using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Collections;

namespace PcDebuger
{
    public enum Serial_SendStatus
    {
        TryToDequeue,
        ActSend,
        Wait,
    }

    public enum Serial_RecvStatus
    {
        TryToDequeue,
        ActRecv,
        Wait,
    }

    class SerialBufferThread
    {
        private Queue mUartSendQueue;
        public Queue mUartRecvQueue;  //  因为接收处理比较耗时，当数据发得比较快的时候容易导致连帧，因此先把接收到的数据缓存起来，用另一个线程来处理串口数据
        private Queue<CAN_Frame> mCanSendQueue;
        private MainForm formCaller;
        Serial_SendStatus mSerialSendStatus;
        private CAN_Frame mCanFrameUnit;
        private byte[] mUartFrameUnit;
        private byte mUartSendCnt;
        private DateTime mSendStartTime;
        private int mSendDelayTime;
        System.Threading.Thread mSerialSendThread;
        System.Threading.Thread mSerialRecvThread;

        private DateTime mPeriodSendStartTime;
        private byte mPeriodSendStatus;
        private uint mDelayCnt;

        public SerialBufferThread(MainForm f)
        {
            formCaller = f;
            mCanSendQueue = new System.Collections.Generic.Queue<CAN_Frame>();
            mUartSendQueue = new Queue();
            mUartRecvQueue = new Queue();

            mSerialSendStatus = Serial_SendStatus.TryToDequeue;
            mSendStartTime = DateTime.Now;
            mSerialSendThread = new Thread(new ThreadStart(SerialSendThread));
            mSerialSendThread.IsBackground = true;
            mSerialSendThread.Start();

            mSerialRecvThread = new Thread(new ThreadStart(SerialRecvThread));
            mSerialRecvThread.IsBackground = true;
            mSerialRecvThread.Start();

            mPeriodSendStartTime = DateTime.Now;
            mPeriodSendStatus = 0;
            mUartSendCnt = 0;
            mDelayCnt = 0;
        }

        public void CanSendEnqueue(CAN_Frame frame)
        {
            if (formCaller.mCommMode == CommMode.CAN)
            {
                mCanSendQueue.Enqueue(frame);
            }
            else
            {
                formCaller.LogMsg("通信模式有误！", true);
            }
        }

        public bool CanBufferIsEmpty()
        {
            return (mCanSendQueue.Count == 0) ? true : false;
        }

        public void UartSendEnqueue(byte[] frame)
        {
            if (formCaller.mCommMode == CommMode.UART)
            {
                mUartSendQueue.Enqueue(frame);
            }
            else
            {
                formCaller.LogMsg("通信模式有误！", true);
            }            
        }

        public bool UartBufferIsEmpty()
        {
            return (mUartSendQueue.Count == 0) ? true : false;
        }

        public void UartRecvEnqueue(byte[] frame)
        {
            if (formCaller.mCommMode == CommMode.UART)
            {
                mUartRecvQueue.Enqueue(frame);
            }
            else
            {
                formCaller.LogMsg("通信模式有误！", true);
            }
        }

        private bool SerialSendThread_TryToDequeue()
        {
            if (formCaller.mCommMode == CommMode.UART)
            {
                if (mUartSendQueue.Count > 0)
                {
                    mUartFrameUnit = (byte[])mUartSendQueue.Dequeue();
                    if (mUartFrameUnit != null && mUartFrameUnit.Length > 0)
                    {
                        mSendDelayTime = 25;
                        return true;
                    }
                }
            }
            else if (formCaller.mCommMode == CommMode.CAN)
            {
                if (mCanSendQueue.Count > 0)
                {
                    mCanFrameUnit = (CAN_Frame)mCanSendQueue.Dequeue();
                    if (mCanFrameUnit.mData != null && mCanFrameUnit.len > 0)
                    {
                        mSendDelayTime = 0;
                        return true;
                    }
                }
            }
            return false;
        }

        private bool SerialSendThread_ActSend()
        {
            if (formCaller.mCommMode == CommMode.UART)
            {
                if (mUartFrameUnit != null && mUartFrameUnit.Length > 0)
                {
                    formCaller.UART_SendData(mUartFrameUnit, mUartFrameUnit.Length);
                    return true;
                }
            }
            else if (formCaller.mCommMode == CommMode.CAN)
            {
                if (mCanFrameUnit.mData != null && mCanFrameUnit.len > 0)
                {
                    formCaller.CAN_SendData(mCanFrameUnit);
                    return true;
                }
            }
            return false;
        }

        private void SerialRecvThread()
        {
            while (true)
            {
                if (mUartRecvQueue.Count > 0)
                {
                    byte[] dataBuf = (byte[])mUartRecvQueue.Dequeue();
                    formCaller.LogMsg("Recv " + dataBuf.Length.ToString() + " data.\r\n");
                    if (!formCaller.mIsLoading)
                    {
                        formCaller.LogMsg(dataBuf, true);
                    }
                    formCaller.CommRecvCallback(dataBuf);
                }
                Thread.Sleep(30);
            }
        }

        private void SerialSendThread()
        {
            while (true)
            {
                //PeriodSendTask();
                if (mSerialSendStatus == Serial_SendStatus.TryToDequeue)  //  读取数据
                {
                    if (SerialSendThread_TryToDequeue())
                    {
                        mSerialSendStatus = Serial_SendStatus.ActSend;
                    }
                }
                else if (mSerialSendStatus == Serial_SendStatus.ActSend)
                {
                    if (SerialSendThread_ActSend())
                    {
                        mSerialSendStatus = Serial_SendStatus.Wait;
                        mSendStartTime = DateTime.Now;
                    }
                    else
                    {
                        mSerialSendStatus = Serial_SendStatus.TryToDequeue;
                    }
                }
                else if (mSerialSendStatus == Serial_SendStatus.Wait)
                {
                    mSerialSendStatus = Serial_SendStatus.TryToDequeue;
                }
                if (mSendDelayTime == 0)
                {
                    mDelayCnt++;
                    if (mDelayCnt > 16)
                    {
                        mDelayCnt = 0;
                        Thread.Sleep(1);
                    }
                }
                else
                {
                    Thread.Sleep(mSendDelayTime);
                }
                
                //Thread.Sleep(1);
            }
        }

        private void PeriodSendTask()
        {
            if (!formCaller.mIsSendPeriod)
            {
                mUartSendCnt = 0;
                return;
            }
            if (mPeriodSendStatus == 0)
            {
                mUartFrameUnit = new byte[100];
                //for (int i = 0; i < mUartFrameUnit.Length; i++)
                //{
                //    mUartFrameUnit[i] = (byte)i;
                //}
                mUartFrameUnit[0] = mUartSendCnt++;
                formCaller.UART_SendData(mUartFrameUnit, mUartFrameUnit.Length);
                mPeriodSendStatus = 1;
                mPeriodSendStartTime = DateTime.Now;
            }
            else if (mPeriodSendStatus == 1)
            {
                mPeriodSendStartTime = DateTime.Now;
                Thread.Sleep(formCaller.mSendPeriod);
                formCaller.LogMsg((DateTime.Now - mPeriodSendStartTime).TotalMilliseconds.ToString(), true);
                mPeriodSendStatus = 0;
                
            }
        }

    }
}
