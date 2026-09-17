using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing; 

namespace PcDebuger
{
    public enum CommMode
    {
        UART,
        PLC,
        CAN,
        RS485,
    }

    partial class MainForm
    {
        public CommMode mCommMode;

        public void InitCommConfigView()
        {
            mCommMode = CommMode.UART;
            radioBtnCommUartMode.Checked = true;
            radioBtnCommUartMode.CheckedChanged += radioBtnCommUartMode_CheckedChanged;
            radioBtnCommPlcMode.Checked = false;
            radioBtnCommPlcMode.CheckedChanged += radioBtnCommPlcMode_CheckedChanged;
            radioBtnCommCanMode.Checked = false;
            radioBtnCommCanMode.CheckedChanged += radioBtnCommCanMode_CheckedChanged;
            radioBtnComm485Mode.Checked = false;
            radioBtnComm485Mode.CheckedChanged += radioBtnComm485Mode_CheckedChanged;

            UpdateCommModeViews();

            btnCalculateCrc.Click += btnCalculateCrc_Click;

            groupBox1.Dock = DockStyle.Left;
            groupBox1.Size = new Size(459, 765); 
            this.Resize += MainForm_Resize;

            txtReceivedData.Multiline = true; 
            txtReceivedData.Dock = DockStyle.Top;
            txtReceivedData.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;

            groupBox55.Dock = DockStyle.Bottom;

            groupBox2.Controls.Add(groupBox55);
            groupBox2.Controls.Add(txtReceivedData);

        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            ArrangeGroupBoxControls(); // 窗口大小改变时重新排布
        }

        private void ArrangeGroupBoxControls()
        {
            if (groupBox1 == null) return;

            int totalHeight = groupBox1.ClientSize.Height;
            groupBox1.Controls.Clear();

            // 1. groupBox7 - 5%
            groupBox7.Height = (int)(totalHeight * 0.05);
            groupBox7.Location = new Point(10, 10);
            groupBox1.Controls.Add(groupBox7);

            // 2. groupBox16 - 5%
            groupBox16.Height = (int)(totalHeight * 0.05);
            groupBox16.Location = new Point(10, groupBox7.Bottom);
            groupBox1.Controls.Add(groupBox16);

            // 3. tabControl1 - 34%
            tabControl1.Height = (int)(totalHeight * 0.34);
            tabControl1.Width = groupBox1.Width - 20;
            tabControl1.Location = new Point(10, groupBox16.Bottom);
            tabControl1.Dock = DockStyle.None;
            groupBox1.Controls.Add(tabControl1);

            // 4. groupBox23 - 12%
            groupBox23.Height = (int)(totalHeight * 0.12);
            groupBox23.Location = new Point(10, tabControl1.Bottom);
            groupBox1.Controls.Add(groupBox23);

            // 5. groupBox2 - 剩余 44%
            groupBox2.Location = new Point(10, groupBox23.Bottom);
            groupBox2.Height = totalHeight - groupBox2.Location.Y - 10;
            groupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(groupBox2);
        }

        private void radioBtnCommUartMode_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioBtn = (RadioButton)sender;
            if (radioBtn.Checked)
            {
                mCommMode = CommMode.UART;
                UpdateCommModeViews();
            }
        }

