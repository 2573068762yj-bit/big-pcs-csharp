using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;

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
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            int clm = e.ColumnIndex;
            if (clm == 1 || clm == 2)
            {
                DataGridViewRow datRow = dataGridView1.Rows[row];
                string varAddr = datRow.Cells[1].Value.ToString();
                string selectedVarType = datRow.Cells[2].Value.ToString();

                mVarListExt[row].addr = varAddr;
                mVarListExt[row].type = selectedVarType;
                var item = mVarListExt[row];
                byte[] cmd = VarDebugOnlineMakeSetAddrCmd(item, (byte)row);
                CommSendCmd(cmd);
            }
            else if (clm == 4)
            {
                DataGridViewRow datRow = dataGridView1.Rows[row];
                string wrValue = datRow.Cells[clm].Value.ToString();
                mVarListExt[row].wrValue = wrValue;
                var item = mVarListExt[row];
                byte[] cmd = VarDebugOnlineMakeWriteCmd(item, (byte)row);
                CommSendCmd(cmd);
            }
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
                if (item.isSelected)
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
        }

        private void UpdateVarListFromUi()
        {
            mVarListExt.Clear();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[0].Value == null || row.Cells[1].Value == null || row.Cells[2].Value == null || row.Cells[3].Value == null)
                {
                    break;
                }
                VarOnlineExtend varRow = new VarOnlineExtend();
                varRow.isSelected = true;
                if (varRow.isSelected)
                {
                    varRow.name = row.Cells[0].Value.ToString();
                    varRow.addr = row.Cells[1].Value.ToString();
                    varRow.type = row.Cells[2].Value.ToString();
                    varRow.rdValue = row.Cells[3].Value.ToString();
                    varRow.wrValue = row.Cells[4].Value.ToString();
                    DataGridViewCheckBoxCell checkboxCell = dataGridView1.CurrentRow.Cells[5] as DataGridViewCheckBoxCell;
                    if (checkboxCell.Value.Equals(true))
                    {
                        varRow.isNeedWrite = true;
                    }
                    else
                    {
                        varRow.isNeedWrite = false;
                    }
                    mVarListExt.Add(varRow);
                }
            }
            if (mVarListExt.Count == 0)
            {
                MessageBox.Show("没有任何变量！");
            }
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
            if(channel >= 32) {
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
            if (channel >= 32)
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
            if (channel >= 32)
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
                if (item.isSelected)
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
            // 创建文件选择窗口。
            OpenFileDialog dialog = new OpenFileDialog();

            // 每次只允许导入一个调试文件。
            dialog.Multiselect = false;

            // 提示用户选择MAP或ELF文件。
            dialog.Title = "请选择MAP或ELF文件";

            // 当前功能只支持MAP和ELF，不额外加入AXF格式。
            dialog.Filter = "调试文件(*.map;*.elf)|*.map;*.elf|MAP文件(*.map)|*.map|ELF文件(*.elf)|*.elf";

            // 只有用户确认选择后才开始解析。
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    // 保存用户选择的完整文件路径。
                    string file = dialog.FileName;

                    // 先解析到临时列表，解析失败时保留上一次有效数据。
                    List<VarOnline> varList = AnalysisDebugFile(file);

                    // DWARF失败但ELF普通符号可用时，先说明回退原因再让用户选择变量。
                    if (!string.IsNullOrEmpty(ElfDwarfParser.LastWarning) &&
                        string.Equals(Path.GetExtension(file), ".elf",
                            StringComparison.OrdinalIgnoreCase))
                    {
                        MessageBox.Show(
                            ElfDwarfParser.LastWarning,
                            "ELF解析提示",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                    }

                    // 解析成功后再更新路径显示。
                    textBoxMapDir.Text = file;

                    // 使用新的变量列表替换旧列表。
                    mVarList = varList;

                    // 文件切换后清除之前选中的变量。
                    mVarListExt.Clear();

                    // 打开变量选择窗口，并加入本次选中的变量。
                    mVarListExt.AddRange(GetVarList(mVarList));

                    // 刷新在线变量表格。
                    UpdateVarSelectWin();

                }
                catch (Exception ex)
                {
                    // 将文件格式或读取错误显示给用户，避免程序直接退出。
                    MessageBox.Show(
                        "解析调试文件失败！\r\n" + ex.Message,
                        "文件解析",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
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
                    newRow.Cells[1].Value = va.addr;

                    var comboColumn = dataGridView1.Columns[2] as DataGridViewComboBoxColumn;
                    if (comboColumn != null && !comboColumn.Items.Contains(va.type))
                    {
                        comboColumn.Items.Add(va.type);
                    }

                    newRow.Cells[2].Value = va.type;
                    newRow.Cells[3].Value = va.rdValue;
                    newRow.Cells[4].Value = va.wrValue;
                    newRow.Cells[5].Value = va.isNeedWrite;

                    // 3. 最后把这行添加到网格
                    dataGridView1.Rows.Add(newRow);

                    //byte[] cmd = VarDebugOnlineMakeSetAddrCmd(va);
                    //CommSendCmd(cmd);
                }
            }
            
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
