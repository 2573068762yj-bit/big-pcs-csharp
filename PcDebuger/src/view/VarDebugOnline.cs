using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Drawing;
using System.Xml.Serialization;

namespace PcDebuger
{
    public class VarOnline
    {
        // 保存变量或结构体叶子成员的完整名称。
        public string name;

        // 保存可以直接发送给下位机的十六进制地址字符串。
        public string addr;

        // 保存当前协议使用的数据类型名称。
        public string type;

        // 保存 ELF/DWARF 中记录的变量字节数。
        public uint size;

        // 标记该成员是否属于当前协议不能直接读写的位域。
        public bool isBitField;

        // 保存变量来源，便于在选择窗口区分MAP符号和ELF成员。
        public string source;
    }

    public class VarOnlineExtend
    {
        public bool isSelected;
        public bool isNeedWrite;
        public string name;
        public string addr;
        public string type;
        public string rdValue;
        public string wrValue;

        // 保存调试文件中的原始类型，用于新ELF载入后的严格身份匹配。
        public string debugType;

        // 保存调试文件中的变量大小，用于避免同名但布局已经变化的变量误匹配。
        public uint size;

        // 标记该变量是否已经在当前ELF/MAP中重新匹配成功。
        public bool resolved;
    }

    /// <summary>
    /// 保存变量调试页需要跨软件启动保留的内容。
    /// 使用公开字段是为了兼容.NET Framework 4.5自带的XmlSerializer。
    /// </summary>
    [Serializable]
    public class VarDebugOnlineConfig
    {
        // 保存用户最后一次选择的Debug构建目录。
        public string debugDirectory;

        // 保存用户已经添加到右侧在线变量表中的变量。
        public List<VarOnlineExtend> variables;

        public VarDebugOnlineConfig()
        {
            // XML反序列化和首次启动都需要一个非空列表。
            variables = new List<VarOnlineExtend>();
        }
    }

    /// <summary>
    /// 保存一次后台目录扫描的完整结果，便于安全地切回UI线程更新控件。
    /// </summary>
    internal class VarDebugDirectoryScanResult
    {
        // 保存本次实际解析的ELF和MAP文件。
        public string[] files;

        // 保存解析得到的全部可读取变量。
        public List<VarOnline> variables;

        // 保存ELF/DWARF解析器产生的非致命提示。
        public string warning;
    }

    public enum ReadType : byte
    {
        READ_SINGLE = 0x00,
        READ_POLLING = 0x01,
        READ_DAQ = 0x02,
    }
    
    partial class MainForm
    {
        private List<VarOnline> mVarList; // 从MAP或ELF文件中读出来的所有变量和地址
        private List<VarOnlineExtend> mVarListExt;  //  变量读写界面中所有的变量
        private ReadType mReadType;
        private uint mReadPeriod;
        private bool mReadPollingStarted;
        private ushort CMD_READ_DEBUG_VAR = 0x2A91;
        private ushort CMD_WRITE_DEBUG_VAR = 0x2B91;
        private ushort CMD_WRITE_DEBUG_CFG = 0x2B90;

        // 左侧常驻变量浏览区一次最多创建的行数，防止大型ELF使界面卡顿。
        private const int MAX_RESIDENT_VAR_COUNT = 1500;

        // 保存当前选择的Debug构建目录。
        private string mDebugDirectory;

        // 每两秒检查一次最新ELF的路径、大小和修改时间，逻辑与Rust版一致。
        private System.Windows.Forms.Timer mDebugFileChangedTimer;

        // 标记后台是否正在解析调试文件，避免同时启动多个DWARF解析任务。
        private bool mIsDebugDirectoryScanning;

        // 扫描期间再次收到文件变化时，记录完成后还需要重新扫描一次。
        private bool mIsDebugDirectoryScanPending;

        // 保存当前已经解析的主调试文件路径。
        private string mLoadedDebugImagePath;

        // 保存当前已经解析的主调试文件修改时间。
        private DateTime mLoadedDebugImageWriteTimeUtc;

        // 保存当前已经解析的主调试文件大小，辅助识别同一秒内的重新构建。
        private long mLoadedDebugImageLength;

        // 自动更新地址前如果正在轮询，完成重绑定后需要恢复轮询。
        private bool mResumePollingAfterDebugScan;

        // 保存左侧变量浏览区使用的分栏控件。
        private SplitContainer mVarDebugSplitContainer;

        // 保存左侧变量搜索输入框。
        private TextBox mResidentVarSearchTextBox;

        // 保存左侧来源筛选框，可查看全部、ELF或MAP变量。
        private ComboBox mResidentVarSourceComboBox;

