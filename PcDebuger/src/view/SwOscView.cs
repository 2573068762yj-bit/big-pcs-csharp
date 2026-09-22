using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing; // 导入绘图命名空间
using System.Windows.Forms;
using System.Threading;
using System.Collections;
using System.IO;
using System.Windows.Forms.DataVisualization.Charting;

namespace PcDebuger
{
    enum OscSampleMode : ushort
    {
        SAMPLE_MODE_STOP_SAMPLE = 0,
        SAMPLE_MODE_TRIG_SAMPLE,
        SAMPLE_MODE_NORMAL_SAMPLE
    }

    public class OscDataBuf
    {
        public Queue<double> mDataBuf;
        public Queue<double> mDataShow;

        public OscDataBuf()
        {
            mDataBuf = new Queue<double>();
            mDataShow = new Queue<double>();
        }
    }

    public struct SignalObj
    {
        public ushort signalId;
        public string signalName;

        public SignalObj(ushort id, string name)
        {
            signalId = id;
            signalName = name;
        }
    }

    public struct ChannelObj
    {
        public ushort mChId;
        public bool mIsEnable;
        public ushort mSigId;
        public ushort mDataId;
        public double[] mDataBuffer;

        public ChannelObj(ushort chid, bool isEnable, ushort sigId, ushort dataId)
        {
            mChId = chid;
            mIsEnable = isEnable;
            mSigId = sigId;
            mDataId = dataId;
            mDataBuffer = new double[0];
        }
    }

    public struct ChannelVerCtrlObj
    {
        public float mZoom;
        public float mOffset;
        public ChannelVerCtrlObj(float zoom, float offset)
        {
            mZoom = zoom;
            mOffset = offset;
        }
    }

    partial class MainForm
    {
        private ushort CMD_SET_CHANNEL_PARAM = 0x2B98;
        private ushort CMD_SET_TRIGLLE_PARAM = 0x2B99;
        private ushort CMD_GET_WAVE_DATA = 0x2A98;
        private ushort CMD_GET_WAVE_READY = 0x2A97;
        private ushort CMD_GET_WAVE_FINISH = 0x2B97;
        private ushort CHANNEL_DATA_BUF_MAX_LEN = 200;
        private ushort CHANNEL_TOTAL_NUM = 4;  				
        private ushort SINGLE_FRAME_DATA_MAX_LEN = 8;
        private ushort DATA_GROUP_MAX_NUM = 25;

        private bool mIsStartToGetWaveData;
        private bool mIsChannel1Enable;
        private bool mIsChannel2Enable;
        private bool mIsChannel3Enable;
        private bool mIsChannel4Enable;
        private bool mIsGetChannel1Dat;
        private bool mIsGetChannel2Dat;
        private bool mIsGetChannel3Dat;
        private bool mIsGetChannel4Dat;

		private ushort mActiveChannelTotalNum;
        System.Threading.Thread mGetWaveDataThread;
        private Random mRandom;
        List<OscDataBuf> mOscDataBuf;
        private byte mGetWaveStatus;
        private int mWaitTimeCnt;
        private byte mSingleTrigEnable; // 0-禁能，1-使能，2-使能切换至禁能
        private bool mIsSampleOk;
        private byte mSampleMode;       // 0-禁止采集，1-触发采集，2-普通采集
        private short mRecvTrigIndex;       // 触发时刻数据的index
        private byte mGroupNum;         // 下发读波形数据的数据组数
        private ushort mStartIndex;     // 起始index，每组数据第一个数据的index
        private double[] mPcsTestDataBuf;
        private byte[] mChannelDataType;

        private List<VarOnline> mOscVarList; // 从MAP或ELF文件中读出来的所有变量和地址
        private List<VarOnlineExtend> mOscVarListExt;  //  变量读写界面中所有的变量
		
        private SignalObj[] mSignalTbl = new SignalObj[]{
            new SignalObj(0x0000, "00-signal0"),
            new SignalObj(0x0001, "01-signal1"),
            new SignalObj(0x0002, "02-signal2"),
            new SignalObj(0x0003, "03-signal3"),
            new SignalObj(0x0004, "04-signal4"),
        };

        private ChannelObj[] mChannelTblee = new ChannelObj[]{
            new ChannelObj(0, false, 0, 0),
            new ChannelObj(1, false, 0, 0),
            new ChannelObj(2, false, 0, 0),
            new ChannelObj(3, false, 0, 0),
        };
		
		Color[] mColors = new Color[]
        {
            Color.FromArgb(255, 255, 165, 0), // 橘色
            Color.FromArgb(255, 0, 128, 0),   // 绿色
            Color.FromArgb(255, 255, 192, 203), // 粉色
            Color.DodgerBlue,   // 蓝色
        };

        MarkerStyle[] mMarkStyles = new MarkerStyle[]
        {
            MarkerStyle.Circle,  // 圆形
            MarkerStyle.Cross,   // 十字
            MarkerStyle.Square,  // 三角形
            MarkerStyle.Star5,   // 星形
        };

        ComboBox[] mChxDatTypeCombox;
        NumericUpDown[] mChxVerZoomNumeric;
        NumericUpDown[] mChxVerOffsetNumeric;

        ushort[] mSigSampleFreq = 
        {
            10,//100Hz//1khz频率调用分频
            5,//200Hz
            2,//500Hz
            1,//1kHz
        };
		
		ushort[] mTrigValId = 
        {
	        0,// 通道1
	        1,// 通道2
	        2,// 通道3
            3,// 通道4
        };
		
		ushort[] mTrigCompareType = 
        {
	        0,//null
	        1,//>
	        2,//<
            3,//=
        };

        byte[] mOscDataType = 
        {
            0x91,//int16
            0x92,//uint16
            0x93,//int32
            0x94,//uint32
            0x95,//float
        };

        //ushort[] mTrigPosition = 
        //{
        //    0,//波形0点处
        //    100,//波形1/2处（200*1/2=100）
        //};
        private ushort mTrigPosition;

        private List<double[]> mSignalBuffer;

        private ChannelVerCtrlObj[] mChVerCtrlObj;

