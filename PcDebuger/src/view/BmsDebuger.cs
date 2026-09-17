using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace PcDebuger
{
    public enum BmsCmd : byte
    {
        BMS_CMD_HEART = 0x00,
        BMS_CMD_21 = 0x21,
        BMS_CMD_20 = 0x20,
        BMS_CMD_3F = 0x3F,
    }

    public enum Bms21SubCmd : byte
    {
        BMS_21_SUBCMD_ONOFF = 0x08,
        BMS_21_SUBCMD_RESET = 0x06,
    }

    public enum Bms3FSubCmd : byte
    {
        BMS_3F_SUBCMD_TRANS = 0x00,  // 透传
        BMS_3F_SUBCMD_READ_ANALOG  = 0x01,
        BMS_3F_SUBCMD_READ_ANALOG2 = 0x02,
        BMS_3F_SUBCMD_RESER_CALI = 0x11,
        BMS_3F_SUBCMD_SET_CALI_CURR = 0x10,
        BMS_3F_SUBCMD_SET_CHG_REVERSE = 0x12,
    }

    public enum Bms20SubCmd : byte
    {
        BMS_20_SUBCMD_SET_3_POWER = 0x01,
    }

    public enum Bms00SubCmd : byte
    {
        BMS_00_SUBCMD_HEART = 0x20,
    }


    partial class MainForm
    {
        System.Threading.Thread mHeartCmdSendThread;
        private bool mHeartStartBtnFlg = false;//bms按键心跳标志, false:未开始,true:开始
        DateTime mHeartStartTime;//bms心跳开始时间

        private void InitBmsDebugerView()
        {
            btnBmsSetThreeChapseChgDischgCmd.Click += btnBmsSetThreeChapseChgDischgCmd_Click;
            btnBmsTurnOffCmd.Click += btnBmsTurnOffCmd_Click;
            btnBmsTurnOnCmd.Click += btnBmsTurnOnCmd_Click;
            btnBmsResetCmd.Click += btnBmsResetCmd_Click;
            btnBmsReadCalibratorParaCmd.Click += btnBmsReadCalibratorParaCmd_Click;
            btnBmsResetCalibratorParaCmd.Click += btnBmsResetCalibratorParaCmd_Click;
            btnBmsSetCalibrateCurrSamplingInputCmd.Click += btnBmsSetCalibrateCurrSamplingInputCmd_Click;
            btnBmsSetChgReverseCompensationParamCmd.Click += btnBmsSetChgReverseCompensationParamCmd_Click;
            btnBmsHeartBeat.Click += btnBmsHeartBeat_Click;

            mHeartCmdSendThread = new Thread(new ThreadStart(HeartCmdSendThread));
            mHeartCmdSendThread.IsBackground = true;
            mUartRecvThread.Priority = ThreadPriority.Lowest;
            mHeartCmdSendThread.Start();
        }

        private void btnBmsSetThreeChapseChgDischgCmd_Click(object sender, EventArgs e)
        {
            try
            {
                byte[] tempData = new byte[4];
                List<byte> sendList = new List<byte>();

                float aPhasePowerRes = float.Parse(textBoxBmsAPhaseChgDisChgPower.Text);
                float bPhasePowerRes = float.Parse(textBoxBmsBPhaseChgDisChgPower.Text);
                float cPhasePowerRes = float.Parse(textBoxBmsCPhaseChgDisChgPower.Text);

                UInt32 aPowerValueZoom1000 = (UInt32)(aPhasePowerRes * 1000);
                UInt32 bPowerValueZoom1000 = (UInt32)(bPhasePowerRes * 1000);
                UInt32 cPowerValueZoom1000 = (UInt32)(cPhasePowerRes * 1000);

                UInt32[] powerValueZoom1000 = new UInt32[] { aPowerValueZoom1000, bPowerValueZoom1000, cPowerValueZoom1000 };

                sendList.Add(0x00);
                sendList.Add((byte)BmsCmd.BMS_CMD_20);
                sendList.Add(0x01);
                sendList.Add(0x0C);

                for (int i = 0; i < 3; i++)
                {
                    tempData[0] = (byte)((powerValueZoom1000[i] >> 24) & 0x000000FF);
                    tempData[1] = (byte)((powerValueZoom1000[i] >> 16) & 0x000000FF);
                    tempData[2] = (byte)((powerValueZoom1000[i] >> 8) & 0x000000FF);
                    tempData[3] = (byte)((powerValueZoom1000[i] >> 0) & 0x000000FF);

                    for (int j = 0; j < 4; j++)
                    {
                        sendList.Add(tempData[j]);
                    }
                }
                txtSendData.Text = BitConverter.ToString(sendList.ToArray()).Replace("-", " ");
                CommSendCmd(sendList.ToArray());//do not reply 
            }
            catch (FormatException)
            {
                LogMsg("字符串不是有效的浮点数格式。\r\n");
            }
            catch (OverflowException)
            {
                LogMsg("字符串表示的数字太大或太小，无法转换为float。\r\n");
            }
        }

        private void btnBmsTurnOffCmd_Click(object sender, EventArgs e)
        {
            byte[] frame = new byte[] {0x00, 0x21, 0x08, 0x02, 0x00, 0x00, 0x00, 0x00 };

            txtSendData.Text = BitConverter.ToString(frame.ToArray()).Replace("-", " ");
            CommSendCmd(frame);
        }

        private void btnBmsTurnOnCmd_Click(object sender, EventArgs e)
        {
            byte[] frame = new byte[] { 0x00, 0x21, 0x08, 0x02, 0x00, 0x01, 0x00, 0x00 };

            txtSendData.Text = BitConverter.ToString(frame.ToArray()).Replace("-", " ");
            CommSendCmd(frame);
        }

        private void btnBmsResetCmd_Click(object sender, EventArgs e)
        {
            byte[] frame = new byte[] { 0x00, 0x21, 0x06, 0x02, 0x00, 0x01, 0x00, 0x00 };

            txtSendData.Text = BitConverter.ToString(frame.ToArray()).Replace("-", " ");
            CommSendCmd(frame);
        }

        private void btnBmsResetCalibratorParaCmd_Click(object sender, EventArgs e)
        {
            byte[] frame = new byte[64];
            frame[0] = 0x00;
            frame[1] = 0x3F;
            frame[2] = 0x11;
            frame[3] = 0x01;
            frame[4] = 0x01;
            txtSendData.Text = BitConverter.ToString(frame.ToArray()).Replace("-", " ");
            CommSendCmd(frame);
        }

        private void btnBmsReadCalibratorParaCmd_Click(object sender, EventArgs e)
        {
            byte[] frame = new byte[64];
            frame[0] = 0x00;
            frame[1] = 0x3F;
            frame[2] = 0x11;
            txtSendData.Text = BitConverter.ToString(frame.ToArray()).Replace("-", " ");
            CommSendCmd(frame);
        }

        private void btnBmsSetCalibrateCurrSamplingInputCmd_Click(object sender, EventArgs e)
        {
            try
            {
                ushort offset = 0;
                byte[] tempData = new byte[2];
                float[] bmsSamplData = new float[20];
                List<byte> sendList = new List<byte>();
                Int16[] bmsSamplDataZoom = new Int16[20];               

                bmsSamplData[offset++] = float.Parse(txtBmsSamplingChgData1.Text);
                bmsSamplData[offset++] = float.Parse(txtBmsPowerAnalysisSamplChgData1.Text);
                bmsSamplData[offset++] = float.Parse(txtBmsSamplingChgData2.Text);
                bmsSamplData[offset++] = float.Parse(txtBmsPowerAnalysisSamplChgData2.Text);
                bmsSamplData[offset++] = float.Parse(txtBmsSamplingChgData3.Text);
                bmsSamplData[offset++] = float.Parse(txtBmsPowerAnalysisSamplChgData3.Text);
                bmsSamplData[offset++] = float.Parse(txtBmsSamplingChgData4.Text);
                bmsSamplData[offset++] = float.Parse(txtBmsPowerAnalysisSamplChgData4.Text);
                bmsSamplData[offset++] = 0f;
                bmsSamplData[offset++] = 0f;
                bmsSamplData[offset++] = 0f;
                bmsSamplData[offset++] = 0f;
                bmsSamplData[offset++] = float.Parse(txtBmsSamplingDischgData1.Text);
                bmsSamplData[offset++] = float.Parse(txtBmsPowerAnalysisSamplDischgData1.Text);
                bmsSamplData[offset++] = float.Parse(txtBmsSamplingDischgData2.Text);
                bmsSamplData[offset++] = float.Parse(txtBmsPowerAnalysisSamplDischgData2.Text);
                bmsSamplData[offset++] = float.Parse(txtBmsSamplingDischgData3.Text);
                bmsSamplData[offset++] = float.Parse(txtBmsPowerAnalysisSamplDischgData3.Text);
                bmsSamplData[offset++] = float.Parse(txtBmsSamplingDischgData4.Text);
                bmsSamplData[offset++] = float.Parse(txtBmsPowerAnalysisSamplDischgData4.Text);

                for (int i = 0; i < 20; i++)
                {
                    bmsSamplDataZoom[i] = (Int16)(float)(bmsSamplData[i] * 100); 
                }
                sendList.Add(0x00);
                sendList.Add((byte)BmsCmd.BMS_CMD_3F);
                sendList.Add(0x10);
                sendList.Add(0x28);
                for (int i = 0; i < 20; i++)
                {
                    tempData[0] = (byte)(bmsSamplDataZoom[i] >> 8 & 0x00FF);
                    tempData[1] = (byte)(bmsSamplDataZoom[i] >> 0 & 0x00FF);

                    for (int j = 0; j < 2; j++)
                    {
                        sendList.Add(tempData[j]);
                    }
                }
                txtSendData.Text = BitConverter.ToString(sendList.ToArray()).Replace("-", " ");
                CommSendCmd(sendList.ToArray());
            }
            catch (FormatException)
            {
                LogMsg("字符串不是有效的浮点数格式。\r\n");
            }
            catch (OverflowException)
            {
                LogMsg("字符串表示的数字太大或太小，无法转换为float。\r\n");
            }
        }

        private void btnBmsSetChgReverseCompensationParamCmd_Click(object sender, EventArgs e)
        {
            try
            {
                byte[] tempData = new byte[2];
                float[] bmsSamplData = new float[1];
                List<byte> sendList = new List<byte>();
                Int16[] bmsSamplDataZoom = new Int16[1];

                bmsSamplData[0] = float.Parse(txtBmsChgReverseCompensationParam.Text);
                bmsSamplDataZoom[0] = (Int16)(float)(bmsSamplData[0] * 100);

                sendList.Add(0x00);
                sendList.Add((byte)BmsCmd.BMS_CMD_3F);
                sendList.Add(0x12);
                sendList.Add(0x02);

                tempData[0] = (byte)(bmsSamplDataZoom[0] >> 8 & 0x00FF);
                tempData[1] = (byte)(bmsSamplDataZoom[0] >> 0 & 0x00FF);

                for (int j = 0; j < 2; j++)
                {
                    sendList.Add(tempData[j]);
                }
                sendList.Add(0x00);
                sendList.Add(0x00);
                txtSendData.Text = BitConverter.ToString(sendList.ToArray()).Replace("-", " ");
                CommSendCmd(sendList.ToArray());
            }
            catch (FormatException)
            {
                LogMsg("字符串不是有效的浮点数格式。\r\n");
            }
            catch (OverflowException)
            {
                LogMsg("字符串表示的数字太大或太小，无法转换为float。\r\n");
            }
        }

        public void RecvBmsCalibratorParaDataProcess(byte[] frame, byte cmd)
        {            
            if (frame.Length < 0x3D)
            {
                return;
            }
            int offset = 0;
            short[] data = new short[22];
            float[] data_f = new float[22];

            float[] gain = new float[] { 1000, 1000, 1000, 1000, 1000, 1000, 1000, 1000, 1000, 1000, 1000, 1000, 1000, 1000, 100, 100, 100, 100, 100, 100, 100, 100 };

            switch (cmd)
            {
                case 0x11:
                    for (int i = 0; i < 8; i++)
                    {
                        data[i] = (short)((frame[offset++] << 8) | frame[offset++]);
                        data_f[i] = (float)(((float)data[i]) / gain[i]);
                    }

                    offset += 4;
                    for (int i = 8; i < 14; i++)
                    {
                        data[i] = (short)((frame[offset++] << 8) | frame[offset++]);
                        data_f[i] = (float)(((float)data[i]) / gain[i]);
                    }

                    offset += 4;
                    for (int i = 14; i < 18; i++)
                    {
                        data[i] = (short)((frame[offset++] << 8) | frame[offset++]);
                        data_f[i] = (float)(((float)data[i]) / gain[i]);
                    }

                    offset += 2;
                    for (int i = 18; i < 22; i++)
                    {
                        data[i] = (short)((frame[offset++] << 8) | frame[offset++]);
                        data_f[i] = (float)(((float)data[i]) / gain[i]);
                    }                  
                    break;
                default:
                    break;
            }

            Invoke(new Action(() =>
            {
                int j = 0;
                switch (cmd)
                {
                    case 0x11:
                        txtBmsCalibratorParaChgK0.Text = data_f[j++].ToString();
                        txtBmsCalibratorParaChgB0.Text = data_f[j++].ToString();
                        txtBmsCalibratorParaChgK1.Text = data_f[j++].ToString();
                        txtBmsCalibratorParaChgB1.Text = data_f[j++].ToString();
                        txtBmsCalibratorParaChgK2.Text = data_f[j++].ToString();
                        txtBmsCalibratorParaChgB2.Text = data_f[j++].ToString();
                        txtBmsCalibratorParaChgK3.Text = data_f[j++].ToString();
                        txtBmsCalibratorParaChgB3.Text = data_f[j++].ToString();
                        txtBmsCalibratorParaDischgK1.Text = data_f[j++].ToString();
                        txtBmsCalibratorParaDischgB1.Text = data_f[j++].ToString();
                        txtBmsCalibratorParaDischgK2.Text = data_f[j++].ToString();
                        txtBmsCalibratorParaDischgB2.Text = data_f[j++].ToString();
                        txtBmsCalibratorParaDischgK3.Text = data_f[j++].ToString();
                        txtBmsCalibratorParaDischgB3.Text = data_f[j++].ToString();
                        txtBmsChgCurr1_Z1.Text = data_f[j++].ToString();
                        txtBmsChgCurr2_Z2.Text = data_f[j++].ToString();
                        txtBmsChgCurr3_Z3.Text = data_f[j++].ToString();
                        txtBmsChgCurr4_Z4.Text = data_f[j++].ToString();
                        txtBmsDischgCurr1_Z1.Text = data_f[j++].ToString();
                        txtBmsDischgCurr2_Z2.Text = data_f[j++].ToString();
                        txtBmsDischgCurr3_Z3.Text = data_f[j++].ToString();
                        txtBmsDischgCurr4_Z4.Text = data_f[j++].ToString();
                        break;                   
                    default:
                        break;
                }
            }));

        }

        private void HeartCmdSendThread()
        {
            while (true)
            {
                Thread.Sleep(10);

                if (mHeartStartBtnFlg == true && m_isCanOpen == true && ((DateTime.Now - mHeartStartTime).TotalMilliseconds >= 2000))
                {
                    mHeartStartTime = DateTime.Now;

                    byte[] frame = new byte[] {0x00, 0x00, 0x20, 0x00, 0x00, 0x00, 0x00, 0x00 };
                    CommSendCmd(frame);
                }
            }
        }

        private void btnBmsHeartBeat_Click(object sender, EventArgs e) 
        {
            mHeartStartBtnFlg = !mHeartStartBtnFlg;
            if (mHeartStartBtnFlg == true)
            {
                btnBmsHeartBeat.Text = "停止心跳";
                btnBmsHeartBeat.BackColor = System.Drawing.Color.LimeGreen;
            }
            else 
            {
                btnBmsHeartBeat.Text = "开始心跳";
                btnBmsHeartBeat.BackColor = System.Drawing.Color.Transparent;
            }            
            mHeartStartTime = DateTime.Now;
        }

    }
    class BmsDebuger
    {
    }
}