        // 保存左侧搜索结果表格。
        private DataGridView mResidentVarGrid;

        // 保存目录扫描状态、变量数量和地址更新数量。
        private Label mResidentVarStatusLabel;

        // 保存左侧变量树中由用户手工展开的结构体和数组节点。
        private HashSet<string> mExpandedResidentVarNodeSet;

        // 保存最近一次成功扫描摘要，搜索条件清空后用于恢复状态提示。
        private string mDebugScanSummary;

        // 分支行共用同一个粗体字体，避免每次搜索都创建大量字体对象。
        private Font mResidentVarBranchFont;

        private void InitVarDebugOnlineView()
        {
            btnOpenMap.Click += btnOpenMap_Click;

            mReadType = ReadType.READ_SINGLE;
            rdioBtnReadSingle.Checked = true;
            rdioBtnReadSingle.CheckedChanged += rdioBtnReadSingle_CheckedChanged;
            rdioBtnPollingRead.Checked = false;
            rdioBtnPollingRead.CheckedChanged += rdioBtnPollingRead_CheckedChanged;
            rdioBtnDaqRead.Checked = false;
            rdioBtnDaqRead.CheckedChanged += rdioBtnDaqRead_CheckedChanged;

            btnReadVar.Click += btnReadVar_Click;
            btnSetVarParam.Click += btnSetVarParam_Click;
            btnClearVars.Click += btnClearVars_Click;

            textBoxReadPeriod.Text = "100000";  // 100ms
            mReadPeriod = 100000;
            mVarList = new List<VarOnline>();
            mVarListExt = new List<VarOnlineExtend>();

            mReadPollingStarted = false;

            // 将原来的弹窗选择方式改为左侧常驻搜索和添加区域。
            InitResidentVarDebugView();

            // 载入上次关闭软件时保存的Debug目录和在线变量。
            LoadVarDebugOnlineConfig();

            // 先恢复右侧变量表，即使Debug文件暂时不存在也不会丢失用户配置。
            UpdateVarSelectWin();

            // 软件关闭前再次保存界面中的最新变量设置。
            this.FormClosing += MainForm_VarDebugOnlineFormClosing;

            // 已保存的Debug目录仍然有效时，启动监视并立即解析一次。
            if (!string.IsNullOrEmpty(mDebugDirectory) &&
                Directory.Exists(mDebugDirectory))
            {
                ConfigureDebugDirectoryWatcher();
                StartDebugDirectoryScan(false);
            }
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            int clm = e.ColumnIndex;

            // 表头、空行或模型范围外的行不能继续处理。
            if (row < 0 || row >= mVarListExt.Count)
            {
                return;
            }

            if (clm == 1 || clm == 2)
            {
                DataGridViewRow datRow = dataGridView1.Rows[row];
                string varAddr = Convert.ToString(datRow.Cells[1].Value);
                string selectedVarType = Convert.ToString(datRow.Cells[2].Value);

                mVarListExt[row].addr = varAddr;
                mVarListExt[row].type = selectedVarType;
                var item = mVarListExt[row];

                // 只有当前ELF重新匹配成功后才允许把地址配置给下位机。
                if (item.resolved)
                {
                    byte[] cmd = VarDebugOnlineMakeSetAddrCmd(item, (byte)row);
                    CommSendCmd(cmd);
                }
            }
            else if (clm == 4)
            {
                DataGridViewRow datRow = dataGridView1.Rows[row];
                string wrValue = Convert.ToString(datRow.Cells[clm].Value);
                mVarListExt[row].wrValue = wrValue;
                var item = mVarListExt[row];

                if (item.resolved)
                {
                    byte[] cmd = VarDebugOnlineMakeWriteCmd(item, (byte)row);
                    CommSendCmd(cmd);
                }
            }

            // 每次编辑后立即保存，异常关闭时也能尽量保留用户设置。
            SaveVarDebugOnlineConfig();
        }