        private void InitSwOscView()
        {
            mRandom = new Random();
            mPcsTestDataBuf = new double[CHANNEL_DATA_BUF_MAX_LEN];

            mOscDataBuf = new List<OscDataBuf>();
            mOscDataBuf.Add(new OscDataBuf());
            mOscDataBuf.Add(new OscDataBuf());
            mOscDataBuf.Add(new OscDataBuf());
            mOscDataBuf.Add(new OscDataBuf());

            WaveChart.ChartAreas[0].AxisX.Maximum = CHANNEL_DATA_BUF_MAX_LEN;

            for (int i = 0; i < CHANNEL_TOTAL_NUM; i++)
            {
                WaveChart.Series[i].Color = mColors[i];
                WaveChart.Series[i].MarkerStyle = mMarkStyles[i];
            }
            
            WaveChart.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.FromArgb(50, 0, 0, 0);
            WaveChart.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.FromArgb(50, 0, 0, 0); 
            WaveChart.ChartAreas[0].AxisX.MinorGrid.LineColor = Color.FromArgb(50, 0, 0, 0);
            WaveChart.ChartAreas[0].AxisY.MinorGrid.LineColor = Color.FromArgb(50, 0, 0, 0);

            mPcsTestDataBuf = GenerateSineWave(CHANNEL_DATA_BUF_MAX_LEN, 50.0, 220, 1000);

            mSignalBuffer = new List<double[]>();
            mSignalBuffer.Add(GenerateSineWave(CHANNEL_DATA_BUF_MAX_LEN, 50.0, 220, 1000));
            mSignalBuffer.Add(GenerateSineWave(CHANNEL_DATA_BUF_MAX_LEN, 50.0, 120, 1000));
            mSignalBuffer.Add(GenerateSineWave(CHANNEL_DATA_BUF_MAX_LEN, 20.0, 220, 1000));
            mSignalBuffer.Add(GenerateSineWave(CHANNEL_DATA_BUF_MAX_LEN, 20.0, 60, 1000));
            mSignalBuffer.Add(GenerateSineWave(CHANNEL_DATA_BUF_MAX_LEN, 100.0, 60, 1000));

            mGetWaveStatus = 0;

            btnStartGetWaveData.Click += btnStartGetWaveData_Click;
            mIsStartToGetWaveData = false;

            btnChannel1.Click += btnChannel1_Click;
            mIsChannel1Enable = false;
            btnChannel2.Click += btnChannel2_Click;
            mIsChannel2Enable = false;
            btnChannel3.Click += btnChannel3_Click;
            mIsChannel3Enable = false;
            btnChannel4.Click += btnChannel4_Click;
            mIsChannel4Enable = false;

            mIsGetChannel1Dat = false;
            mIsGetChannel2Dat = false;
            mIsGetChannel3Dat = false;
            mIsGetChannel4Dat = false;

            mGetWaveDataThread = new Thread(new ThreadStart(GetWaveDataThread));
            mGetWaveDataThread.IsBackground = true;
            mGetWaveDataThread.Start();

            btnImportSignalCfg.Click += btnImportSignalCfg_Click;
            WaveChart.MouseClick += WaveChart_MouseClick;
            btnStartSingleTrigGetWaveData.Click += btnStartSingleTrigGetWaveData_Click;
            //btnSyncChannelSampleFreq.Click += btnSyncChannelSampleFreq_Click;
            btnClearAllWaveData.Click += btnClearAllWaveData_Click;
            btnImportWaveData.Click += btnImportWaveData_Click;
            btnExportWaveData.Click += btnExportWaveData_Click;

            //comboBoxCh1TrigValId.Items.AddRange(new object[] { "TrigVal_00", "TrigVal_01", "TrigVal_02" });
            comboBoxCh1TrigValId.SelectedIndex = 0;

            comboBoxCh1TrigCompareType.Items.AddRange(new object[] { "null", ">", "<", "=", ">=", "<=" });
            comboBoxCh1TrigCompareType.SelectedIndex = 0;

            //comboBoxCh1TrigPosition.Items.AddRange(new object[] { "波形0点处", "波形1/2处" });
            //comboBoxCh1TrigPosition.SelectedIndex = 0;

            textBoxCh1TrigVal.Text = "0";
            //textBoxCh1TrigData.Text = "P";

            tabControl2.Dock = DockStyle.Fill;

            if (tabPage3 == null)
            {
                tabPage3 = new TabPage("TabPage3");
                tabControl2.TabPages.Add(tabPage3);
            }

            mOscVarList = new List<VarOnline>();
            mOscVarListExt = new List<VarOnlineExtend>();

            comboBoxCh1SignalId.SelectedIndexChanged += comboBoxCh1SignalId_SelectedIndexChanged;
            comboBoxCh2SignalId.SelectedIndexChanged += comboBoxCh2SignalId_SelectedIndexChanged;
            comboBoxCh3SignalId.SelectedIndexChanged += comboBoxCh3SignalId_SelectedIndexChanged;
            comboBoxCh4SignalId.SelectedIndexChanged += comboBoxCh4SignalId_SelectedIndexChanged;

            comboBoxCh1DatType.SelectedIndex = 4;
            comboBoxCh2DatType.SelectedIndex = 4;
            comboBoxCh3DatType.SelectedIndex = 4;
            comboBoxCh4DatType.SelectedIndex = 4;

            mTrigPosition = 0;
            mIsSampleOk = false;

            mChannelDataType = new byte[4];

            mChxDatTypeCombox = new ComboBox[4];

            mChxDatTypeCombox[0] = comboBoxCh1DatType;
            mChxDatTypeCombox[1] = comboBoxCh2DatType;
            mChxDatTypeCombox[2] = comboBoxCh3DatType;
            mChxDatTypeCombox[3] = comboBoxCh4DatType;

            mChxVerZoomNumeric = new NumericUpDown[4];
            mChxVerOffsetNumeric = new NumericUpDown[4];

            mChxVerZoomNumeric[0] = numUpDnVrtZoomCh1;
            mChxVerZoomNumeric[1] = numUpDnVrtZoomCh2;
            mChxVerZoomNumeric[2] = numUpDnVrtZoomCh3;
            mChxVerZoomNumeric[3] = numUpDnVrtZoomCh4;

            mChxVerOffsetNumeric[0] = numUpDnVrtOffsetCh1;
            mChxVerOffsetNumeric[1] = numUpDnVrtOffsetCh2;
            mChxVerOffsetNumeric[2] = numUpDnVrtOffsetCh3;
            mChxVerOffsetNumeric[3] = numUpDnVrtOffsetCh4;

            mChVerCtrlObj = new ChannelVerCtrlObj[4];
            mChVerCtrlObj[0] = (new ChannelVerCtrlObj(1, 0));
            mChVerCtrlObj[1] = (new ChannelVerCtrlObj(1, 0));
            mChVerCtrlObj[2] = (new ChannelVerCtrlObj(1, 0));
            mChVerCtrlObj[3] = (new ChannelVerCtrlObj(1, 0));

            numUpDnVrtZoomCh1.ValueChanged += numUpDnVrtZoomCh1_ValueChanged;
            numUpDnVrtZoomCh2.ValueChanged += numUpDnVrtZoomCh2_ValueChanged;
            numUpDnVrtZoomCh3.ValueChanged += numUpDnVrtZoomCh3_ValueChanged;
            numUpDnVrtZoomCh4.ValueChanged += numUpDnVrtZoomCh4_ValueChanged;

            numUpDnVrtOffsetCh1.ValueChanged += numUpDnVrtOffsetCh1_ValueChanged;
            numUpDnVrtOffsetCh2.ValueChanged += numUpDnVrtOffsetCh2_ValueChanged;
            numUpDnVrtOffsetCh3.ValueChanged += numUpDnVrtOffsetCh3_ValueChanged;
            numUpDnVrtOffsetCh4.ValueChanged += numUpDnVrtOffsetCh4_ValueChanged;

            for (int i = 0; i < CHANNEL_DATA_BUF_MAX_LEN; i++)
            {
                for (int j = 0; j < CHANNEL_TOTAL_NUM; j++)
                {
                    mOscDataBuf[j].mDataBuf.Enqueue(0);
                    mOscDataBuf[j].mDataShow.Enqueue(0);
                    double yValue = 0 * mChVerCtrlObj[j].mZoom + mChVerCtrlObj[j].mOffset;
                    WaveChart.Series[j].Points.AddXY(i, 0);
                }
            }
        }

