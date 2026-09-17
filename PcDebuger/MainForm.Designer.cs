namespace PcDebuger
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox55 = new System.Windows.Forms.GroupBox();
            this.btnPeriodSend = new System.Windows.Forms.Button();
            this.button_clear = new System.Windows.Forms.Button();
            this.textBoxSendPeriod = new System.Windows.Forms.TextBox();
            this.btnCmdRecordFileSaveAs = new System.Windows.Forms.Button();
            this.chkBoxHexSend = new System.Windows.Forms.CheckBox();
            this.checkBoxShowSend = new System.Windows.Forms.CheckBox();
            this.chkBoxHexShow = new System.Windows.Forms.CheckBox();
            this.checkBoxShowRecv = new System.Windows.Forms.CheckBox();
            this.labelCPcsSoftwareVer = new System.Windows.Forms.Label();
            this.labelBPcsSoftwareVer = new System.Windows.Forms.Label();
            this.labelAPcsSoftwareVer = new System.Windows.Forms.Label();
            this.btnGetPcsSoftwareVer = new System.Windows.Forms.Button();
            this.label57 = new System.Windows.Forms.Label();
            this.txtReceivedData = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBoxUartCfg = new System.Windows.Forms.GroupBox();
            this.btnOpenClose = new System.Windows.Forms.Button();
            this.button_Scan = new System.Windows.Forms.Button();
            this.cmbBaudRate = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbPortName = new System.Windows.Forms.ComboBox();
            this.groupBoxPlcDstCfg = new System.Windows.Forms.GroupBox();
            this.label42 = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.txtBoxDstPanId = new System.Windows.Forms.TextBox();
            this.txtBoxDstAddr = new System.Windows.Forms.TextBox();
            this.groupBoxPlcTstBrdCfg = new System.Windows.Forms.GroupBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label43 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPanId = new System.Windows.Forms.TextBox();
            this.btnCpx4Init = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.txtTxScale = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbBandPlan = new System.Windows.Forms.ComboBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBoxCanSendCfg = new System.Windows.Forms.GroupBox();
            this.checkBoxIsUseCanId = new System.Windows.Forms.CheckBox();
            this.label15 = new System.Windows.Forms.Label();
            this.textBoxCanIDSrcAddr = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.textBoxCanIdDestAddr = new System.Windows.Forms.TextBox();
            this.label_protocol = new System.Windows.Forms.Label();
            this.comboBox_frametype = new System.Windows.Forms.ComboBox();
            this.comboBox_protocol = new System.Windows.Forms.ComboBox();
            this.label_channel = new System.Windows.Forms.Label();
            this.comboBox_channel = new System.Windows.Forms.ComboBox();
            this.textBox_ID = new System.Windows.Forms.TextBox();
            this.label_frametype = new System.Windows.Forms.Label();
            this.groupBoxCanCfg = new System.Windows.Forms.GroupBox();
            this.label_endid = new System.Windows.Forms.Label();
            this.textBox_endid = new System.Windows.Forms.TextBox();
            this.button_close = new System.Windows.Forms.Button();
            this.comboBox_index = new System.Windows.Forms.ComboBox();
            this.label_startid = new System.Windows.Forms.Label();
            this.label_index = new System.Windows.Forms.Label();
            this.button_reset = new System.Windows.Forms.Button();
            this.comboBox_device = new System.Windows.Forms.ComboBox();
            this.label_device = new System.Windows.Forms.Label();
            this.button_init = new System.Windows.Forms.Button();
            this.button_start = new System.Windows.Forms.Button();
            this.textBox_startid = new System.Windows.Forms.TextBox();
            this.comboBox_standard2 = new System.Windows.Forms.ComboBox();
            this.label_standard2 = new System.Windows.Forms.Label();
            this.button_open = new System.Windows.Forms.Button();
            this.comboBox_ABIT2 = new System.Windows.Forms.ComboBox();
            this.label_ABIT2 = new System.Windows.Forms.Label();
            this.comboBox_ABIT = new System.Windows.Forms.ComboBox();
            this.label_ABIT = new System.Windows.Forms.Label();
            this.comboBox_mode = new System.Windows.Forms.ComboBox();
            this.label_mode = new System.Windows.Forms.Label();
            this.comboBox_standard = new System.Windows.Forms.ComboBox();
            this.label_standard = new System.Windows.Forms.Label();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.radioBtnComm485Mode = new System.Windows.Forms.RadioButton();
            this.radioBtnCommCanMode = new System.Windows.Forms.RadioButton();
            this.radioBtnCommUartMode = new System.Windows.Forms.RadioButton();
            this.radioBtnCommPlcMode = new System.Windows.Forms.RadioButton();
            this.groupBox23 = new System.Windows.Forms.GroupBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.label72 = new System.Windows.Forms.Label();
            this.label71 = new System.Windows.Forms.Label();
            this.btnCalculateCrc = new System.Windows.Forms.Button();
            this.tbCrcResult = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.tbData2Crc = new System.Windows.Forms.TextBox();
            this.txtSendData = new System.Windows.Forms.TextBox();
            this.groupBox16 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.radioBtnConnectObjectPCS_A = new System.Windows.Forms.RadioButton();
            this.radioBtnConnectObjectPCS_B = new System.Windows.Forms.RadioButton();
            this.radioBtnConnectObjectBigPcs = new System.Windows.Forms.RadioButton();
            this.labDestMcuAddr = new System.Windows.Forms.Label();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox63 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.label287 = new System.Windows.Forms.Label();
            this.btnChannel1 = new System.Windows.Forms.Button();
            this.btnChannel2 = new System.Windows.Forms.Button();
            this.btnChannel3 = new System.Windows.Forms.Button();
            this.btnChannel4 = new System.Windows.Forms.Button();
            this.label286 = new System.Windows.Forms.Label();
            this.comboBoxCh1SignalId = new System.Windows.Forms.ComboBox();
            this.comboBoxCh2SignalId = new System.Windows.Forms.ComboBox();
            this.comboBoxCh3SignalId = new System.Windows.Forms.ComboBox();
            this.comboBoxCh4SignalId = new System.Windows.Forms.ComboBox();
            this.label349 = new System.Windows.Forms.Label();
            this.textBoxCh1Addr = new System.Windows.Forms.TextBox();
            this.textBoxCh2Addr = new System.Windows.Forms.TextBox();
            this.textBoxCh3Addr = new System.Windows.Forms.TextBox();
            this.textBoxCh4Addr = new System.Windows.Forms.TextBox();
            this.label345 = new System.Windows.Forms.Label();
            this.comboBoxCh1DatType = new System.Windows.Forms.ComboBox();
            this.comboBoxCh2DatType = new System.Windows.Forms.ComboBox();
            this.comboBoxCh3DatType = new System.Windows.Forms.ComboBox();
            this.comboBoxCh4DatType = new System.Windows.Forms.ComboBox();
            this.btnExportWaveData = new System.Windows.Forms.Button();
            this.btnImportWaveData = new System.Windows.Forms.Button();
            this.btnOscAddSignal = new System.Windows.Forms.Button();
            this.btnImportSignalCfg = new System.Windows.Forms.Button();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox62 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.numericUpDownTrigPos = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown3 = new System.Windows.Forms.NumericUpDown();
            this.label361 = new System.Windows.Forms.Label();
            this.label359 = new System.Windows.Forms.Label();
            this.numUpDnVrtZoomCh1 = new System.Windows.Forms.NumericUpDown();
            this.numUpDnVrtZoomCh2 = new System.Windows.Forms.NumericUpDown();
            this.numUpDnVrtZoomCh3 = new System.Windows.Forms.NumericUpDown();
            this.numUpDnVrtZoomCh4 = new System.Windows.Forms.NumericUpDown();
            this.numUpDnVrtOffsetCh1 = new System.Windows.Forms.NumericUpDown();
            this.numUpDnVrtOffsetCh2 = new System.Windows.Forms.NumericUpDown();
            this.numUpDnVrtOffsetCh3 = new System.Windows.Forms.NumericUpDown();
            this.numUpDnVrtOffsetCh4 = new System.Windows.Forms.NumericUpDown();
            this.label325 = new System.Windows.Forms.Label();
            this.label346 = new System.Windows.Forms.Label();
            this.label347 = new System.Windows.Forms.Label();
            this.label348 = new System.Windows.Forms.Label();
            this.label350 = new System.Windows.Forms.Label();
            this.label351 = new System.Windows.Forms.Label();
            this.label352 = new System.Windows.Forms.Label();
            this.label353 = new System.Windows.Forms.Label();
            this.tableLayoutPanel9 = new System.Windows.Forms.TableLayoutPanel();
            this.label288 = new System.Windows.Forms.Label();
            this.label284 = new System.Windows.Forms.Label();
            this.numUpDnSampleFreqOrigin = new System.Windows.Forms.NumericUpDown();
            this.numUpDnSampleDiv = new System.Windows.Forms.NumericUpDown();
            this.btnStartGetWaveData = new System.Windows.Forms.Button();
            this.btnClearAllWaveData = new System.Windows.Forms.Button();
            this.groupBox54 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.label282 = new System.Windows.Forms.Label();
            this.comboBoxCh1TrigValId = new System.Windows.Forms.ComboBox();
            this.label281 = new System.Windows.Forms.Label();
            this.comboBoxCh1TrigCompareType = new System.Windows.Forms.ComboBox();
            this.label50 = new System.Windows.Forms.Label();
            this.textBoxCh1TrigVal = new System.Windows.Forms.NumericUpDown();
            this.btnStartSingleTrigGetWaveData = new System.Windows.Forms.Button();
            this.tableLayoutPanel10 = new System.Windows.Forms.TableLayoutPanel();
            this.WaveChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tableLayoutPanel11 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox67 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel14 = new System.Windows.Forms.TableLayoutPanel();
            this.button11 = new System.Windows.Forms.Button();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label362 = new System.Windows.Forms.Label();
            this.label367 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.groupBox68 = new System.Windows.Forms.GroupBox();
            this.labSamplePeriod = new System.Windows.Forms.Label();
            this.labSampleFreq = new System.Windows.Forms.Label();
            this.label371 = new System.Windows.Forms.Label();
            this.label370 = new System.Windows.Forms.Label();
            this.label369 = new System.Windows.Forms.Label();
            this.label368 = new System.Windows.Forms.Label();
            this.label366 = new System.Windows.Forms.Label();
            this.label365 = new System.Windows.Forms.Label();
            this.label364 = new System.Windows.Forms.Label();
            this.label363 = new System.Windows.Forms.Label();
            this.label285 = new System.Windows.Forms.Label();
            this.Mouse_textLab = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.groupBox59 = new System.Windows.Forms.GroupBox();
            this.textBoxBmsRunState = new System.Windows.Forms.TextBox();
            this.btnGetBmsRunState = new System.Windows.Forms.Button();
            this.groupBox40 = new System.Windows.Forms.GroupBox();
            this.label280 = new System.Windows.Forms.Label();
            this.textBoxCFG_Q_CTRL_KVAR = new System.Windows.Forms.TextBox();
            this.btnGetLimitQ = new System.Windows.Forms.Button();
            this.btnSetLimitQ = new System.Windows.Forms.Button();
            this.groupBox34 = new System.Windows.Forms.GroupBox();
            this.comboHeatFilmPwrSup = new System.Windows.Forms.ComboBox();
            this.btnGetHeatFilmPwrSup = new System.Windows.Forms.Button();
            this.btnSetHeatFilmPwrSup = new System.Windows.Forms.Button();
            this.groupBox14 = new System.Windows.Forms.GroupBox();
            this.label85 = new System.Windows.Forms.Label();
            this.textBoxCAlarm2 = new System.Windows.Forms.TextBox();
            this.textBoxCAlarm1 = new System.Windows.Forms.TextBox();
            this.label86 = new System.Windows.Forms.Label();
            this.label87 = new System.Windows.Forms.Label();
            this.label82 = new System.Windows.Forms.Label();
            this.textBoxBAlarm2 = new System.Windows.Forms.TextBox();
            this.textBoxBAlarm1 = new System.Windows.Forms.TextBox();
            this.label83 = new System.Windows.Forms.Label();
            this.label84 = new System.Windows.Forms.Label();
            this.label81 = new System.Windows.Forms.Label();
            this.textBoxAAlarm2 = new System.Windows.Forms.TextBox();
            this.textBoxAAlarm1 = new System.Windows.Forms.TextBox();
            this.label44 = new System.Windows.Forms.Label();
            this.label45 = new System.Windows.Forms.Label();
            this.btnReadAlarm = new System.Windows.Forms.Button();
            this.btnReadStatus = new System.Windows.Forms.Button();
            this.groupBox26 = new System.Windows.Forms.GroupBox();
            this.label60 = new System.Windows.Forms.Label();
            this.comboBoxParticularPara = new System.Windows.Forms.ComboBox();
            this.textBoxPartiParaValue = new System.Windows.Forms.TextBox();
            this.btnGetParticularPara = new System.Windows.Forms.Button();
            this.btnSetParticularPara = new System.Windows.Forms.Button();
            this.SSS = new System.Windows.Forms.GroupBox();
            this.labelCStandbyStep = new System.Windows.Forms.Label();
            this.labelBStandbyStep = new System.Windows.Forms.Label();
            this.labelAStandbyStep = new System.Windows.Forms.Label();
            this.label74 = new System.Windows.Forms.Label();
            this.txtCFsmStatus = new System.Windows.Forms.TextBox();
            this.label75 = new System.Windows.Forms.Label();
            this.labelCShutDownStep = new System.Windows.Forms.Label();
            this.labelCRunStep = new System.Windows.Forms.Label();
            this.labelCStartStep = new System.Windows.Forms.Label();
            this.labelCIdleStep = new System.Windows.Forms.Label();
            this.lableCInitStep = new System.Windows.Forms.Label();
            this.label67 = new System.Windows.Forms.Label();
            this.txtBFsmStatus = new System.Windows.Forms.TextBox();
            this.label68 = new System.Windows.Forms.Label();
            this.labelBShutDownStep = new System.Windows.Forms.Label();
            this.labelBRunStep = new System.Windows.Forms.Label();
            this.labelBStartStep = new System.Windows.Forms.Label();
            this.labelBIdleStep = new System.Windows.Forms.Label();
            this.lableBInitStep = new System.Windows.Forms.Label();
            this.label58 = new System.Windows.Forms.Label();
            this.txtAFsmStatus = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.labelAShutDownStep = new System.Windows.Forms.Label();
            this.labelARunStep = new System.Windows.Forms.Label();
            this.labelAStartStep = new System.Windows.Forms.Label();
            this.labelAIdleStep = new System.Windows.Forms.Label();
            this.lableAInitStep = new System.Windows.Forms.Label();
            this.groupBox22 = new System.Windows.Forms.GroupBox();
            this.textBoxCfg_Q_CTRL_PF = new System.Windows.Forms.TextBox();
            this.btnCfg_Q_CTRL_PF_R = new System.Windows.Forms.Button();
            this.btnCfg_Q_CTRL_PF_W = new System.Windows.Forms.Button();
            this.groupBox19 = new System.Windows.Forms.GroupBox();
            this.label32 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.txtCSecTemp = new System.Windows.Forms.TextBox();
            this.label34 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.txtCPriTemp = new System.Windows.Forms.TextBox();
            this.groupBox18 = new System.Windows.Forms.GroupBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.txtBSecTemp = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.txtBPriTemp = new System.Windows.Forms.TextBox();
            this.groupBox17 = new System.Windows.Forms.GroupBox();
            this.label37 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.txtASecTemp = new System.Windows.Forms.TextBox();
            this.label39 = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.txtAPriTemp = new System.Windows.Forms.TextBox();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.label46 = new System.Windows.Forms.Label();
            this.textBoxActivePower = new System.Windows.Forms.TextBox();
            this.btnGetActivePower = new System.Windows.Forms.Button();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.btnGetInvMode = new System.Windows.Forms.Button();
            this.btnSetInvMode = new System.Windows.Forms.Button();
            this.radioButtonOffGrid = new System.Windows.Forms.RadioButton();
            this.radioButtonOnGrid = new System.Windows.Forms.RadioButton();
            this.groupBox15 = new System.Windows.Forms.GroupBox();
            this.label48 = new System.Windows.Forms.Label();
            this.textBoxChgDisChgLimitPower = new System.Windows.Forms.TextBox();
            this.btnGetChgDisChgLimitPower = new System.Windows.Forms.Button();
            this.btnSetChgDisChgLimitPower = new System.Windows.Forms.Button();
            this.btnGetPcsTemp = new System.Windows.Forms.Button();
            this.groupBox20 = new System.Windows.Forms.GroupBox();
            this.btnGetTurnOnOff = new System.Windows.Forms.Button();
            this.btnSetTurnOnOff = new System.Windows.Forms.Button();
            this.radioButtonTurnOff = new System.Windows.Forms.RadioButton();
            this.radioButtonTurnOn = new System.Windows.Forms.RadioButton();
            this.groupBox21 = new System.Windows.Forms.GroupBox();
            this.radioButtonRunStateErrStop = new System.Windows.Forms.RadioButton();
            this.btnGetRunState = new System.Windows.Forms.Button();
            this.radioButtonRunStateSleep = new System.Windows.Forms.RadioButton();
            this.radioButtonRunStateStandby = new System.Windows.Forms.RadioButton();
            this.radioButtonRunStateRun = new System.Windows.Forms.RadioButton();
            this.radioButtonRunStateStop = new System.Windows.Forms.RadioButton();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.radioBtnSouthDevProto = new System.Windows.Forms.RadioButton();
            this.btnSelectProtoType = new System.Windows.Forms.Button();
            this.radioBtnCmdProto = new System.Windows.Forms.RadioButton();
            this.radioBtnModbusProto = new System.Windows.Forms.RadioButton();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.comboBoxDatType = new System.Windows.Forms.ComboBox();
            this.btnGenWriteCmd = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.comboBoxDecHex = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.textBoxCmdData = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.textBoxCmd = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.labelProgress = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.progBarUpload = new System.Windows.Forms.ProgressBar();
            this.txtInvSoftVersion = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.cmbFileType = new System.Windows.Forms.ComboBox();
            this.labDeviceType = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.labSlideFrameNum = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.labFrameDatLen = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnLoadFileStart = new System.Windows.Forms.Button();
            this.btnActiveApp = new System.Windows.Forms.Button();
            this.btnLoadFileConsult = new System.Windows.Forms.Button();
            this.btnUpload = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnEnterBackDoor = new System.Windows.Forms.Button();
            this.btnJumpApp = new System.Windows.Forms.Button();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.btnFindFile = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSwitchLoaderOrLoadee = new System.Windows.Forms.Button();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.groupBox25 = new System.Windows.Forms.GroupBox();
            this.label340 = new System.Windows.Forms.Label();
            this.btnTimeSync = new System.Windows.Forms.Button();
            this.label330 = new System.Windows.Forms.Label();
            this.btnLogManualTxtAnalysis = new System.Windows.Forms.Button();
            this.btnExportClear = new System.Windows.Forms.Button();
            this.label59 = new System.Windows.Forms.Label();
            this.comboLogSubfileType = new System.Windows.Forms.ComboBox();
            this.label66 = new System.Windows.Forms.Label();
            this.cmbFileTypeExport = new System.Windows.Forms.ComboBox();
            this.labelExportProgress = new System.Windows.Forms.Label();
            this.progressBarExport = new System.Windows.Forms.ProgressBar();
            this.label61 = new System.Windows.Forms.Label();
            this.label62 = new System.Windows.Forms.Label();
            this.labFileInfo = new System.Windows.Forms.Label();
            this.label63 = new System.Windows.Forms.Label();
            this.chkboxPrintOriginLog = new System.Windows.Forms.CheckBox();
            this.label64 = new System.Windows.Forms.Label();
            this.btnSwitchExporterOrExportee = new System.Windows.Forms.Button();
            this.txtLogFilePath = new System.Windows.Forms.TextBox();
            this.label65 = new System.Windows.Forms.Label();
            this.btnExportEnd = new System.Windows.Forms.Button();
            this.btnFindLogFile = new System.Windows.Forms.Button();
            this.btnExportFileSaveAs = new System.Windows.Forms.Button();
            this.textBoxExport = new System.Windows.Forms.TextBox();
            this.btnExportConsult = new System.Windows.Forms.Button();
            this.btnExportStart = new System.Windows.Forms.Button();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.groupBox37 = new System.Windows.Forms.GroupBox();
            this.groupBox35 = new System.Windows.Forms.GroupBox();
            this.label214 = new System.Windows.Forms.Label();
            this.txtBmsMinVbatIndex = new System.Windows.Forms.TextBox();
            this.label219 = new System.Windows.Forms.Label();
            this.txtBmsMinVbatValue = new System.Windows.Forms.TextBox();
            this.label220 = new System.Windows.Forms.Label();
            this.groupBox38 = new System.Windows.Forms.GroupBox();
            this.label93 = new System.Windows.Forms.Label();
            this.txtBmsMaxVbatIndex = new System.Windows.Forms.TextBox();
            this.label95 = new System.Windows.Forms.Label();
            this.txtBmsMaxVbatValue = new System.Windows.Forms.TextBox();
            this.label218 = new System.Windows.Forms.Label();
            this.label223 = new System.Windows.Forms.Label();
            this.groupBox31 = new System.Windows.Forms.GroupBox();
            this.btnAnalogMonit5sec1hourStartStop = new System.Windows.Forms.Button();
            this.btnBMSAnalogDatSave = new System.Windows.Forms.Button();
            this.btnAnalogDatSave = new System.Windows.Forms.Button();
            this.btnAnalogMonit1sec1minStartStop = new System.Windows.Forms.Button();
            this.btnGetAnalogData = new System.Windows.Forms.Button();
            this.groupBox27 = new System.Windows.Forms.GroupBox();
            this.txtBmsAnalogAlmGroup4 = new System.Windows.Forms.TextBox();
            this.txtBmsAnalogAlmGroup3 = new System.Windows.Forms.TextBox();
            this.label91 = new System.Windows.Forms.Label();
            this.label92 = new System.Windows.Forms.Label();
            this.label89 = new System.Windows.Forms.Label();
            this.label90 = new System.Windows.Forms.Label();
            this.txtBmsAnalogSOE = new System.Windows.Forms.TextBox();
            this.label78 = new System.Windows.Forms.Label();
            this.label79 = new System.Windows.Forms.Label();
            this.txtBmsAnalogSOP_discharge = new System.Windows.Forms.TextBox();
            this.label80 = new System.Windows.Forms.Label();
            this.label88 = new System.Windows.Forms.Label();
            this.txtBmsAnalogSOP_charge = new System.Windows.Forms.TextBox();
            this.label70 = new System.Windows.Forms.Label();
            this.label73 = new System.Windows.Forms.Label();
            this.txtBmsAnalogSOH = new System.Windows.Forms.TextBox();
            this.label76 = new System.Windows.Forms.Label();
            this.label77 = new System.Windows.Forms.Label();
            this.txtBmsAnalogSOC = new System.Windows.Forms.TextBox();
            this.label55 = new System.Windows.Forms.Label();
            this.label56 = new System.Windows.Forms.Label();
            this.txtBmsAnalog12V = new System.Windows.Forms.TextBox();
            this.label53 = new System.Windows.Forms.Label();
            this.label54 = new System.Windows.Forms.Label();
            this.txtBmsAnalogUbatPos = new System.Windows.Forms.TextBox();
            this.label176 = new System.Windows.Forms.Label();
            this.label177 = new System.Windows.Forms.Label();
            this.txtBmsAnalogBat30V = new System.Windows.Forms.TextBox();
            this.txtBmsAnalogAlmGroup2 = new System.Windows.Forms.TextBox();
            this.txtBmsAnalogAlmGroup1 = new System.Windows.Forms.TextBox();
            this.label160 = new System.Windows.Forms.Label();
            this.label161 = new System.Windows.Forms.Label();
            this.label146 = new System.Windows.Forms.Label();
            this.label186 = new System.Windows.Forms.Label();
            this.label188 = new System.Windows.Forms.Label();
            this.txtBmsAnalogVbat8 = new System.Windows.Forms.TextBox();
            this.label198 = new System.Windows.Forms.Label();
            this.label199 = new System.Windows.Forms.Label();
            this.txtBmsAnalogTbat8 = new System.Windows.Forms.TextBox();
            this.label200 = new System.Windows.Forms.Label();
            this.label201 = new System.Windows.Forms.Label();
            this.txtBmsAnalogVbat7 = new System.Windows.Forms.TextBox();
            this.label202 = new System.Windows.Forms.Label();
            this.label203 = new System.Windows.Forms.Label();
            this.txtBmsAnalogTbat7 = new System.Windows.Forms.TextBox();
            this.label204 = new System.Windows.Forms.Label();
            this.label205 = new System.Windows.Forms.Label();
            this.txtBmsAnalogVbat6 = new System.Windows.Forms.TextBox();
            this.label206 = new System.Windows.Forms.Label();
            this.label207 = new System.Windows.Forms.Label();
            this.txtBmsAnalogTbat6 = new System.Windows.Forms.TextBox();
            this.label208 = new System.Windows.Forms.Label();
            this.label209 = new System.Windows.Forms.Label();
            this.txtBmsAnalogVbat5 = new System.Windows.Forms.TextBox();
            this.label210 = new System.Windows.Forms.Label();
            this.label211 = new System.Windows.Forms.Label();
            this.txtBmsAnalogTbat5 = new System.Windows.Forms.TextBox();
            this.label178 = new System.Windows.Forms.Label();
            this.label179 = new System.Windows.Forms.Label();
            this.txtBmsAnalogAc30V = new System.Windows.Forms.TextBox();
            this.label180 = new System.Windows.Forms.Label();
            this.label181 = new System.Windows.Forms.Label();
            this.txtBmsAnalogTblncingr = new System.Windows.Forms.TextBox();
            this.label182 = new System.Windows.Forms.Label();
            this.label183 = new System.Windows.Forms.Label();
            this.txtBmsAnalogTboard = new System.Windows.Forms.TextBox();
            this.label184 = new System.Windows.Forms.Label();
            this.label185 = new System.Windows.Forms.Label();
            this.txtBmsAnalogTterminal2 = new System.Windows.Forms.TextBox();
            this.label187 = new System.Windows.Forms.Label();
            this.label189 = new System.Windows.Forms.Label();
            this.txtBmsAnalogTterminal1 = new System.Windows.Forms.TextBox();
            this.label190 = new System.Windows.Forms.Label();
            this.label191 = new System.Windows.Forms.Label();
            this.label192 = new System.Windows.Forms.Label();
            this.label193 = new System.Windows.Forms.Label();
            this.txtBmsAnalog3V3 = new System.Windows.Forms.TextBox();
            this.txtBmsAnalogISR = new System.Windows.Forms.TextBox();
            this.label194 = new System.Windows.Forms.Label();
            this.label195 = new System.Windows.Forms.Label();
            this.label196 = new System.Windows.Forms.Label();
            this.txtBmsAnalog30V = new System.Windows.Forms.TextBox();
            this.label197 = new System.Windows.Forms.Label();
            this.txtBmsAnalogIbat = new System.Windows.Forms.TextBox();
            this.label144 = new System.Windows.Forms.Label();
            this.label145 = new System.Windows.Forms.Label();
            this.txtBmsAnalogVbat4 = new System.Windows.Forms.TextBox();
            this.label147 = new System.Windows.Forms.Label();
            this.txtBmsAnalogTbat4 = new System.Windows.Forms.TextBox();
            this.label148 = new System.Windows.Forms.Label();
            this.label149 = new System.Windows.Forms.Label();
            this.txtBmsAnalogVbat3 = new System.Windows.Forms.TextBox();
            this.label150 = new System.Windows.Forms.Label();
            this.label151 = new System.Windows.Forms.Label();
            this.txtBmsAnalogTbat3 = new System.Windows.Forms.TextBox();
            this.label152 = new System.Windows.Forms.Label();
            this.label153 = new System.Windows.Forms.Label();
            this.txtBmsAnalogVbat2 = new System.Windows.Forms.TextBox();
            this.label154 = new System.Windows.Forms.Label();
            this.label155 = new System.Windows.Forms.Label();
            this.txtBmsAnalogTbat2 = new System.Windows.Forms.TextBox();
            this.label156 = new System.Windows.Forms.Label();
            this.label157 = new System.Windows.Forms.Label();
            this.txtBmsAnalogVbat1 = new System.Windows.Forms.TextBox();
            this.label158 = new System.Windows.Forms.Label();
            this.label159 = new System.Windows.Forms.Label();
            this.txtBmsAnalogTbat1 = new System.Windows.Forms.TextBox();
            this.groupBox13 = new System.Windows.Forms.GroupBox();
            this.groupBox32 = new System.Windows.Forms.GroupBox();
            this.label337 = new System.Windows.Forms.Label();
            this.txtCAnalogExternalFan2State = new System.Windows.Forms.TextBox();
            this.label338 = new System.Windows.Forms.Label();
            this.txtCAnalogExternalFan1State = new System.Windows.Forms.TextBox();
            this.label339 = new System.Windows.Forms.Label();
            this.txtCAnalogInternalFanState = new System.Windows.Forms.TextBox();
            this.label51 = new System.Windows.Forms.Label();
            this.label174 = new System.Windows.Forms.Label();
            this.label52 = new System.Windows.Forms.Label();
            this.txtCAnalogGridFreq = new System.Windows.Forms.TextBox();
            this.label175 = new System.Windows.Forms.Label();
            this.txtCAnalogQout = new System.Windows.Forms.TextBox();
            this.label212 = new System.Windows.Forms.Label();
            this.label213 = new System.Windows.Forms.Label();
            this.txtCAnalogPout = new System.Windows.Forms.TextBox();
            this.label128 = new System.Windows.Forms.Label();
            this.label129 = new System.Windows.Forms.Label();
            this.txtCAnalog10V = new System.Windows.Forms.TextBox();
            this.label130 = new System.Windows.Forms.Label();
            this.label131 = new System.Windows.Forms.Label();
            this.txtCAnalogDci = new System.Windows.Forms.TextBox();
            this.label132 = new System.Windows.Forms.Label();
            this.label133 = new System.Windows.Forms.Label();
            this.txtCAnalogSecTemp = new System.Windows.Forms.TextBox();
            this.label134 = new System.Windows.Forms.Label();
            this.label135 = new System.Windows.Forms.Label();
            this.txtCAnalogPriTemp = new System.Windows.Forms.TextBox();
            this.label136 = new System.Windows.Forms.Label();
            this.label137 = new System.Windows.Forms.Label();
            this.txtCAnalogVbat = new System.Windows.Forms.TextBox();
            this.label138 = new System.Windows.Forms.Label();
            this.label139 = new System.Windows.Forms.Label();
            this.txtCAnalogIgrid = new System.Windows.Forms.TextBox();
            this.label140 = new System.Windows.Forms.Label();
            this.label141 = new System.Windows.Forms.Label();
            this.txtCAnalogPowerVgrid = new System.Windows.Forms.TextBox();
            this.label142 = new System.Windows.Forms.Label();
            this.label143 = new System.Windows.Forms.Label();
            this.txtCAnalogVgrid = new System.Windows.Forms.TextBox();
            this.groupBox29 = new System.Windows.Forms.GroupBox();
            this.label332 = new System.Windows.Forms.Label();
            this.txtBAnalogExternalFan2State = new System.Windows.Forms.TextBox();
            this.label334 = new System.Windows.Forms.Label();
            this.txtBAnalogExternalFan1State = new System.Windows.Forms.TextBox();
            this.label336 = new System.Windows.Forms.Label();
            this.txtBAnalogInternalFanState = new System.Windows.Forms.TextBox();
            this.label36 = new System.Windows.Forms.Label();
            this.label170 = new System.Windows.Forms.Label();
            this.label47 = new System.Windows.Forms.Label();
            this.txtBAnalogGridFreq = new System.Windows.Forms.TextBox();
            this.label171 = new System.Windows.Forms.Label();
            this.txtBAnalogQout = new System.Windows.Forms.TextBox();
            this.label172 = new System.Windows.Forms.Label();
            this.label173 = new System.Windows.Forms.Label();
            this.txtBAnalogPout = new System.Windows.Forms.TextBox();
            this.label112 = new System.Windows.Forms.Label();
            this.label113 = new System.Windows.Forms.Label();
            this.txtBAnalog10V = new System.Windows.Forms.TextBox();
            this.label114 = new System.Windows.Forms.Label();
            this.label115 = new System.Windows.Forms.Label();
            this.txtBAnalogDci = new System.Windows.Forms.TextBox();
            this.label116 = new System.Windows.Forms.Label();
            this.label117 = new System.Windows.Forms.Label();
            this.txtBAnalogSecTemp = new System.Windows.Forms.TextBox();
            this.label118 = new System.Windows.Forms.Label();
            this.label119 = new System.Windows.Forms.Label();
            this.txtBAnalogPriTemp = new System.Windows.Forms.TextBox();
            this.label120 = new System.Windows.Forms.Label();
            this.label121 = new System.Windows.Forms.Label();
            this.txtBAnalogVbat = new System.Windows.Forms.TextBox();
            this.label122 = new System.Windows.Forms.Label();
            this.label123 = new System.Windows.Forms.Label();
            this.txtBAnalogIgrid = new System.Windows.Forms.TextBox();
            this.label124 = new System.Windows.Forms.Label();
            this.label125 = new System.Windows.Forms.Label();
            this.txtBAnalogPowerVgrid = new System.Windows.Forms.TextBox();
            this.label126 = new System.Windows.Forms.Label();
            this.label127 = new System.Windows.Forms.Label();
            this.txtBAnalogVgrid = new System.Windows.Forms.TextBox();
            this.groupBox28 = new System.Windows.Forms.GroupBox();
            this.label335 = new System.Windows.Forms.Label();
            this.txtAAnalogExternalFan2State = new System.Windows.Forms.TextBox();
            this.label331 = new System.Windows.Forms.Label();
            this.txtAAnalogExternalFan1State = new System.Windows.Forms.TextBox();
            this.label333 = new System.Windows.Forms.Label();
            this.txtAAnalogInternalFanState = new System.Windows.Forms.TextBox();
            this.label31 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.txtAAnalogGridFreq = new System.Windows.Forms.TextBox();
            this.label166 = new System.Windows.Forms.Label();
            this.label167 = new System.Windows.Forms.Label();
            this.txtAAnalogQout = new System.Windows.Forms.TextBox();
            this.label168 = new System.Windows.Forms.Label();
            this.label169 = new System.Windows.Forms.Label();
            this.txtAAnalogPout = new System.Windows.Forms.TextBox();
            this.label96 = new System.Windows.Forms.Label();
            this.label97 = new System.Windows.Forms.Label();
            this.txtAAnalog10V = new System.Windows.Forms.TextBox();
            this.label98 = new System.Windows.Forms.Label();
            this.label99 = new System.Windows.Forms.Label();
            this.txtAAnalogDci = new System.Windows.Forms.TextBox();
            this.label100 = new System.Windows.Forms.Label();
            this.label101 = new System.Windows.Forms.Label();
            this.txtAAnalogSecTemp = new System.Windows.Forms.TextBox();
            this.label102 = new System.Windows.Forms.Label();
            this.label103 = new System.Windows.Forms.Label();
            this.txtAAnalogPriTemp = new System.Windows.Forms.TextBox();
            this.label104 = new System.Windows.Forms.Label();
            this.label105 = new System.Windows.Forms.Label();
            this.txtAAnalogVbat = new System.Windows.Forms.TextBox();
            this.label106 = new System.Windows.Forms.Label();
            this.label107 = new System.Windows.Forms.Label();
            this.txtAAnalogIgrid = new System.Windows.Forms.TextBox();
            this.label108 = new System.Windows.Forms.Label();
            this.label109 = new System.Windows.Forms.Label();
            this.txtAAnalogPowerVgrid = new System.Windows.Forms.TextBox();
            this.label110 = new System.Windows.Forms.Label();
            this.label111 = new System.Windows.Forms.Label();
            this.txtAAnalogVgrid = new System.Windows.Forms.TextBox();
            this.groupBox30 = new System.Windows.Forms.GroupBox();
            this.chkboxAnalogDataBms = new System.Windows.Forms.CheckBox();
            this.chkboxAnalogDataPcs = new System.Windows.Forms.CheckBox();
            this.tabPage8 = new System.Windows.Forms.TabPage();
            this.groupBox39 = new System.Windows.Forms.GroupBox();
            this.btnBmsResetCalibratorParaCmd = new System.Windows.Forms.Button();
            this.label279 = new System.Windows.Forms.Label();
            this.label262 = new System.Windows.Forms.Label();
            this.label261 = new System.Windows.Forms.Label();
            this.label260 = new System.Windows.Forms.Label();
            this.label259 = new System.Windows.Forms.Label();
            this.label258 = new System.Windows.Forms.Label();
            this.label257 = new System.Windows.Forms.Label();
            this.label256 = new System.Windows.Forms.Label();
            this.label235 = new System.Windows.Forms.Label();
            this.label250 = new System.Windows.Forms.Label();
            this.txtBmsDischgCurr4_Z4 = new System.Windows.Forms.TextBox();
            this.label251 = new System.Windows.Forms.Label();
            this.txtBmsDischgCurr3_Z3 = new System.Windows.Forms.TextBox();
            this.label252 = new System.Windows.Forms.Label();
            this.txtBmsDischgCurr2_Z2 = new System.Windows.Forms.TextBox();
            this.label253 = new System.Windows.Forms.Label();
            this.txtBmsDischgCurr1_Z1 = new System.Windows.Forms.TextBox();
            this.label254 = new System.Windows.Forms.Label();
            this.txtBmsChgCurr4_Z4 = new System.Windows.Forms.TextBox();
            this.label255 = new System.Windows.Forms.Label();
            this.txtBmsChgCurr3_Z3 = new System.Windows.Forms.TextBox();
            this.btnBmsReadCalibratorParaCmd = new System.Windows.Forms.Button();
            this.label229 = new System.Windows.Forms.Label();
            this.txtBmsCalibratorParaDischgB1 = new System.Windows.Forms.TextBox();
            this.label231 = new System.Windows.Forms.Label();
            this.txtBmsCalibratorParaDischgK1 = new System.Windows.Forms.TextBox();
            this.label233 = new System.Windows.Forms.Label();
            this.txtBmsChgCurr2_Z2 = new System.Windows.Forms.TextBox();
            this.txtBmsChgCurr1_Z1 = new System.Windows.Forms.TextBox();
            this.label237 = new System.Windows.Forms.Label();
            this.txtBmsCalibratorParaDischgB3 = new System.Windows.Forms.TextBox();
            this.label239 = new System.Windows.Forms.Label();
            this.txtBmsCalibratorParaDischgK3 = new System.Windows.Forms.TextBox();
            this.label240 = new System.Windows.Forms.Label();
            this.txtBmsCalibratorParaDischgB2 = new System.Windows.Forms.TextBox();
            this.label241 = new System.Windows.Forms.Label();
            this.txtBmsCalibratorParaDischgK2 = new System.Windows.Forms.TextBox();
            this.label242 = new System.Windows.Forms.Label();
            this.txtBmsCalibratorParaChgB0 = new System.Windows.Forms.TextBox();
            this.label243 = new System.Windows.Forms.Label();
            this.txtBmsCalibratorParaChgK0 = new System.Windows.Forms.TextBox();
            this.label244 = new System.Windows.Forms.Label();
            this.txtBmsCalibratorParaChgB3 = new System.Windows.Forms.TextBox();
            this.label245 = new System.Windows.Forms.Label();
            this.txtBmsCalibratorParaChgK3 = new System.Windows.Forms.TextBox();
            this.label246 = new System.Windows.Forms.Label();
            this.txtBmsCalibratorParaChgB2 = new System.Windows.Forms.TextBox();
            this.label247 = new System.Windows.Forms.Label();
            this.txtBmsCalibratorParaChgK2 = new System.Windows.Forms.TextBox();
            this.label248 = new System.Windows.Forms.Label();
            this.txtBmsCalibratorParaChgB1 = new System.Windows.Forms.TextBox();
            this.label249 = new System.Windows.Forms.Label();
            this.txtBmsCalibratorParaChgK1 = new System.Windows.Forms.TextBox();
            this.groupBox36 = new System.Windows.Forms.GroupBox();
            this.label271 = new System.Windows.Forms.Label();
            this.label272 = new System.Windows.Forms.Label();
            this.label273 = new System.Windows.Forms.Label();
            this.label274 = new System.Windows.Forms.Label();
            this.label275 = new System.Windows.Forms.Label();
            this.label276 = new System.Windows.Forms.Label();
            this.label277 = new System.Windows.Forms.Label();
            this.label278 = new System.Windows.Forms.Label();
            this.label263 = new System.Windows.Forms.Label();
            this.label264 = new System.Windows.Forms.Label();
            this.label265 = new System.Windows.Forms.Label();
            this.label266 = new System.Windows.Forms.Label();
            this.label267 = new System.Windows.Forms.Label();
            this.label268 = new System.Windows.Forms.Label();
            this.label269 = new System.Windows.Forms.Label();
            this.label270 = new System.Windows.Forms.Label();
            this.btnBmsSetCalibrateCurrSamplingInputCmd = new System.Windows.Forms.Button();
            this.label94 = new System.Windows.Forms.Label();
            this.txtBmsPowerAnalysisSamplDischgData1 = new System.Windows.Forms.TextBox();
            this.label215 = new System.Windows.Forms.Label();
            this.txtBmsSamplingDischgData1 = new System.Windows.Forms.TextBox();
            this.label217 = new System.Windows.Forms.Label();
            this.txtBmsPowerAnalysisSamplDischgData4 = new System.Windows.Forms.TextBox();
            this.label222 = new System.Windows.Forms.Label();
            this.txtBmsSamplingDischgData4 = new System.Windows.Forms.TextBox();
            this.label224 = new System.Windows.Forms.Label();
            this.txtBmsPowerAnalysisSamplDischgData3 = new System.Windows.Forms.TextBox();
            this.label225 = new System.Windows.Forms.Label();
            this.txtBmsSamplingDischgData3 = new System.Windows.Forms.TextBox();
            this.label226 = new System.Windows.Forms.Label();
            this.txtBmsPowerAnalysisSamplDischgData2 = new System.Windows.Forms.TextBox();
            this.label227 = new System.Windows.Forms.Label();
            this.txtBmsSamplingDischgData2 = new System.Windows.Forms.TextBox();
            this.label216 = new System.Windows.Forms.Label();
            this.txtBmsPowerAnalysisSamplChgData1 = new System.Windows.Forms.TextBox();
            this.label221 = new System.Windows.Forms.Label();
            this.txtBmsSamplingChgData1 = new System.Windows.Forms.TextBox();
            this.label228 = new System.Windows.Forms.Label();
            this.txtBmsPowerAnalysisSamplChgData4 = new System.Windows.Forms.TextBox();
            this.label230 = new System.Windows.Forms.Label();
            this.txtBmsSamplingChgData4 = new System.Windows.Forms.TextBox();
            this.label232 = new System.Windows.Forms.Label();
            this.txtBmsPowerAnalysisSamplChgData3 = new System.Windows.Forms.TextBox();
            this.label234 = new System.Windows.Forms.Label();
            this.txtBmsSamplingChgData3 = new System.Windows.Forms.TextBox();
            this.label236 = new System.Windows.Forms.Label();
            this.txtBmsPowerAnalysisSamplChgData2 = new System.Windows.Forms.TextBox();
            this.label238 = new System.Windows.Forms.Label();
            this.txtBmsSamplingChgData2 = new System.Windows.Forms.TextBox();
            this.groupBox24 = new System.Windows.Forms.GroupBox();
            this.groupBox42 = new System.Windows.Forms.GroupBox();
            this.btnBmsHeartBeat = new System.Windows.Forms.Button();
            this.groupBox41 = new System.Windows.Forms.GroupBox();
            this.btnBmsSetChgReverseCompensationParamCmd = new System.Windows.Forms.Button();
            this.txtBmsChgReverseCompensationParam = new System.Windows.Forms.TextBox();
            this.label283 = new System.Windows.Forms.Label();
            this.groupBox33 = new System.Windows.Forms.GroupBox();
            this.label165 = new System.Windows.Forms.Label();
            this.label164 = new System.Windows.Forms.Label();
            this.textBoxBmsCPhaseChgDisChgPower = new System.Windows.Forms.TextBox();
            this.label163 = new System.Windows.Forms.Label();
            this.textBoxBmsBPhaseChgDisChgPower = new System.Windows.Forms.TextBox();
            this.label162 = new System.Windows.Forms.Label();
            this.textBoxBmsAPhaseChgDisChgPower = new System.Windows.Forms.TextBox();
            this.btnBmsSetThreeChapseChgDischgCmd = new System.Windows.Forms.Button();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.btnBmsTurnOffCmd = new System.Windows.Forms.Button();
            this.btnBmsResetCmd = new System.Windows.Forms.Button();
            this.btnBmsTurnOnCmd = new System.Windows.Forms.Button();
            this.tabPage9 = new System.Windows.Forms.TabPage();
            this.groupBox57 = new System.Windows.Forms.GroupBox();
            this.btnGetBkpAlmDataOnOffGridStateData = new System.Windows.Forms.Button();
            this.label357 = new System.Windows.Forms.Label();
            this.txtBkpIsAlmState = new System.Windows.Forms.TextBox();
            this.txtBkpIsAlmData = new System.Windows.Forms.TextBox();
            this.label360 = new System.Windows.Forms.Label();
            this.label392 = new System.Windows.Forms.Label();
            this.txtBkpOnOffGridState = new System.Windows.Forms.TextBox();
            this.groupBox53 = new System.Windows.Forms.GroupBox();
            this.groupBox56 = new System.Windows.Forms.GroupBox();
            this.radioBtnBkpFanTurnOff = new System.Windows.Forms.RadioButton();
            this.radioBtnBkpFanTurnOn = new System.Windows.Forms.RadioButton();
            this.btnBkpSetFanTurnOnOff = new System.Windows.Forms.Button();
            this.groupBox49 = new System.Windows.Forms.GroupBox();
            this.groupBox58 = new System.Windows.Forms.GroupBox();
            this.label342 = new System.Windows.Forms.Label();
            this.radioBtnBkpDo4LowLevel = new System.Windows.Forms.RadioButton();
            this.radioBtnBkpDo4HighLevel = new System.Windows.Forms.RadioButton();
            this.groupBox52 = new System.Windows.Forms.GroupBox();
            this.label324 = new System.Windows.Forms.Label();
            this.radioBtnBkpDo3LowLevel = new System.Windows.Forms.RadioButton();
            this.radioBtnBkpDo3HighLevel = new System.Windows.Forms.RadioButton();
            this.groupBox51 = new System.Windows.Forms.GroupBox();
            this.label322 = new System.Windows.Forms.Label();
            this.radioBtnBkpDo2LowLevel = new System.Windows.Forms.RadioButton();
            this.radioBtnBkpDo2HighLevel = new System.Windows.Forms.RadioButton();
            this.groupBox50 = new System.Windows.Forms.GroupBox();
            this.label329 = new System.Windows.Forms.Label();
            this.radioBtnBkpDo1LowLevel = new System.Windows.Forms.RadioButton();
            this.radioBtnBkpDo1HighLevel = new System.Windows.Forms.RadioButton();
            this.btnBkpSetMultiDoPara = new System.Windows.Forms.Button();
            this.groupBox45 = new System.Windows.Forms.GroupBox();
            this.btnGetBkpTestdata = new System.Windows.Forms.Button();
            this.groupBox47 = new System.Windows.Forms.GroupBox();
            this.label323 = new System.Windows.Forms.Label();
            this.txtBkpHardVer = new System.Windows.Forms.TextBox();
            this.txtBkpPhaseNum = new System.Windows.Forms.TextBox();
            this.label321 = new System.Windows.Forms.Label();
            this.groupBox48 = new System.Windows.Forms.GroupBox();
            this.label317 = new System.Windows.Forms.Label();
            this.txtBkpUn2pe = new System.Windows.Forms.TextBox();
            this.label319 = new System.Windows.Forms.Label();
            this.txtBkpU12v = new System.Windows.Forms.TextBox();
            this.label305 = new System.Windows.Forms.Label();
            this.label303 = new System.Windows.Forms.Label();
            this.groupBox46 = new System.Windows.Forms.GroupBox();
            this.label310 = new System.Windows.Forms.Label();
            this.label311 = new System.Windows.Forms.Label();
            this.txtBkpBphaseUg = new System.Windows.Forms.TextBox();
            this.txtBkpAphaseUg = new System.Windows.Forms.TextBox();
            this.label309 = new System.Windows.Forms.Label();
            this.label308 = new System.Windows.Forms.Label();
            this.txtBkpCphaseUg = new System.Windows.Forms.TextBox();
            this.label307 = new System.Windows.Forms.Label();
            this.txtBkpCphaseUout = new System.Windows.Forms.TextBox();
            this.label306 = new System.Windows.Forms.Label();
            this.label313 = new System.Windows.Forms.Label();
            this.label312 = new System.Windows.Forms.Label();
            this.label292 = new System.Windows.Forms.Label();
            this.txtBkpAphaseUout = new System.Windows.Forms.TextBox();
            this.label293 = new System.Windows.Forms.Label();
            this.label297 = new System.Windows.Forms.Label();
            this.txtBkpBphaseUdiff = new System.Windows.Forms.TextBox();
            this.label296 = new System.Windows.Forms.Label();
            this.label298 = new System.Windows.Forms.Label();
            this.txtBkpBphaseUout = new System.Windows.Forms.TextBox();
            this.label299 = new System.Windows.Forms.Label();
            this.label295 = new System.Windows.Forms.Label();
            this.txtBkpAphaseUdiff = new System.Windows.Forms.TextBox();
            this.label294 = new System.Windows.Forms.Label();
            this.label300 = new System.Windows.Forms.Label();
            this.txtBkpCphaseUdiff = new System.Windows.Forms.TextBox();
            this.label301 = new System.Windows.Forms.Label();
            this.groupBox44 = new System.Windows.Forms.GroupBox();
            this.txtBkpDo4State = new System.Windows.Forms.TextBox();
            this.label341 = new System.Windows.Forms.Label();
            this.label318 = new System.Windows.Forms.Label();
            this.txtBkpDo2State = new System.Windows.Forms.TextBox();
            this.label320 = new System.Windows.Forms.Label();
            this.txtBkpDo1State = new System.Windows.Forms.TextBox();
            this.txtBkpDI2State = new System.Windows.Forms.TextBox();
            this.label316 = new System.Windows.Forms.Label();
            this.txtBkpDo3State = new System.Windows.Forms.TextBox();
            this.label304 = new System.Windows.Forms.Label();
            this.txtBkpDI1State = new System.Windows.Forms.TextBox();
            this.label302 = new System.Windows.Forms.Label();
            this.groupBox43 = new System.Windows.Forms.GroupBox();
            this.txtBkptTempTrans = new System.Windows.Forms.TextBox();
            this.label326 = new System.Windows.Forms.Label();
            this.label327 = new System.Windows.Forms.Label();
            this.label290 = new System.Windows.Forms.Label();
            this.txtBkptTempBCrly = new System.Windows.Forms.TextBox();
            this.label289 = new System.Windows.Forms.Label();
            this.label291 = new System.Windows.Forms.Label();
            this.txtBkptTempEnv = new System.Windows.Forms.TextBox();
            this.txtBkptTempANrly = new System.Windows.Forms.TextBox();
            this.label315 = new System.Windows.Forms.Label();
            this.label49 = new System.Windows.Forms.Label();
            this.label314 = new System.Windows.Forms.Label();
            this.tabPage10 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox60 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.VarName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VarAddr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VarType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ReadValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WriteValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VarSelect = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.groupBox61 = new System.Windows.Forms.GroupBox();
            this.btnClearVars = new System.Windows.Forms.Button();
            this.btnSetVarParam = new System.Windows.Forms.Button();
            this.btnVarSelect = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.rdioBtnDaqRead = new System.Windows.Forms.RadioButton();
            this.rdioBtnPollingRead = new System.Windows.Forms.RadioButton();
            this.rdioBtnReadSingle = new System.Windows.Forms.RadioButton();
            this.label344 = new System.Windows.Forms.Label();
            this.textBoxReadPeriod = new System.Windows.Forms.TextBox();
            this.btnReadVar = new System.Windows.Forms.Button();
            this.textBoxMapDir = new System.Windows.Forms.TextBox();
            this.label343 = new System.Windows.Forms.Label();
            this.btnOpenMap = new System.Windows.Forms.Button();
            this.groupBox66 = new System.Windows.Forms.GroupBox();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.timerAnalogMonit = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox55.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBoxUartCfg.SuspendLayout();
            this.groupBoxPlcDstCfg.SuspendLayout();
            this.groupBoxPlcTstBrdCfg.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBoxCanSendCfg.SuspendLayout();
            this.groupBoxCanCfg.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox23.SuspendLayout();
            this.groupBox16.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.groupBox63.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.groupBox62.SuspendLayout();
            this.tableLayoutPanel8.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTrigPos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDnVrtZoomCh1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDnVrtZoomCh2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDnVrtZoomCh3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDnVrtZoomCh4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDnVrtOffsetCh1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDnVrtOffsetCh2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDnVrtOffsetCh3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDnVrtOffsetCh4)).BeginInit();
            this.tableLayoutPanel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDnSampleFreqOrigin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDnSampleDiv)).BeginInit();
            this.groupBox54.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textBoxCh1TrigVal)).BeginInit();
            this.tableLayoutPanel10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WaveChart)).BeginInit();
            this.tableLayoutPanel11.SuspendLayout();
            this.groupBox67.SuspendLayout();
            this.tableLayoutPanel14.SuspendLayout();
            this.groupBox68.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox59.SuspendLayout();
            this.groupBox40.SuspendLayout();
            this.groupBox34.SuspendLayout();
            this.groupBox14.SuspendLayout();
            this.groupBox26.SuspendLayout();
            this.SSS.SuspendLayout();
            this.groupBox22.SuspendLayout();
            this.groupBox19.SuspendLayout();
            this.groupBox18.SuspendLayout();
            this.groupBox17.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.groupBox12.SuspendLayout();
            this.groupBox15.SuspendLayout();
            this.groupBox20.SuspendLayout();
            this.groupBox21.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.groupBox25.SuspendLayout();
            this.tabPage7.SuspendLayout();
            this.groupBox37.SuspendLayout();
            this.groupBox35.SuspendLayout();
            this.groupBox38.SuspendLayout();
            this.groupBox31.SuspendLayout();
            this.groupBox27.SuspendLayout();
            this.groupBox13.SuspendLayout();
            this.groupBox32.SuspendLayout();
            this.groupBox29.SuspendLayout();
            this.groupBox28.SuspendLayout();
            this.groupBox30.SuspendLayout();
            this.tabPage8.SuspendLayout();
            this.groupBox39.SuspendLayout();
            this.groupBox36.SuspendLayout();
            this.groupBox24.SuspendLayout();
            this.groupBox42.SuspendLayout();
            this.groupBox41.SuspendLayout();
            this.groupBox33.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.tabPage9.SuspendLayout();
            this.groupBox57.SuspendLayout();
            this.groupBox53.SuspendLayout();
            this.groupBox56.SuspendLayout();
            this.groupBox49.SuspendLayout();
            this.groupBox58.SuspendLayout();
            this.groupBox52.SuspendLayout();
            this.groupBox51.SuspendLayout();
            this.groupBox50.SuspendLayout();
            this.groupBox45.SuspendLayout();
            this.groupBox47.SuspendLayout();
            this.groupBox48.SuspendLayout();
            this.groupBox46.SuspendLayout();
            this.groupBox44.SuspendLayout();
            this.groupBox43.SuspendLayout();
            this.tabPage10.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox60.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox61.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.tabControl1);
            this.groupBox1.Controls.Add(this.groupBox7);
            this.groupBox1.Controls.Add(this.groupBox23);
            this.groupBox1.Controls.Add(this.groupBox16);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(469, 765);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "通信配置";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox55);
            this.groupBox2.Controls.Add(this.labelCPcsSoftwareVer);
            this.groupBox2.Controls.Add(this.labelBPcsSoftwareVer);
            this.groupBox2.Controls.Add(this.labelAPcsSoftwareVer);
            this.groupBox2.Controls.Add(this.btnGetPcsSoftwareVer);
            this.groupBox2.Controls.Add(this.label57);
            this.groupBox2.Controls.Add(this.txtReceivedData);
            this.groupBox2.Location = new System.Drawing.Point(10, 448);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(453, 310);
            this.groupBox2.TabIndex = 70;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "收发调试";
            // 
            // groupBox55
            // 
            this.groupBox55.Controls.Add(this.btnPeriodSend);
            this.groupBox55.Controls.Add(this.button_clear);
            this.groupBox55.Controls.Add(this.textBoxSendPeriod);
            this.groupBox55.Controls.Add(this.btnCmdRecordFileSaveAs);
            this.groupBox55.Controls.Add(this.chkBoxHexSend);
            this.groupBox55.Controls.Add(this.checkBoxShowSend);
            this.groupBox55.Controls.Add(this.chkBoxHexShow);
            this.groupBox55.Controls.Add(this.checkBoxShowRecv);
            this.groupBox55.Location = new System.Drawing.Point(6, 254);
            this.groupBox55.Name = "groupBox55";
            this.groupBox55.Size = new System.Drawing.Size(444, 51);
            this.groupBox55.TabIndex = 356;
            this.groupBox55.TabStop = false;
            // 
            // btnPeriodSend
            // 
            this.btnPeriodSend.Location = new System.Drawing.Point(288, 20);
            this.btnPeriodSend.Name = "btnPeriodSend";
            this.btnPeriodSend.Size = new System.Drawing.Size(72, 23);
            this.btnPeriodSend.TabIndex = 89;
            this.btnPeriodSend.Text = "定时发送";
            this.btnPeriodSend.UseVisualStyleBackColor = true;
            // 
            // button_clear
            // 
            this.button_clear.Location = new System.Drawing.Point(0, 12);
            this.button_clear.Name = "button_clear";
            this.button_clear.Size = new System.Drawing.Size(72, 34);
            this.button_clear.TabIndex = 82;
            this.button_clear.Text = "清空";
            this.button_clear.UseVisualStyleBackColor = true;
            // 
            // textBoxSendPeriod
            // 
            this.textBoxSendPeriod.Location = new System.Drawing.Point(228, 20);
            this.textBoxSendPeriod.Name = "textBoxSendPeriod";
            this.textBoxSendPeriod.Size = new System.Drawing.Size(57, 21);
            this.textBoxSendPeriod.TabIndex = 88;
            this.textBoxSendPeriod.Text = "1000";
            // 
            // btnCmdRecordFileSaveAs
            // 
            this.btnCmdRecordFileSaveAs.Location = new System.Drawing.Point(366, 11);
            this.btnCmdRecordFileSaveAs.Name = "btnCmdRecordFileSaveAs";
            this.btnCmdRecordFileSaveAs.Size = new System.Drawing.Size(74, 35);
            this.btnCmdRecordFileSaveAs.TabIndex = 83;
            this.btnCmdRecordFileSaveAs.Text = "记录另存为";
            this.btnCmdRecordFileSaveAs.UseVisualStyleBackColor = true;
            // 
            // chkBoxHexSend
            // 
            this.chkBoxHexSend.AutoSize = true;
            this.chkBoxHexSend.Checked = true;
            this.chkBoxHexSend.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBoxHexSend.Location = new System.Drawing.Point(156, 31);
            this.chkBoxHexSend.Name = "chkBoxHexSend";
            this.chkBoxHexSend.Size = new System.Drawing.Size(66, 16);
            this.chkBoxHexSend.TabIndex = 87;
            this.chkBoxHexSend.Text = "Hex发送";
            this.chkBoxHexSend.UseVisualStyleBackColor = true;
            // 
            // checkBoxShowSend
            // 
            this.checkBoxShowSend.AutoSize = true;
            this.checkBoxShowSend.Checked = true;
            this.checkBoxShowSend.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxShowSend.Location = new System.Drawing.Point(78, 31);
            this.checkBoxShowSend.Name = "checkBoxShowSend";
            this.checkBoxShowSend.Size = new System.Drawing.Size(72, 16);
            this.checkBoxShowSend.TabIndex = 84;
            this.checkBoxShowSend.Text = "显示发送";
            this.checkBoxShowSend.UseVisualStyleBackColor = true;
            // 
            // chkBoxHexShow
            // 
            this.chkBoxHexShow.AutoSize = true;
            this.chkBoxHexShow.Checked = true;
            this.chkBoxHexShow.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBoxHexShow.Location = new System.Drawing.Point(156, 11);
            this.chkBoxHexShow.Name = "chkBoxHexShow";
            this.chkBoxHexShow.Size = new System.Drawing.Size(66, 16);
            this.chkBoxHexShow.TabIndex = 86;
            this.chkBoxHexShow.Text = "Hex显示";
            this.chkBoxHexShow.UseVisualStyleBackColor = true;
            // 
            // checkBoxShowRecv
            // 
            this.checkBoxShowRecv.AutoSize = true;
            this.checkBoxShowRecv.Checked = true;
            this.checkBoxShowRecv.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxShowRecv.Location = new System.Drawing.Point(78, 12);
            this.checkBoxShowRecv.Name = "checkBoxShowRecv";
            this.checkBoxShowRecv.Size = new System.Drawing.Size(72, 16);
            this.checkBoxShowRecv.TabIndex = 85;
            this.checkBoxShowRecv.Text = "显示接收";
            this.checkBoxShowRecv.UseVisualStyleBackColor = true;
            // 
            // labelCPcsSoftwareVer
            // 
            this.labelCPcsSoftwareVer.AutoSize = true;
            this.labelCPcsSoftwareVer.Location = new System.Drawing.Point(278, 15);
            this.labelCPcsSoftwareVer.Name = "labelCPcsSoftwareVer";
            this.labelCPcsSoftwareVer.Size = new System.Drawing.Size(35, 12);
            this.labelCPcsSoftwareVer.TabIndex = 81;
            this.labelCPcsSoftwareVer.Text = "C相：";
            // 
            // labelBPcsSoftwareVer
            // 
            this.labelBPcsSoftwareVer.AutoSize = true;
            this.labelBPcsSoftwareVer.Location = new System.Drawing.Point(206, 15);
            this.labelBPcsSoftwareVer.Name = "labelBPcsSoftwareVer";
            this.labelBPcsSoftwareVer.Size = new System.Drawing.Size(35, 12);
            this.labelBPcsSoftwareVer.TabIndex = 80;
            this.labelBPcsSoftwareVer.Text = "B相：";
            // 
            // labelAPcsSoftwareVer
            // 
            this.labelAPcsSoftwareVer.AutoSize = true;
            this.labelAPcsSoftwareVer.Location = new System.Drawing.Point(133, 15);
            this.labelAPcsSoftwareVer.Name = "labelAPcsSoftwareVer";
            this.labelAPcsSoftwareVer.Size = new System.Drawing.Size(35, 12);
            this.labelAPcsSoftwareVer.TabIndex = 79;
            this.labelAPcsSoftwareVer.Text = "A相：";
            // 
            // btnGetPcsSoftwareVer
            // 
            this.btnGetPcsSoftwareVer.BackColor = System.Drawing.Color.LimeGreen;
            this.btnGetPcsSoftwareVer.Location = new System.Drawing.Point(354, 10);
            this.btnGetPcsSoftwareVer.Name = "btnGetPcsSoftwareVer";
            this.btnGetPcsSoftwareVer.Size = new System.Drawing.Size(68, 22);
            this.btnGetPcsSoftwareVer.TabIndex = 78;
            this.btnGetPcsSoftwareVer.Text = "查询";
            this.btnGetPcsSoftwareVer.UseVisualStyleBackColor = false;
            // 
            // label57
            // 
            this.label57.AutoSize = true;
            this.label57.Location = new System.Drawing.Point(11, 15);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(119, 12);
            this.label57.TabIndex = 77;
            this.label57.Text = "上位机-代码匹配查询";
            // 
            // txtReceivedData
            // 
            this.txtReceivedData.AcceptsReturn = true;
            this.txtReceivedData.Location = new System.Drawing.Point(9, 38);
            this.txtReceivedData.Multiline = true;
            this.txtReceivedData.Name = "txtReceivedData";
            this.txtReceivedData.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtReceivedData.Size = new System.Drawing.Size(437, 221);
            this.txtReceivedData.TabIndex = 11;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(6, 97);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(457, 252);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBoxUartCfg);
            this.tabPage1.Controls.Add(this.groupBoxPlcDstCfg);
            this.tabPage1.Controls.Add(this.groupBoxPlcTstBrdCfg);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(449, 226);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "串口";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBoxUartCfg
            // 
            this.groupBoxUartCfg.Controls.Add(this.btnOpenClose);
            this.groupBoxUartCfg.Controls.Add(this.button_Scan);
            this.groupBoxUartCfg.Controls.Add(this.cmbBaudRate);
            this.groupBoxUartCfg.Controls.Add(this.label1);
            this.groupBoxUartCfg.Controls.Add(this.label2);
            this.groupBoxUartCfg.Controls.Add(this.cmbPortName);
            this.groupBoxUartCfg.Location = new System.Drawing.Point(9, 6);
            this.groupBoxUartCfg.Name = "groupBoxUartCfg";
            this.groupBoxUartCfg.Size = new System.Drawing.Size(424, 50);
            this.groupBoxUartCfg.TabIndex = 71;
            this.groupBoxUartCfg.TabStop = false;
            this.groupBoxUartCfg.Text = "串口配置";
            // 
            // btnOpenClose
            // 
            this.btnOpenClose.Location = new System.Drawing.Point(346, 18);
            this.btnOpenClose.Name = "btnOpenClose";
            this.btnOpenClose.Size = new System.Drawing.Size(74, 23);
            this.btnOpenClose.TabIndex = 39;
            this.btnOpenClose.Text = "打开串口";
            this.btnOpenClose.UseVisualStyleBackColor = true;
            this.btnOpenClose.Click += new System.EventHandler(this.btnOpenClose_Click);
            // 
            // button_Scan
            // 
            this.button_Scan.Location = new System.Drawing.Point(268, 17);
            this.button_Scan.Name = "button_Scan";
            this.button_Scan.Size = new System.Drawing.Size(75, 23);
            this.button_Scan.TabIndex = 40;
            this.button_Scan.Text = "扫描串口";
            this.button_Scan.UseVisualStyleBackColor = true;
            this.button_Scan.Click += new System.EventHandler(this.button_Scan_Click);
            // 
            // cmbBaudRate
            // 
            this.cmbBaudRate.FormattingEnabled = true;
            this.cmbBaudRate.Location = new System.Drawing.Point(180, 18);
            this.cmbBaudRate.Name = "cmbBaudRate";
            this.cmbBaudRate.Size = new System.Drawing.Size(81, 20);
            this.cmbBaudRate.TabIndex = 38;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 36;
            this.label1.Text = "串口号";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(137, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 37;
            this.label2.Text = "波特率";
            // 
            // cmbPortName
            // 
            this.cmbPortName.FormattingEnabled = true;
            this.cmbPortName.Location = new System.Drawing.Point(55, 18);
            this.cmbPortName.Name = "cmbPortName";
            this.cmbPortName.Size = new System.Drawing.Size(75, 20);
            this.cmbPortName.TabIndex = 35;
            // 
            // groupBoxPlcDstCfg
            // 
            this.groupBoxPlcDstCfg.Controls.Add(this.label42);
            this.groupBoxPlcDstCfg.Controls.Add(this.label41);
            this.groupBoxPlcDstCfg.Controls.Add(this.txtBoxDstPanId);
            this.groupBoxPlcDstCfg.Controls.Add(this.txtBoxDstAddr);
            this.groupBoxPlcDstCfg.Location = new System.Drawing.Point(9, 146);
            this.groupBoxPlcDstCfg.Name = "groupBoxPlcDstCfg";
            this.groupBoxPlcDstCfg.Size = new System.Drawing.Size(128, 77);
            this.groupBoxPlcDstCfg.TabIndex = 64;
            this.groupBoxPlcDstCfg.TabStop = false;
            this.groupBoxPlcDstCfg.Text = "目标参数";
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Location = new System.Drawing.Point(6, 49);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(53, 12);
            this.label42.TabIndex = 70;
            this.label42.Text = "目标地址";
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(6, 23);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(65, 12);
            this.label41.TabIndex = 67;
            this.label41.Text = "目标PAN ID";
            // 
            // txtBoxDstPanId
            // 
            this.txtBoxDstPanId.Location = new System.Drawing.Point(71, 19);
            this.txtBoxDstPanId.Name = "txtBoxDstPanId";
            this.txtBoxDstPanId.Size = new System.Drawing.Size(54, 21);
            this.txtBoxDstPanId.TabIndex = 68;
            this.txtBoxDstPanId.Text = "88 88";
            // 
            // txtBoxDstAddr
            // 
            this.txtBoxDstAddr.Location = new System.Drawing.Point(71, 46);
            this.txtBoxDstAddr.Name = "txtBoxDstAddr";
            this.txtBoxDstAddr.Size = new System.Drawing.Size(54, 21);
            this.txtBoxDstAddr.TabIndex = 69;
            this.txtBoxDstAddr.Text = "10 01";
            // 
            // groupBoxPlcTstBrdCfg
            // 
            this.groupBoxPlcTstBrdCfg.Controls.Add(this.textBox5);
            this.groupBoxPlcTstBrdCfg.Controls.Add(this.label43);
            this.groupBoxPlcTstBrdCfg.Controls.Add(this.label6);
            this.groupBoxPlcTstBrdCfg.Controls.Add(this.txtPanId);
            this.groupBoxPlcTstBrdCfg.Controls.Add(this.btnCpx4Init);
            this.groupBoxPlcTstBrdCfg.Controls.Add(this.label12);
            this.groupBoxPlcTstBrdCfg.Controls.Add(this.txtTxScale);
            this.groupBoxPlcTstBrdCfg.Controls.Add(this.label3);
            this.groupBoxPlcTstBrdCfg.Controls.Add(this.cmbBandPlan);
            this.groupBoxPlcTstBrdCfg.Location = new System.Drawing.Point(9, 63);
            this.groupBoxPlcTstBrdCfg.Name = "groupBoxPlcTstBrdCfg";
            this.groupBoxPlcTstBrdCfg.Size = new System.Drawing.Size(424, 77);
            this.groupBoxPlcTstBrdCfg.TabIndex = 63;
            this.groupBoxPlcTstBrdCfg.TabStop = false;
            this.groupBoxPlcTstBrdCfg.Text = "小板配置";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(247, 44);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(54, 21);
            this.textBox5.TabIndex = 68;
            this.textBox5.Text = "10 00";
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Location = new System.Drawing.Point(181, 48);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(53, 12);
            this.label43.TabIndex = 67;
            this.label43.Text = "本机地址";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 54;
            this.label6.Text = "频带计划";
            // 
            // txtPanId
            // 
            this.txtPanId.Location = new System.Drawing.Point(248, 18);
            this.txtPanId.Name = "txtPanId";
            this.txtPanId.Size = new System.Drawing.Size(54, 21);
            this.txtPanId.TabIndex = 62;
            this.txtPanId.Text = "88 88";
            // 
            // btnCpx4Init
            // 
            this.btnCpx4Init.Location = new System.Drawing.Point(331, 17);
            this.btnCpx4Init.Name = "btnCpx4Init";
            this.btnCpx4Init.Size = new System.Drawing.Size(87, 49);
            this.btnCpx4Init.TabIndex = 17;
            this.btnCpx4Init.Text = "CPX4 初始化";
            this.btnCpx4Init.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(181, 22);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 12);
            this.label12.TabIndex = 61;
            this.label12.Text = "本机PAN ID";
            // 
            // txtTxScale
            // 
            this.txtTxScale.Location = new System.Drawing.Point(85, 45);
            this.txtTxScale.Name = "txtTxScale";
            this.txtTxScale.Size = new System.Drawing.Size(60, 21);
            this.txtTxScale.TabIndex = 44;
            this.txtTxScale.Text = "06 57";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 44;
            this.label3.Text = "发射功率0x";
            // 
            // cmbBandPlan
            // 
            this.cmbBandPlan.FormattingEnabled = true;
            this.cmbBandPlan.Location = new System.Drawing.Point(84, 19);
            this.cmbBandPlan.Name = "cmbBandPlan";
            this.cmbBandPlan.Size = new System.Drawing.Size(60, 20);
            this.cmbBandPlan.TabIndex = 54;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBoxCanSendCfg);
            this.tabPage2.Controls.Add(this.groupBoxCanCfg);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(449, 226);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "CAN";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBoxCanSendCfg
            // 
            this.groupBoxCanSendCfg.Controls.Add(this.checkBoxIsUseCanId);
            this.groupBoxCanSendCfg.Controls.Add(this.label15);
            this.groupBoxCanSendCfg.Controls.Add(this.textBoxCanIDSrcAddr);
            this.groupBoxCanSendCfg.Controls.Add(this.label14);
            this.groupBoxCanSendCfg.Controls.Add(this.textBoxCanIdDestAddr);
            this.groupBoxCanSendCfg.Controls.Add(this.label_protocol);
            this.groupBoxCanSendCfg.Controls.Add(this.comboBox_frametype);
            this.groupBoxCanSendCfg.Controls.Add(this.comboBox_protocol);
            this.groupBoxCanSendCfg.Controls.Add(this.label_channel);
            this.groupBoxCanSendCfg.Controls.Add(this.comboBox_channel);
            this.groupBoxCanSendCfg.Controls.Add(this.textBox_ID);
            this.groupBoxCanSendCfg.Controls.Add(this.label_frametype);
            this.groupBoxCanSendCfg.Location = new System.Drawing.Point(2, 166);
            this.groupBoxCanSendCfg.Name = "groupBoxCanSendCfg";
            this.groupBoxCanSendCfg.Size = new System.Drawing.Size(434, 63);
            this.groupBoxCanSendCfg.TabIndex = 41;
            this.groupBoxCanSendCfg.TabStop = false;
            this.groupBoxCanSendCfg.Text = "发送参数";
            // 
            // checkBoxIsUseCanId
            // 
            this.checkBoxIsUseCanId.AutoSize = true;
            this.checkBoxIsUseCanId.Location = new System.Drawing.Point(154, 41);
            this.checkBoxIsUseCanId.Name = "checkBoxIsUseCanId";
            this.checkBoxIsUseCanId.Size = new System.Drawing.Size(60, 16);
            this.checkBoxIsUseCanId.TabIndex = 45;
            this.checkBoxIsUseCanId.Text = "ID: 0x";
            this.checkBoxIsUseCanId.UseVisualStyleBackColor = true;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(9, 16);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(41, 12);
            this.label15.TabIndex = 44;
            this.label15.Text = "源地址";
            // 
            // textBoxCanIDSrcAddr
            // 
            this.textBoxCanIDSrcAddr.Location = new System.Drawing.Point(71, 12);
            this.textBoxCanIDSrcAddr.MaxLength = 8;
            this.textBoxCanIDSrcAddr.Name = "textBoxCanIDSrcAddr";
            this.textBoxCanIDSrcAddr.Size = new System.Drawing.Size(70, 21);
            this.textBoxCanIDSrcAddr.TabIndex = 43;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(8, 39);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(53, 12);
            this.label14.TabIndex = 42;
            this.label14.Text = "目标地址";
            // 
            // textBoxCanIdDestAddr
            // 
            this.textBoxCanIdDestAddr.Location = new System.Drawing.Point(71, 36);
            this.textBoxCanIdDestAddr.MaxLength = 8;
            this.textBoxCanIdDestAddr.Name = "textBoxCanIdDestAddr";
            this.textBoxCanIdDestAddr.Size = new System.Drawing.Size(70, 21);
            this.textBoxCanIdDestAddr.TabIndex = 41;
            // 
            // label_protocol
            // 
            this.label_protocol.AutoSize = true;
            this.label_protocol.Location = new System.Drawing.Point(166, 18);
            this.label_protocol.Name = "label_protocol";
            this.label_protocol.Size = new System.Drawing.Size(41, 12);
            this.label_protocol.TabIndex = 40;
            this.label_protocol.Text = "CAN/FD";
            // 
            // comboBox_frametype
            // 
            this.comboBox_frametype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_frametype.FormattingEnabled = true;
            this.comboBox_frametype.Items.AddRange(new object[] {
            "标准帧",
            "扩展帧"});
            this.comboBox_frametype.Location = new System.Drawing.Point(350, 14);
            this.comboBox_frametype.Name = "comboBox_frametype";
            this.comboBox_frametype.Size = new System.Drawing.Size(70, 20);
            this.comboBox_frametype.TabIndex = 37;
            // 
            // comboBox_protocol
            // 
            this.comboBox_protocol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_protocol.FormattingEnabled = true;
            this.comboBox_protocol.Items.AddRange(new object[] {
            "CAN",
            "CANFD"});
            this.comboBox_protocol.Location = new System.Drawing.Point(215, 13);
            this.comboBox_protocol.Name = "comboBox_protocol";
            this.comboBox_protocol.Size = new System.Drawing.Size(70, 20);
            this.comboBox_protocol.TabIndex = 38;
            // 
            // label_channel
            // 
            this.label_channel.AutoSize = true;
            this.label_channel.Location = new System.Drawing.Point(315, 43);
            this.label_channel.Name = "label_channel";
            this.label_channel.Size = new System.Drawing.Size(29, 12);
            this.label_channel.TabIndex = 39;
            this.label_channel.Text = "通道";
            // 
            // comboBox_channel
            // 
            this.comboBox_channel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_channel.FormattingEnabled = true;
            this.comboBox_channel.Location = new System.Drawing.Point(350, 39);
            this.comboBox_channel.Name = "comboBox_channel";
            this.comboBox_channel.Size = new System.Drawing.Size(70, 20);
            this.comboBox_channel.TabIndex = 33;
            // 
            // textBox_ID
            // 
            this.textBox_ID.Location = new System.Drawing.Point(215, 38);
            this.textBox_ID.MaxLength = 8;
            this.textBox_ID.Name = "textBox_ID";
            this.textBox_ID.Size = new System.Drawing.Size(70, 21);
            this.textBox_ID.TabIndex = 34;
            // 
            // label_frametype
            // 
            this.label_frametype.AutoSize = true;
            this.label_frametype.Location = new System.Drawing.Point(303, 17);
            this.label_frametype.Name = "label_frametype";
            this.label_frametype.Size = new System.Drawing.Size(41, 12);
            this.label_frametype.TabIndex = 36;
            this.label_frametype.Text = "帧类型";
            // 
            // groupBoxCanCfg
            // 
            this.groupBoxCanCfg.Controls.Add(this.label_endid);
            this.groupBoxCanCfg.Controls.Add(this.textBox_endid);
            this.groupBoxCanCfg.Controls.Add(this.button_close);
            this.groupBoxCanCfg.Controls.Add(this.comboBox_index);
            this.groupBoxCanCfg.Controls.Add(this.label_startid);
            this.groupBoxCanCfg.Controls.Add(this.label_index);
            this.groupBoxCanCfg.Controls.Add(this.button_reset);
            this.groupBoxCanCfg.Controls.Add(this.comboBox_device);
            this.groupBoxCanCfg.Controls.Add(this.label_device);
            this.groupBoxCanCfg.Controls.Add(this.button_init);
            this.groupBoxCanCfg.Controls.Add(this.button_start);
            this.groupBoxCanCfg.Controls.Add(this.textBox_startid);
            this.groupBoxCanCfg.Controls.Add(this.comboBox_standard2);
            this.groupBoxCanCfg.Controls.Add(this.label_standard2);
            this.groupBoxCanCfg.Controls.Add(this.button_open);
            this.groupBoxCanCfg.Controls.Add(this.comboBox_ABIT2);
            this.groupBoxCanCfg.Controls.Add(this.label_ABIT2);
            this.groupBoxCanCfg.Controls.Add(this.comboBox_ABIT);
            this.groupBoxCanCfg.Controls.Add(this.label_ABIT);
            this.groupBoxCanCfg.Controls.Add(this.comboBox_mode);
            this.groupBoxCanCfg.Controls.Add(this.label_mode);
            this.groupBoxCanCfg.Controls.Add(this.comboBox_standard);
            this.groupBoxCanCfg.Controls.Add(this.label_standard);
            this.groupBoxCanCfg.Location = new System.Drawing.Point(5, 7);
            this.groupBoxCanCfg.Name = "groupBoxCanCfg";
            this.groupBoxCanCfg.Size = new System.Drawing.Size(431, 159);
            this.groupBoxCanCfg.TabIndex = 7;
            this.groupBoxCanCfg.TabStop = false;
            this.groupBoxCanCfg.Text = "参数配置";
            // 
            // label_endid
            // 
            this.label_endid.AutoSize = true;
            this.label_endid.Location = new System.Drawing.Point(176, 135);
            this.label_endid.Name = "label_endid";
            this.label_endid.Size = new System.Drawing.Size(77, 12);
            this.label_endid.TabIndex = 20;
            this.label_endid.Text = "结束ID(0x)：";
            // 
            // textBox_endid
            // 
            this.textBox_endid.Location = new System.Drawing.Point(261, 130);
            this.textBox_endid.MaxLength = 8;
            this.textBox_endid.Name = "textBox_endid";
            this.textBox_endid.Size = new System.Drawing.Size(70, 21);
            this.textBox_endid.TabIndex = 19;
            // 
            // button_close
            // 
            this.button_close.Enabled = false;
            this.button_close.Location = new System.Drawing.Point(339, 101);
            this.button_close.Name = "button_close";
            this.button_close.Size = new System.Drawing.Size(78, 23);
            this.button_close.TabIndex = 11;
            this.button_close.Text = "关闭设备";
            this.button_close.UseVisualStyleBackColor = true;
            this.button_close.Click += new System.EventHandler(this.button_close_Click);
            // 
            // comboBox_index
            // 
            this.comboBox_index.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_index.FormattingEnabled = true;
            this.comboBox_index.Location = new System.Drawing.Point(261, 19);
            this.comboBox_index.Name = "comboBox_index";
            this.comboBox_index.Size = new System.Drawing.Size(70, 20);
            this.comboBox_index.TabIndex = 3;
            // 
            // label_startid
            // 
            this.label_startid.AutoSize = true;
            this.label_startid.Location = new System.Drawing.Point(176, 108);
            this.label_startid.Name = "label_startid";
            this.label_startid.Size = new System.Drawing.Size(77, 12);
            this.label_startid.TabIndex = 18;
            this.label_startid.Text = "起始ID(0x)：";
            // 
            // label_index
            // 
            this.label_index.AutoSize = true;
            this.label_index.Location = new System.Drawing.Point(176, 25);
            this.label_index.Name = "label_index";
            this.label_index.Size = new System.Drawing.Size(65, 12);
            this.label_index.TabIndex = 2;
            this.label_index.Text = "设备索引：";
            // 
            // button_reset
            // 
            this.button_reset.Enabled = false;
            this.button_reset.Location = new System.Drawing.Point(339, 128);
            this.button_reset.Name = "button_reset";
            this.button_reset.Size = new System.Drawing.Size(78, 23);
            this.button_reset.TabIndex = 9;
            this.button_reset.Text = "复位";
            this.button_reset.UseVisualStyleBackColor = true;
            // 
            // comboBox_device
            // 
            this.comboBox_device.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_device.FormattingEnabled = true;
            this.comboBox_device.Items.AddRange(new object[] {
            "USBCANFD-200U"});
            this.comboBox_device.Location = new System.Drawing.Point(94, 20);
            this.comboBox_device.Name = "comboBox_device";
            this.comboBox_device.Size = new System.Drawing.Size(74, 20);
            this.comboBox_device.TabIndex = 1;
            this.comboBox_device.SelectedIndexChanged += new System.EventHandler(this.comboBox_device_SelectedIndexChanged);
            // 
            // label_device
            // 
            this.label_device.AutoSize = true;
            this.label_device.Location = new System.Drawing.Point(13, 24);
            this.label_device.Name = "label_device";
            this.label_device.Size = new System.Drawing.Size(65, 12);
            this.label_device.TabIndex = 0;
            this.label_device.Text = "设备类型：";
            // 
            // button_init
            // 
            this.button_init.Enabled = false;
            this.button_init.Location = new System.Drawing.Point(339, 45);
            this.button_init.Name = "button_init";
            this.button_init.Size = new System.Drawing.Size(78, 23);
            this.button_init.TabIndex = 10;
            this.button_init.Text = "初始化CAN";
            this.button_init.UseVisualStyleBackColor = true;
            // 
            // button_start
            // 
            this.button_start.Enabled = false;
            this.button_start.Location = new System.Drawing.Point(339, 73);
            this.button_start.Name = "button_start";
            this.button_start.Size = new System.Drawing.Size(78, 23);
            this.button_start.TabIndex = 8;
            this.button_start.Text = "启动CAN";
            this.button_start.UseVisualStyleBackColor = true;
            // 
            // textBox_startid
            // 
            this.textBox_startid.Location = new System.Drawing.Point(261, 103);
            this.textBox_startid.MaxLength = 8;
            this.textBox_startid.Name = "textBox_startid";
            this.textBox_startid.Size = new System.Drawing.Size(70, 21);
            this.textBox_startid.TabIndex = 17;
            // 
            // comboBox_standard2
            // 
            this.comboBox_standard2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_standard2.FormattingEnabled = true;
            this.comboBox_standard2.Items.AddRange(new object[] {
            "标准帧",
            "扩展帧",
            "禁能"});
            this.comboBox_standard2.Location = new System.Drawing.Point(94, 105);
            this.comboBox_standard2.Name = "comboBox_standard2";
            this.comboBox_standard2.Size = new System.Drawing.Size(74, 20);
            this.comboBox_standard2.TabIndex = 16;
            // 
            // label_standard2
            // 
            this.label_standard2.AutoSize = true;
            this.label_standard2.Location = new System.Drawing.Point(12, 109);
            this.label_standard2.Name = "label_standard2";
            this.label_standard2.Size = new System.Drawing.Size(65, 12);
            this.label_standard2.TabIndex = 15;
            this.label_standard2.Text = "滤波模式：";
            // 
            // button_open
            // 
            this.button_open.Location = new System.Drawing.Point(339, 17);
            this.button_open.Name = "button_open";
            this.button_open.Size = new System.Drawing.Size(78, 23);
            this.button_open.TabIndex = 7;
            this.button_open.Text = "打开设备";
            this.button_open.UseVisualStyleBackColor = true;
            this.button_open.Click += new System.EventHandler(this.button_open_Click);
            // 
            // comboBox_ABIT2
            // 
            this.comboBox_ABIT2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_ABIT2.FormattingEnabled = true;
            this.comboBox_ABIT2.Items.AddRange(new object[] {
            "5Mbps ",
            "4Mbps ",
            "2Mbps ",
            "1Mbps ",
            "800Kbps ",
            "500Kbps ",
            "250Kbps ",
            "125Kbps "});
            this.comboBox_ABIT2.Location = new System.Drawing.Point(261, 75);
            this.comboBox_ABIT2.Name = "comboBox_ABIT2";
            this.comboBox_ABIT2.Size = new System.Drawing.Size(70, 20);
            this.comboBox_ABIT2.TabIndex = 9;
            // 
            // label_ABIT2
            // 
            this.label_ABIT2.AutoSize = true;
            this.label_ABIT2.Location = new System.Drawing.Point(176, 80);
            this.label_ABIT2.Name = "label_ABIT2";
            this.label_ABIT2.Size = new System.Drawing.Size(89, 12);
            this.label_ABIT2.TabIndex = 8;
            this.label_ABIT2.Text = "数据域波特率：";
            // 
            // comboBox_ABIT
            // 
            this.comboBox_ABIT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_ABIT.FormattingEnabled = true;
            this.comboBox_ABIT.Items.AddRange(new object[] {
            "1Mbps ",
            "800kbps ",
            "500kbps ",
            "250kbps ",
            "125kbps ",
            "100kbps ",
            "50kbps "});
            this.comboBox_ABIT.Location = new System.Drawing.Point(94, 76);
            this.comboBox_ABIT.Name = "comboBox_ABIT";
            this.comboBox_ABIT.Size = new System.Drawing.Size(74, 20);
            this.comboBox_ABIT.TabIndex = 7;
            // 
            // label_ABIT
            // 
            this.label_ABIT.AutoSize = true;
            this.label_ABIT.Location = new System.Drawing.Point(11, 80);
            this.label_ABIT.Name = "label_ABIT";
            this.label_ABIT.Size = new System.Drawing.Size(89, 12);
            this.label_ABIT.TabIndex = 6;
            this.label_ABIT.Text = "仲裁域波特率：";
            // 
            // comboBox_mode
            // 
            this.comboBox_mode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_mode.FormattingEnabled = true;
            this.comboBox_mode.Items.AddRange(new object[] {
            "正常",
            "只听"});
            this.comboBox_mode.Location = new System.Drawing.Point(94, 48);
            this.comboBox_mode.Name = "comboBox_mode";
            this.comboBox_mode.Size = new System.Drawing.Size(74, 20);
            this.comboBox_mode.TabIndex = 5;
            // 
            // label_mode
            // 
            this.label_mode.AutoSize = true;
            this.label_mode.Location = new System.Drawing.Point(12, 53);
            this.label_mode.Name = "label_mode";
            this.label_mode.Size = new System.Drawing.Size(65, 12);
            this.label_mode.TabIndex = 4;
            this.label_mode.Text = "工作模式：";
            // 
            // comboBox_standard
            // 
            this.comboBox_standard.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_standard.FormattingEnabled = true;
            this.comboBox_standard.Items.AddRange(new object[] {
            "CANFD ISO",
            "CANFD BOSCH"});
            this.comboBox_standard.Location = new System.Drawing.Point(261, 48);
            this.comboBox_standard.Name = "comboBox_standard";
            this.comboBox_standard.Size = new System.Drawing.Size(70, 20);
            this.comboBox_standard.TabIndex = 3;
            // 
            // label_standard
            // 
            this.label_standard.AutoSize = true;
            this.label_standard.Location = new System.Drawing.Point(176, 53);
            this.label_standard.Name = "label_standard";
            this.label_standard.Size = new System.Drawing.Size(71, 12);
            this.label_standard.TabIndex = 2;
            this.label_standard.Text = "CANFD标准：";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.radioBtnComm485Mode);
            this.groupBox7.Controls.Add(this.radioBtnCommCanMode);
            this.groupBox7.Controls.Add(this.radioBtnCommUartMode);
            this.groupBox7.Controls.Add(this.radioBtnCommPlcMode);
            this.groupBox7.Location = new System.Drawing.Point(6, 15);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(450, 36);
            this.groupBox7.TabIndex = 65;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "上位机通信模式选择";
            // 
            // radioBtnComm485Mode
            // 
            this.radioBtnComm485Mode.AutoSize = true;
            this.radioBtnComm485Mode.Location = new System.Drawing.Point(315, 15);
            this.radioBtnComm485Mode.Name = "radioBtnComm485Mode";
            this.radioBtnComm485Mode.Size = new System.Drawing.Size(53, 16);
            this.radioBtnComm485Mode.TabIndex = 59;
            this.radioBtnComm485Mode.TabStop = true;
            this.radioBtnComm485Mode.Text = "RS485";
            this.radioBtnComm485Mode.UseVisualStyleBackColor = true;
            // 
            // radioBtnCommCanMode
            // 
            this.radioBtnCommCanMode.AutoSize = true;
            this.radioBtnCommCanMode.Location = new System.Drawing.Point(235, 15);
            this.radioBtnCommCanMode.Name = "radioBtnCommCanMode";
            this.radioBtnCommCanMode.Size = new System.Drawing.Size(41, 16);
            this.radioBtnCommCanMode.TabIndex = 58;
            this.radioBtnCommCanMode.TabStop = true;
            this.radioBtnCommCanMode.Text = "CAN";
            this.radioBtnCommCanMode.UseVisualStyleBackColor = true;
            // 
            // radioBtnCommUartMode
            // 
            this.radioBtnCommUartMode.AutoSize = true;
            this.radioBtnCommUartMode.Location = new System.Drawing.Point(53, 15);
            this.radioBtnCommUartMode.Name = "radioBtnCommUartMode";
            this.radioBtnCommUartMode.Size = new System.Drawing.Size(47, 16);
            this.radioBtnCommUartMode.TabIndex = 56;
            this.radioBtnCommUartMode.TabStop = true;
            this.radioBtnCommUartMode.Text = "串口";
            this.radioBtnCommUartMode.UseVisualStyleBackColor = true;
            // 
            // radioBtnCommPlcMode
            // 
            this.radioBtnCommPlcMode.AutoSize = true;
            this.radioBtnCommPlcMode.Location = new System.Drawing.Point(146, 15);
            this.radioBtnCommPlcMode.Name = "radioBtnCommPlcMode";
            this.radioBtnCommPlcMode.Size = new System.Drawing.Size(41, 16);
            this.radioBtnCommPlcMode.TabIndex = 57;
            this.radioBtnCommPlcMode.TabStop = true;
            this.radioBtnCommPlcMode.Text = "PLC";
            this.radioBtnCommPlcMode.UseVisualStyleBackColor = true;
            // 
            // groupBox23
            // 
            this.groupBox23.Controls.Add(this.btnSend);
            this.groupBox23.Controls.Add(this.label72);
            this.groupBox23.Controls.Add(this.label71);
            this.groupBox23.Controls.Add(this.btnCalculateCrc);
            this.groupBox23.Controls.Add(this.tbCrcResult);
            this.groupBox23.Controls.Add(this.label19);
            this.groupBox23.Controls.Add(this.label20);
            this.groupBox23.Controls.Add(this.tbData2Crc);
            this.groupBox23.Controls.Add(this.txtSendData);
            this.groupBox23.Location = new System.Drawing.Point(7, 351);
            this.groupBox23.Name = "groupBox23";
            this.groupBox23.Size = new System.Drawing.Size(456, 93);
            this.groupBox23.TabIndex = 71;
            this.groupBox23.TabStop = false;
            this.groupBox23.Text = "手动发送";
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(359, 64);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(91, 23);
            this.btnSend.TabIndex = 109;
            this.btnSend.Text = "发送";
            this.btnSend.UseVisualStyleBackColor = true;
            // 
            // label72
            // 
            this.label72.AutoSize = true;
            this.label72.Location = new System.Drawing.Point(127, 45);
            this.label72.Name = "label72";
            this.label72.Size = new System.Drawing.Size(119, 12);
            this.label72.TabIndex = 108;
            this.label72.Text = "(自动生成CRC校验码)";
            // 
            // label71
            // 
            this.label71.AutoSize = true;
            this.label71.Location = new System.Drawing.Point(5, 70);
            this.label71.Name = "label71";
            this.label71.Size = new System.Drawing.Size(53, 12);
            this.label71.TabIndex = 66;
            this.label71.Text = "发送内容";
            // 
            // btnCalculateCrc
            // 
            this.btnCalculateCrc.Location = new System.Drawing.Point(359, 40);
            this.btnCalculateCrc.Name = "btnCalculateCrc";
            this.btnCalculateCrc.Size = new System.Drawing.Size(91, 23);
            this.btnCalculateCrc.TabIndex = 56;
            this.btnCalculateCrc.Text = "计算CRC";
            this.btnCalculateCrc.UseVisualStyleBackColor = true;
            // 
            // tbCrcResult
            // 
            this.tbCrcResult.Location = new System.Drawing.Point(59, 41);
            this.tbCrcResult.Name = "tbCrcResult";
            this.tbCrcResult.Size = new System.Drawing.Size(62, 21);
            this.tbCrcResult.TabIndex = 65;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(6, 45);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(53, 12);
            this.label19.TabIndex = 64;
            this.label19.Text = "CRC 结果";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(6, 20);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(53, 12);
            this.label20.TabIndex = 63;
            this.label20.Text = "发送内容";
            // 
            // tbData2Crc
            // 
            this.tbData2Crc.Location = new System.Drawing.Point(59, 17);
            this.tbData2Crc.Name = "tbData2Crc";
            this.tbData2Crc.Size = new System.Drawing.Size(390, 21);
            this.tbData2Crc.TabIndex = 36;
            // 
            // txtSendData
            // 
            this.txtSendData.Location = new System.Drawing.Point(59, 65);
            this.txtSendData.Name = "txtSendData";
            this.txtSendData.Size = new System.Drawing.Size(297, 21);
            this.txtSendData.TabIndex = 9;
            // 
            // groupBox16
            // 
            this.groupBox16.Controls.Add(this.flowLayoutPanel1);
            this.groupBox16.Location = new System.Drawing.Point(5, 51);
            this.groupBox16.Name = "groupBox16";
            this.groupBox16.Size = new System.Drawing.Size(451, 43);
            this.groupBox16.TabIndex = 66;
            this.groupBox16.TabStop = false;
            this.groupBox16.Text = "通信对象选择";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.radioBtnConnectObjectPCS_A);
            this.flowLayoutPanel1.Controls.Add(this.radioBtnConnectObjectPCS_B);
            this.flowLayoutPanel1.Controls.Add(this.radioBtnConnectObjectBigPcs);
            this.flowLayoutPanel1.Controls.Add(this.labDestMcuAddr);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 17);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(445, 23);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // radioBtnConnectObjectPCS_A
            // 
            this.radioBtnConnectObjectPCS_A.AutoSize = true;
            this.radioBtnConnectObjectPCS_A.Location = new System.Drawing.Point(3, 3);
            this.radioBtnConnectObjectPCS_A.Name = "radioBtnConnectObjectPCS_A";
            this.radioBtnConnectObjectPCS_A.Size = new System.Drawing.Size(83, 16);
            this.radioBtnConnectObjectPCS_A.TabIndex = 69;
            this.radioBtnConnectObjectPCS_A.TabStop = true;
            this.radioBtnConnectObjectPCS_A.Text = "PCS_Master";
            this.radioBtnConnectObjectPCS_A.UseVisualStyleBackColor = true;
            // 
            // radioBtnConnectObjectPCS_B
            // 
            this.radioBtnConnectObjectPCS_B.AutoSize = true;
            this.radioBtnConnectObjectPCS_B.Location = new System.Drawing.Point(92, 3);
            this.radioBtnConnectObjectPCS_B.Name = "radioBtnConnectObjectPCS_B";
            this.radioBtnConnectObjectPCS_B.Size = new System.Drawing.Size(77, 16);
            this.radioBtnConnectObjectPCS_B.TabIndex = 70;
            this.radioBtnConnectObjectPCS_B.TabStop = true;
            this.radioBtnConnectObjectPCS_B.Text = "PCS_Slave";
            this.radioBtnConnectObjectPCS_B.UseVisualStyleBackColor = true;
            // 
            // radioBtnConnectObjectBigPcs
            // 
            this.radioBtnConnectObjectBigPcs.AutoSize = true;
            this.radioBtnConnectObjectBigPcs.Location = new System.Drawing.Point(175, 3);
            this.radioBtnConnectObjectBigPcs.Name = "radioBtnConnectObjectBigPcs";
            this.radioBtnConnectObjectBigPcs.Size = new System.Drawing.Size(101, 16);
            this.radioBtnConnectObjectBigPcs.TabIndex = 74;
            this.radioBtnConnectObjectBigPcs.TabStop = true;
            this.radioBtnConnectObjectBigPcs.Text = "PCS_Broadcast";
            this.radioBtnConnectObjectBigPcs.UseVisualStyleBackColor = true;
            // 
            // labDestMcuAddr
            // 
            this.labDestMcuAddr.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labDestMcuAddr.AutoSize = true;
            this.labDestMcuAddr.Location = new System.Drawing.Point(282, 5);
            this.labDestMcuAddr.Name = "labDestMcuAddr";
            this.labDestMcuAddr.Size = new System.Drawing.Size(89, 12);
            this.labDestMcuAddr.TabIndex = 75;
            this.labDestMcuAddr.Text = "MCU地址： 0x00";
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage3);
            this.tabControl2.Controls.Add(this.tabPage4);
            this.tabControl2.Controls.Add(this.tabPage5);
            this.tabControl2.Controls.Add(this.tabPage6);
            this.tabControl2.Controls.Add(this.tabPage7);
            this.tabControl2.Controls.Add(this.tabPage8);
            this.tabControl2.Controls.Add(this.tabPage9);
            this.tabControl2.Controls.Add(this.tabPage10);
            this.tabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl2.Location = new System.Drawing.Point(469, 0);
            this.tabControl2.Margin = new System.Windows.Forms.Padding(6, 3, 3, 3);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 1;
            this.tabControl2.Size = new System.Drawing.Size(724, 765);
            this.tabControl2.TabIndex = 2;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.tableLayoutPanel2);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(716, 739);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "软件示波器";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel10, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 298F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(710, 733);
            this.tableLayoutPanel2.TabIndex = 356;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.groupBox63, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel5, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 438);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 148F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(704, 292);
            this.tableLayoutPanel3.TabIndex = 356;
            // 
            // groupBox63
            // 
            this.groupBox63.Controls.Add(this.tableLayoutPanel4);
            this.groupBox63.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox63.Location = new System.Drawing.Point(3, 151);
            this.groupBox63.Name = "groupBox63";
            this.groupBox63.Size = new System.Drawing.Size(698, 138);
            this.groupBox63.TabIndex = 1;
            this.groupBox63.TabStop = false;
            this.groupBox63.Text = "通道配置";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 6;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 82F));
            this.tableLayoutPanel4.Controls.Add(this.label287, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.btnChannel1, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.btnChannel2, 2, 0);
            this.tableLayoutPanel4.Controls.Add(this.btnChannel3, 3, 0);
            this.tableLayoutPanel4.Controls.Add(this.btnChannel4, 4, 0);
            this.tableLayoutPanel4.Controls.Add(this.label286, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.comboBoxCh1SignalId, 1, 1);
            this.tableLayoutPanel4.Controls.Add(this.comboBoxCh2SignalId, 2, 1);
            this.tableLayoutPanel4.Controls.Add(this.comboBoxCh3SignalId, 3, 1);
            this.tableLayoutPanel4.Controls.Add(this.comboBoxCh4SignalId, 4, 1);
            this.tableLayoutPanel4.Controls.Add(this.label349, 0, 2);
            this.tableLayoutPanel4.Controls.Add(this.textBoxCh1Addr, 1, 2);
            this.tableLayoutPanel4.Controls.Add(this.textBoxCh2Addr, 2, 2);
            this.tableLayoutPanel4.Controls.Add(this.textBoxCh3Addr, 3, 2);
            this.tableLayoutPanel4.Controls.Add(this.textBoxCh4Addr, 4, 2);
            this.tableLayoutPanel4.Controls.Add(this.label345, 0, 3);
            this.tableLayoutPanel4.Controls.Add(this.comboBoxCh1DatType, 1, 3);
            this.tableLayoutPanel4.Controls.Add(this.comboBoxCh2DatType, 2, 3);
            this.tableLayoutPanel4.Controls.Add(this.comboBoxCh3DatType, 3, 3);
            this.tableLayoutPanel4.Controls.Add(this.comboBoxCh4DatType, 4, 3);
            this.tableLayoutPanel4.Controls.Add(this.btnExportWaveData, 5, 3);
            this.tableLayoutPanel4.Controls.Add(this.btnImportWaveData, 5, 2);
            this.tableLayoutPanel4.Controls.Add(this.btnOscAddSignal, 5, 1);
            this.tableLayoutPanel4.Controls.Add(this.btnImportSignalCfg, 5, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 17);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 5;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(692, 118);
            this.tableLayoutPanel4.TabIndex = 390;
            // 
            // label287
            // 
            this.label287.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label287.AutoSize = true;
            this.label287.Location = new System.Drawing.Point(3, 8);
            this.label287.Name = "label287";
            this.label287.Size = new System.Drawing.Size(64, 12);
            this.label287.TabIndex = 359;
            this.label287.Text = "通道选择";
            // 
            // btnChannel1
            // 
            this.btnChannel1.BackColor = System.Drawing.Color.White;
            this.btnChannel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnChannel1.Location = new System.Drawing.Point(73, 3);
            this.btnChannel1.Name = "btnChannel1";
            this.btnChannel1.Size = new System.Drawing.Size(129, 22);
            this.btnChannel1.TabIndex = 355;
            this.btnChannel1.Text = "通道1";
            this.btnChannel1.UseVisualStyleBackColor = false;
            // 
            // btnChannel2
            // 
            this.btnChannel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnChannel2.Location = new System.Drawing.Point(208, 3);
            this.btnChannel2.Name = "btnChannel2";
            this.btnChannel2.Size = new System.Drawing.Size(129, 22);
            this.btnChannel2.TabIndex = 356;
            this.btnChannel2.Text = "通道2";
            this.btnChannel2.UseVisualStyleBackColor = true;
            // 
            // btnChannel3
            // 
            this.btnChannel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnChannel3.Location = new System.Drawing.Point(343, 3);
            this.btnChannel3.Name = "btnChannel3";
            this.btnChannel3.Size = new System.Drawing.Size(129, 22);
            this.btnChannel3.TabIndex = 357;
            this.btnChannel3.Text = "通道3";
            this.btnChannel3.UseVisualStyleBackColor = true;
            // 
            // btnChannel4
            // 
            this.btnChannel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnChannel4.Location = new System.Drawing.Point(478, 3);
            this.btnChannel4.Name = "btnChannel4";
            this.btnChannel4.Size = new System.Drawing.Size(129, 22);
            this.btnChannel4.TabIndex = 358;
            this.btnChannel4.Text = "通道4";
            this.btnChannel4.UseVisualStyleBackColor = true;
            // 
            // label286
            // 
            this.label286.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label286.AutoSize = true;
            this.label286.Location = new System.Drawing.Point(3, 36);
            this.label286.Name = "label286";
            this.label286.Size = new System.Drawing.Size(64, 12);
            this.label286.TabIndex = 360;
            this.label286.Text = "信号选择";
            // 
            // comboBoxCh1SignalId
            // 
            this.comboBoxCh1SignalId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxCh1SignalId.FormattingEnabled = true;
            this.comboBoxCh1SignalId.Location = new System.Drawing.Point(73, 32);
            this.comboBoxCh1SignalId.Name = "comboBoxCh1SignalId";
            this.comboBoxCh1SignalId.Size = new System.Drawing.Size(129, 20);
            this.comboBoxCh1SignalId.TabIndex = 361;
            // 
            // comboBoxCh2SignalId
            // 
            this.comboBoxCh2SignalId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxCh2SignalId.FormattingEnabled = true;
            this.comboBoxCh2SignalId.Location = new System.Drawing.Point(208, 32);
            this.comboBoxCh2SignalId.Name = "comboBoxCh2SignalId";
            this.comboBoxCh2SignalId.Size = new System.Drawing.Size(129, 20);
            this.comboBoxCh2SignalId.TabIndex = 363;
            // 
            // comboBoxCh3SignalId
            // 
            this.comboBoxCh3SignalId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxCh3SignalId.FormattingEnabled = true;
            this.comboBoxCh3SignalId.Location = new System.Drawing.Point(343, 32);
            this.comboBoxCh3SignalId.Name = "comboBoxCh3SignalId";
            this.comboBoxCh3SignalId.Size = new System.Drawing.Size(129, 20);
            this.comboBoxCh3SignalId.TabIndex = 364;
            // 
            // comboBoxCh4SignalId
            // 
            this.comboBoxCh4SignalId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxCh4SignalId.FormattingEnabled = true;
            this.comboBoxCh4SignalId.Location = new System.Drawing.Point(478, 32);
            this.comboBoxCh4SignalId.Name = "comboBoxCh4SignalId";
            this.comboBoxCh4SignalId.Size = new System.Drawing.Size(129, 20);
            this.comboBoxCh4SignalId.TabIndex = 365;
            // 
            // label349
            // 
            this.label349.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label349.AutoSize = true;
            this.label349.Location = new System.Drawing.Point(3, 64);
            this.label349.Name = "label349";
            this.label349.Size = new System.Drawing.Size(64, 12);
            this.label349.TabIndex = 393;
            this.label349.Text = "信号地址";
            // 
            // textBoxCh1Addr
            // 
            this.textBoxCh1Addr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxCh1Addr.Location = new System.Drawing.Point(73, 59);
            this.textBoxCh1Addr.Name = "textBoxCh1Addr";
            this.textBoxCh1Addr.Size = new System.Drawing.Size(129, 21);
            this.textBoxCh1Addr.TabIndex = 394;
            // 
            // textBoxCh2Addr
            // 
            this.textBoxCh2Addr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxCh2Addr.Location = new System.Drawing.Point(208, 59);
            this.textBoxCh2Addr.Name = "textBoxCh2Addr";
            this.textBoxCh2Addr.Size = new System.Drawing.Size(129, 21);
            this.textBoxCh2Addr.TabIndex = 395;
            // 
            // textBoxCh3Addr
            // 
            this.textBoxCh3Addr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxCh3Addr.Location = new System.Drawing.Point(343, 59);
            this.textBoxCh3Addr.Name = "textBoxCh3Addr";
            this.textBoxCh3Addr.Size = new System.Drawing.Size(129, 21);
            this.textBoxCh3Addr.TabIndex = 396;
            // 
            // textBoxCh4Addr
            // 
            this.textBoxCh4Addr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxCh4Addr.Location = new System.Drawing.Point(478, 59);
            this.textBoxCh4Addr.Name = "textBoxCh4Addr";
            this.textBoxCh4Addr.Size = new System.Drawing.Size(129, 21);
            this.textBoxCh4Addr.TabIndex = 397;
            // 
            // label345
            // 
            this.label345.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label345.AutoSize = true;
            this.label345.Location = new System.Drawing.Point(3, 92);
            this.label345.Name = "label345";
            this.label345.Size = new System.Drawing.Size(64, 12);
            this.label345.TabIndex = 403;
            this.label345.Text = "数据类型";
            // 
            // comboBoxCh1DatType
            // 
            this.comboBoxCh1DatType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxCh1DatType.FormattingEnabled = true;
            this.comboBoxCh1DatType.Items.AddRange(new object[] {
            "Int16",
            "Uint16",
            "Int32",
            "Uint32",
            "Float"});
            this.comboBoxCh1DatType.Location = new System.Drawing.Point(73, 88);
            this.comboBoxCh1DatType.Name = "comboBoxCh1DatType";
            this.comboBoxCh1DatType.Size = new System.Drawing.Size(129, 20);
            this.comboBoxCh1DatType.TabIndex = 404;
            // 
            // comboBoxCh2DatType
            // 
            this.comboBoxCh2DatType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxCh2DatType.FormattingEnabled = true;
            this.comboBoxCh2DatType.Items.AddRange(new object[] {
            "Int16",
            "Uint16",
            "Int32",
            "Uint32",
            "Float"});
            this.comboBoxCh2DatType.Location = new System.Drawing.Point(208, 88);
            this.comboBoxCh2DatType.Name = "comboBoxCh2DatType";
            this.comboBoxCh2DatType.Size = new System.Drawing.Size(129, 20);
            this.comboBoxCh2DatType.TabIndex = 405;
            // 
            // comboBoxCh3DatType
            // 
            this.comboBoxCh3DatType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxCh3DatType.FormattingEnabled = true;
            this.comboBoxCh3DatType.Items.AddRange(new object[] {
            "Int16",
            "Uint16",
            "Int32",
            "Uint32",
            "Float"});
            this.comboBoxCh3DatType.Location = new System.Drawing.Point(343, 88);
            this.comboBoxCh3DatType.Name = "comboBoxCh3DatType";
            this.comboBoxCh3DatType.Size = new System.Drawing.Size(129, 20);
            this.comboBoxCh3DatType.TabIndex = 406;
            // 
            // comboBoxCh4DatType
            // 
            this.comboBoxCh4DatType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxCh4DatType.FormattingEnabled = true;
            this.comboBoxCh4DatType.Items.AddRange(new object[] {
            "Int16",
            "Uint16",
            "Int32",
            "Uint32",
            "Float"});
            this.comboBoxCh4DatType.Location = new System.Drawing.Point(478, 88);
            this.comboBoxCh4DatType.Name = "comboBoxCh4DatType";
            this.comboBoxCh4DatType.Size = new System.Drawing.Size(129, 20);
            this.comboBoxCh4DatType.TabIndex = 407;
            // 
            // btnExportWaveData
            // 
            this.btnExportWaveData.Location = new System.Drawing.Point(613, 87);
            this.btnExportWaveData.Name = "btnExportWaveData";
            this.btnExportWaveData.Size = new System.Drawing.Size(76, 22);
            this.btnExportWaveData.TabIndex = 383;
            this.btnExportWaveData.Text = "导出波形";
            this.btnExportWaveData.UseVisualStyleBackColor = true;
            // 
            // btnImportWaveData
            // 
            this.btnImportWaveData.Location = new System.Drawing.Point(613, 59);
            this.btnImportWaveData.Name = "btnImportWaveData";
            this.btnImportWaveData.Size = new System.Drawing.Size(76, 22);
            this.btnImportWaveData.TabIndex = 382;
            this.btnImportWaveData.Text = "导入波形";
            this.btnImportWaveData.UseVisualStyleBackColor = true;
            // 
            // btnOscAddSignal
            // 
            this.btnOscAddSignal.Location = new System.Drawing.Point(613, 31);
            this.btnOscAddSignal.Name = "btnOscAddSignal";
            this.btnOscAddSignal.Size = new System.Drawing.Size(75, 22);
            this.btnOscAddSignal.TabIndex = 418;
            this.btnOscAddSignal.Text = "添加信号";
            this.btnOscAddSignal.UseVisualStyleBackColor = true;
            // 
            // btnImportSignalCfg
            // 
            this.btnImportSignalCfg.Location = new System.Drawing.Point(613, 3);
            this.btnImportSignalCfg.Name = "btnImportSignalCfg";
            this.btnImportSignalCfg.Size = new System.Drawing.Size(76, 22);
            this.btnImportSignalCfg.TabIndex = 366;
            this.btnImportSignalCfg.Text = "导入信号";
            this.btnImportSignalCfg.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 154F));
            this.tableLayoutPanel5.Controls.Add(this.groupBox62, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.groupBox54, 1, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(698, 142);
            this.tableLayoutPanel5.TabIndex = 2;
            // 
            // groupBox62
            // 
            this.groupBox62.Controls.Add(this.tableLayoutPanel8);
            this.groupBox62.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox62.Location = new System.Drawing.Point(3, 3);
            this.groupBox62.Name = "groupBox62";
            this.groupBox62.Size = new System.Drawing.Size(538, 136);
            this.groupBox62.TabIndex = 404;
            this.groupBox62.TabStop = false;
            this.groupBox62.Text = "波形控制";
            // 
            // tableLayoutPanel8
            // 
            this.tableLayoutPanel8.ColumnCount = 1;
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel8.Controls.Add(this.tableLayoutPanel7, 0, 1);
            this.tableLayoutPanel8.Controls.Add(this.tableLayoutPanel9, 0, 0);
            this.tableLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel8.Location = new System.Drawing.Point(3, 17);
            this.tableLayoutPanel8.Name = "tableLayoutPanel8";
            this.tableLayoutPanel8.RowCount = 2;
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel8.Size = new System.Drawing.Size(532, 116);
            this.tableLayoutPanel8.TabIndex = 394;
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.ColumnCount = 8;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tableLayoutPanel7.Controls.Add(this.numericUpDownTrigPos, 7, 2);
            this.tableLayoutPanel7.Controls.Add(this.numericUpDown3, 7, 1);
            this.tableLayoutPanel7.Controls.Add(this.label361, 6, 2);
            this.tableLayoutPanel7.Controls.Add(this.label359, 6, 1);
            this.tableLayoutPanel7.Controls.Add(this.numUpDnVrtZoomCh1, 1, 1);
            this.tableLayoutPanel7.Controls.Add(this.numUpDnVrtZoomCh2, 2, 1);
            this.tableLayoutPanel7.Controls.Add(this.numUpDnVrtZoomCh3, 3, 1);
            this.tableLayoutPanel7.Controls.Add(this.numUpDnVrtZoomCh4, 4, 1);
            this.tableLayoutPanel7.Controls.Add(this.numUpDnVrtOffsetCh1, 1, 2);
            this.tableLayoutPanel7.Controls.Add(this.numUpDnVrtOffsetCh2, 2, 2);
            this.tableLayoutPanel7.Controls.Add(this.numUpDnVrtOffsetCh3, 3, 2);
            this.tableLayoutPanel7.Controls.Add(this.numUpDnVrtOffsetCh4, 4, 2);
            this.tableLayoutPanel7.Controls.Add(this.label325, 0, 1);
            this.tableLayoutPanel7.Controls.Add(this.label346, 0, 2);
            this.tableLayoutPanel7.Controls.Add(this.label347, 0, 0);
            this.tableLayoutPanel7.Controls.Add(this.label348, 1, 0);
            this.tableLayoutPanel7.Controls.Add(this.label350, 2, 0);
            this.tableLayoutPanel7.Controls.Add(this.label351, 3, 0);
            this.tableLayoutPanel7.Controls.Add(this.label352, 4, 0);
            this.tableLayoutPanel7.Controls.Add(this.label353, 7, 0);
            this.tableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel7.Location = new System.Drawing.Point(3, 36);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 4;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(526, 77);
            this.tableLayoutPanel7.TabIndex = 394;
            // 
            // numericUpDownTrigPos
            // 
            this.numericUpDownTrigPos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDownTrigPos.Location = new System.Drawing.Point(454, 52);
            this.numericUpDownTrigPos.Maximum = new decimal(new int[] {
            199,
            0,
            0,
            0});
            this.numericUpDownTrigPos.Name = "numericUpDownTrigPos";
            this.numericUpDownTrigPos.Size = new System.Drawing.Size(69, 21);
            this.numericUpDownTrigPos.TabIndex = 403;
            // 
            // numericUpDown3
            // 
            this.numericUpDown3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDown3.Location = new System.Drawing.Point(454, 25);
            this.numericUpDown3.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDown3.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.numericUpDown3.Name = "numericUpDown3";
            this.numericUpDown3.Size = new System.Drawing.Size(69, 21);
            this.numericUpDown3.TabIndex = 402;
            // 
            // label361
            // 
            this.label361.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label361.AutoSize = true;
            this.label361.Location = new System.Drawing.Point(409, 56);
            this.label361.Name = "label361";
            this.label361.Size = new System.Drawing.Size(39, 12);
            this.label361.TabIndex = 398;
            this.label361.Text = "平移";
            // 
            // label359
            // 
            this.label359.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label359.AutoSize = true;
            this.label359.Location = new System.Drawing.Point(409, 29);
            this.label359.Name = "label359";
            this.label359.Size = new System.Drawing.Size(39, 12);
            this.label359.TabIndex = 394;
            this.label359.Text = "缩放";
            // 
            // numUpDnVrtZoomCh1
            // 
            this.numUpDnVrtZoomCh1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.numUpDnVrtZoomCh1.DecimalPlaces = 4;
            this.numUpDnVrtZoomCh1.Increment = new decimal(new int[] {
            1,
            0,
            0,
            262144});
            this.numUpDnVrtZoomCh1.Location = new System.Drawing.Point(48, 25);
            this.numUpDnVrtZoomCh1.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numUpDnVrtZoomCh1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            262144});
            this.numUpDnVrtZoomCh1.Name = "numUpDnVrtZoomCh1";
            this.numUpDnVrtZoomCh1.Size = new System.Drawing.Size(69, 21);
            this.numUpDnVrtZoomCh1.TabIndex = 410;
            this.numUpDnVrtZoomCh1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numUpDnVrtZoomCh2
            // 
            this.numUpDnVrtZoomCh2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.numUpDnVrtZoomCh2.DecimalPlaces = 4;
            this.numUpDnVrtZoomCh2.Increment = new decimal(new int[] {
            1,
            0,
            0,
            262144});
            this.numUpDnVrtZoomCh2.Location = new System.Drawing.Point(123, 25);
            this.numUpDnVrtZoomCh2.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numUpDnVrtZoomCh2.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            262144});
            this.numUpDnVrtZoomCh2.Name = "numUpDnVrtZoomCh2";
            this.numUpDnVrtZoomCh2.Size = new System.Drawing.Size(69, 21);
            this.numUpDnVrtZoomCh2.TabIndex = 411;
            this.numUpDnVrtZoomCh2.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numUpDnVrtZoomCh3
            // 
            this.numUpDnVrtZoomCh3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.numUpDnVrtZoomCh3.DecimalPlaces = 4;
            this.numUpDnVrtZoomCh3.Increment = new decimal(new int[] {
            1,
            0,
            0,
            262144});
            this.numUpDnVrtZoomCh3.Location = new System.Drawing.Point(198, 25);
            this.numUpDnVrtZoomCh3.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numUpDnVrtZoomCh3.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            262144});
            this.numUpDnVrtZoomCh3.Name = "numUpDnVrtZoomCh3";
            this.numUpDnVrtZoomCh3.Size = new System.Drawing.Size(69, 21);
            this.numUpDnVrtZoomCh3.TabIndex = 412;
            this.numUpDnVrtZoomCh3.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numUpDnVrtZoomCh4
            // 
            this.numUpDnVrtZoomCh4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.numUpDnVrtZoomCh4.DecimalPlaces = 4;
            this.numUpDnVrtZoomCh4.Increment = new decimal(new int[] {
            1,
            0,
            0,
            262144});
            this.numUpDnVrtZoomCh4.Location = new System.Drawing.Point(273, 25);
            this.numUpDnVrtZoomCh4.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numUpDnVrtZoomCh4.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            262144});
            this.numUpDnVrtZoomCh4.Name = "numUpDnVrtZoomCh4";
            this.numUpDnVrtZoomCh4.Size = new System.Drawing.Size(69, 21);
            this.numUpDnVrtZoomCh4.TabIndex = 413;
            this.numUpDnVrtZoomCh4.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numUpDnVrtOffsetCh1
            // 
            this.numUpDnVrtOffsetCh1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.numUpDnVrtOffsetCh1.DecimalPlaces = 4;
            this.numUpDnVrtOffsetCh1.Increment = new decimal(new int[] {
            1,
            0,
            0,
            262144});
            this.numUpDnVrtOffsetCh1.Location = new System.Drawing.Point(48, 52);
            this.numUpDnVrtOffsetCh1.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numUpDnVrtOffsetCh1.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.numUpDnVrtOffsetCh1.Name = "numUpDnVrtOffsetCh1";
            this.numUpDnVrtOffsetCh1.Size = new System.Drawing.Size(69, 21);
            this.numUpDnVrtOffsetCh1.TabIndex = 414;
            // 
            // numUpDnVrtOffsetCh2
            // 
            this.numUpDnVrtOffsetCh2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.numUpDnVrtOffsetCh2.DecimalPlaces = 4;
            this.numUpDnVrtOffsetCh2.Increment = new decimal(new int[] {
            1,
            0,
            0,
            262144});
            this.numUpDnVrtOffsetCh2.Location = new System.Drawing.Point(123, 52);
            this.numUpDnVrtOffsetCh2.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numUpDnVrtOffsetCh2.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.numUpDnVrtOffsetCh2.Name = "numUpDnVrtOffsetCh2";
            this.numUpDnVrtOffsetCh2.Size = new System.Drawing.Size(69, 21);
            this.numUpDnVrtOffsetCh2.TabIndex = 415;
            // 
            // numUpDnVrtOffsetCh3
            // 
            this.numUpDnVrtOffsetCh3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.numUpDnVrtOffsetCh3.DecimalPlaces = 4;
            this.numUpDnVrtOffsetCh3.Increment = new decimal(new int[] {
            1,
            0,
            0,
            262144});
            this.numUpDnVrtOffsetCh3.Location = new System.Drawing.Point(198, 52);
            this.numUpDnVrtOffsetCh3.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numUpDnVrtOffsetCh3.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.numUpDnVrtOffsetCh3.Name = "numUpDnVrtOffsetCh3";
            this.numUpDnVrtOffsetCh3.Size = new System.Drawing.Size(69, 21);
            this.numUpDnVrtOffsetCh3.TabIndex = 416;
            // 
            // numUpDnVrtOffsetCh4
            // 
            this.numUpDnVrtOffsetCh4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.numUpDnVrtOffsetCh4.DecimalPlaces = 4;
            this.numUpDnVrtOffsetCh4.Increment = new decimal(new int[] {
            1,
            0,
            0,
            262144});
            this.numUpDnVrtOffsetCh4.Location = new System.Drawing.Point(273, 52);
            this.numUpDnVrtOffsetCh4.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numUpDnVrtOffsetCh4.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.numUpDnVrtOffsetCh4.Name = "numUpDnVrtOffsetCh4";
            this.numUpDnVrtOffsetCh4.Size = new System.Drawing.Size(69, 21);
            this.numUpDnVrtOffsetCh4.TabIndex = 417;
            // 
            // label325
            // 
            this.label325.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label325.AutoSize = true;
            this.label325.Location = new System.Drawing.Point(3, 29);
            this.label325.Name = "label325";
            this.label325.Size = new System.Drawing.Size(39, 12);
            this.label325.TabIndex = 408;
            this.label325.Text = "缩放";
            // 
            // label346
            // 
            this.label346.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label346.AutoSize = true;
            this.label346.Location = new System.Drawing.Point(3, 56);
            this.label346.Name = "label346";
            this.label346.Size = new System.Drawing.Size(39, 12);
            this.label346.TabIndex = 409;
            this.label346.Text = "偏移";
            // 
            // label347
            // 
            this.label347.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label347.AutoSize = true;
            this.label347.Location = new System.Drawing.Point(3, 5);
            this.label347.Name = "label347";
            this.label347.Size = new System.Drawing.Size(39, 12);
            this.label347.TabIndex = 418;
            this.label347.Text = "垂向";
            // 
            // label348
            // 
            this.label348.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label348.AutoSize = true;
            this.label348.Location = new System.Drawing.Point(48, 5);
            this.label348.Name = "label348";
            this.label348.Size = new System.Drawing.Size(69, 12);
            this.label348.TabIndex = 419;
            this.label348.Text = "通道1";
            this.label348.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label350
            // 
            this.label350.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label350.AutoSize = true;
            this.label350.Location = new System.Drawing.Point(123, 5);
            this.label350.Name = "label350";
            this.label350.Size = new System.Drawing.Size(69, 12);
            this.label350.TabIndex = 420;
            this.label350.Text = "通道2";
            this.label350.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label351
            // 
            this.label351.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label351.AutoSize = true;
            this.label351.Location = new System.Drawing.Point(198, 5);
            this.label351.Name = "label351";
            this.label351.Size = new System.Drawing.Size(69, 12);
            this.label351.TabIndex = 421;
            this.label351.Text = "通道3";
            this.label351.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label352
            // 
            this.label352.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label352.AutoSize = true;
            this.label352.Location = new System.Drawing.Point(273, 5);
            this.label352.Name = "label352";
            this.label352.Size = new System.Drawing.Size(69, 12);
            this.label352.TabIndex = 422;
            this.label352.Text = "通道4";
            this.label352.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label353
            // 
            this.label353.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label353.AutoSize = true;
            this.label353.Location = new System.Drawing.Point(454, 5);
            this.label353.Name = "label353";
            this.label353.Size = new System.Drawing.Size(69, 12);
            this.label353.TabIndex = 423;
            this.label353.Text = "水平方向";
            // 
            // tableLayoutPanel9
            // 
            this.tableLayoutPanel9.ColumnCount = 7;
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel9.Controls.Add(this.label288, 0, 0);
            this.tableLayoutPanel9.Controls.Add(this.label284, 2, 0);
            this.tableLayoutPanel9.Controls.Add(this.numUpDnSampleFreqOrigin, 1, 0);
            this.tableLayoutPanel9.Controls.Add(this.numUpDnSampleDiv, 3, 0);
            this.tableLayoutPanel9.Controls.Add(this.btnStartGetWaveData, 6, 0);
            this.tableLayoutPanel9.Controls.Add(this.btnClearAllWaveData, 5, 0);
            this.tableLayoutPanel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel9.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel9.Name = "tableLayoutPanel9";
            this.tableLayoutPanel9.RowCount = 1;
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel9.Size = new System.Drawing.Size(526, 27);
            this.tableLayoutPanel9.TabIndex = 0;
            // 
            // label288
            // 
            this.label288.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label288.AutoSize = true;
            this.label288.Location = new System.Drawing.Point(3, 7);
            this.label288.Name = "label288";
            this.label288.Size = new System.Drawing.Size(64, 12);
            this.label288.TabIndex = 0;
            this.label288.Text = "采样频率";
            // 
            // label284
            // 
            this.label284.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label284.AutoSize = true;
            this.label284.Location = new System.Drawing.Point(153, 7);
            this.label284.Name = "label284";
            this.label284.Size = new System.Drawing.Size(64, 12);
            this.label284.TabIndex = 392;
            this.label284.Text = "采样分频";
            // 
            // numUpDnSampleFreqOrigin
            // 
            this.numUpDnSampleFreqOrigin.Location = new System.Drawing.Point(73, 3);
            this.numUpDnSampleFreqOrigin.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numUpDnSampleFreqOrigin.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numUpDnSampleFreqOrigin.Name = "numUpDnSampleFreqOrigin";
            this.numUpDnSampleFreqOrigin.Size = new System.Drawing.Size(74, 21);
            this.numUpDnSampleFreqOrigin.TabIndex = 1;
            this.numUpDnSampleFreqOrigin.Value = new decimal(new int[] {
            40000,
            0,
            0,
            0});
            // 
            // numUpDnSampleDiv
            // 
            this.numUpDnSampleDiv.Location = new System.Drawing.Point(223, 3);
            this.numUpDnSampleDiv.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.numUpDnSampleDiv.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numUpDnSampleDiv.Name = "numUpDnSampleDiv";
            this.numUpDnSampleDiv.Size = new System.Drawing.Size(74, 21);
            this.numUpDnSampleDiv.TabIndex = 393;
            this.numUpDnSampleDiv.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnStartGetWaveData
            // 
            this.btnStartGetWaveData.Location = new System.Drawing.Point(449, 3);
            this.btnStartGetWaveData.Name = "btnStartGetWaveData";
            this.btnStartGetWaveData.Size = new System.Drawing.Size(74, 21);
            this.btnStartGetWaveData.TabIndex = 391;
            this.btnStartGetWaveData.Text = "手动采集";
            this.btnStartGetWaveData.UseVisualStyleBackColor = true;
            // 
            // btnClearAllWaveData
            // 
            this.btnClearAllWaveData.Location = new System.Drawing.Point(369, 3);
            this.btnClearAllWaveData.Name = "btnClearAllWaveData";
            this.btnClearAllWaveData.Size = new System.Drawing.Size(74, 21);
            this.btnClearAllWaveData.TabIndex = 384;
            this.btnClearAllWaveData.Text = "清除波形";
            this.btnClearAllWaveData.UseVisualStyleBackColor = true;
            // 
            // groupBox54
            // 
            this.groupBox54.Controls.Add(this.tableLayoutPanel6);
            this.groupBox54.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox54.Location = new System.Drawing.Point(547, 3);
            this.groupBox54.Name = "groupBox54";
            this.groupBox54.Size = new System.Drawing.Size(148, 136);
            this.groupBox54.TabIndex = 2;
            this.groupBox54.TabStop = false;
            this.groupBox54.Text = "采集控制";
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 2;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 61F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.Controls.Add(this.label282, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.comboBoxCh1TrigValId, 1, 0);
            this.tableLayoutPanel6.Controls.Add(this.label281, 0, 1);
            this.tableLayoutPanel6.Controls.Add(this.comboBoxCh1TrigCompareType, 1, 1);
            this.tableLayoutPanel6.Controls.Add(this.label50, 0, 2);
            this.tableLayoutPanel6.Controls.Add(this.textBoxCh1TrigVal, 1, 2);
            this.tableLayoutPanel6.Controls.Add(this.btnStartSingleTrigGetWaveData, 1, 3);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(3, 17);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 4;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 12F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(142, 116);
            this.tableLayoutPanel6.TabIndex = 387;
            // 
            // label282
            // 
            this.label282.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label282.AutoSize = true;
            this.label282.Location = new System.Drawing.Point(3, 9);
            this.label282.Name = "label282";
            this.label282.Size = new System.Drawing.Size(55, 12);
            this.label282.TabIndex = 374;
            this.label282.Text = "信源";
            // 
            // comboBoxCh1TrigValId
            // 
            this.comboBoxCh1TrigValId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxCh1TrigValId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCh1TrigValId.FormattingEnabled = true;
            this.comboBoxCh1TrigValId.Items.AddRange(new object[] {
            "通道1",
            "通道2",
            "通道3",
            "通道4"});
            this.comboBoxCh1TrigValId.Location = new System.Drawing.Point(64, 5);
            this.comboBoxCh1TrigValId.Name = "comboBoxCh1TrigValId";
            this.comboBoxCh1TrigValId.Size = new System.Drawing.Size(75, 20);
            this.comboBoxCh1TrigValId.TabIndex = 375;
            // 
            // label281
            // 
            this.label281.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label281.AutoSize = true;
            this.label281.Location = new System.Drawing.Point(3, 39);
            this.label281.Name = "label281";
            this.label281.Size = new System.Drawing.Size(55, 12);
            this.label281.TabIndex = 376;
            this.label281.Text = "比较";
            // 
            // comboBoxCh1TrigCompareType
            // 
            this.comboBoxCh1TrigCompareType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxCh1TrigCompareType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCh1TrigCompareType.FormattingEnabled = true;
            this.comboBoxCh1TrigCompareType.Location = new System.Drawing.Point(64, 35);
            this.comboBoxCh1TrigCompareType.Name = "comboBoxCh1TrigCompareType";
            this.comboBoxCh1TrigCompareType.Size = new System.Drawing.Size(75, 20);
            this.comboBoxCh1TrigCompareType.TabIndex = 377;
            // 
            // label50
            // 
            this.label50.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label50.AutoSize = true;
            this.label50.Location = new System.Drawing.Point(3, 68);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(55, 12);
            this.label50.TabIndex = 378;
            this.label50.Text = "触发值";
            // 
            // textBoxCh1TrigVal
            // 
            this.textBoxCh1TrigVal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxCh1TrigVal.DecimalPlaces = 3;
            this.textBoxCh1TrigVal.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.textBoxCh1TrigVal.Location = new System.Drawing.Point(64, 63);
            this.textBoxCh1TrigVal.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.textBoxCh1TrigVal.Minimum = new decimal(new int[] {
            100000000,
            0,
            0,
            -2147483648});
            this.textBoxCh1TrigVal.Name = "textBoxCh1TrigVal";
            this.textBoxCh1TrigVal.Size = new System.Drawing.Size(75, 21);
            this.textBoxCh1TrigVal.TabIndex = 387;
            // 
            // btnStartSingleTrigGetWaveData
            // 
            this.btnStartSingleTrigGetWaveData.Location = new System.Drawing.Point(64, 91);
            this.btnStartSingleTrigGetWaveData.Name = "btnStartSingleTrigGetWaveData";
            this.btnStartSingleTrigGetWaveData.Size = new System.Drawing.Size(74, 22);
            this.btnStartSingleTrigGetWaveData.TabIndex = 380;
            this.btnStartSingleTrigGetWaveData.Text = "条件触发";
            this.btnStartSingleTrigGetWaveData.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel10
            // 
            this.tableLayoutPanel10.ColumnCount = 2;
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel10.Controls.Add(this.WaveChart, 0, 0);
            this.tableLayoutPanel10.Controls.Add(this.tableLayoutPanel11, 1, 0);
            this.tableLayoutPanel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel10.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel10.Name = "tableLayoutPanel10";
            this.tableLayoutPanel10.RowCount = 1;
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel10.Size = new System.Drawing.Size(704, 429);
            this.tableLayoutPanel10.TabIndex = 357;
            // 
            // WaveChart
            // 
            this.WaveChart.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea2.CursorX.IsUserEnabled = true;
            chartArea2.CursorX.IsUserSelectionEnabled = true;
            chartArea2.CursorY.IsUserEnabled = true;
            chartArea2.CursorY.IsUserSelectionEnabled = true;
            chartArea2.Name = "ChartArea1";
            this.WaveChart.ChartAreas.Add(chartArea2);
            this.WaveChart.Dock = System.Windows.Forms.DockStyle.Fill;
            legend2.Alignment = System.Drawing.StringAlignment.Center;
            legend2.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            legend2.Name = "Legend1";
            this.WaveChart.Legends.Add(legend2);
            this.WaveChart.Location = new System.Drawing.Point(3, 3);
            this.WaveChart.Name = "WaveChart";
            series5.ChartArea = "ChartArea1";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series5.Legend = "Legend1";
            series5.Name = "通道1";
            series5.YValuesPerPoint = 4;
            series6.ChartArea = "ChartArea1";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series6.Legend = "Legend1";
            series6.Name = "通道2";
            series7.ChartArea = "ChartArea1";
            series7.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series7.Legend = "Legend1";
            series7.Name = "通道3";
            series8.ChartArea = "ChartArea1";
            series8.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series8.Legend = "Legend1";
            series8.Name = "通道4";
            this.WaveChart.Series.Add(series5);
            this.WaveChart.Series.Add(series6);
            this.WaveChart.Series.Add(series7);
            this.WaveChart.Series.Add(series8);
            this.WaveChart.Size = new System.Drawing.Size(548, 423);
            this.WaveChart.TabIndex = 183;
            this.WaveChart.Text = "chart1";
            // 
            // tableLayoutPanel11
            // 
            this.tableLayoutPanel11.ColumnCount = 1;
            this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel11.Controls.Add(this.groupBox67, 0, 0);
            this.tableLayoutPanel11.Controls.Add(this.groupBox68, 0, 1);
            this.tableLayoutPanel11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel11.Location = new System.Drawing.Point(557, 3);
            this.tableLayoutPanel11.Name = "tableLayoutPanel11";
            this.tableLayoutPanel11.RowCount = 2;
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel11.Size = new System.Drawing.Size(144, 423);
            this.tableLayoutPanel11.TabIndex = 184;
            // 
            // groupBox67
            // 
            this.groupBox67.Controls.Add(this.tableLayoutPanel14);
            this.groupBox67.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox67.Location = new System.Drawing.Point(3, 3);
            this.groupBox67.Name = "groupBox67";
            this.groupBox67.Size = new System.Drawing.Size(138, 124);
            this.groupBox67.TabIndex = 0;
            this.groupBox67.TabStop = false;
            this.groupBox67.Text = "测量";
            // 
            // tableLayoutPanel14
            // 
            this.tableLayoutPanel14.ColumnCount = 2;
            this.tableLayoutPanel14.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel14.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel14.Controls.Add(this.button11, 1, 0);
            this.tableLayoutPanel14.Controls.Add(this.comboBox2, 1, 2);
            this.tableLayoutPanel14.Controls.Add(this.label362, 0, 1);
            this.tableLayoutPanel14.Controls.Add(this.label367, 0, 2);
            this.tableLayoutPanel14.Controls.Add(this.comboBox1, 1, 1);
            this.tableLayoutPanel14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel14.Location = new System.Drawing.Point(3, 17);
            this.tableLayoutPanel14.Name = "tableLayoutPanel14";
            this.tableLayoutPanel14.RowCount = 3;
            this.tableLayoutPanel14.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel14.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel14.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel14.Size = new System.Drawing.Size(132, 104);
            this.tableLayoutPanel14.TabIndex = 379;
            // 
            // button11
            // 
            this.button11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button11.Location = new System.Drawing.Point(43, 3);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(86, 27);
            this.button11.TabIndex = 0;
            this.button11.Text = "游标";
            this.button11.UseVisualStyleBackColor = true;
            // 
            // comboBox2
            // 
            this.comboBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "通道1",
            "通道2",
            "通道3",
            "通道4"});
            this.comboBox2.Location = new System.Drawing.Point(43, 75);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(86, 20);
            this.comboBox2.TabIndex = 378;
            // 
            // label362
            // 
            this.label362.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label362.AutoSize = true;
            this.label362.Location = new System.Drawing.Point(3, 43);
            this.label362.Name = "label362";
            this.label362.Size = new System.Drawing.Size(34, 12);
            this.label362.TabIndex = 375;
            this.label362.Text = "信源";
            // 
            // label367
            // 
            this.label367.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label367.AutoSize = true;
            this.label367.Location = new System.Drawing.Point(3, 79);
            this.label367.Name = "label367";
            this.label367.Size = new System.Drawing.Size(34, 12);
            this.label367.TabIndex = 377;
            this.label367.Text = "方向";
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "通道1",
            "通道2",
            "通道3",
            "通道4"});
            this.comboBox1.Location = new System.Drawing.Point(43, 39);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(86, 20);
            this.comboBox1.TabIndex = 376;
            // 
            // groupBox68
            // 
            this.groupBox68.Controls.Add(this.labSamplePeriod);
            this.groupBox68.Controls.Add(this.labSampleFreq);
            this.groupBox68.Controls.Add(this.label371);
            this.groupBox68.Controls.Add(this.label370);
            this.groupBox68.Controls.Add(this.label369);
            this.groupBox68.Controls.Add(this.label368);
            this.groupBox68.Controls.Add(this.label366);
            this.groupBox68.Controls.Add(this.label365);
            this.groupBox68.Controls.Add(this.label364);
            this.groupBox68.Controls.Add(this.label363);
            this.groupBox68.Controls.Add(this.label285);
            this.groupBox68.Controls.Add(this.Mouse_textLab);
            this.groupBox68.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox68.Location = new System.Drawing.Point(3, 133);
            this.groupBox68.Name = "groupBox68";
            this.groupBox68.Size = new System.Drawing.Size(138, 287);
            this.groupBox68.TabIndex = 1;
            this.groupBox68.TabStop = false;
            this.groupBox68.Text = "数据显示";
            // 
            // labSamplePeriod
            // 
            this.labSamplePeriod.AutoSize = true;
            this.labSamplePeriod.Location = new System.Drawing.Point(6, 242);
            this.labSamplePeriod.Name = "labSamplePeriod";
            this.labSamplePeriod.Size = new System.Drawing.Size(113, 12);
            this.labSamplePeriod.TabIndex = 378;
            this.labSamplePeriod.Text = "采样间隔： 0.025ms";
            // 
            // labSampleFreq
            // 
            this.labSampleFreq.AutoSize = true;
            this.labSampleFreq.Location = new System.Drawing.Point(6, 228);
            this.labSampleFreq.Name = "labSampleFreq";
            this.labSampleFreq.Size = new System.Drawing.Size(101, 12);
            this.labSampleFreq.TabIndex = 377;
            this.labSampleFreq.Text = "采样频率： 40KHz";
            // 
            // label371
            // 
            this.label371.AutoSize = true;
            this.label371.Location = new System.Drawing.Point(13, 105);
            this.label371.Name = "label371";
            this.label371.Size = new System.Drawing.Size(41, 12);
            this.label371.TabIndex = 376;
            this.label371.Text = "y4: —";
            // 
            // label370
            // 
            this.label370.AutoSize = true;
            this.label370.Location = new System.Drawing.Point(13, 90);
            this.label370.Name = "label370";
            this.label370.Size = new System.Drawing.Size(41, 12);
            this.label370.TabIndex = 375;
            this.label370.Text = "y3: —";
            // 
            // label369
            // 
            this.label369.AutoSize = true;
            this.label369.Location = new System.Drawing.Point(13, 76);
            this.label369.Name = "label369";
            this.label369.Size = new System.Drawing.Size(41, 12);
            this.label369.TabIndex = 374;
            this.label369.Text = "y2: —";
            // 
            // label368
            // 
            this.label368.AutoSize = true;
            this.label368.Location = new System.Drawing.Point(13, 60);
            this.label368.Name = "label368";
            this.label368.Size = new System.Drawing.Size(41, 12);
            this.label368.TabIndex = 373;
            this.label368.Text = "y1: —";
            // 
            // label366
            // 
            this.label366.AutoSize = true;
            this.label366.Location = new System.Drawing.Point(6, 155);
            this.label366.Name = "label366";
            this.label366.Size = new System.Drawing.Size(77, 12);
            this.label366.TabIndex = 372;
            this.label366.Text = "1/DX = 0.0Hz";
            // 
            // label365
            // 
            this.label365.AutoSize = true;
            this.label365.Location = new System.Drawing.Point(6, 183);
            this.label365.Name = "label365";
            this.label365.Size = new System.Drawing.Size(77, 12);
            this.label365.TabIndex = 371;
            this.label365.Text = "X1 = 18.00ms";
            // 
            // label364
            // 
            this.label364.AutoSize = true;
            this.label364.Location = new System.Drawing.Point(6, 169);
            this.label364.Name = "label364";
            this.label364.Size = new System.Drawing.Size(77, 12);
            this.label364.TabIndex = 370;
            this.label364.Text = "X2 = 18.00ms";
            // 
            // label363
            // 
            this.label363.AutoSize = true;
            this.label363.Location = new System.Drawing.Point(6, 141);
            this.label363.Name = "label363";
            this.label363.Size = new System.Drawing.Size(59, 12);
            this.label363.TabIndex = 369;
            this.label363.Text = "DX = 0.0s";
            // 
            // label285
            // 
            this.label285.AutoSize = true;
            this.label285.Location = new System.Drawing.Point(6, 26);
            this.label285.Name = "label285";
            this.label285.Size = new System.Drawing.Size(53, 12);
            this.label285.TabIndex = 368;
            this.label285.Text = "xy坐标值";
            // 
            // Mouse_textLab
            // 
            this.Mouse_textLab.AutoSize = true;
            this.Mouse_textLab.Location = new System.Drawing.Point(13, 44);
            this.Mouse_textLab.Name = "Mouse_textLab";
            this.Mouse_textLab.Size = new System.Drawing.Size(35, 12);
            this.Mouse_textLab.TabIndex = 367;
            this.Mouse_textLab.Text = "x: —";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.groupBox9);
            this.tabPage4.Controls.Add(this.groupBox5);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(716, 739);
            this.tabPage4.TabIndex = 1;
            this.tabPage4.Text = "PCS在线调试";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.groupBox59);
            this.groupBox9.Controls.Add(this.groupBox40);
            this.groupBox9.Controls.Add(this.groupBox34);
            this.groupBox9.Controls.Add(this.groupBox14);
            this.groupBox9.Controls.Add(this.btnReadAlarm);
            this.groupBox9.Controls.Add(this.btnReadStatus);
            this.groupBox9.Controls.Add(this.groupBox26);
            this.groupBox9.Controls.Add(this.SSS);
            this.groupBox9.Controls.Add(this.groupBox22);
            this.groupBox9.Controls.Add(this.groupBox19);
            this.groupBox9.Controls.Add(this.groupBox18);
            this.groupBox9.Controls.Add(this.groupBox17);
            this.groupBox9.Controls.Add(this.groupBox10);
            this.groupBox9.Controls.Add(this.groupBox12);
            this.groupBox9.Controls.Add(this.groupBox15);
            this.groupBox9.Controls.Add(this.btnGetPcsTemp);
            this.groupBox9.Controls.Add(this.groupBox20);
            this.groupBox9.Controls.Add(this.groupBox21);
            this.groupBox9.Location = new System.Drawing.Point(6, 109);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(602, 502);
            this.groupBox9.TabIndex = 78;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "PCS快捷操作";
            // 
            // groupBox59
            // 
            this.groupBox59.Controls.Add(this.textBoxBmsRunState);
            this.groupBox59.Controls.Add(this.btnGetBmsRunState);
            this.groupBox59.Location = new System.Drawing.Point(139, 434);
            this.groupBox59.Name = "groupBox59";
            this.groupBox59.Size = new System.Drawing.Size(149, 62);
            this.groupBox59.TabIndex = 84;
            this.groupBox59.TabStop = false;
            this.groupBox59.Text = "PCS内部的BMS运行状态";
            // 
            // textBoxBmsRunState
            // 
            this.textBoxBmsRunState.Location = new System.Drawing.Point(10, 16);
            this.textBoxBmsRunState.MaxLength = 8;
            this.textBoxBmsRunState.Name = "textBoxBmsRunState";
            this.textBoxBmsRunState.Size = new System.Drawing.Size(83, 21);
            this.textBoxBmsRunState.TabIndex = 57;
            // 
            // btnGetBmsRunState
            // 
            this.btnGetBmsRunState.Location = new System.Drawing.Point(94, 38);
            this.btnGetBmsRunState.Name = "btnGetBmsRunState";
            this.btnGetBmsRunState.Size = new System.Drawing.Size(39, 20);
            this.btnGetBmsRunState.TabIndex = 67;
            this.btnGetBmsRunState.Text = "回读";
            this.btnGetBmsRunState.UseVisualStyleBackColor = true;
            // 
            // groupBox40
            // 
            this.groupBox40.Controls.Add(this.label280);
            this.groupBox40.Controls.Add(this.textBoxCFG_Q_CTRL_KVAR);
            this.groupBox40.Controls.Add(this.btnGetLimitQ);
            this.groupBox40.Controls.Add(this.btnSetLimitQ);
            this.groupBox40.Location = new System.Drawing.Point(8, 434);
            this.groupBox40.Name = "groupBox40";
            this.groupBox40.Size = new System.Drawing.Size(125, 62);
            this.groupBox40.TabIndex = 83;
            this.groupBox40.TabStop = false;
            this.groupBox40.Text = "无功功率值";
            // 
            // label280
            // 
            this.label280.AutoSize = true;
            this.label280.Location = new System.Drawing.Point(85, 23);
            this.label280.Name = "label280";
            this.label280.Size = new System.Drawing.Size(29, 12);
            this.label280.TabIndex = 68;
            this.label280.Text = "kVar";
            // 
            // textBoxCFG_Q_CTRL_KVAR
            // 
            this.textBoxCFG_Q_CTRL_KVAR.Location = new System.Drawing.Point(10, 16);
            this.textBoxCFG_Q_CTRL_KVAR.MaxLength = 8;
            this.textBoxCFG_Q_CTRL_KVAR.Name = "textBoxCFG_Q_CTRL_KVAR";
            this.textBoxCFG_Q_CTRL_KVAR.Size = new System.Drawing.Size(69, 21);
            this.textBoxCFG_Q_CTRL_KVAR.TabIndex = 57;
            // 
            // btnGetLimitQ
            // 
            this.btnGetLimitQ.Location = new System.Drawing.Point(56, 38);
            this.btnGetLimitQ.Name = "btnGetLimitQ";
            this.btnGetLimitQ.Size = new System.Drawing.Size(39, 20);
            this.btnGetLimitQ.TabIndex = 67;
            this.btnGetLimitQ.Text = "回读";
            this.btnGetLimitQ.UseVisualStyleBackColor = true;
            // 
            // btnSetLimitQ
            // 
            this.btnSetLimitQ.Location = new System.Drawing.Point(8, 38);
            this.btnSetLimitQ.Name = "btnSetLimitQ";
            this.btnSetLimitQ.Size = new System.Drawing.Size(39, 20);
            this.btnSetLimitQ.TabIndex = 56;
            this.btnSetLimitQ.Text = "设置";
            this.btnSetLimitQ.UseVisualStyleBackColor = true;
            // 
            // groupBox34
            // 
            this.groupBox34.Controls.Add(this.comboHeatFilmPwrSup);
            this.groupBox34.Controls.Add(this.btnGetHeatFilmPwrSup);
            this.groupBox34.Controls.Add(this.btnSetHeatFilmPwrSup);
            this.groupBox34.Location = new System.Drawing.Point(474, 78);
            this.groupBox34.Name = "groupBox34";
            this.groupBox34.Size = new System.Drawing.Size(122, 61);
            this.groupBox34.TabIndex = 81;
            this.groupBox34.TabStop = false;
            this.groupBox34.Text = "加热膜供电设置";
            // 
            // comboHeatFilmPwrSup
            // 
            this.comboHeatFilmPwrSup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboHeatFilmPwrSup.FormattingEnabled = true;
            this.comboHeatFilmPwrSup.Location = new System.Drawing.Point(6, 16);
            this.comboHeatFilmPwrSup.Name = "comboHeatFilmPwrSup";
            this.comboHeatFilmPwrSup.Size = new System.Drawing.Size(105, 20);
            this.comboHeatFilmPwrSup.TabIndex = 68;
            // 
            // btnGetHeatFilmPwrSup
            // 
            this.btnGetHeatFilmPwrSup.Location = new System.Drawing.Point(59, 38);
            this.btnGetHeatFilmPwrSup.Name = "btnGetHeatFilmPwrSup";
            this.btnGetHeatFilmPwrSup.Size = new System.Drawing.Size(39, 20);
            this.btnGetHeatFilmPwrSup.TabIndex = 67;
            this.btnGetHeatFilmPwrSup.Text = "回读";
            this.btnGetHeatFilmPwrSup.UseVisualStyleBackColor = true;
            // 
            // btnSetHeatFilmPwrSup
            // 
            this.btnSetHeatFilmPwrSup.Location = new System.Drawing.Point(13, 38);
            this.btnSetHeatFilmPwrSup.Name = "btnSetHeatFilmPwrSup";
            this.btnSetHeatFilmPwrSup.Size = new System.Drawing.Size(39, 20);
            this.btnSetHeatFilmPwrSup.TabIndex = 56;
            this.btnSetHeatFilmPwrSup.Text = "设置";
            this.btnSetHeatFilmPwrSup.UseVisualStyleBackColor = true;
            // 
            // groupBox14
            // 
            this.groupBox14.Controls.Add(this.label85);
            this.groupBox14.Controls.Add(this.textBoxCAlarm2);
            this.groupBox14.Controls.Add(this.textBoxCAlarm1);
            this.groupBox14.Controls.Add(this.label86);
            this.groupBox14.Controls.Add(this.label87);
            this.groupBox14.Controls.Add(this.label82);
            this.groupBox14.Controls.Add(this.textBoxBAlarm2);
            this.groupBox14.Controls.Add(this.textBoxBAlarm1);
            this.groupBox14.Controls.Add(this.label83);
            this.groupBox14.Controls.Add(this.label84);
            this.groupBox14.Controls.Add(this.label81);
            this.groupBox14.Controls.Add(this.textBoxAAlarm2);
            this.groupBox14.Controls.Add(this.textBoxAAlarm1);
            this.groupBox14.Controls.Add(this.label44);
            this.groupBox14.Controls.Add(this.label45);
            this.groupBox14.Location = new System.Drawing.Point(246, 141);
            this.groupBox14.Name = "groupBox14";
            this.groupBox14.Size = new System.Drawing.Size(350, 205);
            this.groupBox14.TabIndex = 70;
            this.groupBox14.TabStop = false;
            this.groupBox14.Text = "故障信息";
            // 
            // label85
            // 
            this.label85.AutoSize = true;
            this.label85.Location = new System.Drawing.Point(8, 142);
            this.label85.Name = "label85";
            this.label85.Size = new System.Drawing.Size(35, 12);
            this.label85.TabIndex = 80;
            this.label85.Text = "C相：";
            // 
            // textBoxCAlarm2
            // 
            this.textBoxCAlarm2.Location = new System.Drawing.Point(54, 178);
            this.textBoxCAlarm2.MaxLength = 8;
            this.textBoxCAlarm2.Name = "textBoxCAlarm2";
            this.textBoxCAlarm2.Size = new System.Drawing.Size(291, 21);
            this.textBoxCAlarm2.TabIndex = 79;
            // 
            // textBoxCAlarm1
            // 
            this.textBoxCAlarm1.Location = new System.Drawing.Point(54, 155);
            this.textBoxCAlarm1.MaxLength = 8;
            this.textBoxCAlarm1.Name = "textBoxCAlarm1";
            this.textBoxCAlarm1.Size = new System.Drawing.Size(291, 21);
            this.textBoxCAlarm1.TabIndex = 78;
            // 
            // label86
            // 
            this.label86.AutoSize = true;
            this.label86.Location = new System.Drawing.Point(6, 182);
            this.label86.Name = "label86";
            this.label86.Size = new System.Drawing.Size(47, 12);
            this.label86.TabIndex = 77;
            this.label86.Text = "告警组2";
            // 
            // label87
            // 
            this.label87.AutoSize = true;
            this.label87.Location = new System.Drawing.Point(6, 161);
            this.label87.Name = "label87";
            this.label87.Size = new System.Drawing.Size(47, 12);
            this.label87.TabIndex = 76;
            this.label87.Text = "告警组1";
            // 
            // label82
            // 
            this.label82.AutoSize = true;
            this.label82.Location = new System.Drawing.Point(8, 80);
            this.label82.Name = "label82";
            this.label82.Size = new System.Drawing.Size(35, 12);
            this.label82.TabIndex = 75;
            this.label82.Text = "B相：";
            // 
            // textBoxBAlarm2
            // 
            this.textBoxBAlarm2.Location = new System.Drawing.Point(54, 116);
            this.textBoxBAlarm2.MaxLength = 8;
            this.textBoxBAlarm2.Name = "textBoxBAlarm2";
            this.textBoxBAlarm2.Size = new System.Drawing.Size(291, 21);
            this.textBoxBAlarm2.TabIndex = 74;
            // 
            // textBoxBAlarm1
            // 
            this.textBoxBAlarm1.Location = new System.Drawing.Point(54, 93);
            this.textBoxBAlarm1.MaxLength = 8;
            this.textBoxBAlarm1.Name = "textBoxBAlarm1";
            this.textBoxBAlarm1.Size = new System.Drawing.Size(291, 21);
            this.textBoxBAlarm1.TabIndex = 73;
            // 
            // label83
            // 
            this.label83.AutoSize = true;
            this.label83.Location = new System.Drawing.Point(6, 120);
            this.label83.Name = "label83";
            this.label83.Size = new System.Drawing.Size(47, 12);
            this.label83.TabIndex = 72;
            this.label83.Text = "告警组2";
            // 
            // label84
            // 
            this.label84.AutoSize = true;
            this.label84.Location = new System.Drawing.Point(6, 99);
            this.label84.Name = "label84";
            this.label84.Size = new System.Drawing.Size(47, 12);
            this.label84.TabIndex = 71;
            this.label84.Text = "告警组1";
            // 
            // label81
            // 
            this.label81.AutoSize = true;
            this.label81.Location = new System.Drawing.Point(7, 17);
            this.label81.Name = "label81";
            this.label81.Size = new System.Drawing.Size(35, 12);
            this.label81.TabIndex = 70;
            this.label81.Text = "A相：";
            // 
            // textBoxAAlarm2
            // 
            this.textBoxAAlarm2.Location = new System.Drawing.Point(54, 52);
            this.textBoxAAlarm2.MaxLength = 8;
            this.textBoxAAlarm2.Name = "textBoxAAlarm2";
            this.textBoxAAlarm2.Size = new System.Drawing.Size(291, 21);
            this.textBoxAAlarm2.TabIndex = 69;
            // 
            // textBoxAAlarm1
            // 
            this.textBoxAAlarm1.Location = new System.Drawing.Point(54, 29);
            this.textBoxAAlarm1.MaxLength = 8;
            this.textBoxAAlarm1.Name = "textBoxAAlarm1";
            this.textBoxAAlarm1.Size = new System.Drawing.Size(291, 21);
            this.textBoxAAlarm1.TabIndex = 68;
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Location = new System.Drawing.Point(5, 57);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(47, 12);
            this.label44.TabIndex = 58;
            this.label44.Text = "告警组2";
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Location = new System.Drawing.Point(5, 35);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(47, 12);
            this.label45.TabIndex = 57;
            this.label45.Text = "告警组1";
            // 
            // btnReadAlarm
            // 
            this.btnReadAlarm.Location = new System.Drawing.Point(314, 347);
            this.btnReadAlarm.Name = "btnReadAlarm";
            this.btnReadAlarm.Size = new System.Drawing.Size(216, 23);
            this.btnReadAlarm.TabIndex = 57;
            this.btnReadAlarm.Text = "读取三相/单相告警";
            this.btnReadAlarm.UseVisualStyleBackColor = true;
            // 
            // btnReadStatus
            // 
            this.btnReadStatus.Location = new System.Drawing.Point(36, 347);
            this.btnReadStatus.Name = "btnReadStatus";
            this.btnReadStatus.Size = new System.Drawing.Size(172, 23);
            this.btnReadStatus.TabIndex = 57;
            this.btnReadStatus.Text = "读取单相/三相状态机";
            this.btnReadStatus.UseVisualStyleBackColor = true;
            // 
            // groupBox26
            // 
            this.groupBox26.Controls.Add(this.label60);
            this.groupBox26.Controls.Add(this.comboBoxParticularPara);
            this.groupBox26.Controls.Add(this.textBoxPartiParaValue);
            this.groupBox26.Controls.Add(this.btnGetParticularPara);
            this.groupBox26.Controls.Add(this.btnSetParticularPara);
            this.groupBox26.Location = new System.Drawing.Point(246, 78);
            this.groupBox26.Name = "groupBox26";
            this.groupBox26.Size = new System.Drawing.Size(222, 61);
            this.groupBox26.TabIndex = 80;
            this.groupBox26.TabStop = false;
            this.groupBox26.Text = "特殊参数设置";
            // 
            // label60
            // 
            this.label60.AutoSize = true;
            this.label60.Location = new System.Drawing.Point(91, 41);
            this.label60.Name = "label60";
            this.label60.Size = new System.Drawing.Size(35, 12);
            this.label60.TabIndex = 69;
            this.label60.Text = "pu/ms";
            // 
            // comboBoxParticularPara
            // 
            this.comboBoxParticularPara.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxParticularPara.FormattingEnabled = true;
            this.comboBoxParticularPara.Location = new System.Drawing.Point(6, 14);
            this.comboBoxParticularPara.Name = "comboBoxParticularPara";
            this.comboBoxParticularPara.Size = new System.Drawing.Size(167, 20);
            this.comboBoxParticularPara.TabIndex = 68;
            // 
            // textBoxPartiParaValue
            // 
            this.textBoxPartiParaValue.Location = new System.Drawing.Point(5, 36);
            this.textBoxPartiParaValue.MaxLength = 8;
            this.textBoxPartiParaValue.Name = "textBoxPartiParaValue";
            this.textBoxPartiParaValue.Size = new System.Drawing.Size(80, 21);
            this.textBoxPartiParaValue.TabIndex = 57;
            // 
            // btnGetParticularPara
            // 
            this.btnGetParticularPara.Location = new System.Drawing.Point(175, 38);
            this.btnGetParticularPara.Name = "btnGetParticularPara";
            this.btnGetParticularPara.Size = new System.Drawing.Size(39, 20);
            this.btnGetParticularPara.TabIndex = 67;
            this.btnGetParticularPara.Text = "回读";
            this.btnGetParticularPara.UseVisualStyleBackColor = true;
            // 
            // btnSetParticularPara
            // 
            this.btnSetParticularPara.Location = new System.Drawing.Point(130, 38);
            this.btnSetParticularPara.Name = "btnSetParticularPara";
            this.btnSetParticularPara.Size = new System.Drawing.Size(39, 20);
            this.btnSetParticularPara.TabIndex = 56;
            this.btnSetParticularPara.Text = "设置";
            this.btnSetParticularPara.UseVisualStyleBackColor = true;
            // 
            // SSS
            // 
            this.SSS.Controls.Add(this.labelCStandbyStep);
            this.SSS.Controls.Add(this.labelBStandbyStep);
            this.SSS.Controls.Add(this.labelAStandbyStep);
            this.SSS.Controls.Add(this.label74);
            this.SSS.Controls.Add(this.txtCFsmStatus);
            this.SSS.Controls.Add(this.label75);
            this.SSS.Controls.Add(this.labelCShutDownStep);
            this.SSS.Controls.Add(this.labelCRunStep);
            this.SSS.Controls.Add(this.labelCStartStep);
            this.SSS.Controls.Add(this.labelCIdleStep);
            this.SSS.Controls.Add(this.lableCInitStep);
            this.SSS.Controls.Add(this.label67);
            this.SSS.Controls.Add(this.txtBFsmStatus);
            this.SSS.Controls.Add(this.label68);
            this.SSS.Controls.Add(this.labelBShutDownStep);
            this.SSS.Controls.Add(this.labelBRunStep);
            this.SSS.Controls.Add(this.labelBStartStep);
            this.SSS.Controls.Add(this.labelBIdleStep);
            this.SSS.Controls.Add(this.lableBInitStep);
            this.SSS.Controls.Add(this.label58);
            this.SSS.Controls.Add(this.txtAFsmStatus);
            this.SSS.Controls.Add(this.label22);
            this.SSS.Controls.Add(this.labelAShutDownStep);
            this.SSS.Controls.Add(this.labelARunStep);
            this.SSS.Controls.Add(this.labelAStartStep);
            this.SSS.Controls.Add(this.labelAIdleStep);
            this.SSS.Controls.Add(this.lableAInitStep);
            this.SSS.Location = new System.Drawing.Point(8, 141);
            this.SSS.Name = "SSS";
            this.SSS.Size = new System.Drawing.Size(232, 205);
            this.SSS.TabIndex = 69;
            this.SSS.TabStop = false;
            this.SSS.Text = "运行状态机";
            // 
            // labelCStandbyStep
            // 
            this.labelCStandbyStep.AutoSize = true;
            this.labelCStandbyStep.Location = new System.Drawing.Point(67, 188);
            this.labelCStandbyStep.Name = "labelCStandbyStep";
            this.labelCStandbyStep.Size = new System.Drawing.Size(71, 12);
            this.labelCStandbyStep.TabIndex = 82;
            this.labelCStandbyStep.Text = "standbyStep";
            // 
            // labelBStandbyStep
            // 
            this.labelBStandbyStep.AutoSize = true;
            this.labelBStandbyStep.Location = new System.Drawing.Point(67, 130);
            this.labelBStandbyStep.Name = "labelBStandbyStep";
            this.labelBStandbyStep.Size = new System.Drawing.Size(71, 12);
            this.labelBStandbyStep.TabIndex = 81;
            this.labelBStandbyStep.Text = "standbyStep";
            // 
            // labelAStandbyStep
            // 
            this.labelAStandbyStep.AutoSize = true;
            this.labelAStandbyStep.Location = new System.Drawing.Point(67, 68);
            this.labelAStandbyStep.Name = "labelAStandbyStep";
            this.labelAStandbyStep.Size = new System.Drawing.Size(71, 12);
            this.labelAStandbyStep.TabIndex = 80;
            this.labelAStandbyStep.Text = "standbyStep";
            // 
            // label74
            // 
            this.label74.AutoSize = true;
            this.label74.Location = new System.Drawing.Point(8, 140);
            this.label74.Name = "label74";
            this.label74.Size = new System.Drawing.Size(35, 12);
            this.label74.TabIndex = 79;
            this.label74.Text = "C相：";
            // 
            // txtCFsmStatus
            // 
            this.txtCFsmStatus.Location = new System.Drawing.Point(79, 149);
            this.txtCFsmStatus.MaxLength = 8;
            this.txtCFsmStatus.Name = "txtCFsmStatus";
            this.txtCFsmStatus.Size = new System.Drawing.Size(73, 21);
            this.txtCFsmStatus.TabIndex = 78;
            // 
            // label75
            // 
            this.label75.AutoSize = true;
            this.label75.Location = new System.Drawing.Point(5, 155);
            this.label75.Name = "label75";
            this.label75.Size = new System.Drawing.Size(59, 12);
            this.label75.TabIndex = 77;
            this.label75.Text = "fsmStatus";
            // 
            // labelCShutDownStep
            // 
            this.labelCShutDownStep.AutoSize = true;
            this.labelCShutDownStep.Location = new System.Drawing.Point(147, 186);
            this.labelCShutDownStep.Name = "labelCShutDownStep";
            this.labelCShutDownStep.Size = new System.Drawing.Size(77, 12);
            this.labelCShutDownStep.TabIndex = 76;
            this.labelCShutDownStep.Text = "shutDownStep";
            // 
            // labelCRunStep
            // 
            this.labelCRunStep.AutoSize = true;
            this.labelCRunStep.Location = new System.Drawing.Point(6, 188);
            this.labelCRunStep.Name = "labelCRunStep";
            this.labelCRunStep.Size = new System.Drawing.Size(47, 12);
            this.labelCRunStep.TabIndex = 75;
            this.labelCRunStep.Text = "runStep";
            // 
            // labelCStartStep
            // 
            this.labelCStartStep.AutoSize = true;
            this.labelCStartStep.Location = new System.Drawing.Point(147, 171);
            this.labelCStartStep.Name = "labelCStartStep";
            this.labelCStartStep.Size = new System.Drawing.Size(59, 12);
            this.labelCStartStep.TabIndex = 74;
            this.labelCStartStep.Text = "startStep";
            // 
            // labelCIdleStep
            // 
            this.labelCIdleStep.AutoSize = true;
            this.labelCIdleStep.Location = new System.Drawing.Point(67, 171);
            this.labelCIdleStep.Name = "labelCIdleStep";
            this.labelCIdleStep.Size = new System.Drawing.Size(53, 12);
            this.labelCIdleStep.TabIndex = 72;
            this.labelCIdleStep.Text = "idleStep";
            // 
            // lableCInitStep
            // 
            this.lableCInitStep.AutoSize = true;
            this.lableCInitStep.Location = new System.Drawing.Point(5, 171);
            this.lableCInitStep.Name = "lableCInitStep";
            this.lableCInitStep.Size = new System.Drawing.Size(53, 12);
            this.lableCInitStep.TabIndex = 73;
            this.lableCInitStep.Text = "initStep";
            // 
            // label67
            // 
            this.label67.AutoSize = true;
            this.label67.Location = new System.Drawing.Point(8, 79);
            this.label67.Name = "label67";
            this.label67.Size = new System.Drawing.Size(35, 12);
            this.label67.TabIndex = 71;
            this.label67.Text = "B相：";
            // 
            // txtBFsmStatus
            // 
            this.txtBFsmStatus.Location = new System.Drawing.Point(79, 88);
            this.txtBFsmStatus.MaxLength = 8;
            this.txtBFsmStatus.Name = "txtBFsmStatus";
            this.txtBFsmStatus.Size = new System.Drawing.Size(73, 21);
            this.txtBFsmStatus.TabIndex = 70;
            // 
            // label68
            // 
            this.label68.AutoSize = true;
            this.label68.Location = new System.Drawing.Point(5, 94);
            this.label68.Name = "label68";
            this.label68.Size = new System.Drawing.Size(59, 12);
            this.label68.TabIndex = 69;
            this.label68.Text = "fsmStatus";
            // 
            // labelBShutDownStep
            // 
            this.labelBShutDownStep.AutoSize = true;
            this.labelBShutDownStep.Location = new System.Drawing.Point(147, 130);
            this.labelBShutDownStep.Name = "labelBShutDownStep";
            this.labelBShutDownStep.Size = new System.Drawing.Size(77, 12);
            this.labelBShutDownStep.TabIndex = 68;
            this.labelBShutDownStep.Text = "shutDownStep";
            // 
            // labelBRunStep
            // 
            this.labelBRunStep.AutoSize = true;
            this.labelBRunStep.Location = new System.Drawing.Point(6, 127);
            this.labelBRunStep.Name = "labelBRunStep";
            this.labelBRunStep.Size = new System.Drawing.Size(47, 12);
            this.labelBRunStep.TabIndex = 67;
            this.labelBRunStep.Text = "runStep";
            // 
            // labelBStartStep
            // 
            this.labelBStartStep.AutoSize = true;
            this.labelBStartStep.Location = new System.Drawing.Point(147, 110);
            this.labelBStartStep.Name = "labelBStartStep";
            this.labelBStartStep.Size = new System.Drawing.Size(59, 12);
            this.labelBStartStep.TabIndex = 66;
            this.labelBStartStep.Text = "startStep";
            // 
            // labelBIdleStep
            // 
            this.labelBIdleStep.AutoSize = true;
            this.labelBIdleStep.Location = new System.Drawing.Point(67, 110);
            this.labelBIdleStep.Name = "labelBIdleStep";
            this.labelBIdleStep.Size = new System.Drawing.Size(53, 12);
            this.labelBIdleStep.TabIndex = 64;
            this.labelBIdleStep.Text = "idleStep";
            // 
            // lableBInitStep
            // 
            this.lableBInitStep.AutoSize = true;
            this.lableBInitStep.Location = new System.Drawing.Point(5, 110);
            this.lableBInitStep.Name = "lableBInitStep";
            this.lableBInitStep.Size = new System.Drawing.Size(53, 12);
            this.lableBInitStep.TabIndex = 65;
            this.lableBInitStep.Text = "initStep";
            // 
            // label58
            // 
            this.label58.AutoSize = true;
            this.label58.Location = new System.Drawing.Point(8, 16);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(35, 12);
            this.label58.TabIndex = 63;
            this.label58.Text = "A相：";
            // 
            // txtAFsmStatus
            // 
            this.txtAFsmStatus.Location = new System.Drawing.Point(79, 25);
            this.txtAFsmStatus.MaxLength = 8;
            this.txtAFsmStatus.Name = "txtAFsmStatus";
            this.txtAFsmStatus.Size = new System.Drawing.Size(73, 21);
            this.txtAFsmStatus.TabIndex = 62;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(5, 31);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(59, 12);
            this.label22.TabIndex = 61;
            this.label22.Text = "fsmStatus";
            // 
            // labelAShutDownStep
            // 
            this.labelAShutDownStep.AutoSize = true;
            this.labelAShutDownStep.Location = new System.Drawing.Point(147, 68);
            this.labelAShutDownStep.Name = "labelAShutDownStep";
            this.labelAShutDownStep.Size = new System.Drawing.Size(77, 12);
            this.labelAShutDownStep.TabIndex = 60;
            this.labelAShutDownStep.Text = "shutDownStep";
            // 
            // labelARunStep
            // 
            this.labelARunStep.AutoSize = true;
            this.labelARunStep.Location = new System.Drawing.Point(6, 64);
            this.labelARunStep.Name = "labelARunStep";
            this.labelARunStep.Size = new System.Drawing.Size(47, 12);
            this.labelARunStep.TabIndex = 59;
            this.labelARunStep.Text = "runStep";
            // 
            // labelAStartStep
            // 
            this.labelAStartStep.AutoSize = true;
            this.labelAStartStep.Location = new System.Drawing.Point(147, 47);
            this.labelAStartStep.Name = "labelAStartStep";
            this.labelAStartStep.Size = new System.Drawing.Size(59, 12);
            this.labelAStartStep.TabIndex = 58;
            this.labelAStartStep.Text = "startStep";
            // 
            // labelAIdleStep
            // 
            this.labelAIdleStep.AutoSize = true;
            this.labelAIdleStep.Location = new System.Drawing.Point(67, 47);
            this.labelAIdleStep.Name = "labelAIdleStep";
            this.labelAIdleStep.Size = new System.Drawing.Size(53, 12);
            this.labelAIdleStep.TabIndex = 57;
            this.labelAIdleStep.Text = "idleStep";
            // 
            // lableAInitStep
            // 
            this.lableAInitStep.AutoSize = true;
            this.lableAInitStep.Location = new System.Drawing.Point(5, 47);
            this.lableAInitStep.Name = "lableAInitStep";
            this.lableAInitStep.Size = new System.Drawing.Size(53, 12);
            this.lableAInitStep.TabIndex = 57;
            this.lableAInitStep.Text = "initStep";
            // 
            // groupBox22
            // 
            this.groupBox22.Controls.Add(this.textBoxCfg_Q_CTRL_PF);
            this.groupBox22.Controls.Add(this.btnCfg_Q_CTRL_PF_R);
            this.groupBox22.Controls.Add(this.btnCfg_Q_CTRL_PF_W);
            this.groupBox22.Location = new System.Drawing.Point(477, 16);
            this.groupBox22.Name = "groupBox22";
            this.groupBox22.Size = new System.Drawing.Size(119, 60);
            this.groupBox22.TabIndex = 71;
            this.groupBox22.TabStop = false;
            this.groupBox22.Text = "无功PF值调度";
            // 
            // textBoxCfg_Q_CTRL_PF
            // 
            this.textBoxCfg_Q_CTRL_PF.Location = new System.Drawing.Point(10, 16);
            this.textBoxCfg_Q_CTRL_PF.MaxLength = 8;
            this.textBoxCfg_Q_CTRL_PF.Name = "textBoxCfg_Q_CTRL_PF";
            this.textBoxCfg_Q_CTRL_PF.Size = new System.Drawing.Size(69, 21);
            this.textBoxCfg_Q_CTRL_PF.TabIndex = 57;
            // 
            // btnCfg_Q_CTRL_PF_R
            // 
            this.btnCfg_Q_CTRL_PF_R.Location = new System.Drawing.Point(56, 38);
            this.btnCfg_Q_CTRL_PF_R.Name = "btnCfg_Q_CTRL_PF_R";
            this.btnCfg_Q_CTRL_PF_R.Size = new System.Drawing.Size(39, 20);
            this.btnCfg_Q_CTRL_PF_R.TabIndex = 67;
            this.btnCfg_Q_CTRL_PF_R.Text = "回读";
            this.btnCfg_Q_CTRL_PF_R.UseVisualStyleBackColor = true;
            // 
            // btnCfg_Q_CTRL_PF_W
            // 
            this.btnCfg_Q_CTRL_PF_W.Location = new System.Drawing.Point(8, 38);
            this.btnCfg_Q_CTRL_PF_W.Name = "btnCfg_Q_CTRL_PF_W";
            this.btnCfg_Q_CTRL_PF_W.Size = new System.Drawing.Size(39, 20);
            this.btnCfg_Q_CTRL_PF_W.TabIndex = 56;
            this.btnCfg_Q_CTRL_PF_W.Text = "设置";
            this.btnCfg_Q_CTRL_PF_W.UseVisualStyleBackColor = true;
            // 
            // groupBox19
            // 
            this.groupBox19.Controls.Add(this.label32);
            this.groupBox19.Controls.Add(this.label33);
            this.groupBox19.Controls.Add(this.txtCSecTemp);
            this.groupBox19.Controls.Add(this.label34);
            this.groupBox19.Controls.Add(this.label35);
            this.groupBox19.Controls.Add(this.txtCPriTemp);
            this.groupBox19.Location = new System.Drawing.Point(352, 372);
            this.groupBox19.Name = "groupBox19";
            this.groupBox19.Size = new System.Drawing.Size(170, 61);
            this.groupBox19.TabIndex = 75;
            this.groupBox19.TabStop = false;
            this.groupBox19.Text = "C相NTC温度";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(6, 39);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(53, 12);
            this.label32.TabIndex = 71;
            this.label32.Text = "副边温度";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(138, 39);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(17, 12);
            this.label33.TabIndex = 69;
            this.label33.Text = "℃";
            // 
            // txtCSecTemp
            // 
            this.txtCSecTemp.Location = new System.Drawing.Point(60, 34);
            this.txtCSecTemp.MaxLength = 8;
            this.txtCSecTemp.Name = "txtCSecTemp";
            this.txtCSecTemp.Size = new System.Drawing.Size(73, 21);
            this.txtCSecTemp.TabIndex = 70;
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(6, 16);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(53, 12);
            this.label34.TabIndex = 68;
            this.label34.Text = "原边温度";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(138, 16);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(17, 12);
            this.label35.TabIndex = 57;
            this.label35.Text = "℃";
            // 
            // txtCPriTemp
            // 
            this.txtCPriTemp.Location = new System.Drawing.Point(60, 12);
            this.txtCPriTemp.MaxLength = 8;
            this.txtCPriTemp.Name = "txtCPriTemp";
            this.txtCPriTemp.Size = new System.Drawing.Size(73, 21);
            this.txtCPriTemp.TabIndex = 57;
            // 
            // groupBox18
            // 
            this.groupBox18.Controls.Add(this.label21);
            this.groupBox18.Controls.Add(this.label23);
            this.groupBox18.Controls.Add(this.txtBSecTemp);
            this.groupBox18.Controls.Add(this.label24);
            this.groupBox18.Controls.Add(this.label25);
            this.groupBox18.Controls.Add(this.txtBPriTemp);
            this.groupBox18.Location = new System.Drawing.Point(179, 372);
            this.groupBox18.Name = "groupBox18";
            this.groupBox18.Size = new System.Drawing.Size(162, 61);
            this.groupBox18.TabIndex = 75;
            this.groupBox18.TabStop = false;
            this.groupBox18.Text = "B相NTC温度";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(6, 40);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(53, 12);
            this.label21.TabIndex = 71;
            this.label21.Text = "副边温度";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(138, 40);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(17, 12);
            this.label23.TabIndex = 69;
            this.label23.Text = "℃";
            // 
            // txtBSecTemp
            // 
            this.txtBSecTemp.Location = new System.Drawing.Point(59, 35);
            this.txtBSecTemp.MaxLength = 8;
            this.txtBSecTemp.Name = "txtBSecTemp";
            this.txtBSecTemp.Size = new System.Drawing.Size(73, 21);
            this.txtBSecTemp.TabIndex = 70;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(6, 17);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(53, 12);
            this.label24.TabIndex = 68;
            this.label24.Text = "原边温度";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(138, 17);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(17, 12);
            this.label25.TabIndex = 57;
            this.label25.Text = "℃";
            // 
            // txtBPriTemp
            // 
            this.txtBPriTemp.Location = new System.Drawing.Point(59, 13);
            this.txtBPriTemp.MaxLength = 8;
            this.txtBPriTemp.Name = "txtBPriTemp";
            this.txtBPriTemp.Size = new System.Drawing.Size(73, 21);
            this.txtBPriTemp.TabIndex = 57;
            // 
            // groupBox17
            // 
            this.groupBox17.Controls.Add(this.label37);
            this.groupBox17.Controls.Add(this.label38);
            this.groupBox17.Controls.Add(this.txtASecTemp);
            this.groupBox17.Controls.Add(this.label39);
            this.groupBox17.Controls.Add(this.label40);
            this.groupBox17.Controls.Add(this.txtAPriTemp);
            this.groupBox17.Location = new System.Drawing.Point(8, 372);
            this.groupBox17.Name = "groupBox17";
            this.groupBox17.Size = new System.Drawing.Size(162, 61);
            this.groupBox17.TabIndex = 70;
            this.groupBox17.TabStop = false;
            this.groupBox17.Text = "A相NTC温度";
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(6, 40);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(53, 12);
            this.label37.TabIndex = 71;
            this.label37.Text = "副边温度";
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(138, 40);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(17, 12);
            this.label38.TabIndex = 69;
            this.label38.Text = "℃";
            // 
            // txtASecTemp
            // 
            this.txtASecTemp.Location = new System.Drawing.Point(59, 35);
            this.txtASecTemp.MaxLength = 8;
            this.txtASecTemp.Name = "txtASecTemp";
            this.txtASecTemp.Size = new System.Drawing.Size(73, 21);
            this.txtASecTemp.TabIndex = 70;
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(6, 17);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(53, 12);
            this.label39.TabIndex = 68;
            this.label39.Text = "原边温度";
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(138, 17);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(17, 12);
            this.label40.TabIndex = 57;
            this.label40.Text = "℃";
            // 
            // txtAPriTemp
            // 
            this.txtAPriTemp.Location = new System.Drawing.Point(59, 13);
            this.txtAPriTemp.MaxLength = 8;
            this.txtAPriTemp.Name = "txtAPriTemp";
            this.txtAPriTemp.Size = new System.Drawing.Size(73, 21);
            this.txtAPriTemp.TabIndex = 57;
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.label46);
            this.groupBox10.Controls.Add(this.textBoxActivePower);
            this.groupBox10.Controls.Add(this.btnGetActivePower);
            this.groupBox10.Location = new System.Drawing.Point(360, 16);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(108, 61);
            this.groupBox10.TabIndex = 70;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "输出有功功率";
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.Location = new System.Drawing.Point(81, 20);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(17, 12);
            this.label46.TabIndex = 57;
            this.label46.Text = "kW";
            // 
            // textBoxActivePower
            // 
            this.textBoxActivePower.Location = new System.Drawing.Point(6, 16);
            this.textBoxActivePower.MaxLength = 8;
            this.textBoxActivePower.Name = "textBoxActivePower";
            this.textBoxActivePower.Size = new System.Drawing.Size(69, 21);
            this.textBoxActivePower.TabIndex = 57;
            // 
            // btnGetActivePower
            // 
            this.btnGetActivePower.Location = new System.Drawing.Point(53, 38);
            this.btnGetActivePower.Name = "btnGetActivePower";
            this.btnGetActivePower.Size = new System.Drawing.Size(39, 21);
            this.btnGetActivePower.TabIndex = 67;
            this.btnGetActivePower.Text = "回读";
            this.btnGetActivePower.UseVisualStyleBackColor = true;
            // 
            // groupBox12
            // 
            this.groupBox12.Controls.Add(this.btnGetInvMode);
            this.groupBox12.Controls.Add(this.btnSetInvMode);
            this.groupBox12.Controls.Add(this.radioButtonOffGrid);
            this.groupBox12.Controls.Add(this.radioButtonOnGrid);
            this.groupBox12.Location = new System.Drawing.Point(132, 78);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new System.Drawing.Size(107, 61);
            this.groupBox12.TabIndex = 68;
            this.groupBox12.TabStop = false;
            this.groupBox12.Text = "逆变模式";
            // 
            // btnGetInvMode
            // 
            this.btnGetInvMode.Location = new System.Drawing.Point(64, 36);
            this.btnGetInvMode.Name = "btnGetInvMode";
            this.btnGetInvMode.Size = new System.Drawing.Size(39, 22);
            this.btnGetInvMode.TabIndex = 67;
            this.btnGetInvMode.Text = "回读";
            this.btnGetInvMode.UseVisualStyleBackColor = true;
            // 
            // btnSetInvMode
            // 
            this.btnSetInvMode.Location = new System.Drawing.Point(63, 13);
            this.btnSetInvMode.Name = "btnSetInvMode";
            this.btnSetInvMode.Size = new System.Drawing.Size(39, 22);
            this.btnSetInvMode.TabIndex = 56;
            this.btnSetInvMode.Text = "设置";
            this.btnSetInvMode.UseVisualStyleBackColor = true;
            // 
            // radioButtonOffGrid
            // 
            this.radioButtonOffGrid.AutoSize = true;
            this.radioButtonOffGrid.Location = new System.Drawing.Point(7, 39);
            this.radioButtonOffGrid.Name = "radioButtonOffGrid";
            this.radioButtonOffGrid.Size = new System.Drawing.Size(47, 16);
            this.radioButtonOffGrid.TabIndex = 64;
            this.radioButtonOffGrid.TabStop = true;
            this.radioButtonOffGrid.Text = "离网";
            this.radioButtonOffGrid.UseVisualStyleBackColor = true;
            // 
            // radioButtonOnGrid
            // 
            this.radioButtonOnGrid.AutoSize = true;
            this.radioButtonOnGrid.Location = new System.Drawing.Point(7, 19);
            this.radioButtonOnGrid.Name = "radioButtonOnGrid";
            this.radioButtonOnGrid.Size = new System.Drawing.Size(47, 16);
            this.radioButtonOnGrid.TabIndex = 63;
            this.radioButtonOnGrid.TabStop = true;
            this.radioButtonOnGrid.Text = "并网";
            this.radioButtonOnGrid.UseVisualStyleBackColor = true;
            // 
            // groupBox15
            // 
            this.groupBox15.Controls.Add(this.label48);
            this.groupBox15.Controls.Add(this.textBoxChgDisChgLimitPower);
            this.groupBox15.Controls.Add(this.btnGetChgDisChgLimitPower);
            this.groupBox15.Controls.Add(this.btnSetChgDisChgLimitPower);
            this.groupBox15.Location = new System.Drawing.Point(246, 15);
            this.groupBox15.Name = "groupBox15";
            this.groupBox15.Size = new System.Drawing.Size(108, 62);
            this.groupBox15.TabIndex = 69;
            this.groupBox15.TabStop = false;
            this.groupBox15.Text = "充放电功率值";
            // 
            // label48
            // 
            this.label48.AutoSize = true;
            this.label48.Location = new System.Drawing.Point(83, 22);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(17, 12);
            this.label48.TabIndex = 57;
            this.label48.Text = "kW";
            // 
            // textBoxChgDisChgLimitPower
            // 
            this.textBoxChgDisChgLimitPower.Location = new System.Drawing.Point(8, 16);
            this.textBoxChgDisChgLimitPower.MaxLength = 8;
            this.textBoxChgDisChgLimitPower.Name = "textBoxChgDisChgLimitPower";
            this.textBoxChgDisChgLimitPower.Size = new System.Drawing.Size(69, 21);
            this.textBoxChgDisChgLimitPower.TabIndex = 57;
            // 
            // btnGetChgDisChgLimitPower
            // 
            this.btnGetChgDisChgLimitPower.Location = new System.Drawing.Point(56, 39);
            this.btnGetChgDisChgLimitPower.Name = "btnGetChgDisChgLimitPower";
            this.btnGetChgDisChgLimitPower.Size = new System.Drawing.Size(39, 20);
            this.btnGetChgDisChgLimitPower.TabIndex = 67;
            this.btnGetChgDisChgLimitPower.Text = "回读";
            this.btnGetChgDisChgLimitPower.UseVisualStyleBackColor = true;
            // 
            // btnSetChgDisChgLimitPower
            // 
            this.btnSetChgDisChgLimitPower.Location = new System.Drawing.Point(8, 39);
            this.btnSetChgDisChgLimitPower.Name = "btnSetChgDisChgLimitPower";
            this.btnSetChgDisChgLimitPower.Size = new System.Drawing.Size(39, 20);
            this.btnSetChgDisChgLimitPower.TabIndex = 56;
            this.btnSetChgDisChgLimitPower.Text = "设置";
            this.btnSetChgDisChgLimitPower.UseVisualStyleBackColor = true;
            // 
            // btnGetPcsTemp
            // 
            this.btnGetPcsTemp.Location = new System.Drawing.Point(536, 377);
            this.btnGetPcsTemp.Name = "btnGetPcsTemp";
            this.btnGetPcsTemp.Size = new System.Drawing.Size(44, 51);
            this.btnGetPcsTemp.TabIndex = 67;
            this.btnGetPcsTemp.Text = "读取温度";
            this.btnGetPcsTemp.UseVisualStyleBackColor = true;
            // 
            // groupBox20
            // 
            this.groupBox20.Controls.Add(this.btnGetTurnOnOff);
            this.groupBox20.Controls.Add(this.btnSetTurnOnOff);
            this.groupBox20.Controls.Add(this.radioButtonTurnOff);
            this.groupBox20.Controls.Add(this.radioButtonTurnOn);
            this.groupBox20.Location = new System.Drawing.Point(132, 15);
            this.groupBox20.Name = "groupBox20";
            this.groupBox20.Size = new System.Drawing.Size(107, 62);
            this.groupBox20.TabIndex = 68;
            this.groupBox20.TabStop = false;
            this.groupBox20.Text = "开关机指令";
            // 
            // btnGetTurnOnOff
            // 
            this.btnGetTurnOnOff.Location = new System.Drawing.Point(62, 38);
            this.btnGetTurnOnOff.Name = "btnGetTurnOnOff";
            this.btnGetTurnOnOff.Size = new System.Drawing.Size(39, 21);
            this.btnGetTurnOnOff.TabIndex = 67;
            this.btnGetTurnOnOff.Text = "回读";
            this.btnGetTurnOnOff.UseVisualStyleBackColor = true;
            // 
            // btnSetTurnOnOff
            // 
            this.btnSetTurnOnOff.Location = new System.Drawing.Point(62, 15);
            this.btnSetTurnOnOff.Name = "btnSetTurnOnOff";
            this.btnSetTurnOnOff.Size = new System.Drawing.Size(39, 21);
            this.btnSetTurnOnOff.TabIndex = 56;
            this.btnSetTurnOnOff.Text = "设置";
            this.btnSetTurnOnOff.UseVisualStyleBackColor = true;
            // 
            // radioButtonTurnOff
            // 
            this.radioButtonTurnOff.AutoSize = true;
            this.radioButtonTurnOff.Location = new System.Drawing.Point(6, 16);
            this.radioButtonTurnOff.Name = "radioButtonTurnOff";
            this.radioButtonTurnOff.Size = new System.Drawing.Size(47, 16);
            this.radioButtonTurnOff.TabIndex = 64;
            this.radioButtonTurnOff.TabStop = true;
            this.radioButtonTurnOff.Text = "关机";
            this.radioButtonTurnOff.UseVisualStyleBackColor = true;
            // 
            // radioButtonTurnOn
            // 
            this.radioButtonTurnOn.AutoSize = true;
            this.radioButtonTurnOn.Location = new System.Drawing.Point(6, 39);
            this.radioButtonTurnOn.Name = "radioButtonTurnOn";
            this.radioButtonTurnOn.Size = new System.Drawing.Size(47, 16);
            this.radioButtonTurnOn.TabIndex = 63;
            this.radioButtonTurnOn.TabStop = true;
            this.radioButtonTurnOn.Text = "开机";
            this.radioButtonTurnOn.UseVisualStyleBackColor = true;
            // 
            // groupBox21
            // 
            this.groupBox21.Controls.Add(this.radioButtonRunStateErrStop);
            this.groupBox21.Controls.Add(this.btnGetRunState);
            this.groupBox21.Controls.Add(this.radioButtonRunStateSleep);
            this.groupBox21.Controls.Add(this.radioButtonRunStateStandby);
            this.groupBox21.Controls.Add(this.radioButtonRunStateRun);
            this.groupBox21.Controls.Add(this.radioButtonRunStateStop);
            this.groupBox21.Location = new System.Drawing.Point(8, 15);
            this.groupBox21.Name = "groupBox21";
            this.groupBox21.Size = new System.Drawing.Size(117, 124);
            this.groupBox21.TabIndex = 64;
            this.groupBox21.TabStop = false;
            this.groupBox21.Text = "工作状态";
            // 
            // radioButtonRunStateErrStop
            // 
            this.radioButtonRunStateErrStop.AutoSize = true;
            this.radioButtonRunStateErrStop.Location = new System.Drawing.Point(12, 103);
            this.radioButtonRunStateErrStop.Name = "radioButtonRunStateErrStop";
            this.radioButtonRunStateErrStop.Size = new System.Drawing.Size(71, 16);
            this.radioButtonRunStateErrStop.TabIndex = 68;
            this.radioButtonRunStateErrStop.TabStop = true;
            this.radioButtonRunStateErrStop.Text = "异常关机";
            this.radioButtonRunStateErrStop.UseVisualStyleBackColor = true;
            // 
            // btnGetRunState
            // 
            this.btnGetRunState.Location = new System.Drawing.Point(69, 53);
            this.btnGetRunState.Name = "btnGetRunState";
            this.btnGetRunState.Size = new System.Drawing.Size(39, 38);
            this.btnGetRunState.TabIndex = 67;
            this.btnGetRunState.Text = "回读";
            this.btnGetRunState.UseVisualStyleBackColor = true;
            // 
            // radioButtonRunStateSleep
            // 
            this.radioButtonRunStateSleep.AutoSize = true;
            this.radioButtonRunStateSleep.Location = new System.Drawing.Point(12, 83);
            this.radioButtonRunStateSleep.Name = "radioButtonRunStateSleep";
            this.radioButtonRunStateSleep.Size = new System.Drawing.Size(47, 16);
            this.radioButtonRunStateSleep.TabIndex = 66;
            this.radioButtonRunStateSleep.TabStop = true;
            this.radioButtonRunStateSleep.Text = "休眠";
            this.radioButtonRunStateSleep.UseVisualStyleBackColor = true;
            // 
            // radioButtonRunStateStandby
            // 
            this.radioButtonRunStateStandby.AutoSize = true;
            this.radioButtonRunStateStandby.Location = new System.Drawing.Point(12, 61);
            this.radioButtonRunStateStandby.Name = "radioButtonRunStateStandby";
            this.radioButtonRunStateStandby.Size = new System.Drawing.Size(47, 16);
            this.radioButtonRunStateStandby.TabIndex = 65;
            this.radioButtonRunStateStandby.TabStop = true;
            this.radioButtonRunStateStandby.Text = "待机";
            this.radioButtonRunStateStandby.UseVisualStyleBackColor = true;
            // 
            // radioButtonRunStateRun
            // 
            this.radioButtonRunStateRun.AutoSize = true;
            this.radioButtonRunStateRun.Location = new System.Drawing.Point(12, 39);
            this.radioButtonRunStateRun.Name = "radioButtonRunStateRun";
            this.radioButtonRunStateRun.Size = new System.Drawing.Size(47, 16);
            this.radioButtonRunStateRun.TabIndex = 64;
            this.radioButtonRunStateRun.TabStop = true;
            this.radioButtonRunStateRun.Text = "运行";
            this.radioButtonRunStateRun.UseVisualStyleBackColor = true;
            // 
            // radioButtonRunStateStop
            // 
            this.radioButtonRunStateStop.AutoSize = true;
            this.radioButtonRunStateStop.Location = new System.Drawing.Point(12, 17);
            this.radioButtonRunStateStop.Name = "radioButtonRunStateStop";
            this.radioButtonRunStateStop.Size = new System.Drawing.Size(71, 16);
            this.radioButtonRunStateStop.TabIndex = 63;
            this.radioButtonRunStateStop.TabStop = true;
            this.radioButtonRunStateStop.Text = "指令关机";
            this.radioButtonRunStateStop.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.groupBox8);
            this.groupBox5.Controls.Add(this.groupBox6);
            this.groupBox5.Location = new System.Drawing.Point(6, 6);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(602, 102);
            this.groupBox5.TabIndex = 1;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "通信测试";
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.radioBtnSouthDevProto);
            this.groupBox8.Controls.Add(this.btnSelectProtoType);
            this.groupBox8.Controls.Add(this.radioBtnCmdProto);
            this.groupBox8.Controls.Add(this.radioBtnModbusProto);
            this.groupBox8.Location = new System.Drawing.Point(8, 15);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(154, 82);
            this.groupBox8.TabIndex = 60;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "通信协议选择";
            // 
            // radioBtnSouthDevProto
            // 
            this.radioBtnSouthDevProto.AutoSize = true;
            this.radioBtnSouthDevProto.Location = new System.Drawing.Point(6, 61);
            this.radioBtnSouthDevProto.Name = "radioBtnSouthDevProto";
            this.radioBtnSouthDevProto.Size = new System.Drawing.Size(71, 16);
            this.radioBtnSouthDevProto.TabIndex = 62;
            this.radioBtnSouthDevProto.TabStop = true;
            this.radioBtnSouthDevProto.Text = "南设协议";
            this.radioBtnSouthDevProto.UseVisualStyleBackColor = true;
            // 
            // btnSelectProtoType
            // 
            this.btnSelectProtoType.Location = new System.Drawing.Point(95, 18);
            this.btnSelectProtoType.Name = "btnSelectProtoType";
            this.btnSelectProtoType.Size = new System.Drawing.Size(53, 60);
            this.btnSelectProtoType.TabIndex = 61;
            this.btnSelectProtoType.Text = "切换";
            this.btnSelectProtoType.UseVisualStyleBackColor = true;
            // 
            // radioBtnCmdProto
            // 
            this.radioBtnCmdProto.AutoSize = true;
            this.radioBtnCmdProto.Location = new System.Drawing.Point(6, 18);
            this.radioBtnCmdProto.Name = "radioBtnCmdProto";
            this.radioBtnCmdProto.Size = new System.Drawing.Size(83, 16);
            this.radioBtnCmdProto.TabIndex = 56;
            this.radioBtnCmdProto.TabStop = true;
            this.radioBtnCmdProto.Text = "命令字协议";
            this.radioBtnCmdProto.UseVisualStyleBackColor = true;
            // 
            // radioBtnModbusProto
            // 
            this.radioBtnModbusProto.AutoSize = true;
            this.radioBtnModbusProto.Location = new System.Drawing.Point(6, 39);
            this.radioBtnModbusProto.Name = "radioBtnModbusProto";
            this.radioBtnModbusProto.Size = new System.Drawing.Size(83, 16);
            this.radioBtnModbusProto.TabIndex = 57;
            this.radioBtnModbusProto.TabStop = true;
            this.radioBtnModbusProto.Text = "Modbus协议";
            this.radioBtnModbusProto.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.comboBoxDatType);
            this.groupBox6.Controls.Add(this.btnGenWriteCmd);
            this.groupBox6.Controls.Add(this.label13);
            this.groupBox6.Controls.Add(this.comboBoxDecHex);
            this.groupBox6.Controls.Add(this.label16);
            this.groupBox6.Controls.Add(this.textBoxCmdData);
            this.groupBox6.Controls.Add(this.label17);
            this.groupBox6.Controls.Add(this.textBoxCmd);
            this.groupBox6.Controls.Add(this.label18);
            this.groupBox6.Location = new System.Drawing.Point(168, 15);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(428, 82);
            this.groupBox6.TabIndex = 62;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "命令字通信组件";
            // 
            // comboBoxDatType
            // 
            this.comboBoxDatType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDatType.FormattingEnabled = true;
            this.comboBoxDatType.Location = new System.Drawing.Point(71, 46);
            this.comboBoxDatType.Name = "comboBoxDatType";
            this.comboBoxDatType.Size = new System.Drawing.Size(74, 20);
            this.comboBoxDatType.TabIndex = 58;
            // 
            // btnGenWriteCmd
            // 
            this.btnGenWriteCmd.Location = new System.Drawing.Point(351, 44);
            this.btnGenWriteCmd.Name = "btnGenWriteCmd";
            this.btnGenWriteCmd.Size = new System.Drawing.Size(69, 23);
            this.btnGenWriteCmd.TabIndex = 56;
            this.btnGenWriteCmd.Text = "下发报文";
            this.btnGenWriteCmd.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(271, 32);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(29, 12);
            this.label13.TabIndex = 27;
            this.label13.Text = "数据";
            // 
            // comboBoxDecHex
            // 
            this.comboBoxDecHex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDecHex.FormattingEnabled = true;
            this.comboBoxDecHex.Location = new System.Drawing.Point(146, 46);
            this.comboBoxDecHex.Name = "comboBoxDecHex";
            this.comboBoxDecHex.Size = new System.Drawing.Size(74, 20);
            this.comboBoxDecHex.TabIndex = 22;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(156, 31);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(53, 12);
            this.label16.TabIndex = 26;
            this.label16.Text = "数据进制";
            // 
            // textBoxCmdData
            // 
            this.textBoxCmdData.Location = new System.Drawing.Point(224, 45);
            this.textBoxCmdData.MaxLength = 14;
            this.textBoxCmdData.Name = "textBoxCmdData";
            this.textBoxCmdData.Size = new System.Drawing.Size(123, 21);
            this.textBoxCmdData.TabIndex = 25;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(84, 31);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(53, 12);
            this.label17.TabIndex = 23;
            this.label17.Text = "数据类型";
            // 
            // textBoxCmd
            // 
            this.textBoxCmd.Location = new System.Drawing.Point(5, 45);
            this.textBoxCmd.MaxLength = 8;
            this.textBoxCmd.Name = "textBoxCmd";
            this.textBoxCmd.Size = new System.Drawing.Size(65, 21);
            this.textBoxCmd.TabIndex = 21;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(18, 31);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(41, 12);
            this.label18.TabIndex = 22;
            this.label18.Text = "命令字";
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.groupBox4);
            this.tabPage5.Controls.Add(this.groupBox3);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(716, 739);
            this.tabPage5.TabIndex = 2;
            this.tabPage5.Text = "文件下载";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.labelProgress);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.progBarUpload);
            this.groupBox4.Controls.Add(this.txtInvSoftVersion);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.cmbFileType);
            this.groupBox4.Controls.Add(this.labDeviceType);
            this.groupBox4.Controls.Add(this.label28);
            this.groupBox4.Controls.Add(this.labSlideFrameNum);
            this.groupBox4.Controls.Add(this.label29);
            this.groupBox4.Controls.Add(this.labFrameDatLen);
            this.groupBox4.Controls.Add(this.label27);
            this.groupBox4.Controls.Add(this.label26);
            this.groupBox4.Location = new System.Drawing.Point(6, 184);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(609, 198);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "显示区";
            // 
            // labelProgress
            // 
            this.labelProgress.AutoSize = true;
            this.labelProgress.Location = new System.Drawing.Point(323, 24);
            this.labelProgress.Name = "labelProgress";
            this.labelProgress.Size = new System.Drawing.Size(17, 12);
            this.labelProgress.TabIndex = 76;
            this.labelProgress.Text = "0%";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(240, 24);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 12);
            this.label9.TabIndex = 75;
            this.label9.Text = "升级进度：";
            // 
            // progBarUpload
            // 
            this.progBarUpload.Location = new System.Drawing.Point(242, 43);
            this.progBarUpload.Name = "progBarUpload";
            this.progBarUpload.Size = new System.Drawing.Size(348, 23);
            this.progBarUpload.TabIndex = 74;
            // 
            // txtInvSoftVersion
            // 
            this.txtInvSoftVersion.AutoSize = true;
            this.txtInvSoftVersion.Location = new System.Drawing.Point(121, 75);
            this.txtInvSoftVersion.Name = "txtInvSoftVersion";
            this.txtInvSoftVersion.Size = new System.Drawing.Size(89, 12);
            this.txtInvSoftVersion.TabIndex = 73;
            this.txtInvSoftVersion.Text = "00.00.00.00.00";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(20, 51);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(71, 12);
            this.label10.TabIndex = 71;
            this.label10.Text = "· 升级对象";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(20, 75);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(83, 12);
            this.label11.TabIndex = 72;
            this.label11.Text = "· 回读的版本";
            // 
            // cmbFileType
            // 
            this.cmbFileType.FormattingEnabled = true;
            this.cmbFileType.Location = new System.Drawing.Point(123, 46);
            this.cmbFileType.Name = "cmbFileType";
            this.cmbFileType.Size = new System.Drawing.Size(90, 20);
            this.cmbFileType.TabIndex = 70;
            // 
            // labDeviceType
            // 
            this.labDeviceType.AutoSize = true;
            this.labDeviceType.Location = new System.Drawing.Point(121, 145);
            this.labDeviceType.Name = "labDeviceType";
            this.labDeviceType.Size = new System.Drawing.Size(11, 12);
            this.labDeviceType.TabIndex = 69;
            this.labDeviceType.Text = "0";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(20, 145);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(71, 12);
            this.label28.TabIndex = 68;
            this.label28.Text = "· 设备类型";
            // 
            // labSlideFrameNum
            // 
            this.labSlideFrameNum.AutoSize = true;
            this.labSlideFrameNum.Location = new System.Drawing.Point(121, 123);
            this.labSlideFrameNum.Name = "labSlideFrameNum";
            this.labSlideFrameNum.Size = new System.Drawing.Size(11, 12);
            this.labSlideFrameNum.TabIndex = 67;
            this.labSlideFrameNum.Text = "0";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(20, 123);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(71, 12);
            this.label29.TabIndex = 66;
            this.label29.Text = "· 滑窗帧数";
            // 
            // labFrameDatLen
            // 
            this.labFrameDatLen.AutoSize = true;
            this.labFrameDatLen.Location = new System.Drawing.Point(121, 99);
            this.labFrameDatLen.Name = "labFrameDatLen";
            this.labFrameDatLen.Size = new System.Drawing.Size(11, 12);
            this.labFrameDatLen.TabIndex = 65;
            this.labFrameDatLen.Text = "0";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(20, 99);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(95, 12);
            this.label27.TabIndex = 64;
            this.label27.Text = "· 每帧数据长度";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(6, 27);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(53, 12);
            this.label26.TabIndex = 63;
            this.label26.Text = "协商结果";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnLoadFileStart);
            this.groupBox3.Controls.Add(this.btnActiveApp);
            this.groupBox3.Controls.Add(this.btnLoadFileConsult);
            this.groupBox3.Controls.Add(this.btnUpload);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.btnEnterBackDoor);
            this.groupBox3.Controls.Add(this.btnJumpApp);
            this.groupBox3.Controls.Add(this.txtFilePath);
            this.groupBox3.Controls.Add(this.btnFindFile);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.btnSwitchLoaderOrLoadee);
            this.groupBox3.Location = new System.Drawing.Point(6, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(609, 173);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "控制区";
            // 
            // btnLoadFileStart
            // 
            this.btnLoadFileStart.Location = new System.Drawing.Point(289, 85);
            this.btnLoadFileStart.Name = "btnLoadFileStart";
            this.btnLoadFileStart.Size = new System.Drawing.Size(90, 23);
            this.btnLoadFileStart.TabIndex = 64;
            this.btnLoadFileStart.Text = "加载文件启动";
            this.btnLoadFileStart.UseVisualStyleBackColor = true;
            // 
            // btnActiveApp
            // 
            this.btnActiveApp.Location = new System.Drawing.Point(403, 85);
            this.btnActiveApp.Name = "btnActiveApp";
            this.btnActiveApp.Size = new System.Drawing.Size(90, 23);
            this.btnActiveApp.TabIndex = 65;
            this.btnActiveApp.Text = "升级激活";
            this.btnActiveApp.UseVisualStyleBackColor = true;
            // 
            // btnLoadFileConsult
            // 
            this.btnLoadFileConsult.Location = new System.Drawing.Point(89, 86);
            this.btnLoadFileConsult.Name = "btnLoadFileConsult";
            this.btnLoadFileConsult.Size = new System.Drawing.Size(90, 23);
            this.btnLoadFileConsult.TabIndex = 63;
            this.btnLoadFileConsult.Text = "加载文件协商";
            this.btnLoadFileConsult.UseVisualStyleBackColor = true;
            this.btnLoadFileConsult.Click += new System.EventHandler(this.btnLoadFileConsult_Click);
            // 
            // btnUpload
            // 
            this.btnUpload.Location = new System.Drawing.Point(204, 85);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(51, 23);
            this.btnUpload.TabIndex = 62;
            this.btnUpload.Text = "升级";
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 91);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 12);
            this.label8.TabIndex = 61;
            this.label8.Text = "升级调试命令";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(202, 25);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 60;
            this.label7.Text = "跳转控制";
            // 
            // btnEnterBackDoor
            // 
            this.btnEnterBackDoor.Location = new System.Drawing.Point(261, 20);
            this.btnEnterBackDoor.Name = "btnEnterBackDoor";
            this.btnEnterBackDoor.Size = new System.Drawing.Size(90, 23);
            this.btnEnterBackDoor.TabIndex = 59;
            this.btnEnterBackDoor.Text = "后门进入Boot";
            this.btnEnterBackDoor.UseVisualStyleBackColor = true;
            // 
            // btnJumpApp
            // 
            this.btnJumpApp.Location = new System.Drawing.Point(367, 20);
            this.btnJumpApp.Name = "btnJumpApp";
            this.btnJumpApp.Size = new System.Drawing.Size(90, 23);
            this.btnJumpApp.TabIndex = 58;
            this.btnJumpApp.Text = "强制跳转APP";
            this.btnJumpApp.UseVisualStyleBackColor = true;
            // 
            // txtFilePath
            // 
            this.txtFilePath.Location = new System.Drawing.Point(89, 54);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Size = new System.Drawing.Size(404, 21);
            this.txtFilePath.TabIndex = 13;
            // 
            // btnFindFile
            // 
            this.btnFindFile.Location = new System.Drawing.Point(498, 52);
            this.btnFindFile.Name = "btnFindFile";
            this.btnFindFile.Size = new System.Drawing.Size(92, 23);
            this.btnFindFile.TabIndex = 14;
            this.btnFindFile.Text = "浏览";
            this.btnFindFile.UseVisualStyleBackColor = true;
            this.btnFindFile.Click += new System.EventHandler(this.btnFindFile_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 57);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 12);
            this.label5.TabIndex = 2;
            this.label5.Text = "待升级的文件";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 1;
            this.label4.Text = "上下位机切换";
            // 
            // btnSwitchLoaderOrLoadee
            // 
            this.btnSwitchLoaderOrLoadee.Location = new System.Drawing.Point(89, 20);
            this.btnSwitchLoaderOrLoadee.Name = "btnSwitchLoaderOrLoadee";
            this.btnSwitchLoaderOrLoadee.Size = new System.Drawing.Size(75, 23);
            this.btnSwitchLoaderOrLoadee.TabIndex = 0;
            this.btnSwitchLoaderOrLoadee.Text = "上位机";
            this.btnSwitchLoaderOrLoadee.UseVisualStyleBackColor = true;
            this.btnSwitchLoaderOrLoadee.Click += new System.EventHandler(this.btnSwitchLoaderOrLoadee_Click);
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.groupBox25);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(716, 739);
            this.tabPage6.TabIndex = 3;
            this.tabPage6.Text = "日志导出";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // groupBox25
            // 
            this.groupBox25.Controls.Add(this.label340);
            this.groupBox25.Controls.Add(this.btnTimeSync);
            this.groupBox25.Controls.Add(this.label330);
            this.groupBox25.Controls.Add(this.btnLogManualTxtAnalysis);
            this.groupBox25.Controls.Add(this.btnExportClear);
            this.groupBox25.Controls.Add(this.label59);
            this.groupBox25.Controls.Add(this.comboLogSubfileType);
            this.groupBox25.Controls.Add(this.label66);
            this.groupBox25.Controls.Add(this.cmbFileTypeExport);
            this.groupBox25.Controls.Add(this.labelExportProgress);
            this.groupBox25.Controls.Add(this.progressBarExport);
            this.groupBox25.Controls.Add(this.label61);
            this.groupBox25.Controls.Add(this.label62);
            this.groupBox25.Controls.Add(this.labFileInfo);
            this.groupBox25.Controls.Add(this.label63);
            this.groupBox25.Controls.Add(this.chkboxPrintOriginLog);
            this.groupBox25.Controls.Add(this.label64);
            this.groupBox25.Controls.Add(this.btnSwitchExporterOrExportee);
            this.groupBox25.Controls.Add(this.txtLogFilePath);
            this.groupBox25.Controls.Add(this.label65);
            this.groupBox25.Controls.Add(this.btnExportEnd);
            this.groupBox25.Controls.Add(this.btnFindLogFile);
            this.groupBox25.Controls.Add(this.btnExportFileSaveAs);
            this.groupBox25.Controls.Add(this.textBoxExport);
            this.groupBox25.Controls.Add(this.btnExportConsult);
            this.groupBox25.Controls.Add(this.btnExportStart);
            this.groupBox25.Location = new System.Drawing.Point(6, 4);
            this.groupBox25.Name = "groupBox25";
            this.groupBox25.Size = new System.Drawing.Size(609, 669);
            this.groupBox25.TabIndex = 59;
            this.groupBox25.TabStop = false;
            this.groupBox25.Text = "文件导出组件";
            // 
            // label340
            // 
            this.label340.AutoSize = true;
            this.label340.Location = new System.Drawing.Point(9, 162);
            this.label340.Name = "label340";
            this.label340.Size = new System.Drawing.Size(53, 12);
            this.label340.TabIndex = 99;
            this.label340.Text = "操作命令";
            // 
            // btnTimeSync
            // 
            this.btnTimeSync.Location = new System.Drawing.Point(187, 157);
            this.btnTimeSync.Name = "btnTimeSync";
            this.btnTimeSync.Size = new System.Drawing.Size(125, 23);
            this.btnTimeSync.TabIndex = 98;
            this.btnTimeSync.Text = "同步时间";
            this.btnTimeSync.UseVisualStyleBackColor = true;
            // 
            // label330
            // 
            this.label330.AutoSize = true;
            this.label330.Location = new System.Drawing.Point(9, 194);
            this.label330.Name = "label330";
            this.label330.Size = new System.Drawing.Size(95, 12);
            this.label330.TabIndex = 96;
            this.label330.Text = "日志解析txt命令";
            // 
            // btnLogManualTxtAnalysis
            // 
            this.btnLogManualTxtAnalysis.Location = new System.Drawing.Point(110, 191);
            this.btnLogManualTxtAnalysis.Name = "btnLogManualTxtAnalysis";
            this.btnLogManualTxtAnalysis.Size = new System.Drawing.Size(160, 23);
            this.btnLogManualTxtAnalysis.TabIndex = 95;
            this.btnLogManualTxtAnalysis.Text = "解析";
            this.btnLogManualTxtAnalysis.UseVisualStyleBackColor = true;
            // 
            // btnExportClear
            // 
            this.btnExportClear.Location = new System.Drawing.Point(64, 157);
            this.btnExportClear.Name = "btnExportClear";
            this.btnExportClear.Size = new System.Drawing.Size(117, 23);
            this.btnExportClear.TabIndex = 94;
            this.btnExportClear.Text = "清空日志";
            this.btnExportClear.UseVisualStyleBackColor = true;
            // 
            // label59
            // 
            this.label59.AutoSize = true;
            this.label59.Location = new System.Drawing.Point(356, 24);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(53, 12);
            this.label59.TabIndex = 86;
            this.label59.Text = "日志类型";
            // 
            // comboLogSubfileType
            // 
            this.comboLogSubfileType.FormattingEnabled = true;
            this.comboLogSubfileType.Location = new System.Drawing.Point(415, 20);
            this.comboLogSubfileType.Name = "comboLogSubfileType";
            this.comboLogSubfileType.Size = new System.Drawing.Size(168, 20);
            this.comboLogSubfileType.TabIndex = 85;
            // 
            // label66
            // 
            this.label66.AutoSize = true;
            this.label66.Location = new System.Drawing.Point(185, 24);
            this.label66.Name = "label66";
            this.label66.Size = new System.Drawing.Size(53, 12);
            this.label66.TabIndex = 84;
            this.label66.Text = "导出对象";
            // 
            // cmbFileTypeExport
            // 
            this.cmbFileTypeExport.FormattingEnabled = true;
            this.cmbFileTypeExport.Location = new System.Drawing.Point(244, 20);
            this.cmbFileTypeExport.Name = "cmbFileTypeExport";
            this.cmbFileTypeExport.Size = new System.Drawing.Size(90, 20);
            this.cmbFileTypeExport.TabIndex = 83;
            // 
            // labelExportProgress
            // 
            this.labelExportProgress.AutoSize = true;
            this.labelExportProgress.Location = new System.Drawing.Point(526, 94);
            this.labelExportProgress.Name = "labelExportProgress";
            this.labelExportProgress.Size = new System.Drawing.Size(17, 12);
            this.labelExportProgress.TabIndex = 79;
            this.labelExportProgress.Text = "0%";
            // 
            // progressBarExport
            // 
            this.progressBarExport.Location = new System.Drawing.Point(64, 89);
            this.progressBarExport.Name = "progressBarExport";
            this.progressBarExport.Size = new System.Drawing.Size(415, 23);
            this.progressBarExport.TabIndex = 78;
            // 
            // label61
            // 
            this.label61.AutoSize = true;
            this.label61.Location = new System.Drawing.Point(9, 58);
            this.label61.Name = "label61";
            this.label61.Size = new System.Drawing.Size(77, 12);
            this.label61.TabIndex = 77;
            this.label61.Text = "导出调试命令";
            // 
            // label62
            // 
            this.label62.AutoSize = true;
            this.label62.Location = new System.Drawing.Point(9, 95);
            this.label62.Name = "label62";
            this.label62.Size = new System.Drawing.Size(53, 12);
            this.label62.TabIndex = 76;
            this.label62.Text = "导出进度";
            // 
            // labFileInfo
            // 
            this.labFileInfo.AutoSize = true;
            this.labFileInfo.Location = new System.Drawing.Point(128, 239);
            this.labFileInfo.Name = "labFileInfo";
            this.labFileInfo.Size = new System.Drawing.Size(89, 12);
            this.labFileInfo.TabIndex = 53;
            this.labFileInfo.Text = "00.00.00.00.00";
            // 
            // label63
            // 
            this.label63.AutoSize = true;
            this.label63.Location = new System.Drawing.Point(9, 239);
            this.label63.Name = "label63";
            this.label63.Size = new System.Drawing.Size(113, 12);
            this.label63.TabIndex = 49;
            this.label63.Text = "文件大小和地址范围";
            // 
            // chkboxPrintOriginLog
            // 
            this.chkboxPrintOriginLog.AutoSize = true;
            this.chkboxPrintOriginLog.Location = new System.Drawing.Point(492, 238);
            this.chkboxPrintOriginLog.Name = "chkboxPrintOriginLog";
            this.chkboxPrintOriginLog.Size = new System.Drawing.Size(96, 16);
            this.chkboxPrintOriginLog.TabIndex = 58;
            this.chkboxPrintOriginLog.Text = "打印原始数据";
            this.chkboxPrintOriginLog.UseVisualStyleBackColor = true;
            // 
            // label64
            // 
            this.label64.AutoSize = true;
            this.label64.Location = new System.Drawing.Point(9, 24);
            this.label64.Name = "label64";
            this.label64.Size = new System.Drawing.Size(77, 12);
            this.label64.TabIndex = 60;
            this.label64.Text = "上下位机切换";
            // 
            // btnSwitchExporterOrExportee
            // 
            this.btnSwitchExporterOrExportee.Location = new System.Drawing.Point(92, 19);
            this.btnSwitchExporterOrExportee.Name = "btnSwitchExporterOrExportee";
            this.btnSwitchExporterOrExportee.Size = new System.Drawing.Size(75, 23);
            this.btnSwitchExporterOrExportee.TabIndex = 59;
            this.btnSwitchExporterOrExportee.Text = "上位机";
            this.btnSwitchExporterOrExportee.UseVisualStyleBackColor = true;
            // 
            // txtLogFilePath
            // 
            this.txtLogFilePath.Location = new System.Drawing.Point(64, 125);
            this.txtLogFilePath.Name = "txtLogFilePath";
            this.txtLogFilePath.Size = new System.Drawing.Size(415, 21);
            this.txtLogFilePath.TabIndex = 54;
            // 
            // label65
            // 
            this.label65.AutoSize = true;
            this.label65.Location = new System.Drawing.Point(9, 130);
            this.label65.Name = "label65";
            this.label65.Size = new System.Drawing.Size(53, 12);
            this.label65.TabIndex = 55;
            this.label65.Text = "文件路径";
            // 
            // btnExportEnd
            // 
            this.btnExportEnd.Location = new System.Drawing.Point(308, 53);
            this.btnExportEnd.Name = "btnExportEnd";
            this.btnExportEnd.Size = new System.Drawing.Size(90, 23);
            this.btnExportEnd.TabIndex = 51;
            this.btnExportEnd.Text = "导出文件结束";
            this.btnExportEnd.UseVisualStyleBackColor = true;
            // 
            // btnFindLogFile
            // 
            this.btnFindLogFile.Location = new System.Drawing.Point(491, 124);
            this.btnFindLogFile.Name = "btnFindLogFile";
            this.btnFindLogFile.Size = new System.Drawing.Size(92, 23);
            this.btnFindLogFile.TabIndex = 56;
            this.btnFindLogFile.Text = "浏览";
            this.btnFindLogFile.UseVisualStyleBackColor = true;
            // 
            // btnExportFileSaveAs
            // 
            this.btnExportFileSaveAs.Location = new System.Drawing.Point(416, 53);
            this.btnExportFileSaveAs.Name = "btnExportFileSaveAs";
            this.btnExportFileSaveAs.Size = new System.Drawing.Size(90, 23);
            this.btnExportFileSaveAs.TabIndex = 12;
            this.btnExportFileSaveAs.Text = "文件另存为";
            this.btnExportFileSaveAs.UseVisualStyleBackColor = true;
            // 
            // textBoxExport
            // 
            this.textBoxExport.AcceptsReturn = true;
            this.textBoxExport.Location = new System.Drawing.Point(11, 262);
            this.textBoxExport.Multiline = true;
            this.textBoxExport.Name = "textBoxExport";
            this.textBoxExport.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxExport.Size = new System.Drawing.Size(577, 401);
            this.textBoxExport.TabIndex = 35;
            // 
            // btnExportConsult
            // 
            this.btnExportConsult.Location = new System.Drawing.Point(92, 53);
            this.btnExportConsult.Name = "btnExportConsult";
            this.btnExportConsult.Size = new System.Drawing.Size(90, 23);
            this.btnExportConsult.TabIndex = 44;
            this.btnExportConsult.Text = "导出文件协商";
            this.btnExportConsult.UseVisualStyleBackColor = true;
            // 
            // btnExportStart
            // 
            this.btnExportStart.Location = new System.Drawing.Point(200, 53);
            this.btnExportStart.Name = "btnExportStart";
            this.btnExportStart.Size = new System.Drawing.Size(90, 23);
            this.btnExportStart.TabIndex = 45;
            this.btnExportStart.Text = "导出文件启动";
            this.btnExportStart.UseVisualStyleBackColor = true;
            // 
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.groupBox37);
            this.tabPage7.Controls.Add(this.groupBox31);
            this.tabPage7.Controls.Add(this.groupBox27);
            this.tabPage7.Controls.Add(this.groupBox13);
            this.tabPage7.Controls.Add(this.groupBox30);
            this.tabPage7.Location = new System.Drawing.Point(4, 22);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage7.Size = new System.Drawing.Size(716, 739);
            this.tabPage7.TabIndex = 4;
            this.tabPage7.Text = "模拟量记录";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // groupBox37
            // 
            this.groupBox37.Controls.Add(this.groupBox35);
            this.groupBox37.Controls.Add(this.groupBox38);
            this.groupBox37.Controls.Add(this.label223);
            this.groupBox37.Location = new System.Drawing.Point(528, 2);
            this.groupBox37.Name = "groupBox37";
            this.groupBox37.Size = new System.Drawing.Size(92, 359);
            this.groupBox37.TabIndex = 104;
            this.groupBox37.TabStop = false;
            this.groupBox37.Text = "储能电芯电压";
            // 
            // groupBox35
            // 
            this.groupBox35.Controls.Add(this.label214);
            this.groupBox35.Controls.Add(this.txtBmsMinVbatIndex);
            this.groupBox35.Controls.Add(this.label219);
            this.groupBox35.Controls.Add(this.txtBmsMinVbatValue);
            this.groupBox35.Controls.Add(this.label220);
            this.groupBox35.Location = new System.Drawing.Point(4, 140);
            this.groupBox35.Name = "groupBox35";
            this.groupBox35.Size = new System.Drawing.Size(84, 117);
            this.groupBox35.TabIndex = 96;
            this.groupBox35.TabStop = false;
            this.groupBox35.Text = "最小电压";
            // 
            // label214
            // 
            this.label214.AutoSize = true;
            this.label214.Location = new System.Drawing.Point(5, 66);
            this.label214.Name = "label214";
            this.label214.Size = new System.Drawing.Size(65, 12);
            this.label214.TabIndex = 99;
            this.label214.Text = "对应电芯号";
            // 
            // txtBmsMinVbatIndex
            // 
            this.txtBmsMinVbatIndex.Location = new System.Drawing.Point(4, 82);
            this.txtBmsMinVbatIndex.MaxLength = 8;
            this.txtBmsMinVbatIndex.Name = "txtBmsMinVbatIndex";
            this.txtBmsMinVbatIndex.Size = new System.Drawing.Size(70, 21);
            this.txtBmsMinVbatIndex.TabIndex = 98;
            // 
            // label219
            // 
            this.label219.AutoSize = true;
            this.label219.Location = new System.Drawing.Point(5, 21);
            this.label219.Name = "label219";
            this.label219.Size = new System.Drawing.Size(65, 12);
            this.label219.TabIndex = 97;
            this.label219.Text = "最小电压值";
            // 
            // txtBmsMinVbatValue
            // 
            this.txtBmsMinVbatValue.Location = new System.Drawing.Point(4, 41);
            this.txtBmsMinVbatValue.MaxLength = 8;
            this.txtBmsMinVbatValue.Name = "txtBmsMinVbatValue";
            this.txtBmsMinVbatValue.Size = new System.Drawing.Size(70, 21);
            this.txtBmsMinVbatValue.TabIndex = 96;
            // 
            // label220
            // 
            this.label220.AutoSize = true;
            this.label220.Location = new System.Drawing.Point(95, 160);
            this.label220.Name = "label220";
            this.label220.Size = new System.Drawing.Size(11, 12);
            this.label220.TabIndex = 57;
            this.label220.Text = "V";
            // 
            // groupBox38
            // 
            this.groupBox38.Controls.Add(this.label93);
            this.groupBox38.Controls.Add(this.txtBmsMaxVbatIndex);
            this.groupBox38.Controls.Add(this.label95);
            this.groupBox38.Controls.Add(this.txtBmsMaxVbatValue);
            this.groupBox38.Controls.Add(this.label218);
            this.groupBox38.Location = new System.Drawing.Point(4, 17);
            this.groupBox38.Name = "groupBox38";
            this.groupBox38.Size = new System.Drawing.Size(84, 117);
            this.groupBox38.TabIndex = 95;
            this.groupBox38.TabStop = false;
            this.groupBox38.Text = "最大电压";
            // 
            // label93
            // 
            this.label93.AutoSize = true;
            this.label93.Location = new System.Drawing.Point(5, 68);
            this.label93.Name = "label93";
            this.label93.Size = new System.Drawing.Size(65, 12);
            this.label93.TabIndex = 99;
            this.label93.Text = "对应电芯号";
            // 
            // txtBmsMaxVbatIndex
            // 
            this.txtBmsMaxVbatIndex.Location = new System.Drawing.Point(4, 84);
            this.txtBmsMaxVbatIndex.MaxLength = 8;
            this.txtBmsMaxVbatIndex.Name = "txtBmsMaxVbatIndex";
            this.txtBmsMaxVbatIndex.Size = new System.Drawing.Size(70, 21);
            this.txtBmsMaxVbatIndex.TabIndex = 98;
            // 
            // label95
            // 
            this.label95.AutoSize = true;
            this.label95.Location = new System.Drawing.Point(5, 20);
            this.label95.Name = "label95";
            this.label95.Size = new System.Drawing.Size(65, 12);
            this.label95.TabIndex = 97;
            this.label95.Text = "最大电压值";
            // 
            // txtBmsMaxVbatValue
            // 
            this.txtBmsMaxVbatValue.Location = new System.Drawing.Point(4, 40);
            this.txtBmsMaxVbatValue.MaxLength = 8;
            this.txtBmsMaxVbatValue.Name = "txtBmsMaxVbatValue";
            this.txtBmsMaxVbatValue.Size = new System.Drawing.Size(70, 21);
            this.txtBmsMaxVbatValue.TabIndex = 96;
            // 
            // label218
            // 
            this.label218.AutoSize = true;
            this.label218.Location = new System.Drawing.Point(95, 160);
            this.label218.Name = "label218";
            this.label218.Size = new System.Drawing.Size(11, 12);
            this.label218.TabIndex = 57;
            this.label218.Text = "V";
            // 
            // label223
            // 
            this.label223.AutoSize = true;
            this.label223.Location = new System.Drawing.Point(95, 160);
            this.label223.Name = "label223";
            this.label223.Size = new System.Drawing.Size(11, 12);
            this.label223.TabIndex = 57;
            this.label223.Text = "V";
            // 
            // groupBox31
            // 
            this.groupBox31.Controls.Add(this.btnAnalogMonit5sec1hourStartStop);
            this.groupBox31.Controls.Add(this.btnBMSAnalogDatSave);
            this.groupBox31.Controls.Add(this.btnAnalogDatSave);
            this.groupBox31.Controls.Add(this.btnAnalogMonit1sec1minStartStop);
            this.groupBox31.Controls.Add(this.btnGetAnalogData);
            this.groupBox31.Location = new System.Drawing.Point(118, 668);
            this.groupBox31.Name = "groupBox31";
            this.groupBox31.Size = new System.Drawing.Size(505, 68);
            this.groupBox31.TabIndex = 103;
            this.groupBox31.TabStop = false;
            this.groupBox31.Text = "快捷操作";
            // 
            // btnAnalogMonit5sec1hourStartStop
            // 
            this.btnAnalogMonit5sec1hourStartStop.Location = new System.Drawing.Point(182, 18);
            this.btnAnalogMonit5sec1hourStartStop.Name = "btnAnalogMonit5sec1hourStartStop";
            this.btnAnalogMonit5sec1hourStartStop.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnAnalogMonit5sec1hourStartStop.Size = new System.Drawing.Size(91, 43);
            this.btnAnalogMonit5sec1hourStartStop.TabIndex = 227;
            this.btnAnalogMonit5sec1hourStartStop.Text = "  开始监控   (每5秒 共1时)";
            this.btnAnalogMonit5sec1hourStartStop.UseVisualStyleBackColor = true;
            // 
            // btnBMSAnalogDatSave
            // 
            this.btnBMSAnalogDatSave.BackColor = System.Drawing.Color.Transparent;
            this.btnBMSAnalogDatSave.Location = new System.Drawing.Point(400, 17);
            this.btnBMSAnalogDatSave.Name = "btnBMSAnalogDatSave";
            this.btnBMSAnalogDatSave.Size = new System.Drawing.Size(96, 43);
            this.btnBMSAnalogDatSave.TabIndex = 98;
            this.btnBMSAnalogDatSave.Text = "BMS数据另存";
            this.btnBMSAnalogDatSave.UseVisualStyleBackColor = false;
            // 
            // btnAnalogDatSave
            // 
            this.btnAnalogDatSave.BackColor = System.Drawing.Color.Transparent;
            this.btnAnalogDatSave.Location = new System.Drawing.Point(281, 17);
            this.btnAnalogDatSave.Name = "btnAnalogDatSave";
            this.btnAnalogDatSave.Size = new System.Drawing.Size(112, 43);
            this.btnAnalogDatSave.TabIndex = 97;
            this.btnAnalogDatSave.Text = "模拟量数据另存";
            this.btnAnalogDatSave.UseVisualStyleBackColor = false;
            // 
            // btnAnalogMonit1sec1minStartStop
            // 
            this.btnAnalogMonit1sec1minStartStop.Location = new System.Drawing.Point(84, 17);
            this.btnAnalogMonit1sec1minStartStop.Name = "btnAnalogMonit1sec1minStartStop";
            this.btnAnalogMonit1sec1minStartStop.Size = new System.Drawing.Size(91, 43);
            this.btnAnalogMonit1sec1minStartStop.TabIndex = 96;
            this.btnAnalogMonit1sec1minStartStop.Text = "  开始监控    (每1秒 共1分)";
            this.btnAnalogMonit1sec1minStartStop.UseVisualStyleBackColor = true;
            // 
            // btnGetAnalogData
            // 
            this.btnGetAnalogData.Location = new System.Drawing.Point(8, 17);
            this.btnGetAnalogData.Name = "btnGetAnalogData";
            this.btnGetAnalogData.Size = new System.Drawing.Size(70, 43);
            this.btnGetAnalogData.TabIndex = 95;
            this.btnGetAnalogData.Text = "读取数据";
            this.btnGetAnalogData.UseVisualStyleBackColor = true;
            // 
            // groupBox27
            // 
            this.groupBox27.Controls.Add(this.txtBmsAnalogAlmGroup4);
            this.groupBox27.Controls.Add(this.txtBmsAnalogAlmGroup3);
            this.groupBox27.Controls.Add(this.label91);
            this.groupBox27.Controls.Add(this.label92);
            this.groupBox27.Controls.Add(this.label89);
            this.groupBox27.Controls.Add(this.label90);
            this.groupBox27.Controls.Add(this.txtBmsAnalogSOE);
            this.groupBox27.Controls.Add(this.label78);
            this.groupBox27.Controls.Add(this.label79);
            this.groupBox27.Controls.Add(this.txtBmsAnalogSOP_discharge);
            this.groupBox27.Controls.Add(this.label80);
            this.groupBox27.Controls.Add(this.label88);
            this.groupBox27.Controls.Add(this.txtBmsAnalogSOP_charge);
            this.groupBox27.Controls.Add(this.label70);
            this.groupBox27.Controls.Add(this.label73);
            this.groupBox27.Controls.Add(this.txtBmsAnalogSOH);
            this.groupBox27.Controls.Add(this.label76);
            this.groupBox27.Controls.Add(this.label77);
            this.groupBox27.Controls.Add(this.txtBmsAnalogSOC);
            this.groupBox27.Controls.Add(this.label55);
            this.groupBox27.Controls.Add(this.label56);
            this.groupBox27.Controls.Add(this.txtBmsAnalog12V);
            this.groupBox27.Controls.Add(this.label53);
            this.groupBox27.Controls.Add(this.label54);
            this.groupBox27.Controls.Add(this.txtBmsAnalogUbatPos);
            this.groupBox27.Controls.Add(this.label176);
            this.groupBox27.Controls.Add(this.label177);
            this.groupBox27.Controls.Add(this.txtBmsAnalogBat30V);
            this.groupBox27.Controls.Add(this.txtBmsAnalogAlmGroup2);
            this.groupBox27.Controls.Add(this.txtBmsAnalogAlmGroup1);
            this.groupBox27.Controls.Add(this.label160);
            this.groupBox27.Controls.Add(this.label161);
            this.groupBox27.Controls.Add(this.label146);
            this.groupBox27.Controls.Add(this.label186);
            this.groupBox27.Controls.Add(this.label188);
            this.groupBox27.Controls.Add(this.txtBmsAnalogVbat8);
            this.groupBox27.Controls.Add(this.label198);
            this.groupBox27.Controls.Add(this.label199);
            this.groupBox27.Controls.Add(this.txtBmsAnalogTbat8);
            this.groupBox27.Controls.Add(this.label200);
            this.groupBox27.Controls.Add(this.label201);
            this.groupBox27.Controls.Add(this.txtBmsAnalogVbat7);
            this.groupBox27.Controls.Add(this.label202);
            this.groupBox27.Controls.Add(this.label203);
            this.groupBox27.Controls.Add(this.txtBmsAnalogTbat7);
            this.groupBox27.Controls.Add(this.label204);
            this.groupBox27.Controls.Add(this.label205);
            this.groupBox27.Controls.Add(this.txtBmsAnalogVbat6);
            this.groupBox27.Controls.Add(this.label206);
            this.groupBox27.Controls.Add(this.label207);
            this.groupBox27.Controls.Add(this.txtBmsAnalogTbat6);
            this.groupBox27.Controls.Add(this.label208);
            this.groupBox27.Controls.Add(this.label209);
            this.groupBox27.Controls.Add(this.txtBmsAnalogVbat5);
            this.groupBox27.Controls.Add(this.label210);
            this.groupBox27.Controls.Add(this.label211);
            this.groupBox27.Controls.Add(this.txtBmsAnalogTbat5);
            this.groupBox27.Controls.Add(this.label178);
            this.groupBox27.Controls.Add(this.label179);
            this.groupBox27.Controls.Add(this.txtBmsAnalogAc30V);
            this.groupBox27.Controls.Add(this.label180);
            this.groupBox27.Controls.Add(this.label181);
            this.groupBox27.Controls.Add(this.txtBmsAnalogTblncingr);
            this.groupBox27.Controls.Add(this.label182);
            this.groupBox27.Controls.Add(this.label183);
            this.groupBox27.Controls.Add(this.txtBmsAnalogTboard);
            this.groupBox27.Controls.Add(this.label184);
            this.groupBox27.Controls.Add(this.label185);
            this.groupBox27.Controls.Add(this.txtBmsAnalogTterminal2);
            this.groupBox27.Controls.Add(this.label187);
            this.groupBox27.Controls.Add(this.label189);
            this.groupBox27.Controls.Add(this.txtBmsAnalogTterminal1);
            this.groupBox27.Controls.Add(this.label190);
            this.groupBox27.Controls.Add(this.label191);
            this.groupBox27.Controls.Add(this.label192);
            this.groupBox27.Controls.Add(this.label193);
            this.groupBox27.Controls.Add(this.txtBmsAnalog3V3);
            this.groupBox27.Controls.Add(this.txtBmsAnalogISR);
            this.groupBox27.Controls.Add(this.label194);
            this.groupBox27.Controls.Add(this.label195);
            this.groupBox27.Controls.Add(this.label196);
            this.groupBox27.Controls.Add(this.txtBmsAnalog30V);
            this.groupBox27.Controls.Add(this.label197);
            this.groupBox27.Controls.Add(this.txtBmsAnalogIbat);
            this.groupBox27.Controls.Add(this.label144);
            this.groupBox27.Controls.Add(this.label145);
            this.groupBox27.Controls.Add(this.txtBmsAnalogVbat4);
            this.groupBox27.Controls.Add(this.label147);
            this.groupBox27.Controls.Add(this.txtBmsAnalogTbat4);
            this.groupBox27.Controls.Add(this.label148);
            this.groupBox27.Controls.Add(this.label149);
            this.groupBox27.Controls.Add(this.txtBmsAnalogVbat3);
            this.groupBox27.Controls.Add(this.label150);
            this.groupBox27.Controls.Add(this.label151);
            this.groupBox27.Controls.Add(this.txtBmsAnalogTbat3);
            this.groupBox27.Controls.Add(this.label152);
            this.groupBox27.Controls.Add(this.label153);
            this.groupBox27.Controls.Add(this.txtBmsAnalogVbat2);
            this.groupBox27.Controls.Add(this.label154);
            this.groupBox27.Controls.Add(this.label155);
            this.groupBox27.Controls.Add(this.txtBmsAnalogTbat2);
            this.groupBox27.Controls.Add(this.label156);
            this.groupBox27.Controls.Add(this.label157);
            this.groupBox27.Controls.Add(this.txtBmsAnalogVbat1);
            this.groupBox27.Controls.Add(this.label158);
            this.groupBox27.Controls.Add(this.label159);
            this.groupBox27.Controls.Add(this.txtBmsAnalogTbat1);
            this.groupBox27.Location = new System.Drawing.Point(11, 364);
            this.groupBox27.Name = "groupBox27";
            this.groupBox27.Size = new System.Drawing.Size(612, 302);
            this.groupBox27.TabIndex = 101;
            this.groupBox27.TabStop = false;
            this.groupBox27.Text = "BMS模拟量数据";
            // 
            // txtBmsAnalogAlmGroup4
            // 
            this.txtBmsAnalogAlmGroup4.Location = new System.Drawing.Point(99, 276);
            this.txtBmsAnalogAlmGroup4.MaxLength = 8;
            this.txtBmsAnalogAlmGroup4.Name = "txtBmsAnalogAlmGroup4";
            this.txtBmsAnalogAlmGroup4.Size = new System.Drawing.Size(499, 21);
            this.txtBmsAnalogAlmGroup4.TabIndex = 260;
            // 
            // txtBmsAnalogAlmGroup3
            // 
            this.txtBmsAnalogAlmGroup3.Location = new System.Drawing.Point(99, 253);
            this.txtBmsAnalogAlmGroup3.MaxLength = 8;
            this.txtBmsAnalogAlmGroup3.Name = "txtBmsAnalogAlmGroup3";
            this.txtBmsAnalogAlmGroup3.Size = new System.Drawing.Size(499, 21);
            this.txtBmsAnalogAlmGroup3.TabIndex = 259;
            // 
            // label91
            // 
            this.label91.AutoSize = true;
            this.label91.Location = new System.Drawing.Point(6, 281);
            this.label91.Name = "label91";
            this.label91.Size = new System.Drawing.Size(95, 12);
            this.label91.TabIndex = 258;
            this.label91.Text = "BMS_AlarmGroup4";
            // 
            // label92
            // 
            this.label92.AutoSize = true;
            this.label92.Location = new System.Drawing.Point(6, 259);
            this.label92.Name = "label92";
            this.label92.Size = new System.Drawing.Size(95, 12);
            this.label92.TabIndex = 257;
            this.label92.Text = "BMS_AlarmGroup3";
            // 
            // label89
            // 
            this.label89.AutoSize = true;
            this.label89.Location = new System.Drawing.Point(504, 113);
            this.label89.Name = "label89";
            this.label89.Size = new System.Drawing.Size(23, 12);
            this.label89.TabIndex = 252;
            this.label89.Text = "SOE";
            // 
            // label90
            // 
            this.label90.AutoSize = true;
            this.label90.Location = new System.Drawing.Point(585, 114);
            this.label90.Name = "label90";
            this.label90.Size = new System.Drawing.Size(11, 12);
            this.label90.TabIndex = 250;
            this.label90.Text = "%";
            // 
            // txtBmsAnalogSOE
            // 
            this.txtBmsAnalogSOE.Location = new System.Drawing.Point(532, 109);
            this.txtBmsAnalogSOE.MaxLength = 8;
            this.txtBmsAnalogSOE.Name = "txtBmsAnalogSOE";
            this.txtBmsAnalogSOE.Size = new System.Drawing.Size(51, 21);
            this.txtBmsAnalogSOE.TabIndex = 251;
            // 
            // label78
            // 
            this.label78.AutoSize = true;
            this.label78.Location = new System.Drawing.Point(158, 137);
            this.label78.Name = "label78";
            this.label78.Size = new System.Drawing.Size(53, 12);
            this.label78.TabIndex = 249;
            this.label78.Text = "SOP_放电";
            // 
            // label79
            // 
            this.label79.AutoSize = true;
            this.label79.Location = new System.Drawing.Point(285, 138);
            this.label79.Name = "label79";
            this.label79.Size = new System.Drawing.Size(17, 12);
            this.label79.TabIndex = 247;
            this.label79.Text = "kW";
            // 
            // txtBmsAnalogSOP_discharge
            // 
            this.txtBmsAnalogSOP_discharge.Location = new System.Drawing.Point(215, 133);
            this.txtBmsAnalogSOP_discharge.MaxLength = 8;
            this.txtBmsAnalogSOP_discharge.Name = "txtBmsAnalogSOP_discharge";
            this.txtBmsAnalogSOP_discharge.Size = new System.Drawing.Size(66, 21);
            this.txtBmsAnalogSOP_discharge.TabIndex = 248;
            // 
            // label80
            // 
            this.label80.AutoSize = true;
            this.label80.Location = new System.Drawing.Point(6, 137);
            this.label80.Name = "label80";
            this.label80.Size = new System.Drawing.Size(53, 12);
            this.label80.TabIndex = 246;
            this.label80.Text = "SOP_充电";
            // 
            // label88
            // 
            this.label88.AutoSize = true;
            this.label88.Location = new System.Drawing.Point(134, 137);
            this.label88.Name = "label88";
            this.label88.Size = new System.Drawing.Size(17, 12);
            this.label88.TabIndex = 245;
            this.label88.Text = "kW";
            // 
            // txtBmsAnalogSOP_charge
            // 
            this.txtBmsAnalogSOP_charge.Location = new System.Drawing.Point(61, 133);
            this.txtBmsAnalogSOP_charge.MaxLength = 8;
            this.txtBmsAnalogSOP_charge.Name = "txtBmsAnalogSOP_charge";
            this.txtBmsAnalogSOP_charge.Size = new System.Drawing.Size(66, 21);
            this.txtBmsAnalogSOP_charge.TabIndex = 244;
            // 
            // label70
            // 
            this.label70.AutoSize = true;
            this.label70.Location = new System.Drawing.Point(408, 113);
            this.label70.Name = "label70";
            this.label70.Size = new System.Drawing.Size(23, 12);
            this.label70.TabIndex = 243;
            this.label70.Text = "SOH";
            // 
            // label73
            // 
            this.label73.AutoSize = true;
            this.label73.Location = new System.Drawing.Point(485, 115);
            this.label73.Name = "label73";
            this.label73.Size = new System.Drawing.Size(11, 12);
            this.label73.TabIndex = 241;
            this.label73.Text = "%";
            // 
            // txtBmsAnalogSOH
            // 
            this.txtBmsAnalogSOH.Location = new System.Drawing.Point(432, 109);
            this.txtBmsAnalogSOH.MaxLength = 8;
            this.txtBmsAnalogSOH.Name = "txtBmsAnalogSOH";
            this.txtBmsAnalogSOH.Size = new System.Drawing.Size(51, 21);
            this.txtBmsAnalogSOH.TabIndex = 242;
            // 
            // label76
            // 
            this.label76.AutoSize = true;
            this.label76.Location = new System.Drawing.Point(310, 113);
            this.label76.Name = "label76";
            this.label76.Size = new System.Drawing.Size(23, 12);
            this.label76.TabIndex = 240;
            this.label76.Text = "SOC";
            // 
            // label77
            // 
            this.label77.AutoSize = true;
            this.label77.Location = new System.Drawing.Point(388, 114);
            this.label77.Name = "label77";
            this.label77.Size = new System.Drawing.Size(11, 12);
            this.label77.TabIndex = 238;
            this.label77.Text = "%";
            // 
            // txtBmsAnalogSOC
            // 
            this.txtBmsAnalogSOC.Location = new System.Drawing.Point(335, 109);
            this.txtBmsAnalogSOC.MaxLength = 8;
            this.txtBmsAnalogSOC.Name = "txtBmsAnalogSOC";
            this.txtBmsAnalogSOC.Size = new System.Drawing.Size(51, 21);
            this.txtBmsAnalogSOC.TabIndex = 239;
            // 
            // label55
            // 
            this.label55.AutoSize = true;
            this.label55.Location = new System.Drawing.Point(463, 185);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(23, 12);
            this.label55.TabIndex = 237;
            this.label55.Text = "12V";
            // 
            // label56
            // 
            this.label56.AutoSize = true;
            this.label56.Location = new System.Drawing.Point(587, 186);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(11, 12);
            this.label56.TabIndex = 235;
            this.label56.Text = "V";
            // 
            // txtBmsAnalog12V
            // 
            this.txtBmsAnalog12V.Location = new System.Drawing.Point(517, 181);
            this.txtBmsAnalog12V.MaxLength = 8;
            this.txtBmsAnalog12V.Name = "txtBmsAnalog12V";
            this.txtBmsAnalog12V.Size = new System.Drawing.Size(66, 21);
            this.txtBmsAnalog12V.TabIndex = 236;
            // 
            // label53
            // 
            this.label53.AutoSize = true;
            this.label53.Location = new System.Drawing.Point(158, 113);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(53, 12);
            this.label53.TabIndex = 234;
            this.label53.Text = "电池Bat+";
            // 
            // label54
            // 
            this.label54.AutoSize = true;
            this.label54.Location = new System.Drawing.Point(285, 114);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(11, 12);
            this.label54.TabIndex = 232;
            this.label54.Text = "V";
            // 
            // txtBmsAnalogUbatPos
            // 
            this.txtBmsAnalogUbatPos.Location = new System.Drawing.Point(215, 109);
            this.txtBmsAnalogUbatPos.MaxLength = 8;
            this.txtBmsAnalogUbatPos.Name = "txtBmsAnalogUbatPos";
            this.txtBmsAnalogUbatPos.Size = new System.Drawing.Size(66, 21);
            this.txtBmsAnalogUbatPos.TabIndex = 233;
            // 
            // label176
            // 
            this.label176.AutoSize = true;
            this.label176.Location = new System.Drawing.Point(7, 185);
            this.label176.Name = "label176";
            this.label176.Size = new System.Drawing.Size(41, 12);
            this.label176.TabIndex = 231;
            this.label176.Text = "BAT30V";
            // 
            // label177
            // 
            this.label177.AutoSize = true;
            this.label177.Location = new System.Drawing.Point(134, 185);
            this.label177.Name = "label177";
            this.label177.Size = new System.Drawing.Size(11, 12);
            this.label177.TabIndex = 229;
            this.label177.Text = "V";
            // 
            // txtBmsAnalogBat30V
            // 
            this.txtBmsAnalogBat30V.Location = new System.Drawing.Point(62, 181);
            this.txtBmsAnalogBat30V.MaxLength = 8;
            this.txtBmsAnalogBat30V.Name = "txtBmsAnalogBat30V";
            this.txtBmsAnalogBat30V.Size = new System.Drawing.Size(66, 21);
            this.txtBmsAnalogBat30V.TabIndex = 230;
            // 
            // txtBmsAnalogAlmGroup2
            // 
            this.txtBmsAnalogAlmGroup2.Location = new System.Drawing.Point(99, 230);
            this.txtBmsAnalogAlmGroup2.MaxLength = 8;
            this.txtBmsAnalogAlmGroup2.Name = "txtBmsAnalogAlmGroup2";
            this.txtBmsAnalogAlmGroup2.Size = new System.Drawing.Size(499, 21);
            this.txtBmsAnalogAlmGroup2.TabIndex = 228;
            // 
            // txtBmsAnalogAlmGroup1
            // 
            this.txtBmsAnalogAlmGroup1.Location = new System.Drawing.Point(99, 207);
            this.txtBmsAnalogAlmGroup1.MaxLength = 8;
            this.txtBmsAnalogAlmGroup1.Name = "txtBmsAnalogAlmGroup1";
            this.txtBmsAnalogAlmGroup1.Size = new System.Drawing.Size(499, 21);
            this.txtBmsAnalogAlmGroup1.TabIndex = 227;
            // 
            // label160
            // 
            this.label160.AutoSize = true;
            this.label160.Location = new System.Drawing.Point(6, 235);
            this.label160.Name = "label160";
            this.label160.Size = new System.Drawing.Size(95, 12);
            this.label160.TabIndex = 226;
            this.label160.Text = "BMS_AlarmGroup2";
            // 
            // label161
            // 
            this.label161.AutoSize = true;
            this.label161.Location = new System.Drawing.Point(6, 213);
            this.label161.Name = "label161";
            this.label161.Size = new System.Drawing.Size(95, 12);
            this.label161.TabIndex = 225;
            this.label161.Text = "BMS_AlarmGroup1";
            // 
            // label146
            // 
            this.label146.AutoSize = true;
            this.label146.Location = new System.Drawing.Point(460, 21);
            this.label146.Name = "label146";
            this.label146.Size = new System.Drawing.Size(59, 12);
            this.label146.TabIndex = 220;
            this.label146.Text = "电芯温度4";
            // 
            // label186
            // 
            this.label186.AutoSize = true;
            this.label186.Location = new System.Drawing.Point(460, 89);
            this.label186.Name = "label186";
            this.label186.Size = new System.Drawing.Size(59, 12);
            this.label186.TabIndex = 218;
            this.label186.Text = "电芯电压8";
            // 
            // label188
            // 
            this.label188.AutoSize = true;
            this.label188.Location = new System.Drawing.Point(587, 90);
            this.label188.Name = "label188";
            this.label188.Size = new System.Drawing.Size(11, 12);
            this.label188.TabIndex = 216;
            this.label188.Text = "V";
            // 
            // txtBmsAnalogVbat8
            // 
            this.txtBmsAnalogVbat8.Location = new System.Drawing.Point(517, 85);
            this.txtBmsAnalogVbat8.MaxLength = 8;
            this.txtBmsAnalogVbat8.Name = "txtBmsAnalogVbat8";
            this.txtBmsAnalogVbat8.Size = new System.Drawing.Size(66, 21);
            this.txtBmsAnalogVbat8.TabIndex = 217;
            // 
            // label198
            // 
            this.label198.AutoSize = true;
            this.label198.Location = new System.Drawing.Point(460, 66);
            this.label198.Name = "label198";
            this.label198.Size = new System.Drawing.Size(59, 12);
            this.label198.TabIndex = 215;
            this.label198.Text = "电芯温度8";
            // 
            // label199
            // 
            this.label199.AutoSize = true;
            this.label199.Location = new System.Drawing.Point(584, 66);
            this.label199.Name = "label199";
            this.label199.Size = new System.Drawing.Size(17, 12);
            this.label199.TabIndex = 213;
            this.label199.Text = "℃";
            // 
            // txtBmsAnalogTbat8
            // 
            this.txtBmsAnalogTbat8.Location = new System.Drawing.Point(517, 62);
            this.txtBmsAnalogTbat8.MaxLength = 8;
            this.txtBmsAnalogTbat8.Name = "txtBmsAnalogTbat8";
            this.txtBmsAnalogTbat8.Size = new System.Drawing.Size(66, 21);
            this.txtBmsAnalogTbat8.TabIndex = 214;
            // 
            // label200
            // 
            this.label200.AutoSize = true;
            this.label200.Location = new System.Drawing.Point(311, 89);
            this.label200.Name = "label200";
            this.label200.Size = new System.Drawing.Size(59, 12);
            this.label200.TabIndex = 212;
            this.label200.Text = "电芯电压7";
            // 
            // label201
            // 
            this.label201.AutoSize = true;
            this.label201.Location = new System.Drawing.Point(437, 90);
            this.label201.Name = "label201";
            this.label201.Size = new System.Drawing.Size(11, 12);
            this.label201.TabIndex = 210;
            this.label201.Text = "V";
            // 
            // txtBmsAnalogVbat7
            // 
            this.txtBmsAnalogVbat7.Location = new System.Drawing.Point(368, 85);
            this.txtBmsAnalogVbat7.MaxLength = 8;
            this.txtBmsAnalogVbat7.Name = "txtBmsAnalogVbat7";
            this.txtBmsAnalogVbat7.Size = new System.Drawing.Size(66, 21);
            this.txtBmsAnalogVbat7.TabIndex = 211;
            // 
            // label202
            // 
            this.label202.AutoSize = true;
            this.label202.Location = new System.Drawing.Point(311, 66);
            this.label202.Name = "label202";
            this.label202.Size = new System.Drawing.Size(59, 12);
            this.label202.TabIndex = 209;
            this.label202.Text = "电芯温度7";
            // 
            // label203
            // 
            this.label203.AutoSize = true;
            this.label203.Location = new System.Drawing.Point(435, 66);
            this.label203.Name = "label203";
            this.label203.Size = new System.Drawing.Size(17, 12);
            this.label203.TabIndex = 207;
            this.label203.Text = "℃";
            // 
            // txtBmsAnalogTbat7
            // 
            this.txtBmsAnalogTbat7.Location = new System.Drawing.Point(368, 62);
            this.txtBmsAnalogTbat7.MaxLength = 8;
            this.txtBmsAnalogTbat7.Name = "txtBmsAnalogTbat7";
            this.txtBmsAnalogTbat7.Size = new System.Drawing.Size(66, 21);
            this.txtBmsAnalogTbat7.TabIndex = 208;
            // 
            // label204
            // 
            this.label204.AutoSize = true;
            this.label204.Location = new System.Drawing.Point(159, 89);
            this.label204.Name = "label204";
            this.label204.Size = new System.Drawing.Size(59, 12);
            this.label204.TabIndex = 206;
            this.label204.Text = "电芯电压6";
            // 
            // label205
            // 
            this.label205.AutoSize = true;
            this.label205.Location = new System.Drawing.Point(286, 90);
            this.label205.Name = "label205";
            this.label205.Size = new System.Drawing.Size(11, 12);
            this.label205.TabIndex = 204;
            this.label205.Text = "V";
            // 
            // txtBmsAnalogVbat6
            // 
            this.txtBmsAnalogVbat6.Location = new System.Drawing.Point(216, 85);
            this.txtBmsAnalogVbat6.MaxLength = 8;
            this.txtBmsAnalogVbat6.Name = "txtBmsAnalogVbat6";
            this.txtBmsAnalogVbat6.Size = new System.Drawing.Size(66, 21);
            this.txtBmsAnalogVbat6.TabIndex = 205;
            // 
            // label206
            // 
            this.label206.AutoSize = true;
            this.label206.Location = new System.Drawing.Point(159, 66);
            this.label206.Name = "label206";
            this.label206.Size = new System.Drawing.Size(59, 12);
            this.label206.TabIndex = 203;
            this.label206.Text = "电芯温度6";
            // 
            // label207
            // 
            this.label207.AutoSize = true;
            this.label207.Location = new System.Drawing.Point(284, 66);
            this.label207.Name = "label207";
            this.label207.Size = new System.Drawing.Size(17, 12);
            this.label207.TabIndex = 201;
            this.label207.Text = "℃";
            // 
            // txtBmsAnalogTbat6
            // 
            this.txtBmsAnalogTbat6.Location = new System.Drawing.Point(216, 62);
            this.txtBmsAnalogTbat6.MaxLength = 8;
            this.txtBmsAnalogTbat6.Name = "txtBmsAnalogTbat6";
            this.txtBmsAnalogTbat6.Size = new System.Drawing.Size(66, 21);
            this.txtBmsAnalogTbat6.TabIndex = 202;
            // 
            // label208
            // 
            this.label208.AutoSize = true;
            this.label208.Location = new System.Drawing.Point(7, 89);
            this.label208.Name = "label208";
            this.label208.Size = new System.Drawing.Size(59, 12);
            this.label208.TabIndex = 200;
            this.label208.Text = "电芯电压5";
            // 
            // label209
            // 
            this.label209.AutoSize = true;
            this.label209.Location = new System.Drawing.Point(135, 90);
            this.label209.Name = "label209";
            this.label209.Size = new System.Drawing.Size(11, 12);
            this.label209.TabIndex = 198;
            this.label209.Text = "V";
            // 
            // txtBmsAnalogVbat5
            // 
            this.txtBmsAnalogVbat5.Location = new System.Drawing.Point(64, 85);
            this.txtBmsAnalogVbat5.MaxLength = 8;
            this.txtBmsAnalogVbat5.Name = "txtBmsAnalogVbat5";
            this.txtBmsAnalogVbat5.Size = new System.Drawing.Size(66, 21);
            this.txtBmsAnalogVbat5.TabIndex = 199;
            // 
            // label210
            // 
            this.label210.AutoSize = true;
            this.label210.Location = new System.Drawing.Point(7, 66);
            this.label210.Name = "label210";
            this.label210.Size = new System.Drawing.Size(59, 12);
            this.label210.TabIndex = 197;
            this.label210.Text = "电芯温度5";
            // 
            // label211
            // 
            this.label211.AutoSize = true;
            this.label211.Location = new System.Drawing.Point(133, 67);
            this.label211.Name = "label211";
            this.label211.Size = new System.Drawing.Size(17, 12);
            this.label211.TabIndex = 196;
            this.label211.Text = "℃";
            // 
            // txtBmsAnalogTbat5
            // 
            this.txtBmsAnalogTbat5.Location = new System.Drawing.Point(64, 62);
            this.txtBmsAnalogTbat5.MaxLength = 8;
            this.txtBmsAnalogTbat5.Name = "txtBmsAnalogTbat5";
            this.txtBmsAnalogTbat5.Size = new System.Drawing.Size(66, 21);
            this.txtBmsAnalogTbat5.TabIndex = 195;
            // 
            // label178
            // 
            this.label178.AutoSize = true;
            this.label178.Location = new System.Drawing.Point(463, 162);
            this.label178.Name = "label178";
            this.label178.Size = new System.Drawing.Size(35, 12);
            this.label178.TabIndex = 185;
            this.label178.Text = "AC30V";
            // 
            // label179
            // 
            this.label179.AutoSize = true;
            this.label179.Location = new System.Drawing.Point(587, 163);
            this.label179.Name = "label179";
            this.label179.Size = new System.Drawing.Size(11, 12);
            this.label179.TabIndex = 183;
            this.label179.Text = "V";
            // 
            // txtBmsAnalogAc30V
            // 
            this.txtBmsAnalogAc30V.Location = new System.Drawing.Point(517, 158);
            this.txtBmsAnalogAc30V.MaxLength = 8;
            this.txtBmsAnalogAc30V.Name = "txtBmsAnalogAc30V";
            this.txtBmsAnalogAc30V.Size = new System.Drawing.Size(66, 21);
            this.txtBmsAnalogAc30V.TabIndex = 184;
            // 
            // label180
            // 
            this.label180.AutoSize = true;
            this.label180.Location = new System.Drawing.Point(311, 162);
            this.label180.Name = "label180";
            this.label180.Size = new System.Drawing.Size(77, 12);
            this.label180.TabIndex = 182;
            this.label180.Text = "均衡电阻温度";
            // 
            // label181
            // 
            this.label181.AutoSize = true;
            this.label181.Location = new System.Drawing.Point(437, 162);
            this.label181.Name = "label181";
            this.label181.Size = new System.Drawing.Size(17, 12);
            this.label181.TabIndex = 180;
            this.label181.Text = "℃";
            // 
            // txtBmsAnalogTblncingr
            // 
            this.txtBmsAnalogTblncingr.Location = new System.Drawing.Point(386, 158);
            this.txtBmsAnalogTblncingr.MaxLength = 8;
            this.txtBmsAnalogTblncingr.Name = "txtBmsAnalogTblncingr";
            this.txtBmsAnalogTblncingr.Size = new System.Drawing.Size(46, 21);
            this.txtBmsAnalogTblncingr.TabIndex = 181;
            // 
            // label182
            // 
            this.label182.AutoSize = true;
            this.label182.Location = new System.Drawing.Point(158, 162);
            this.label182.Name = "label182";
            this.label182.Size = new System.Drawing.Size(29, 12);
            this.label182.TabIndex = 179;
            this.label182.Text = "板温";
            // 
            // label183
            // 
            this.label183.AutoSize = true;
            this.label183.Location = new System.Drawing.Point(285, 162);
            this.label183.Name = "label183";
            this.label183.Size = new System.Drawing.Size(17, 12);
            this.label183.TabIndex = 177;
            this.label183.Text = "℃";
            // 
            // txtBmsAnalogTboard
            // 
            this.txtBmsAnalogTboard.Location = new System.Drawing.Point(214, 158);
            this.txtBmsAnalogTboard.MaxLength = 8;
            this.txtBmsAnalogTboard.Name = "txtBmsAnalogTboard";
            this.txtBmsAnalogTboard.Size = new System.Drawing.Size(66, 21);
            this.txtBmsAnalogTboard.TabIndex = 178;
            // 
            // label184
            // 
            this.label184.AutoSize = true;
            this.label184.Location = new System.Drawing.Point(6, 162);
            this.label184.Name = "label184";
            this.label184.Size = new System.Drawing.Size(59, 12);
            this.label184.TabIndex = 176;
            this.label184.Text = "端子温度2";
            // 
            // label185
            // 
            this.label185.AutoSize = true;
            this.label185.Location = new System.Drawing.Point(131, 162);
            this.label185.Name = "label185";
            this.label185.Size = new System.Drawing.Size(17, 12);
            this.label185.TabIndex = 174;
            this.label185.Text = "℃";
            // 
            // txtBmsAnalogTterminal2
            // 
            this.txtBmsAnalogTterminal2.Location = new System.Drawing.Point(63, 158);
            this.txtBmsAnalogTterminal2.MaxLength = 8;
            this.txtBmsAnalogTterminal2.Name = "txtBmsAnalogTterminal2";
            this.txtBmsAnalogTterminal2.Size = new System.Drawing.Size(66, 21);
            this.txtBmsAnalogTterminal2.TabIndex = 175;
            // 
            // label187
            // 
            this.label187.AutoSize = true;
            this.label187.Location = new System.Drawing.Point(461, 137);
            this.label187.Name = "label187";
            this.label187.Size = new System.Drawing.Size(59, 12);
            this.label187.TabIndex = 173;
            this.label187.Text = "端子温度1";
            // 
            // label189
            // 
            this.label189.AutoSize = true;
            this.label189.Location = new System.Drawing.Point(587, 138);
            this.label189.Name = "label189";
            this.label189.Size = new System.Drawing.Size(17, 12);
            this.label189.TabIndex = 171;
            this.label189.Text = "℃";
            // 
            // txtBmsAnalogTterminal1
            // 
            this.txtBmsAnalogTterminal1.Location = new System.Drawing.Point(517, 133);
            this.txtBmsAnalogTterminal1.MaxLength = 8;
            this.txtBmsAnalogTterminal1.Name = "txtBmsAnalogTterminal1";
            this.txtBmsAnalogTterminal1.Size = new System.Drawing.Size(66, 21);
            this.txtBmsAnalogTterminal1.TabIndex = 172;
            // 
            // label190
            // 
            this.label190.AutoSize = true;
            this.label190.Location = new System.Drawing.Point(313, 186);
            this.label190.Name = "label190";
            this.label190.Size = new System.Drawing.Size(23, 12);
            this.label190.TabIndex = 194;
            this.label190.Text = "3V3";
            // 
            // label191
            // 
            this.label191.AutoSize = true;
            this.label191.Location = new System.Drawing.Point(311, 137);
            this.label191.Name = "label191";
            this.label191.Size = new System.Drawing.Size(53, 12);
            this.label191.TabIndex = 170;
            this.label191.Text = "绝缘阻抗";
            // 
            // label192
            // 
            this.label192.AutoSize = true;
            this.label192.Location = new System.Drawing.Point(439, 186);
            this.label192.Name = "label192";
            this.label192.Size = new System.Drawing.Size(11, 12);
            this.label192.TabIndex = 192;
            this.label192.Text = "V";
            // 
            // label193
            // 
            this.label193.AutoSize = true;
            this.label193.Location = new System.Drawing.Point(436, 138);
            this.label193.Name = "label193";
            this.label193.Size = new System.Drawing.Size(23, 12);
            this.label193.TabIndex = 168;
            this.label193.Text = "kΩ";
            // 
            // txtBmsAnalog3V3
            // 
            this.txtBmsAnalog3V3.Location = new System.Drawing.Point(366, 181);
            this.txtBmsAnalog3V3.MaxLength = 8;
            this.txtBmsAnalog3V3.Name = "txtBmsAnalog3V3";
            this.txtBmsAnalog3V3.Size = new System.Drawing.Size(66, 21);
            this.txtBmsAnalog3V3.TabIndex = 193;
            // 
            // txtBmsAnalogISR
            // 
            this.txtBmsAnalogISR.Location = new System.Drawing.Point(367, 133);
            this.txtBmsAnalogISR.MaxLength = 8;
            this.txtBmsAnalogISR.Name = "txtBmsAnalogISR";
            this.txtBmsAnalogISR.Size = new System.Drawing.Size(66, 21);
            this.txtBmsAnalogISR.TabIndex = 169;
            // 
            // label194
            // 
            this.label194.AutoSize = true;
            this.label194.Location = new System.Drawing.Point(158, 185);
            this.label194.Name = "label194";
            this.label194.Size = new System.Drawing.Size(23, 12);
            this.label194.TabIndex = 191;
            this.label194.Text = "30V";
            // 
            // label195
            // 
            this.label195.AutoSize = true;
            this.label195.Location = new System.Drawing.Point(288, 185);
            this.label195.Name = "label195";
            this.label195.Size = new System.Drawing.Size(11, 12);
            this.label195.TabIndex = 190;
            this.label195.Text = "V";
            // 
            // label196
            // 
            this.label196.AutoSize = true;
            this.label196.Location = new System.Drawing.Point(6, 113);
            this.label196.Name = "label196";
            this.label196.Size = new System.Drawing.Size(53, 12);
            this.label196.TabIndex = 167;
            this.label196.Text = "电池电流";
            // 
            // txtBmsAnalog30V
            // 
            this.txtBmsAnalog30V.Location = new System.Drawing.Point(214, 181);
            this.txtBmsAnalog30V.MaxLength = 8;
            this.txtBmsAnalog30V.Name = "txtBmsAnalog30V";
            this.txtBmsAnalog30V.Size = new System.Drawing.Size(66, 21);
            this.txtBmsAnalog30V.TabIndex = 189;
            // 
            // label197
            // 
            this.label197.AutoSize = true;
            this.label197.Location = new System.Drawing.Point(134, 113);
            this.label197.Name = "label197";
            this.label197.Size = new System.Drawing.Size(11, 12);
            this.label197.TabIndex = 166;
            this.label197.Text = "A";
            // 
            // txtBmsAnalogIbat
            // 
            this.txtBmsAnalogIbat.Location = new System.Drawing.Point(61, 109);
            this.txtBmsAnalogIbat.MaxLength = 8;
            this.txtBmsAnalogIbat.Name = "txtBmsAnalogIbat";
            this.txtBmsAnalogIbat.Size = new System.Drawing.Size(66, 21);
            this.txtBmsAnalogIbat.TabIndex = 165;
            // 
            // label144
            // 
            this.label144.AutoSize = true;
            this.label144.Location = new System.Drawing.Point(460, 43);
            this.label144.Name = "label144";
            this.label144.Size = new System.Drawing.Size(59, 12);
            this.label144.TabIndex = 140;
            this.label144.Text = "电芯电压4";
            // 
            // label145
            // 
            this.label145.AutoSize = true;
            this.label145.Location = new System.Drawing.Point(587, 44);
            this.label145.Name = "label145";
            this.label145.Size = new System.Drawing.Size(11, 12);
            this.label145.TabIndex = 138;
            this.label145.Text = "V";
            // 
            // txtBmsAnalogVbat4
            // 
            this.txtBmsAnalogVbat4.Location = new System.Drawing.Point(517, 39);
            this.txtBmsAnalogVbat4.MaxLength = 8;
            this.txtBmsAnalogVbat4.Name = "txtBmsAnalogVbat4";
            this.txtBmsAnalogVbat4.Size = new System.Drawing.Size(66, 21);
            this.txtBmsAnalogVbat4.TabIndex = 139;
            // 
            // label147
            // 
            this.label147.AutoSize = true;
            this.label147.Location = new System.Drawing.Point(584, 20);
            this.label147.Name = "label147";
            this.label147.Size = new System.Drawing.Size(17, 12);
            this.label147.TabIndex = 135;
            this.label147.Text = "℃";
            // 
            // txtBmsAnalogTbat4
            // 
            this.txtBmsAnalogTbat4.Location = new System.Drawing.Point(517, 16);
            this.txtBmsAnalogTbat4.MaxLength = 8;
            this.txtBmsAnalogTbat4.Name = "txtBmsAnalogTbat4";
            this.txtBmsAnalogTbat4.Size = new System.Drawing.Size(66, 21);
            this.txtBmsAnalogTbat4.TabIndex = 136;
            // 
            // label148
            // 
            this.label148.AutoSize = true;
            this.label148.Location = new System.Drawing.Point(311, 43);
            this.label148.Name = "label148";
            this.label148.Size = new System.Drawing.Size(59, 12);
            this.label148.TabIndex = 134;
            this.label148.Text = "电芯电压3";
            // 
            // label149
            // 
            this.label149.AutoSize = true;
            this.label149.Location = new System.Drawing.Point(437, 44);
            this.label149.Name = "label149";
            this.label149.Size = new System.Drawing.Size(11, 12);
            this.label149.TabIndex = 132;
            this.label149.Text = "V";
            // 
            // txtBmsAnalogVbat3
            // 
            this.txtBmsAnalogVbat3.Location = new System.Drawing.Point(368, 39);
            this.txtBmsAnalogVbat3.MaxLength = 8;
            this.txtBmsAnalogVbat3.Name = "txtBmsAnalogVbat3";
            this.txtBmsAnalogVbat3.Size = new System.Drawing.Size(66, 21);
            this.txtBmsAnalogVbat3.TabIndex = 133;
            // 
            // label150
            // 
            this.label150.AutoSize = true;
            this.label150.Location = new System.Drawing.Point(311, 20);
            this.label150.Name = "label150";
            this.label150.Size = new System.Drawing.Size(59, 12);
            this.label150.TabIndex = 131;
            this.label150.Text = "电芯温度3";
            // 
            // label151
            // 
            this.label151.AutoSize = true;
            this.label151.Location = new System.Drawing.Point(435, 20);
            this.label151.Name = "label151";
            this.label151.Size = new System.Drawing.Size(17, 12);
            this.label151.TabIndex = 129;
            this.label151.Text = "℃";
            // 
            // txtBmsAnalogTbat3
            // 
            this.txtBmsAnalogTbat3.Location = new System.Drawing.Point(368, 16);
            this.txtBmsAnalogTbat3.MaxLength = 8;
            this.txtBmsAnalogTbat3.Name = "txtBmsAnalogTbat3";
            this.txtBmsAnalogTbat3.Size = new System.Drawing.Size(66, 21);
            this.txtBmsAnalogTbat3.TabIndex = 130;
            // 
            // label152
            // 
            this.label152.AutoSize = true;
            this.label152.Location = new System.Drawing.Point(159, 43);
            this.label152.Name = "label152";
            this.label152.Size = new System.Drawing.Size(59, 12);
            this.label152.TabIndex = 128;
            this.label152.Text = "电芯电压2";
            // 
            // label153
            // 
            this.label153.AutoSize = true;
            this.label153.Location = new System.Drawing.Point(286, 44);
            this.label153.Name = "label153";
            this.label153.Size = new System.Drawing.Size(11, 12);
            this.label153.TabIndex = 126;
            this.label153.Text = "V";
            // 
            // txtBmsAnalogVbat2
            // 
            this.txtBmsAnalogVbat2.Location = new System.Drawing.Point(216, 39);
            this.txtBmsAnalogVbat2.MaxLength = 8;
            this.txtBmsAnalogVbat2.Name = "txtBmsAnalogVbat2";
            this.txtBmsAnalogVbat2.Size = new System.Drawing.Size(66, 21);
            this.txtBmsAnalogVbat2.TabIndex = 127;
            // 
            // label154
            // 
            this.label154.AutoSize = true;
            this.label154.Location = new System.Drawing.Point(159, 20);
            this.label154.Name = "label154";
            this.label154.Size = new System.Drawing.Size(59, 12);
            this.label154.TabIndex = 125;
            this.label154.Text = "电芯温度2";
            // 
            // label155
            // 
            this.label155.AutoSize = true;
            this.label155.Location = new System.Drawing.Point(284, 20);
            this.label155.Name = "label155";
            this.label155.Size = new System.Drawing.Size(17, 12);
            this.label155.TabIndex = 123;
            this.label155.Text = "℃";
            // 
            // txtBmsAnalogTbat2
            // 
            this.txtBmsAnalogTbat2.Location = new System.Drawing.Point(216, 16);
            this.txtBmsAnalogTbat2.MaxLength = 8;
            this.txtBmsAnalogTbat2.Name = "txtBmsAnalogTbat2";
            this.txtBmsAnalogTbat2.Size = new System.Drawing.Size(66, 21);
            this.txtBmsAnalogTbat2.TabIndex = 124;
            // 
            // label156
            // 
            this.label156.AutoSize = true;
            this.label156.Location = new System.Drawing.Point(7, 43);
            this.label156.Name = "label156";
            this.label156.Size = new System.Drawing.Size(59, 12);
            this.label156.TabIndex = 122;
            this.label156.Text = "电芯电压1";
            // 
            // label157
            // 
            this.label157.AutoSize = true;
            this.label157.Location = new System.Drawing.Point(135, 44);
            this.label157.Name = "label157";
            this.label157.Size = new System.Drawing.Size(11, 12);
            this.label157.TabIndex = 120;
            this.label157.Text = "V";
            // 
            // txtBmsAnalogVbat1
            // 
            this.txtBmsAnalogVbat1.Location = new System.Drawing.Point(64, 39);
            this.txtBmsAnalogVbat1.MaxLength = 8;
            this.txtBmsAnalogVbat1.Name = "txtBmsAnalogVbat1";
            this.txtBmsAnalogVbat1.Size = new System.Drawing.Size(66, 21);
            this.txtBmsAnalogVbat1.TabIndex = 121;
            // 
            // label158
            // 
            this.label158.AutoSize = true;
            this.label158.Location = new System.Drawing.Point(7, 20);
            this.label158.Name = "label158";
            this.label158.Size = new System.Drawing.Size(59, 12);
            this.label158.TabIndex = 119;
            this.label158.Text = "电芯温度1";
            // 
            // label159
            // 
            this.label159.AutoSize = true;
            this.label159.Location = new System.Drawing.Point(133, 21);
            this.label159.Name = "label159";
            this.label159.Size = new System.Drawing.Size(17, 12);
            this.label159.TabIndex = 118;
            this.label159.Text = "℃";
            // 
            // txtBmsAnalogTbat1
            // 
            this.txtBmsAnalogTbat1.Location = new System.Drawing.Point(64, 16);
            this.txtBmsAnalogTbat1.MaxLength = 8;
            this.txtBmsAnalogTbat1.Name = "txtBmsAnalogTbat1";
            this.txtBmsAnalogTbat1.Size = new System.Drawing.Size(66, 21);
            this.txtBmsAnalogTbat1.TabIndex = 117;
            // 
            // groupBox13
            // 
            this.groupBox13.Controls.Add(this.groupBox32);
            this.groupBox13.Controls.Add(this.groupBox29);
            this.groupBox13.Controls.Add(this.groupBox28);
            this.groupBox13.Location = new System.Drawing.Point(11, 2);
            this.groupBox13.Name = "groupBox13";
            this.groupBox13.Size = new System.Drawing.Size(515, 359);
            this.groupBox13.TabIndex = 100;
            this.groupBox13.TabStop = false;
            this.groupBox13.Text = "PCS数据";
            // 
            // groupBox32
            // 
            this.groupBox32.Controls.Add(this.label337);
            this.groupBox32.Controls.Add(this.txtCAnalogExternalFan2State);
            this.groupBox32.Controls.Add(this.label338);
            this.groupBox32.Controls.Add(this.txtCAnalogExternalFan1State);
            this.groupBox32.Controls.Add(this.label339);
            this.groupBox32.Controls.Add(this.txtCAnalogInternalFanState);
            this.groupBox32.Controls.Add(this.label51);
            this.groupBox32.Controls.Add(this.label174);
            this.groupBox32.Controls.Add(this.label52);
            this.groupBox32.Controls.Add(this.txtCAnalogGridFreq);
            this.groupBox32.Controls.Add(this.label175);
            this.groupBox32.Controls.Add(this.txtCAnalogQout);
            this.groupBox32.Controls.Add(this.label212);
            this.groupBox32.Controls.Add(this.label213);
            this.groupBox32.Controls.Add(this.txtCAnalogPout);
            this.groupBox32.Controls.Add(this.label128);
            this.groupBox32.Controls.Add(this.label129);
            this.groupBox32.Controls.Add(this.txtCAnalog10V);
            this.groupBox32.Controls.Add(this.label130);
            this.groupBox32.Controls.Add(this.label131);
            this.groupBox32.Controls.Add(this.txtCAnalogDci);
            this.groupBox32.Controls.Add(this.label132);
            this.groupBox32.Controls.Add(this.label133);
            this.groupBox32.Controls.Add(this.txtCAnalogSecTemp);
            this.groupBox32.Controls.Add(this.label134);
            this.groupBox32.Controls.Add(this.label135);
            this.groupBox32.Controls.Add(this.txtCAnalogPriTemp);
            this.groupBox32.Controls.Add(this.label136);
            this.groupBox32.Controls.Add(this.label137);
            this.groupBox32.Controls.Add(this.txtCAnalogVbat);
            this.groupBox32.Controls.Add(this.label138);
            this.groupBox32.Controls.Add(this.label139);
            this.groupBox32.Controls.Add(this.txtCAnalogIgrid);
            this.groupBox32.Controls.Add(this.label140);
            this.groupBox32.Controls.Add(this.label141);
            this.groupBox32.Controls.Add(this.txtCAnalogPowerVgrid);
            this.groupBox32.Controls.Add(this.label142);
            this.groupBox32.Controls.Add(this.label143);
            this.groupBox32.Controls.Add(this.txtCAnalogVgrid);
            this.groupBox32.Location = new System.Drawing.Point(343, 17);
            this.groupBox32.Name = "groupBox32";
            this.groupBox32.Size = new System.Drawing.Size(168, 338);
            this.groupBox32.TabIndex = 93;
            this.groupBox32.TabStop = false;
            this.groupBox32.Text = "C相模拟量数据";
            // 
            // label337
            // 
            this.label337.AutoSize = true;
            this.label337.Location = new System.Drawing.Point(1, 317);
            this.label337.Name = "label337";
            this.label337.Size = new System.Drawing.Size(83, 12);
            this.label337.TabIndex = 114;
            this.label337.Text = "外部风扇2状态";
            // 
            // txtCAnalogExternalFan2State
            // 
            this.txtCAnalogExternalFan2State.Location = new System.Drawing.Point(83, 313);
            this.txtCAnalogExternalFan2State.MaxLength = 8;
            this.txtCAnalogExternalFan2State.Name = "txtCAnalogExternalFan2State";
            this.txtCAnalogExternalFan2State.Size = new System.Drawing.Size(55, 21);
            this.txtCAnalogExternalFan2State.TabIndex = 113;
            // 
            // label338
            // 
            this.label338.AutoSize = true;
            this.label338.Location = new System.Drawing.Point(2, 295);
            this.label338.Name = "label338";
            this.label338.Size = new System.Drawing.Size(83, 12);
            this.label338.TabIndex = 112;
            this.label338.Text = "外部风扇1状态";
            // 
            // txtCAnalogExternalFan1State
            // 
            this.txtCAnalogExternalFan1State.Location = new System.Drawing.Point(83, 291);
            this.txtCAnalogExternalFan1State.MaxLength = 8;
            this.txtCAnalogExternalFan1State.Name = "txtCAnalogExternalFan1State";
            this.txtCAnalogExternalFan1State.Size = new System.Drawing.Size(55, 21);
            this.txtCAnalogExternalFan1State.TabIndex = 111;
            // 
            // label339
            // 
            this.label339.AutoSize = true;
            this.label339.Location = new System.Drawing.Point(2, 272);
            this.label339.Name = "label339";
            this.label339.Size = new System.Drawing.Size(77, 12);
            this.label339.TabIndex = 110;
            this.label339.Text = "内部风扇状态";
            // 
            // txtCAnalogInternalFanState
            // 
            this.txtCAnalogInternalFanState.Location = new System.Drawing.Point(83, 268);
            this.txtCAnalogInternalFanState.MaxLength = 8;
            this.txtCAnalogInternalFanState.Name = "txtCAnalogInternalFanState";
            this.txtCAnalogInternalFanState.Size = new System.Drawing.Size(55, 21);
            this.txtCAnalogInternalFanState.TabIndex = 109;
            // 
            // label51
            // 
            this.label51.AutoSize = true;
            this.label51.Location = new System.Drawing.Point(140, 249);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(17, 12);
            this.label51.TabIndex = 105;
            this.label51.Text = "Hz";
            // 
            // label174
            // 
            this.label174.AutoSize = true;
            this.label174.Location = new System.Drawing.Point(3, 41);
            this.label174.Name = "label174";
            this.label174.Size = new System.Drawing.Size(53, 12);
            this.label174.TabIndex = 101;
            this.label174.Text = "无功功率";
            // 
            // label52
            // 
            this.label52.AutoSize = true;
            this.label52.Location = new System.Drawing.Point(3, 249);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(53, 12);
            this.label52.TabIndex = 104;
            this.label52.Text = "电网频率";
            // 
            // txtCAnalogGridFreq
            // 
            this.txtCAnalogGridFreq.Location = new System.Drawing.Point(54, 245);
            this.txtCAnalogGridFreq.MaxLength = 8;
            this.txtCAnalogGridFreq.Name = "txtCAnalogGridFreq";
            this.txtCAnalogGridFreq.Size = new System.Drawing.Size(83, 21);
            this.txtCAnalogGridFreq.TabIndex = 103;
            // 
            // label175
            // 
            this.label175.AutoSize = true;
            this.label175.Location = new System.Drawing.Point(138, 41);
            this.label175.Name = "label175";
            this.label175.Size = new System.Drawing.Size(29, 12);
            this.label175.TabIndex = 99;
            this.label175.Text = "kVar";
            // 
            // txtCAnalogQout
            // 
            this.txtCAnalogQout.Location = new System.Drawing.Point(53, 37);
            this.txtCAnalogQout.MaxLength = 8;
            this.txtCAnalogQout.Name = "txtCAnalogQout";
            this.txtCAnalogQout.Size = new System.Drawing.Size(84, 21);
            this.txtCAnalogQout.TabIndex = 100;
            // 
            // label212
            // 
            this.label212.AutoSize = true;
            this.label212.Location = new System.Drawing.Point(3, 18);
            this.label212.Name = "label212";
            this.label212.Size = new System.Drawing.Size(53, 12);
            this.label212.TabIndex = 98;
            this.label212.Text = "有功功率";
            // 
            // label213
            // 
            this.label213.AutoSize = true;
            this.label213.Location = new System.Drawing.Point(138, 18);
            this.label213.Name = "label213";
            this.label213.Size = new System.Drawing.Size(17, 12);
            this.label213.TabIndex = 96;
            this.label213.Text = "kW";
            // 
            // txtCAnalogPout
            // 
            this.txtCAnalogPout.Location = new System.Drawing.Point(54, 14);
            this.txtCAnalogPout.MaxLength = 8;
            this.txtCAnalogPout.Name = "txtCAnalogPout";
            this.txtCAnalogPout.Size = new System.Drawing.Size(83, 21);
            this.txtCAnalogPout.TabIndex = 97;
            // 
            // label128
            // 
            this.label128.AutoSize = true;
            this.label128.Location = new System.Drawing.Point(4, 226);
            this.label128.Name = "label128";
            this.label128.Size = new System.Drawing.Size(23, 12);
            this.label128.TabIndex = 89;
            this.label128.Text = "10V";
            // 
            // label129
            // 
            this.label129.AutoSize = true;
            this.label129.Location = new System.Drawing.Point(141, 226);
            this.label129.Name = "label129";
            this.label129.Size = new System.Drawing.Size(11, 12);
            this.label129.TabIndex = 87;
            this.label129.Text = "V";
            // 
            // txtCAnalog10V
            // 
            this.txtCAnalog10V.Location = new System.Drawing.Point(55, 222);
            this.txtCAnalog10V.MaxLength = 8;
            this.txtCAnalog10V.Name = "txtCAnalog10V";
            this.txtCAnalog10V.Size = new System.Drawing.Size(83, 21);
            this.txtCAnalog10V.TabIndex = 88;
            // 
            // label130
            // 
            this.label130.AutoSize = true;
            this.label130.Location = new System.Drawing.Point(4, 203);
            this.label130.Name = "label130";
            this.label130.Size = new System.Drawing.Size(23, 12);
            this.label130.TabIndex = 86;
            this.label130.Text = "DCI";
            // 
            // label131
            // 
            this.label131.AutoSize = true;
            this.label131.Location = new System.Drawing.Point(141, 203);
            this.label131.Name = "label131";
            this.label131.Size = new System.Drawing.Size(11, 12);
            this.label131.TabIndex = 84;
            this.label131.Text = "A";
            // 
            // txtCAnalogDci
            // 
            this.txtCAnalogDci.Location = new System.Drawing.Point(55, 199);
            this.txtCAnalogDci.MaxLength = 8;
            this.txtCAnalogDci.Name = "txtCAnalogDci";
            this.txtCAnalogDci.Size = new System.Drawing.Size(83, 21);
            this.txtCAnalogDci.TabIndex = 85;
            // 
            // label132
            // 
            this.label132.AutoSize = true;
            this.label132.Location = new System.Drawing.Point(3, 180);
            this.label132.Name = "label132";
            this.label132.Size = new System.Drawing.Size(71, 12);
            this.label132.TabIndex = 83;
            this.label132.Text = "副边ntc温度";
            // 
            // label133
            // 
            this.label133.AutoSize = true;
            this.label133.Location = new System.Drawing.Point(138, 180);
            this.label133.Name = "label133";
            this.label133.Size = new System.Drawing.Size(17, 12);
            this.label133.TabIndex = 81;
            this.label133.Text = "℃";
            // 
            // txtCAnalogSecTemp
            // 
            this.txtCAnalogSecTemp.Location = new System.Drawing.Point(74, 176);
            this.txtCAnalogSecTemp.MaxLength = 8;
            this.txtCAnalogSecTemp.Name = "txtCAnalogSecTemp";
            this.txtCAnalogSecTemp.Size = new System.Drawing.Size(63, 21);
            this.txtCAnalogSecTemp.TabIndex = 82;
            // 
            // label134
            // 
            this.label134.AutoSize = true;
            this.label134.Location = new System.Drawing.Point(3, 157);
            this.label134.Name = "label134";
            this.label134.Size = new System.Drawing.Size(71, 12);
            this.label134.TabIndex = 80;
            this.label134.Text = "原边ntc温度";
            // 
            // label135
            // 
            this.label135.AutoSize = true;
            this.label135.Location = new System.Drawing.Point(138, 157);
            this.label135.Name = "label135";
            this.label135.Size = new System.Drawing.Size(17, 12);
            this.label135.TabIndex = 78;
            this.label135.Text = "℃";
            // 
            // txtCAnalogPriTemp
            // 
            this.txtCAnalogPriTemp.Location = new System.Drawing.Point(74, 153);
            this.txtCAnalogPriTemp.MaxLength = 8;
            this.txtCAnalogPriTemp.Name = "txtCAnalogPriTemp";
            this.txtCAnalogPriTemp.Size = new System.Drawing.Size(63, 21);
            this.txtCAnalogPriTemp.TabIndex = 79;
            // 
            // label136
            // 
            this.label136.AutoSize = true;
            this.label136.Location = new System.Drawing.Point(4, 133);
            this.label136.Name = "label136";
            this.label136.Size = new System.Drawing.Size(53, 12);
            this.label136.TabIndex = 77;
            this.label136.Text = "电池电压";
            // 
            // label137
            // 
            this.label137.AutoSize = true;
            this.label137.Location = new System.Drawing.Point(141, 133);
            this.label137.Name = "label137";
            this.label137.Size = new System.Drawing.Size(11, 12);
            this.label137.TabIndex = 75;
            this.label137.Text = "V";
            // 
            // txtCAnalogVbat
            // 
            this.txtCAnalogVbat.Location = new System.Drawing.Point(55, 129);
            this.txtCAnalogVbat.MaxLength = 8;
            this.txtCAnalogVbat.Name = "txtCAnalogVbat";
            this.txtCAnalogVbat.Size = new System.Drawing.Size(83, 21);
            this.txtCAnalogVbat.TabIndex = 76;
            // 
            // label138
            // 
            this.label138.AutoSize = true;
            this.label138.Location = new System.Drawing.Point(4, 110);
            this.label138.Name = "label138";
            this.label138.Size = new System.Drawing.Size(53, 12);
            this.label138.TabIndex = 74;
            this.label138.Text = "并网电流";
            // 
            // label139
            // 
            this.label139.AutoSize = true;
            this.label139.Location = new System.Drawing.Point(141, 110);
            this.label139.Name = "label139";
            this.label139.Size = new System.Drawing.Size(11, 12);
            this.label139.TabIndex = 72;
            this.label139.Text = "A";
            // 
            // txtCAnalogIgrid
            // 
            this.txtCAnalogIgrid.Location = new System.Drawing.Point(55, 106);
            this.txtCAnalogIgrid.MaxLength = 8;
            this.txtCAnalogIgrid.Name = "txtCAnalogIgrid";
            this.txtCAnalogIgrid.Size = new System.Drawing.Size(83, 21);
            this.txtCAnalogIgrid.TabIndex = 73;
            // 
            // label140
            // 
            this.label140.AutoSize = true;
            this.label140.Location = new System.Drawing.Point(3, 87);
            this.label140.Name = "label140";
            this.label140.Size = new System.Drawing.Size(53, 12);
            this.label140.TabIndex = 71;
            this.label140.Text = "电网电压";
            // 
            // label141
            // 
            this.label141.AutoSize = true;
            this.label141.Location = new System.Drawing.Point(140, 87);
            this.label141.Name = "label141";
            this.label141.Size = new System.Drawing.Size(11, 12);
            this.label141.TabIndex = 69;
            this.label141.Text = "V";
            // 
            // txtCAnalogPowerVgrid
            // 
            this.txtCAnalogPowerVgrid.Location = new System.Drawing.Point(54, 83);
            this.txtCAnalogPowerVgrid.MaxLength = 8;
            this.txtCAnalogPowerVgrid.Name = "txtCAnalogPowerVgrid";
            this.txtCAnalogPowerVgrid.Size = new System.Drawing.Size(83, 21);
            this.txtCAnalogPowerVgrid.TabIndex = 70;
            // 
            // label142
            // 
            this.label142.AutoSize = true;
            this.label142.Location = new System.Drawing.Point(3, 64);
            this.label142.Name = "label142";
            this.label142.Size = new System.Drawing.Size(53, 12);
            this.label142.TabIndex = 68;
            this.label142.Text = "电容电压";
            // 
            // label143
            // 
            this.label143.AutoSize = true;
            this.label143.Location = new System.Drawing.Point(140, 64);
            this.label143.Name = "label143";
            this.label143.Size = new System.Drawing.Size(11, 12);
            this.label143.TabIndex = 57;
            this.label143.Text = "V";
            // 
            // txtCAnalogVgrid
            // 
            this.txtCAnalogVgrid.Location = new System.Drawing.Point(54, 60);
            this.txtCAnalogVgrid.MaxLength = 8;
            this.txtCAnalogVgrid.Name = "txtCAnalogVgrid";
            this.txtCAnalogVgrid.Size = new System.Drawing.Size(83, 21);
            this.txtCAnalogVgrid.TabIndex = 57;
            // 
            // groupBox29
            // 
            this.groupBox29.Controls.Add(this.label332);
            this.groupBox29.Controls.Add(this.txtBAnalogExternalFan2State);
            this.groupBox29.Controls.Add(this.label334);
            this.groupBox29.Controls.Add(this.txtBAnalogExternalFan1State);
            this.groupBox29.Controls.Add(this.label336);
            this.groupBox29.Controls.Add(this.txtBAnalogInternalFanState);
            this.groupBox29.Controls.Add(this.label36);
            this.groupBox29.Controls.Add(this.label170);
            this.groupBox29.Controls.Add(this.label47);
            this.groupBox29.Controls.Add(this.txtBAnalogGridFreq);
            this.groupBox29.Controls.Add(this.label171);
            this.groupBox29.Controls.Add(this.txtBAnalogQout);
            this.groupBox29.Controls.Add(this.label172);
            this.groupBox29.Controls.Add(this.label173);
            this.groupBox29.Controls.Add(this.txtBAnalogPout);
            this.groupBox29.Controls.Add(this.label112);
            this.groupBox29.Controls.Add(this.label113);
            this.groupBox29.Controls.Add(this.txtBAnalog10V);
            this.groupBox29.Controls.Add(this.label114);
            this.groupBox29.Controls.Add(this.label115);
            this.groupBox29.Controls.Add(this.txtBAnalogDci);
            this.groupBox29.Controls.Add(this.label116);
            this.groupBox29.Controls.Add(this.label117);
            this.groupBox29.Controls.Add(this.txtBAnalogSecTemp);
            this.groupBox29.Controls.Add(this.label118);
            this.groupBox29.Controls.Add(this.label119);
            this.groupBox29.Controls.Add(this.txtBAnalogPriTemp);
            this.groupBox29.Controls.Add(this.label120);
            this.groupBox29.Controls.Add(this.label121);
            this.groupBox29.Controls.Add(this.txtBAnalogVbat);
            this.groupBox29.Controls.Add(this.label122);
            this.groupBox29.Controls.Add(this.label123);
            this.groupBox29.Controls.Add(this.txtBAnalogIgrid);
            this.groupBox29.Controls.Add(this.label124);
            this.groupBox29.Controls.Add(this.label125);
            this.groupBox29.Controls.Add(this.txtBAnalogPowerVgrid);
            this.groupBox29.Controls.Add(this.label126);
            this.groupBox29.Controls.Add(this.label127);
            this.groupBox29.Controls.Add(this.txtBAnalogVgrid);
            this.groupBox29.Location = new System.Drawing.Point(173, 17);
            this.groupBox29.Name = "groupBox29";
            this.groupBox29.Size = new System.Drawing.Size(168, 338);
            this.groupBox29.TabIndex = 93;
            this.groupBox29.TabStop = false;
            this.groupBox29.Text = "B相模拟量数据";
            // 
            // label332
            // 
            this.label332.AutoSize = true;
            this.label332.Location = new System.Drawing.Point(2, 317);
            this.label332.Name = "label332";
            this.label332.Size = new System.Drawing.Size(83, 12);
            this.label332.TabIndex = 114;
            this.label332.Text = "外部风扇2状态";
            // 
            // txtBAnalogExternalFan2State
            // 
            this.txtBAnalogExternalFan2State.Location = new System.Drawing.Point(84, 313);
            this.txtBAnalogExternalFan2State.MaxLength = 8;
            this.txtBAnalogExternalFan2State.Name = "txtBAnalogExternalFan2State";
            this.txtBAnalogExternalFan2State.Size = new System.Drawing.Size(55, 21);
            this.txtBAnalogExternalFan2State.TabIndex = 113;
            // 
            // label334
            // 
            this.label334.AutoSize = true;
            this.label334.Location = new System.Drawing.Point(3, 295);
            this.label334.Name = "label334";
            this.label334.Size = new System.Drawing.Size(83, 12);
            this.label334.TabIndex = 112;
            this.label334.Text = "外部风扇1状态";
            // 
            // txtBAnalogExternalFan1State
            // 
            this.txtBAnalogExternalFan1State.Location = new System.Drawing.Point(84, 291);
            this.txtBAnalogExternalFan1State.MaxLength = 8;
            this.txtBAnalogExternalFan1State.Name = "txtBAnalogExternalFan1State";
            this.txtBAnalogExternalFan1State.Size = new System.Drawing.Size(55, 21);
            this.txtBAnalogExternalFan1State.TabIndex = 111;
            // 
            // label336
            // 
            this.label336.AutoSize = true;
            this.label336.Location = new System.Drawing.Point(3, 272);
            this.label336.Name = "label336";
            this.label336.Size = new System.Drawing.Size(77, 12);
            this.label336.TabIndex = 110;
            this.label336.Text = "内部风扇状态";
            // 
            // txtBAnalogInternalFanState
            // 
            this.txtBAnalogInternalFanState.Location = new System.Drawing.Point(84, 268);
            this.txtBAnalogInternalFanState.MaxLength = 8;
            this.txtBAnalogInternalFanState.Name = "txtBAnalogInternalFanState";
            this.txtBAnalogInternalFanState.Size = new System.Drawing.Size(55, 21);
            this.txtBAnalogInternalFanState.TabIndex = 109;
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(142, 249);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(17, 12);
            this.label36.TabIndex = 102;
            this.label36.Text = "Hz";
            // 
            // label170
            // 
            this.label170.AutoSize = true;
            this.label170.Location = new System.Drawing.Point(5, 41);
            this.label170.Name = "label170";
            this.label170.Size = new System.Drawing.Size(53, 12);
            this.label170.TabIndex = 101;
            this.label170.Text = "无功功率";
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.Location = new System.Drawing.Point(5, 249);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(53, 12);
            this.label47.TabIndex = 101;
            this.label47.Text = "电网频率";
            // 
            // txtBAnalogGridFreq
            // 
            this.txtBAnalogGridFreq.Location = new System.Drawing.Point(56, 245);
            this.txtBAnalogGridFreq.MaxLength = 8;
            this.txtBAnalogGridFreq.Name = "txtBAnalogGridFreq";
            this.txtBAnalogGridFreq.Size = new System.Drawing.Size(83, 21);
            this.txtBAnalogGridFreq.TabIndex = 100;
            // 
            // label171
            // 
            this.label171.AutoSize = true;
            this.label171.Location = new System.Drawing.Point(140, 41);
            this.label171.Name = "label171";
            this.label171.Size = new System.Drawing.Size(29, 12);
            this.label171.TabIndex = 99;
            this.label171.Text = "kVar";
            // 
            // txtBAnalogQout
            // 
            this.txtBAnalogQout.Location = new System.Drawing.Point(56, 37);
            this.txtBAnalogQout.MaxLength = 8;
            this.txtBAnalogQout.Name = "txtBAnalogQout";
            this.txtBAnalogQout.Size = new System.Drawing.Size(83, 21);
            this.txtBAnalogQout.TabIndex = 100;
            // 
            // label172
            // 
            this.label172.AutoSize = true;
            this.label172.Location = new System.Drawing.Point(5, 18);
            this.label172.Name = "label172";
            this.label172.Size = new System.Drawing.Size(53, 12);
            this.label172.TabIndex = 98;
            this.label172.Text = "有功功率";
            // 
            // label173
            // 
            this.label173.AutoSize = true;
            this.label173.Location = new System.Drawing.Point(140, 18);
            this.label173.Name = "label173";
            this.label173.Size = new System.Drawing.Size(17, 12);
            this.label173.TabIndex = 96;
            this.label173.Text = "kW";
            // 
            // txtBAnalogPout
            // 
            this.txtBAnalogPout.Location = new System.Drawing.Point(56, 14);
            this.txtBAnalogPout.MaxLength = 8;
            this.txtBAnalogPout.Name = "txtBAnalogPout";
            this.txtBAnalogPout.Size = new System.Drawing.Size(83, 21);
            this.txtBAnalogPout.TabIndex = 97;
            // 
            // label112
            // 
            this.label112.AutoSize = true;
            this.label112.Location = new System.Drawing.Point(5, 226);
            this.label112.Name = "label112";
            this.label112.Size = new System.Drawing.Size(23, 12);
            this.label112.TabIndex = 89;
            this.label112.Text = "10V";
            // 
            // label113
            // 
            this.label113.AutoSize = true;
            this.label113.Location = new System.Drawing.Point(142, 226);
            this.label113.Name = "label113";
            this.label113.Size = new System.Drawing.Size(11, 12);
            this.label113.TabIndex = 87;
            this.label113.Text = "V";
            // 
            // txtBAnalog10V
            // 
            this.txtBAnalog10V.Location = new System.Drawing.Point(56, 222);
            this.txtBAnalog10V.MaxLength = 8;
            this.txtBAnalog10V.Name = "txtBAnalog10V";
            this.txtBAnalog10V.Size = new System.Drawing.Size(84, 21);
            this.txtBAnalog10V.TabIndex = 88;
            // 
            // label114
            // 
            this.label114.AutoSize = true;
            this.label114.Location = new System.Drawing.Point(5, 203);
            this.label114.Name = "label114";
            this.label114.Size = new System.Drawing.Size(23, 12);
            this.label114.TabIndex = 86;
            this.label114.Text = "DCI";
            // 
            // label115
            // 
            this.label115.AutoSize = true;
            this.label115.Location = new System.Drawing.Point(142, 203);
            this.label115.Name = "label115";
            this.label115.Size = new System.Drawing.Size(11, 12);
            this.label115.TabIndex = 84;
            this.label115.Text = "A";
            // 
            // txtBAnalogDci
            // 
            this.txtBAnalogDci.Location = new System.Drawing.Point(56, 199);
            this.txtBAnalogDci.MaxLength = 8;
            this.txtBAnalogDci.Name = "txtBAnalogDci";
            this.txtBAnalogDci.Size = new System.Drawing.Size(84, 21);
            this.txtBAnalogDci.TabIndex = 85;
            // 
            // label116
            // 
            this.label116.AutoSize = true;
            this.label116.Location = new System.Drawing.Point(4, 180);
            this.label116.Name = "label116";
            this.label116.Size = new System.Drawing.Size(71, 12);
            this.label116.TabIndex = 83;
            this.label116.Text = "副边ntc温度";
            // 
            // label117
            // 
            this.label117.AutoSize = true;
            this.label117.Location = new System.Drawing.Point(139, 180);
            this.label117.Name = "label117";
            this.label117.Size = new System.Drawing.Size(17, 12);
            this.label117.TabIndex = 81;
            this.label117.Text = "℃";
            // 
            // txtBAnalogSecTemp
            // 
            this.txtBAnalogSecTemp.Location = new System.Drawing.Point(75, 176);
            this.txtBAnalogSecTemp.MaxLength = 8;
            this.txtBAnalogSecTemp.Name = "txtBAnalogSecTemp";
            this.txtBAnalogSecTemp.Size = new System.Drawing.Size(64, 21);
            this.txtBAnalogSecTemp.TabIndex = 82;
            // 
            // label118
            // 
            this.label118.AutoSize = true;
            this.label118.Location = new System.Drawing.Point(4, 157);
            this.label118.Name = "label118";
            this.label118.Size = new System.Drawing.Size(71, 12);
            this.label118.TabIndex = 80;
            this.label118.Text = "原边ntc温度";
            // 
            // label119
            // 
            this.label119.AutoSize = true;
            this.label119.Location = new System.Drawing.Point(139, 157);
            this.label119.Name = "label119";
            this.label119.Size = new System.Drawing.Size(17, 12);
            this.label119.TabIndex = 78;
            this.label119.Text = "℃";
            // 
            // txtBAnalogPriTemp
            // 
            this.txtBAnalogPriTemp.Location = new System.Drawing.Point(75, 153);
            this.txtBAnalogPriTemp.MaxLength = 8;
            this.txtBAnalogPriTemp.Name = "txtBAnalogPriTemp";
            this.txtBAnalogPriTemp.Size = new System.Drawing.Size(64, 21);
            this.txtBAnalogPriTemp.TabIndex = 79;
            // 
            // label120
            // 
            this.label120.AutoSize = true;
            this.label120.Location = new System.Drawing.Point(5, 133);
            this.label120.Name = "label120";
            this.label120.Size = new System.Drawing.Size(53, 12);
            this.label120.TabIndex = 77;
            this.label120.Text = "电池电压";
            // 
            // label121
            // 
            this.label121.AutoSize = true;
            this.label121.Location = new System.Drawing.Point(142, 133);
            this.label121.Name = "label121";
            this.label121.Size = new System.Drawing.Size(11, 12);
            this.label121.TabIndex = 75;
            this.label121.Text = "V";
            // 
            // txtBAnalogVbat
            // 
            this.txtBAnalogVbat.Location = new System.Drawing.Point(56, 129);
            this.txtBAnalogVbat.MaxLength = 8;
            this.txtBAnalogVbat.Name = "txtBAnalogVbat";
            this.txtBAnalogVbat.Size = new System.Drawing.Size(84, 21);
            this.txtBAnalogVbat.TabIndex = 76;
            // 
            // label122
            // 
            this.label122.AutoSize = true;
            this.label122.Location = new System.Drawing.Point(5, 110);
            this.label122.Name = "label122";
            this.label122.Size = new System.Drawing.Size(53, 12);
            this.label122.TabIndex = 74;
            this.label122.Text = "并网电流";
            // 
            // label123
            // 
            this.label123.AutoSize = true;
            this.label123.Location = new System.Drawing.Point(142, 110);
            this.label123.Name = "label123";
            this.label123.Size = new System.Drawing.Size(11, 12);
            this.label123.TabIndex = 72;
            this.label123.Text = "A";
            // 
            // txtBAnalogIgrid
            // 
            this.txtBAnalogIgrid.Location = new System.Drawing.Point(56, 106);
            this.txtBAnalogIgrid.MaxLength = 8;
            this.txtBAnalogIgrid.Name = "txtBAnalogIgrid";
            this.txtBAnalogIgrid.Size = new System.Drawing.Size(84, 21);
            this.txtBAnalogIgrid.TabIndex = 73;
            // 
            // label124
            // 
            this.label124.AutoSize = true;
            this.label124.Location = new System.Drawing.Point(4, 87);
            this.label124.Name = "label124";
            this.label124.Size = new System.Drawing.Size(53, 12);
            this.label124.TabIndex = 71;
            this.label124.Text = "电网电压";
            // 
            // label125
            // 
            this.label125.AutoSize = true;
            this.label125.Location = new System.Drawing.Point(141, 87);
            this.label125.Name = "label125";
            this.label125.Size = new System.Drawing.Size(11, 12);
            this.label125.TabIndex = 69;
            this.label125.Text = "V";
            // 
            // txtBAnalogPowerVgrid
            // 
            this.txtBAnalogPowerVgrid.Location = new System.Drawing.Point(56, 83);
            this.txtBAnalogPowerVgrid.MaxLength = 8;
            this.txtBAnalogPowerVgrid.Name = "txtBAnalogPowerVgrid";
            this.txtBAnalogPowerVgrid.Size = new System.Drawing.Size(83, 21);
            this.txtBAnalogPowerVgrid.TabIndex = 70;
            // 
            // label126
            // 
            this.label126.AutoSize = true;
            this.label126.Location = new System.Drawing.Point(4, 64);
            this.label126.Name = "label126";
            this.label126.Size = new System.Drawing.Size(53, 12);
            this.label126.TabIndex = 68;
            this.label126.Text = "电容电压";
            // 
            // label127
            // 
            this.label127.AutoSize = true;
            this.label127.Location = new System.Drawing.Point(141, 64);
            this.label127.Name = "label127";
            this.label127.Size = new System.Drawing.Size(11, 12);
            this.label127.TabIndex = 57;
            this.label127.Text = "V";
            // 
            // txtBAnalogVgrid
            // 
            this.txtBAnalogVgrid.Location = new System.Drawing.Point(55, 60);
            this.txtBAnalogVgrid.MaxLength = 8;
            this.txtBAnalogVgrid.Name = "txtBAnalogVgrid";
            this.txtBAnalogVgrid.Size = new System.Drawing.Size(84, 21);
            this.txtBAnalogVgrid.TabIndex = 57;
            // 
            // groupBox28
            // 
            this.groupBox28.Controls.Add(this.label335);
            this.groupBox28.Controls.Add(this.txtAAnalogExternalFan2State);
            this.groupBox28.Controls.Add(this.label331);
            this.groupBox28.Controls.Add(this.txtAAnalogExternalFan1State);
            this.groupBox28.Controls.Add(this.label333);
            this.groupBox28.Controls.Add(this.txtAAnalogInternalFanState);
            this.groupBox28.Controls.Add(this.label31);
            this.groupBox28.Controls.Add(this.label30);
            this.groupBox28.Controls.Add(this.txtAAnalogGridFreq);
            this.groupBox28.Controls.Add(this.label166);
            this.groupBox28.Controls.Add(this.label167);
            this.groupBox28.Controls.Add(this.txtAAnalogQout);
            this.groupBox28.Controls.Add(this.label168);
            this.groupBox28.Controls.Add(this.label169);
            this.groupBox28.Controls.Add(this.txtAAnalogPout);
            this.groupBox28.Controls.Add(this.label96);
            this.groupBox28.Controls.Add(this.label97);
            this.groupBox28.Controls.Add(this.txtAAnalog10V);
            this.groupBox28.Controls.Add(this.label98);
            this.groupBox28.Controls.Add(this.label99);
            this.groupBox28.Controls.Add(this.txtAAnalogDci);
            this.groupBox28.Controls.Add(this.label100);
            this.groupBox28.Controls.Add(this.label101);
            this.groupBox28.Controls.Add(this.txtAAnalogSecTemp);
            this.groupBox28.Controls.Add(this.label102);
            this.groupBox28.Controls.Add(this.label103);
            this.groupBox28.Controls.Add(this.txtAAnalogPriTemp);
            this.groupBox28.Controls.Add(this.label104);
            this.groupBox28.Controls.Add(this.label105);
            this.groupBox28.Controls.Add(this.txtAAnalogVbat);
            this.groupBox28.Controls.Add(this.label106);
            this.groupBox28.Controls.Add(this.label107);
            this.groupBox28.Controls.Add(this.txtAAnalogIgrid);
            this.groupBox28.Controls.Add(this.label108);
            this.groupBox28.Controls.Add(this.label109);
            this.groupBox28.Controls.Add(this.txtAAnalogPowerVgrid);
            this.groupBox28.Controls.Add(this.label110);
            this.groupBox28.Controls.Add(this.label111);
            this.groupBox28.Controls.Add(this.txtAAnalogVgrid);
            this.groupBox28.Location = new System.Drawing.Point(3, 17);
            this.groupBox28.Name = "groupBox28";
            this.groupBox28.Size = new System.Drawing.Size(168, 338);
            this.groupBox28.TabIndex = 92;
            this.groupBox28.TabStop = false;
            this.groupBox28.Text = "A相模拟量数据";
            // 
            // label335
            // 
            this.label335.AutoSize = true;
            this.label335.Location = new System.Drawing.Point(2, 317);
            this.label335.Name = "label335";
            this.label335.Size = new System.Drawing.Size(83, 12);
            this.label335.TabIndex = 108;
            this.label335.Text = "外部风扇2状态";
            // 
            // txtAAnalogExternalFan2State
            // 
            this.txtAAnalogExternalFan2State.Location = new System.Drawing.Point(84, 313);
            this.txtAAnalogExternalFan2State.MaxLength = 8;
            this.txtAAnalogExternalFan2State.Name = "txtAAnalogExternalFan2State";
            this.txtAAnalogExternalFan2State.Size = new System.Drawing.Size(55, 21);
            this.txtAAnalogExternalFan2State.TabIndex = 107;
            // 
            // label331
            // 
            this.label331.AutoSize = true;
            this.label331.Location = new System.Drawing.Point(3, 295);
            this.label331.Name = "label331";
            this.label331.Size = new System.Drawing.Size(83, 12);
            this.label331.TabIndex = 105;
            this.label331.Text = "外部风扇1状态";
            // 
            // txtAAnalogExternalFan1State
            // 
            this.txtAAnalogExternalFan1State.Location = new System.Drawing.Point(84, 291);
            this.txtAAnalogExternalFan1State.MaxLength = 8;
            this.txtAAnalogExternalFan1State.Name = "txtAAnalogExternalFan1State";
            this.txtAAnalogExternalFan1State.Size = new System.Drawing.Size(55, 21);
            this.txtAAnalogExternalFan1State.TabIndex = 104;
            // 
            // label333
            // 
            this.label333.AutoSize = true;
            this.label333.Location = new System.Drawing.Point(3, 272);
            this.label333.Name = "label333";
            this.label333.Size = new System.Drawing.Size(77, 12);
            this.label333.TabIndex = 102;
            this.label333.Text = "内部风扇状态";
            // 
            // txtAAnalogInternalFanState
            // 
            this.txtAAnalogInternalFanState.Location = new System.Drawing.Point(84, 268);
            this.txtAAnalogInternalFanState.MaxLength = 8;
            this.txtAAnalogInternalFanState.Name = "txtAAnalogInternalFanState";
            this.txtAAnalogInternalFanState.Size = new System.Drawing.Size(55, 21);
            this.txtAAnalogInternalFanState.TabIndex = 101;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(142, 249);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(17, 12);
            this.label31.TabIndex = 99;
            this.label31.Text = "Hz";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(5, 249);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(53, 12);
            this.label30.TabIndex = 98;
            this.label30.Text = "电网频率";
            // 
            // txtAAnalogGridFreq
            // 
            this.txtAAnalogGridFreq.Location = new System.Drawing.Point(56, 245);
            this.txtAAnalogGridFreq.MaxLength = 8;
            this.txtAAnalogGridFreq.Name = "txtAAnalogGridFreq";
            this.txtAAnalogGridFreq.Size = new System.Drawing.Size(83, 21);
            this.txtAAnalogGridFreq.TabIndex = 97;
            // 
            // label166
            // 
            this.label166.AutoSize = true;
            this.label166.Location = new System.Drawing.Point(4, 41);
            this.label166.Name = "label166";
            this.label166.Size = new System.Drawing.Size(53, 12);
            this.label166.TabIndex = 95;
            this.label166.Text = "无功功率";
            // 
            // label167
            // 
            this.label167.AutoSize = true;
            this.label167.Location = new System.Drawing.Point(139, 41);
            this.label167.Name = "label167";
            this.label167.Size = new System.Drawing.Size(29, 12);
            this.label167.TabIndex = 93;
            this.label167.Text = "kVar";
            // 
            // txtAAnalogQout
            // 
            this.txtAAnalogQout.Location = new System.Drawing.Point(55, 37);
            this.txtAAnalogQout.MaxLength = 8;
            this.txtAAnalogQout.Name = "txtAAnalogQout";
            this.txtAAnalogQout.Size = new System.Drawing.Size(83, 21);
            this.txtAAnalogQout.TabIndex = 94;
            // 
            // label168
            // 
            this.label168.AutoSize = true;
            this.label168.Location = new System.Drawing.Point(4, 18);
            this.label168.Name = "label168";
            this.label168.Size = new System.Drawing.Size(53, 12);
            this.label168.TabIndex = 92;
            this.label168.Text = "有功功率";
            // 
            // label169
            // 
            this.label169.AutoSize = true;
            this.label169.Location = new System.Drawing.Point(140, 18);
            this.label169.Name = "label169";
            this.label169.Size = new System.Drawing.Size(17, 12);
            this.label169.TabIndex = 90;
            this.label169.Text = "kW";
            // 
            // txtAAnalogPout
            // 
            this.txtAAnalogPout.Location = new System.Drawing.Point(55, 14);
            this.txtAAnalogPout.MaxLength = 8;
            this.txtAAnalogPout.Name = "txtAAnalogPout";
            this.txtAAnalogPout.Size = new System.Drawing.Size(83, 21);
            this.txtAAnalogPout.TabIndex = 91;
            // 
            // label96
            // 
            this.label96.AutoSize = true;
            this.label96.Location = new System.Drawing.Point(5, 226);
            this.label96.Name = "label96";
            this.label96.Size = new System.Drawing.Size(23, 12);
            this.label96.TabIndex = 89;
            this.label96.Text = "10V";
            // 
            // label97
            // 
            this.label97.AutoSize = true;
            this.label97.Location = new System.Drawing.Point(142, 226);
            this.label97.Name = "label97";
            this.label97.Size = new System.Drawing.Size(11, 12);
            this.label97.TabIndex = 87;
            this.label97.Text = "V";
            // 
            // txtAAnalog10V
            // 
            this.txtAAnalog10V.Location = new System.Drawing.Point(56, 222);
            this.txtAAnalog10V.MaxLength = 8;
            this.txtAAnalog10V.Name = "txtAAnalog10V";
            this.txtAAnalog10V.Size = new System.Drawing.Size(83, 21);
            this.txtAAnalog10V.TabIndex = 88;
            // 
            // label98
            // 
            this.label98.AutoSize = true;
            this.label98.Location = new System.Drawing.Point(5, 203);
            this.label98.Name = "label98";
            this.label98.Size = new System.Drawing.Size(23, 12);
            this.label98.TabIndex = 86;
            this.label98.Text = "DCI";
            // 
            // label99
            // 
            this.label99.AutoSize = true;
            this.label99.Location = new System.Drawing.Point(142, 203);
            this.label99.Name = "label99";
            this.label99.Size = new System.Drawing.Size(11, 12);
            this.label99.TabIndex = 84;
            this.label99.Text = "A";
            // 
            // txtAAnalogDci
            // 
            this.txtAAnalogDci.Location = new System.Drawing.Point(56, 199);
            this.txtAAnalogDci.MaxLength = 8;
            this.txtAAnalogDci.Name = "txtAAnalogDci";
            this.txtAAnalogDci.Size = new System.Drawing.Size(83, 21);
            this.txtAAnalogDci.TabIndex = 85;
            // 
            // label100
            // 
            this.label100.AutoSize = true;
            this.label100.Location = new System.Drawing.Point(4, 180);
            this.label100.Name = "label100";
            this.label100.Size = new System.Drawing.Size(71, 12);
            this.label100.TabIndex = 83;
            this.label100.Text = "副边ntc温度";
            // 
            // label101
            // 
            this.label101.AutoSize = true;
            this.label101.Location = new System.Drawing.Point(139, 180);
            this.label101.Name = "label101";
            this.label101.Size = new System.Drawing.Size(17, 12);
            this.label101.TabIndex = 81;
            this.label101.Text = "℃";
            // 
            // txtAAnalogSecTemp
            // 
            this.txtAAnalogSecTemp.Location = new System.Drawing.Point(75, 176);
            this.txtAAnalogSecTemp.MaxLength = 8;
            this.txtAAnalogSecTemp.Name = "txtAAnalogSecTemp";
            this.txtAAnalogSecTemp.Size = new System.Drawing.Size(63, 21);
            this.txtAAnalogSecTemp.TabIndex = 82;
            // 
            // label102
            // 
            this.label102.AutoSize = true;
            this.label102.Location = new System.Drawing.Point(4, 157);
            this.label102.Name = "label102";
            this.label102.Size = new System.Drawing.Size(71, 12);
            this.label102.TabIndex = 80;
            this.label102.Text = "原边ntc温度";
            // 
            // label103
            // 
            this.label103.AutoSize = true;
            this.label103.Location = new System.Drawing.Point(139, 157);
            this.label103.Name = "label103";
            this.label103.Size = new System.Drawing.Size(17, 12);
            this.label103.TabIndex = 78;
            this.label103.Text = "℃";
            // 
            // txtAAnalogPriTemp
            // 
            this.txtAAnalogPriTemp.Location = new System.Drawing.Point(75, 153);
            this.txtAAnalogPriTemp.MaxLength = 8;
            this.txtAAnalogPriTemp.Name = "txtAAnalogPriTemp";
            this.txtAAnalogPriTemp.Size = new System.Drawing.Size(63, 21);
            this.txtAAnalogPriTemp.TabIndex = 79;
            // 
            // label104
            // 
            this.label104.AutoSize = true;
            this.label104.Location = new System.Drawing.Point(5, 133);
            this.label104.Name = "label104";
            this.label104.Size = new System.Drawing.Size(53, 12);
            this.label104.TabIndex = 77;
            this.label104.Text = "电池电压";
            // 
            // label105
            // 
            this.label105.AutoSize = true;
            this.label105.Location = new System.Drawing.Point(142, 133);
            this.label105.Name = "label105";
            this.label105.Size = new System.Drawing.Size(11, 12);
            this.label105.TabIndex = 75;
            this.label105.Text = "V";
            // 
            // txtAAnalogVbat
            // 
            this.txtAAnalogVbat.Location = new System.Drawing.Point(56, 129);
            this.txtAAnalogVbat.MaxLength = 8;
            this.txtAAnalogVbat.Name = "txtAAnalogVbat";
            this.txtAAnalogVbat.Size = new System.Drawing.Size(83, 21);
            this.txtAAnalogVbat.TabIndex = 76;
            // 
            // label106
            // 
            this.label106.AutoSize = true;
            this.label106.Location = new System.Drawing.Point(5, 110);
            this.label106.Name = "label106";
            this.label106.Size = new System.Drawing.Size(53, 12);
            this.label106.TabIndex = 74;
            this.label106.Text = "并网电流";
            // 
            // label107
            // 
            this.label107.AutoSize = true;
            this.label107.Location = new System.Drawing.Point(142, 110);
            this.label107.Name = "label107";
            this.label107.Size = new System.Drawing.Size(11, 12);
            this.label107.TabIndex = 72;
            this.label107.Text = "A";
            // 
            // txtAAnalogIgrid
            // 
            this.txtAAnalogIgrid.Location = new System.Drawing.Point(56, 106);
            this.txtAAnalogIgrid.MaxLength = 8;
            this.txtAAnalogIgrid.Name = "txtAAnalogIgrid";
            this.txtAAnalogIgrid.Size = new System.Drawing.Size(83, 21);
            this.txtAAnalogIgrid.TabIndex = 73;
            // 
            // label108
            // 
            this.label108.AutoSize = true;
            this.label108.Location = new System.Drawing.Point(4, 87);
            this.label108.Name = "label108";
            this.label108.Size = new System.Drawing.Size(53, 12);
            this.label108.TabIndex = 71;
            this.label108.Text = "电网电压";
            // 
            // label109
            // 
            this.label109.AutoSize = true;
            this.label109.Location = new System.Drawing.Point(141, 87);
            this.label109.Name = "label109";
            this.label109.Size = new System.Drawing.Size(11, 12);
            this.label109.TabIndex = 69;
            this.label109.Text = "V";
            // 
            // txtAAnalogPowerVgrid
            // 
            this.txtAAnalogPowerVgrid.Location = new System.Drawing.Point(55, 83);
            this.txtAAnalogPowerVgrid.MaxLength = 8;
            this.txtAAnalogPowerVgrid.Name = "txtAAnalogPowerVgrid";
            this.txtAAnalogPowerVgrid.Size = new System.Drawing.Size(83, 21);
            this.txtAAnalogPowerVgrid.TabIndex = 70;
            // 
            // label110
            // 
            this.label110.AutoSize = true;
            this.label110.Location = new System.Drawing.Point(4, 64);
            this.label110.Name = "label110";
            this.label110.Size = new System.Drawing.Size(53, 12);
            this.label110.TabIndex = 68;
            this.label110.Text = "电容电压";
            // 
            // label111
            // 
            this.label111.AutoSize = true;
            this.label111.Location = new System.Drawing.Point(141, 64);
            this.label111.Name = "label111";
            this.label111.Size = new System.Drawing.Size(11, 12);
            this.label111.TabIndex = 57;
            this.label111.Text = "V";
            // 
            // txtAAnalogVgrid
            // 
            this.txtAAnalogVgrid.Location = new System.Drawing.Point(55, 60);
            this.txtAAnalogVgrid.MaxLength = 8;
            this.txtAAnalogVgrid.Name = "txtAAnalogVgrid";
            this.txtAAnalogVgrid.Size = new System.Drawing.Size(83, 21);
            this.txtAAnalogVgrid.TabIndex = 57;
            // 
            // groupBox30
            // 
            this.groupBox30.Controls.Add(this.chkboxAnalogDataBms);
            this.groupBox30.Controls.Add(this.chkboxAnalogDataPcs);
            this.groupBox30.Location = new System.Drawing.Point(11, 668);
            this.groupBox30.Name = "groupBox30";
            this.groupBox30.Size = new System.Drawing.Size(100, 68);
            this.groupBox30.TabIndex = 102;
            this.groupBox30.TabStop = false;
            this.groupBox30.Text = "读数据选择";
            // 
            // chkboxAnalogDataBms
            // 
            this.chkboxAnalogDataBms.AutoSize = true;
            this.chkboxAnalogDataBms.Location = new System.Drawing.Point(9, 43);
            this.chkboxAnalogDataBms.Name = "chkboxAnalogDataBms";
            this.chkboxAnalogDataBms.Size = new System.Drawing.Size(66, 16);
            this.chkboxAnalogDataBms.TabIndex = 63;
            this.chkboxAnalogDataBms.Text = "BMS数据";
            this.chkboxAnalogDataBms.UseVisualStyleBackColor = true;
            // 
            // chkboxAnalogDataPcs
            // 
            this.chkboxAnalogDataPcs.AutoSize = true;
            this.chkboxAnalogDataPcs.Location = new System.Drawing.Point(9, 21);
            this.chkboxAnalogDataPcs.Name = "chkboxAnalogDataPcs";
            this.chkboxAnalogDataPcs.Size = new System.Drawing.Size(66, 16);
            this.chkboxAnalogDataPcs.TabIndex = 62;
            this.chkboxAnalogDataPcs.Text = "PCS数据";
            this.chkboxAnalogDataPcs.UseVisualStyleBackColor = true;
            // 
            // tabPage8
            // 
            this.tabPage8.Controls.Add(this.groupBox39);
            this.tabPage8.Controls.Add(this.groupBox36);
            this.tabPage8.Controls.Add(this.groupBox24);
            this.tabPage8.Location = new System.Drawing.Point(4, 22);
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage8.Size = new System.Drawing.Size(716, 739);
            this.tabPage8.TabIndex = 5;
            this.tabPage8.Text = "BMS在线调试";
            this.tabPage8.UseVisualStyleBackColor = true;
            // 
            // groupBox39
            // 
            this.groupBox39.Controls.Add(this.btnBmsResetCalibratorParaCmd);
            this.groupBox39.Controls.Add(this.label279);
            this.groupBox39.Controls.Add(this.label262);
            this.groupBox39.Controls.Add(this.label261);
            this.groupBox39.Controls.Add(this.label260);
            this.groupBox39.Controls.Add(this.label259);
            this.groupBox39.Controls.Add(this.label258);
            this.groupBox39.Controls.Add(this.label257);
            this.groupBox39.Controls.Add(this.label256);
            this.groupBox39.Controls.Add(this.label235);
            this.groupBox39.Controls.Add(this.label250);
            this.groupBox39.Controls.Add(this.txtBmsDischgCurr4_Z4);
            this.groupBox39.Controls.Add(this.label251);
            this.groupBox39.Controls.Add(this.txtBmsDischgCurr3_Z3);
            this.groupBox39.Controls.Add(this.label252);
            this.groupBox39.Controls.Add(this.txtBmsDischgCurr2_Z2);
            this.groupBox39.Controls.Add(this.label253);
            this.groupBox39.Controls.Add(this.txtBmsDischgCurr1_Z1);
            this.groupBox39.Controls.Add(this.label254);
            this.groupBox39.Controls.Add(this.txtBmsChgCurr4_Z4);
            this.groupBox39.Controls.Add(this.label255);
            this.groupBox39.Controls.Add(this.txtBmsChgCurr3_Z3);
            this.groupBox39.Controls.Add(this.btnBmsReadCalibratorParaCmd);
            this.groupBox39.Controls.Add(this.label229);
            this.groupBox39.Controls.Add(this.txtBmsCalibratorParaDischgB1);
            this.groupBox39.Controls.Add(this.label231);
            this.groupBox39.Controls.Add(this.txtBmsCalibratorParaDischgK1);
            this.groupBox39.Controls.Add(this.label233);
            this.groupBox39.Controls.Add(this.txtBmsChgCurr2_Z2);
            this.groupBox39.Controls.Add(this.txtBmsChgCurr1_Z1);
            this.groupBox39.Controls.Add(this.label237);
            this.groupBox39.Controls.Add(this.txtBmsCalibratorParaDischgB3);
            this.groupBox39.Controls.Add(this.label239);
            this.groupBox39.Controls.Add(this.txtBmsCalibratorParaDischgK3);
            this.groupBox39.Controls.Add(this.label240);
            this.groupBox39.Controls.Add(this.txtBmsCalibratorParaDischgB2);
            this.groupBox39.Controls.Add(this.label241);
            this.groupBox39.Controls.Add(this.txtBmsCalibratorParaDischgK2);
            this.groupBox39.Controls.Add(this.label242);
            this.groupBox39.Controls.Add(this.txtBmsCalibratorParaChgB0);
            this.groupBox39.Controls.Add(this.label243);
            this.groupBox39.Controls.Add(this.txtBmsCalibratorParaChgK0);
            this.groupBox39.Controls.Add(this.label244);
            this.groupBox39.Controls.Add(this.txtBmsCalibratorParaChgB3);
            this.groupBox39.Controls.Add(this.label245);
            this.groupBox39.Controls.Add(this.txtBmsCalibratorParaChgK3);
            this.groupBox39.Controls.Add(this.label246);
            this.groupBox39.Controls.Add(this.txtBmsCalibratorParaChgB2);
            this.groupBox39.Controls.Add(this.label247);
            this.groupBox39.Controls.Add(this.txtBmsCalibratorParaChgK2);
            this.groupBox39.Controls.Add(this.label248);
            this.groupBox39.Controls.Add(this.txtBmsCalibratorParaChgB1);
            this.groupBox39.Controls.Add(this.label249);
            this.groupBox39.Controls.Add(this.txtBmsCalibratorParaChgK1);
            this.groupBox39.Location = new System.Drawing.Point(18, 74);
            this.groupBox39.Name = "groupBox39";
            this.groupBox39.Size = new System.Drawing.Size(292, 526);
            this.groupBox39.TabIndex = 96;
            this.groupBox39.TabStop = false;
            this.groupBox39.Text = "校准参数查询";
            // 
            // btnBmsResetCalibratorParaCmd
            // 
            this.btnBmsResetCalibratorParaCmd.Location = new System.Drawing.Point(217, 59);
            this.btnBmsResetCalibratorParaCmd.Name = "btnBmsResetCalibratorParaCmd";
            this.btnBmsResetCalibratorParaCmd.Size = new System.Drawing.Size(62, 137);
            this.btnBmsResetCalibratorParaCmd.TabIndex = 133;
            this.btnBmsResetCalibratorParaCmd.Text = "重 置";
            this.btnBmsResetCalibratorParaCmd.UseVisualStyleBackColor = true;
            // 
            // label279
            // 
            this.label279.AutoSize = true;
            this.label279.Location = new System.Drawing.Point(4, 343);
            this.label279.Name = "label279";
            this.label279.Size = new System.Drawing.Size(101, 12);
            this.label279.TabIndex = 108;
            this.label279.Text = "充电采样电流1-Z1";
            // 
            // label262
            // 
            this.label262.AutoSize = true;
            this.label262.Location = new System.Drawing.Point(197, 344);
            this.label262.Name = "label262";
            this.label262.Size = new System.Drawing.Size(11, 12);
            this.label262.TabIndex = 132;
            this.label262.Text = "A";
            // 
            // label261
            // 
            this.label261.AutoSize = true;
            this.label261.Location = new System.Drawing.Point(197, 505);
            this.label261.Name = "label261";
            this.label261.Size = new System.Drawing.Size(11, 12);
            this.label261.TabIndex = 131;
            this.label261.Text = "A";
            // 
            // label260
            // 
            this.label260.AutoSize = true;
            this.label260.Location = new System.Drawing.Point(197, 482);
            this.label260.Name = "label260";
            this.label260.Size = new System.Drawing.Size(11, 12);
            this.label260.TabIndex = 130;
            this.label260.Text = "A";
            // 
            // label259
            // 
            this.label259.AutoSize = true;
            this.label259.Location = new System.Drawing.Point(197, 458);
            this.label259.Name = "label259";
            this.label259.Size = new System.Drawing.Size(11, 12);
            this.label259.TabIndex = 129;
            this.label259.Text = "A";
            // 
            // label258
            // 
            this.label258.AutoSize = true;
            this.label258.Location = new System.Drawing.Point(197, 435);
            this.label258.Name = "label258";
            this.label258.Size = new System.Drawing.Size(11, 12);
            this.label258.TabIndex = 128;
            this.label258.Text = "A";
            // 
            // label257
            // 
            this.label257.AutoSize = true;
            this.label257.Location = new System.Drawing.Point(197, 412);
            this.label257.Name = "label257";
            this.label257.Size = new System.Drawing.Size(11, 12);
            this.label257.TabIndex = 127;
            this.label257.Text = "A";
            // 
            // label256
            // 
            this.label256.AutoSize = true;
            this.label256.Location = new System.Drawing.Point(197, 388);
            this.label256.Name = "label256";
            this.label256.Size = new System.Drawing.Size(11, 12);
            this.label256.TabIndex = 126;
            this.label256.Text = "A";
            // 
            // label235
            // 
            this.label235.AutoSize = true;
            this.label235.Location = new System.Drawing.Point(197, 365);
            this.label235.Name = "label235";
            this.label235.Size = new System.Drawing.Size(11, 12);
            this.label235.TabIndex = 125;
            this.label235.Text = "A";
            // 
            // label250
            // 
            this.label250.AutoSize = true;
            this.label250.Location = new System.Drawing.Point(4, 505);
            this.label250.Name = "label250";
            this.label250.Size = new System.Drawing.Size(101, 12);
            this.label250.TabIndex = 124;
            this.label250.Text = "放电采样电流4-Z4";
            // 
            // txtBmsDischgCurr4_Z4
            // 
            this.txtBmsDischgCurr4_Z4.Location = new System.Drawing.Point(109, 500);
            this.txtBmsDischgCurr4_Z4.MaxLength = 8;
            this.txtBmsDischgCurr4_Z4.Name = "txtBmsDischgCurr4_Z4";
            this.txtBmsDischgCurr4_Z4.Size = new System.Drawing.Size(82, 21);
            this.txtBmsDischgCurr4_Z4.TabIndex = 123;
            // 
            // label251
            // 
            this.label251.AutoSize = true;
            this.label251.Location = new System.Drawing.Point(4, 482);
            this.label251.Name = "label251";
            this.label251.Size = new System.Drawing.Size(101, 12);
            this.label251.TabIndex = 122;
            this.label251.Text = "放电采样电流3-Z3";
            // 
            // txtBmsDischgCurr3_Z3
            // 
            this.txtBmsDischgCurr3_Z3.Location = new System.Drawing.Point(109, 477);
            this.txtBmsDischgCurr3_Z3.MaxLength = 8;
            this.txtBmsDischgCurr3_Z3.Name = "txtBmsDischgCurr3_Z3";
            this.txtBmsDischgCurr3_Z3.Size = new System.Drawing.Size(82, 21);
            this.txtBmsDischgCurr3_Z3.TabIndex = 121;
            // 
            // label252
            // 
            this.label252.AutoSize = true;
            this.label252.Location = new System.Drawing.Point(4, 458);
            this.label252.Name = "label252";
            this.label252.Size = new System.Drawing.Size(101, 12);
            this.label252.TabIndex = 120;
            this.label252.Text = "放电采样电流2-Z2";
            // 
            // txtBmsDischgCurr2_Z2
            // 
            this.txtBmsDischgCurr2_Z2.Location = new System.Drawing.Point(109, 453);
            this.txtBmsDischgCurr2_Z2.MaxLength = 8;
            this.txtBmsDischgCurr2_Z2.Name = "txtBmsDischgCurr2_Z2";
            this.txtBmsDischgCurr2_Z2.Size = new System.Drawing.Size(82, 21);
            this.txtBmsDischgCurr2_Z2.TabIndex = 119;
            // 
            // label253
            // 
            this.label253.AutoSize = true;
            this.label253.Location = new System.Drawing.Point(4, 435);
            this.label253.Name = "label253";
            this.label253.Size = new System.Drawing.Size(101, 12);
            this.label253.TabIndex = 118;
            this.label253.Text = "放电采样电流1-Z1";
            // 
            // txtBmsDischgCurr1_Z1
            // 
            this.txtBmsDischgCurr1_Z1.Location = new System.Drawing.Point(109, 430);
            this.txtBmsDischgCurr1_Z1.MaxLength = 8;
            this.txtBmsDischgCurr1_Z1.Name = "txtBmsDischgCurr1_Z1";
            this.txtBmsDischgCurr1_Z1.Size = new System.Drawing.Size(82, 21);
            this.txtBmsDischgCurr1_Z1.TabIndex = 117;
            // 
            // label254
            // 
            this.label254.AutoSize = true;
            this.label254.Location = new System.Drawing.Point(4, 412);
            this.label254.Name = "label254";
            this.label254.Size = new System.Drawing.Size(101, 12);
            this.label254.TabIndex = 116;
            this.label254.Text = "充电采样电流4-Z4";
            // 
            // txtBmsChgCurr4_Z4
            // 
            this.txtBmsChgCurr4_Z4.Location = new System.Drawing.Point(109, 407);
            this.txtBmsChgCurr4_Z4.MaxLength = 8;
            this.txtBmsChgCurr4_Z4.Name = "txtBmsChgCurr4_Z4";
            this.txtBmsChgCurr4_Z4.Size = new System.Drawing.Size(82, 21);
            this.txtBmsChgCurr4_Z4.TabIndex = 115;
            // 
            // label255
            // 
            this.label255.AutoSize = true;
            this.label255.Location = new System.Drawing.Point(4, 389);
            this.label255.Name = "label255";
            this.label255.Size = new System.Drawing.Size(101, 12);
            this.label255.TabIndex = 114;
            this.label255.Text = "充电采样电流3-Z3";
            // 
            // txtBmsChgCurr3_Z3
            // 
            this.txtBmsChgCurr3_Z3.Location = new System.Drawing.Point(109, 384);
            this.txtBmsChgCurr3_Z3.MaxLength = 8;
            this.txtBmsChgCurr3_Z3.Name = "txtBmsChgCurr3_Z3";
            this.txtBmsChgCurr3_Z3.Size = new System.Drawing.Size(82, 21);
            this.txtBmsChgCurr3_Z3.TabIndex = 113;
            // 
            // btnBmsReadCalibratorParaCmd
            // 
            this.btnBmsReadCalibratorParaCmd.Location = new System.Drawing.Point(217, 220);
            this.btnBmsReadCalibratorParaCmd.Name = "btnBmsReadCalibratorParaCmd";
            this.btnBmsReadCalibratorParaCmd.Size = new System.Drawing.Size(62, 137);
            this.btnBmsReadCalibratorParaCmd.TabIndex = 112;
            this.btnBmsReadCalibratorParaCmd.Text = "查 询";
            this.btnBmsReadCalibratorParaCmd.UseVisualStyleBackColor = true;
            // 
            // label229
            // 
            this.label229.AutoSize = true;
            this.label229.Location = new System.Drawing.Point(4, 227);
            this.label229.Name = "label229";
            this.label229.Size = new System.Drawing.Size(101, 12);
            this.label229.TabIndex = 111;
            this.label229.Text = "校准参数5-放电B1";
            // 
            // txtBmsCalibratorParaDischgB1
            // 
            this.txtBmsCalibratorParaDischgB1.Location = new System.Drawing.Point(109, 222);
            this.txtBmsCalibratorParaDischgB1.MaxLength = 8;
            this.txtBmsCalibratorParaDischgB1.Name = "txtBmsCalibratorParaDischgB1";
            this.txtBmsCalibratorParaDischgB1.Size = new System.Drawing.Size(82, 21);
            this.txtBmsCalibratorParaDischgB1.TabIndex = 110;
            // 
            // label231
            // 
            this.label231.AutoSize = true;
            this.label231.Location = new System.Drawing.Point(4, 204);
            this.label231.Name = "label231";
            this.label231.Size = new System.Drawing.Size(101, 12);
            this.label231.TabIndex = 109;
            this.label231.Text = "校准参数5-放电K1";
            // 
            // txtBmsCalibratorParaDischgK1
            // 
            this.txtBmsCalibratorParaDischgK1.Location = new System.Drawing.Point(109, 199);
            this.txtBmsCalibratorParaDischgK1.MaxLength = 8;
            this.txtBmsCalibratorParaDischgK1.Name = "txtBmsCalibratorParaDischgK1";
            this.txtBmsCalibratorParaDischgK1.Size = new System.Drawing.Size(82, 21);
            this.txtBmsCalibratorParaDischgK1.TabIndex = 108;
            // 
            // label233
            // 
            this.label233.AutoSize = true;
            this.label233.Location = new System.Drawing.Point(4, 366);
            this.label233.Name = "label233";
            this.label233.Size = new System.Drawing.Size(101, 12);
            this.label233.TabIndex = 107;
            this.label233.Text = "充电采样电流2-Z2";
            // 
            // txtBmsChgCurr2_Z2
            // 
            this.txtBmsChgCurr2_Z2.Location = new System.Drawing.Point(109, 361);
            this.txtBmsChgCurr2_Z2.MaxLength = 8;
            this.txtBmsChgCurr2_Z2.Name = "txtBmsChgCurr2_Z2";
            this.txtBmsChgCurr2_Z2.Size = new System.Drawing.Size(82, 21);
            this.txtBmsChgCurr2_Z2.TabIndex = 106;
            // 
            // txtBmsChgCurr1_Z1
            // 
            this.txtBmsChgCurr1_Z1.Location = new System.Drawing.Point(109, 338);
            this.txtBmsChgCurr1_Z1.MaxLength = 8;
            this.txtBmsChgCurr1_Z1.Name = "txtBmsChgCurr1_Z1";
            this.txtBmsChgCurr1_Z1.Size = new System.Drawing.Size(82, 21);
            this.txtBmsChgCurr1_Z1.TabIndex = 104;
            // 
            // label237
            // 
            this.label237.AutoSize = true;
            this.label237.Location = new System.Drawing.Point(4, 319);
            this.label237.Name = "label237";
            this.label237.Size = new System.Drawing.Size(101, 12);
            this.label237.TabIndex = 103;
            this.label237.Text = "校准参数7-放电B3";
            // 
            // txtBmsCalibratorParaDischgB3
            // 
            this.txtBmsCalibratorParaDischgB3.Location = new System.Drawing.Point(109, 314);
            this.txtBmsCalibratorParaDischgB3.MaxLength = 8;
            this.txtBmsCalibratorParaDischgB3.Name = "txtBmsCalibratorParaDischgB3";
            this.txtBmsCalibratorParaDischgB3.Size = new System.Drawing.Size(82, 21);
            this.txtBmsCalibratorParaDischgB3.TabIndex = 102;
            // 
            // label239
            // 
            this.label239.AutoSize = true;
            this.label239.Location = new System.Drawing.Point(4, 296);
            this.label239.Name = "label239";
            this.label239.Size = new System.Drawing.Size(101, 12);
            this.label239.TabIndex = 101;
            this.label239.Text = "校准参数7-放电K3";
            // 
            // txtBmsCalibratorParaDischgK3
            // 
            this.txtBmsCalibratorParaDischgK3.Location = new System.Drawing.Point(109, 291);
            this.txtBmsCalibratorParaDischgK3.MaxLength = 8;
            this.txtBmsCalibratorParaDischgK3.Name = "txtBmsCalibratorParaDischgK3";
            this.txtBmsCalibratorParaDischgK3.Size = new System.Drawing.Size(82, 21);
            this.txtBmsCalibratorParaDischgK3.TabIndex = 100;
            // 
            // label240
            // 
            this.label240.AutoSize = true;
            this.label240.Location = new System.Drawing.Point(4, 273);
            this.label240.Name = "label240";
            this.label240.Size = new System.Drawing.Size(101, 12);
            this.label240.TabIndex = 99;
            this.label240.Text = "校准参数6-放电B2";
            // 
            // txtBmsCalibratorParaDischgB2
            // 
            this.txtBmsCalibratorParaDischgB2.Location = new System.Drawing.Point(109, 268);
            this.txtBmsCalibratorParaDischgB2.MaxLength = 8;
            this.txtBmsCalibratorParaDischgB2.Name = "txtBmsCalibratorParaDischgB2";
            this.txtBmsCalibratorParaDischgB2.Size = new System.Drawing.Size(82, 21);
            this.txtBmsCalibratorParaDischgB2.TabIndex = 98;
            // 
            // label241
            // 
            this.label241.AutoSize = true;
            this.label241.Location = new System.Drawing.Point(4, 250);
            this.label241.Name = "label241";
            this.label241.Size = new System.Drawing.Size(101, 12);
            this.label241.TabIndex = 97;
            this.label241.Text = "校准参数6-放电K2";
            // 
            // txtBmsCalibratorParaDischgK2
            // 
            this.txtBmsCalibratorParaDischgK2.Location = new System.Drawing.Point(109, 245);
            this.txtBmsCalibratorParaDischgK2.MaxLength = 8;
            this.txtBmsCalibratorParaDischgK2.Name = "txtBmsCalibratorParaDischgK2";
            this.txtBmsCalibratorParaDischgK2.Size = new System.Drawing.Size(82, 21);
            this.txtBmsCalibratorParaDischgK2.TabIndex = 96;
            // 
            // label242
            // 
            this.label242.AutoSize = true;
            this.label242.Location = new System.Drawing.Point(4, 42);
            this.label242.Name = "label242";
            this.label242.Size = new System.Drawing.Size(101, 12);
            this.label242.TabIndex = 95;
            this.label242.Text = "校准参数1-充电B0";
            // 
            // txtBmsCalibratorParaChgB0
            // 
            this.txtBmsCalibratorParaChgB0.Location = new System.Drawing.Point(109, 37);
            this.txtBmsCalibratorParaChgB0.MaxLength = 8;
            this.txtBmsCalibratorParaChgB0.Name = "txtBmsCalibratorParaChgB0";
            this.txtBmsCalibratorParaChgB0.Size = new System.Drawing.Size(82, 21);
            this.txtBmsCalibratorParaChgB0.TabIndex = 94;
            // 
            // label243
            // 
            this.label243.AutoSize = true;
            this.label243.Location = new System.Drawing.Point(4, 20);
            this.label243.Name = "label243";
            this.label243.Size = new System.Drawing.Size(101, 12);
            this.label243.TabIndex = 92;
            this.label243.Text = "校准参数1-充电K0";
            // 
            // txtBmsCalibratorParaChgK0
            // 
            this.txtBmsCalibratorParaChgK0.Location = new System.Drawing.Point(109, 14);
            this.txtBmsCalibratorParaChgK0.MaxLength = 8;
            this.txtBmsCalibratorParaChgK0.Name = "txtBmsCalibratorParaChgK0";
            this.txtBmsCalibratorParaChgK0.Size = new System.Drawing.Size(82, 21);
            this.txtBmsCalibratorParaChgK0.TabIndex = 91;
            // 
            // label244
            // 
            this.label244.AutoSize = true;
            this.label244.Location = new System.Drawing.Point(4, 181);
            this.label244.Name = "label244";
            this.label244.Size = new System.Drawing.Size(101, 12);
            this.label244.TabIndex = 83;
            this.label244.Text = "校准参数4-充电B3";
            // 
            // txtBmsCalibratorParaChgB3
            // 
            this.txtBmsCalibratorParaChgB3.Location = new System.Drawing.Point(109, 176);
            this.txtBmsCalibratorParaChgB3.MaxLength = 8;
            this.txtBmsCalibratorParaChgB3.Name = "txtBmsCalibratorParaChgB3";
            this.txtBmsCalibratorParaChgB3.Size = new System.Drawing.Size(82, 21);
            this.txtBmsCalibratorParaChgB3.TabIndex = 82;
            // 
            // label245
            // 
            this.label245.AutoSize = true;
            this.label245.Location = new System.Drawing.Point(4, 158);
            this.label245.Name = "label245";
            this.label245.Size = new System.Drawing.Size(101, 12);
            this.label245.TabIndex = 80;
            this.label245.Text = "校准参数4-充电K3";
            // 
            // txtBmsCalibratorParaChgK3
            // 
            this.txtBmsCalibratorParaChgK3.Location = new System.Drawing.Point(109, 153);
            this.txtBmsCalibratorParaChgK3.MaxLength = 8;
            this.txtBmsCalibratorParaChgK3.Name = "txtBmsCalibratorParaChgK3";
            this.txtBmsCalibratorParaChgK3.Size = new System.Drawing.Size(82, 21);
            this.txtBmsCalibratorParaChgK3.TabIndex = 79;
            // 
            // label246
            // 
            this.label246.AutoSize = true;
            this.label246.Location = new System.Drawing.Point(4, 134);
            this.label246.Name = "label246";
            this.label246.Size = new System.Drawing.Size(101, 12);
            this.label246.TabIndex = 77;
            this.label246.Text = "校准参数3-充电B2";
            // 
            // txtBmsCalibratorParaChgB2
            // 
            this.txtBmsCalibratorParaChgB2.Location = new System.Drawing.Point(109, 129);
            this.txtBmsCalibratorParaChgB2.MaxLength = 8;
            this.txtBmsCalibratorParaChgB2.Name = "txtBmsCalibratorParaChgB2";
            this.txtBmsCalibratorParaChgB2.Size = new System.Drawing.Size(82, 21);
            this.txtBmsCalibratorParaChgB2.TabIndex = 76;
            // 
            // label247
            // 
            this.label247.AutoSize = true;
            this.label247.Location = new System.Drawing.Point(4, 111);
            this.label247.Name = "label247";
            this.label247.Size = new System.Drawing.Size(101, 12);
            this.label247.TabIndex = 74;
            this.label247.Text = "校准参数3-充电K2";
            // 
            // txtBmsCalibratorParaChgK2
            // 
            this.txtBmsCalibratorParaChgK2.Location = new System.Drawing.Point(109, 106);
            this.txtBmsCalibratorParaChgK2.MaxLength = 8;
            this.txtBmsCalibratorParaChgK2.Name = "txtBmsCalibratorParaChgK2";
            this.txtBmsCalibratorParaChgK2.Size = new System.Drawing.Size(82, 21);
            this.txtBmsCalibratorParaChgK2.TabIndex = 73;
            // 
            // label248
            // 
            this.label248.AutoSize = true;
            this.label248.Location = new System.Drawing.Point(4, 88);
            this.label248.Name = "label248";
            this.label248.Size = new System.Drawing.Size(101, 12);
            this.label248.TabIndex = 71;
            this.label248.Text = "校准参数2-充电B1";
            // 
            // txtBmsCalibratorParaChgB1
            // 
            this.txtBmsCalibratorParaChgB1.Location = new System.Drawing.Point(109, 83);
            this.txtBmsCalibratorParaChgB1.MaxLength = 8;
            this.txtBmsCalibratorParaChgB1.Name = "txtBmsCalibratorParaChgB1";
            this.txtBmsCalibratorParaChgB1.Size = new System.Drawing.Size(82, 21);
            this.txtBmsCalibratorParaChgB1.TabIndex = 70;
            // 
            // label249
            // 
            this.label249.AutoSize = true;
            this.label249.Location = new System.Drawing.Point(4, 65);
            this.label249.Name = "label249";
            this.label249.Size = new System.Drawing.Size(101, 12);
            this.label249.TabIndex = 68;
            this.label249.Text = "校准参数2-充电K1";
            // 
            // txtBmsCalibratorParaChgK1
            // 
            this.txtBmsCalibratorParaChgK1.Location = new System.Drawing.Point(109, 60);
            this.txtBmsCalibratorParaChgK1.MaxLength = 8;
            this.txtBmsCalibratorParaChgK1.Name = "txtBmsCalibratorParaChgK1";
            this.txtBmsCalibratorParaChgK1.Size = new System.Drawing.Size(82, 21);
            this.txtBmsCalibratorParaChgK1.TabIndex = 57;
            // 
            // groupBox36
            // 
            this.groupBox36.Controls.Add(this.label271);
            this.groupBox36.Controls.Add(this.label272);
            this.groupBox36.Controls.Add(this.label273);
            this.groupBox36.Controls.Add(this.label274);
            this.groupBox36.Controls.Add(this.label275);
            this.groupBox36.Controls.Add(this.label276);
            this.groupBox36.Controls.Add(this.label277);
            this.groupBox36.Controls.Add(this.label278);
            this.groupBox36.Controls.Add(this.label263);
            this.groupBox36.Controls.Add(this.label264);
            this.groupBox36.Controls.Add(this.label265);
            this.groupBox36.Controls.Add(this.label266);
            this.groupBox36.Controls.Add(this.label267);
            this.groupBox36.Controls.Add(this.label268);
            this.groupBox36.Controls.Add(this.label269);
            this.groupBox36.Controls.Add(this.label270);
            this.groupBox36.Controls.Add(this.btnBmsSetCalibrateCurrSamplingInputCmd);
            this.groupBox36.Controls.Add(this.label94);
            this.groupBox36.Controls.Add(this.txtBmsPowerAnalysisSamplDischgData1);
            this.groupBox36.Controls.Add(this.label215);
            this.groupBox36.Controls.Add(this.txtBmsSamplingDischgData1);
            this.groupBox36.Controls.Add(this.label217);
            this.groupBox36.Controls.Add(this.txtBmsPowerAnalysisSamplDischgData4);
            this.groupBox36.Controls.Add(this.label222);
            this.groupBox36.Controls.Add(this.txtBmsSamplingDischgData4);
            this.groupBox36.Controls.Add(this.label224);
            this.groupBox36.Controls.Add(this.txtBmsPowerAnalysisSamplDischgData3);
            this.groupBox36.Controls.Add(this.label225);
            this.groupBox36.Controls.Add(this.txtBmsSamplingDischgData3);
            this.groupBox36.Controls.Add(this.label226);
            this.groupBox36.Controls.Add(this.txtBmsPowerAnalysisSamplDischgData2);
            this.groupBox36.Controls.Add(this.label227);
            this.groupBox36.Controls.Add(this.txtBmsSamplingDischgData2);
            this.groupBox36.Controls.Add(this.label216);
            this.groupBox36.Controls.Add(this.txtBmsPowerAnalysisSamplChgData1);
            this.groupBox36.Controls.Add(this.label221);
            this.groupBox36.Controls.Add(this.txtBmsSamplingChgData1);
            this.groupBox36.Controls.Add(this.label228);
            this.groupBox36.Controls.Add(this.txtBmsPowerAnalysisSamplChgData4);
            this.groupBox36.Controls.Add(this.label230);
            this.groupBox36.Controls.Add(this.txtBmsSamplingChgData4);
            this.groupBox36.Controls.Add(this.label232);
            this.groupBox36.Controls.Add(this.txtBmsPowerAnalysisSamplChgData3);
            this.groupBox36.Controls.Add(this.label234);
            this.groupBox36.Controls.Add(this.txtBmsSamplingChgData3);
            this.groupBox36.Controls.Add(this.label236);
            this.groupBox36.Controls.Add(this.txtBmsPowerAnalysisSamplChgData2);
            this.groupBox36.Controls.Add(this.label238);
            this.groupBox36.Controls.Add(this.txtBmsSamplingChgData2);
            this.groupBox36.Location = new System.Drawing.Point(318, 74);
            this.groupBox36.Name = "groupBox36";
            this.groupBox36.Size = new System.Drawing.Size(288, 388);
            this.groupBox36.TabIndex = 95;
            this.groupBox36.TabStop = false;
            this.groupBox36.Text = "校准电流采样输入设置";
            // 
            // label271
            // 
            this.label271.AutoSize = true;
            this.label271.Location = new System.Drawing.Point(200, 206);
            this.label271.Name = "label271";
            this.label271.Size = new System.Drawing.Size(11, 12);
            this.label271.TabIndex = 148;
            this.label271.Text = "A";
            // 
            // label272
            // 
            this.label272.AutoSize = true;
            this.label272.Location = new System.Drawing.Point(200, 366);
            this.label272.Name = "label272";
            this.label272.Size = new System.Drawing.Size(11, 12);
            this.label272.TabIndex = 147;
            this.label272.Text = "A";
            // 
            // label273
            // 
            this.label273.AutoSize = true;
            this.label273.Location = new System.Drawing.Point(200, 343);
            this.label273.Name = "label273";
            this.label273.Size = new System.Drawing.Size(11, 12);
            this.label273.TabIndex = 146;
            this.label273.Text = "A";
            // 
            // label274
            // 
            this.label274.AutoSize = true;
            this.label274.Location = new System.Drawing.Point(200, 319);
            this.label274.Name = "label274";
            this.label274.Size = new System.Drawing.Size(11, 12);
            this.label274.TabIndex = 145;
            this.label274.Text = "A";
            // 
            // label275
            // 
            this.label275.AutoSize = true;
            this.label275.Location = new System.Drawing.Point(200, 296);
            this.label275.Name = "label275";
            this.label275.Size = new System.Drawing.Size(11, 12);
            this.label275.TabIndex = 144;
            this.label275.Text = "A";
            // 
            // label276
            // 
            this.label276.AutoSize = true;
            this.label276.Location = new System.Drawing.Point(200, 273);
            this.label276.Name = "label276";
            this.label276.Size = new System.Drawing.Size(11, 12);
            this.label276.TabIndex = 143;
            this.label276.Text = "A";
            // 
            // label277
            // 
            this.label277.AutoSize = true;
            this.label277.Location = new System.Drawing.Point(200, 249);
            this.label277.Name = "label277";
            this.label277.Size = new System.Drawing.Size(11, 12);
            this.label277.TabIndex = 142;
            this.label277.Text = "A";
            // 
            // label278
            // 
            this.label278.AutoSize = true;
            this.label278.Location = new System.Drawing.Point(200, 227);
            this.label278.Name = "label278";
            this.label278.Size = new System.Drawing.Size(11, 12);
            this.label278.TabIndex = 141;
            this.label278.Text = "A";
            // 
            // label263
            // 
            this.label263.AutoSize = true;
            this.label263.Location = new System.Drawing.Point(200, 20);
            this.label263.Name = "label263";
            this.label263.Size = new System.Drawing.Size(11, 12);
            this.label263.TabIndex = 140;
            this.label263.Text = "A";
            // 
            // label264
            // 
            this.label264.AutoSize = true;
            this.label264.Location = new System.Drawing.Point(200, 182);
            this.label264.Name = "label264";
            this.label264.Size = new System.Drawing.Size(11, 12);
            this.label264.TabIndex = 139;
            this.label264.Text = "A";
            // 
            // label265
            // 
            this.label265.AutoSize = true;
            this.label265.Location = new System.Drawing.Point(200, 157);
            this.label265.Name = "label265";
            this.label265.Size = new System.Drawing.Size(11, 12);
            this.label265.TabIndex = 138;
            this.label265.Text = "A";
            // 
            // label266
            // 
            this.label266.AutoSize = true;
            this.label266.Location = new System.Drawing.Point(200, 133);
            this.label266.Name = "label266";
            this.label266.Size = new System.Drawing.Size(11, 12);
            this.label266.TabIndex = 137;
            this.label266.Text = "A";
            // 
            // label267
            // 
            this.label267.AutoSize = true;
            this.label267.Location = new System.Drawing.Point(200, 110);
            this.label267.Name = "label267";
            this.label267.Size = new System.Drawing.Size(11, 12);
            this.label267.TabIndex = 136;
            this.label267.Text = "A";
            // 
            // label268
            // 
            this.label268.AutoSize = true;
            this.label268.Location = new System.Drawing.Point(200, 88);
            this.label268.Name = "label268";
            this.label268.Size = new System.Drawing.Size(11, 12);
            this.label268.TabIndex = 135;
            this.label268.Text = "A";
            // 
            // label269
            // 
            this.label269.AutoSize = true;
            this.label269.Location = new System.Drawing.Point(200, 65);
            this.label269.Name = "label269";
            this.label269.Size = new System.Drawing.Size(11, 12);
            this.label269.TabIndex = 134;
            this.label269.Text = "A";
            // 
            // label270
            // 
            this.label270.AutoSize = true;
            this.label270.Location = new System.Drawing.Point(200, 42);
            this.label270.Name = "label270";
            this.label270.Size = new System.Drawing.Size(11, 12);
            this.label270.TabIndex = 133;
            this.label270.Text = "A";
            // 
            // btnBmsSetCalibrateCurrSamplingInputCmd
            // 
            this.btnBmsSetCalibrateCurrSamplingInputCmd.Location = new System.Drawing.Point(218, 129);
            this.btnBmsSetCalibrateCurrSamplingInputCmd.Name = "btnBmsSetCalibrateCurrSamplingInputCmd";
            this.btnBmsSetCalibrateCurrSamplingInputCmd.Size = new System.Drawing.Size(62, 137);
            this.btnBmsSetCalibrateCurrSamplingInputCmd.TabIndex = 112;
            this.btnBmsSetCalibrateCurrSamplingInputCmd.Text = "设 置";
            this.btnBmsSetCalibrateCurrSamplingInputCmd.UseVisualStyleBackColor = true;
            // 
            // label94
            // 
            this.label94.AutoSize = true;
            this.label94.Location = new System.Drawing.Point(4, 227);
            this.label94.Name = "label94";
            this.label94.Size = new System.Drawing.Size(107, 12);
            this.label94.TabIndex = 111;
            this.label94.Text = "功分采样放电数据1";
            // 
            // txtBmsPowerAnalysisSamplDischgData1
            // 
            this.txtBmsPowerAnalysisSamplDischgData1.Location = new System.Drawing.Point(112, 222);
            this.txtBmsPowerAnalysisSamplDischgData1.MaxLength = 8;
            this.txtBmsPowerAnalysisSamplDischgData1.Name = "txtBmsPowerAnalysisSamplDischgData1";
            this.txtBmsPowerAnalysisSamplDischgData1.Size = new System.Drawing.Size(82, 21);
            this.txtBmsPowerAnalysisSamplDischgData1.TabIndex = 110;
            // 
            // label215
            // 
            this.label215.AutoSize = true;
            this.label215.Location = new System.Drawing.Point(4, 204);
            this.label215.Name = "label215";
            this.label215.Size = new System.Drawing.Size(101, 12);
            this.label215.TabIndex = 109;
            this.label215.Text = "BMS采样放电数据1";
            // 
            // txtBmsSamplingDischgData1
            // 
            this.txtBmsSamplingDischgData1.Location = new System.Drawing.Point(112, 199);
            this.txtBmsSamplingDischgData1.MaxLength = 8;
            this.txtBmsSamplingDischgData1.Name = "txtBmsSamplingDischgData1";
            this.txtBmsSamplingDischgData1.Size = new System.Drawing.Size(82, 21);
            this.txtBmsSamplingDischgData1.TabIndex = 108;
            // 
            // label217
            // 
            this.label217.AutoSize = true;
            this.label217.Location = new System.Drawing.Point(4, 366);
            this.label217.Name = "label217";
            this.label217.Size = new System.Drawing.Size(107, 12);
            this.label217.TabIndex = 107;
            this.label217.Text = "功分采样放电数据4";
            // 
            // txtBmsPowerAnalysisSamplDischgData4
            // 
            this.txtBmsPowerAnalysisSamplDischgData4.Location = new System.Drawing.Point(112, 361);
            this.txtBmsPowerAnalysisSamplDischgData4.MaxLength = 8;
            this.txtBmsPowerAnalysisSamplDischgData4.Name = "txtBmsPowerAnalysisSamplDischgData4";
            this.txtBmsPowerAnalysisSamplDischgData4.Size = new System.Drawing.Size(82, 21);
            this.txtBmsPowerAnalysisSamplDischgData4.TabIndex = 106;
            // 
            // label222
            // 
            this.label222.AutoSize = true;
            this.label222.Location = new System.Drawing.Point(4, 343);
            this.label222.Name = "label222";
            this.label222.Size = new System.Drawing.Size(101, 12);
            this.label222.TabIndex = 105;
            this.label222.Text = "BMS采样放电数据4";
            // 
            // txtBmsSamplingDischgData4
            // 
            this.txtBmsSamplingDischgData4.Location = new System.Drawing.Point(112, 338);
            this.txtBmsSamplingDischgData4.MaxLength = 8;
            this.txtBmsSamplingDischgData4.Name = "txtBmsSamplingDischgData4";
            this.txtBmsSamplingDischgData4.Size = new System.Drawing.Size(82, 21);
            this.txtBmsSamplingDischgData4.TabIndex = 104;
            // 
            // label224
            // 
            this.label224.AutoSize = true;
            this.label224.Location = new System.Drawing.Point(4, 319);
            this.label224.Name = "label224";
            this.label224.Size = new System.Drawing.Size(107, 12);
            this.label224.TabIndex = 103;
            this.label224.Text = "功分采样放电数据3";
            // 
            // txtBmsPowerAnalysisSamplDischgData3
            // 
            this.txtBmsPowerAnalysisSamplDischgData3.Location = new System.Drawing.Point(112, 314);
            this.txtBmsPowerAnalysisSamplDischgData3.MaxLength = 8;
            this.txtBmsPowerAnalysisSamplDischgData3.Name = "txtBmsPowerAnalysisSamplDischgData3";
            this.txtBmsPowerAnalysisSamplDischgData3.Size = new System.Drawing.Size(82, 21);
            this.txtBmsPowerAnalysisSamplDischgData3.TabIndex = 102;
            // 
            // label225
            // 
            this.label225.AutoSize = true;
            this.label225.Location = new System.Drawing.Point(4, 296);
            this.label225.Name = "label225";
            this.label225.Size = new System.Drawing.Size(101, 12);
            this.label225.TabIndex = 101;
            this.label225.Text = "BMS采样放电数据3";
            // 
            // txtBmsSamplingDischgData3
            // 
            this.txtBmsSamplingDischgData3.Location = new System.Drawing.Point(112, 291);
            this.txtBmsSamplingDischgData3.MaxLength = 8;
            this.txtBmsSamplingDischgData3.Name = "txtBmsSamplingDischgData3";
            this.txtBmsSamplingDischgData3.Size = new System.Drawing.Size(82, 21);
            this.txtBmsSamplingDischgData3.TabIndex = 100;
            // 
            // label226
            // 
            this.label226.AutoSize = true;
            this.label226.Location = new System.Drawing.Point(4, 273);
            this.label226.Name = "label226";
            this.label226.Size = new System.Drawing.Size(107, 12);
            this.label226.TabIndex = 99;
            this.label226.Text = "功分采样放电数据2";
            // 
            // txtBmsPowerAnalysisSamplDischgData2
            // 
            this.txtBmsPowerAnalysisSamplDischgData2.Location = new System.Drawing.Point(112, 268);
            this.txtBmsPowerAnalysisSamplDischgData2.MaxLength = 8;
            this.txtBmsPowerAnalysisSamplDischgData2.Name = "txtBmsPowerAnalysisSamplDischgData2";
            this.txtBmsPowerAnalysisSamplDischgData2.Size = new System.Drawing.Size(82, 21);
            this.txtBmsPowerAnalysisSamplDischgData2.TabIndex = 98;
            // 
            // label227
            // 
            this.label227.AutoSize = true;
            this.label227.Location = new System.Drawing.Point(4, 250);
            this.label227.Name = "label227";
            this.label227.Size = new System.Drawing.Size(101, 12);
            this.label227.TabIndex = 97;
            this.label227.Text = "BMS采样放电数据2";
            // 
            // txtBmsSamplingDischgData2
            // 
            this.txtBmsSamplingDischgData2.Location = new System.Drawing.Point(112, 245);
            this.txtBmsSamplingDischgData2.MaxLength = 8;
            this.txtBmsSamplingDischgData2.Name = "txtBmsSamplingDischgData2";
            this.txtBmsSamplingDischgData2.Size = new System.Drawing.Size(82, 21);
            this.txtBmsSamplingDischgData2.TabIndex = 96;
            // 
            // label216
            // 
            this.label216.AutoSize = true;
            this.label216.Location = new System.Drawing.Point(4, 42);
            this.label216.Name = "label216";
            this.label216.Size = new System.Drawing.Size(107, 12);
            this.label216.TabIndex = 95;
            this.label216.Text = "功分采样充电数据1";
            // 
            // txtBmsPowerAnalysisSamplChgData1
            // 
            this.txtBmsPowerAnalysisSamplChgData1.Location = new System.Drawing.Point(112, 37);
            this.txtBmsPowerAnalysisSamplChgData1.MaxLength = 8;
            this.txtBmsPowerAnalysisSamplChgData1.Name = "txtBmsPowerAnalysisSamplChgData1";
            this.txtBmsPowerAnalysisSamplChgData1.Size = new System.Drawing.Size(82, 21);
            this.txtBmsPowerAnalysisSamplChgData1.TabIndex = 94;
            // 
            // label221
            // 
            this.label221.AutoSize = true;
            this.label221.Location = new System.Drawing.Point(4, 20);
            this.label221.Name = "label221";
            this.label221.Size = new System.Drawing.Size(101, 12);
            this.label221.TabIndex = 92;
            this.label221.Text = "BMS采样充电数据1";
            // 
            // txtBmsSamplingChgData1
            // 
            this.txtBmsSamplingChgData1.Location = new System.Drawing.Point(112, 14);
            this.txtBmsSamplingChgData1.MaxLength = 8;
            this.txtBmsSamplingChgData1.Name = "txtBmsSamplingChgData1";
            this.txtBmsSamplingChgData1.Size = new System.Drawing.Size(82, 21);
            this.txtBmsSamplingChgData1.TabIndex = 91;
            // 
            // label228
            // 
            this.label228.AutoSize = true;
            this.label228.Location = new System.Drawing.Point(4, 181);
            this.label228.Name = "label228";
            this.label228.Size = new System.Drawing.Size(107, 12);
            this.label228.TabIndex = 83;
            this.label228.Text = "功分采样充电数据4";
            // 
            // txtBmsPowerAnalysisSamplChgData4
            // 
            this.txtBmsPowerAnalysisSamplChgData4.Location = new System.Drawing.Point(112, 176);
            this.txtBmsPowerAnalysisSamplChgData4.MaxLength = 8;
            this.txtBmsPowerAnalysisSamplChgData4.Name = "txtBmsPowerAnalysisSamplChgData4";
            this.txtBmsPowerAnalysisSamplChgData4.Size = new System.Drawing.Size(82, 21);
            this.txtBmsPowerAnalysisSamplChgData4.TabIndex = 82;
            // 
            // label230
            // 
            this.label230.AutoSize = true;
            this.label230.Location = new System.Drawing.Point(4, 158);
            this.label230.Name = "label230";
            this.label230.Size = new System.Drawing.Size(101, 12);
            this.label230.TabIndex = 80;
            this.label230.Text = "BMS采样充电数据4";
            // 
            // txtBmsSamplingChgData4
            // 
            this.txtBmsSamplingChgData4.Location = new System.Drawing.Point(112, 153);
            this.txtBmsSamplingChgData4.MaxLength = 8;
            this.txtBmsSamplingChgData4.Name = "txtBmsSamplingChgData4";
            this.txtBmsSamplingChgData4.Size = new System.Drawing.Size(82, 21);
            this.txtBmsSamplingChgData4.TabIndex = 79;
            // 
            // label232
            // 
            this.label232.AutoSize = true;
            this.label232.Location = new System.Drawing.Point(4, 134);
            this.label232.Name = "label232";
            this.label232.Size = new System.Drawing.Size(107, 12);
            this.label232.TabIndex = 77;
            this.label232.Text = "功分采样充电数据3";
            // 
            // txtBmsPowerAnalysisSamplChgData3
            // 
            this.txtBmsPowerAnalysisSamplChgData3.Location = new System.Drawing.Point(112, 129);
            this.txtBmsPowerAnalysisSamplChgData3.MaxLength = 8;
            this.txtBmsPowerAnalysisSamplChgData3.Name = "txtBmsPowerAnalysisSamplChgData3";
            this.txtBmsPowerAnalysisSamplChgData3.Size = new System.Drawing.Size(82, 21);
            this.txtBmsPowerAnalysisSamplChgData3.TabIndex = 76;
            // 
            // label234
            // 
            this.label234.AutoSize = true;
            this.label234.Location = new System.Drawing.Point(4, 111);
            this.label234.Name = "label234";
            this.label234.Size = new System.Drawing.Size(101, 12);
            this.label234.TabIndex = 74;
            this.label234.Text = "BMS采样充电数据3";
            // 
            // txtBmsSamplingChgData3
            // 
            this.txtBmsSamplingChgData3.Location = new System.Drawing.Point(112, 106);
            this.txtBmsSamplingChgData3.MaxLength = 8;
            this.txtBmsSamplingChgData3.Name = "txtBmsSamplingChgData3";
            this.txtBmsSamplingChgData3.Size = new System.Drawing.Size(82, 21);
            this.txtBmsSamplingChgData3.TabIndex = 73;
            // 
            // label236
            // 
            this.label236.AutoSize = true;
            this.label236.Location = new System.Drawing.Point(4, 88);
            this.label236.Name = "label236";
            this.label236.Size = new System.Drawing.Size(107, 12);
            this.label236.TabIndex = 71;
            this.label236.Text = "功分采样充电数据2";
            // 
            // txtBmsPowerAnalysisSamplChgData2
            // 
            this.txtBmsPowerAnalysisSamplChgData2.Location = new System.Drawing.Point(112, 83);
            this.txtBmsPowerAnalysisSamplChgData2.MaxLength = 8;
            this.txtBmsPowerAnalysisSamplChgData2.Name = "txtBmsPowerAnalysisSamplChgData2";
            this.txtBmsPowerAnalysisSamplChgData2.Size = new System.Drawing.Size(82, 21);
            this.txtBmsPowerAnalysisSamplChgData2.TabIndex = 70;
            // 
            // label238
            // 
            this.label238.AutoSize = true;
            this.label238.Location = new System.Drawing.Point(4, 65);
            this.label238.Name = "label238";
            this.label238.Size = new System.Drawing.Size(101, 12);
            this.label238.TabIndex = 68;
            this.label238.Text = "BMS采样充电数据2";
            // 
            // txtBmsSamplingChgData2
            // 
            this.txtBmsSamplingChgData2.Location = new System.Drawing.Point(112, 60);
            this.txtBmsSamplingChgData2.MaxLength = 8;
            this.txtBmsSamplingChgData2.Name = "txtBmsSamplingChgData2";
            this.txtBmsSamplingChgData2.Size = new System.Drawing.Size(82, 21);
            this.txtBmsSamplingChgData2.TabIndex = 57;
            // 
            // groupBox24
            // 
            this.groupBox24.Controls.Add(this.groupBox42);
            this.groupBox24.Controls.Add(this.groupBox41);
            this.groupBox24.Controls.Add(this.groupBox33);
            this.groupBox24.Controls.Add(this.groupBox11);
            this.groupBox24.Location = new System.Drawing.Point(10, 5);
            this.groupBox24.Name = "groupBox24";
            this.groupBox24.Size = new System.Drawing.Size(602, 609);
            this.groupBox24.TabIndex = 80;
            this.groupBox24.TabStop = false;
            this.groupBox24.Text = "BMS快捷操作";
            // 
            // groupBox42
            // 
            this.groupBox42.Controls.Add(this.btnBmsHeartBeat);
            this.groupBox42.Location = new System.Drawing.Point(308, 534);
            this.groupBox42.Name = "groupBox42";
            this.groupBox42.Size = new System.Drawing.Size(118, 61);
            this.groupBox42.TabIndex = 98;
            this.groupBox42.TabStop = false;
            this.groupBox42.Text = "心跳控制";
            // 
            // btnBmsHeartBeat
            // 
            this.btnBmsHeartBeat.Location = new System.Drawing.Point(20, 17);
            this.btnBmsHeartBeat.Name = "btnBmsHeartBeat";
            this.btnBmsHeartBeat.Size = new System.Drawing.Size(78, 34);
            this.btnBmsHeartBeat.TabIndex = 68;
            this.btnBmsHeartBeat.Text = "开始心跳";
            this.btnBmsHeartBeat.UseVisualStyleBackColor = true;
            // 
            // groupBox41
            // 
            this.groupBox41.Controls.Add(this.btnBmsSetChgReverseCompensationParamCmd);
            this.groupBox41.Controls.Add(this.txtBmsChgReverseCompensationParam);
            this.groupBox41.Controls.Add(this.label283);
            this.groupBox41.Location = new System.Drawing.Point(308, 459);
            this.groupBox41.Name = "groupBox41";
            this.groupBox41.Size = new System.Drawing.Size(118, 72);
            this.groupBox41.TabIndex = 97;
            this.groupBox41.TabStop = false;
            this.groupBox41.Text = "充电反向补偿系数";
            // 
            // btnBmsSetChgReverseCompensationParamCmd
            // 
            this.btnBmsSetChgReverseCompensationParamCmd.Location = new System.Drawing.Point(67, 46);
            this.btnBmsSetChgReverseCompensationParamCmd.Name = "btnBmsSetChgReverseCompensationParamCmd";
            this.btnBmsSetChgReverseCompensationParamCmd.Size = new System.Drawing.Size(39, 20);
            this.btnBmsSetChgReverseCompensationParamCmd.TabIndex = 100;
            this.btnBmsSetChgReverseCompensationParamCmd.Text = "设置";
            this.btnBmsSetChgReverseCompensationParamCmd.UseVisualStyleBackColor = true;
            // 
            // txtBmsChgReverseCompensationParam
            // 
            this.txtBmsChgReverseCompensationParam.Location = new System.Drawing.Point(4, 20);
            this.txtBmsChgReverseCompensationParam.MaxLength = 8;
            this.txtBmsChgReverseCompensationParam.Name = "txtBmsChgReverseCompensationParam";
            this.txtBmsChgReverseCompensationParam.Size = new System.Drawing.Size(80, 21);
            this.txtBmsChgReverseCompensationParam.TabIndex = 96;
            // 
            // label283
            // 
            this.label283.AutoSize = true;
            this.label283.Location = new System.Drawing.Point(95, 160);
            this.label283.Name = "label283";
            this.label283.Size = new System.Drawing.Size(11, 12);
            this.label283.TabIndex = 57;
            this.label283.Text = "V";
            // 
            // groupBox33
            // 
            this.groupBox33.Controls.Add(this.label165);
            this.groupBox33.Controls.Add(this.label164);
            this.groupBox33.Controls.Add(this.textBoxBmsCPhaseChgDisChgPower);
            this.groupBox33.Controls.Add(this.label163);
            this.groupBox33.Controls.Add(this.textBoxBmsBPhaseChgDisChgPower);
            this.groupBox33.Controls.Add(this.label162);
            this.groupBox33.Controls.Add(this.textBoxBmsAPhaseChgDisChgPower);
            this.groupBox33.Controls.Add(this.btnBmsSetThreeChapseChgDischgCmd);
            this.groupBox33.Location = new System.Drawing.Point(8, 15);
            this.groupBox33.Name = "groupBox33";
            this.groupBox33.Size = new System.Drawing.Size(333, 53);
            this.groupBox33.TabIndex = 73;
            this.groupBox33.TabStop = false;
            this.groupBox33.Text = "下发A,B,C三相充放电指令";
            // 
            // label165
            // 
            this.label165.AutoSize = true;
            this.label165.Location = new System.Drawing.Point(239, 26);
            this.label165.Name = "label165";
            this.label165.Size = new System.Drawing.Size(17, 12);
            this.label165.TabIndex = 63;
            this.label165.Text = "kW";
            // 
            // label164
            // 
            this.label164.AutoSize = true;
            this.label164.Location = new System.Drawing.Point(163, 25);
            this.label164.Name = "label164";
            this.label164.Size = new System.Drawing.Size(23, 12);
            this.label164.TabIndex = 62;
            this.label164.Text = "C相";
            // 
            // textBoxBmsCPhaseChgDisChgPower
            // 
            this.textBoxBmsCPhaseChgDisChgPower.Location = new System.Drawing.Point(187, 19);
            this.textBoxBmsCPhaseChgDisChgPower.MaxLength = 8;
            this.textBoxBmsCPhaseChgDisChgPower.Name = "textBoxBmsCPhaseChgDisChgPower";
            this.textBoxBmsCPhaseChgDisChgPower.Size = new System.Drawing.Size(48, 21);
            this.textBoxBmsCPhaseChgDisChgPower.TabIndex = 61;
            // 
            // label163
            // 
            this.label163.AutoSize = true;
            this.label163.Location = new System.Drawing.Point(82, 25);
            this.label163.Name = "label163";
            this.label163.Size = new System.Drawing.Size(23, 12);
            this.label163.TabIndex = 60;
            this.label163.Text = "B相";
            // 
            // textBoxBmsBPhaseChgDisChgPower
            // 
            this.textBoxBmsBPhaseChgDisChgPower.Location = new System.Drawing.Point(106, 19);
            this.textBoxBmsBPhaseChgDisChgPower.MaxLength = 8;
            this.textBoxBmsBPhaseChgDisChgPower.Name = "textBoxBmsBPhaseChgDisChgPower";
            this.textBoxBmsBPhaseChgDisChgPower.Size = new System.Drawing.Size(48, 21);
            this.textBoxBmsBPhaseChgDisChgPower.TabIndex = 59;
            // 
            // label162
            // 
            this.label162.AutoSize = true;
            this.label162.Location = new System.Drawing.Point(4, 26);
            this.label162.Name = "label162";
            this.label162.Size = new System.Drawing.Size(23, 12);
            this.label162.TabIndex = 58;
            this.label162.Text = "A相";
            // 
            // textBoxBmsAPhaseChgDisChgPower
            // 
            this.textBoxBmsAPhaseChgDisChgPower.Location = new System.Drawing.Point(28, 19);
            this.textBoxBmsAPhaseChgDisChgPower.MaxLength = 8;
            this.textBoxBmsAPhaseChgDisChgPower.Name = "textBoxBmsAPhaseChgDisChgPower";
            this.textBoxBmsAPhaseChgDisChgPower.Size = new System.Drawing.Size(48, 21);
            this.textBoxBmsAPhaseChgDisChgPower.TabIndex = 57;
            // 
            // btnBmsSetThreeChapseChgDischgCmd
            // 
            this.btnBmsSetThreeChapseChgDischgCmd.Location = new System.Drawing.Point(265, 14);
            this.btnBmsSetThreeChapseChgDischgCmd.Name = "btnBmsSetThreeChapseChgDischgCmd";
            this.btnBmsSetThreeChapseChgDischgCmd.Size = new System.Drawing.Size(62, 34);
            this.btnBmsSetThreeChapseChgDischgCmd.TabIndex = 56;
            this.btnBmsSetThreeChapseChgDischgCmd.Text = "设置";
            this.btnBmsSetThreeChapseChgDischgCmd.UseVisualStyleBackColor = true;
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.btnBmsTurnOffCmd);
            this.groupBox11.Controls.Add(this.btnBmsResetCmd);
            this.groupBox11.Controls.Add(this.btnBmsTurnOnCmd);
            this.groupBox11.Location = new System.Drawing.Point(352, 15);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(244, 53);
            this.groupBox11.TabIndex = 78;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "控制指令";
            // 
            // btnBmsTurnOffCmd
            // 
            this.btnBmsTurnOffCmd.Location = new System.Drawing.Point(12, 14);
            this.btnBmsTurnOffCmd.Name = "btnBmsTurnOffCmd";
            this.btnBmsTurnOffCmd.Size = new System.Drawing.Size(62, 34);
            this.btnBmsTurnOffCmd.TabIndex = 68;
            this.btnBmsTurnOffCmd.Text = "关机";
            this.btnBmsTurnOffCmd.UseVisualStyleBackColor = true;
            // 
            // btnBmsResetCmd
            // 
            this.btnBmsResetCmd.Location = new System.Drawing.Point(171, 14);
            this.btnBmsResetCmd.Name = "btnBmsResetCmd";
            this.btnBmsResetCmd.Size = new System.Drawing.Size(62, 34);
            this.btnBmsResetCmd.TabIndex = 67;
            this.btnBmsResetCmd.Text = "复位";
            this.btnBmsResetCmd.UseVisualStyleBackColor = true;
            // 
            // btnBmsTurnOnCmd
            // 
            this.btnBmsTurnOnCmd.Location = new System.Drawing.Point(92, 14);
            this.btnBmsTurnOnCmd.Name = "btnBmsTurnOnCmd";
            this.btnBmsTurnOnCmd.Size = new System.Drawing.Size(62, 34);
            this.btnBmsTurnOnCmd.TabIndex = 56;
            this.btnBmsTurnOnCmd.Text = "开机";
            this.btnBmsTurnOnCmd.UseVisualStyleBackColor = true;
            // 
            // tabPage9
            // 
            this.tabPage9.Controls.Add(this.groupBox57);
            this.tabPage9.Controls.Add(this.groupBox53);
            this.tabPage9.Controls.Add(this.groupBox49);
            this.tabPage9.Controls.Add(this.groupBox45);
            this.tabPage9.Location = new System.Drawing.Point(4, 22);
            this.tabPage9.Name = "tabPage9";
            this.tabPage9.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage9.Size = new System.Drawing.Size(716, 739);
            this.tabPage9.TabIndex = 6;
            this.tabPage9.Text = "备电盒在线调试";
            this.tabPage9.UseVisualStyleBackColor = true;
            // 
            // groupBox57
            // 
            this.groupBox57.Controls.Add(this.btnGetBkpAlmDataOnOffGridStateData);
            this.groupBox57.Controls.Add(this.label357);
            this.groupBox57.Controls.Add(this.txtBkpIsAlmState);
            this.groupBox57.Controls.Add(this.txtBkpIsAlmData);
            this.groupBox57.Controls.Add(this.label360);
            this.groupBox57.Controls.Add(this.label392);
            this.groupBox57.Controls.Add(this.txtBkpOnOffGridState);
            this.groupBox57.Location = new System.Drawing.Point(11, 608);
            this.groupBox57.Name = "groupBox57";
            this.groupBox57.Size = new System.Drawing.Size(612, 126);
            this.groupBox57.TabIndex = 113;
            this.groupBox57.TabStop = false;
            this.groupBox57.Text = "告警及其他数据";
            // 
            // btnGetBkpAlmDataOnOffGridStateData
            // 
            this.btnGetBkpAlmDataOnOffGridStateData.Location = new System.Drawing.Point(63, 71);
            this.btnGetBkpAlmDataOnOffGridStateData.Name = "btnGetBkpAlmDataOnOffGridStateData";
            this.btnGetBkpAlmDataOnOffGridStateData.Size = new System.Drawing.Size(451, 49);
            this.btnGetBkpAlmDataOnOffGridStateData.TabIndex = 105;
            this.btnGetBkpAlmDataOnOffGridStateData.Text = "读取信息";
            this.btnGetBkpAlmDataOnOffGridStateData.UseVisualStyleBackColor = true;
            // 
            // label357
            // 
            this.label357.AutoSize = true;
            this.label357.Location = new System.Drawing.Point(6, 22);
            this.label357.Name = "label357";
            this.label357.Size = new System.Drawing.Size(77, 12);
            this.label357.TabIndex = 231;
            this.label357.Text = "是否故障状态";
            // 
            // txtBkpIsAlmState
            // 
            this.txtBkpIsAlmState.Location = new System.Drawing.Point(84, 18);
            this.txtBkpIsAlmState.MaxLength = 8;
            this.txtBkpIsAlmState.Name = "txtBkpIsAlmState";
            this.txtBkpIsAlmState.Size = new System.Drawing.Size(66, 21);
            this.txtBkpIsAlmState.TabIndex = 230;
            // 
            // txtBkpIsAlmData
            // 
            this.txtBkpIsAlmData.Location = new System.Drawing.Point(61, 44);
            this.txtBkpIsAlmData.MaxLength = 300;
            this.txtBkpIsAlmData.Name = "txtBkpIsAlmData";
            this.txtBkpIsAlmData.Size = new System.Drawing.Size(536, 21);
            this.txtBkpIsAlmData.TabIndex = 227;
            // 
            // label360
            // 
            this.label360.AutoSize = true;
            this.label360.Location = new System.Drawing.Point(5, 49);
            this.label360.Name = "label360";
            this.label360.Size = new System.Drawing.Size(53, 12);
            this.label360.TabIndex = 225;
            this.label360.Text = "告警信息";
            // 
            // label392
            // 
            this.label392.AutoSize = true;
            this.label392.Location = new System.Drawing.Point(157, 22);
            this.label392.Name = "label392";
            this.label392.Size = new System.Drawing.Size(65, 12);
            this.label392.TabIndex = 191;
            this.label392.Text = "并离网状态";
            // 
            // txtBkpOnOffGridState
            // 
            this.txtBkpOnOffGridState.Location = new System.Drawing.Point(232, 18);
            this.txtBkpOnOffGridState.MaxLength = 8;
            this.txtBkpOnOffGridState.Name = "txtBkpOnOffGridState";
            this.txtBkpOnOffGridState.Size = new System.Drawing.Size(66, 21);
            this.txtBkpOnOffGridState.TabIndex = 189;
            // 
            // groupBox53
            // 
            this.groupBox53.Controls.Add(this.groupBox56);
            this.groupBox53.Controls.Add(this.btnBkpSetFanTurnOnOff);
            this.groupBox53.Location = new System.Drawing.Point(303, 334);
            this.groupBox53.Name = "groupBox53";
            this.groupBox53.Size = new System.Drawing.Size(196, 77);
            this.groupBox53.TabIndex = 112;
            this.groupBox53.TabStop = false;
            this.groupBox53.Text = "风扇设置";
            // 
            // groupBox56
            // 
            this.groupBox56.Controls.Add(this.radioBtnBkpFanTurnOff);
            this.groupBox56.Controls.Add(this.radioBtnBkpFanTurnOn);
            this.groupBox56.Location = new System.Drawing.Point(6, 9);
            this.groupBox56.Name = "groupBox56";
            this.groupBox56.Size = new System.Drawing.Size(78, 62);
            this.groupBox56.TabIndex = 102;
            this.groupBox56.TabStop = false;
            // 
            // radioBtnBkpFanTurnOff
            // 
            this.radioBtnBkpFanTurnOff.AutoSize = true;
            this.radioBtnBkpFanTurnOff.Location = new System.Drawing.Point(8, 39);
            this.radioBtnBkpFanTurnOff.Name = "radioBtnBkpFanTurnOff";
            this.radioBtnBkpFanTurnOff.Size = new System.Drawing.Size(47, 16);
            this.radioBtnBkpFanTurnOff.TabIndex = 63;
            this.radioBtnBkpFanTurnOff.TabStop = true;
            this.radioBtnBkpFanTurnOff.Text = "关闭";
            this.radioBtnBkpFanTurnOff.UseVisualStyleBackColor = true;
            // 
            // radioBtnBkpFanTurnOn
            // 
            this.radioBtnBkpFanTurnOn.AutoSize = true;
            this.radioBtnBkpFanTurnOn.Location = new System.Drawing.Point(8, 16);
            this.radioBtnBkpFanTurnOn.Name = "radioBtnBkpFanTurnOn";
            this.radioBtnBkpFanTurnOn.Size = new System.Drawing.Size(47, 16);
            this.radioBtnBkpFanTurnOn.TabIndex = 64;
            this.radioBtnBkpFanTurnOn.TabStop = true;
            this.radioBtnBkpFanTurnOn.Text = "开启";
            this.radioBtnBkpFanTurnOn.UseVisualStyleBackColor = true;
            // 
            // btnBkpSetFanTurnOnOff
            // 
            this.btnBkpSetFanTurnOnOff.Location = new System.Drawing.Point(104, 15);
            this.btnBkpSetFanTurnOnOff.Name = "btnBkpSetFanTurnOnOff";
            this.btnBkpSetFanTurnOnOff.Size = new System.Drawing.Size(70, 56);
            this.btnBkpSetFanTurnOnOff.TabIndex = 56;
            this.btnBkpSetFanTurnOnOff.Text = "设置";
            this.btnBkpSetFanTurnOnOff.UseVisualStyleBackColor = true;
            // 
            // groupBox49
            // 
            this.groupBox49.Controls.Add(this.groupBox58);
            this.groupBox49.Controls.Add(this.groupBox52);
            this.groupBox49.Controls.Add(this.groupBox51);
            this.groupBox49.Controls.Add(this.groupBox50);
            this.groupBox49.Controls.Add(this.btnBkpSetMultiDoPara);
            this.groupBox49.Location = new System.Drawing.Point(303, 4);
            this.groupBox49.Name = "groupBox49";
            this.groupBox49.Size = new System.Drawing.Size(196, 325);
            this.groupBox49.TabIndex = 111;
            this.groupBox49.TabStop = false;
            this.groupBox49.Text = "端子设置";
            // 
            // groupBox58
            // 
            this.groupBox58.Controls.Add(this.label342);
            this.groupBox58.Controls.Add(this.radioBtnBkpDo4LowLevel);
            this.groupBox58.Controls.Add(this.radioBtnBkpDo4HighLevel);
            this.groupBox58.Location = new System.Drawing.Point(6, 241);
            this.groupBox58.Name = "groupBox58";
            this.groupBox58.Size = new System.Drawing.Size(78, 77);
            this.groupBox58.TabIndex = 105;
            this.groupBox58.TabStop = false;
            // 
            // label342
            // 
            this.label342.AutoSize = true;
            this.label342.Location = new System.Drawing.Point(6, 12);
            this.label342.Name = "label342";
            this.label342.Size = new System.Drawing.Size(47, 12);
            this.label342.TabIndex = 69;
            this.label342.Text = "DO4控制";
            // 
            // radioBtnBkpDo4LowLevel
            // 
            this.radioBtnBkpDo4LowLevel.AutoSize = true;
            this.radioBtnBkpDo4LowLevel.Location = new System.Drawing.Point(8, 54);
            this.radioBtnBkpDo4LowLevel.Name = "radioBtnBkpDo4LowLevel";
            this.radioBtnBkpDo4LowLevel.Size = new System.Drawing.Size(59, 16);
            this.radioBtnBkpDo4LowLevel.TabIndex = 63;
            this.radioBtnBkpDo4LowLevel.TabStop = true;
            this.radioBtnBkpDo4LowLevel.Text = "低电平";
            this.radioBtnBkpDo4LowLevel.UseVisualStyleBackColor = true;
            // 
            // radioBtnBkpDo4HighLevel
            // 
            this.radioBtnBkpDo4HighLevel.AutoSize = true;
            this.radioBtnBkpDo4HighLevel.Location = new System.Drawing.Point(8, 31);
            this.radioBtnBkpDo4HighLevel.Name = "radioBtnBkpDo4HighLevel";
            this.radioBtnBkpDo4HighLevel.Size = new System.Drawing.Size(59, 16);
            this.radioBtnBkpDo4HighLevel.TabIndex = 64;
            this.radioBtnBkpDo4HighLevel.TabStop = true;
            this.radioBtnBkpDo4HighLevel.Text = "高电平";
            this.radioBtnBkpDo4HighLevel.UseVisualStyleBackColor = true;
            // 
            // groupBox52
            // 
            this.groupBox52.Controls.Add(this.label324);
            this.groupBox52.Controls.Add(this.radioBtnBkpDo3LowLevel);
            this.groupBox52.Controls.Add(this.radioBtnBkpDo3HighLevel);
            this.groupBox52.Location = new System.Drawing.Point(6, 164);
            this.groupBox52.Name = "groupBox52";
            this.groupBox52.Size = new System.Drawing.Size(78, 77);
            this.groupBox52.TabIndex = 104;
            this.groupBox52.TabStop = false;
            // 
            // label324
            // 
            this.label324.AutoSize = true;
            this.label324.Location = new System.Drawing.Point(6, 12);
            this.label324.Name = "label324";
            this.label324.Size = new System.Drawing.Size(47, 12);
            this.label324.TabIndex = 69;
            this.label324.Text = "DO3控制";
            // 
            // radioBtnBkpDo3LowLevel
            // 
            this.radioBtnBkpDo3LowLevel.AutoSize = true;
            this.radioBtnBkpDo3LowLevel.Location = new System.Drawing.Point(8, 54);
            this.radioBtnBkpDo3LowLevel.Name = "radioBtnBkpDo3LowLevel";
            this.radioBtnBkpDo3LowLevel.Size = new System.Drawing.Size(59, 16);
            this.radioBtnBkpDo3LowLevel.TabIndex = 63;
            this.radioBtnBkpDo3LowLevel.TabStop = true;
            this.radioBtnBkpDo3LowLevel.Text = "低电平";
            this.radioBtnBkpDo3LowLevel.UseVisualStyleBackColor = true;
            // 
            // radioBtnBkpDo3HighLevel
            // 
            this.radioBtnBkpDo3HighLevel.AutoSize = true;
            this.radioBtnBkpDo3HighLevel.Location = new System.Drawing.Point(8, 31);
            this.radioBtnBkpDo3HighLevel.Name = "radioBtnBkpDo3HighLevel";
            this.radioBtnBkpDo3HighLevel.Size = new System.Drawing.Size(59, 16);
            this.radioBtnBkpDo3HighLevel.TabIndex = 64;
            this.radioBtnBkpDo3HighLevel.TabStop = true;
            this.radioBtnBkpDo3HighLevel.Text = "高电平";
            this.radioBtnBkpDo3HighLevel.UseVisualStyleBackColor = true;
            // 
            // groupBox51
            // 
            this.groupBox51.Controls.Add(this.label322);
            this.groupBox51.Controls.Add(this.radioBtnBkpDo2LowLevel);
            this.groupBox51.Controls.Add(this.radioBtnBkpDo2HighLevel);
            this.groupBox51.Location = new System.Drawing.Point(6, 87);
            this.groupBox51.Name = "groupBox51";
            this.groupBox51.Size = new System.Drawing.Size(78, 77);
            this.groupBox51.TabIndex = 103;
            this.groupBox51.TabStop = false;
            // 
            // label322
            // 
            this.label322.AutoSize = true;
            this.label322.Location = new System.Drawing.Point(6, 12);
            this.label322.Name = "label322";
            this.label322.Size = new System.Drawing.Size(47, 12);
            this.label322.TabIndex = 69;
            this.label322.Text = "DO2控制";
            // 
            // radioBtnBkpDo2LowLevel
            // 
            this.radioBtnBkpDo2LowLevel.AutoSize = true;
            this.radioBtnBkpDo2LowLevel.Location = new System.Drawing.Point(8, 54);
            this.radioBtnBkpDo2LowLevel.Name = "radioBtnBkpDo2LowLevel";
            this.radioBtnBkpDo2LowLevel.Size = new System.Drawing.Size(59, 16);
            this.radioBtnBkpDo2LowLevel.TabIndex = 63;
            this.radioBtnBkpDo2LowLevel.TabStop = true;
            this.radioBtnBkpDo2LowLevel.Text = "低电平";
            this.radioBtnBkpDo2LowLevel.UseVisualStyleBackColor = true;
            // 
            // radioBtnBkpDo2HighLevel
            // 
            this.radioBtnBkpDo2HighLevel.AutoSize = true;
            this.radioBtnBkpDo2HighLevel.Location = new System.Drawing.Point(8, 31);
            this.radioBtnBkpDo2HighLevel.Name = "radioBtnBkpDo2HighLevel";
            this.radioBtnBkpDo2HighLevel.Size = new System.Drawing.Size(59, 16);
            this.radioBtnBkpDo2HighLevel.TabIndex = 64;
            this.radioBtnBkpDo2HighLevel.TabStop = true;
            this.radioBtnBkpDo2HighLevel.Text = "高电平";
            this.radioBtnBkpDo2HighLevel.UseVisualStyleBackColor = true;
            // 
            // groupBox50
            // 
            this.groupBox50.Controls.Add(this.label329);
            this.groupBox50.Controls.Add(this.radioBtnBkpDo1LowLevel);
            this.groupBox50.Controls.Add(this.radioBtnBkpDo1HighLevel);
            this.groupBox50.Location = new System.Drawing.Point(6, 10);
            this.groupBox50.Name = "groupBox50";
            this.groupBox50.Size = new System.Drawing.Size(78, 77);
            this.groupBox50.TabIndex = 102;
            this.groupBox50.TabStop = false;
            // 
            // label329
            // 
            this.label329.AutoSize = true;
            this.label329.Location = new System.Drawing.Point(6, 12);
            this.label329.Name = "label329";
            this.label329.Size = new System.Drawing.Size(47, 12);
            this.label329.TabIndex = 69;
            this.label329.Text = "DO1控制";
            // 
            // radioBtnBkpDo1LowLevel
            // 
            this.radioBtnBkpDo1LowLevel.AutoSize = true;
            this.radioBtnBkpDo1LowLevel.Location = new System.Drawing.Point(8, 54);
            this.radioBtnBkpDo1LowLevel.Name = "radioBtnBkpDo1LowLevel";
            this.radioBtnBkpDo1LowLevel.Size = new System.Drawing.Size(59, 16);
            this.radioBtnBkpDo1LowLevel.TabIndex = 63;
            this.radioBtnBkpDo1LowLevel.TabStop = true;
            this.radioBtnBkpDo1LowLevel.Text = "低电平";
            this.radioBtnBkpDo1LowLevel.UseVisualStyleBackColor = true;
            // 
            // radioBtnBkpDo1HighLevel
            // 
            this.radioBtnBkpDo1HighLevel.AutoSize = true;
            this.radioBtnBkpDo1HighLevel.Location = new System.Drawing.Point(8, 31);
            this.radioBtnBkpDo1HighLevel.Name = "radioBtnBkpDo1HighLevel";
            this.radioBtnBkpDo1HighLevel.Size = new System.Drawing.Size(59, 16);
            this.radioBtnBkpDo1HighLevel.TabIndex = 64;
            this.radioBtnBkpDo1HighLevel.TabStop = true;
            this.radioBtnBkpDo1HighLevel.Text = "高电平";
            this.radioBtnBkpDo1HighLevel.UseVisualStyleBackColor = true;
            // 
            // btnBkpSetMultiDoPara
            // 
            this.btnBkpSetMultiDoPara.Location = new System.Drawing.Point(104, 50);
            this.btnBkpSetMultiDoPara.Name = "btnBkpSetMultiDoPara";
            this.btnBkpSetMultiDoPara.Size = new System.Drawing.Size(70, 222);
            this.btnBkpSetMultiDoPara.TabIndex = 56;
            this.btnBkpSetMultiDoPara.Text = "设置";
            this.btnBkpSetMultiDoPara.UseVisualStyleBackColor = true;
            // 
            // groupBox45
            // 
            this.groupBox45.Controls.Add(this.btnGetBkpTestdata);
            this.groupBox45.Controls.Add(this.groupBox47);
            this.groupBox45.Controls.Add(this.groupBox48);
            this.groupBox45.Controls.Add(this.groupBox46);
            this.groupBox45.Controls.Add(this.groupBox44);
            this.groupBox45.Controls.Add(this.groupBox43);
            this.groupBox45.Location = new System.Drawing.Point(11, 4);
            this.groupBox45.Name = "groupBox45";
            this.groupBox45.Size = new System.Drawing.Size(288, 600);
            this.groupBox45.TabIndex = 110;
            this.groupBox45.TabStop = false;
            this.groupBox45.Text = "调试数据";
            // 
            // btnGetBkpTestdata
            // 
            this.btnGetBkpTestdata.Location = new System.Drawing.Point(192, 121);
            this.btnGetBkpTestdata.Name = "btnGetBkpTestdata";
            this.btnGetBkpTestdata.Size = new System.Drawing.Size(71, 347);
            this.btnGetBkpTestdata.TabIndex = 101;
            this.btnGetBkpTestdata.Text = "读取数据";
            this.btnGetBkpTestdata.UseVisualStyleBackColor = true;
            // 
            // groupBox47
            // 
            this.groupBox47.Controls.Add(this.label323);
            this.groupBox47.Controls.Add(this.txtBkpHardVer);
            this.groupBox47.Controls.Add(this.txtBkpPhaseNum);
            this.groupBox47.Controls.Add(this.label321);
            this.groupBox47.Location = new System.Drawing.Point(3, 539);
            this.groupBox47.Name = "groupBox47";
            this.groupBox47.Size = new System.Drawing.Size(158, 58);
            this.groupBox47.TabIndex = 102;
            this.groupBox47.TabStop = false;
            // 
            // label323
            // 
            this.label323.AutoSize = true;
            this.label323.Location = new System.Drawing.Point(6, 14);
            this.label323.Name = "label323";
            this.label323.Size = new System.Drawing.Size(65, 12);
            this.label323.TabIndex = 128;
            this.label323.Text = "硬件版本号";
            // 
            // txtBkpHardVer
            // 
            this.txtBkpHardVer.Location = new System.Drawing.Point(77, 10);
            this.txtBkpHardVer.MaxLength = 8;
            this.txtBkpHardVer.Name = "txtBkpHardVer";
            this.txtBkpHardVer.Size = new System.Drawing.Size(63, 21);
            this.txtBkpHardVer.TabIndex = 127;
            // 
            // txtBkpPhaseNum
            // 
            this.txtBkpPhaseNum.Location = new System.Drawing.Point(77, 33);
            this.txtBkpPhaseNum.MaxLength = 8;
            this.txtBkpPhaseNum.Name = "txtBkpPhaseNum";
            this.txtBkpPhaseNum.Size = new System.Drawing.Size(63, 21);
            this.txtBkpPhaseNum.TabIndex = 130;
            // 
            // label321
            // 
            this.label321.AutoSize = true;
            this.label321.Location = new System.Drawing.Point(6, 37);
            this.label321.Name = "label321";
            this.label321.Size = new System.Drawing.Size(65, 12);
            this.label321.TabIndex = 131;
            this.label321.Text = "单三相数量";
            // 
            // groupBox48
            // 
            this.groupBox48.Controls.Add(this.label317);
            this.groupBox48.Controls.Add(this.txtBkpUn2pe);
            this.groupBox48.Controls.Add(this.label319);
            this.groupBox48.Controls.Add(this.txtBkpU12v);
            this.groupBox48.Controls.Add(this.label305);
            this.groupBox48.Controls.Add(this.label303);
            this.groupBox48.Location = new System.Drawing.Point(4, 480);
            this.groupBox48.Name = "groupBox48";
            this.groupBox48.Size = new System.Drawing.Size(158, 60);
            this.groupBox48.TabIndex = 103;
            this.groupBox48.TabStop = false;
            // 
            // label317
            // 
            this.label317.AutoSize = true;
            this.label317.Location = new System.Drawing.Point(6, 15);
            this.label317.Name = "label317";
            this.label317.Size = new System.Drawing.Size(53, 12);
            this.label317.TabIndex = 122;
            this.label317.Text = "N2PE电压";
            // 
            // txtBkpUn2pe
            // 
            this.txtBkpUn2pe.Location = new System.Drawing.Point(77, 11);
            this.txtBkpUn2pe.MaxLength = 8;
            this.txtBkpUn2pe.Name = "txtBkpUn2pe";
            this.txtBkpUn2pe.Size = new System.Drawing.Size(63, 21);
            this.txtBkpUn2pe.TabIndex = 121;
            // 
            // label319
            // 
            this.label319.AutoSize = true;
            this.label319.Location = new System.Drawing.Point(142, 15);
            this.label319.Name = "label319";
            this.label319.Size = new System.Drawing.Size(11, 12);
            this.label319.TabIndex = 120;
            this.label319.Text = "V";
            // 
            // txtBkpU12v
            // 
            this.txtBkpU12v.Location = new System.Drawing.Point(77, 34);
            this.txtBkpU12v.MaxLength = 8;
            this.txtBkpU12v.Name = "txtBkpU12v";
            this.txtBkpU12v.Size = new System.Drawing.Size(63, 21);
            this.txtBkpU12v.TabIndex = 124;
            // 
            // label305
            // 
            this.label305.AutoSize = true;
            this.label305.Location = new System.Drawing.Point(141, 38);
            this.label305.Name = "label305";
            this.label305.Size = new System.Drawing.Size(11, 12);
            this.label305.TabIndex = 123;
            this.label305.Text = "V";
            // 
            // label303
            // 
            this.label303.AutoSize = true;
            this.label303.Location = new System.Drawing.Point(6, 38);
            this.label303.Name = "label303";
            this.label303.Size = new System.Drawing.Size(47, 12);
            this.label303.TabIndex = 125;
            this.label303.Text = "12V电压";
            // 
            // groupBox46
            // 
            this.groupBox46.Controls.Add(this.label310);
            this.groupBox46.Controls.Add(this.label311);
            this.groupBox46.Controls.Add(this.txtBkpBphaseUg);
            this.groupBox46.Controls.Add(this.txtBkpAphaseUg);
            this.groupBox46.Controls.Add(this.label309);
            this.groupBox46.Controls.Add(this.label308);
            this.groupBox46.Controls.Add(this.txtBkpCphaseUg);
            this.groupBox46.Controls.Add(this.label307);
            this.groupBox46.Controls.Add(this.txtBkpCphaseUout);
            this.groupBox46.Controls.Add(this.label306);
            this.groupBox46.Controls.Add(this.label313);
            this.groupBox46.Controls.Add(this.label312);
            this.groupBox46.Controls.Add(this.label292);
            this.groupBox46.Controls.Add(this.txtBkpAphaseUout);
            this.groupBox46.Controls.Add(this.label293);
            this.groupBox46.Controls.Add(this.label297);
            this.groupBox46.Controls.Add(this.txtBkpBphaseUdiff);
            this.groupBox46.Controls.Add(this.label296);
            this.groupBox46.Controls.Add(this.label298);
            this.groupBox46.Controls.Add(this.txtBkpBphaseUout);
            this.groupBox46.Controls.Add(this.label299);
            this.groupBox46.Controls.Add(this.label295);
            this.groupBox46.Controls.Add(this.txtBkpAphaseUdiff);
            this.groupBox46.Controls.Add(this.label294);
            this.groupBox46.Controls.Add(this.label300);
            this.groupBox46.Controls.Add(this.txtBkpCphaseUdiff);
            this.groupBox46.Controls.Add(this.label301);
            this.groupBox46.Location = new System.Drawing.Point(3, 113);
            this.groupBox46.Name = "groupBox46";
            this.groupBox46.Size = new System.Drawing.Size(158, 222);
            this.groupBox46.TabIndex = 102;
            this.groupBox46.TabStop = false;
            // 
            // label310
            // 
            this.label310.AutoSize = true;
            this.label310.Location = new System.Drawing.Point(6, 15);
            this.label310.Name = "label310";
            this.label310.Size = new System.Drawing.Size(71, 12);
            this.label310.TabIndex = 71;
            this.label310.Text = "A相电网电压";
            // 
            // label311
            // 
            this.label311.AutoSize = true;
            this.label311.Location = new System.Drawing.Point(143, 15);
            this.label311.Name = "label311";
            this.label311.Size = new System.Drawing.Size(11, 12);
            this.label311.TabIndex = 69;
            this.label311.Text = "V";
            // 
            // txtBkpBphaseUg
            // 
            this.txtBkpBphaseUg.Location = new System.Drawing.Point(78, 34);
            this.txtBkpBphaseUg.MaxLength = 8;
            this.txtBkpBphaseUg.Name = "txtBkpBphaseUg";
            this.txtBkpBphaseUg.Size = new System.Drawing.Size(63, 21);
            this.txtBkpBphaseUg.TabIndex = 73;
            // 
            // txtBkpAphaseUg
            // 
            this.txtBkpAphaseUg.Location = new System.Drawing.Point(77, 11);
            this.txtBkpAphaseUg.MaxLength = 8;
            this.txtBkpAphaseUg.Name = "txtBkpAphaseUg";
            this.txtBkpAphaseUg.Size = new System.Drawing.Size(63, 21);
            this.txtBkpAphaseUg.TabIndex = 70;
            // 
            // label309
            // 
            this.label309.AutoSize = true;
            this.label309.Location = new System.Drawing.Point(144, 38);
            this.label309.Name = "label309";
            this.label309.Size = new System.Drawing.Size(11, 12);
            this.label309.TabIndex = 72;
            this.label309.Text = "V";
            // 
            // label308
            // 
            this.label308.AutoSize = true;
            this.label308.Location = new System.Drawing.Point(7, 38);
            this.label308.Name = "label308";
            this.label308.Size = new System.Drawing.Size(71, 12);
            this.label308.TabIndex = 74;
            this.label308.Text = "B相电网电压";
            // 
            // txtBkpCphaseUg
            // 
            this.txtBkpCphaseUg.Location = new System.Drawing.Point(78, 57);
            this.txtBkpCphaseUg.MaxLength = 8;
            this.txtBkpCphaseUg.Name = "txtBkpCphaseUg";
            this.txtBkpCphaseUg.Size = new System.Drawing.Size(63, 21);
            this.txtBkpCphaseUg.TabIndex = 76;
            // 
            // label307
            // 
            this.label307.AutoSize = true;
            this.label307.Location = new System.Drawing.Point(144, 61);
            this.label307.Name = "label307";
            this.label307.Size = new System.Drawing.Size(11, 12);
            this.label307.TabIndex = 75;
            this.label307.Text = "V";
            // 
            // txtBkpCphaseUout
            // 
            this.txtBkpCphaseUout.Location = new System.Drawing.Point(77, 127);
            this.txtBkpCphaseUout.MaxLength = 8;
            this.txtBkpCphaseUout.Name = "txtBkpCphaseUout";
            this.txtBkpCphaseUout.Size = new System.Drawing.Size(63, 21);
            this.txtBkpCphaseUout.TabIndex = 57;
            // 
            // label306
            // 
            this.label306.AutoSize = true;
            this.label306.Location = new System.Drawing.Point(7, 61);
            this.label306.Name = "label306";
            this.label306.Size = new System.Drawing.Size(71, 12);
            this.label306.TabIndex = 77;
            this.label306.Text = "C相电网电压";
            // 
            // label313
            // 
            this.label313.AutoSize = true;
            this.label313.Location = new System.Drawing.Point(143, 131);
            this.label313.Name = "label313";
            this.label313.Size = new System.Drawing.Size(11, 12);
            this.label313.TabIndex = 57;
            this.label313.Text = "V";
            // 
            // label312
            // 
            this.label312.AutoSize = true;
            this.label312.Location = new System.Drawing.Point(6, 131);
            this.label312.Name = "label312";
            this.label312.Size = new System.Drawing.Size(71, 12);
            this.label312.TabIndex = 68;
            this.label312.Text = "C相输出电压";
            // 
            // label292
            // 
            this.label292.AutoSize = true;
            this.label292.Location = new System.Drawing.Point(7, 177);
            this.label292.Name = "label292";
            this.label292.Size = new System.Drawing.Size(71, 12);
            this.label292.TabIndex = 104;
            this.label292.Text = "B相差值电压";
            // 
            // txtBkpAphaseUout
            // 
            this.txtBkpAphaseUout.Location = new System.Drawing.Point(77, 81);
            this.txtBkpAphaseUout.MaxLength = 8;
            this.txtBkpAphaseUout.Name = "txtBkpAphaseUout";
            this.txtBkpAphaseUout.Size = new System.Drawing.Size(63, 21);
            this.txtBkpAphaseUout.TabIndex = 91;
            // 
            // label293
            // 
            this.label293.AutoSize = true;
            this.label293.Location = new System.Drawing.Point(142, 177);
            this.label293.Name = "label293";
            this.label293.Size = new System.Drawing.Size(11, 12);
            this.label293.TabIndex = 102;
            this.label293.Text = "V";
            // 
            // label297
            // 
            this.label297.AutoSize = true;
            this.label297.Location = new System.Drawing.Point(142, 85);
            this.label297.Name = "label297";
            this.label297.Size = new System.Drawing.Size(11, 12);
            this.label297.TabIndex = 90;
            this.label297.Text = "V";
            // 
            // txtBkpBphaseUdiff
            // 
            this.txtBkpBphaseUdiff.Location = new System.Drawing.Point(78, 173);
            this.txtBkpBphaseUdiff.MaxLength = 8;
            this.txtBkpBphaseUdiff.Name = "txtBkpBphaseUdiff";
            this.txtBkpBphaseUdiff.Size = new System.Drawing.Size(63, 21);
            this.txtBkpBphaseUdiff.TabIndex = 103;
            // 
            // label296
            // 
            this.label296.AutoSize = true;
            this.label296.Location = new System.Drawing.Point(6, 85);
            this.label296.Name = "label296";
            this.label296.Size = new System.Drawing.Size(71, 12);
            this.label296.TabIndex = 92;
            this.label296.Text = "A相输出电压";
            // 
            // label298
            // 
            this.label298.AutoSize = true;
            this.label298.Location = new System.Drawing.Point(7, 154);
            this.label298.Name = "label298";
            this.label298.Size = new System.Drawing.Size(71, 12);
            this.label298.TabIndex = 101;
            this.label298.Text = "A相差值电压";
            // 
            // txtBkpBphaseUout
            // 
            this.txtBkpBphaseUout.Location = new System.Drawing.Point(77, 104);
            this.txtBkpBphaseUout.MaxLength = 8;
            this.txtBkpBphaseUout.Name = "txtBkpBphaseUout";
            this.txtBkpBphaseUout.Size = new System.Drawing.Size(63, 21);
            this.txtBkpBphaseUout.TabIndex = 94;
            // 
            // label299
            // 
            this.label299.AutoSize = true;
            this.label299.Location = new System.Drawing.Point(143, 154);
            this.label299.Name = "label299";
            this.label299.Size = new System.Drawing.Size(11, 12);
            this.label299.TabIndex = 99;
            this.label299.Text = "V";
            // 
            // label295
            // 
            this.label295.AutoSize = true;
            this.label295.Location = new System.Drawing.Point(141, 108);
            this.label295.Name = "label295";
            this.label295.Size = new System.Drawing.Size(11, 12);
            this.label295.TabIndex = 93;
            this.label295.Text = "V";
            // 
            // txtBkpAphaseUdiff
            // 
            this.txtBkpAphaseUdiff.Location = new System.Drawing.Point(78, 150);
            this.txtBkpAphaseUdiff.MaxLength = 8;
            this.txtBkpAphaseUdiff.Name = "txtBkpAphaseUdiff";
            this.txtBkpAphaseUdiff.Size = new System.Drawing.Size(63, 21);
            this.txtBkpAphaseUdiff.TabIndex = 100;
            // 
            // label294
            // 
            this.label294.AutoSize = true;
            this.label294.Location = new System.Drawing.Point(6, 108);
            this.label294.Name = "label294";
            this.label294.Size = new System.Drawing.Size(71, 12);
            this.label294.TabIndex = 95;
            this.label294.Text = "B相输出电压";
            // 
            // label300
            // 
            this.label300.AutoSize = true;
            this.label300.Location = new System.Drawing.Point(7, 200);
            this.label300.Name = "label300";
            this.label300.Size = new System.Drawing.Size(71, 12);
            this.label300.TabIndex = 98;
            this.label300.Text = "C相差值电压";
            // 
            // txtBkpCphaseUdiff
            // 
            this.txtBkpCphaseUdiff.Location = new System.Drawing.Point(78, 196);
            this.txtBkpCphaseUdiff.MaxLength = 8;
            this.txtBkpCphaseUdiff.Name = "txtBkpCphaseUdiff";
            this.txtBkpCphaseUdiff.Size = new System.Drawing.Size(63, 21);
            this.txtBkpCphaseUdiff.TabIndex = 97;
            // 
            // label301
            // 
            this.label301.AutoSize = true;
            this.label301.Location = new System.Drawing.Point(144, 200);
            this.label301.Name = "label301";
            this.label301.Size = new System.Drawing.Size(11, 12);
            this.label301.TabIndex = 96;
            this.label301.Text = "V";
            // 
            // groupBox44
            // 
            this.groupBox44.Controls.Add(this.txtBkpDo4State);
            this.groupBox44.Controls.Add(this.label341);
            this.groupBox44.Controls.Add(this.label318);
            this.groupBox44.Controls.Add(this.txtBkpDo2State);
            this.groupBox44.Controls.Add(this.label320);
            this.groupBox44.Controls.Add(this.txtBkpDo1State);
            this.groupBox44.Controls.Add(this.txtBkpDI2State);
            this.groupBox44.Controls.Add(this.label316);
            this.groupBox44.Controls.Add(this.txtBkpDo3State);
            this.groupBox44.Controls.Add(this.label304);
            this.groupBox44.Controls.Add(this.txtBkpDI1State);
            this.groupBox44.Controls.Add(this.label302);
            this.groupBox44.Location = new System.Drawing.Point(4, 330);
            this.groupBox44.Name = "groupBox44";
            this.groupBox44.Size = new System.Drawing.Size(158, 151);
            this.groupBox44.TabIndex = 97;
            this.groupBox44.TabStop = false;
            // 
            // txtBkpDo4State
            // 
            this.txtBkpDo4State.Location = new System.Drawing.Point(75, 79);
            this.txtBkpDo4State.MaxLength = 8;
            this.txtBkpDo4State.Name = "txtBkpDo4State";
            this.txtBkpDo4State.Size = new System.Drawing.Size(78, 21);
            this.txtBkpDo4State.TabIndex = 120;
            // 
            // label341
            // 
            this.label341.AutoSize = true;
            this.label341.Location = new System.Drawing.Point(6, 83);
            this.label341.Name = "label341";
            this.label341.Size = new System.Drawing.Size(71, 12);
            this.label341.TabIndex = 121;
            this.label341.Text = "DO4三方光伏";
            // 
            // label318
            // 
            this.label318.AutoSize = true;
            this.label318.Location = new System.Drawing.Point(6, 15);
            this.label318.Name = "label318";
            this.label318.Size = new System.Drawing.Size(59, 12);
            this.label318.TabIndex = 110;
            this.label318.Text = "DO1发电机";
            // 
            // txtBkpDo2State
            // 
            this.txtBkpDo2State.Location = new System.Drawing.Point(76, 34);
            this.txtBkpDo2State.MaxLength = 8;
            this.txtBkpDo2State.Name = "txtBkpDo2State";
            this.txtBkpDo2State.Size = new System.Drawing.Size(77, 21);
            this.txtBkpDo2State.TabIndex = 106;
            // 
            // label320
            // 
            this.label320.AutoSize = true;
            this.label320.Location = new System.Drawing.Point(6, 38);
            this.label320.Name = "label320";
            this.label320.Size = new System.Drawing.Size(71, 12);
            this.label320.TabIndex = 107;
            this.label320.Text = "DO2三方光伏";
            // 
            // txtBkpDo1State
            // 
            this.txtBkpDo1State.Location = new System.Drawing.Point(76, 11);
            this.txtBkpDo1State.MaxLength = 8;
            this.txtBkpDo1State.Name = "txtBkpDo1State";
            this.txtBkpDo1State.Size = new System.Drawing.Size(78, 21);
            this.txtBkpDo1State.TabIndex = 109;
            // 
            // txtBkpDI2State
            // 
            this.txtBkpDI2State.Location = new System.Drawing.Point(76, 125);
            this.txtBkpDI2State.MaxLength = 8;
            this.txtBkpDI2State.Name = "txtBkpDI2State";
            this.txtBkpDI2State.Size = new System.Drawing.Size(78, 21);
            this.txtBkpDI2State.TabIndex = 112;
            // 
            // label316
            // 
            this.label316.AutoSize = true;
            this.label316.Location = new System.Drawing.Point(7, 129);
            this.label316.Name = "label316";
            this.label316.Size = new System.Drawing.Size(71, 12);
            this.label316.TabIndex = 113;
            this.label316.Text = "DI2旁路开关";
            // 
            // txtBkpDo3State
            // 
            this.txtBkpDo3State.Location = new System.Drawing.Point(76, 57);
            this.txtBkpDo3State.MaxLength = 8;
            this.txtBkpDo3State.Name = "txtBkpDo3State";
            this.txtBkpDo3State.Size = new System.Drawing.Size(78, 21);
            this.txtBkpDo3State.TabIndex = 115;
            // 
            // label304
            // 
            this.label304.AutoSize = true;
            this.label304.Location = new System.Drawing.Point(7, 61);
            this.label304.Name = "label304";
            this.label304.Size = new System.Drawing.Size(47, 12);
            this.label304.TabIndex = 116;
            this.label304.Text = "DO3负载";
            // 
            // txtBkpDI1State
            // 
            this.txtBkpDI1State.Location = new System.Drawing.Point(76, 102);
            this.txtBkpDI1State.MaxLength = 8;
            this.txtBkpDI1State.Name = "txtBkpDI1State";
            this.txtBkpDI1State.Size = new System.Drawing.Size(78, 21);
            this.txtBkpDI1State.TabIndex = 118;
            // 
            // label302
            // 
            this.label302.AutoSize = true;
            this.label302.Location = new System.Drawing.Point(7, 106);
            this.label302.Name = "label302";
            this.label302.Size = new System.Drawing.Size(47, 12);
            this.label302.TabIndex = 119;
            this.label302.Text = "DI1_ATS";
            // 
            // groupBox43
            // 
            this.groupBox43.Controls.Add(this.txtBkptTempTrans);
            this.groupBox43.Controls.Add(this.label326);
            this.groupBox43.Controls.Add(this.label327);
            this.groupBox43.Controls.Add(this.label290);
            this.groupBox43.Controls.Add(this.txtBkptTempBCrly);
            this.groupBox43.Controls.Add(this.label289);
            this.groupBox43.Controls.Add(this.label291);
            this.groupBox43.Controls.Add(this.txtBkptTempEnv);
            this.groupBox43.Controls.Add(this.txtBkptTempANrly);
            this.groupBox43.Controls.Add(this.label315);
            this.groupBox43.Controls.Add(this.label49);
            this.groupBox43.Controls.Add(this.label314);
            this.groupBox43.Location = new System.Drawing.Point(4, 10);
            this.groupBox43.Name = "groupBox43";
            this.groupBox43.Size = new System.Drawing.Size(158, 104);
            this.groupBox43.TabIndex = 96;
            this.groupBox43.TabStop = false;
            // 
            // txtBkptTempTrans
            // 
            this.txtBkptTempTrans.Location = new System.Drawing.Point(80, 78);
            this.txtBkptTempTrans.MaxLength = 8;
            this.txtBkptTempTrans.Name = "txtBkptTempTrans";
            this.txtBkptTempTrans.Size = new System.Drawing.Size(60, 21);
            this.txtBkptTempTrans.TabIndex = 76;
            // 
            // label326
            // 
            this.label326.AutoSize = true;
            this.label326.Location = new System.Drawing.Point(140, 83);
            this.label326.Name = "label326";
            this.label326.Size = new System.Drawing.Size(17, 12);
            this.label326.TabIndex = 75;
            this.label326.Text = "℃";
            // 
            // label327
            // 
            this.label327.AutoSize = true;
            this.label327.Location = new System.Drawing.Point(6, 83);
            this.label327.Name = "label327";
            this.label327.Size = new System.Drawing.Size(65, 12);
            this.label327.TabIndex = 77;
            this.label327.Text = "变压器温度";
            // 
            // label290
            // 
            this.label290.AutoSize = true;
            this.label290.Location = new System.Drawing.Point(6, 16);
            this.label290.Name = "label290";
            this.label290.Size = new System.Drawing.Size(71, 12);
            this.label290.TabIndex = 68;
            this.label290.Text = "继电器A温度";
            // 
            // txtBkptTempBCrly
            // 
            this.txtBkptTempBCrly.Location = new System.Drawing.Point(80, 34);
            this.txtBkptTempBCrly.MaxLength = 8;
            this.txtBkptTempBCrly.Name = "txtBkptTempBCrly";
            this.txtBkptTempBCrly.Size = new System.Drawing.Size(60, 21);
            this.txtBkptTempBCrly.TabIndex = 70;
            // 
            // label289
            // 
            this.label289.AutoSize = true;
            this.label289.Location = new System.Drawing.Point(140, 39);
            this.label289.Name = "label289";
            this.label289.Size = new System.Drawing.Size(17, 12);
            this.label289.TabIndex = 69;
            this.label289.Text = "℃";
            // 
            // label291
            // 
            this.label291.AutoSize = true;
            this.label291.Location = new System.Drawing.Point(140, 16);
            this.label291.Name = "label291";
            this.label291.Size = new System.Drawing.Size(17, 12);
            this.label291.TabIndex = 57;
            this.label291.Text = "℃";
            // 
            // txtBkptTempEnv
            // 
            this.txtBkptTempEnv.Location = new System.Drawing.Point(59, 56);
            this.txtBkptTempEnv.MaxLength = 8;
            this.txtBkptTempEnv.Name = "txtBkptTempEnv";
            this.txtBkptTempEnv.Size = new System.Drawing.Size(81, 21);
            this.txtBkptTempEnv.TabIndex = 73;
            // 
            // txtBkptTempANrly
            // 
            this.txtBkptTempANrly.Location = new System.Drawing.Point(80, 12);
            this.txtBkptTempANrly.MaxLength = 8;
            this.txtBkptTempANrly.Name = "txtBkptTempANrly";
            this.txtBkptTempANrly.Size = new System.Drawing.Size(61, 21);
            this.txtBkptTempANrly.TabIndex = 57;
            // 
            // label315
            // 
            this.label315.AutoSize = true;
            this.label315.Location = new System.Drawing.Point(140, 60);
            this.label315.Name = "label315";
            this.label315.Size = new System.Drawing.Size(17, 12);
            this.label315.TabIndex = 72;
            this.label315.Text = "℃";
            // 
            // label49
            // 
            this.label49.AutoSize = true;
            this.label49.Location = new System.Drawing.Point(6, 39);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(77, 12);
            this.label49.TabIndex = 71;
            this.label49.Text = "继电器BC温度";
            // 
            // label314
            // 
            this.label314.AutoSize = true;
            this.label314.Location = new System.Drawing.Point(6, 60);
            this.label314.Name = "label314";
            this.label314.Size = new System.Drawing.Size(53, 12);
            this.label314.TabIndex = 74;
            this.label314.Text = "环境温度";
            // 
            // tabPage10
            // 
            this.tabPage10.Controls.Add(this.tableLayoutPanel1);
            this.tabPage10.Location = new System.Drawing.Point(4, 22);
            this.tabPage10.Name = "tabPage10";
            this.tabPage10.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage10.Size = new System.Drawing.Size(716, 739);
            this.tabPage10.TabIndex = 7;
            this.tabPage10.Text = "变量读写工具";
            this.tabPage10.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox60, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupBox61, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox66, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 356F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(710, 733);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // groupBox60
            // 
            this.groupBox60.Controls.Add(this.dataGridView1);
            this.groupBox60.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox60.Location = new System.Drawing.Point(3, 83);
            this.groupBox60.Name = "groupBox60";
            this.groupBox60.Size = new System.Drawing.Size(704, 291);
            this.groupBox60.TabIndex = 0;
            this.groupBox60.TabStop = false;
            this.groupBox60.Text = "变量显示";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.VarName,
            this.VarAddr,
            this.VarType,
            this.ReadValue,
            this.WriteValue,
            this.VarSelect});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 17);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(698, 271);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
            // 
            // VarName
            // 
            this.VarName.HeaderText = "变量名";
            this.VarName.Name = "VarName";
            this.VarName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.VarName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // VarAddr
            // 
            this.VarAddr.HeaderText = "地址";
            this.VarAddr.Name = "VarAddr";
            // 
            // VarType
            // 
            this.VarType.HeaderText = "类型";
            this.VarType.Items.AddRange(new object[] {
            "Int16",
            "Uint16",
            "Int32",
            "Uint32",
            "Float"});
            this.VarType.Name = "VarType";
            // 
            // ReadValue
            // 
            this.ReadValue.HeaderText = "读取值";
            this.ReadValue.Name = "ReadValue";
            this.ReadValue.ReadOnly = true;
            this.ReadValue.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ReadValue.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // WriteValue
            // 
            this.WriteValue.HeaderText = "写入值";
            this.WriteValue.Name = "WriteValue";
            // 
            // VarSelect
            // 
            this.VarSelect.HeaderText = "选中写";
            this.VarSelect.Name = "VarSelect";
            // 
            // groupBox61
            // 
            this.groupBox61.Controls.Add(this.btnClearVars);
            this.groupBox61.Controls.Add(this.btnSetVarParam);
            this.groupBox61.Controls.Add(this.btnVarSelect);
            this.groupBox61.Controls.Add(this.button1);
            this.groupBox61.Controls.Add(this.rdioBtnDaqRead);
            this.groupBox61.Controls.Add(this.rdioBtnPollingRead);
            this.groupBox61.Controls.Add(this.rdioBtnReadSingle);
            this.groupBox61.Controls.Add(this.label344);
            this.groupBox61.Controls.Add(this.textBoxReadPeriod);
            this.groupBox61.Controls.Add(this.btnReadVar);
            this.groupBox61.Controls.Add(this.textBoxMapDir);
            this.groupBox61.Controls.Add(this.label343);
            this.groupBox61.Controls.Add(this.btnOpenMap);
            this.groupBox61.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox61.Location = new System.Drawing.Point(3, 3);
            this.groupBox61.Name = "groupBox61";
            this.groupBox61.Size = new System.Drawing.Size(704, 74);
            this.groupBox61.TabIndex = 1;
            this.groupBox61.TabStop = false;
            this.groupBox61.Text = "设置";
            // 
            // btnClearVars
            // 
            this.btnClearVars.Location = new System.Drawing.Point(508, 41);
            this.btnClearVars.Name = "btnClearVars";
            this.btnClearVars.Size = new System.Drawing.Size(62, 23);
            this.btnClearVars.TabIndex = 70;
            this.btnClearVars.Text = "清空变量";
            this.btnClearVars.UseVisualStyleBackColor = true;
            // 
            // btnSetVarParam
            // 
            this.btnSetVarParam.Location = new System.Drawing.Point(378, 41);
            this.btnSetVarParam.Name = "btnSetVarParam";
            this.btnSetVarParam.Size = new System.Drawing.Size(62, 23);
            this.btnSetVarParam.TabIndex = 69;
            this.btnSetVarParam.Text = "配置";
            this.btnSetVarParam.UseVisualStyleBackColor = true;
            // 
            // btnVarSelect
            // 
            this.btnVarSelect.Location = new System.Drawing.Point(232, 43);
            this.btnVarSelect.Name = "btnVarSelect";
            this.btnVarSelect.Size = new System.Drawing.Size(62, 23);
            this.btnVarSelect.TabIndex = 68;
            this.btnVarSelect.Text = "添加";
            this.btnVarSelect.UseVisualStyleBackColor = true;
            this.btnVarSelect.Click += new System.EventHandler(this.btnVarSelect_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(636, 43);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(62, 23);
            this.button1.TabIndex = 67;
            this.button1.Text = "写入";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            // 
            // rdioBtnDaqRead
            // 
            this.rdioBtnDaqRead.AutoSize = true;
            this.rdioBtnDaqRead.Location = new System.Drawing.Point(574, 15);
            this.rdioBtnDaqRead.Name = "rdioBtnDaqRead";
            this.rdioBtnDaqRead.Size = new System.Drawing.Size(59, 16);
            this.rdioBtnDaqRead.TabIndex = 66;
            this.rdioBtnDaqRead.TabStop = true;
            this.rdioBtnDaqRead.Text = "主动报";
            this.rdioBtnDaqRead.UseVisualStyleBackColor = true;
            this.rdioBtnDaqRead.Visible = false;
            // 
            // rdioBtnPollingRead
            // 
            this.rdioBtnPollingRead.AutoSize = true;
            this.rdioBtnPollingRead.Location = new System.Drawing.Point(511, 15);
            this.rdioBtnPollingRead.Name = "rdioBtnPollingRead";
            this.rdioBtnPollingRead.Size = new System.Drawing.Size(59, 16);
            this.rdioBtnPollingRead.TabIndex = 65;
            this.rdioBtnPollingRead.TabStop = true;
            this.rdioBtnPollingRead.Text = "定时查";
            this.rdioBtnPollingRead.UseVisualStyleBackColor = true;
            // 
            // rdioBtnReadSingle
            // 
            this.rdioBtnReadSingle.AutoSize = true;
            this.rdioBtnReadSingle.Location = new System.Drawing.Point(445, 15);
            this.rdioBtnReadSingle.Name = "rdioBtnReadSingle";
            this.rdioBtnReadSingle.Size = new System.Drawing.Size(59, 16);
            this.rdioBtnReadSingle.TabIndex = 64;
            this.rdioBtnReadSingle.TabStop = true;
            this.rdioBtnReadSingle.Text = "单次读";
            this.rdioBtnReadSingle.UseVisualStyleBackColor = true;
            // 
            // label344
            // 
            this.label344.AutoSize = true;
            this.label344.Location = new System.Drawing.Point(300, 19);
            this.label344.Name = "label344";
            this.label344.Size = new System.Drawing.Size(65, 12);
            this.label344.TabIndex = 63;
            this.label344.Text = "周期（us）";
            // 
            // textBoxReadPeriod
            // 
            this.textBoxReadPeriod.Location = new System.Drawing.Point(361, 13);
            this.textBoxReadPeriod.Name = "textBoxReadPeriod";
            this.textBoxReadPeriod.Size = new System.Drawing.Size(79, 21);
            this.textBoxReadPeriod.TabIndex = 61;
            // 
            // btnReadVar
            // 
            this.btnReadVar.Location = new System.Drawing.Point(636, 12);
            this.btnReadVar.Name = "btnReadVar";
            this.btnReadVar.Size = new System.Drawing.Size(62, 23);
            this.btnReadVar.TabIndex = 60;
            this.btnReadVar.Text = "读取";
            this.btnReadVar.UseVisualStyleBackColor = true;
            // 
            // textBoxMapDir
            // 
            this.textBoxMapDir.Location = new System.Drawing.Point(83, 16);
            this.textBoxMapDir.Name = "textBoxMapDir";
            this.textBoxMapDir.Size = new System.Drawing.Size(141, 21);
            this.textBoxMapDir.TabIndex = 57;
            // 
            // label343
            // 
            this.label343.AutoSize = true;
            this.label343.Location = new System.Drawing.Point(6, 19);
            this.label343.Name = "label343";
            this.label343.Size = new System.Drawing.Size(71, 12);
            this.label343.TabIndex = 58;
            this.label343.Text = "map文件路径";
            // 
            // btnOpenMap
            // 
            this.btnOpenMap.Location = new System.Drawing.Point(232, 14);
            this.btnOpenMap.Name = "btnOpenMap";
            this.btnOpenMap.Size = new System.Drawing.Size(62, 23);
            this.btnOpenMap.TabIndex = 59;
            this.btnOpenMap.Text = "浏览";
            this.btnOpenMap.UseVisualStyleBackColor = true;
            // 
            // groupBox66
            // 
            this.groupBox66.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox66.Location = new System.Drawing.Point(3, 380);
            this.groupBox66.Name = "groupBox66";
            this.groupBox66.Size = new System.Drawing.Size(704, 350);
            this.groupBox66.TabIndex = 2;
            this.groupBox66.TabStop = false;
            this.groupBox66.Text = "groupBox66";
            // 
            // timerAnalogMonit
            // 
            this.timerAnalogMonit.Enabled = true;
            this.timerAnalogMonit.Interval = 1000;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1193, 765);
            this.Controls.Add(this.tabControl2);
            this.Controls.Add(this.groupBox1);
            this.Name = "MainForm";
            this.Text = "BigPcsDebugerV1.2_tmp";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox55.ResumeLayout(false);
            this.groupBox55.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBoxUartCfg.ResumeLayout(false);
            this.groupBoxUartCfg.PerformLayout();
            this.groupBoxPlcDstCfg.ResumeLayout(false);
            this.groupBoxPlcDstCfg.PerformLayout();
            this.groupBoxPlcTstBrdCfg.ResumeLayout(false);
            this.groupBoxPlcTstBrdCfg.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.groupBoxCanSendCfg.ResumeLayout(false);
            this.groupBoxCanSendCfg.PerformLayout();
            this.groupBoxCanCfg.ResumeLayout(false);
            this.groupBoxCanCfg.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox23.ResumeLayout(false);
            this.groupBox23.PerformLayout();
            this.groupBox16.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.tabControl2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.groupBox63.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.groupBox62.ResumeLayout(false);
            this.tableLayoutPanel8.ResumeLayout(false);
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTrigPos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDnVrtZoomCh1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDnVrtZoomCh2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDnVrtZoomCh3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDnVrtZoomCh4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDnVrtOffsetCh1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDnVrtOffsetCh2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDnVrtOffsetCh3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDnVrtOffsetCh4)).EndInit();
            this.tableLayoutPanel9.ResumeLayout(false);
            this.tableLayoutPanel9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDnSampleFreqOrigin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDnSampleDiv)).EndInit();
            this.groupBox54.ResumeLayout(false);
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textBoxCh1TrigVal)).EndInit();
            this.tableLayoutPanel10.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.WaveChart)).EndInit();
            this.tableLayoutPanel11.ResumeLayout(false);
            this.groupBox67.ResumeLayout(false);
            this.tableLayoutPanel14.ResumeLayout(false);
            this.tableLayoutPanel14.PerformLayout();
            this.groupBox68.ResumeLayout(false);
            this.groupBox68.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.groupBox9.ResumeLayout(false);
            this.groupBox59.ResumeLayout(false);
            this.groupBox59.PerformLayout();
            this.groupBox40.ResumeLayout(false);
            this.groupBox40.PerformLayout();
            this.groupBox34.ResumeLayout(false);
            this.groupBox14.ResumeLayout(false);
            this.groupBox14.PerformLayout();
            this.groupBox26.ResumeLayout(false);
            this.groupBox26.PerformLayout();
            this.SSS.ResumeLayout(false);
            this.SSS.PerformLayout();
            this.groupBox22.ResumeLayout(false);
            this.groupBox22.PerformLayout();
            this.groupBox19.ResumeLayout(false);
            this.groupBox19.PerformLayout();
            this.groupBox18.ResumeLayout(false);
            this.groupBox18.PerformLayout();
            this.groupBox17.ResumeLayout(false);
            this.groupBox17.PerformLayout();
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.groupBox12.ResumeLayout(false);
            this.groupBox12.PerformLayout();
            this.groupBox15.ResumeLayout(false);
            this.groupBox15.PerformLayout();
            this.groupBox20.ResumeLayout(false);
            this.groupBox20.PerformLayout();
            this.groupBox21.ResumeLayout(false);
            this.groupBox21.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabPage6.ResumeLayout(false);
            this.groupBox25.ResumeLayout(false);
            this.groupBox25.PerformLayout();
            this.tabPage7.ResumeLayout(false);
            this.groupBox37.ResumeLayout(false);
            this.groupBox37.PerformLayout();
            this.groupBox35.ResumeLayout(false);
            this.groupBox35.PerformLayout();
            this.groupBox38.ResumeLayout(false);
            this.groupBox38.PerformLayout();
            this.groupBox31.ResumeLayout(false);
            this.groupBox27.ResumeLayout(false);
            this.groupBox27.PerformLayout();
            this.groupBox13.ResumeLayout(false);
            this.groupBox32.ResumeLayout(false);
            this.groupBox32.PerformLayout();
            this.groupBox29.ResumeLayout(false);
            this.groupBox29.PerformLayout();
            this.groupBox28.ResumeLayout(false);
            this.groupBox28.PerformLayout();
            this.groupBox30.ResumeLayout(false);
            this.groupBox30.PerformLayout();
            this.tabPage8.ResumeLayout(false);
            this.groupBox39.ResumeLayout(false);
            this.groupBox39.PerformLayout();
            this.groupBox36.ResumeLayout(false);
            this.groupBox36.PerformLayout();
            this.groupBox24.ResumeLayout(false);
            this.groupBox42.ResumeLayout(false);
            this.groupBox41.ResumeLayout(false);
            this.groupBox41.PerformLayout();
            this.groupBox33.ResumeLayout(false);
            this.groupBox33.PerformLayout();
            this.groupBox11.ResumeLayout(false);
            this.tabPage9.ResumeLayout(false);
            this.groupBox57.ResumeLayout(false);
            this.groupBox57.PerformLayout();
            this.groupBox53.ResumeLayout(false);
            this.groupBox56.ResumeLayout(false);
            this.groupBox56.PerformLayout();
            this.groupBox49.ResumeLayout(false);
            this.groupBox58.ResumeLayout(false);
            this.groupBox58.PerformLayout();
            this.groupBox52.ResumeLayout(false);
            this.groupBox52.PerformLayout();
            this.groupBox51.ResumeLayout(false);
            this.groupBox51.PerformLayout();
            this.groupBox50.ResumeLayout(false);
            this.groupBox50.PerformLayout();
            this.groupBox45.ResumeLayout(false);
            this.groupBox47.ResumeLayout(false);
            this.groupBox47.PerformLayout();
            this.groupBox48.ResumeLayout(false);
            this.groupBox48.PerformLayout();
            this.groupBox46.ResumeLayout(false);
            this.groupBox46.PerformLayout();
            this.groupBox44.ResumeLayout(false);
            this.groupBox44.PerformLayout();
            this.groupBox43.ResumeLayout(false);
            this.groupBox43.PerformLayout();
            this.tabPage10.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox60.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox61.ResumeLayout(false);
            this.groupBox61.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbPortName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbBaudRate;
        private System.Windows.Forms.Button button_Scan;
        private System.Windows.Forms.Button btnOpenClose;
        private System.Windows.Forms.GroupBox groupBoxPlcTstBrdCfg;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPanId;
        private System.Windows.Forms.Button btnCpx4Init;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtTxScale;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbBandPlan;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.RadioButton radioBtnCommUartMode;
        private System.Windows.Forms.RadioButton radioBtnCommPlcMode;
        private System.Windows.Forms.RadioButton radioBtnCommCanMode;
        private System.Windows.Forms.GroupBox groupBoxCanCfg;
        private System.Windows.Forms.Label label_endid;
        private System.Windows.Forms.TextBox textBox_endid;
        private System.Windows.Forms.Button button_close;
        private System.Windows.Forms.ComboBox comboBox_index;
        private System.Windows.Forms.Label label_startid;
        private System.Windows.Forms.Label label_index;
        private System.Windows.Forms.Button button_reset;
        private System.Windows.Forms.ComboBox comboBox_device;
        private System.Windows.Forms.Label label_device;
        private System.Windows.Forms.Button button_init;
        private System.Windows.Forms.Button button_start;
        private System.Windows.Forms.TextBox textBox_startid;
        private System.Windows.Forms.ComboBox comboBox_standard2;
        private System.Windows.Forms.Label label_standard2;
        private System.Windows.Forms.Button button_open;
        private System.Windows.Forms.ComboBox comboBox_ABIT2;
        private System.Windows.Forms.Label label_ABIT2;
        private System.Windows.Forms.ComboBox comboBox_ABIT;
        private System.Windows.Forms.Label label_ABIT;
        private System.Windows.Forms.ComboBox comboBox_mode;
        private System.Windows.Forms.Label label_mode;
        private System.Windows.Forms.ComboBox comboBox_standard;
        private System.Windows.Forms.Label label_standard;
        private System.Windows.Forms.RadioButton radioBtnComm485Mode;
        private System.Windows.Forms.GroupBox groupBoxPlcDstCfg;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.TextBox txtBoxDstPanId;
        private System.Windows.Forms.TextBox txtBoxDstAddr;
        private System.Windows.Forms.Label label_channel;
        private System.Windows.Forms.ComboBox comboBox_channel;
        private System.Windows.Forms.ComboBox comboBox_frametype;
        private System.Windows.Forms.Label label_frametype;
        private System.Windows.Forms.TextBox textBox_ID;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.GroupBox groupBoxUartCfg;
        private System.Windows.Forms.GroupBox groupBoxCanSendCfg;
        private System.Windows.Forms.Label label_protocol;
        private System.Windows.Forms.ComboBox comboBox_protocol;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSwitchLoaderOrLoadee;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.Button btnFindFile;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnEnterBackDoor;
        private System.Windows.Forms.Button btnJumpApp;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnLoadFileStart;
        private System.Windows.Forms.Button btnActiveApp;
        private System.Windows.Forms.Button btnLoadFileConsult;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label txtInvSoftVersion;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cmbFileType;
        private System.Windows.Forms.Label labDeviceType;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label labSlideFrameNum;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label labFrameDatLen;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label labelProgress;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ProgressBar progBarUpload;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox textBoxCanIDSrcAddr;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox textBoxCanIdDestAddr;
        private System.Windows.Forms.CheckBox checkBoxIsUseCanId;
        private System.Windows.Forms.GroupBox groupBox16;
        private System.Windows.Forms.RadioButton radioBtnConnectObjectPCS_B;
        private System.Windows.Forms.RadioButton radioBtnConnectObjectPCS_A;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.RadioButton radioBtnSouthDevProto;
        private System.Windows.Forms.Button btnSelectProtoType;
        private System.Windows.Forms.RadioButton radioBtnCmdProto;
        private System.Windows.Forms.RadioButton radioBtnModbusProto;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button btnGenWriteCmd;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox comboBoxDecHex;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox textBoxCmdData;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox textBoxCmd;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TabPage tabPage7;
        private System.Windows.Forms.Timer timerAnalogMonit;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.GroupBox groupBox34;
        private System.Windows.Forms.ComboBox comboHeatFilmPwrSup;
        private System.Windows.Forms.Button btnGetHeatFilmPwrSup;
        private System.Windows.Forms.Button btnSetHeatFilmPwrSup;
        private System.Windows.Forms.GroupBox groupBox14;
        private System.Windows.Forms.Label label85;
        private System.Windows.Forms.TextBox textBoxCAlarm2;
        private System.Windows.Forms.TextBox textBoxCAlarm1;
        private System.Windows.Forms.Label label86;
        private System.Windows.Forms.Label label87;
        private System.Windows.Forms.Label label82;
        private System.Windows.Forms.TextBox textBoxBAlarm2;
        private System.Windows.Forms.TextBox textBoxBAlarm1;
        private System.Windows.Forms.Label label83;
        private System.Windows.Forms.Label label84;
        private System.Windows.Forms.Label label81;
        private System.Windows.Forms.TextBox textBoxAAlarm2;
        private System.Windows.Forms.TextBox textBoxAAlarm1;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.Button btnReadAlarm;
        private System.Windows.Forms.Button btnReadStatus;
        private System.Windows.Forms.GroupBox groupBox26;
        private System.Windows.Forms.Label label60;
        private System.Windows.Forms.ComboBox comboBoxParticularPara;
        private System.Windows.Forms.TextBox textBoxPartiParaValue;
        private System.Windows.Forms.Button btnGetParticularPara;
        private System.Windows.Forms.Button btnSetParticularPara;
        private System.Windows.Forms.GroupBox SSS;
        private System.Windows.Forms.Label label74;
        private System.Windows.Forms.TextBox txtCFsmStatus;
        private System.Windows.Forms.Label label75;
        private System.Windows.Forms.Label labelCShutDownStep;
        private System.Windows.Forms.Label labelCRunStep;
        private System.Windows.Forms.Label labelCStartStep;
        private System.Windows.Forms.Label labelCIdleStep;
        private System.Windows.Forms.Label lableCInitStep;
        private System.Windows.Forms.Label label67;
        private System.Windows.Forms.TextBox txtBFsmStatus;
        private System.Windows.Forms.Label label68;
        private System.Windows.Forms.Label labelBShutDownStep;
        private System.Windows.Forms.Label labelBRunStep;
        private System.Windows.Forms.Label labelBStartStep;
        private System.Windows.Forms.Label labelBIdleStep;
        private System.Windows.Forms.Label lableBInitStep;
        private System.Windows.Forms.Label label58;
        private System.Windows.Forms.TextBox txtAFsmStatus;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label labelAShutDownStep;
        private System.Windows.Forms.Label labelARunStep;
        private System.Windows.Forms.Label labelAStartStep;
        private System.Windows.Forms.Label labelAIdleStep;
        private System.Windows.Forms.Label lableAInitStep;
        private System.Windows.Forms.GroupBox groupBox22;
        private System.Windows.Forms.TextBox textBoxCfg_Q_CTRL_PF;
        private System.Windows.Forms.Button btnCfg_Q_CTRL_PF_R;
        private System.Windows.Forms.Button btnCfg_Q_CTRL_PF_W;
        private System.Windows.Forms.GroupBox groupBox19;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.TextBox txtCSecTemp;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.TextBox txtCPriTemp;
        private System.Windows.Forms.GroupBox groupBox18;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox txtBSecTemp;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox txtBPriTemp;
        private System.Windows.Forms.GroupBox groupBox17;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.TextBox txtASecTemp;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.TextBox txtAPriTemp;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.Label label46;
        private System.Windows.Forms.TextBox textBoxActivePower;
        private System.Windows.Forms.Button btnGetActivePower;
        private System.Windows.Forms.GroupBox groupBox12;
        private System.Windows.Forms.Button btnGetInvMode;
        private System.Windows.Forms.Button btnSetInvMode;
        private System.Windows.Forms.RadioButton radioButtonOffGrid;
        private System.Windows.Forms.RadioButton radioButtonOnGrid;
        private System.Windows.Forms.GroupBox groupBox15;
        private System.Windows.Forms.Label label48;
        private System.Windows.Forms.TextBox textBoxChgDisChgLimitPower;
        private System.Windows.Forms.Button btnGetChgDisChgLimitPower;
        private System.Windows.Forms.Button btnSetChgDisChgLimitPower;
        private System.Windows.Forms.Button btnGetPcsTemp;
        private System.Windows.Forms.GroupBox groupBox20;
        private System.Windows.Forms.Button btnGetTurnOnOff;
        private System.Windows.Forms.Button btnSetTurnOnOff;
        private System.Windows.Forms.RadioButton radioButtonTurnOff;
        private System.Windows.Forms.RadioButton radioButtonTurnOn;
        private System.Windows.Forms.GroupBox groupBox21;
        private System.Windows.Forms.RadioButton radioButtonRunStateErrStop;
        private System.Windows.Forms.Button btnGetRunState;
        private System.Windows.Forms.RadioButton radioButtonRunStateSleep;
        private System.Windows.Forms.RadioButton radioButtonRunStateStandby;
        private System.Windows.Forms.RadioButton radioButtonRunStateRun;
        private System.Windows.Forms.RadioButton radioButtonRunStateStop;
        private System.Windows.Forms.GroupBox groupBox25;
        private System.Windows.Forms.Label labelExportProgress;
        private System.Windows.Forms.ProgressBar progressBarExport;
        private System.Windows.Forms.Label label61;
        private System.Windows.Forms.Label label62;
        private System.Windows.Forms.Label labFileInfo;
        private System.Windows.Forms.Label label63;
        private System.Windows.Forms.CheckBox chkboxPrintOriginLog;
        private System.Windows.Forms.Label label64;
        private System.Windows.Forms.Button btnSwitchExporterOrExportee;
        private System.Windows.Forms.TextBox txtLogFilePath;
        private System.Windows.Forms.Label label65;
        private System.Windows.Forms.Button btnExportEnd;
        private System.Windows.Forms.Button btnFindLogFile;
        private System.Windows.Forms.Button btnExportFileSaveAs;
        private System.Windows.Forms.TextBox textBoxExport;
        private System.Windows.Forms.Button btnExportConsult;
        private System.Windows.Forms.Button btnExportStart;
        private System.Windows.Forms.GroupBox groupBox23;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Label label72;
        private System.Windows.Forms.Label label71;
        private System.Windows.Forms.Button btnCalculateCrc;
        private System.Windows.Forms.TextBox tbCrcResult;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox tbData2Crc;
        private System.Windows.Forms.TextBox txtSendData;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label labelCPcsSoftwareVer;
        private System.Windows.Forms.Label labelBPcsSoftwareVer;
        private System.Windows.Forms.Label labelAPcsSoftwareVer;
        private System.Windows.Forms.Button btnGetPcsSoftwareVer;
        private System.Windows.Forms.Label label57;
        private System.Windows.Forms.TextBox txtReceivedData;
        private System.Windows.Forms.TabPage tabPage8;
        private System.Windows.Forms.GroupBox groupBox24;
        private System.Windows.Forms.GroupBox groupBox33;
        private System.Windows.Forms.Label label165;
        private System.Windows.Forms.Label label164;
        private System.Windows.Forms.TextBox textBoxBmsCPhaseChgDisChgPower;
        private System.Windows.Forms.Label label163;
        private System.Windows.Forms.TextBox textBoxBmsBPhaseChgDisChgPower;
        private System.Windows.Forms.Label label162;
        private System.Windows.Forms.TextBox textBoxBmsAPhaseChgDisChgPower;
        private System.Windows.Forms.Button btnBmsSetThreeChapseChgDischgCmd;
        private System.Windows.Forms.GroupBox groupBox11;
        private System.Windows.Forms.Button btnBmsTurnOffCmd;
        private System.Windows.Forms.Button btnBmsResetCmd;
        private System.Windows.Forms.Button btnBmsTurnOnCmd;
        private System.Windows.Forms.Label label59;
        private System.Windows.Forms.ComboBox comboLogSubfileType;
        private System.Windows.Forms.Label label66;
        private System.Windows.Forms.ComboBox cmbFileTypeExport;
        private System.Windows.Forms.GroupBox groupBox39;
        private System.Windows.Forms.Button btnBmsResetCalibratorParaCmd;
        private System.Windows.Forms.Label label279;
        private System.Windows.Forms.Label label262;
        private System.Windows.Forms.Label label261;
        private System.Windows.Forms.Label label260;
        private System.Windows.Forms.Label label259;
        private System.Windows.Forms.Label label258;
        private System.Windows.Forms.Label label257;
        private System.Windows.Forms.Label label256;
        private System.Windows.Forms.Label label235;
        private System.Windows.Forms.Label label250;
        private System.Windows.Forms.TextBox txtBmsDischgCurr4_Z4;
        private System.Windows.Forms.Label label251;
        private System.Windows.Forms.TextBox txtBmsDischgCurr3_Z3;
        private System.Windows.Forms.Label label252;
        private System.Windows.Forms.TextBox txtBmsDischgCurr2_Z2;
        private System.Windows.Forms.Label label253;
        private System.Windows.Forms.TextBox txtBmsDischgCurr1_Z1;
        private System.Windows.Forms.Label label254;
        private System.Windows.Forms.TextBox txtBmsChgCurr4_Z4;
        private System.Windows.Forms.Label label255;
        private System.Windows.Forms.TextBox txtBmsChgCurr3_Z3;
        private System.Windows.Forms.Button btnBmsReadCalibratorParaCmd;
        private System.Windows.Forms.Label label229;
        private System.Windows.Forms.TextBox txtBmsCalibratorParaDischgB1;
        private System.Windows.Forms.Label label231;
        private System.Windows.Forms.TextBox txtBmsCalibratorParaDischgK1;
        private System.Windows.Forms.Label label233;
        private System.Windows.Forms.TextBox txtBmsChgCurr2_Z2;
        private System.Windows.Forms.TextBox txtBmsChgCurr1_Z1;
        private System.Windows.Forms.Label label237;
        private System.Windows.Forms.TextBox txtBmsCalibratorParaDischgB3;
        private System.Windows.Forms.Label label239;
        private System.Windows.Forms.TextBox txtBmsCalibratorParaDischgK3;
        private System.Windows.Forms.Label label240;
        private System.Windows.Forms.TextBox txtBmsCalibratorParaDischgB2;
        private System.Windows.Forms.Label label241;
        private System.Windows.Forms.TextBox txtBmsCalibratorParaDischgK2;
        private System.Windows.Forms.Label label242;
        private System.Windows.Forms.TextBox txtBmsCalibratorParaChgB0;
        private System.Windows.Forms.Label label243;
        private System.Windows.Forms.TextBox txtBmsCalibratorParaChgK0;
        private System.Windows.Forms.Label label244;
        private System.Windows.Forms.TextBox txtBmsCalibratorParaChgB3;
        private System.Windows.Forms.Label label245;
        private System.Windows.Forms.TextBox txtBmsCalibratorParaChgK3;
        private System.Windows.Forms.Label label246;
        private System.Windows.Forms.TextBox txtBmsCalibratorParaChgB2;
        private System.Windows.Forms.Label label247;
        private System.Windows.Forms.TextBox txtBmsCalibratorParaChgK2;
        private System.Windows.Forms.Label label248;
        private System.Windows.Forms.TextBox txtBmsCalibratorParaChgB1;
        private System.Windows.Forms.Label label249;
        private System.Windows.Forms.TextBox txtBmsCalibratorParaChgK1;
        private System.Windows.Forms.GroupBox groupBox36;
        private System.Windows.Forms.Label label271;
        private System.Windows.Forms.Label label272;
        private System.Windows.Forms.Label label273;
        private System.Windows.Forms.Label label274;
        private System.Windows.Forms.Label label275;
        private System.Windows.Forms.Label label276;
        private System.Windows.Forms.Label label277;
        private System.Windows.Forms.Label label278;
        private System.Windows.Forms.Label label263;
        private System.Windows.Forms.Label label264;
        private System.Windows.Forms.Label label265;
        private System.Windows.Forms.Label label266;
        private System.Windows.Forms.Label label267;
        private System.Windows.Forms.Label label268;
        private System.Windows.Forms.Label label269;
        private System.Windows.Forms.Label label270;
        private System.Windows.Forms.Button btnBmsSetCalibrateCurrSamplingInputCmd;
        private System.Windows.Forms.Label label94;
        private System.Windows.Forms.TextBox txtBmsPowerAnalysisSamplDischgData1;
        private System.Windows.Forms.Label label215;
        private System.Windows.Forms.TextBox txtBmsSamplingDischgData1;
        private System.Windows.Forms.Label label217;
        private System.Windows.Forms.TextBox txtBmsPowerAnalysisSamplDischgData4;
        private System.Windows.Forms.Label label222;
        private System.Windows.Forms.TextBox txtBmsSamplingDischgData4;
        private System.Windows.Forms.Label label224;
        private System.Windows.Forms.TextBox txtBmsPowerAnalysisSamplDischgData3;
        private System.Windows.Forms.Label label225;
        private System.Windows.Forms.TextBox txtBmsSamplingDischgData3;
        private System.Windows.Forms.Label label226;
        private System.Windows.Forms.TextBox txtBmsPowerAnalysisSamplDischgData2;
        private System.Windows.Forms.Label label227;
        private System.Windows.Forms.TextBox txtBmsSamplingDischgData2;
        private System.Windows.Forms.Label label216;
        private System.Windows.Forms.TextBox txtBmsPowerAnalysisSamplChgData1;
        private System.Windows.Forms.Label label221;
        private System.Windows.Forms.TextBox txtBmsSamplingChgData1;
        private System.Windows.Forms.Label label228;
        private System.Windows.Forms.TextBox txtBmsPowerAnalysisSamplChgData4;
        private System.Windows.Forms.Label label230;
        private System.Windows.Forms.TextBox txtBmsSamplingChgData4;
        private System.Windows.Forms.Label label232;
        private System.Windows.Forms.TextBox txtBmsPowerAnalysisSamplChgData3;
        private System.Windows.Forms.Label label234;
        private System.Windows.Forms.TextBox txtBmsSamplingChgData3;
        private System.Windows.Forms.Label label236;
        private System.Windows.Forms.TextBox txtBmsPowerAnalysisSamplChgData2;
        private System.Windows.Forms.Label label238;
        private System.Windows.Forms.TextBox txtBmsSamplingChgData2;
        private System.Windows.Forms.GroupBox groupBox40;
        private System.Windows.Forms.Label label280;
        private System.Windows.Forms.TextBox textBoxCFG_Q_CTRL_KVAR;
        private System.Windows.Forms.Button btnGetLimitQ;
        private System.Windows.Forms.Button btnSetLimitQ;
        private System.Windows.Forms.GroupBox groupBox41;
        private System.Windows.Forms.Button btnBmsSetChgReverseCompensationParamCmd;
        private System.Windows.Forms.TextBox txtBmsChgReverseCompensationParam;
        private System.Windows.Forms.Label label283;
        private System.Windows.Forms.GroupBox groupBox42;
        private System.Windows.Forms.Button btnBmsHeartBeat;
        private System.Windows.Forms.ComboBox comboBoxDatType;
        private System.Windows.Forms.TabPage tabPage9;
        private System.Windows.Forms.Button btnChannel2;
        private System.Windows.Forms.Button btnChannel3;
        private System.Windows.Forms.Button btnChannel1;
        private System.Windows.Forms.Button btnChannel4;
        private System.Windows.Forms.Label label287;
        private System.Windows.Forms.Label label286;
        private System.Windows.Forms.ComboBox comboBoxCh1SignalId;
        private System.Windows.Forms.ComboBox comboBoxCh2SignalId;
        private System.Windows.Forms.ComboBox comboBoxCh3SignalId;
        private System.Windows.Forms.ComboBox comboBoxCh4SignalId;
        private System.Windows.Forms.Button btnImportSignalCfg;
        private System.Windows.Forms.GroupBox groupBox55;
        private System.Windows.Forms.Button btnPeriodSend;
        private System.Windows.Forms.Button button_clear;
        private System.Windows.Forms.TextBox textBoxSendPeriod;
        private System.Windows.Forms.Button btnCmdRecordFileSaveAs;
        private System.Windows.Forms.CheckBox chkBoxHexSend;
        private System.Windows.Forms.CheckBox checkBoxShowSend;
        private System.Windows.Forms.CheckBox chkBoxHexShow;
        private System.Windows.Forms.CheckBox checkBoxShowRecv;
        private System.Windows.Forms.Label labelCStandbyStep;
        private System.Windows.Forms.Label labelBStandbyStep;
        private System.Windows.Forms.Label labelAStandbyStep;
        private System.Windows.Forms.Label label330;
        private System.Windows.Forms.Button btnLogManualTxtAnalysis;
        private System.Windows.Forms.Button btnExportClear;
        private System.Windows.Forms.GroupBox groupBox37;
        private System.Windows.Forms.GroupBox groupBox35;
        private System.Windows.Forms.Label label214;
        private System.Windows.Forms.TextBox txtBmsMinVbatIndex;
        private System.Windows.Forms.Label label219;
        private System.Windows.Forms.TextBox txtBmsMinVbatValue;
        private System.Windows.Forms.Label label220;
        private System.Windows.Forms.GroupBox groupBox38;
        private System.Windows.Forms.Label label93;
        private System.Windows.Forms.TextBox txtBmsMaxVbatIndex;
        private System.Windows.Forms.Label label95;
        private System.Windows.Forms.TextBox txtBmsMaxVbatValue;
        private System.Windows.Forms.Label label218;
        private System.Windows.Forms.Label label223;
        private System.Windows.Forms.GroupBox groupBox31;
        private System.Windows.Forms.Button btnAnalogMonit5sec1hourStartStop;
        private System.Windows.Forms.Button btnBMSAnalogDatSave;
        private System.Windows.Forms.Button btnAnalogDatSave;
        private System.Windows.Forms.Button btnAnalogMonit1sec1minStartStop;
        private System.Windows.Forms.Button btnGetAnalogData;
        private System.Windows.Forms.GroupBox groupBox27;
        private System.Windows.Forms.TextBox txtBmsAnalogAlmGroup4;
        private System.Windows.Forms.TextBox txtBmsAnalogAlmGroup3;
        private System.Windows.Forms.Label label91;
        private System.Windows.Forms.Label label92;
        private System.Windows.Forms.Label label89;
        private System.Windows.Forms.Label label90;
        private System.Windows.Forms.TextBox txtBmsAnalogSOE;
        private System.Windows.Forms.Label label78;
        private System.Windows.Forms.Label label79;
        private System.Windows.Forms.TextBox txtBmsAnalogSOP_discharge;
        private System.Windows.Forms.Label label80;
        private System.Windows.Forms.Label label88;
        private System.Windows.Forms.TextBox txtBmsAnalogSOP_charge;
        private System.Windows.Forms.Label label70;
        private System.Windows.Forms.Label label73;
        private System.Windows.Forms.TextBox txtBmsAnalogSOH;
        private System.Windows.Forms.Label label76;
        private System.Windows.Forms.Label label77;
        private System.Windows.Forms.TextBox txtBmsAnalogSOC;
        private System.Windows.Forms.Label label55;
        private System.Windows.Forms.Label label56;
        private System.Windows.Forms.TextBox txtBmsAnalog12V;
        private System.Windows.Forms.Label label53;
        private System.Windows.Forms.Label label54;
        private System.Windows.Forms.TextBox txtBmsAnalogUbatPos;
        private System.Windows.Forms.Label label176;
        private System.Windows.Forms.Label label177;
        private System.Windows.Forms.TextBox txtBmsAnalogBat30V;
        private System.Windows.Forms.TextBox txtBmsAnalogAlmGroup2;
        private System.Windows.Forms.TextBox txtBmsAnalogAlmGroup1;
        private System.Windows.Forms.Label label160;
        private System.Windows.Forms.Label label161;
        private System.Windows.Forms.Label label146;
        private System.Windows.Forms.Label label186;
        private System.Windows.Forms.Label label188;
        private System.Windows.Forms.TextBox txtBmsAnalogVbat8;
        private System.Windows.Forms.Label label198;
        private System.Windows.Forms.Label label199;
        private System.Windows.Forms.TextBox txtBmsAnalogTbat8;
        private System.Windows.Forms.Label label200;
        private System.Windows.Forms.Label label201;
        private System.Windows.Forms.TextBox txtBmsAnalogVbat7;
        private System.Windows.Forms.Label label202;
        private System.Windows.Forms.Label label203;
        private System.Windows.Forms.TextBox txtBmsAnalogTbat7;
        private System.Windows.Forms.Label label204;
        private System.Windows.Forms.Label label205;
        private System.Windows.Forms.TextBox txtBmsAnalogVbat6;
        private System.Windows.Forms.Label label206;
        private System.Windows.Forms.Label label207;
        private System.Windows.Forms.TextBox txtBmsAnalogTbat6;
        private System.Windows.Forms.Label label208;
        private System.Windows.Forms.Label label209;
        private System.Windows.Forms.TextBox txtBmsAnalogVbat5;
        private System.Windows.Forms.Label label210;
        private System.Windows.Forms.Label label211;
        private System.Windows.Forms.TextBox txtBmsAnalogTbat5;
        private System.Windows.Forms.Label label178;
        private System.Windows.Forms.Label label179;
        private System.Windows.Forms.TextBox txtBmsAnalogAc30V;
        private System.Windows.Forms.Label label180;
        private System.Windows.Forms.Label label181;
        private System.Windows.Forms.TextBox txtBmsAnalogTblncingr;
        private System.Windows.Forms.Label label182;
        private System.Windows.Forms.Label label183;
        private System.Windows.Forms.TextBox txtBmsAnalogTboard;
        private System.Windows.Forms.Label label184;
        private System.Windows.Forms.Label label185;
        private System.Windows.Forms.TextBox txtBmsAnalogTterminal2;
        private System.Windows.Forms.Label label187;
        private System.Windows.Forms.Label label189;
        private System.Windows.Forms.TextBox txtBmsAnalogTterminal1;
        private System.Windows.Forms.Label label190;
        private System.Windows.Forms.Label label191;
        private System.Windows.Forms.Label label192;
        private System.Windows.Forms.Label label193;
        private System.Windows.Forms.TextBox txtBmsAnalog3V3;
        private System.Windows.Forms.TextBox txtBmsAnalogISR;
        private System.Windows.Forms.Label label194;
        private System.Windows.Forms.Label label195;
        private System.Windows.Forms.Label label196;
        private System.Windows.Forms.TextBox txtBmsAnalog30V;
        private System.Windows.Forms.Label label197;
        private System.Windows.Forms.TextBox txtBmsAnalogIbat;
        private System.Windows.Forms.Label label144;
        private System.Windows.Forms.Label label145;
        private System.Windows.Forms.TextBox txtBmsAnalogVbat4;
        private System.Windows.Forms.Label label147;
        private System.Windows.Forms.TextBox txtBmsAnalogTbat4;
        private System.Windows.Forms.Label label148;
        private System.Windows.Forms.Label label149;
        private System.Windows.Forms.TextBox txtBmsAnalogVbat3;
        private System.Windows.Forms.Label label150;
        private System.Windows.Forms.Label label151;
        private System.Windows.Forms.TextBox txtBmsAnalogTbat3;
        private System.Windows.Forms.Label label152;
        private System.Windows.Forms.Label label153;
        private System.Windows.Forms.TextBox txtBmsAnalogVbat2;
        private System.Windows.Forms.Label label154;
        private System.Windows.Forms.Label label155;
        private System.Windows.Forms.TextBox txtBmsAnalogTbat2;
        private System.Windows.Forms.Label label156;
        private System.Windows.Forms.Label label157;
        private System.Windows.Forms.TextBox txtBmsAnalogVbat1;
        private System.Windows.Forms.Label label158;
        private System.Windows.Forms.Label label159;
        private System.Windows.Forms.TextBox txtBmsAnalogTbat1;
        private System.Windows.Forms.GroupBox groupBox13;
        private System.Windows.Forms.GroupBox groupBox32;
        private System.Windows.Forms.Label label337;
        private System.Windows.Forms.TextBox txtCAnalogExternalFan2State;
        private System.Windows.Forms.Label label338;
        private System.Windows.Forms.TextBox txtCAnalogExternalFan1State;
        private System.Windows.Forms.Label label339;
        private System.Windows.Forms.TextBox txtCAnalogInternalFanState;
        private System.Windows.Forms.Label label51;
        private System.Windows.Forms.Label label174;
        private System.Windows.Forms.Label label52;
        private System.Windows.Forms.TextBox txtCAnalogGridFreq;
        private System.Windows.Forms.Label label175;
        private System.Windows.Forms.TextBox txtCAnalogQout;
        private System.Windows.Forms.Label label212;
        private System.Windows.Forms.Label label213;
        private System.Windows.Forms.TextBox txtCAnalogPout;
        private System.Windows.Forms.Label label128;
        private System.Windows.Forms.Label label129;
        private System.Windows.Forms.TextBox txtCAnalog10V;
        private System.Windows.Forms.Label label130;
        private System.Windows.Forms.Label label131;
        private System.Windows.Forms.TextBox txtCAnalogDci;
        private System.Windows.Forms.Label label132;
        private System.Windows.Forms.Label label133;
        private System.Windows.Forms.TextBox txtCAnalogSecTemp;
        private System.Windows.Forms.Label label134;
        private System.Windows.Forms.Label label135;
        private System.Windows.Forms.TextBox txtCAnalogPriTemp;
        private System.Windows.Forms.Label label136;
        private System.Windows.Forms.Label label137;
        private System.Windows.Forms.TextBox txtCAnalogVbat;
        private System.Windows.Forms.Label label138;
        private System.Windows.Forms.Label label139;
        private System.Windows.Forms.TextBox txtCAnalogIgrid;
        private System.Windows.Forms.Label label140;
        private System.Windows.Forms.Label label141;
        private System.Windows.Forms.TextBox txtCAnalogPowerVgrid;
        private System.Windows.Forms.Label label142;
        private System.Windows.Forms.Label label143;
        private System.Windows.Forms.TextBox txtCAnalogVgrid;
        private System.Windows.Forms.GroupBox groupBox29;
        private System.Windows.Forms.Label label332;
        private System.Windows.Forms.TextBox txtBAnalogExternalFan2State;
        private System.Windows.Forms.Label label334;
        private System.Windows.Forms.TextBox txtBAnalogExternalFan1State;
        private System.Windows.Forms.Label label336;
        private System.Windows.Forms.TextBox txtBAnalogInternalFanState;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.Label label170;
        private System.Windows.Forms.Label label47;
        private System.Windows.Forms.TextBox txtBAnalogGridFreq;
        private System.Windows.Forms.Label label171;
        private System.Windows.Forms.TextBox txtBAnalogQout;
        private System.Windows.Forms.Label label172;
        private System.Windows.Forms.Label label173;
        private System.Windows.Forms.TextBox txtBAnalogPout;
        private System.Windows.Forms.Label label112;
        private System.Windows.Forms.Label label113;
        private System.Windows.Forms.TextBox txtBAnalog10V;
        private System.Windows.Forms.Label label114;
        private System.Windows.Forms.Label label115;
        private System.Windows.Forms.TextBox txtBAnalogDci;
        private System.Windows.Forms.Label label116;
        private System.Windows.Forms.Label label117;
        private System.Windows.Forms.TextBox txtBAnalogSecTemp;
        private System.Windows.Forms.Label label118;
        private System.Windows.Forms.Label label119;
        private System.Windows.Forms.TextBox txtBAnalogPriTemp;
        private System.Windows.Forms.Label label120;
        private System.Windows.Forms.Label label121;
        private System.Windows.Forms.TextBox txtBAnalogVbat;
        private System.Windows.Forms.Label label122;
        private System.Windows.Forms.Label label123;
        private System.Windows.Forms.TextBox txtBAnalogIgrid;
        private System.Windows.Forms.Label label124;
        private System.Windows.Forms.Label label125;
        private System.Windows.Forms.TextBox txtBAnalogPowerVgrid;
        private System.Windows.Forms.Label label126;
        private System.Windows.Forms.Label label127;
        private System.Windows.Forms.TextBox txtBAnalogVgrid;
        private System.Windows.Forms.GroupBox groupBox28;
        private System.Windows.Forms.Label label335;
        private System.Windows.Forms.TextBox txtAAnalogExternalFan2State;
        private System.Windows.Forms.Label label331;
        private System.Windows.Forms.TextBox txtAAnalogExternalFan1State;
        private System.Windows.Forms.Label label333;
        private System.Windows.Forms.TextBox txtAAnalogInternalFanState;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.TextBox txtAAnalogGridFreq;
        private System.Windows.Forms.Label label166;
        private System.Windows.Forms.Label label167;
        private System.Windows.Forms.TextBox txtAAnalogQout;
        private System.Windows.Forms.Label label168;
        private System.Windows.Forms.Label label169;
        private System.Windows.Forms.TextBox txtAAnalogPout;
        private System.Windows.Forms.Label label96;
        private System.Windows.Forms.Label label97;
        private System.Windows.Forms.TextBox txtAAnalog10V;
        private System.Windows.Forms.Label label98;
        private System.Windows.Forms.Label label99;
        private System.Windows.Forms.TextBox txtAAnalogDci;
        private System.Windows.Forms.Label label100;
        private System.Windows.Forms.Label label101;
        private System.Windows.Forms.TextBox txtAAnalogSecTemp;
        private System.Windows.Forms.Label label102;
        private System.Windows.Forms.Label label103;
        private System.Windows.Forms.TextBox txtAAnalogPriTemp;
        private System.Windows.Forms.Label label104;
        private System.Windows.Forms.Label label105;
        private System.Windows.Forms.TextBox txtAAnalogVbat;
        private System.Windows.Forms.Label label106;
        private System.Windows.Forms.Label label107;
        private System.Windows.Forms.TextBox txtAAnalogIgrid;
        private System.Windows.Forms.Label label108;
        private System.Windows.Forms.Label label109;
        private System.Windows.Forms.TextBox txtAAnalogPowerVgrid;
        private System.Windows.Forms.Label label110;
        private System.Windows.Forms.Label label111;
        private System.Windows.Forms.TextBox txtAAnalogVgrid;
        private System.Windows.Forms.GroupBox groupBox30;
        private System.Windows.Forms.CheckBox chkboxAnalogDataBms;
        private System.Windows.Forms.CheckBox chkboxAnalogDataPcs;
        private System.Windows.Forms.Label label340;
        private System.Windows.Forms.Button btnTimeSync;
        private System.Windows.Forms.GroupBox groupBox57;
        private System.Windows.Forms.Button btnGetBkpAlmDataOnOffGridStateData;
        private System.Windows.Forms.Label label357;
        private System.Windows.Forms.TextBox txtBkpIsAlmState;
        private System.Windows.Forms.TextBox txtBkpIsAlmData;
        private System.Windows.Forms.Label label360;
        private System.Windows.Forms.Label label392;
        private System.Windows.Forms.TextBox txtBkpOnOffGridState;
        private System.Windows.Forms.GroupBox groupBox53;
        private System.Windows.Forms.GroupBox groupBox56;
        private System.Windows.Forms.RadioButton radioBtnBkpFanTurnOff;
        private System.Windows.Forms.RadioButton radioBtnBkpFanTurnOn;
        private System.Windows.Forms.Button btnBkpSetFanTurnOnOff;
        private System.Windows.Forms.GroupBox groupBox49;
        private System.Windows.Forms.GroupBox groupBox58;
        private System.Windows.Forms.Label label342;
        private System.Windows.Forms.RadioButton radioBtnBkpDo4LowLevel;
        private System.Windows.Forms.RadioButton radioBtnBkpDo4HighLevel;
        private System.Windows.Forms.GroupBox groupBox52;
        private System.Windows.Forms.Label label324;
        private System.Windows.Forms.RadioButton radioBtnBkpDo3LowLevel;
        private System.Windows.Forms.RadioButton radioBtnBkpDo3HighLevel;
        private System.Windows.Forms.GroupBox groupBox51;
        private System.Windows.Forms.Label label322;
        private System.Windows.Forms.RadioButton radioBtnBkpDo2LowLevel;
        private System.Windows.Forms.RadioButton radioBtnBkpDo2HighLevel;
        private System.Windows.Forms.GroupBox groupBox50;
        private System.Windows.Forms.Label label329;
        private System.Windows.Forms.RadioButton radioBtnBkpDo1LowLevel;
        private System.Windows.Forms.RadioButton radioBtnBkpDo1HighLevel;
        private System.Windows.Forms.Button btnBkpSetMultiDoPara;
        private System.Windows.Forms.GroupBox groupBox45;
        private System.Windows.Forms.Button btnGetBkpTestdata;
        private System.Windows.Forms.GroupBox groupBox47;
        private System.Windows.Forms.Label label323;
        private System.Windows.Forms.TextBox txtBkpHardVer;
        private System.Windows.Forms.TextBox txtBkpPhaseNum;
        private System.Windows.Forms.Label label321;
        private System.Windows.Forms.GroupBox groupBox48;
        private System.Windows.Forms.Label label317;
        private System.Windows.Forms.TextBox txtBkpUn2pe;
        private System.Windows.Forms.Label label319;
        private System.Windows.Forms.TextBox txtBkpU12v;
        private System.Windows.Forms.Label label305;
        private System.Windows.Forms.Label label303;
        private System.Windows.Forms.GroupBox groupBox46;
        private System.Windows.Forms.Label label310;
        private System.Windows.Forms.Label label311;
        private System.Windows.Forms.TextBox txtBkpBphaseUg;
        private System.Windows.Forms.TextBox txtBkpAphaseUg;
        private System.Windows.Forms.Label label309;
        private System.Windows.Forms.Label label308;
        private System.Windows.Forms.TextBox txtBkpCphaseUg;
        private System.Windows.Forms.Label label307;
        private System.Windows.Forms.TextBox txtBkpCphaseUout;
        private System.Windows.Forms.Label label306;
        private System.Windows.Forms.Label label313;
        private System.Windows.Forms.Label label312;
        private System.Windows.Forms.Label label292;
        private System.Windows.Forms.TextBox txtBkpAphaseUout;
        private System.Windows.Forms.Label label293;
        private System.Windows.Forms.Label label297;
        private System.Windows.Forms.TextBox txtBkpBphaseUdiff;
        private System.Windows.Forms.Label label296;
        private System.Windows.Forms.Label label298;
        private System.Windows.Forms.TextBox txtBkpBphaseUout;
        private System.Windows.Forms.Label label299;
        private System.Windows.Forms.Label label295;
        private System.Windows.Forms.TextBox txtBkpAphaseUdiff;
        private System.Windows.Forms.Label label294;
        private System.Windows.Forms.Label label300;
        private System.Windows.Forms.TextBox txtBkpCphaseUdiff;
        private System.Windows.Forms.Label label301;
        private System.Windows.Forms.GroupBox groupBox44;
        private System.Windows.Forms.TextBox txtBkpDo4State;
        private System.Windows.Forms.Label label341;
        private System.Windows.Forms.Label label318;
        private System.Windows.Forms.TextBox txtBkpDo2State;
        private System.Windows.Forms.Label label320;
        private System.Windows.Forms.TextBox txtBkpDo1State;
        private System.Windows.Forms.TextBox txtBkpDI2State;
        private System.Windows.Forms.Label label316;
        private System.Windows.Forms.TextBox txtBkpDo3State;
        private System.Windows.Forms.Label label304;
        private System.Windows.Forms.TextBox txtBkpDI1State;
        private System.Windows.Forms.Label label302;
        private System.Windows.Forms.GroupBox groupBox43;
        private System.Windows.Forms.TextBox txtBkptTempTrans;
        private System.Windows.Forms.Label label326;
        private System.Windows.Forms.Label label327;
        private System.Windows.Forms.Label label290;
        private System.Windows.Forms.TextBox txtBkptTempBCrly;
        private System.Windows.Forms.Label label289;
        private System.Windows.Forms.Label label291;
        private System.Windows.Forms.TextBox txtBkptTempEnv;
        private System.Windows.Forms.TextBox txtBkptTempANrly;
        private System.Windows.Forms.Label label315;
        private System.Windows.Forms.Label label49;
        private System.Windows.Forms.Label label314;
        private System.Windows.Forms.GroupBox groupBox59;
        private System.Windows.Forms.TextBox textBoxBmsRunState;
        private System.Windows.Forms.Button btnGetBmsRunState;
        private System.Windows.Forms.TabPage tabPage10;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox60;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox61;
        private System.Windows.Forms.TextBox textBoxMapDir;
        private System.Windows.Forms.Label label343;
        private System.Windows.Forms.Button btnOpenMap;
        private System.Windows.Forms.Label label344;
        private System.Windows.Forms.TextBox textBoxReadPeriod;
        private System.Windows.Forms.Button btnReadVar;
        private System.Windows.Forms.RadioButton rdioBtnDaqRead;
        private System.Windows.Forms.RadioButton rdioBtnPollingRead;
        private System.Windows.Forms.RadioButton rdioBtnReadSingle;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnVarSelect;
        private System.Windows.Forms.DataGridViewTextBoxColumn VarName;
        private System.Windows.Forms.DataGridViewTextBoxColumn VarAddr;
        private System.Windows.Forms.DataGridViewComboBoxColumn VarType;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReadValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn WriteValue;
        private System.Windows.Forms.DataGridViewCheckBoxColumn VarSelect;
        private System.Windows.Forms.Button btnSetVarParam;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.GroupBox groupBox63;
        private System.Windows.Forms.Button btnImportWaveData;
        private System.Windows.Forms.Button btnExportWaveData;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label label349;
        private System.Windows.Forms.TextBox textBoxCh1Addr;
        private System.Windows.Forms.TextBox textBoxCh2Addr;
        private System.Windows.Forms.TextBox textBoxCh3Addr;
        private System.Windows.Forms.TextBox textBoxCh4Addr;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Label label50;
        private System.Windows.Forms.Label label285;
        private System.Windows.Forms.Label Mouse_textLab;
        private System.Windows.Forms.Button btnStartSingleTrigGetWaveData;
        private System.Windows.Forms.Label label281;
        private System.Windows.Forms.Button btnClearAllWaveData;
        private System.Windows.Forms.ComboBox comboBoxCh1TrigCompareType;
        private System.Windows.Forms.ComboBox comboBoxCh1TrigValId;
        private System.Windows.Forms.Label label282;
        private System.Windows.Forms.GroupBox groupBox54;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.NumericUpDown textBoxCh1TrigVal;
        private System.Windows.Forms.GroupBox groupBox66;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel10;
        private System.Windows.Forms.DataVisualization.Charting.Chart WaveChart;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel11;
        private System.Windows.Forms.GroupBox groupBox67;
        private System.Windows.Forms.GroupBox groupBox68;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label362;
        private System.Windows.Forms.Label label366;
        private System.Windows.Forms.Label label365;
        private System.Windows.Forms.Label label364;
        private System.Windows.Forms.Label label363;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label367;
        private System.Windows.Forms.Label label370;
        private System.Windows.Forms.Label label369;
        private System.Windows.Forms.Label label368;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel14;
        private System.Windows.Forms.Label label371;
        private System.Windows.Forms.Label label345;
        private System.Windows.Forms.ComboBox comboBoxCh1DatType;
        private System.Windows.Forms.ComboBox comboBoxCh2DatType;
        private System.Windows.Forms.ComboBox comboBoxCh3DatType;
        private System.Windows.Forms.ComboBox comboBoxCh4DatType;
        private System.Windows.Forms.Label labSampleFreq;
        private System.Windows.Forms.Label labSamplePeriod;
        private System.Windows.Forms.Button btnOscAddSignal;
        private System.Windows.Forms.GroupBox groupBox62;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel8;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private System.Windows.Forms.NumericUpDown numericUpDownTrigPos;
        private System.Windows.Forms.NumericUpDown numericUpDown3;
        private System.Windows.Forms.Label label361;
        private System.Windows.Forms.Label label359;
        private System.Windows.Forms.NumericUpDown numUpDnVrtZoomCh1;
        private System.Windows.Forms.NumericUpDown numUpDnVrtZoomCh2;
        private System.Windows.Forms.NumericUpDown numUpDnVrtZoomCh3;
        private System.Windows.Forms.NumericUpDown numUpDnVrtZoomCh4;
        private System.Windows.Forms.NumericUpDown numUpDnVrtOffsetCh1;
        private System.Windows.Forms.NumericUpDown numUpDnVrtOffsetCh2;
        private System.Windows.Forms.NumericUpDown numUpDnVrtOffsetCh3;
        private System.Windows.Forms.NumericUpDown numUpDnVrtOffsetCh4;
        private System.Windows.Forms.Label label325;
        private System.Windows.Forms.Label label346;
        private System.Windows.Forms.Label label347;
        private System.Windows.Forms.Label label348;
        private System.Windows.Forms.Label label350;
        private System.Windows.Forms.Label label351;
        private System.Windows.Forms.Label label352;
        private System.Windows.Forms.Label label353;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel9;
        private System.Windows.Forms.Label label288;
        private System.Windows.Forms.Label label284;
        private System.Windows.Forms.NumericUpDown numUpDnSampleFreqOrigin;
        private System.Windows.Forms.NumericUpDown numUpDnSampleDiv;
        private System.Windows.Forms.Button btnStartGetWaveData;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.RadioButton radioBtnConnectObjectBigPcs;
        private System.Windows.Forms.Label labDestMcuAddr;
        private System.Windows.Forms.Button btnClearVars;
    }
}