        private byte VarDebugOnlineGetDatLen(byte type)
        {
            byte len = 0;
            switch (type)
            {
                case 0x91:
                case 0x92:
                    len = 2;
                    break;
                case 0x93:
                case 0x94:
                case 0x95:
                    len = 4;
                    break;
                default:
                    break;
            }
            return len;
        }
        public void VarDebugOnlineRecvDataProcess(byte[] frame)
        {
            if (frame.Length < 6)
            {
                return;
            }

            ushort offset = 0;
            offset++;
            ushort cmd = (ushort)((frame[offset] << 8) + frame[offset + 1]);
            offset += (2 + 1); //  跳过错误码
            ushort datLen = (ushort)((frame[offset] << 8) + frame[offset + 1]);
            offset += 2;
            //if ((datLen + 7) > frame.Length)
            //{
            //    return;
            //}
            if (cmd == CMD_READ_DEBUG_VAR)
            {
                offset += 1; // 跳过高字节
                byte chNum = frame[offset++];
                offset += 1; // 跳过高字节
                byte varLen = VarDebugOnlineGetDatLen(frame[offset++]);
                uint addr = (uint)((frame[offset + 2] << 24) + (frame[offset + 3] << 16) + (frame[offset] << 8) + frame[offset + 1]);
                offset += 4;
                uint value = 0;
                if (varLen == 2)
                {
                    value = (uint)((frame[offset] << 8) + (frame[offset + 1] << 0));
                }
                else if (varLen == 4)
                {
                    value = (uint)((frame[offset] << 24) + (frame[offset + 1] << 16) + (frame[offset + 2] << 8) + frame[offset + 3]);
                }
                else
                {
                    return;
                }
                if (chNum >= mVarListExt.Count)
                {
                    return;
                }

                // ELF更新期间或变量未匹配时，丢弃可能属于旧地址的迟到应答。
                if (!mVarListExt[chNum].resolved)
                {
                    return;
                }

                if (addr == VarDebugOnlineGetAddr(mVarListExt[chNum].addr))
                {
                    mVarListExt[chNum].rdValue = value.ToString();

                    var type = mVarListExt[chNum].type;
                    dataGridView1.Rows[chNum].Cells[3].Value = GetValueStringByTypeAndHexValue(type, value);
                }
            }

        }

        private string GetValueStringByTypeAndHexValue(string type, uint value)
        {
            string valueStr = "null";
            switch (type)
            {
                case "Int16":
                    valueStr = ((Int16)value).ToString();
                    break;
                case "Uint16":
                    valueStr = ((UInt16)value).ToString();
                    break;
                case "Int32":
                    valueStr = ((Int32)value).ToString();
                    break;
                case "Uint32":
                    valueStr = ((UInt32)value).ToString();
                    break;
                case "Float":
                    valueStr = (((float)(int)value) / 1000).ToString();
                    break;
                default:
                    break;
            }
            return valueStr;
        }

        private void btnReadVar_Click(object sender, EventArgs e)
        {
            // 没有在当前ELF中匹配成功的变量时，禁止启动空轮询或访问旧地址。
            if (!mVarListExt.Any(item => item.isSelected && item.resolved))
            {
                MessageBox.Show("当前没有已匹配的在线变量！");
                return;
            }

            switch (mReadType)
            {
                case ReadType.READ_SINGLE:
                    VarDebugOnlineReadSingle();
                    break;
                case ReadType.READ_POLLING:
                    if (mReadPollingStarted)
                    {
                        mReadPollingStarted = false; // stop thread
                        btnReadVar.Text = "读取";
                    }
                    else
                    {
                        mReadPollingStarted = true;
                        btnReadVar.Text = "停止";
                        mReadPeriod = Convert.ToUInt32(textBoxReadPeriod.Text);
                        VarDebugOnlineReadPollingStart();
                    }
                    break;
                case ReadType.READ_DAQ:
                    break;
                default:
                    break;
            }
        }

        private void VarDebugOnlineReadPollingStart()
        {
            System.Threading.Thread readPollingThread;
            readPollingThread = new Thread(new ThreadStart(PollingReadThread));
            readPollingThread.IsBackground = true;
            readPollingThread.Start();
        }

        private void PollingReadThread()
        {
            uint delayTime_ms = mReadPeriod / 1000;
            TimeSpan tspan = new TimeSpan(delayTime_ms);
            while (mReadPollingStarted)
            {
                Thread.Sleep(tspan);
                VarDebugOnlineReadSingle();
            }
        }

        private void btnSetVarParam_Click(object sender, EventArgs e)
        {
            UpdateVarListFromUi();

            for(byte i = 0; i < mVarListExt.Count; i++) // (var item in mVarListExt)
            {
                var item = mVarListExt[i];
                if (item.isSelected && item.resolved)
                {
                    byte[] cmd = VarDebugOnlineMakeSetAddrCmd(item, i);
                    LogMsg(cmd, true);
                    CommSendCmd(cmd);
                }
            }
        }

        private void btnClearVars_Click(object sender, EventArgs e)
        {
            mVarListExt.Clear();
            UpdateVarSelectWin();
            RefreshResidentVarList();
            SaveVarDebugOnlineConfig();
        }