        private void UpdateOscVerShow(ushort chId)
        {
            mChVerCtrlObj[chId].mZoom = (float)mChxVerZoomNumeric[chId].Value;
            mChVerCtrlObj[chId].mOffset = (float)mChxVerOffsetNumeric[chId].Value;

            Invoke(new Action(() =>
            {
                WaveChart.Series[chId].Points.Clear();
                double[] dataBuf = mOscDataBuf[chId].mDataShow.ToArray();
                for (int i = 0; i < dataBuf.Length; i++)
                {
                    double yValue = dataBuf[i] * mChVerCtrlObj[chId].mZoom + mChVerCtrlObj[chId].mOffset;
                    WaveChart.Series[chId].Points.AddXY(i, yValue);
                }
            }));
        }

        private void numUpDnVrtZoomCh1_ValueChanged(object sender, EventArgs e)
        {
            UpdateOscVerShow(0);
        }

        private void numUpDnVrtZoomCh2_ValueChanged(object sender, EventArgs e)
        {
            UpdateOscVerShow(1);
        }

        private void numUpDnVrtZoomCh3_ValueChanged(object sender, EventArgs e)
        {
            UpdateOscVerShow(2);
        }

        private void numUpDnVrtZoomCh4_ValueChanged(object sender, EventArgs e)
        {
            UpdateOscVerShow(3);
        }

        private void numUpDnVrtOffsetCh1_ValueChanged(object sender, EventArgs e)
        {
            UpdateOscVerShow(0);
        }

        private void numUpDnVrtOffsetCh2_ValueChanged(object sender, EventArgs e)
        {
            UpdateOscVerShow(1);
        }

        private void numUpDnVrtOffsetCh3_ValueChanged(object sender, EventArgs e)
        {
            UpdateOscVerShow(2);
        }

        private void numUpDnVrtOffsetCh4_ValueChanged(object sender, EventArgs e)
        {
            UpdateOscVerShow(3);
        }

        private void WaveChart_MouseClick(object sender, MouseEventArgs e)
        {
            HitTestResult hit = WaveChart.HitTest(e.X, e.Y);

            if (hit.ChartElementType == ChartElementType.DataPoint)
            {
                DataPoint point = hit.Series.Points[hit.PointIndex];
                double xValue = point.XValue;
                double yValue = point.YValues[0];

                int xIndex = (int)Math.Round(xValue); 

                StringBuilder pointValue = new StringBuilder();
                StringBuilder channelPointValue = new StringBuilder();

                pointValue.Append("x: ").Append(xValue.ToString())
                          .Append(",y: ").Append(yValue.ToString("F2"))
                          .Append("   ");

                if (xIndex >= 0 && xIndex < CHANNEL_DATA_BUF_MAX_LEN) 
                {
                    for (int i = 0; i < CHANNEL_TOTAL_NUM; i++)
                    {
                        double chartY = double.NaN;

                        if (i < WaveChart.Series.Count && WaveChart.Series[i].Points.Count > xIndex)
                        {
                            chartY = WaveChart.Series[i].Points[xIndex].YValues[0];
                        }

                        double? bufY = null;

                        if (mOscDataBuf[i].mDataShow.Count > xIndex)
                        {
                            double[] array = mOscDataBuf[i].mDataShow.ToArray();
                            bufY = array[xIndex];
                        }

                        bool isEqual = bufY.HasValue && !double.IsNaN(chartY)
                                       && Math.Abs(bufY.Value - chartY) < 0.0001;

                        channelPointValue.Append("ch").Append(i + 1)
                                         .Append(": ").Append(bufY.HasValue ? bufY.Value.ToString("F2") : "N/A");
                        if (i < CHANNEL_TOTAL_NUM - 1)
                        {
                            channelPointValue.Append("      ");
                        }
                    }
                }
                else
                {
                    pointValue.Append("x 索引超出缓存范围\r\n");
                    channelPointValue.Append("x 索引超出缓存范围\r\n");
                }

                Mouse_textLab.Text = pointValue.ToString();
                //labelOscChannelPointData.Text = channelPointValue.ToString();
            }
            else
            {
                Mouse_textLab.Text = "未点击到曲线数据点";
                //labelOscChannelPointData.Text = "未点击到曲线数据点";
            }
        }
     
        void btnImportSignalCfg_Click(object sender, EventArgs e)
        {
            // 创建调试文件选择窗口。
            OpenFileDialog dialog = new OpenFileDialog();

            // 允许同时导入同一固件生成的MAP和ELF文件。
            dialog.Multiselect = true;

            // 提示用户选择包含变量信息的调试文件。
            dialog.Title = "请选择MAP或ELF文件";

            // 与在线变量界面使用相同的文件类型范围。
            dialog.Filter = "调试文件(*.map;*.elf)|*.map;*.elf|MAP文件(*.map)|*.map|ELF文件(*.elf)|*.elf";

            // 用户确认选择后才执行解析。
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    // 展开用户选择，并自动补充同名的MAP或ELF伴随文件。
                    string[] debugFiles = GetDebugFileList(dialog.FileNames);

                    // 示波器与在线变量共用MAP和ELF合并解析入口。
                    string warning;
                    mOscVarList = AnalysisDebugFiles(debugFiles, out warning);

                    // DWARF解析失败时先说明当前只能使用普通ELF符号。
                    if (!string.IsNullOrEmpty(warning))
                    {
                        MessageBox.Show(
                            warning,
                            "ELF解析提示",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                    }

                    // 打开变量选择窗口。
                    List<VarOnlineExtend> varListSelected = GetVarList(mOscVarList);

                    // 示波器必须至少选择一个变量。
                    if (varListSelected.Count == 0)
                    {
                        MessageBox.Show("没有选择任何变量！");
                        return;
                    }

                    // 保留原工程最多选择10个候选信号的限制。
                    if (varListSelected.Count > 10)
                    {
                        MessageBox.Show("选择的变量太多！");
                        return;
                    }

                    // 清除之前导入的示波器候选变量。
                    mOscVarListExt.Clear();

                    // 保存本次选择的变量。
                    mOscVarListExt.AddRange(varListSelected);

                    // 刷新四个示波器通道的信号下拉框。
                    UpdateWaveSignalComboxList(mOscVarListExt);

                }
                catch (Exception ex)
                {
                    // 显示文件读取或解析错误，避免异常终止程序。
                    MessageBox.Show(
                        "解析调试文件失败！\r\n" + ex.Message,
                        "文件解析",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }
        
        private void UpdateWaveSignalComboxList(List<VarOnlineExtend>  sigList)
        {
            if (sigList.Count <= 0)
            {
                return;
            }

            comboBoxCh1SignalId.Items.Clear();
            comboBoxCh2SignalId.Items.Clear();
            comboBoxCh3SignalId.Items.Clear();
            comboBoxCh4SignalId.Items.Clear();

            for (int i = 0; i < sigList.Count; i++)
            {
                comboBoxCh1SignalId.Items.Add(sigList[i].name);
                comboBoxCh2SignalId.Items.Add(sigList[i].name);
                comboBoxCh3SignalId.Items.Add(sigList[i].name);
                comboBoxCh4SignalId.Items.Add(sigList[i].name);
            }
            comboBoxCh1SignalId.SelectedIndex = 0;
            comboBoxCh2SignalId.SelectedIndex = 0;
            comboBoxCh3SignalId.SelectedIndex = 0;
            comboBoxCh4SignalId.SelectedIndex = 0;
        }

        private void comboBoxCh1SignalId_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            if (comboBox.SelectedIndex == -1)
            {
                return;
            }

            textBoxCh1Addr.Text = mOscVarListExt[comboBox.SelectedIndex].addr;
        }

        private void comboBoxCh2SignalId_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            if (comboBox.SelectedIndex == -1)
            {
                return;
            }

            textBoxCh2Addr.Text = mOscVarListExt[comboBox.SelectedIndex].addr;
        }

