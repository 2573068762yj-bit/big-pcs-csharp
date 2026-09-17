using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;
using System.Threading;

namespace PcDebuger
{
    public delegate void UART_RecvCallback(byte[] frame);
    public class UART_RecvEventSource
    {
        public event UART_RecvCallback UartRecvCallback;

        public void RaiseEvent(byte[] frame)
        {
            if (UartRecvCallback != null)
            {
                UartRecvCallback.Invoke(frame);
            }
        }
    }

    partial class MainForm
    {
        UART_RecvEventSource mUartRecvEvent;
        System.Threading.Thread mUartRecvThread;
        private bool mIsRecving;
        private int mRecvTimeOutCnt;

        public void InitUartConfigView()
        {
            // 初始化串口列表
            string[] portNames = SerialPort.GetPortNames();
            cmbPortName.Items.AddRange(portNames);

            // 初始化波特率列表
            cmbBaudRate.Items.AddRange(new object[] { 4800, 9600, 19200, 38400, 57600, 115200, 500000 });
            cmbBaudRate.SelectedIndex = 5;

            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);

            mUartRecvEvent = new UART_RecvEventSource();
            //mUartRecvEvent.UartRecvCallback += ShowUartRecvData;
            mUartRecvEvent.UartRecvCallback += CommRecvCallback;

            mUartRecvThread = new Thread(new ThreadStart(UartRecvThread));
            mUartRecvThread.IsBackground = true;
            mUartRecvThread.Priority = ThreadPriority.Highest;
            mUartRecvThread.Start();

            mIsRecving = false;
            mRecvTimeOutCnt = 0;
        }

        private void UartRecvThread()
        {
            while (true)
            {
                Thread.Sleep(5);
                if (!serialPort1.IsOpen)
                {
                    continue;
                }
                if(mIsRecving)
                {
                    if (mRecvTimeOutCnt++ > 2)
                    {
                        byte[] buffer = new byte[serialPort1.BytesToRead];
                        serialPort1.Read(buffer, 0, buffer.Length);
                        mSerialBufferThread.mUartRecvQueue.Enqueue(buffer);
                        mIsRecving = false;
                        mRecvTimeOutCnt = 0;
                    }
                }
            }
        }
        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            // 接收数据
            if (serialPort1.IsOpen)
            {
                mRecvTimeOutCnt = 0;
                mIsRecving = true; // Recving
            }
        }

        private void ShowUartRecvData(byte[] data)
        {
            if (mIsShowRecvFlag)
            {
                LogMsg("Uart Rx: ", false);
                LogMsg(data, true);
            }
        }

        private void SendBtnData_Uart(string frame)
        {
            if (frame.Length == 0)
            {
                MessageBox.Show("数据为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (serialPort1.IsOpen)
            {
                string sendData = txtSendData.Text;
                byte[] bytes;

                if (mIsHexSend) // 如果选择Hex发送
                {
                    try
                    {
                        string[] words = sendData.Split(' ');
                        sendData = string.Join(string.Empty, words);
                        bytes = DataFormatConvert.HexStringToAscii(sendData);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("无法转换为Hex格式：" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    bytes = System.Text.Encoding.Default.GetBytes(sendData);
                }

                UART_SendData(bytes, bytes.Length);
                if (mIsShowSendFlag)
                {
                    LogMsg("Uart Tx: ", false);
                    LogMsg(bytes, true);
                }
            }
            else
            {
                MessageBox.Show("请先打开串口", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        public void UART_SendData(byte[] data, int len)
        {
            //Invoke(new Action(() =>
            //{
                if (serialPort1.IsOpen)
                { 
                    if (data == null)
                    {
                        LogMsg("数据格式错误!", true);
                        return;
                    }
                    if (data.Length < len)
                    {
                        len = data.Length;
                    }
                    LogMsg("Uart Tx: ", false);
                    LogMsg(data, true);
                    LogMsg("+", false);
                    serialPort1.Write(data, 0, len);
                }
            //}));
        }

        private void SearchAndAddSerialToComboBox(SerialPort MyPort, ComboBox MyBox)
        {
            string[] ComputerPortName = SerialPort.GetPortNames();  //获取本机串口列表

            MyBox.Items.Clear();  //清空ComboBox内容
            cmbPortName.Text = "";
            for (int i = 0; i < ComputerPortName.Length; i++) //循环
            {

                try  //核心原理是依靠try和catch完成遍历
                {
                    MyPort.PortName = ComputerPortName[i];
                    MyPort.Open();                          //如果失败，后面的代码不会执行          
                    MyBox.Items.Add(MyPort.PortName);       //打开成功，添加至下拉列表
                    MyPort.Close();                         //关闭
                    if (cmbPortName.Text == "")
                    {
                        cmbPortName.Text = MyPort.PortName;
                    }
                }
                catch
                {

                }
            }
            if (cmbPortName.Text == "")
            {
                txtReceivedData.AppendText("[" + DateTime.Now.ToString("HH:mm:ss") + "]" + "->");
                txtReceivedData.AppendText("没检测到可用串口！\r\n");
            }
        }

        private void button_Scan_Click(object sender, EventArgs e)
        {
            //先关闭串口
            serialPort1.Close();
            btnOpenClose.Text = "打开串口";
            btnOpenClose.Tag = "OFF";
            txtReceivedData.AppendText("[" + DateTime.Now.ToString("HH:mm:ss") + "]" + "->");
            txtReceivedData.AppendText("扫描关闭串口！\r\n");
            //扫描添加串口
            SearchAndAddSerialToComboBox(serialPort1, cmbPortName);
        }

        private void btnOpenClose_Click(object sender, EventArgs e)
        {
            // 打开或关闭串口
            if (!serialPort1.IsOpen)
            {
                try
                {
                    serialPort1.PortName = cmbPortName.SelectedItem.ToString();
                    serialPort1.BaudRate = (int)cmbBaudRate.SelectedItem;
                    serialPort1.Open();

                    btnOpenClose.Text = "关闭串口";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("无法打开串口：" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                serialPort1.Close();
                btnOpenClose.Text = "打开串口";
            }
        }
    }
}
