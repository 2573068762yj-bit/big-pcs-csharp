using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace PcDebuger
{
    partial class MainForm
    {
        private DateTime mAnalogMonitStart1sec1minTimer;
        private DateTime mAnalogMonitStart5sec1hourTimer;
        private bool mAnalogMonitFlag;//false:未监控 true:监控中
        private bool mAnalogDataPcsReFlag;//false:不读 true:读
        private bool mAnalogDataBmsReFlag;//false:不读 true:读
        private bool mAnalogDataBmsSaveFlag;//false:不存 true:存
        private bool mAnalogMonit1minor1hourFlag;//false:1s1min true:5s1hr

        List<List<object>> recordedAnalogData = new List<List<object>>();//pcsAnalog
        private List<object> AnalogrowData = new List<object>();
        List<List<object>> recordedAnalogBmsDataFront = new List<List<object>>();//bmsAnalog3f01
        private List<object> AnalogBmsDataFront = new List<object>();
        List<List<object>> recordedAnalogBmsDataBack = new List<List<object>>();//bmsAnalog3f02
        private List<object> AnalogBmsDataBack = new List<object>();

        private void InitAnalogDataMonitView()
        {
            mAnalogMonitFlag = false;
            mAnalogDataPcsReFlag = true;
            mAnalogDataBmsReFlag = true;
            mAnalogDataBmsSaveFlag = true;
            timerAnalogMonit.Stop();
            timerAnalogMonit.Tick += timerAnalogMonit_Tick;
            chkboxAnalogDataPcs.Checked = true;
            chkboxAnalogDataPcs.CheckedChanged += chkboxAnalogDataPcs_CheckedChanged;
            chkboxAnalogDataBms.Checked = true;
            chkboxAnalogDataBms.CheckedChanged += chkboxAnalogDataBms_CheckedChanged;
            btnGetAnalogData.Click += btnGetAnalogData_Click;
            btnAnalogDatSave.Click += btnAnalogDatSave_Click;
            btnBMSAnalogDatSave.Click += btnBMSAnalogDatSave_Click;
            btnAnalogMonit1sec1minStartStop.Click += btnAnalogMonit1sec1minStartStop_Click;
            btnAnalogMonit5sec1hourStartStop.Click += btnAnalogMonit5sec1hourStartStop_Click;
        }

        private void GetAnalogDataFromRecvFrame(byte srcAddr, byte[] frame)
        {
            if (frame.Length < 0x2C)
            {
                return;
            }

            int offset = 0;
            int[] data = new int[14];
            float[] data_f = new float[14];

            for (int i = 0; i < 6; i++)
            {
                data[i] = (int)((frame[offset] << 24) + (frame[offset + 1] << 16) + (frame[offset + 2] << 8) + (frame[offset + 3]));
                offset += 4;
                data_f[i] = (float)(((float)data[i]) / 10000.0);
            }
            data[6] = (short)((frame[offset++] << 8) | frame[offset++]);
            data_f[6] = (float)(((float)data[6]) / 100.0);
            data[7] = (short)((frame[offset++] << 8) | frame[offset++]);
            data_f[7] = (float)(((float)data[7]) / 100.0);
            data[8] = (int)((frame[offset] << 24) + (frame[offset + 1] << 16) + (frame[offset + 2] << 8) + (frame[offset + 3]));
            offset += 4;
            data_f[8] = (float)(((float)data[8]) / 10000.0);
            data[9] = (int)(int)((frame[offset] << 24) + (frame[offset + 1] << 16) + (frame[offset + 2] << 8) + (frame[offset + 3]));
            offset += 4;
            data_f[9] = (float)(((float)data[9]) / 10000.0);
            data[10] = (short)((frame[offset++] << 8) | frame[offset++]);
            data_f[10] = (float)(((float)data[10]) / 100.0);
            data[11] = (short)((frame[offset++] << 8) | frame[offset++]);
            data_f[11] = (float)(((float)data[11]) / 1);
            data[12] = (short)((frame[offset++] << 8) | frame[offset++]);
            data_f[12] = (float)(((float)data[12]) / 1);
            data[13] = (short)((frame[offset++] << 8) | frame[offset++]);
            data_f[13] = (float)(((float)data[13]) / 1);

            if (mAnalogMonitFlag == true)
            {
                DateTime currentTime = DateTime.Now;
                AnalogrowData.Add(currentTime.ToString("yyyy-MM-dd HH:mm:ss"));
                AnalogrowData.Add(srcAddr);
                for (int j = 0; j < data_f.Length; j++)
                {
                    AnalogrowData.Add(data_f[j]);
                }
                recordedAnalogData.Add(AnalogrowData);
            }

            Invoke(new Action(() =>
            {
                int j = 0;
                switch (srcAddr)
                {
                    case 0x01:
                        txtAAnalogPout.Text = data_f[j++].ToString();
                        txtAAnalogQout.Text = data_f[j++].ToString();
                        txtAAnalogVgrid.Text = data_f[j++].ToString();
                        txtAAnalogPowerVgrid.Text = data_f[j++].ToString();
                        txtAAnalogIgrid.Text = data_f[j++].ToString();
                        txtAAnalogVbat.Text = data_f[j++].ToString();
                        txtAAnalogPriTemp.Text = data_f[j++].ToString();
                        txtAAnalogSecTemp.Text = data_f[j++].ToString();
                        txtAAnalogDci.Text = data_f[j++].ToString();
                        txtAAnalog10V.Text = data_f[j++].ToString();
                        txtAAnalogGridFreq.Text = data_f[j++].ToString();
                        if (data_f[j] == 0)
                        {
                            txtAAnalogInternalFanState.Text = "0-未知";
                        }
                        else if (data_f[j] == 1)
                        {
                            txtAAnalogInternalFanState.Text = "1-停止";
                        }
                        else if (data_f[j] == 2)
                        {
                            txtAAnalogInternalFanState.Text = "2-运行";
                        }
                        else if (data_f[j] == 3)
                        {
                            txtAAnalogInternalFanState.Text = "3-故障";
                        }
                        else if (data_f[j] == 4)
                        {
                            txtAAnalogInternalFanState.Text = "4-内部正常";
                        }
                        else
                        {
                            txtAAnalogInternalFanState.Text = "err,为" + data_f[j].ToString();
                        }
                        j++;

                        if (data_f[j] == 0)
                        {
                            txtAAnalogExternalFan1State.Text = "0-未知";
                        }
                        else if (data_f[j] == 1)
                        {
                            txtAAnalogExternalFan1State.Text = "1-停止";
                        }
                        else if (data_f[j] == 2)
                        {
                            txtAAnalogExternalFan1State.Text = "2-运行";
                        }
                        else if (data_f[j] == 3)
                        {
                            txtAAnalogExternalFan1State.Text = "3-故障";
                        }
                        else if (data_f[j] == 4)
                        {
                            txtAAnalogExternalFan1State.Text = "4-内部正常";
                        }
                        else
                        {
                            txtAAnalogExternalFan1State.Text = "err,为" + data_f[j].ToString();
                        }
                        j++;

                        if (data_f[j] == 0)
                        {
                            txtAAnalogExternalFan2State.Text = "0-未知";
                        }
                        else if (data_f[j] == 1)
                        {
                            txtAAnalogExternalFan2State.Text = "1-停止";
                        }
                        else if (data_f[j] == 2)
                        {
                            txtAAnalogExternalFan2State.Text = "2-运行";
                        }
                        else if (data_f[j] == 3)
                        {
                            txtAAnalogExternalFan2State.Text = "3-故障";
                        }
                        else if (data_f[j] == 4)
                        {
                            txtAAnalogExternalFan2State.Text = "4-内部正常";
                        }
                        else
                        {
                            txtAAnalogExternalFan2State.Text = "err,为" + data_f[j].ToString();
                        }
                        j++;
                        break;
                    case 0x02:
                        txtBAnalogPout.Text = data_f[j++].ToString();
                        txtBAnalogQout.Text = data_f[j++].ToString();
                        txtBAnalogVgrid.Text = data_f[j++].ToString();
                        txtBAnalogPowerVgrid.Text = data_f[j++].ToString();
                        txtBAnalogIgrid.Text = data_f[j++].ToString();
                        txtBAnalogVbat.Text = data_f[j++].ToString();
                        txtBAnalogPriTemp.Text = data_f[j++].ToString();
                        txtBAnalogSecTemp.Text = data_f[j++].ToString();
                        txtBAnalogDci.Text = data_f[j++].ToString();
                        txtBAnalog10V.Text = data_f[j++].ToString();
                        txtBAnalogGridFreq.Text = data_f[j++].ToString();
                         if (data_f[j] == 0)
                            {
                                txtBAnalogInternalFanState.Text = "0-未知";
                            }
                            else if (data_f[j] == 1)
                            {
                                txtBAnalogInternalFanState.Text = "1-停止";
                            }
                            else if (data_f[j] == 2)
                            {
                                txtBAnalogInternalFanState.Text = "2-运行";
                            }
                            else if (data_f[j] == 3)
                            {
                                txtBAnalogInternalFanState.Text = "3-故障";
                            }
                            else if (data_f[j] == 4)
                            {
                                txtBAnalogInternalFanState.Text = "4-内部正常";
                            }
                            else
                            {
                                txtBAnalogInternalFanState.Text = "err,为" + data_f[j].ToString();
                            }
                            j++;

                            if (data_f[j] == 0)
                            {
                                txtBAnalogExternalFan1State.Text = "0-未知";
                            }
                            else if (data_f[j] == 1)
                            {
                                txtBAnalogExternalFan1State.Text = "1-停止";
                            }
                            else if (data_f[j] == 2)
                            {
                                txtBAnalogExternalFan1State.Text = "2-运行";
                            }
                            else if (data_f[j] == 3)
                            {
                                txtBAnalogExternalFan1State.Text = "3-故障";
                            }
                            else if (data_f[j] == 4)
                            {
                                txtBAnalogExternalFan1State.Text = "4-内部正常";
                            }
                            else
                            {
                                txtBAnalogExternalFan1State.Text = "err,为" + data_f[j].ToString();
                            }
                            j++;

                            if (data_f[j] == 0)
                            {
                                txtBAnalogExternalFan2State.Text = "0-未知";
                            }
                            else if (data_f[j] == 1)
                            {
                                txtBAnalogExternalFan2State.Text = "1-停止";
                            }
                            else if (data_f[j] == 2)
                            {
                                txtBAnalogExternalFan2State.Text = "2-运行";
                            }
                            else if (data_f[j] == 3)
                            {
                                txtBAnalogExternalFan2State.Text = "3-故障";
                            }
                            else if (data_f[j] == 4)
                            {
                                txtBAnalogExternalFan2State.Text = "4-内部正常";
                            }
                            else
                            {
                                txtBAnalogExternalFan2State.Text = "err,为" + data_f[j].ToString();
                            }
                            j++;
                        break;
                    case 0x03:
                        txtCAnalogPout.Text = data_f[j++].ToString();
                        txtCAnalogQout.Text = data_f[j++].ToString();
                        txtCAnalogVgrid.Text = data_f[j++].ToString();
                        txtCAnalogPowerVgrid.Text = data_f[j++].ToString();
                        txtCAnalogIgrid.Text = data_f[j++].ToString();
                        txtCAnalogVbat.Text = data_f[j++].ToString();
                        txtCAnalogPriTemp.Text = data_f[j++].ToString();
                        txtCAnalogSecTemp.Text = data_f[j++].ToString();
                        txtCAnalogDci.Text = data_f[j++].ToString();
                        txtCAnalog10V.Text = data_f[j++].ToString();
                        txtCAnalogGridFreq.Text = data_f[j++].ToString();
                        if (data_f[j] == 0)
                        {
                            txtCAnalogInternalFanState.Text = "0-未知";
                        }
                        else if (data_f[j] == 1)
                        {
                            txtCAnalogInternalFanState.Text = "1-停止";
                        }
                        else if (data_f[j] == 2)
                        {
                            txtCAnalogInternalFanState.Text = "2-运行";
                        }
                        else if (data_f[j] == 3)
                        {
                            txtCAnalogInternalFanState.Text = "3-故障";
                        }
                        else if (data_f[j] == 4)
                        {
                            txtCAnalogInternalFanState.Text = "4-内部正常";
                        }
                        else
                        {
                            txtCAnalogInternalFanState.Text = "err,为" + data_f[j].ToString();
                        }
                        j++;

                        if (data_f[j] == 0)
                        {
                            txtCAnalogExternalFan1State.Text = "0-未知";
                        }
                        else if (data_f[j] == 1)
                        {
                            txtCAnalogExternalFan1State.Text = "1-停止";
                        }
                        else if (data_f[j] == 2)
                        {
                            txtCAnalogExternalFan1State.Text = "2-运行";
                        }
                        else if (data_f[j] == 3)
                        {
                            txtCAnalogExternalFan1State.Text = "3-故障";
                        }
                        else if (data_f[j] == 4)
                        {
                            txtCAnalogExternalFan1State.Text = "4-内部正常";
                        }
                        else
                        {
                            txtCAnalogExternalFan1State.Text = "err,为" + data_f[j].ToString();
                        }
                        j++;

                        if (data_f[j] == 0)
                        {
                            txtCAnalogExternalFan2State.Text = "0-未知";
                        }
                        else if (data_f[j] == 1)
                        {
                            txtCAnalogExternalFan2State.Text = "1-停止";
                        }
                        else if (data_f[j] == 2)
                        {
                            txtCAnalogExternalFan2State.Text = "2-运行";
                        }
                        else if (data_f[j] == 3)
                        {
                            txtCAnalogExternalFan2State.Text = "3-故障";
                        }
                        else if (data_f[j] == 4)
                        {
                            txtCAnalogExternalFan2State.Text = "4-内部正常";
                        }
                        else
                        {
                            txtCAnalogExternalFan2State.Text = "err,为" + data_f[j].ToString();
                        }
                        j++;
                        break;
                    default:
                        break;
                }
            }));
        }

        private void GetBmsAnalogDataFromRecvFrame(byte cmd, byte[] frame)
        {
            if (frame.Length < 0x17)
            {
                return;
            }

            int offset = 0;
            int data_int = 0;
            int[] almData = new int[4];
            short[] data = new short[23];
            float[] data_f = new float[23];
            float maxValue = float.MinValue;
            float minValue = float.MaxValue;
            List<int> maxIndicesInOdd = new List<int>();
            List<int> minIndicesInOdd = new List<int>();
            StringBuilder[] almResult = new StringBuilder[4];

            for (int i = 0; i < almResult.Length; i++)
            {
                almResult[i] = new StringBuilder();
            }

            float[] gain = new float[] { 10, 1000, 10, 1000, 10, 1000, 10, 1000, 10, 1000, 10, 1000, 10, 1000, 10, 1000, 10, 10, 1, 1, 1, 1000, 1000, 10, 10, 10, 10, 10, 10, 10, 10, 1000 };

            string[] AlmGrp1Name = new string[] { "PCS通讯故障1-00", "PCS通讯故障1-01", "PCS通讯故障1-02", "数采通讯故障1-03", "绝缘异常1-04", "绝缘异常2-05", "绝缘异常3-06", "电压采集线异常1-07", 
                                                  "温度采集线异常1-08", "温度采集线异常3-09", "均衡控制线异常3-10", "充放电回路异常1-11", "充放电回路异常1-12", "AFE异常1-13", "AFE异常1-14", "均衡电阻过温3-15", 
                                                  "DC端子NTC采1样2-16", "DC端子NTC采2样2-17", "交流辅助源采样1-18", "辅源总输入采样1-19", "电池电压辅源输入采样1-20", "12V电压采样1-21", "3.3V电压采样1-22", "总电压过压1-23",
                                                  "总电压过压2-24", "总电压过压3-25", "总电压欠压1-26", "总电压欠压2-27", "总电压欠压3-28", "单体过压1-29", "单体过压2-30", "单体过压3-31" };

            string[] AlmGrp2Name = new string[] { "单体欠压1-00", "单体欠压2-01", "单体欠压3-02", "单体压差过大1-03", "单体压差过大2-04", "单体压差过大3-05", "电池总压不一致2-06", "单体温度高1-07", 
                                                  "单体温度高2-08", "单体温度高3-09", "电池充电温度低1-10", "电池充电温度低2-11", "电池充电温度低3-12", "电池放电电温度低1-13", "电池放电电温度低2-14", "电池放电电温度低3-15", 
                                                  "电池温差过大1-16", "电池温差过大2-17", "电池温差过大3-18", "充电电流过大1-19", "充电电流过大2-20", "充电电流过大3-21", "放电电流过大1-22", "放电电流过大2-23",
                                                  "放电电流过大3-24", "电流不一致2-25", "电池老化3-26", "电池微短路1-27", "电池热失控1-28", "绕流风扇故障3-29", "散热风扇1故障3-30", "散热风扇2故障3-31" };

            string[] AlmGrp3Name = new string[] { "电池老化1-00", "功率不一致2-01", "加热膜故障告警3-02", "存储温度低/-03", "板温温度过高1-04", "2-05", "3-06", "1-07", 
                                                  "1-08", "3-09", "3-10", "1-11", "1-12", "1-13", "1-14", "3-15", 
                                                  "2-16", "2-17", "1-18", "1-19", "1-20", "1-21", "1-22", "1-23",
                                                  "2-24", "3-25", "1-26", "2-27", "3-28", "1-29", "2-30", "3-31" };

            string[] AlmGrp4Name = new string[] { "1-00", "2-01", "3-02", "1-03", "2-04", "3-05", "2-06", "1-07", 
                                                  "1-08", "3-09", "3-10", "1-11", "1-12", "1-13", "1-14", "3-15", 
                                                  "2-16", "2-17", "1-18", "1-19", "1-20", "1-21", "1-22", "1-23",
                                                  "2-24", "3-25", "1-26", "2-27", "3-28", "1-29", "2-30", "3-31" };

            string[][] AlmNameGroups = new string[][] { AlmGrp1Name, AlmGrp2Name, AlmGrp3Name, AlmGrp4Name };

            switch (cmd)
            {
                case 0x01:
                    for (int i = 0; i < 18; i++)
                    {
                        data[i] = (short)((frame[offset++] << 8) | frame[offset++]);
                        data_f[i] = (float)(((float)data[i]) / gain[i]);
                    }
                    if (frame.Length > 0x25) 
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            data[18 + i] = (short)(frame[offset++]);
                            data_f[18 + i] = (float)(((float)data[18 + i]) / gain[18 + i]);
                        }
                        for (int i = 0; i < 2; i++)//18+3=21
                        {
                            data[21 + i] = (short)((frame[offset++] << 8) | frame[offset++]);
                            data_f[21 + i] = (float)(((float)data[21 + i]) / gain[21 + i]);
                        }
                    }

                    int oddIndex = 0;
                    int[] originalIndices = new int[8];
                    float[] oddIndexedData = new float[8];

                    for (int i = 1; i < 16; i += 2)
                    {
                        oddIndexedData[oddIndex] = data_f[i];
                        originalIndices[oddIndex] = i;

                        if (data_f[i] > maxValue)
                        {
                            maxValue = data_f[i];
                            maxIndicesInOdd.Clear();
                            maxIndicesInOdd.Add(oddIndex +1);
                        }
                        else if (data_f[i] == maxValue)
                        {
                            maxIndicesInOdd.Add(oddIndex + 1);
                        }

                        if (data_f[i] < minValue)
                        {
                            minValue = data_f[i];
                            minIndicesInOdd.Clear();
                            minIndicesInOdd.Add(oddIndex + 1);
                        }
                        else if (data_f[i] == minValue)
                        {
                            minIndicesInOdd.Add(oddIndex + 1);
                        }

                        oddIndex++;
                    }
                    break;
                case 0x02:
                    data[0] = (short)((frame[offset++] << 8) | frame[offset++]);
                    data[1] = (short)((frame[offset++] << 8) | frame[offset++]);
                    data_int = (int)((data[0] << 16) | (data[1] & 0xFFFF));
                    data_f[0] = (float)(((float)data_int) / gain[23]);//21+1+1=23

                    for (int i = 1; i < 9; i++)
                    {
                        data[i] = (short)((frame[offset++] << 8) | frame[offset++]);
                        data_f[i] = (float)(((float)data[i]) / gain[23 + i]);
                    }
                    if (frame.Length > 0x1D)//4+8*2+4+4+1
                    {
                        List<int>[] almBit1List = new List<int>[4];

                        for (int dat_i = 0; dat_i < 2; dat_i++)
                        {
                            almData[dat_i] = (int)((frame[offset] << 24) + (frame[offset + 1] << 16) + (frame[offset + 2] << 8) + (frame[offset + 3]));
                            almBit1List[dat_i] = GetAlmDataBit1((int)almData[dat_i], 32);
                            offset += 4;
                            data_f[9 + dat_i] = almData[dat_i];
                        }

                        data[11] = (short)((frame[offset++] << 8) | frame[offset++]);
                        data_f[11] = (float)(((float)data[11]) / 10.0);

                        for (int dat_i = 2; dat_i < 4; dat_i++)
                        {
                            almData[dat_i] = (int)((frame[offset] << 24) + (frame[offset + 1] << 16) + (frame[offset + 2] << 8) + (frame[offset + 3]));
                            almBit1List[dat_i] = GetAlmDataBit1((int)almData[dat_i], 32);
                            offset += 4;
                            data_f[12 + dat_i] = almData[dat_i];
                        }

                        for (int i = 0; i < 4; i++)
                        {
                            foreach (int position in almBit1List[i])
                            {
                                if (position >= 0 && position < AlmNameGroups[i].Length)
                                {
                                    almResult[i].AppendFormat("{0}, ", AlmNameGroups[i][position]);
                                }
                            }

                            if (almResult[i].Length > 0)
                            {
                                almResult[i].Remove(almResult[i].Length - 2, 2);
                            }
                        }
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
                    case 0x01:
                        if (mAnalogMonitFlag == true)
                        {
                            DateTime currentTime = DateTime.Now;
                            AnalogBmsDataFront.Add(currentTime.ToString("yyyy-MM-dd HH:mm:ss"));
                            for (int k = 0; k < 23; k++)
                            {
                                AnalogBmsDataFront.Add(data_f[k]);
                            }
                            recordedAnalogBmsDataFront.Add(AnalogBmsDataFront);
                        }
                        txtBmsAnalogTbat1.Text = data_f[j++].ToString();
                        txtBmsAnalogVbat1.Text = data_f[j++].ToString();
                        txtBmsAnalogTbat2.Text = data_f[j++].ToString();
                        txtBmsAnalogVbat2.Text = data_f[j++].ToString();
                        txtBmsAnalogTbat3.Text = data_f[j++].ToString();
                        txtBmsAnalogVbat3.Text = data_f[j++].ToString();
                        txtBmsAnalogTbat4.Text = data_f[j++].ToString();
                        txtBmsAnalogVbat4.Text = data_f[j++].ToString();
                        txtBmsAnalogTbat5.Text = data_f[j++].ToString();
                        txtBmsAnalogVbat5.Text = data_f[j++].ToString();
                        txtBmsAnalogTbat6.Text = data_f[j++].ToString();
                        txtBmsAnalogVbat6.Text = data_f[j++].ToString();
                        txtBmsAnalogTbat7.Text = data_f[j++].ToString();
                        txtBmsAnalogVbat7.Text = data_f[j++].ToString();
                        txtBmsAnalogTbat8.Text = data_f[j++].ToString();
                        txtBmsAnalogVbat8.Text = data_f[j++].ToString();
                        txtBmsAnalogIbat.Text = data_f[j++].ToString();
                        txtBmsAnalogUbatPos.Text = data_f[j++].ToString();
                        if (frame.Length > 0x25) 
                        {
                            txtBmsAnalogSOC.Text = data_f[j++].ToString();
                            txtBmsAnalogSOH.Text = data_f[j++].ToString();
                            txtBmsAnalogSOE.Text = data_f[j++].ToString();
                            txtBmsAnalogSOP_charge.Text = data_f[j++].ToString();
                            txtBmsAnalogSOP_discharge.Text = data_f[j++].ToString();
                        }
                        txtBmsMaxVbatValue.Text = maxValue.ToString();
                        txtBmsMinVbatValue.Text = minValue.ToString();
                        StringBuilder maxIndicesStr = new StringBuilder();
                        foreach (int index in maxIndicesInOdd)
                        {
                            maxIndicesStr.Append(index + " ");
                        }
                        txtBmsMaxVbatIndex.Text = maxIndicesStr.ToString().Trim();

                        StringBuilder minIndicesStr = new StringBuilder();
                        foreach (int index in minIndicesInOdd)
                        {
                            minIndicesStr.Append(index + " ");
                        }
                        txtBmsMinVbatIndex.Text = minIndicesStr.ToString().Trim();
                        break;
                    case 0x02:
                        if (almResult[0].Length == 0)
                        {
                            txtBmsAnalogAlmGroup1.Text = "本组无告警";
                        }
                        else
                        {
                            txtBmsAnalogAlmGroup1.Text = almResult[0].ToString();
                        }
                        if (almResult[1].Length == 0)
                        {
                            txtBmsAnalogAlmGroup2.Text = "本组无告警";
                        }
                        else
                        {
                            txtBmsAnalogAlmGroup2.Text = almResult[1].ToString();
                        }
                        if (mAnalogMonitFlag == true)
                        {
                            DateTime currentTime = DateTime.Now;
                            AnalogBmsDataBack.Add(currentTime.ToString("yyyy-MM-dd HH:mm:ss"));
                            for (int k = 0; k < 14; k++)
                            {
                                AnalogBmsDataBack.Add(data_f[k]);
                            }
                            recordedAnalogBmsDataBack.Add(AnalogBmsDataBack);
                        }
                        txtBmsAnalogISR.Text = data_f[j++].ToString();
                        txtBmsAnalogTterminal1.Text = data_f[j++].ToString();
                        txtBmsAnalogTterminal2.Text = data_f[j++].ToString();
                        txtBmsAnalogTboard.Text = data_f[j++].ToString();
                        txtBmsAnalogTblncingr.Text = data_f[j++].ToString();
                        txtBmsAnalogAc30V.Text = data_f[j++].ToString();
                        txtBmsAnalogBat30V.Text = data_f[j++].ToString();
                        txtBmsAnalog30V.Text = data_f[j++].ToString();
                        txtBmsAnalog3V3.Text = data_f[j++].ToString();
                        if (frame.Length > 0x1D) 
                        {
                            j++;
                            j++;
                            txtBmsAnalog12V.Text = data_f[j++].ToString();
                            if (almResult[2].Length == 0)
                            {
                                txtBmsAnalogAlmGroup3.Text = "本组无告警";
                            }
                            else
                            {
                                txtBmsAnalogAlmGroup3.Text = almResult[2].ToString();
                            }
                            if (almResult[3].Length == 0)
                            {
                                txtBmsAnalogAlmGroup4.Text = "本组无告警";
                            }
                            else
                            {
                                txtBmsAnalogAlmGroup4.Text = almResult[3].ToString();
                            }
                        }                       
                        break;
                    default:
                        break;
                }
            }));
        }

        public void RecvBmsAnalogDataProcess(byte[] frame, byte cmd)
        {
            byte[] pBmsAnalogDat = new byte[frame.Length];
            for (int i = 0; i < frame.Length; i++)
            {
                pBmsAnalogDat[i] = frame[i];
            }
            if (pBmsAnalogDat.Length <= 0)
            {
                return;
            }

            GetBmsAnalogDataFromRecvFrame(cmd, pBmsAnalogDat);
        }

        private void chkboxAnalogDataPcs_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            if (checkBox.Checked)
            {
                mAnalogDataPcsReFlag = true;
            }
            else
            {
                mAnalogDataPcsReFlag = false;
            }
        }

        private void chkboxAnalogDataBms_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            if (checkBox.Checked)
            {
                mAnalogDataBmsReFlag = true;
            }
            else
            {
                mAnalogDataBmsReFlag = false;
            }
        }

        private void btnGetAnalogData_Click(object sender, EventArgs e)
        {
            GetAnalogData();
        }

        private void GetAnalogData()
        {
            if (m_isCanOpen == false) 
            {
                return;
            }

            if (mAnalogDataPcsReFlag == true)
            {
                byte[] cmdBuf = ModbusProto.MakeSouthDevReadCmdFrame(GetModbusAddr(), 0x1E0E, 44);
                cmdBuf = ModbusProto.TransparentToModbusCmd(cmdBuf, (mCommMode == CommMode.CAN));
                CommSendCmd(cmdBuf);

                txtSendData.Text = BitConverter.ToString(cmdBuf.ToArray()).Replace("-", " ");
            }
            if (mAnalogDataBmsReFlag == true)
            {
                byte[] frame = new byte[64];
                frame[0] = 0x00;
                frame[1] = 0x3F;
                frame[2] = 0x01;
                CommSendCmd(frame);//Send one cmd back two

                txtSendData.Text = BitConverter.ToString(frame.ToArray()).Replace("-", " ");
            }
        }

        private void btnAnalogMonit1sec1minStartStop_Click(object sender, EventArgs e)
        {
            mAnalogMonit1minor1hourFlag = false;

            if (mAnalogMonitFlag)
            {
                mAnalogMonitFlag = false;
                btnAnalogMonit1sec1minStartStop.Text = "  开始监控    (每1秒 共1分)";
                btnAnalogMonit5sec1hourStartStop.Text = "  开始监控   (每5秒 共1时)";
            }
            else
            {
                mAnalogMonitFlag = true;
                this.timerAnalogMonit.Interval = 1000;
                mAnalogMonitStart1sec1minTimer = DateTime.Now;
                btnAnalogMonit5sec1hourStartStop.Text = "  开始监控   (每5秒 共1时)";
                btnAnalogMonit1sec1minStartStop.Text = "  停止监控    (每1秒 共1分)";
            }
            timerAnalogMonitStartStopCtrl();
            LogMsg(mAnalogMonitStart1sec1minTimer.ToString(), true);
        }

        private void btnAnalogMonit5sec1hourStartStop_Click(object sender, EventArgs e)
        {
            if (mAnalogMonitFlag)
            {
                mAnalogMonitFlag = false;
                mAnalogMonit1minor1hourFlag = false;
                this.timerAnalogMonit.Interval = 1000;
                btnAnalogMonit5sec1hourStartStop.Text = "  开始监控   (每5秒 共1时)";
                btnAnalogMonit1sec1minStartStop.Text = "  开始监控    (每1秒 共1分)";
            }
            else
            {
                mAnalogMonitFlag = true;
                mAnalogMonit1minor1hourFlag = true;
                this.timerAnalogMonit.Interval = 5000;
                mAnalogMonitStart5sec1hourTimer = DateTime.Now;
                btnAnalogMonit1sec1minStartStop.Text = "  开始监控    (每1秒 共1分)";
                btnAnalogMonit5sec1hourStartStop.Text = "  停止监控   (每5秒 共1时)";
            }
            timerAnalogMonitStartStopCtrl();
            LogMsg(mAnalogMonitStart5sec1hourTimer.ToString(), true);
        }

        private void timerAnalogMonitStartStopCtrl() 
        {
            if (mAnalogMonitFlag == false)
            {
                timerAnalogMonit.Stop();
            }
            else
            {
                timerAnalogMonit.Start();
                AnalogrowData.Clear();
                recordedAnalogData.Clear();
                AnalogBmsDataFront.Clear();
                recordedAnalogBmsDataFront.Clear();
                AnalogBmsDataBack.Clear();
                recordedAnalogBmsDataBack.Clear();
            }
        }

        private void timerAnalogMonit_Tick(object sender, EventArgs e)
        {
            UInt32 timeSpan = 60000;
            DateTime timeStart = mAnalogMonitStart1sec1minTimer;

            if (mAnalogMonit1minor1hourFlag == true)
            {
                timeSpan = 3600000; //60 * 1000 * 60
                timeStart = mAnalogMonitStart5sec1hourTimer;
            }

            if (((DateTime.Now - timeStart).TotalMilliseconds <= timeSpan))
            {
                GetAnalogData();
            }
            else
            {
                timerAnalogMonit.Stop();
                mAnalogMonitFlag = false;
                if (mAnalogMonit1minor1hourFlag == true)
                {
                    btnAnalogMonit5sec1hourStartStop.Text = "  开始监控   (每5秒 共1时)";
                }
                else
                {
                    btnAnalogMonit1sec1minStartStop.Text = "  开始监控    (每1秒 共1分)";
                }
                LogMsg(DateTime.Now.ToString(), true);
                mAnalogMonit1minor1hourFlag = false;
            }          
        }

        private void btnAnalogDatSave_Click(object sender, EventArgs e)
        {
            mAnalogDataBmsSaveFlag = false;
            SaveRecordedAnalogDataToExcel(recordedAnalogData, recordedAnalogBmsDataFront, recordedAnalogBmsDataBack);
        }

        private void btnBMSAnalogDatSave_Click(object sender, EventArgs e)
        {
            mAnalogDataBmsSaveFlag = true;
            SaveRecordedAnalogDataToExcel(recordedAnalogData, recordedAnalogBmsDataFront, recordedAnalogBmsDataBack);
        }

        private void SaveRecordedAnalogDataToExcel(List<List<object>> data, List<List<object>> bmsDatFront, List<List<object>> bmsDatBack)
        {
            Excel.Application excelApp = new Excel.Application();
            excelApp.Visible = true;
            Excel.Workbook workbook = excelApp.Workbooks.Add();
            Excel.Worksheet worksheet = workbook.Sheets[1];

            if (mAnalogDataBmsSaveFlag == false)
            {
                string[] pcsDatheaders = new string[] { "记录时间", "McuId", "有功功率/kW", "无功功率/kVar", "功率电网/V", "功率电网电压/V",
                                                        "电网电流/A", "电池电压/V", "原边NTC温度/℃", "副边NTC温度/℃", "DCI/V", "10V/V", "电网频率/Hz",
                                                        "内部风扇状态", "外部风扇1状态", "外部风扇2状态"};
                worksheet.Range["A1", "P1"].Value = pcsDatheaders;

                for (int i = 0; i < data.Count; i++)
                {
                    object[] rData = new object[data[i].Count];
                    for (int j = 0; j < data[i].Count; j++)
                    {
                        rData[j] = data[i][j];
                    }
                }

                int row = 2, x = 0;

                foreach (var rData in data)
                {
                    for (int col = 1; col <= 16; col++)
                    {
                        worksheet.Cells[row, col] = rData[x++];
                        Excel.Range range = worksheet.Columns[col];
                        range.NumberFormat = "0.0000";
                    }
                    row++;
                }
            }

            string[] bmsDatFrontheaders = new string[] { "记录时间", "电芯温度1/℃", "电芯电压1/V", "电芯温度2/℃", "电芯电压2/V", "电芯温度3/℃", "电芯电压3/V", "电芯温度4/℃", "电芯电压4/V", 
                                                         "电芯温度5/℃","电芯电压5/V", "电芯温度6/℃", "电芯电压6/V", "电芯温度7/℃", "电芯电压7/V", "电芯温度8/℃", "电芯电压8/V", "电池电流/A",
                                                         "电池Bat+/V", "SOC/%", "SOH/%", "SOE/%", "SOP_CHARGE/kW", "SOP_DISCHARGE/kW" };
            worksheet.Range["Q1", "AN1"].Value = bmsDatFrontheaders;

            for (int i = 0; i < bmsDatFront.Count; i++)
            {
                object[] rData = new object[bmsDatFront[i].Count];
                for (int j = 0; j < bmsDatFront[i].Count; j++)
                {
                    rData[j] = bmsDatFront[i][j];
                }
            }

            int row2 = 2, x2 = 0;

            foreach (var rData in bmsDatFront)
            {
                for (int col = 17; col <= 40; col++)
                {
                    if (x2 <= rData.Count)
                    {
                        worksheet.Cells[row2, col] = rData[x2++];
                    }
                }
                row2++;
            }

            SetDateTimeFormat(worksheet, "A");

            string[] bmsDatBackheaders = new string[] { "记录时间", "绝缘阻抗/kΩ", "端子温度1/℃", "端子温度2/℃", "板温/℃","均衡电阻温度/℃", 
                                                        "AC30V/V", "BAT30V/V", "30V/V", "3V3/V", "BMS_AlmGroup1", "BMS_AlmGroup2", "12V/V",
                                                        "BMS_AlmGroup3", "BMS_AlmGroup4"};
            worksheet.Range["AO1", "BC1"].Value = bmsDatBackheaders;

            for (int i = 0; i < bmsDatBack.Count; i++)
            {
                object[] rData = new object[bmsDatBack[i].Count];
                for (int j = 0; j < bmsDatBack[i].Count; j++)
                {
                    rData[j] = bmsDatBack[i][j];
                }
            }

            int row3 = 2, x3 = 0;

            foreach (var rData in bmsDatBack)
            {
                for (int col = 41; col <= 55; col++)
                {
                    if (x3 <= rData.Count)
                    {
                        worksheet.Cells[row3, col] = rData[x3++];
                    }
                }
                row3++;
            }

            SetDateTimeFormat(worksheet, "Q");
            SetDateTimeFormat(worksheet, "AO");

            worksheet.Columns.AutoFit();
            mAnalogDataBmsSaveFlag = false;

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                workbook.SaveAs(saveFileDialog.FileName);
            }
        }

    }
    class AnalogDataMonitView
    {
    }
}