        private void UpdateVarListFromUi()
        {
            // 不再清空并重建模型，否则会丢失ELF大小、原始类型和匹配状态。
            SyncVarListFromGrid();

            if (mVarListExt.Count == 0)
            {
                MessageBox.Show("没有任何变量！");
            }

            SaveVarDebugOnlineConfig();
        }

        private byte VarDebugOnlineGetVarType(string type)
        {
            byte varType = 0x00;
            switch (type)
            {
                case "Int16":
                    varType = 0x91;
                    break;
                case "Uint16":
                    varType = 0x92;
                    break;
                case "Int32":
                    varType = 0x93;
                    break;
                case "Uint32":
                    varType = 0x94;
                    break;
                case "Float":
                    varType = 0x95;
                    break;
                default:
                    break;
            }
            return varType;
        }

        private UInt32 VarDebugOnlineGetVarValueHex(string type, string value)
        {
            UInt32 varValue = 0;
            switch (type)
            {
                case "Int16":
                    varValue = (UInt32)(int.Parse(value));
                    break;
                case "Uint16":
                    varValue = (UInt32)(uint.Parse(value));
                    break;
                case "Int32":
                    varValue = (UInt32)(int.Parse(value));
                    break;
                case "Uint32":
                    varValue = (UInt32)(uint.Parse(value));
                    break;
                case "Float":
                    varValue = (UInt32)(float.Parse(value) * 1000);
                    break;
                default:
                    break;
            }
            return varValue;
        }

        private uint VarDebugOnlineGetAddr(string addrStr)
        {
            //string addrStr = item.addr;
            if (addrStr.StartsWith("0x"))
            {
                addrStr = addrStr.Substring(2);
            }
            addrStr = addrStr.Replace(" ", "");
            if (addrStr.Length != 8)
            {
                MessageBox.Show("地址位数少于8！");
                return 0;
            }

            byte[] addrBytes = DataFormatConvert.CmdStringToAscii(addrStr);
            if (addrBytes.Length != 4)
            {
                MessageBox.Show("地址字节数少于4！");
                return 0;
            }
            uint addr = (uint)((addrBytes[0] << 24) + (addrBytes[1] << 16) + (addrBytes[2] << 8) + (addrBytes[3]));
            return addr;
        }

        private byte[] VarDebugOnlineMakeSetAddrCmd(VarOnlineExtend item, byte channel)
        {
            List<byte> sendList = new List<byte>();
            if(channel >= 32 || item == null || !item.resolved) {
                return null;
            }

            sendList.Add(0x00);    // 通道编号高字节
            sendList.Add(channel); // 通道编号，需与子功能码的通道号配套，subCmd - 1
            sendList.Add(0x00);    // 变量类型高字节
            sendList.Add(VarDebugOnlineGetVarType(item.type));  // 变量类型低字节
            uint varAddr = VarDebugOnlineGetAddr(item.addr);
            sendList.Add((byte)((varAddr >> 24) & 0xFF));
            sendList.Add((byte)((varAddr >> 16) & 0xFF));
            sendList.Add((byte)((varAddr >> 8) & 0xFF));
            sendList.Add((byte)((varAddr >> 0) & 0xFF));

            sendList.Add(0x00);
            sendList.Add(0x00);
            sendList.Add(0x00);
            sendList.Add(0x00);

            byte modbusAddr = GetModbusAddr();
            byte[] cmdBuf = ModbusProto.MakeSouthDevWriteCmdFrame(modbusAddr, CMD_WRITE_DEBUG_CFG, (ushort)sendList.Count, sendList.ToArray());
            LogMsg(cmdBuf, true);
            cmdBuf = ModbusProto.TransparentToModbusCmd(cmdBuf, (mCommMode == CommMode.CAN));
            LogMsg(cmdBuf, true);

            return cmdBuf;
        }

        private byte[] VarDebugOnlineMakeWriteCmd(VarOnlineExtend item, byte channel)
        {
            List<byte> sendList = new List<byte>();
            if (channel >= 32 || item == null || !item.resolved)
            {
                return null;
            }

            sendList.Add(0x00);    // 通道编号高字节
            sendList.Add(channel); // 通道编号，需与子功能码的通道号配套，subCmd - 1
            sendList.Add(0x00);
            sendList.Add(VarDebugOnlineGetVarType(item.type));
            uint varAddr = VarDebugOnlineGetAddr(item.addr);
            sendList.Add((byte)((varAddr >> 24) & 0xFF));
            sendList.Add((byte)((varAddr >> 16) & 0xFF));
            sendList.Add((byte)((varAddr >> 8) & 0xFF));
            sendList.Add((byte)((varAddr >> 0) & 0xFF));


            uint varValue = VarDebugOnlineGetVarValueHex(item.type, item.wrValue);
            sendList.Add((byte)((varValue >> 24) & 0xFF));
            sendList.Add((byte)((varValue >> 16) & 0xFF));
            sendList.Add((byte)((varValue >> 8) & 0xFF));
            sendList.Add((byte)((varValue >> 0) & 0xFF));

            byte modbusAddr = GetModbusAddr();
            byte[] cmdBuf = ModbusProto.MakeSouthDevWriteCmdFrame(modbusAddr, CMD_WRITE_DEBUG_VAR, (ushort)sendList.Count, sendList.ToArray());
            LogMsg(cmdBuf, true);
            cmdBuf = ModbusProto.TransparentToModbusCmd(cmdBuf, (mCommMode == CommMode.CAN));
            LogMsg(cmdBuf, true);

            return cmdBuf;
        }