        private void radioBtnCommPlcMode_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioBtn = (RadioButton)sender;
            if (radioBtn.Checked)
            {
                mCommMode = CommMode.PLC;
                UpdateCommModeViews();
            }
        }

        private void radioBtnCommCanMode_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioBtn = (RadioButton)sender;
            if (radioBtn.Checked)
            {
                mCommMode = CommMode.CAN;
                UpdateCommModeViews();
            }
        }

        private void radioBtnComm485Mode_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioBtn = (RadioButton)sender;
            if (radioBtn.Checked)
            {
                mCommMode = CommMode.RS485;
                UpdateCommModeViews();
            }
        }

        private void UpdateCommModeViews()
        {
            groupBoxUartCfg.Visible = false;
            groupBoxPlcTstBrdCfg.Visible = false;
            groupBoxPlcDstCfg.Visible = false;
            groupBoxCanCfg.Visible = false;
            groupBoxCanSendCfg.Visible = false;
            if (mCommMode == CommMode.UART || mCommMode == CommMode.RS485)
            {
                groupBoxUartCfg.Visible = true;
                tabControl1.SelectedIndex = 0;
            }
            else if (mCommMode == CommMode.PLC)
            {
                groupBoxUartCfg.Visible = true;
                groupBoxPlcTstBrdCfg.Visible = true;
                groupBoxPlcDstCfg.Visible = true;
                tabControl1.SelectedIndex = 0;
            }
            else if (mCommMode == CommMode.CAN)
            {
                groupBoxCanCfg.Visible = true;
                groupBoxCanSendCfg.Visible = true;
                tabControl1.SelectedIndex = 1;
            }
        }

        public void CommSendCmd(byte[] frame)
        {
            //LogMsg(frame, true);
            if (mCommMode == CommMode.UART)
            {
                mSerialBufferThread.UartSendEnqueue(frame);
            }
            else if (mCommMode == CommMode.PLC)
            {
            }
            else if (mCommMode == CommMode.CAN)
            {

                //  增加特殊处理代码，CAN ID修改+透传帧的修改
                uint canId = GetCanIdCfg();  //  Q=0x00, R=0x01

                List<CAN_Frame> canFrames = ModbusProto.ModbusToCanFrame(frame, canId);
                for (int i = 0; i < canFrames.Count; i++)
                {
                    mSerialBufferThread.CanSendEnqueue(canFrames[i]);
                }
            }
        }

        public bool CommIsBufferEmpty()
        {
            if (mCommMode == CommMode.UART)
            {
                return mSerialBufferThread.UartBufferIsEmpty();
            }
            else if (mCommMode == CommMode.CAN)
            {
                return mSerialBufferThread.CanBufferIsEmpty();
            }
            else
            {
                return true;
            }
        }

        public void CommRecvCallback(byte[] data)
        {
            if (mCommMode == CommMode.UART)
            {
                if (data.Length < 2)
                {
                    return;
                }
                byte cmd = data[1];
                if (ModbusProto.CheckCmdIsTransparentCmd(cmd))
                {
                    if (GetLoadType() == LoadType.Loader)
                    {
                        RecvDataProcess(data);
                        PcsTestSwOscRecvDataProcess(data);
                    }
                    else if (GetLoadType() == LoadType.Loadee)
                    {
                        RecvDataProcessLoadee(data);
                        PcsTestSwOscLoadee(data);
                    }
                }
                else if (ModbusProto.CheckCmdIsTlvCmd(cmd))
                {
                    if (cmd == (byte)ModbusCmd.EXPORT_FILE)
                    {
                        ExportRecvDataProcess(data);
                    }
                    else if (GetLoadType() == LoadType.Loadee)
                    {
                        mLoadee.LoadeeRecvProcess(ModbusProto.GetModbusTlvFrame(data));
                    }
                    else
                    {
                        mUploaderProto.UploaderRecvProcess(ModbusProto.GetModbusTlvFrame(data));
                    }
                }
            }
            else if (mCommMode == CommMode.PLC)
            {

            }
        }

        public void CommRecvCallback(CAN_Frame frame)
        {
            if (mCommMode == CommMode.CAN)
            {
                //if (frame.mCanId.DestAddr == mCanIdSrcAddr)
                //{
                //    mCanIdDestAddr = frame.mCanId.SrcAddr;
                //}
                byte[] data = new byte[0];
                data = ModbusProto.CanToModbusFrame(frame);
                if (data.Length != 0)
                {
                    if (frame.mCanId.CmdHigh == 0x3F)
                    {
                        if (frame.mData[0] == 0x01 || frame.mData[0] == 0x02)//bms 3F01/3F02
                        {
                            RecvBmsAnalogDataProcess(data, frame.mData[0]);
                        }
                        else if (frame.mData[0] == 0x11)
                        {
                            RecvBmsCalibratorParaDataProcess(data, frame.mData[0]);
                        }
                        else if (GetLoadType() == LoadType.Loader)
                        {
                            LogMsg(data, true);
                            RecvDataProcess(data);
                            PcsTestSwOscRecvDataProcess(data);
                            VarDebugOnlineRecvDataProcess(data);
                        }
                        else
                        {
                            RecvDataProcessLoadee(data);
                            PcsTestSwOscLoadee(data);
                        }
                    }
                    else if (frame.mCanId.CmdHigh == 0x31)
                    {
                        ExportRecvDataProcess(data);
                    }
                    else if (frame.mCanId.CmdHigh == 0x25)
                    {
                        if (frame.mData[0] == 0x07)
                        {
                            RecvBkpTestDataProcess(data, frame.mData[0]);
                        }
                        else if (frame.mData[0] == 0x01)
                        {
                            VarDebugOnlineRecvDataProcess(data);
                        }
                    }
                    else if (frame.mCanId.CmdHigh == 0x21)
                    {
                        if (frame.mData[0] == 0xCA)
                        {
                            RecvBkpAlmDataOnOffGridStateProcess(data, frame.mData[0]);
                        }                        
                    }                        
                    else
                    {
                        //LogMsg(data, true);
                        if (GetLoadType() == LoadType.Loadee)
                        {
                            mLoadee.LoadeeRecvProcess(ModbusProto.GetModbusTlvFrame(data));
                        }
                        else
                        {
                            mUploaderProto.UploaderRecvProcess(ModbusProto.GetModbusTlvFrame(data));
                        }
                    }
                }
            }
        }

        private void btnCalculateCrc_Click(object sender, EventArgs e)
        {
            string sendData = tbData2Crc.Text;
            byte[] bytes;
            List<byte> datList = new List<byte>();
            try
            {
                string[] words = sendData.Split(' ');
                sendData = string.Join(string.Empty, words);
                bytes = DataFormatConvert.HexStringToAscii(sendData);
            }
            catch (Exception ex)
            {
                MessageBox.Show("无法转换为Hex格式：" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbCrcResult.Clear();
                return;
            }

            datList.AddRange(bytes);
            ushort crcShort = ModbusCrc.Crc16(bytes, bytes.Length);
            byte[] crcByteResult = new byte[2];
            crcByteResult[0] = (byte)(crcShort & 0xFF);
            crcByteResult[1] = (byte)(crcShort >> 8);
            datList.AddRange(crcByteResult);
            string crcStrResult = BitConverter.ToString(crcByteResult).Replace("-", " ");

            tbCrcResult.Text = crcStrResult;

            txtSendData.Text = tbData2Crc.Text + " " + crcStrResult;

            //byte[] cmdBuf = datList.ToArray();
            //cmdBuf = ModbusProto.TransparentToModbusCmd(cmdBuf, (mCommMode == CommMode.CAN));
            //CommSendCmd(cmdBuf);
        }
    }




}