        private void comboBoxCh3SignalId_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            if (comboBox.SelectedIndex == -1)
            {
                return;
            }

            textBoxCh3Addr.Text = mOscVarListExt[comboBox.SelectedIndex].addr;
        }

        private void comboBoxCh4SignalId_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            if (comboBox.SelectedIndex == -1)
            {
                return;
            }

            textBoxCh4Addr.Text = mOscVarListExt[comboBox.SelectedIndex].addr;
        }

        public double[] GenerateSineWave(int sampleCount, double frequency, double amplitude, double sampleRate)
        {
            List<double> waveform = new List<double>();
            double radiansPerSample = (2 * Math.PI * frequency) / sampleRate;

            for (int i = 0; i < sampleCount; i++)
            {
                double radians = i * radiansPerSample;
                double sample = amplitude * Math.Sin(radians);
                waveform.Add(sample);
            }

            return waveform.ToArray();
        }

        private void AddDataToSwOsc(int ch, int x, double y)
        {
            mOscDataBuf[ch].mDataBuf.Enqueue(y);
            if (mOscDataBuf[ch].mDataShow.Count > CHANNEL_DATA_BUF_MAX_LEN)
            {
                mOscDataBuf[ch].mDataShow.Dequeue();
            }
            mOscDataBuf[ch].mDataShow.Enqueue(y);
            //LogMsg("Get: " + y.ToString(), true);

            Invoke(new Action(() =>
            {
                WaveChart.Series[ch].Points.Clear();
                double[] dataBuf = mOscDataBuf[ch].mDataShow.ToArray();
                for (int i = 0; i < dataBuf.Length; i++)
                {
                    double yValue = dataBuf[i] * mChVerCtrlObj[ch].mZoom + mChVerCtrlObj[ch].mOffset;
                    WaveChart.Series[ch].Points.AddXY(i, yValue);
                }
            }));
        }

        private void btnImportWaveData_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = false;
            dialog.Title = "请选择文件夹";
            dialog.Filter = "所有文件(*.wave)|*.wave";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
			    int currentChannel = -1;
                string file = dialog.FileName;
								
                List<double>[] channelDataList = new List<double>[CHANNEL_TOTAL_NUM];

                for (int i = 0; i < CHANNEL_TOTAL_NUM; i++)
                {
                    channelDataList[i] = new List<double>();
                }

                try
                {
                    string[] lines = File.ReadAllLines(file);
                    LogMsg("\r\n提示：导入时会自动跳过文件内的空行或以//开头的注释行");

                    for (int i = 0; i < lines.Length; i++)
                    {
                        string line = lines[i].Trim();

                        if (string.IsNullOrWhiteSpace(line) || line.StartsWith("//"))
                        {
                            continue;
                        }

                        if (line.StartsWith("##"))
                        {
                            System.Globalization.NumberStyles style = System.Globalization.NumberStyles.Integer;
                            System.IFormatProvider provider = System.Globalization.CultureInfo.InvariantCulture;
                            string channelStr = line.Substring(2);
                            int channelNum;
                            if (int.TryParse(channelStr, style, provider, out channelNum))
                            {
                                if (channelNum > 0 && channelNum <= CHANNEL_TOTAL_NUM)
                                {
                                    currentChannel = channelNum;
                                    LogMsg("\r\n提示：开始导入通道" + currentChannel.ToString() + "的数据");
                                }
                                else
                                {
                                    LogMsg("\r\n警告：无效的通道编号" + channelNum.ToString());
                                    currentChannel = -1;
                                }
                            }
                            else
                            {
                                LogMsg("\r\n警告：无法识别通道标记" + line.ToString());
                                currentChannel = -1;
                            }
                            continue;
                        }

                        if (currentChannel == -1)
                        {
                            continue;
                        }

                        try
                        {
                            double number = double.Parse(line);
                            channelDataList[currentChannel-1].Add(number);
                        }
                        catch (FormatException)
                        {
                            if (line.StartsWith("#END")) 
                            {
                                LogMsg("\r\n提示：无法将第" + (i + 1).ToString() + "行转换为浮点数");
                                LogMsg("无法识别内容为：" + line.ToString());
                            }                
                        }
                        catch (OverflowException)
                        {
                            LogMsg("\r\n第" + (i + 1).ToString() + "行的数值超出 double 类型的范围");
                            LogMsg("无法识别内容为：" + line.ToString());
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("读取文件时发生错误: " + ex.Message);
                    return;
                }

                Invoke(new Action(() =>
                {
                    for (int ch = 0; ch < CHANNEL_TOTAL_NUM; ch++)
                    {
                        if (channelDataList[ch].Count == 0)
                        {
                            LogMsg("\r\n提示：" + (ch + 1).ToString() + "通道无数据");
                            continue; 
                        }
                        
                        WaveChart.Series[ch].Points.Clear();
                        mOscDataBuf[ch].mDataShow.Clear();

                        double[] data = channelDataList[ch].ToArray();
                        for (int i = 0; i < data.Length; i++)
                        {
                            double yValue = data[i] * mChVerCtrlObj[ch].mZoom + mChVerCtrlObj[ch].mOffset;
                            WaveChart.Series[ch].Points.AddXY(i, yValue);
                            mOscDataBuf[ch].mDataShow.Enqueue(data[i]);
                        }
                        LogMsg("\r\n提示：成功导入通道" + (ch + 1).ToString() + "的" + data.Length.ToString() + "条数据");
                    }
                }));
            }
        }

        private void btnExportWaveData_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "所有文件(*.wave)|*.wave";
            saveFileDialog.FilterIndex = 1;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;                    

                try
                {
                    using (StreamWriter writer = new StreamWriter(filePath, false))
                    {
                        if (mIsChannel1Enable) 
                        {
                            writer.WriteLine("##1");
                            WriteQueueToFile(writer, mOscDataBuf[0].mDataShow);
                        }
                        if (mIsChannel2Enable) 
                        {
                            writer.WriteLine("##2");
                            WriteQueueToFile(writer, mOscDataBuf[1].mDataShow);
                        }
                        if (mIsChannel3Enable) 
                        {
                            writer.WriteLine("##3");
                            WriteQueueToFile(writer, mOscDataBuf[2].mDataShow);
                        }
                        if (mIsChannel4Enable) 
                        {
                            writer.WriteLine("##4");
                            WriteQueueToFile(writer, mOscDataBuf[3].mDataShow);
                        }
                        writer.WriteLine("END");
                    }
                    LogMsg("\r\n数据已成功保存到" + filePath);
                }
                catch (Exception )
                {
                    Console.WriteLine("保存数据时发生错误");
                }
             }
        }

        private void WriteQueueToFile(StreamWriter writer, Queue<double> queue)
        {            
            while (queue.Count > 0)
            {
                double value = queue.Dequeue();
                writer.WriteLine(value.ToString("F6"));
            }
        }

        private void btnClearAllWaveData_Click(object sender, EventArgs e)
        {
            ClearSwOsc();
        }

        private void ClearSwOsc()
        {
            WaveChart.Series[0].Points.Clear();
            WaveChart.Series[1].Points.Clear();
            WaveChart.Series[2].Points.Clear();
            WaveChart.Series[3].Points.Clear();

            mOscDataBuf[0].mDataShow.Clear();
            mOscDataBuf[1].mDataShow.Clear();
            mOscDataBuf[2].mDataShow.Clear();
            mOscDataBuf[3].mDataShow.Clear();
        }

        private void PcsTestSwOscLoadee(byte[] frame)
        {
            if (frame.Length < 6)
            {
                return;
            }
            ushort cmd = (ushort)((frame[1] << 8) + frame[2]);
            ushort datLen = (ushort)((frame[3] << 8) + frame[4]);
            if ((datLen + 7) > frame.Length)
            {
                return;
            }

            if (cmd == CMD_GET_WAVE_DATA)
            {
                byte chId = frame[6];
                ushort dataIndex = (ushort)((frame[7] << 8) + frame[8]);
                if(chId < mChannelTblee.Length)
                {
                    if (mChannelTblee[chId].mIsEnable)
                    {
                        ushort endIndex = (ushort)(dataIndex + SINGLE_FRAME_DATA_MAX_LEN);
                        if (endIndex > mChannelTblee[chId].mDataBuffer.Length)
                        {
                            endIndex = (ushort)mChannelTblee[chId].mDataBuffer.Length;
                        }
                        
                        List<byte> sendList = new List<byte>();
                        sendList.Add(GetModbusAddr());
                        sendList.Add(frame[1]);
                        sendList.Add(frame[2]);
                        sendList.Add(0x00);  //  错误码
                        sendList.Add(0x00);  //  数据长度
                        sendList.Add(0x00); 
                        sendList.Add((byte)(chId >> 8)); //  通道编号
                        sendList.Add((byte)(chId >> 0));
                        sendList.Add((byte)(dataIndex >> 8)); //  起始点序号
                        sendList.Add((byte)(dataIndex >> 0)); 

                        for(int i=dataIndex; i<endIndex; i++)
                        {
                            ushort waveDat = (ushort)(mChannelTblee[chId].mDataBuffer[i] * 100);
                            sendList.Add((byte)(waveDat >> 24));
                            sendList.Add((byte)(waveDat >> 16));
                            sendList.Add((byte)(waveDat >> 8));
                            sendList.Add((byte)(waveDat & 0x00FF));
                        }

                        ushort len = (ushort)(sendList.Count - 6);
                        sendList[4] = (byte)(len >> 8);
                        sendList[5] = (byte)(len & 0x00FF);

                        byte[] crcDat = sendList.ToArray();
                        ushort crcShort = ModbusCrc.Crc16(crcDat, crcDat.Length);
                        sendList.Add((byte)(crcShort & 0xFF));
                        sendList.Add((byte)(crcShort >> 8));

                        byte[] cmdBuf = sendList.ToArray();
                        CommSendCmd(cmdBuf);

                    }
                }

            }
            else if (cmd == CMD_SET_CHANNEL_PARAM)
            {
                int offset = 6;
                int chNum = frame[offset++];
                offset++;
                for (int i = 0; i < chNum; i++)
                {
                    byte chId = frame[offset++];
                    offset++;
                    byte isEnable = frame[offset++];
                    offset++;
                    offset++;//sampleFreq
                    offset++;
                    byte sigId = frame[offset++];
                    offset++;
                    if (chId < mChannelTblee.Length)
                    {
                        mChannelTblee[chId].mIsEnable = ((isEnable == 1) ? true : false);
                        mChannelTblee[chId].mDataId = 0;
                        if (sigId >= mSignalBuffer.Count)
                        {
                            sigId = 0;
                        }
                        mChannelTblee[chId].mSigId = sigId;
                        mChannelTblee[chId].mDataBuffer = mSignalBuffer[sigId];
                    }
                }
            }
        }

        private void PcsTestSwOscRecvDataProcess(byte[] frame)
        {
            if (frame.Length < 6)
            {
                return;
            }

            ushort cmd = (ushort)((frame[1] << 8) + frame[2]);
            ushort datLen = (ushort)((frame[4] << 8) + frame[5]);  //  跳过错误码
            //if ((datLen + 7) > frame.Length)
            //{
            //    return;
            //}
            
            if (cmd == CMD_GET_WAVE_READY)
            {
                int offset = 6;

                ushort trigFlg = (ushort)((frame[offset] << 8) + frame[offset + 1]);

                if (trigFlg == 0xFFFF)
                {
                    offset += 2;
                    mRecvTrigIndex = (short)((frame[offset] << 8) + frame[offset + 1]);
                    mIsSampleOk = true;
                }
            }
            else if (cmd == CMD_GET_WAVE_DATA)
            {
                int offset = 6;

                ushort chId = (ushort)((frame[offset++] << 8) + frame[offset++]);
                ushort datIndex = (ushort)((frame[offset++] << 8) + frame[offset++]);

                int pointNum = (datLen / 4) - 1; //  扣除通道id和数据id,一共占1*4字节;
                for (int i = 0; i < pointNum; i++)
                {
                    int waveDat = (int)((frame[offset++] << 24) + (frame[offset++] << 16) + (frame[offset++] << 8) + (frame[offset++]));////  注意格式转换时使用有符号的类型
                    double waveDat_d = 0.0;
                    byte dataType = mChannelDataType[chId];
                    if (dataType == 0x95)
                    {
                        waveDat_d = (double)((double)(waveDat * 1.0) / 1000.0);
                    }
                    else if (dataType == 0x94)
                    {
                        waveDat_d = (double)((double)((uint)(waveDat) * 1.0));
                    }
                    else if (dataType == 0x92)
                    {
                        waveDat_d = (double)((double)((ushort)(waveDat) * 1.0));
                    }
                    else if (dataType == 0x91)
                    {
                        waveDat_d = (double)((double)((short)(waveDat) * 1.0));
                    }
                    else
                    {
                        waveDat_d = (double)((double)(waveDat * 1.0));
                    }
                    AddDataToSwOsc(chId, datIndex++, waveDat_d);
                }
            }              
        }

        private Int32 GetTirggleValue(int ch)
        {
            double trigVal_f = 0;
            try
            {
                trigVal_f = double.Parse(textBoxCh1TrigVal.Text);
            }
            catch (FormatException)
            {
                LogMsg("字符串不是有效的浮点数格式。已自动填0。\r\n");
                textBoxCh1TrigVal.Text = "0";
            }
            catch (OverflowException)
            {
                LogMsg("字符串表示的数字太大或太小，无法转换为double。\r\n");
            }

            byte dataType = mOscDataType[mChxDatTypeCombox[ch].SelectedIndex];
            if (dataType == 0x95)
            {
                trigVal_f = trigVal_f * 1000; // 保留3位小数点
            }
            int tmpVal32 = (int)Math.Round((trigVal_f));   // 触发的比较值
            return tmpVal32;
        }

        private void UpdateSampleRate(uint div)
        {
            uint sampleFreqOrigin = (uint)numUpDnSampleFreqOrigin.Value;
            uint sampleFreq = (uint)(sampleFreqOrigin / div);
            string sampleFreqStr = "采样频率: ";
            string samplePeriodStr = "采样间隔: ";
            if (sampleFreq > 1000)
            {
                sampleFreqStr += ((uint)(sampleFreq / 1000)).ToString() + "KHz";
                samplePeriodStr += ((uint)(1000000.0 / sampleFreq)).ToString() + "us";
            }
            else
            {
                sampleFreqStr += (sampleFreq).ToString() + "Hz";
                samplePeriodStr += ((uint)(1000.0 / sampleFreq)).ToString() + "ms";
            }

            labSampleFreq.Text = sampleFreqStr;
            labSamplePeriod.Text = samplePeriodStr;
        }

        private byte[] MakeWaveTriggerMsg()
        {
            List<byte> datPayload = new List<byte>();
            ushort tmpVal = 0;
            Invoke(new Action(() =>
            {
                datPayload.Add(mSampleMode);                                                    // 触发控制, 0x00=停止采集; 0x01=条件触发; 0x02=手动触发;
                datPayload.Add((byte)mTrigValId[comboBoxCh1TrigValId.SelectedIndex]);           // 触发通道
                mTrigPosition = (ushort)numericUpDownTrigPos.Value;                             // 触发位置
                datPayload.Add((byte)(mTrigPosition >> 8 & 0x00FF));
                datPayload.Add((byte)(mTrigPosition >> 0 & 0x00FF));
                tmpVal = (ushort)mTrigCompareType[comboBoxCh1TrigCompareType.SelectedIndex];    // 触发条件，比较类型
                datPayload.Add((byte)(tmpVal >> 8 & 0x00FF));
                datPayload.Add((byte)(tmpVal >> 0 & 0x00FF));
                Int32 tmpVal32 = GetTirggleValue(comboBoxCh1TrigValId.SelectedIndex);           // 触发比较变量值
                datPayload.Add((byte)(tmpVal32 >> 24));
                datPayload.Add((byte)(tmpVal32 >> 16));        
                datPayload.Add((byte)(tmpVal32 >> 8));
                datPayload.Add((byte)(tmpVal32 & 0x00FF));

                tmpVal = (ushort)numUpDnSampleDiv.Value;           // 采样分频系数，所有通道共用一个                              
                datPayload.Add((byte)(tmpVal >> 8 & 0x00FF));
                datPayload.Add((byte)(tmpVal >> 0 & 0x00FF));

                //  更新采样频率
                UpdateSampleRate(tmpVal);
            }));

            byte modbusAddr = GetModbusAddr();
            //if (m_dstAddr == 0x0F)
            //{
            //    modbusAddr = (byte)((m_srcAddr << 4) + 0x01);
            //}
            byte[] cmdBuf = ModbusProto.MakeSouthDevWriteCmdFrame(modbusAddr, CMD_SET_TRIGLLE_PARAM, (ushort)datPayload.Count, datPayload.ToArray());
            LogMsg(cmdBuf, true);
            cmdBuf = ModbusProto.TransparentToModbusCmd(cmdBuf, (mCommMode == CommMode.CAN));
            LogMsg(cmdBuf, true);
            
			return cmdBuf;
        }

        private byte[] MakeWaveGetMsg(ushort chId, ushort dataId)
        {
            byte[] dataPayload = new byte[4];
            dataPayload[0] = (byte)((chId >> 8) & 0x00FF);
            dataPayload[1] = (byte)((chId >> 0) & 0x00FF);
            dataPayload[2] = (byte)((dataId >> 8) & 0x00FF);
            dataPayload[3] = (byte)((dataId >> 0) & 0x00FF);

            byte modbusAddr = GetModbusAddr();
            //if (m_dstAddr == 0x0F)
            //{
            //    modbusAddr = (byte)((m_srcAddr << 4) + 0x01);
            //}
            return ModbusProto.MakeModbusFrame(modbusAddr, CMD_GET_WAVE_DATA, dataPayload, dataPayload.Length, true, true);
        }

        private int SendWaveGetCmd(int dataIndex)
        {
            if (mIsChannel1Enable)
            {
                byte[] cmdBuf = MakeWaveGetMsg(0, (ushort)dataIndex);
                LogMsg(cmdBuf, true);
                cmdBuf = ModbusProto.TransparentToModbusCmd(cmdBuf, (mCommMode == CommMode.CAN));
                LogMsg(cmdBuf, true);
                CommSendCmd(cmdBuf);
            }
            if (mIsChannel2Enable)
            {
                byte[] cmdBuf = MakeWaveGetMsg(1, (ushort)dataIndex);
                cmdBuf = ModbusProto.TransparentToModbusCmd(cmdBuf, (mCommMode == CommMode.CAN));
                CommSendCmd(cmdBuf);
            }
            if (mIsChannel3Enable)
            {
                byte[] cmdBuf = MakeWaveGetMsg(2, (ushort)dataIndex);
                cmdBuf = ModbusProto.TransparentToModbusCmd(cmdBuf, (mCommMode == CommMode.CAN));
                CommSendCmd(cmdBuf);
            }
            if (mIsChannel4Enable)
            {
                byte[] cmdBuf = MakeWaveGetMsg(3, (ushort)dataIndex);
                cmdBuf = ModbusProto.TransparentToModbusCmd(cmdBuf, (mCommMode == CommMode.CAN));
                CommSendCmd(cmdBuf);
            }
            return 0;
        }

        private byte[] MakeWaveGetOkMsg()
        {
            byte[] dataPayload = new byte[4];
            dataPayload[0] = 0xFF;
            dataPayload[1] = 0xFF;
            dataPayload[2] = 0xFF;
            dataPayload[3] = 0xFF;

            byte modbusAddr = GetModbusAddr();
            //if (m_dstAddr == 0x0F)
            //{
            //    modbusAddr = (byte)((m_srcAddr << 4) + 0x01);
            //}
            return ModbusProto.MakeModbusFrame(modbusAddr, CMD_GET_WAVE_FINISH, dataPayload, dataPayload.Length, true, true);
        }

        private void SendDataInThread(byte[] dat)
        {
            Invoke(new Action(() =>
            {
                byte[]cmdBuf = ModbusProto.TransparentToModbusCmd(dat, (mCommMode == CommMode.CAN));
                CommSendCmd(cmdBuf);
            }));  
        }

        private void GetWaveDataThread()
        {
            while (true)
            {
                Thread.Sleep(10);

                if (mGetWaveStatus == 0x00)  //  idle
                {
                    if (mIsStartToGetWaveData)
                    {
                        //LogMsg("WaveData: ");
                        //for (int i = 0; i < mPcsTestDataBuf.Length; i++)
                        //{
                        //    LogMsg(mPcsTestDataBuf[i].ToString() + ", ", false);
                        //}
                        //LogMsg("\r\n");
                        mGroupNum = 0;
                        mStartIndex = 0;
                        mWaitTimeCnt = 0;  
                        mGetWaveStatus = 0x01;
                    }
                }
                else if (mGetWaveStatus == 0x01)
                {
                    if (mIsSampleOk)  //  等待采集完成
                    {
                        mGetWaveStatus = 0x03;  // 开始导数据
                    }
                }
                else if (mGetWaveStatus == 0x02)  //  wait 1000ms
                {
                    mWaitTimeCnt++;
                    if (mWaitTimeCnt > 5 * mActiveChannelTotalNum)
                    {
                        mWaitTimeCnt = 0;
                        mGetWaveStatus = 0x03;
                    }
                }
                else if (mGetWaveStatus == 0x03)
                {
                    if (mRecvTrigIndex < 0 || mRecvTrigIndex >= CHANNEL_DATA_BUF_MAX_LEN)
                    {
                        mIsStartToGetWaveData = false;
                        mGetWaveStatus = 0x01;
						LogMsg("\r\n触发时刻的数据index超出合理范围!\r\n\r\n");
                        return;
                    }
                    
                    Invoke(new Action(() =>
                    {
                        if (mSampleMode == (byte)OscSampleMode.SAMPLE_MODE_NORMAL_SAMPLE || mSampleMode == (byte)OscSampleMode.SAMPLE_MODE_TRIG_SAMPLE)
                        {
                            mStartIndex = (ushort)CalcGroupStartIndex(mRecvTrigIndex, mGroupNum);
                            SendWaveGetCmd(mStartIndex);
                            mStartIndex += SINGLE_FRAME_DATA_MAX_LEN;
                            mGroupNum++;
                        }
                        //else if (mSingleTrigEnable == 1)//波形1/2处触发采集的每组数据起始index计算
                        //{
                        //    //mStartIndex = (ushort)CalcGroupStartIndex(mRecvTrigIndex, mGroupNum);
                        //    SendWaveGetCmd(mStartIndex);
                        //}
                        
                        mGetWaveStatus = 0x02;
                    }));  

                    if (mGroupNum >= DATA_GROUP_MAX_NUM)  // 采集完成
                    {
                        SendDataInThread(MakeWaveGetOkMsg());
                        mGroupNum = 0;
                        mStartIndex = 0;
                        mIsStartToGetWaveData = false;
                        mGetWaveStatus = 0x00;
                    }

                    if (!mIsStartToGetWaveData)
                    {
                        Invoke(new Action(() =>
                        {
                            btnStartGetWaveData.Text = "手动采集";
                        }));
                        mGetWaveStatus = 0x00;
                    }

                    if (mGetWaveStatus == 0x00 && mSingleTrigEnable == 1)
                    {
                        mSingleTrigEnable = 0x00;
                        Invoke(new Action(() =>
                        {
                            btnStartSingleTrigGetWaveData.Text = "条件触发";
                        }));
                        LogMsg("\r\n停止采集满足触发条件的通道波形!\r\n\r\n");
                    }
                }
                else if (mGetWaveStatus == 0x04)//SingleTrigWait
                {
                    if (mSingleTrigEnable == 2)
                    {
                        Thread.Sleep(5000);
                        mGetWaveStatus = 0x02;
                        mSingleTrigEnable = 1;
                    }
                }
            }
        }
		
        short CalcGroupStartIndex(short triIndex, byte groupNum)
        {
            //  导数据的起始点，就是从触发时的序号往前数预设的mTrigPosition偏移个点的位置，例如，触发偏移是100，触发时的点序号是180，
            //  则180 - 100 = 80处是导出的起始点，又比如触发偏移是0，触发点序号是20，则导出的起始点就是20.
            short startIndex = (short)(triIndex - mTrigPosition + groupNum * SINGLE_FRAME_DATA_MAX_LEN);

            if (startIndex < 0)
            {
                startIndex += (short)CHANNEL_DATA_BUF_MAX_LEN;  // 循环到数组的开头
            }
            startIndex %= (short)CHANNEL_DATA_BUF_MAX_LEN;  // 确保索引在有效范围内

            return startIndex;
        }

        private ComboBox GetOscChDatTypeComboxByChId(ushort id) 
        {
            ComboBox cbox = new ComboBox();
            switch(id)
            {
                case 0:
                    cbox = comboBoxCh1DatType;
                    break;
                case 1:
                    cbox = comboBoxCh2DatType;
                    break;
                case 2:
                    cbox = comboBoxCh3DatType;
                    break;
                case 3:
                    cbox = comboBoxCh4DatType;
                    break;
                default:
                    break;
            }
            return cbox;
        }

        private String GetOscChDatAddrByChId(ushort id)
        {
            string strAddr = " ";
            switch (id)
            {
                case 0:
                    strAddr = textBoxCh1Addr.Text;
                    break;
                case 1:
                    strAddr = textBoxCh2Addr.Text;
                    break;
                case 2:
                    strAddr = textBoxCh3Addr.Text;
                    break;
                case 3:
                    strAddr = textBoxCh4Addr.Text;
                    break;
                default:
                    break;
            }
            return strAddr;
        }

        private byte[] MakeChannelCfgMsg(ushort chId, bool isEnable)
        {

            List<byte> dataPayload = new List<byte>();
            if (chId > 3)
            {
                return dataPayload.ToArray();
            }

            dataPayload.Add((byte)((chId >> 8) & 0x00FF));                                              //  通道编号
            dataPayload.Add((byte)((chId >> 0) & 0x00FF));
            ushort tmpVal = (ushort)numUpDnSampleDiv.Value;                                             //  采样分频，所有通道保持一致                              
            dataPayload.Add((byte)(tmpVal >> 8 & 0x00FF));
            dataPayload.Add((byte)(tmpVal >> 0 & 0x00FF));
            //  更新采样频率
            UpdateSampleRate(tmpVal);

            dataPayload.Add((byte)(isEnable == true ? 0x01 : 0x00));                                    //  使能控制
            mChannelDataType[chId] = (byte)(mOscDataType[GetOscChDatTypeComboxByChId(chId).SelectedIndex]);
            dataPayload.Add(mChannelDataType[chId]);     //  数据类型

            uint sigAddr = VarDebugOnlineGetAddr(GetOscChDatAddrByChId(chId));
            dataPayload.Add((byte)(sigAddr >> 24 & 0x00FF));                                            //  变量地址
            dataPayload.Add((byte)(sigAddr >> 16 & 0x00FF));
            dataPayload.Add((byte)(sigAddr >> 8 & 0x00FF));
            dataPayload.Add((byte)(sigAddr >> 0 & 0x00FF));
            return dataPayload.ToArray();
        }

        private byte[] MakeOneChCfgSendMsg(ushort chId, bool isEnable)
        {
            List<byte> datPayload = new List<byte>();
            datPayload.Add(0x00);
            datPayload.Add(0x01);  // 通道数为1
            datPayload.AddRange(MakeChannelCfgMsg(chId, isEnable));
            byte modbusAddr = GetModbusAddr();
            //if (m_dstAddr == 0x0F)
            //{
            //    modbusAddr = (byte)((m_srcAddr << 4) + 0x01);
            //}
            byte[] cmdBuf = ModbusProto.MakeSouthDevWriteCmdFrame(modbusAddr, CMD_SET_CHANNEL_PARAM, (ushort)datPayload.Count, datPayload.ToArray());
            LogMsg(cmdBuf, true);
            cmdBuf = ModbusProto.TransparentToModbusCmd(cmdBuf, (mCommMode == CommMode.CAN));
            LogMsg(cmdBuf, true);
            return cmdBuf;
        }

        void updatemActiveChannelTotalNum()
        {
            mActiveChannelTotalNum = 0;
            if (mIsChannel1Enable)
            {
                mActiveChannelTotalNum++;
            }
            if (mIsChannel2Enable)
            {
                mActiveChannelTotalNum++;
            }
            if (mIsChannel3Enable)
            {
                mActiveChannelTotalNum++;
            }
            if (mIsChannel4Enable)
            {
                mActiveChannelTotalNum++;
            }
        }

        void btnChannel1_Click(object sender, EventArgs e)
        {
            if (mIsChannel1Enable)
            {
                mIsChannel1Enable = false;
                btnChannel1.BackColor = btnStartGetWaveData.BackColor;
                byte[] cmdBuf = MakeOneChCfgSendMsg(0x0000, false);
                CommSendCmd(cmdBuf);
            }
            else
            {
                mIsChannel1Enable = true;
                btnChannel1.BackColor = mColors[0];
                byte[] cmdBuf = MakeOneChCfgSendMsg(0x0000, true);
                CommSendCmd(cmdBuf);
            }
            updatemActiveChannelTotalNum();
        }

        void btnChannel2_Click(object sender, EventArgs e)
        {
            if (mIsChannel2Enable)
            {
                mIsChannel2Enable = false;
                btnChannel2.BackColor = btnStartGetWaveData.BackColor;
                byte[] cmdBuf = MakeOneChCfgSendMsg(0x0001, false);
                CommSendCmd(cmdBuf);
            }
            else
            {
                mIsChannel2Enable = true;
                btnChannel2.BackColor = mColors[1];
                byte[] cmdBuf = MakeOneChCfgSendMsg(0x0001, true);
                CommSendCmd(cmdBuf);
            }
            updatemActiveChannelTotalNum();
        }

        void btnChannel3_Click(object sender, EventArgs e)
        {
            if (mIsChannel3Enable)
            {
                mIsChannel3Enable = false;
                btnChannel3.BackColor = btnStartGetWaveData.BackColor;
                byte[] cmdBuf = MakeOneChCfgSendMsg(0x0002, false);
                CommSendCmd(cmdBuf);
            }
            else
            {
                mIsChannel3Enable = true;
                btnChannel3.BackColor = mColors[2];
                byte[] cmdBuf = MakeOneChCfgSendMsg(0x0002, true);
                CommSendCmd(cmdBuf);
            }
            updatemActiveChannelTotalNum();
        }

        void btnChannel4_Click(object sender, EventArgs e)
        {
            if (mIsChannel4Enable)
            {
                mIsChannel4Enable = false;
                btnChannel4.BackColor = btnStartGetWaveData.BackColor;
                byte[] cmdBuf = MakeOneChCfgSendMsg(0x0003, false);
                CommSendCmd(cmdBuf);
            }
            else
            {
                mIsChannel4Enable = true;
                btnChannel4.BackColor = mColors[3];
                byte[] cmdBuf = MakeOneChCfgSendMsg(0x0003, true);
                CommSendCmd(cmdBuf);
            }
            updatemActiveChannelTotalNum();
        }

        void btnStartGetWaveData_Click(object sender, EventArgs e)
        {
            if (mIsChannel1Enable != true && mIsChannel2Enable != true && mIsChannel3Enable != true && mIsChannel4Enable != true)
            {
                LogMsg("\r\n请先使能要采集的信号通道。\r\n");
                return;
            }

            if (mSingleTrigEnable == 1 || mSingleTrigEnable == 2)
            {
                LogMsg("\r\n请先关闭触发功能。\r\n");
                return;
            }

            if (mIsStartToGetWaveData)
            {
                mIsStartToGetWaveData = false;
                mSampleMode = (byte)OscSampleMode.SAMPLE_MODE_STOP_SAMPLE;
                btnStartGetWaveData.Text = "开始采集";
            }
            else
            {
                mRecvTrigIndex = 0;
                mIsSampleOk = false;
                mSampleMode = (byte)OscSampleMode.SAMPLE_MODE_NORMAL_SAMPLE;
                byte[] cmdBuf = MakeWaveTriggerMsg();
                CommSendCmd(cmdBuf);
                
                mGetWaveStatus = 0;
                mIsStartToGetWaveData = true;

                ClearSwOsc();
                btnStartGetWaveData.Text = "停止采集";
            }
        }

        private void btnStartSingleTrigGetWaveData_Click(object sender, EventArgs e)
        {
            if (mIsChannel1Enable != true && mIsChannel2Enable != true && mIsChannel3Enable != true && mIsChannel4Enable != true)
            {
                LogMsg("请先使能要采集的信号通道。\r\n");
                return;
            }

            if (comboBoxCh1TrigCompareType.SelectedIndex == 0)
            {
                LogMsg("请先设置触发条件。\r\n");
                return;
            }

            if (mIsStartToGetWaveData)
            {
                //停止触发
                mSampleMode = (byte)OscSampleMode.SAMPLE_MODE_STOP_SAMPLE;
                mSingleTrigEnable = 0; 
                byte[] cmdBuf = MakeWaveTriggerMsg();  // 停止采集
                CommSendCmd(cmdBuf);  
                               
                mIsStartToGetWaveData = false;
                btnStartSingleTrigGetWaveData.Text = "单次触发";
                LogMsg("\r\n停止采集满足触发条件的通道波形!\r\n\r\n");
                mGetWaveStatus = 0;
            }
            else
            {
                //开始触发
                mRecvTrigIndex = 0;
                mIsSampleOk = false;
                mSampleMode = (byte)OscSampleMode.SAMPLE_MODE_TRIG_SAMPLE;
                byte[] cmdBuf = MakeWaveTriggerMsg();
                CommSendCmd(cmdBuf);

                mSingleTrigEnable = 1;                
                mIsStartToGetWaveData = true;
                btnStartSingleTrigGetWaveData.Text = "停止触发";
                ClearSwOsc();
                mGetWaveStatus = 0;
                SyncChannelSampleFreq();
            }           
        }

        private void SyncChannelSampleFreq() 
        {
            //comboBoxCh2SampleFreq.SelectedIndex = comboBoxCh1SampleFreq.SelectedIndex;
            //comboBoxCh3SampleFreq.SelectedIndex = comboBoxCh1SampleFreq.SelectedIndex;
            //comboBoxCh4SampleFreq.SelectedIndex = comboBoxCh1SampleFreq.SelectedIndex;
        }

        private void btnSyncChannelSampleFreq_Click(object sender, EventArgs e) 
        {
            SyncChannelSampleFreq();
        }

    }

    class SwOscView
    {
    }
}
