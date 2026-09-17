using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace PcDebuger
{
    public enum LoadFileSubCmd : byte
    {
        CONSULT = 0x01,
        START = 0x02,
        TRANSFER = 0x03,
        FILE_END = 0x04,
        SLIDECRC = 0x05,
    }

    public enum ActiveFileSubCmd : byte
    {
        START = 0x01,
        PROGRESS_QUERY = 0x02,
    }

    public enum FileDeviceType : ushort
    {
        MICRO_INV = 0x1100,
        BIG_RELAY = 0x1200,
        PCS = 0x1300,
        BACKUP_BOX = 0x1400,
        BIG_PCS = 0x1700,
    }

    public enum InvSubFileType : byte
    {
        APP = 0x01,
        CPLD = 0x02,
        PLC = 0x03,
        BOOT = 0x04,
    }

    public enum PcsSubFileType : byte
    {
        BMS = 0x01,
        BMS_BOOT = 0x7e,
        APP = 0x02,
        CPLD = 0x03,
        BOOT = 0x04,
    }

    public enum BigPcsSubFileType : byte
    {
        INV_APP = 0x01,
        CPLD = 0x02,
        BST_APP = 0x03,
    }

    public enum CrcResult
    {
        NotGetCrc,
        CrcOk,
        CrcFailed,
    }

    public struct LoadObj
    {
        public byte subFileType;
        public byte memType;
        public uint startAddr;
        public uint memTotalSize;
        public string version;

        public LoadObj(byte fileT, byte memT, uint start, uint memSize, string vrs)
        {
            subFileType = fileT;
            memType = memT;
            startAddr = start;
            memTotalSize = memSize;
            version = vrs;
        }
    }

    public enum UploaderStatus
    {
        Idle,
        Init,
        Start,
        SendFile,
        SendSlideWinCrc,
        SendFileCrc,
        SendActive,
        ExceptEnd,
        ActiveQuery,
        ActiveDelay,
        UploadEnd,
    }

    class UploaderProto
    {
        private MainForm formCaller;
        public ushort mFileType;
        public ushort mOneFrameLen;
        public ushort mSlideFrameNum;
        public ushort mSupportPressMethod;
        public FileDeviceType mDeviceType;
        public List<LoadObj> mLoaderObjs;
        public LoadObj mSelectedLoaderObj;
        public bool mIsConsultSuccess;

        public long mfileSize;
        public byte[] mFileBuffer;
        private int mSendIndex;     //  发送缓存索引偏移
        private int mOneSlideWinIndex;
        private int mPacketNumber;  //  发送的包数
        private int mSlideWinCnt;   //  滑窗计数器，当前滑窗的帧数
        private List<byte> mSendFileBuffer;
        private List<byte> mSendSlidWinList;  //  滑窗数据累计

        public UploaderStatus mUploaderStatus;
        System.Threading.Thread mUploaderThread;
        private byte mSendStartStatus;
        private bool mSendStartGetAck;  //  收到应答标志
        private bool mIsGetFileCrcAck;  //  收到文件CRC校验通过应答
        private DateTime mSenStartCmdTime;
        private byte mSendStartCmdCnt;

        private byte mSendActiveStartStatus;  //  激活启动状态
        private bool mSendActiveStartGetAck;  //  收到应答标志
        private DateTime mSendActiveStartCmdTime;   //  激活启动开始时间
        private byte mSendActiveStartCmdCnt;        //  发送激活启动计数器

        private byte mSendActiveQueryStatus;  //  激活查询状态
        private bool mSendActiveQueryGetAck;  //  查询查询完成标志
        private DateTime mSendActiveQueryCmdTime;   //  激活查询开始时间
        private byte mSendActiveQueryCmdCnt;        //  发送激活查询计数器

        private DateTime mSendActiveDelayStartTime;   //  激活完成延时开始时间
        

        public bool mIsStartLoader;
        private byte mSlideWinCrcStatus;    // 0x00:空闲; 0x01: CRC已发送，等待CRC应答; 0x02: 收到CRC应答，进行CRC比对,
                                            // 比对结束则回到0x00，并回到文件发送，如果校验通过，则发下一个滑窗，否则重新发送当前滑窗，
                                            // 如果重传3次滑窗仍然校验失败，则结束文件发送
        private ushort mCrcVal; //  数采计算出来的CRC
        private ushort mSlideWinCrcValue;
        private CrcResult mCrcResult;
        private DateTime mSendCrcStartTime;
        private int mSendCrcCnt;

        private byte mFileCrcStatus;
        private ushort mFileCrcLoader;
        private ushort mFileCrcLoadee;

        private DateTime mUploaderStartTime;
        private ushort mTaskId;

        public UploaderProto(MainForm f)
        {
            formCaller = f;
            mFileType = 0x0010;
            mOneFrameLen = 128;
            mSlideFrameNum = 32;
            mSupportPressMethod = 0x0000;
            mDeviceType = FileDeviceType.PCS;

            mLoaderObjs = new List<LoadObj>();

            mIsConsultSuccess = false;

            mUploaderStatus = UploaderStatus.Idle;
            mUploaderThread = new Thread(new ThreadStart(UploaderThread));
            mUploaderThread.IsBackground = true;
            mUploaderThread.Start();
            mSendStartCmdCnt = 0;
            mSendActiveStartCmdCnt = 0;
            mSendActiveQueryCmdCnt = 0;
            mSendStartStatus = 0x00;
            mSendActiveStartStatus = 0x00;
            mSendActiveQueryStatus = 0x00;
            mIsStartLoader = false;

            mTaskId = 0x0000;
            mSendFileBuffer = new List<byte>();
            mSendSlidWinList = new List<byte>();
        }

        public void SetTaskId(ushort id)
        {
            mTaskId = id;
        }

        private void UploaderThread()
        {
            while (true)
            {
                //Thread.Sleep(1);

                if (mUploaderStatus == UploaderStatus.Idle)
                {
                    ;
                } 
                else if (mUploaderStatus == UploaderStatus.Init)
                {
                    mUploaderStatus = UploaderStatus.Start;
                    mSendStartCmdCnt = 0;
                    mSendActiveStartCmdCnt = 0;
                    mSendActiveQueryCmdCnt = 0;
                    mSendStartStatus = 0x00;
                    mSendActiveStartStatus = 0x00;
                    mSendActiveQueryStatus = 0x00;
                    mFileCrcStatus = 0x00;

                    mFileCrcLoader = ModbusCrc.Crc16(mFileBuffer, mFileBuffer.Length);
                    mIsGetFileCrcAck = false;
                    mUploaderStartTime = DateTime.Now;
                    Thread.Sleep(1);
                }
                else if (mUploaderStatus == UploaderStatus.Start)
                {
                    byte res = SendStartTask();
                    if (res == 0x00)  //  发送成功
                    {
                        formCaller.LogMsg("收到启动回复，开始传输数据.", true);
                        mUploaderStatus = UploaderStatus.SendFile;
                        mSendIndex = 0;
                        mOneSlideWinIndex = 0;
                        mPacketNumber = 0;
                        mSlideWinCnt = 0;
                    }
                    else if (res == 0x02)  //  超过发送次数
                    {
                        mUploaderStatus = UploaderStatus.ExceptEnd;
                    }
                }
                else if (mUploaderStatus == UploaderStatus.SendFile)
                {
                    byte res = SendFileTask();
                    Thread.Sleep(50);
                    if (res == 0x00)  // 完成一个滑窗发送
                    {
                        mUploaderStatus = UploaderStatus.SendSlideWinCrc;
                        mSlideWinCrcStatus = 0x00;
                    }
                    else if (res == 0x02)  //  文件包有误
                    {
                        mUploaderStatus = UploaderStatus.ExceptEnd;
                    }
                }
                else if (mUploaderStatus == UploaderStatus.SendSlideWinCrc)
                {
                    SendSlideCrcTask();
                }
                else if (mUploaderStatus == UploaderStatus.SendFileCrc)
                {
                    FileCrcTask();
                }
                else if (mUploaderStatus == UploaderStatus.ExceptEnd)
                {
                    mUploaderStatus = UploaderStatus.Idle;
                    mIsStartLoader = false;
                    mFileBuffer = new byte[0];
                    mSendFileBuffer = new List<byte>();
                    mSendSlidWinList = new List<byte>();

                    formCaller.LogMsg("升级失败,退出本次升级\r\n");
                    formCaller.SetProgress(0);
                    formCaller.SetUploadBtn(true);
                }
                else if (mUploaderStatus == UploaderStatus.SendActive)
                {
                    SendActiveStartTask();
                }
                else if (mUploaderStatus == UploaderStatus.ActiveQuery)
                {
                    SendActiveQueryTask();
                }
                else if (mUploaderStatus == UploaderStatus.ActiveDelay)
                {
                    if ((DateTime.Now - mSendActiveDelayStartTime).TotalMilliseconds > 1500)//1.5s
                    {
                        formCaller.LogMsg("激活完成后，延时1.5s完成\r\n");
                        formCaller.LogMsg("延时结束的时间: " + DateTime.Now.ToString(), true);
                        mUploaderStatus = UploaderStatus.UploadEnd;
                    }
                }
                else if (mUploaderStatus == UploaderStatus.UploadEnd)
                {
                    double uploadTotalTime = (DateTime.Now - mUploaderStartTime).TotalSeconds;
                    formCaller.LogMsg("升级所花时间：" + uploadTotalTime.ToString() + " s.\r\n");
                    formCaller.LogMsg("升级完成\r\n");
                    formCaller.SetProgress(0);
                    formCaller.SetUploadBtn(true);
                    mUploaderStatus = UploaderStatus.Idle;
                }
            }
        }

        private void SendActiveQueryCmd()
        {
            byte[] activeCmd = MakeActiveQueryCmd(mSelectedLoaderObj.subFileType);
            formCaller.CommSendCmd(activeCmd);
        }

        private void SendActiveCmd()
        {
            byte[] activeCmd = MakeActiveCmd(mSelectedLoaderObj.subFileType);
            formCaller.CommSendCmd(activeCmd);
        }

        public byte[] MakeActiveCmd(ushort fileType)
        {
            List<byte> sendList = new List<byte>();

            sendList.Add(formCaller.GetModbusAddr());
            sendList.Add(0x43);
            sendList.Add(0x01);
            sendList.Add(0x03);
            ushort frameLen = 0x000C;
            byte lenH = (byte)(frameLen >> 8);
            byte lenL = (byte)(frameLen & 0xFF);
            sendList.Add(lenH);
            sendList.Add(lenL);

            sendList.Add(0x01);
            sendList.Add(0x02);
            sendList.Add(0x00);
            sendList.Add(0x10);

            sendList.Add(0x02);
            sendList.Add(0x02);
            sendList.Add(0x17);
            sendList.Add(0x00);

            sendList.Add(0x03);
            sendList.Add(0x02);
            sendList.Add((byte)(fileType >> 8));
            sendList.Add((byte)(fileType & 0xFF));

            byte[] crcDat = sendList.ToArray();
            // 发送Checksum
            ushort crcShort = ModbusCrc.Crc16(crcDat, crcDat.Length);
            sendList.Add((byte)(crcShort & 0xFF));
            sendList.Add((byte)(crcShort >> 8));

            return sendList.ToArray();
        }

        // 返回值：0x00=发送成功；0x01=等待发送成功中； 0x02=发送失败
        private byte SendActiveQueryTask()
        {
            if (mSendActiveQueryStatus == 0x00)
            {
                SendActiveQueryCmd();
                mSendActiveQueryStatus = 0x01;
                mSendActiveQueryGetAck = false;
                mSendActiveQueryCmdTime = DateTime.Now;
            }
            else if (mSendActiveQueryStatus == 0x01)
            {
                if (mSendActiveQueryGetAck)
                {
                    mSendActiveQueryStatus = 0x00;

                    if (mSelectedLoaderObj.subFileType == (byte)PcsSubFileType.BMS)//升级bms_app
                    {
                        mSendActiveDelayStartTime = DateTime.Now;
                        formCaller.LogMsg("开始延时的时间: " + mSendActiveDelayStartTime.ToString(), true);
                        mUploaderStatus = UploaderStatus.ActiveDelay;
                    }
                    else
                    {
                        formCaller.LogMsg("激活完成\r\n");
                        mUploaderStatus = UploaderStatus.UploadEnd;
                    }
                    return 0x00;
                }
                else
                {
                    if ((DateTime.Now - mSendActiveQueryCmdTime).TotalMilliseconds > 10000)
                    {
                        mSendActiveQueryStatus = 0x00;
                        mSendActiveQueryCmdCnt++;
                        if (mSendActiveQueryCmdCnt > 7)
                        {
                            mSendActiveQueryCmdCnt = 0;
                            formCaller.LogMsg("重试激活查询命令超过次数\r\n");
                            formCaller.LogMsg("升级失败,退出本次升级\r\n");
                            formCaller.SetProgress(0);
                            formCaller.SetUploadBtn(true);
                            mUploaderStatus = UploaderStatus.Idle;
                            return 0x02;
                        }
                        formCaller.LogMsg("重试激活查询命令\r\n");
                    }
                    return 0x01;
                }
            }
            return 0x01;
        }

        // 返回值：0x00=发送成功；0x01=等待发送成功中； 0x02=发送失败
        private byte SendActiveStartTask()
        {
            if (mSendActiveStartStatus == 0x00)
            {
                SendActiveCmd();
                mSendActiveStartStatus = 0x01;
                mSendActiveStartGetAck = false;
                mSendActiveStartCmdTime = DateTime.Now;
            }
            else if (mSendActiveStartStatus == 0x01)
            {
                if (mSendActiveStartGetAck)
                {
                    mSendActiveStartStatus = 0x00;
                    mUploaderStatus = UploaderStatus.ActiveQuery;
                    return 0x00;
                }
                else
                {
                    if ((DateTime.Now - mSendActiveStartCmdTime).TotalMilliseconds > 5000)
                    {
                        mSendActiveStartStatus = 0x00;
                        mSendActiveStartCmdCnt++;
                        if (mSendActiveStartCmdCnt > 5)
                        {
                            mSendActiveStartCmdCnt = 0;
                            formCaller.LogMsg("重试激活启动命令超过次数\r\n");
                            formCaller.LogMsg("升级失败,退出本次升级\r\n");
                            formCaller.SetProgress(0);
                            formCaller.SetUploadBtn(true);
                            mUploaderStatus = UploaderStatus.Idle;
                            return 0x02;
                        }
                        formCaller.LogMsg("重试激活启动命令\r\n");
                    }
                    return 0x01;
                }
            }
            return 0x01;
        }

        public byte[] MakeActiveQueryCmd(ushort fileType)
        {
            List<byte> sendList = new List<byte>();

            sendList.Add(formCaller.GetModbusAddr());
            sendList.Add(0x43);
            sendList.Add(0x02);
            sendList.Add(0x01);
            ushort frameLen = 0x0004;
            byte lenH = (byte)(frameLen >> 8);
            byte lenL = (byte)(frameLen & 0xFF);
            sendList.Add(lenH);
            sendList.Add(lenL);

            sendList.Add(0x01);
            sendList.Add(0x02);
            sendList.Add((byte)(fileType >> 8));
            sendList.Add((byte)(fileType & 0xFF));

            byte[] crcDat = sendList.ToArray();
            // 发送Checksum
            ushort crcShort = ModbusCrc.Crc16(crcDat, crcDat.Length);
            sendList.Add((byte)(crcShort & 0xFF));
            sendList.Add((byte)(crcShort >> 8));

            return sendList.ToArray();
        }

        private void FileCrcTask()
        {
            if (mFileCrcStatus == 0x00)
            {
                mFileCrcLoadee = 0x00;
                mIsGetFileCrcAck = false;
                mFileCrcStatus = 0x01;
                //Thread.Sleep(1000);
            }
            if (mFileCrcStatus == 0x01)
            {
                SendFileFinishCmd(mFileCrcLoader);
                mFileCrcStatus = 0x02;
                //  超时计时开始
                mSendCrcStartTime = DateTime.Now;
            }
            else if (mFileCrcStatus == 0x02)
            {
                if (mIsGetFileCrcAck)
                {
                    mFileCrcStatus = 0x03;
                }
                else
                {
                    //  超时计时对比
                    bool reSendFlag = ((DateTime.Now - mSendCrcStartTime).TotalMilliseconds > 15000);
                    if (reSendFlag)
                    {
                        formCaller.LogMsg("超时未收到文件CRC校验，退出\r\n");
                        mUploaderStatus = UploaderStatus.ExceptEnd;      //  异常结束文件传输流程
                    }
                }
            }
            else if (mFileCrcStatus == 0x03)
            {
                if (mFileCrcLoader == mFileCrcLoadee)
                {
                    formCaller.LogMsg("文件CRC校验通过\r\n");
                    mUploaderStatus = UploaderStatus.SendActive;
                }
                else
                {
                    formCaller.LogMsg("文件CRC校验失败\r\n");
                    mUploaderStatus = UploaderStatus.ExceptEnd;
                }

                mFileBuffer = new byte[0];
            }
        }

        private void SendFileFinishCmd(ushort crc)
        {
            List<byte> sendList = new List<byte>();
            sendList.Add(formCaller.GetModbusAddr());
            sendList.Add(0x42);
            sendList.Add(0x04);
            sendList.Add(0x02);
            int frameLen = 0x0008;
            byte lenH = (byte)(frameLen >> 8);
            byte lenL = (byte)(frameLen & 0xFF);
            sendList.Add(lenH);
            sendList.Add(lenL);

            sendList.Add(0x01);
            sendList.Add(0x02);
            sendList.Add(0x00);
            sendList.Add((byte)mTaskId);

            sendList.Add(0x02);
            sendList.Add(0x02);
            sendList.Add((byte)(crc >> 8));
            sendList.Add((byte)(crc & 0xFF));

            byte[] crcDat = sendList.ToArray();
            ushort crcShort = ModbusCrc.Crc16(crcDat, crcDat.Length);
            sendList.Add((byte)(crcShort & 0xFF));
            sendList.Add((byte)(crcShort >> 8));

            formCaller.CommSendCmd(sendList.ToArray());
            formCaller.LogMsg("SendFileCrcCmd\r\n");
            formCaller.LogMsg(sendList.ToArray(), true);
            sendList.Clear();

        }

        // 返回值：0x00=发送成功；0x01=等待发送成功中； 0x02=发送失败
        private byte SendStartTask()
        {
            if (mSendStartStatus == 0x00)
            {
                SendStartCmd();
                mSendStartStatus = 0x01;
                mSendStartGetAck = false;
                mSenStartCmdTime = DateTime.Now;
            }
            else if (mSendStartStatus == 0x01)
            {
                if (mSendStartGetAck)
                {
                    mSendStartStatus = 0x00;
                    return 0x00;
                }
                else
                {
                    if ((DateTime.Now - mSenStartCmdTime).TotalMilliseconds > 20000)
                    {
                        mSendStartStatus = 0x00;
                        mSendStartCmdCnt++;
                        if (mSendStartCmdCnt > 5)
                        {
                            mSendStartCmdCnt = 0;
                            formCaller.LogMsg("重试启动命令超过次数\r\n");
                            return 0x02;
                        }
                        formCaller.LogMsg("重试启动命令\r\n");
                    }
                    return 0x01;
                }
            }
            return 0x01;
        }

        private void SendSlideCrcTask()
        {
            if (mSlideWinCrcStatus == 0x00)
            {
                uint startFrameId = (uint)(mPacketNumber - mSlideWinCnt);
                byte[] crcDat = mSendSlidWinList.ToArray();
                //formCaller.LogMsg("滑窗数据:");
                //formCaller.LogMsg(crcDat);
                //formCaller.LogMsg("\r\n");

                mCrcVal = ModbusCrc.Crc16(crcDat, crcDat.Length);
                mSlideWinCrcValue = mCrcVal;

                formCaller.LogMsg("起始帧号: " + startFrameId.ToString(), true);
                SendSlideWinCrcCmd(startFrameId, (ushort)mSlideWinCnt, mCrcVal);
                mCrcResult = CrcResult.NotGetCrc;
                mSlideWinCrcStatus = 0x01;
                //  超时计时开始
                mSendCrcStartTime = DateTime.Now;
                mSendCrcCnt = 0;
            }
            else if (mSlideWinCrcStatus == 0x01)  //  等待CRC应答
            {
                bool reSendFlag = false;
                if (mCrcResult == CrcResult.CrcOk)
                {
                    mSlideWinCrcStatus = 0x02;
                }
                else if (mCrcResult == CrcResult.CrcFailed)
                {
                    reSendFlag = true;
                    formCaller.LogMsg("滑窗CRC校验失败，重新传输\r\n");
                }
                else
                {
                    //  超时计时对比
                    reSendFlag = ((DateTime.Now - mSendCrcStartTime).TotalMilliseconds > 12000);
                    if (reSendFlag)
                    {
                        formCaller.LogMsg("超时未收到滑窗CRC校验，重新传输\r\n");
                    }
                    //reSendFlag = false;
                    //mUploaderStatus = UploaderStatus.ExceptEnd;      //  异常结束文件传输流程
                }

                if (reSendFlag)
                {
                    //  超时触发重发滑窗机制
                    mSendIndex = mSendIndex - mOneSlideWinIndex;  //  文件指针回到上一个滑窗的位置
                    mPacketNumber = mPacketNumber - mSlideWinCnt;
                    mSendSlidWinList.Clear();
                    mSendFileBuffer.Clear();
                    mOneSlideWinIndex = 0;
                    mSlideWinCnt = 0;

                    mSendCrcCnt++; // 重传次数累计
                    if (mSendCrcCnt > 3)
                    {
                        formCaller.LogMsg("超过重传次数，传输结束\r\n");
                        mUploaderStatus = UploaderStatus.ExceptEnd;      //  异常结束文件传输流程
                    }
                    else
                    {
                        mUploaderStatus = UploaderStatus.SendFile;      //  回到文件发送任务
                    }
                }
            }
            else if (mSlideWinCrcStatus == 0x02)  //  CRC校验通过，可以发下一个滑窗
            {
                mSendCrcCnt = 0;
                mSlideWinCnt = 0;
                mOneSlideWinIndex = 0;
                mSlideWinCrcStatus = 0x00;
                mSendSlidWinList.Clear();
                mSendFileBuffer.Clear();

                int prog = mSendIndex * 100 / ((int)mfileSize);
                if (prog > 100)
                {
                    prog = 100;
                }
                formCaller.SetProgress(prog);

                if (mSendIndex >= mFileBuffer.Length)
                {
                    mUploaderStatus = UploaderStatus.SendFileCrc;      //  文件发送完毕
                    //mFileCrcStatus = 0x00;
                    Thread.Sleep(50);
                    formCaller.LogMsg("文件传输完成\r\n");
                }
                else
                {
                    mUploaderStatus = UploaderStatus.SendFile;      //  回到文件发送任务
                }
            }

        }

        private byte SendFileTask()
        {
            if (mFileBuffer.Length == 0)
            {
                formCaller.LogMsg("buffer no data");
                return 0x02;
            }
            //formCaller.LogMsg("数据长度：" + mFileBuffer.Length.ToString());

            for (int i = 0; i < mOneFrameLen; i++)
            {
                if (mSendIndex < mFileBuffer.Length)
                {
                    mSendFileBuffer.Add(mFileBuffer[mSendIndex++]);
                    mOneSlideWinIndex++;
                }
                else
                {
                    break;
                }
            }

            SendPacket(mSendFileBuffer.ToArray(), mSendFileBuffer.Count, mPacketNumber);
            mSendSlidWinList.AddRange(mSendFileBuffer.ToArray());

            mPacketNumber++;
            mSlideWinCnt++;
            //formCaller.LogMsg(mPacketNumber.ToString() + " 包, 已发送：" + mSendIndex.ToString() + "字节\r\n");

            if (mSlideWinCnt >= mSlideFrameNum || mSendIndex >= mFileBuffer.Length)
            {
                //formCaller.LogMsg(mSendSlidWinList.ToArray());
                //formCaller.LogMsg("进入CRC命令发送任务\r\n");
                mSlideWinCrcStatus = 0x00;
                return 0x00;
            }
            mSendFileBuffer.Clear();
            return 0x01;
        }

        private void SendPacket(byte[] data, int len, int packetNumber)
        {
            List<byte> sendList = new List<byte>();

            sendList.Add(formCaller.GetModbusAddr());
            sendList.Add(0x42);
            sendList.Add(0x03);
            sendList.Add(0x04);
            int frameLen = len + 16;
            byte lenH = (byte)(frameLen >> 8);
            byte lenL = (byte)(frameLen & 0xFF);
            sendList.Add(lenH);
            sendList.Add(lenL);

            sendList.Add(0x01);
            sendList.Add(0x02);
            sendList.Add(0x00);
            sendList.Add((byte)mTaskId);

            sendList.Add(0x02);
            sendList.Add(0x04);
            sendList.Add((byte)(packetNumber >> 24));
            sendList.Add((byte)(packetNumber >> 16));
            sendList.Add((byte)(packetNumber >> 8));
            sendList.Add((byte)(packetNumber & 0xFF));

            sendList.Add(0x03);
            sendList.Add(0x02);
            sendList.Add((byte)(len >> 8));
            sendList.Add((byte)(len & 0xFF));

            sendList.Add(0x04);
            sendList.Add((byte)(len & 0xFF));


            // 发送数据
            byte[] tDat = new byte[len];
            for (int i = 0; i < len; i++)
            {
                tDat[i] = data[i];
            }
            sendList.AddRange(tDat);

            byte[] crcDat = sendList.ToArray();
            // 发送Checksum
            ushort crcShort = ModbusCrc.Crc16(crcDat, crcDat.Length);
            sendList.Add((byte)(crcShort & 0xFF));
            sendList.Add((byte)(crcShort >> 8));

            formCaller.CommSendCmd(sendList.ToArray());
            sendList.Clear();
        }

        private void SendSlideWinCrcCmd(uint startFrameNum, ushort slideWinNum, ushort crc)
        {
            List<byte> sendList = new List<byte>();
            sendList.Add(formCaller.GetModbusAddr());
            sendList.Add(0x42);
            sendList.Add(0x05);
            sendList.Add(0x04);
            int frameLen = 0x0012;
            byte lenH = (byte)(frameLen >> 8);
            byte lenL = (byte)(frameLen & 0xFF);
            sendList.Add(lenH);
            sendList.Add(lenL);

            sendList.Add(0x01);
            sendList.Add(0x02);
            sendList.Add(0x00);
            sendList.Add((byte)mTaskId);

            sendList.Add(0x02);
            sendList.Add(0x04);
            sendList.Add((byte)(startFrameNum >> 24));
            sendList.Add((byte)(startFrameNum >> 16));
            sendList.Add((byte)(startFrameNum >> 8));
            sendList.Add((byte)(startFrameNum & 0xFF));

            sendList.Add(0x03);
            sendList.Add(0x02);
            sendList.Add((byte)(slideWinNum >> 8));
            sendList.Add((byte)(slideWinNum & 0xFF));

            sendList.Add(0x04);
            sendList.Add(0x02);
            sendList.Add((byte)(crc >> 8));
            sendList.Add((byte)(crc & 0xFF));

            byte[] crcDat = sendList.ToArray();
            ushort crcShort = ModbusCrc.Crc16(crcDat, crcDat.Length);
            sendList.Add((byte)(crcShort & 0xFF));
            sendList.Add((byte)(crcShort >> 8));

            formCaller.CommSendCmd(sendList.ToArray());
            //formCaller.LogMsg("SendSlideWinCrcCmd\r\n");
            sendList.Clear();

        }

        private void SendStartCmd()
        {
            byte[] startCmd = MakeStartCmd((ushort)mOneFrameLen, (ushort)mSlideFrameNum, (ushort)mDeviceType, (uint)mFileBuffer.Length, (ushort)mSelectedLoaderObj.subFileType, 1);
            formCaller.LogMsg(startCmd, true);
            formCaller.CommSendCmd(startCmd);
        }

        public byte[] MakeStartCmd(ushort oneFrameSize, ushort oneWinFrames, ushort deviceType, uint fileSize, ushort fileType, byte forceUpdate)
        {
            List<byte> sendList = new List<byte>();

            sendList.Add(formCaller.GetModbusAddr());
            sendList.Add(0x42);
            sendList.Add(0x02);
            sendList.Add(0x08);
            ushort frameLen = 0x0021;
            byte lenH = (byte)(frameLen >> 8);
            byte lenL = (byte)(frameLen & 0xFF);
            sendList.Add(lenH);
            sendList.Add(lenL);

            sendList.Add(0x01);
            sendList.Add(0x02);
            sendList.Add(0x00);
            sendList.Add(0x10);

            sendList.Add(0x02);
            sendList.Add(0x02);
            lenH = (byte)(oneFrameSize >> 8);
            lenL = (byte)(oneFrameSize & 0xFF);
            sendList.Add(lenH);
            sendList.Add(lenL);

            sendList.Add(0x03);
            sendList.Add(0x02);
            lenH = (byte)(oneWinFrames >> 8);
            lenL = (byte)(oneWinFrames & 0xFF);
            sendList.Add(lenH);
            sendList.Add(lenL);

            sendList.Add(0x04);
            sendList.Add(0x02);
            sendList.Add(0x00);
            sendList.Add(0x00);

            sendList.Add(0x05);
            sendList.Add(0x04);
            uint fileLen = fileSize;
            sendList.Add((byte)(fileLen >> 24));
            sendList.Add((byte)(fileLen >> 16));
            sendList.Add((byte)(fileLen >> 8));
            sendList.Add((byte)(fileLen & 0xFF));

            sendList.Add(0x06);
            sendList.Add(0x02);
            sendList.Add((byte)(deviceType >> 8));
            sendList.Add((byte)(deviceType & 0xFF));

            sendList.Add(0x07);
            sendList.Add(0x02);
            sendList.Add((byte)(fileType >> 8));
            sendList.Add((byte)(fileType & 0xFF));

            sendList.Add(0x08);
            sendList.Add(0x01);
            sendList.Add(forceUpdate);

            byte[] crcDat = sendList.ToArray();
            // 发送Checksum
            ushort crcShort = ModbusCrc.Crc16(crcDat, crcDat.Length);
            sendList.Add((byte)(crcShort & 0xFF));
            sendList.Add((byte)(crcShort >> 8));

            return sendList.ToArray();
        }

        public byte[] MakeConsultCmd()
        {
            List<byte> sendList = new List<byte>();

            ModbusTlvProto consultCmd = new ModbusTlvProto();
            consultCmd.addr = formCaller.GetModbusAddr();
            consultCmd.cmd = (byte)ModbusCmd.LOAD_FILE;
            consultCmd.subCmd = (byte)LoadFileSubCmd.CONSULT;
            consultCmd.tagNum = 4;
            consultCmd.datLen = 0;  // update later
            consultCmd.tlvList = new List<TLV_Unit>();

            TLV_Unit tlv = new TLV_Unit();
            tlv.Type = 0x01;
            tlv.Length = 0x02;
            tlv.Value = new byte[2];
            tlv.Value[0] = (byte)(mFileType >> 8);
            tlv.Value[1] = (byte)(mFileType & 0x00FF);
            consultCmd.tlvList.Add(tlv);

            tlv.Type = 0x02;
            tlv.Length = 0x02;
            tlv.Value = new byte[2];
            tlv.Value[0] = (byte)(mOneFrameLen >> 8);
            tlv.Value[1] = (byte)(mOneFrameLen & 0x00FF);
            consultCmd.tlvList.Add(tlv);

            tlv.Type = 0x03;
            tlv.Length = 0x02;
            tlv.Value = new byte[2];
            tlv.Value[0] = (byte)(mSlideFrameNum >> 8);
            tlv.Value[1] = (byte)(mSlideFrameNum & 0x00FF);
            consultCmd.tlvList.Add(tlv);

            tlv.Type = 0x04;
            tlv.Length = 0x02;
            tlv.Value = new byte[2];
            tlv.Value[0] = (byte)(mSupportPressMethod >> 8);
            tlv.Value[1] = (byte)(mSupportPressMethod & 0x00FF);
            consultCmd.tlvList.Add(tlv);

            return ModbusProto.MakeModbusFrame(consultCmd);
        }

        public void UploaderRecvProcess(ModbusTlvProto tlvFrame)
        {
            if (tlvFrame.cmd == (byte)ModbusCmd.LOAD_FILE)
            {
                switch ((LoadFileSubCmd)tlvFrame.subCmd)
                {
                    case LoadFileSubCmd.CONSULT:
                        GetConsultResult(tlvFrame);  //  上位机对协商回复的报文进行解析
                        break;
                    case LoadFileSubCmd.START:
                        mSendStartGetAck = true;
                        foreach (TLV_Unit tlv in tlvFrame.tlvList)
                        {
                            if (tlv.Type == 9)
                            {
                                mTaskId = (ushort)tlv.Value[1];
                            }
                        }
                        break;
                    case LoadFileSubCmd.SLIDECRC:
                        formCaller.LogMsg("上位机滑窗校验成功.\r\n");
                        mCrcResult = CrcResult.CrcOk;
                        break;
                    case LoadFileSubCmd.TRANSFER:
                        break;
                    case LoadFileSubCmd.FILE_END:
                        if (tlvFrame.tagNum != 2 || tlvFrame.tlvList == null)
                        {
                            return;
                        }
                        mFileCrcLoadee = (ushort)((tlvFrame.tlvList[1].Value[0] << 8) + tlvFrame.tlvList[1].Value[1]);
                        mIsGetFileCrcAck = true;
                        break;
                    default:
                        break;
                }               
            }
            else if (tlvFrame.cmd == (byte)ModbusCmd.ACTIVE_FILE)
            {
                switch ((ActiveFileSubCmd)tlvFrame.subCmd)
                {
                    case ActiveFileSubCmd.START:
                        GetActiveFileStartResult(tlvFrame);  
                        break;
                    case ActiveFileSubCmd.PROGRESS_QUERY:
                        GetActiveFileQueryResult(tlvFrame);  
                        break;
                    default:
                        break;
                }
            }
        }

        public void GetActiveFileStartResult(ModbusTlvProto tlvFrame)
        {
            if (tlvFrame.tlvList == null)
            {
                return;
            }

            for (int i = 0; i < tlvFrame.tagNum; i++)
            {
                TLV_Unit tlv = tlvFrame.tlvList[i];

                switch (tlv.Type)
                {
                    case 0x05:
                        ushort taskId = (ushort)((tlv.Value[0] << 8) + tlv.Value[1]);
                        if (0x01 == taskId || 0x02 == taskId || 0x03 == taskId)  //  0x01: inv app， 0x02: cpld， 0x03: bst app
                        {
                            formCaller.LogMsg("激活启动完成", true);
                            mSendActiveStartGetAck = true;
                        }
                        else 
                        {
                            formCaller.LogMsg("激活启动失败", true);
                        }                        
                        break;
                    default:
                        break;
                }
            }
        }

        public void GetActiveFileQueryResult(ModbusTlvProto tlvFrame)
        {
            if (tlvFrame.tlvList == null)
            {
                return;
            }

            for (int i = 0; i < tlvFrame.tagNum; i++)
            {
                TLV_Unit tlv = tlvFrame.tlvList[i];

                switch (tlv.Type)
                {
                    case 0x01:
                        ushort taskId = (ushort)((tlv.Value[0] << 8) + tlv.Value[1]);
                        if (0x01 != taskId && 0x02 != taskId)
                        {
                            formCaller.LogMsg("激活查询到任务id不匹配", true);
                        }
                        break;
                    case 0x03:
                        int progActive = (ushort)(tlv.Value[0]);
                        if (progActive == 0x64)//100%
                        {
                            formCaller.LogMsg("激活进度达100%", true);
                            mSendActiveQueryGetAck = true;
                        }
                        else
                        {
                            formCaller.LogMsg("激活进度达" + progActive.ToString() +"%", true);
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        public void GetConsultResult(ModbusTlvProto tlvFrame)
        {
            formCaller.LogMsg("TAG数：" + tlvFrame.tagNum.ToString(), true);
            ushort len = tlvFrame.datLen;
            formCaller.LogMsg("数据长度： " + len.ToString(), true);
            if (tlvFrame.tlvList == null)
            {
                return;
            }

            mLoaderObjs.Clear();
            mLoaderObjs = new List<LoadObj>();
            
            for (int i = 0; i < tlvFrame.tagNum; i++)
            {
                if (i < tlvFrame.tlvList.Count)
                {
                    TLV_Unit tlv = tlvFrame.tlvList[i];
                    formCaller.LogMsg("Type：" + tlv.Type.ToString() + ", ");
                    formCaller.LogMsg("Length：" + tlv.Length.ToString() + ", ");
                    formCaller.LogMsg("Value：", false);
                    formCaller.LogMsg(tlv.Value, true);

                    switch (tlv.Type)
                    {
                        case 0x01:
                            mFileType = (ushort)((tlv.Value[0] << 8) + tlv.Value[1]);
                            break;
                        case 0x02:
                            //mOneFrameLen = (ushort)((tlv.Value[0] << 8) + tlv.Value[1]);
                            break;
                        case 0x03:
                            mSlideFrameNum = (ushort)((tlv.Value[0] << 8) + tlv.Value[1]);
                            break;
                        case 0x06:
                            mDeviceType = (FileDeviceType)((tlv.Value[0] << 8) + tlv.Value[1]);
                            byte[] versionArray = new byte[tlv.Value[4]];
                            for (int j = 0; j < versionArray.Length; j++)
                            {
                                versionArray[j] = tlv.Value[5 + j];
                            }
                            string versionString = Encoding.UTF8.GetString(versionArray);
                            LoadObj loader = new LoadObj(tlv.Value[3], 0, 0, 0, versionString);
                            mLoaderObjs.Add(loader);
                            break;
                        case 0x07:
                            if (tlv.Value[0] == 0x01)
                            {
                                formCaller.LogMsg("Now in boot!", true);
                            }
                            else
                            {
                                formCaller.LogMsg("Now in app!", true);
                            }
                            mIsConsultSuccess = true;
                            break;
                        default:
                            break;
                    }

                    
                }
            }
            formCaller.UpdateConsultResult();
            formCaller.LogMsg("crc：" + tlvFrame.crc.ToString(), true);
        }   
     
    }
}