        private byte[] VarDebugOnlineMakeReadCmd(VarOnlineExtend item, byte channel)
        {
            List<byte> sendList = new List<byte>();
            if (channel >= 32 || item == null || !item.resolved)
            {
                return null;
            }

            sendList.Add(0x00);    // 通道编号高字节
            sendList.Add(channel); // 通道编号，需与子功能码的通道号配套，subCmd - 1
            sendList.Add(0x00);
            sendList.Add(VarDebugOnlineGetVarType(item.type));
            uint varAddr = VarDebugOnlineGetAddr(item.addr);
            sendList.Add((byte)((varAddr >> 24) & 0xFF));
            sendList.Add((byte)((varAddr >> 16) & 0xFF));
            sendList.Add((byte)((varAddr >> 8) & 0xFF));
            sendList.Add((byte)((varAddr >> 0) & 0xFF));

            sendList.Add(0x00);
            sendList.Add(0x00);
            sendList.Add(0x00);
            sendList.Add(0x00);

            byte modbusAddr = GetModbusAddr();
            byte[] cmdBuf = ModbusProto.MakeSouthDevWriteCmdFrame(modbusAddr, CMD_READ_DEBUG_VAR, (ushort)sendList.Count, sendList.ToArray());
            LogMsg(cmdBuf, true);
            cmdBuf = ModbusProto.TransparentToModbusCmd(cmdBuf, (mCommMode == CommMode.CAN));
            LogMsg(cmdBuf, true);

            return cmdBuf;
        }

        private void VarDebugOnlineReadSingle()
        {
            for(byte i = 0; i < mVarListExt.Count; i++)
            {
                var item = mVarListExt[i];
                if (item.isSelected && item.resolved)
                {
                    byte[] cmd = VarDebugOnlineMakeReadCmd(item, i);
                    CommSendCmd(cmd);
                    Thread.Sleep(50);
                }
            }
        }

        private void rdioBtnReadSingle_CheckedChanged(object sender, EventArgs e)
        {
            mReadType = ReadType.READ_SINGLE;
        }

        private void rdioBtnPollingRead_CheckedChanged(object sender, EventArgs e)
        {
            mReadType = ReadType.READ_POLLING;
        }

        private void rdioBtnDaqRead_CheckedChanged(object sender, EventArgs e)
        {
            mReadType = ReadType.READ_DAQ;
        }

