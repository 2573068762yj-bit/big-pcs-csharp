using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace PcDebuger
{
    
    partial class MainForm
    {
        public byte mBkpDo1LevelState;  // 0x00：低电平; 0x01：高电平
        public byte mBkpDo2LevelState;  // 0x00：低电平; 0x01：高电平
        public byte mBkpDo3LevelState;  // 0x00：低电平; 0x01：高电平
        public byte mBkpDo4LevelState;  // 0x00：低电平; 0x01：高电平
        public byte mBkpFanTurnOnOff;   // 0x00：关闭;   0x01：开启

        private void InitBackupBoxDebugerView()
        {
            mBkpDo1LevelState = 0x00;
            radioBtnBkpDo1HighLevel.Checked = false;
            radioBtnBkpDo1HighLevel.CheckedChanged += radioBtnBkpDo1HighLevel_CheckedChanged;
            radioBtnBkpDo1LowLevel.Checked = true;
            radioBtnBkpDo1LowLevel.CheckedChanged += radioBtnBkpDo1LowLevel_CheckedChanged;

            mBkpDo2LevelState = 0x00;
            radioBtnBkpDo2HighLevel.Checked = false;
            radioBtnBkpDo2HighLevel.CheckedChanged += radioBtnBkpDo2HighLevel_CheckedChanged;
            radioBtnBkpDo2LowLevel.Checked = true;
            radioBtnBkpDo2LowLevel.CheckedChanged += radioBtnBkpDo2LowLevel_CheckedChanged;

            mBkpDo3LevelState = 0x01;
            radioBtnBkpDo3HighLevel.Checked = true;
            radioBtnBkpDo3HighLevel.CheckedChanged += radioBtnBkpDo3HighLevel_CheckedChanged;
            radioBtnBkpDo3LowLevel.Checked = false;
            radioBtnBkpDo3LowLevel.CheckedChanged += radioBtnBkpDo3LowLevel_CheckedChanged;

            mBkpDo4LevelState = 0x00;
            radioBtnBkpDo4HighLevel.Checked = true;
            radioBtnBkpDo4HighLevel.CheckedChanged += radioBtnBkpDo4HighLevel_CheckedChanged;
            radioBtnBkpDo4LowLevel.Checked = false;
            radioBtnBkpDo4LowLevel.CheckedChanged += radioBtnBkpDo4LowLevel_CheckedChanged;

            mBkpFanTurnOnOff = 0x00;
            radioBtnBkpFanTurnOn.Checked = false;
            radioBtnBkpFanTurnOn.CheckedChanged += radioBtnBkpFanTurnOn_CheckedChanged;
            radioBtnBkpFanTurnOff.Checked = true;
            radioBtnBkpFanTurnOff.CheckedChanged += radioBtnBkpFanTurnOff_CheckedChanged;

            btnBkpSetMultiDoPara.Click += btnBkpSetMultiDoPara_Click;
            btnBkpSetFanTurnOnOff.Click += btnBkpSetFanTurnOnOff_Click;
            btnGetBkpTestdata.Click += btnGetBkpTestdata_Click;
            btnGetBkpAlmDataOnOffGridStateData.Click += btnGetBkpAlmDataOnOffGridStateData_Click;

        }

        private void radioBtnBkpDo1HighLevel_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioBtn = (RadioButton)sender;
            if (radioBtn.Checked)
            {
                mBkpDo1LevelState = 0x01;
            }
        }

        private void radioBtnBkpDo1LowLevel_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioBtn = (RadioButton)sender;
            if (radioBtn.Checked)
            {
                mBkpDo1LevelState = 0x00;
            }
        }

        private void radioBtnBkpDo2HighLevel_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioBtn = (RadioButton)sender;
            if (radioBtn.Checked)
            {
                mBkpDo2LevelState = 0x01;
            }
        }

        private void radioBtnBkpDo2LowLevel_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioBtn = (RadioButton)sender;
            if (radioBtn.Checked)
            {
                mBkpDo2LevelState = 0x00;
            }
        }

        private void radioBtnBkpDo3HighLevel_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioBtn = (RadioButton)sender;
            if (radioBtn.Checked)
            {
                mBkpDo3LevelState = 0x01;
            }
        }

        private void radioBtnBkpDo3LowLevel_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioBtn = (RadioButton)sender;
            if (radioBtn.Checked)
            {
                mBkpDo3LevelState = 0x00;
            }
        }

        private void radioBtnBkpDo4HighLevel_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioBtn = (RadioButton)sender;
            if (radioBtn.Checked)
            {
                mBkpDo4LevelState = 0x01;
            }
        }

        private void radioBtnBkpDo4LowLevel_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioBtn = (RadioButton)sender;
            if (radioBtn.Checked)
            {
                mBkpDo4LevelState = 0x00;
            }
        }

        private void radioBtnBkpFanTurnOn_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioBtn = (RadioButton)sender;
            if (radioBtn.Checked)
            {
                mBkpFanTurnOnOff = 0x01;
            }
        }

        private void radioBtnBkpFanTurnOff_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioBtn = (RadioButton)sender;
            if (radioBtn.Checked)
            {
                mBkpFanTurnOnOff = 0x00;
            }
        }

        private void btnBkpSetMultiDoPara_Click(object sender, EventArgs e)
        {
            List<byte> sendList = new List<byte>();

            sendList.Add(0x00);
            sendList.Add(0x24);
            sendList.Add(0x41);
            sendList.Add(0x08);
            sendList.Add(0x00);
            sendList.Add(mBkpDo1LevelState);
            sendList.Add(0x00);
            sendList.Add(mBkpDo2LevelState);
            sendList.Add(0x00);
            sendList.Add(mBkpDo3LevelState);
            sendList.Add(0x00);
            sendList.Add(mBkpDo4LevelState);

            txtSendData.Text = BitConverter.ToString(sendList.ToArray()).Replace("-", " ");
            CommSendCmd(sendList.ToArray());
        }

        private void btnBkpSetFanTurnOnOff_Click(object sender, EventArgs e)
        {
            List<byte> sendList = new List<byte>();

            sendList.Add(0x00);
            sendList.Add(0x24);
            sendList.Add(0x3E);
            sendList.Add(0x02);
            sendList.Add(0x00);
            sendList.Add(mBkpFanTurnOnOff);

            txtSendData.Text = BitConverter.ToString(sendList.ToArray()).Replace("-", " ");
            CommSendCmd(sendList.ToArray());
        }

        private void btnGetBkpTestdata_Click(object sender, EventArgs e)
        {
            List<byte> sendList = new List<byte>();

            sendList.Add(0x00);
            sendList.Add(0x25);
            sendList.Add(0x07);
            sendList.Add(0x3E);
            sendList.Add(0x00);
            sendList.Add(0x00);

            txtSendData.Text = BitConverter.ToString(sendList.ToArray()).Replace("-", " ");
            CommSendCmd(sendList.ToArray());
        }

        private void btnGetBkpAlmDataOnOffGridStateData_Click(object sender, EventArgs e)
        {
            List<byte> sendList = new List<byte>();

            sendList.Add(0x00);
            sendList.Add(0x21);
            sendList.Add(0xCA);
            sendList.Add(0x3C);
            sendList.Add(0x00);
            sendList.Add(0x00);

            txtSendData.Text = BitConverter.ToString(sendList.ToArray()).Replace("-", " ");
            CommSendCmd(sendList.ToArray());
        }

        public void RecvBkpTestDataProcess(byte[] frame, byte cmd)
        {
            if (frame.Length < 47)//23data*2+1errCode
            {
                return;
            }
            int offset = 1;
            ushort dataNum = 23;
            short[] data = new short[dataNum];
            float[] data_f = new float[dataNum];
            float[] gain = new float[] { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 1, 1, 1, 1, 1, 10, 10, 1, 1, 10, 1};

            for (int i = 0; i < dataNum; i++)
            {
                data[i] = (short)((frame[offset++] << 8) | frame[offset++]);
                data_f[i] = (float)(((float)data[i]) / gain[i]);
            }

            Invoke(new Action(() =>
            {
                int j = 0;

                txtBkptTempANrly.Text = data_f[j++].ToString();
                txtBkptTempBCrly.Text = data_f[j++].ToString();
                txtBkptTempEnv.Text = data_f[j++].ToString();
                txtBkpAphaseUg.Text = data_f[j++].ToString();
                txtBkpBphaseUg.Text = data_f[j++].ToString();
                txtBkpCphaseUg.Text = data_f[j++].ToString();
                txtBkpAphaseUout.Text = data_f[j++].ToString();
                txtBkpBphaseUout.Text = data_f[j++].ToString();
                txtBkpCphaseUout.Text = data_f[j++].ToString();
                txtBkpAphaseUdiff.Text = data_f[j++].ToString();
                txtBkpBphaseUdiff.Text = data_f[j++].ToString();
                txtBkpCphaseUdiff.Text = data_f[j++].ToString();
                if (data_f[j] == 0)
                {
                    txtBkpDo1State.Text = "低,断开";
                }
                else if (data_f[j] == 1)
                {
                    txtBkpDo1State.Text = "高,接入"; 
                }
                else {
                    txtBkpDo1State.Text = "err,为" + data_f[j].ToString();
                }
                j++;
                if (data_f[j] == 0)
                {
                    txtBkpDo2State.Text = "低,接入";
                }
                else if (data_f[j] == 1)
                {
                    txtBkpDo2State.Text = "高,断开";
                }
                else
                {
                    txtBkpDo2State.Text = "err,为" + data_f[j].ToString();
                }
                j++;
                if (data_f[j] == 0)
                {
                    txtBkpDo3State.Text = "低,接入";
                }
                else if (data_f[j] == 1)
                {
                    txtBkpDo3State.Text = "高,断开";
                }
                else
                {
                    txtBkpDo3State.Text = "err,为" + data_f[j].ToString();
                }
                j++;
                if (data_f[j] == 0)
                {
                    txtBkpDI1State.Text = "低,油机供电";
                }
                else if (data_f[j] == 1)
                {
                    txtBkpDI1State.Text = "高,电网供电";
                }
                else
                {
                    txtBkpDI1State.Text = "err,为" + data_f[j].ToString();
                }
                j++;
                if (data_f[j] == 0)
                {
                    txtBkpDI2State.Text = "低,不可离网";
                }
                else if (data_f[j] == 1)
                {
                    txtBkpDI2State.Text = "高,可离网";
                }
                else
                {
                    txtBkpDI2State.Text = "err,为" + data_f[j].ToString();
                }
                j++;
                txtBkpUn2pe.Text = data_f[j++].ToString();
                txtBkpU12v.Text = data_f[j++].ToString();
                txtBkpHardVer.Text = data_f[j++].ToString();
                if (data_f[j] == 1)
                {
                    txtBkpPhaseNum.Text = "1,三相";
                }
                else if (data_f[j] == 2)
                {
                    txtBkpPhaseNum.Text = "2,单相";
                }
                else
                {
                    txtBkpPhaseNum.Text = "err,为" + data_f[j].ToString();
                }
                j++;
                txtBkptTempTrans.Text = data_f[j++].ToString();
                if (data_f[j] == 0)
                {
                    txtBkpDo4State.Text = "低,断开";
                }
                else if (data_f[j] == 1)
                {
                    txtBkpDo4State.Text = "高,接入";
                }
                else
                {
                    txtBkpDo4State.Text = "err,为" + data_f[j].ToString();
                }
                j++;
            }));
        }

        public void RecvBkpAlmDataOnOffGridStateProcess(byte[] frame, byte cmd)
        {
            if (frame.Length < 23)//11data*2+1errCode
            {
                return;
            }
            int offset = 1;

            string[] AlmGrp00Name = new string[] { "0-00", "0-01", "0-02", "0-03", "0-04", "0-05", "0-06", "0-07", "0-08", "0-09", "0-10", "0-11", "0-12", "0-13", "0-14", "0-15" };
            string[] AlmGrp01Name = new string[] { "1-00", "1-01", "1-02", "1-03", "1-04", "1-05", "1-06", "1-07", "1-08", "1-09", "1-10", "1-11", "1-12", "1-13", "1-14", "1-15" };
            string[] AlmGrp02Name = new string[] { "2-00", "2-01", "2-02", "2-03", "2-04", "2-05", "2-06", "2-07", "2-08", "2-09", "2-2-10", "2-11", "2-12", "2-13", "2-14", "2-15" };
            string[] AlmGrp03Name = new string[] { "辅源故障3-00", "EEPROM故障3-01", "模拟量故障3-02", "3-03", "3-04", "3-05", "3-06", "版本故障3-07", "继电器故障3-08", "3-09", "过温3-10", "3-11", "BYPASS切换故障3-12", "PE连接故障3-13", "3-14", "3-15" };
            string[] AlmGrp04Name = new string[] { "4-00", "4-01", "4-02", "4-03", "14-04", "4-05", "4-06", "4-07", "4-08","4-09", "4-10", "4-11", "4-12", "4-13", "4-14", "过载4-15" };
            string[] AlmGrp05Name = new string[] { "5-00", "5-01", "5-02", "5-03", "5-04", "5-05", "5-06", "5-07", "5-08", "5-09", "5-10", "5-11", "5-12", "5-13", "5-14", "5-15" };
            string[] AlmGrp06Name = new string[] { "6-00", "6-01", "6-02", "6-03", "6-04", "6-05", "6-06", "6-07", "6-08", "6-09", "6-10", "6-11", "6-12", "6-13", "6-14", "6-15" };
            string[] AlmGrp07Name = new string[] { "7-00", "7-01", "7-02", "7-03", "7-04", "7-05", "7-06", "7-07", "7-08", "7-09", "7-10", "7-11", "7-12", "7-13", "7-14", "7-15" };
            string[] AlmGrp08Name = new string[] { "8-00", "8-01", "8-02", "8-03", "8-04", "8-05", "8-06", "8-07", "8-08", "8-09", "8-10", "8-11", "8-12", "8-13", "8-14", "8-15" };
            string[] AlmGrp09Name = new string[] { "9-00", "9-01", "9-02", "9-03", "9-04", "9-05", "9-06", "9-07", "9-08", "9-09", "9-10", "9-11", "9-12", "9-13", "9-14", "9-15" };

            string[][] AlmNameGroups1x = new string[][] { AlmGrp00Name, AlmGrp01Name, AlmGrp02Name, AlmGrp03Name, AlmGrp04Name, AlmGrp05Name, AlmGrp06Name, AlmGrp07Name, AlmGrp08Name, AlmGrp09Name, };

            ushort[] AlarmGroup1x = new ushort[10];
            List<int>[] almBit1List1x = new List<int>[10];

            for (int dat_i = 0; dat_i < 10; dat_i++)//0-9Group
            {
                AlarmGroup1x[dat_i] = (ushort)((frame[offset++] << 8) | frame[offset++]);
                almBit1List1x[dat_i] = GetAlmDataBit1(AlarmGroup1x[dat_i], 16);
            }

            StringBuilder result = new StringBuilder();

            for (int i = 0; i < almBit1List1x.Length; i++)
            {
                foreach (int position in almBit1List1x[i])
                {
                    if (position >= 0 && position < AlmNameGroups1x[i].Length)
                    {
                        result.AppendFormat("{0}, ", AlmNameGroups1x[i][position]);
                    }
                }
            }

            if (result.Length > 0)
            {
                result.Remove(result.Length - 2, 2);
            }

            Invoke(new Action(() =>
            {
                if (result.Length == 0)
                {
                    txtBkpIsAlmData.Text = "无告警";
                }
                else
                {
                    txtBkpIsAlmData.Text = result.ToString();
                }
            }));

            ushort dataNum = 2;
            short[] data = new short[dataNum];
            float[] data_f = new float[dataNum];

            for (int i = 0; i < dataNum; i++)
            {
                data[i] = (short)((frame[offset++] << 8) | frame[offset++]);
                data_f[i] = (float)(((float)data[i]) / 1.0f);
            }  

            Invoke(new Action(() =>
            {
                int j = 0;
                if (data_f[j] == 0)
                {
                    txtBkpIsAlmState.Text = "0,正常";
                }
                else if (data_f[j] == 1)
                {
                    txtBkpIsAlmState.Text = "1,异常";
                }
                else
                {
                    txtBkpIsAlmState.Text = "err,为" + data_f[j].ToString();
                }
                j++;
                if (data_f[j] == 0)
                {
                    txtBkpOnOffGridState.Text = "0,并网";
                }
                else if (data_f[j] == 1)
                {
                    txtBkpOnOffGridState.Text = "1,离网";
                }
                else if (data_f[j] == 3)
                {
                    txtBkpOnOffGridState.Text = "3,默认态";
                }
                else
                {
                    txtBkpOnOffGridState.Text = "err,为" + data_f[j].ToString();
                }
                j++;
                
            }));
        }    
    }

    class BackupBoxDebuger
    {
    }
}