        void btnOpenMap_Click(object sender, EventArgs e)
        {
            // 使用目录选择器直接选择CubeIDE生成的Debug构建目录。
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description =
                "请选择包含STM32 ELF和MAP文件的Debug目录";
            dialog.ShowNewFolderButton = false;

            // 再次打开时从当前目录开始，减少重复定位操作。
            if (!string.IsNullOrEmpty(mDebugDirectory) &&
                Directory.Exists(mDebugDirectory))
            {
                dialog.SelectedPath = mDebugDirectory;
            }

            if (dialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            // 切换目录后清除旧文件签名，强制重新解析最新ELF。
            mDebugDirectory = Path.GetFullPath(dialog.SelectedPath);
            mLoadedDebugImagePath = string.Empty;
            mLoadedDebugImageWriteTimeUtc = DateTime.MinValue;
            mLoadedDebugImageLength = 0;
            textBoxMapDir.Text = mDebugDirectory;

            // 目录选择立即持久化，并启动两秒自动更新检查。
            SaveVarDebugOnlineConfig();
            ConfigureDebugDirectoryWatcher();
            StartDebugDirectoryScan(true);
        }

        private List<VarOnline> AnalysisDebugFile(string path)
        {
            // 取得文件扩展名，并使用不区分大小写的方式判断。
            string extension = Path.GetExtension(path);

            // MAP文件继续使用原有的文本解析逻辑。
            if (string.Equals(extension, ".map", StringComparison.OrdinalIgnoreCase))
            {
                return AnalysisMapFile(path);
            }

            // ELF文件使用新增的ELF和DWARF解析器。
            if (string.Equals(extension, ".elf", StringComparison.OrdinalIgnoreCase))
            {
                return ElfDwarfParser.AnalysisElfFile(path);
            }

            // 其他扩展名不属于当前功能范围。
            throw new NotSupportedException("不支持的文件格式：" + extension);
        }

        private string[] GetDebugFileList(string[] selectedFiles)
        {
            // 使用不区分大小写的集合避免同一文件被重复加入。
            HashSet<string> fileSet = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

            // 逐个处理用户选择的文件。
            foreach (string selectedFile in selectedFiles)
            {
                // 保存规范化后的完整路径。
                string fullPath = Path.GetFullPath(selectedFile);
                fileSet.Add(fullPath);

                // 取得当前文件扩展名。
                string extension = Path.GetExtension(fullPath);

                // 选择MAP时自动寻找同名ELF文件。
                if (string.Equals(extension, ".map", StringComparison.OrdinalIgnoreCase))
                {
                    string elfPath = Path.ChangeExtension(fullPath, ".elf");

                    if (File.Exists(elfPath))
                    {
                        fileSet.Add(elfPath);
                    }
                }

                // 选择ELF时自动寻找同名MAP文件。
                if (string.Equals(extension, ".elf", StringComparison.OrdinalIgnoreCase))
                {
                    string mapPath = Path.ChangeExtension(fullPath, ".map");

                    if (File.Exists(mapPath))
                    {
                        fileSet.Add(mapPath);
                    }
                }
            }

            // 先解析MAP，再解析ELF，使ELF中的可靠类型覆盖同名MAP变量。
            List<string> fileList = fileSet.ToList();
            fileList.Sort(delegate(string left, string right)
            {
                int leftPriority = string.Equals(Path.GetExtension(left), ".map",
                    StringComparison.OrdinalIgnoreCase) ? 0 : 1;
                int rightPriority = string.Equals(Path.GetExtension(right), ".map",
                    StringComparison.OrdinalIgnoreCase) ? 0 : 1;

                if (leftPriority != rightPriority)
                {
                    return leftPriority.CompareTo(rightPriority);
                }

                return string.Compare(left, right, StringComparison.OrdinalIgnoreCase);
            });

            // 返回最终需要解析的文件列表。
            return fileList.ToArray();
        }

        private List<VarOnline> AnalysisDebugFiles(string[] paths, out string warning)
        {
            // 使用变量完整名称和地址作为合并键。
            Dictionary<string, VarOnline> varMap =
                new Dictionary<string, VarOnline>(StringComparer.OrdinalIgnoreCase);

            // 收集所有ELF解析过程中产生的非致命警告。
            List<string> warningList = new List<string>();

            // 保存MAP根变量的合并键，后续需要排除已经被ELF展开的复合对象。
            List<string> mapVarKeyList = new List<string>();

            // 保存ELF解析出的全部标量叶子路径。
            List<VarOnline> elfVarList = new List<VarOnline>();

            // 依次解析MAP和ELF文件。
            foreach (string path in paths)
            {
                // 解析当前文件中的变量。
                List<VarOnline> fileVarList = AnalysisDebugFile(path);

                // ELF解析器会通过LastWarning报告DWARF回退原因。
                if (string.Equals(Path.GetExtension(path), ".elf",
                    StringComparison.OrdinalIgnoreCase) &&
                    !string.IsNullOrEmpty(ElfDwarfParser.LastWarning))
                {
                    warningList.Add(Path.GetFileName(path) + "：" +
                        ElfDwarfParser.LastWarning);
                }

                // 将当前文件的变量合并到统一列表。
                foreach (VarOnline varItem in fileVarList)
                {
                    // 地址统一转为大写，避免同一地址因大小写不同而重复。
                    string varKey = varItem.name + "@" +
                        (varItem.addr ?? string.Empty).ToUpperInvariant();

                    // 文件列表已经按照MAP在前、ELF在后排序，因此ELF会自然覆盖同名项。
                    varMap[varKey] = varItem;

                    // 分别记录MAP根符号和ELF叶子成员。
                    if (string.Equals(varItem.source, "MAP",
                        StringComparison.OrdinalIgnoreCase))
                    {
                        mapVarKeyList.Add(varKey);
                    }
                    else if (string.Equals(varItem.source, "ELF",
                        StringComparison.OrdinalIgnoreCase))
                    {
                        elfVarList.Add(varItem);
                    }
                }
            }

            // MAP无法判断一个符号是标量还是结构体，因此需要使用ELF展开结果纠正。
            foreach (string mapVarKey in mapVarKeyList)
            {
                // 同名项已经被ELF普通标量覆盖时不需要处理。
                if (!varMap.ContainsKey(mapVarKey) ||
                    !string.Equals(varMap[mapVarKey].source, "MAP",
                        StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }

                // 取得MAP根变量名称。
                string mapVarName = varMap[mapVarKey].name;

                // 标记ELF是否已经把该根变量展开成成员或数组元素。
                bool isExpandedByElf = false;

                // 只要存在“根变量.成员”或“根变量[索引]”，MAP根项就不能按Uint16读取。
                foreach (VarOnline elfVar in elfVarList)
                {
                    if (elfVar.name.StartsWith(mapVarName + ".",
                            StringComparison.Ordinal) ||
                        elfVar.name.StartsWith(mapVarName + "[",
                            StringComparison.Ordinal))
                    {
                        isExpandedByElf = true;
                        break;
                    }
                }

                // 删除无法安全直接读取的结构体或数组根项，只保留ELF标量叶子。
                if (isExpandedByElf)
                {
                    varMap.Remove(mapVarKey);
                }
            }

            // 组合需要显示给用户的警告文本。
            warning = string.Join("\r\n", warningList.ToArray());

            // 将合并结果转换为列表。
            List<VarOnline> result = varMap.Values.ToList();

            // 按完整变量路径排序，方便后续搜索和浏览。
            result.Sort(delegate(VarOnline left, VarOnline right)
            {
                return string.Compare(left.name, right.name,
                    StringComparison.CurrentCultureIgnoreCase);
            });

            // 返回MAP和ELF的统一变量集合。
            return result;
        }

        private List<VarOnline> AnalysisMapFile(string path)
        {
            string filePath = path;
            List<VarOnline> varList = new List<VarOnline>();

            // 读取所有行（自动处理编码）
            List<string> allLines = File.ReadAllLines(filePath).ToList();

            for (int i = 0; i < allLines.Count; )
            {
                string line = allLines[i++].Trim();
                string afterData;
                if (line.StartsWith(".data."))
                {
                    afterData = line.Substring(".data.".Length);
                }
                else if (line.StartsWith(".bss."))
                {
                    afterData = line.Substring(".bss.".Length);
                }
                else
                {
                    continue;
                }
                //LogMsg(afterData + "\r\n拆分后：");

                string[] parts = afterData.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                //foreach (string subStr in parts)
                //{
                    //LogMsg(subStr + " ");
                //}

                //LogMsg("\r\n解析后：");

                if (parts.Length == 1)
                {
                    // 变量名和地址分行保存时，需要确保下一行确实存在。
                    if (i >= allLines.Count)
                    {
                        break;
                    }

                    line = allLines[i++].Trim();  // 如果只有1个变量名，则去下一行查找地址
                    if (line.StartsWith("0x"))
                    {
                        parts = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        if (parts[0] != "0x00000000")
                        {
                            // 创建一个从MAP文件读取到的普通变量。
                            VarOnline varItem = new VarOnline();

                            // MAP地址位于下一行的第一个字段。
                            varItem.addr = parts[0];

                            // MAP变量名称来自.data.或.bss.之后的文本。
                            varItem.name = afterData;

                            // MAP不包含可靠类型信息，因此沿用原工程默认Uint16。
                            varItem.type = "Uint16";

                            // MAP当前没有解析变量字节数，零表示未知。
                            varItem.size = 0;

                            // MAP解析不会生成位域子成员。
                            varItem.isBitField = false;

                            // 记录变量来自MAP文件。
                            varItem.source = "MAP";

                            // 将变量加入结果列表。
                            varList.Add(varItem);

                            //LogMsg(varName + " " + varAddr + "\r\n");
                        }
                    }
                }
                else if (parts.Length > 1)
                {
                    //  如果本行有多个子串，且第2个子串是0x开头，且不为0x00000000，则第1个为变量名，第2个为地址
                    if (parts[1].StartsWith("0x") && parts[1] != "0x00000000")  
                    {
                        // 创建一个名称和地址位于同一行的MAP变量。
                        VarOnline varItem = new VarOnline();

                        // 第二个字段是变量地址。
                        varItem.addr = parts[1];

                        // 第一个字段是变量名称。
                        varItem.name = parts[0];

                        // MAP不包含可靠类型信息，因此沿用原工程默认Uint16。
                        varItem.type = "Uint16";

                        // MAP当前没有解析变量字节数，零表示未知。
                        varItem.size = 0;

                        // MAP解析不会生成位域子成员。
                        varItem.isBitField = false;

                        // 记录变量来自MAP文件。
                        varItem.source = "MAP";

                        // 将变量加入结果列表。
                        varList.Add(varItem);
                        //LogMsg(varName + " " + varAddr + "\r\n");
                    }
                }

                //LogMsg("\r\n");
            }

            return varList;
        }

        private List<VarOnlineExtend> GetVarList(List<VarOnline> allVarList)
        {
            List<VarOnlineExtend> varList = new List<VarOnlineExtend>();

            VarDebugSelect view = new VarDebugSelect();
            if (allVarList.Count == 0)
            {
                return varList;
            }
            view.UpdateVarListView(allVarList);
            view.ShowDialog();
            varList = view.mVarListExt;
            return varList;
        }

        private void btnVarSelect_Click(object sender, EventArgs e)
        {
            List<VarOnlineExtend> varList = GetVarList(mVarList);
            if (varList.Count != 0)
            {
                if (mVarListExt.Count + varList.Count > 32) // 最大不超过32个
                {
                    MessageBox.Show("变量太多，请删减！");
                }
                else
                {
                    mVarListExt.AddRange(varList);  //  新增变量列表
                    UpdateVarSelectWin();
                }
            }
        }

        private void UpdateVarSelectWin()
        {
            dataGridView1.Rows.Clear();

            foreach (VarOnlineExtend va in mVarListExt)
            {
                if (va.isSelected)
                {
                    DataGridViewRow newRow = new DataGridViewRow();
                    newRow.CreateCells(dataGridView1); // 关键：按网格结构创建单元格

                    // 2. 给每一列赋值
                    newRow.Cells[0].Value = va.name;
                    newRow.Cells[1].Value = va.resolved
                        ? va.addr
                        : "待匹配";

                    var comboColumn = dataGridView1.Columns[2] as DataGridViewComboBoxColumn;
                    if (comboColumn != null && !comboColumn.Items.Contains(va.type))
                    {
                        comboColumn.Items.Add(va.type);
                    }

                    newRow.Cells[2].Value = va.type;
                    newRow.Cells[3].Value = va.resolved
                        ? va.rdValue
                        : "变量未匹配";
                    newRow.Cells[4].Value = va.wrValue ?? "0";
                    newRow.Cells[5].Value = va.isNeedWrite;

                    // 未在当前ELF中严格匹配的变量使用浅红色提示，并禁止旧地址读写。
                    if (!va.resolved)
                    {
                        newRow.DefaultCellStyle.BackColor =
                            System.Drawing.Color.MistyRose;
                        newRow.Cells[1].ReadOnly = true;
                        newRow.Cells[4].ReadOnly = true;
                        newRow.Cells[5].ReadOnly = true;
                    }

                    // 3. 最后把这行添加到网格
                    dataGridView1.Rows.Add(newRow);

                    //byte[] cmd = VarDebugOnlineMakeSetAddrCmd(va);
                    //CommSendCmd(cmd);
                }
            }

            // 右侧添加状态变化后同步刷新左侧“+ / ✓”标记。
            RefreshResidentVarList();
        }

        public void UpdateVarListCombox()
        {
            DataGridViewComboBoxColumn comboColumn = dataGridView1.Columns[1] as DataGridViewComboBoxColumn;

            if (comboColumn != null)
            {
                comboColumn.Items.Clear();
                foreach (VarOnline var in mVarList)
                {
                    comboColumn.Items.Add(var.name);
                }
            }
        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            // 只在第3列数据类型（下拉框列）触发
            if (dataGridView1.CurrentCell.ColumnIndex == 2)
            {
                ComboBox combo = e.Control as ComboBox;
                if (combo != null)
                {
                    // 先移除旧事件，避免重复触发
                    combo.SelectedIndexChanged -= Combo_SelectedIndexChanged;
                    // 添加选中变化事件
                    combo.SelectedIndexChanged += Combo_SelectedIndexChanged;
                }
            }
        }

        // 下拉框选中变化时
        private void Combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox combo = sender as ComboBox;
            if (combo == null) return;

            string selectedVarType = combo.Text;

            int rowIndex = dataGridView1.CurrentCell.RowIndex;
            mVarListExt[rowIndex].type = selectedVarType;
            SaveVarDebugOnlineConfig();
        }

        private void ClearDataGridView()
        {
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();

            // 清空第2列下拉框的选项
            //if (dataGridView1.Columns[1] is DataGridViewComboBoxColumn combo)
            //{
            //    combo.Items.Clear();
            //}
        }
    }
    class SoftOscV2
    {
    }
}
