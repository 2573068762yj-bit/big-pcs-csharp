using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace PcDebuger
{
    /// <summary>
    /// 表示左侧常驻变量树中的一个结构体、数组或标量节点。
    /// </summary>
    internal class ResidentVarTreeNode
    {
        // 保存当前层显示的短名称，例如成员名或“[0]”。
        public string label;

        // 保存从根变量开始的完整路径，用作展开状态的稳定标识。
        public string fullPath;

        // 保存当前节点的子节点。
        public List<ResidentVarTreeNode> children;

        // 叶子节点保存可以直接加入在线监视的变量。
        public VarOnline variable;

        // 保存当前分支下的标量叶子数量。
        public int leafCount;

        // 保存当前节点及其子节点中的最小地址，用于分支摘要显示。
        public uint firstAddress;

        public ResidentVarTreeNode()
        {
            children = new List<ResidentVarTreeNode>();
            firstAddress = UInt32.MaxValue;
        }
    }

    partial class MainForm
    {
        /// <summary>
        /// 初始化变量调试页左侧常驻搜索区，并复用原页面空白区域扩大变量表。
        /// </summary>
        private void InitResidentVarDebugView()
        {
            // 原页面底部预留区域没有实际功能，隐藏后把空间交给变量调试区。
            groupBox66.Visible = false;

            // 让变量区域占满设置栏下方的全部空间。
            tableLayoutPanel1.RowStyles[1] =
                new RowStyle(SizeType.Percent, 100F);
            tableLayoutPanel1.RowStyles[2] =
                new RowStyle(SizeType.Absolute, 0F);
            tableLayoutPanel1.SetRowSpan(groupBox60, 2);

            // 更新原有控件文字，使入口含义从“选择文件”变为“选择Debug目录”。
            groupBox61.Text = "Debug目录与读取设置";
            label343.Text = "Debug目录";
            btnOpenMap.Text = "选择目录";
            btnOpenMap.Width = 72;
            textBoxMapDir.ReadOnly = true;

            // 原“添加”按钮改为手工重新扫描按钮，变量添加改由左侧常驻列表完成。
            btnVarSelect.Click -= btnVarSelect_Click;
            btnVarSelect.Text = "重新扫描";
            btnVarSelect.Width = 72;
            btnVarSelect.Location = new Point(302, 43);
            btnVarSelect.Click += btnRescanDebugDirectory_Click;

            // 在线变量表由左侧添加，不再允许DataGridView自动产生空白输入行。
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = true;
            dataGridView1.Columns[0].ReadOnly = true;
            dataGridView1.Columns[1].ReadOnly = true;

            // 右侧空间变窄后按内容重要程度重新分配列宽。
            dataGridView1.Columns[0].FillWeight = 120F;
            dataGridView1.Columns[1].FillWeight = 82F;
            dataGridView1.Columns[2].FillWeight = 65F;
            dataGridView1.Columns[3].FillWeight = 58F;
            dataGridView1.Columns[4].FillWeight = 58F;
            dataGridView1.Columns[5].FillWeight = 45F;
            dataGridView1.KeyDown += dataGridView1_KeyDown;
            dataGridView1.CurrentCellDirtyStateChanged +=
                dataGridView1_CurrentCellDirtyStateChanged;
            dataGridView1.CellValueChanged +=
                dataGridView1_CellValueChangedForSave;

            // 创建左右分栏，左边浏览变量，右边保留原有在线读写表。
            mVarDebugSplitContainer = new SplitContainer();
            mVarDebugSplitContainer.Dock = DockStyle.Fill;
            mVarDebugSplitContainer.Orientation = Orientation.Vertical;
            mVarDebugSplitContainer.FixedPanel = FixedPanel.Panel1;

            // SplitContainer新建时默认宽度很小，必须先赋父容器尺寸再设置两侧最小宽度。
            mVarDebugSplitContainer.Size = groupBox60.ClientSize;
            mVarDebugSplitContainer.Panel1MinSize = 250;
            mVarDebugSplitContainer.Panel2MinSize = 320;
            mVarDebugSplitContainer.SplitterDistance = 290;

            // 先把原在线变量表从GroupBox移到右侧面板。
            groupBox60.Controls.Remove(dataGridView1);
            mVarDebugSplitContainer.Panel2.Controls.Add(dataGridView1);
            dataGridView1.Dock = DockStyle.Fill;

            // 创建左侧纵向布局。
            TableLayoutPanel leftLayout = new TableLayoutPanel();
            leftLayout.Dock = DockStyle.Fill;
            leftLayout.ColumnCount = 1;
            leftLayout.RowCount = 4;
            leftLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 42F));
            leftLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 31F));
            leftLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 31F));
            leftLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            // 状态栏显示当前ELF文件、解析数量和地址重绑定结果。
            mResidentVarStatusLabel = new Label();
            mResidentVarStatusLabel.Dock = DockStyle.Fill;
            mResidentVarStatusLabel.Text = "请选择CubeIDE的Debug目录";
            mResidentVarStatusLabel.AutoEllipsis = true;
            mResidentVarStatusLabel.TextAlign = ContentAlignment.MiddleLeft;
            mResidentVarStatusLabel.Padding = new Padding(4, 0, 4, 0);

            // 搜索框常驻在变量树上方，输入后立即筛选完整变量路径。
            mResidentVarSearchTextBox = new TextBox();
            mResidentVarSearchTextBox.Dock = DockStyle.Fill;
            mResidentVarSearchTextBox.Margin = new Padding(3, 4, 3, 3);
            mResidentVarSearchTextBox.TextChanged +=
                mResidentVarSearchTextBox_TextChanged;

            // 来源筛选保留“全部变量、ELF、MAP”三个选项。
            mResidentVarSourceComboBox = new ComboBox();
            mResidentVarSourceComboBox.Dock = DockStyle.Fill;
            mResidentVarSourceComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            mResidentVarSourceComboBox.Items.AddRange(
                new object[] { "全部变量", "ELF变量", "MAP变量" });
            mResidentVarSourceComboBox.SelectedIndex = 0;
            mResidentVarSourceComboBox.SelectedIndexChanged +=
                mResidentVarSourceComboBox_SelectedIndexChanged;

            // 使用DataGridView绘制可展开树和行内“+”按钮，保持与Rust版相近的操作方式。
            mResidentVarGrid = new DataGridView();
            mResidentVarGrid.Dock = DockStyle.Fill;
            mResidentVarGrid.AllowUserToAddRows = false;
            mResidentVarGrid.AllowUserToDeleteRows = false;
            mResidentVarGrid.AllowUserToResizeRows = false;
            mResidentVarGrid.ReadOnly = true;
            mResidentVarGrid.RowHeadersVisible = false;
            mResidentVarGrid.ColumnHeadersVisible = false;
            mResidentVarGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            mResidentVarGrid.BackgroundColor = SystemColors.Window;
            mResidentVarGrid.BorderStyle = BorderStyle.FixedSingle;
            mResidentVarGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            mResidentVarGrid.MultiSelect = false;
            mResidentVarGrid.CellClick += mResidentVarGrid_CellClick;
            mResidentVarGrid.CellDoubleClick += mResidentVarGrid_CellDoubleClick;

            // 第一列用两行文字显示路径、地址和类型。
            DataGridViewTextBoxColumn infoColumn = new DataGridViewTextBoxColumn();
            infoColumn.Name = "ResidentVarInfo";
            infoColumn.FillWeight = 86F;
            infoColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            infoColumn.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            mResidentVarGrid.Columns.Add(infoColumn);

            // 第二列显示添加按钮或已添加状态。
            DataGridViewButtonColumn addColumn = new DataGridViewButtonColumn();
            addColumn.Name = "ResidentVarAdd";
            addColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            addColumn.Width = 42;
            addColumn.FlatStyle = FlatStyle.Flat;
            addColumn.DefaultCellStyle.ForeColor = Color.FromArgb(7, 137, 139);
            addColumn.DefaultCellStyle.SelectionForeColor = Color.FromArgb(7, 137, 139);
            mResidentVarGrid.Columns.Add(addColumn);

            // 把左侧控件加入布局。
            leftLayout.Controls.Add(mResidentVarStatusLabel, 0, 0);
            leftLayout.Controls.Add(mResidentVarSearchTextBox, 0, 1);
            leftLayout.Controls.Add(mResidentVarSourceComboBox, 0, 2);
            leftLayout.Controls.Add(mResidentVarGrid, 0, 3);
            mVarDebugSplitContainer.Panel1.Controls.Add(leftLayout);

            // 将完整分栏放回原变量显示GroupBox。
            groupBox60.Text = "变量 / 数据通道";
            groupBox60.Controls.Add(mVarDebugSplitContainer);

            // 初始化用户展开节点集合。
            mExpandedResidentVarNodeSet =
                new HashSet<string>(StringComparer.OrdinalIgnoreCase);

            // 所有结构体和数组分支共用一个字体实例。
            mResidentVarBranchFont = new Font(
                mResidentVarGrid.Font,
                FontStyle.Bold);

            // 初始摘要会在第一次成功解析后被真实文件信息替换。
            mDebugScanSummary = "请选择CubeIDE的Debug目录";

            // 每两秒检查一次最新ELF是否已经被重新编译。
            mDebugFileChangedTimer = new System.Windows.Forms.Timer();
            mDebugFileChangedTimer.Interval = 2000;
            mDebugFileChangedTimer.Tick += mDebugFileChangedTimer_Tick;
        }

        /// <summary>
        /// 返回变量调试配置文件在当前用户本地应用数据目录中的路径。
        /// </summary>
        private string GetVarDebugOnlineConfigPath()
        {
            string configDirectory = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "PcDebuger");

            return Path.Combine(configDirectory, "var-debug-online.xml");
        }

        /// <summary>
        /// 恢复上次使用的Debug目录和在线变量，但不直接信任保存的旧地址。
        /// </summary>
        private void LoadVarDebugOnlineConfig()
        {
            string configPath = GetVarDebugOnlineConfigPath();

            // 首次启动没有配置文件属于正常情况。
            if (!File.Exists(configPath))
            {
                return;
            }

            try
            {
                XmlSerializer serializer =
                    new XmlSerializer(typeof(VarDebugOnlineConfig));

                using (FileStream stream = File.OpenRead(configPath))
                {
                    VarDebugOnlineConfig config =
                        serializer.Deserialize(stream) as VarDebugOnlineConfig;

                    if (config == null)
                    {
                        return;
                    }

                    mDebugDirectory = config.debugDirectory ?? string.Empty;
                    textBoxMapDir.Text = mDebugDirectory;

                    // 通信协议最多允许32个在线变量通道。
                    foreach (VarOnlineExtend item in
                        (config.variables ?? new List<VarOnlineExtend>()).Take(32))
                    {
                        // 软件重启后先标记为未匹配，必须由当前ELF重新确认地址。
                        item.resolved = false;
                        item.isSelected = true;
                        item.debugType = string.IsNullOrEmpty(item.debugType)
                            ? item.type
                            : item.debugType;
                        item.rdValue = string.IsNullOrEmpty(item.rdValue)
                            ? "0"
                            : item.rdValue;
                        item.wrValue = string.IsNullOrEmpty(item.wrValue)
                            ? "0"
                            : item.wrValue;
                        mVarListExt.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                // 配置损坏不能阻止主程序启动，仅在状态栏显示原因。
                mResidentVarStatusLabel.Text = "恢复变量配置失败：" + ex.Message;
            }
        }

        /// <summary>
        /// 保存Debug目录和在线变量身份，供下次启动重新匹配当前ELF。
        /// </summary>
        private void SaveVarDebugOnlineConfig()
        {
            try
            {
                string configPath = GetVarDebugOnlineConfigPath();
                string configDirectory = Path.GetDirectoryName(configPath);

                if (!Directory.Exists(configDirectory))
                {
                    Directory.CreateDirectory(configDirectory);
                }

                VarDebugOnlineConfig config = new VarDebugOnlineConfig();
                config.debugDirectory = mDebugDirectory ?? string.Empty;
                config.variables = mVarListExt;

                XmlSerializer serializer =
                    new XmlSerializer(typeof(VarDebugOnlineConfig));

                using (FileStream stream = File.Create(configPath))
                {
                    serializer.Serialize(stream, config);
                }
            }
            catch (Exception ex)
            {
                // 保存失败不应打断正在进行的通信，只更新非阻塞状态提示。
                if (mResidentVarStatusLabel != null)
                {
                    mResidentVarStatusLabel.Text = "保存变量配置失败：" + ex.Message;
                }
            }
        }

        /// <summary>
        /// 关闭软件前停止自动检查并保存当前变量表。
        /// </summary>
        private void MainForm_VarDebugOnlineFormClosing(
            object sender,
            FormClosingEventArgs e)
        {
            // 停止定时器，避免窗体释放过程中再次进入扫描回调。
            if (mDebugFileChangedTimer != null)
            {
                mDebugFileChangedTimer.Stop();
            }

            // 释放运行时创建的字体资源。
            if (mResidentVarBranchFont != null)
            {
                mResidentVarBranchFont.Dispose();
                mResidentVarBranchFont = null;
            }

            // 把用户在右侧表格中的最后编辑结果同步到模型。
            SyncVarListFromGrid();

            // 持久化Debug目录和变量身份信息。
            SaveVarDebugOnlineConfig();
        }

        /// <summary>
        /// 启动Debug目录自动检查。
        /// </summary>
        private void ConfigureDebugDirectoryWatcher()
        {
            if (mDebugFileChangedTimer == null)
            {
                return;
            }

            mDebugFileChangedTimer.Stop();
            mDebugFileChangedTimer.Start();
        }

        /// <summary>
        /// 每两秒只检查最新调试文件的路径、修改时间和大小。
        /// </summary>
        private void mDebugFileChangedTimer_Tick(object sender, EventArgs e)
        {
            CheckDebugDirectoryUpdate();
        }

        /// <summary>
        /// 手工重新扫描按钮忽略旧文件签名，强制读取当前ELF。
        /// </summary>
        private void btnRescanDebugDirectory_Click(object sender, EventArgs e)
        {
            StartDebugDirectoryScan(true);
        }

        /// <summary>
        /// 递归收集目录中的ELF和MAP文件，最大深度与Rust版保持为4层。
        /// </summary>
        private void CollectDebugFiles(
            string directory,
            int depth,
            List<string> elfFiles,
            List<string> mapFiles)
        {
            if (depth > 4 || !Directory.Exists(directory))
            {
                return;
            }

            try
            {
                foreach (string file in Directory.GetFiles(directory))
                {
                    string extension = Path.GetExtension(file);

                    if (string.Equals(extension, ".elf",
                        StringComparison.OrdinalIgnoreCase))
                    {
                        elfFiles.Add(file);
                    }
                    else if (string.Equals(extension, ".map",
                        StringComparison.OrdinalIgnoreCase))
                    {
                        mapFiles.Add(file);
                    }
                }

                foreach (string childDirectory in
                    Directory.GetDirectories(directory))
                {
                    CollectDebugFiles(
                        childDirectory,
                        depth + 1,
                        elfFiles,
                        mapFiles);
                }
            }
            catch (UnauthorizedAccessException)
            {
                // 个别无权限子目录直接跳过，不影响其他构建目录扫描。
            }
            catch (IOException)
            {
                // 编译器正在创建或替换目录时留给下一次两秒检查重试。
            }
        }

        /// <summary>
        /// 选择Debug目录中最后更新的ELF，并自动附加同名MAP作为补充。
        /// </summary>
        private string[] FindLatestDebugFiles()
        {
            List<string> elfFiles = new List<string>();
            List<string> mapFiles = new List<string>();

            CollectDebugFiles(
                mDebugDirectory,
                0,
                elfFiles,
                mapFiles);

            // ELF包含DWARF类型信息，因此始终作为主调试文件。
            string latestElf = elfFiles
                .OrderByDescending(item => File.GetLastWriteTimeUtc(item))
                .FirstOrDefault();

            if (!string.IsNullOrEmpty(latestElf))
            {
                List<string> selectedFiles = new List<string>();
                string sameNameMap = Path.ChangeExtension(latestElf, ".map");

                // MAP先解析，随后由ELF的可靠类型和成员结果覆盖。
                if (File.Exists(sameNameMap))
                {
                    selectedFiles.Add(sameNameMap);
                }

                selectedFiles.Add(latestElf);
                return selectedFiles.ToArray();
            }

            // 没有ELF时仍允许使用最新MAP浏览普通全局变量。
            string latestMap = mapFiles
                .OrderByDescending(item => File.GetLastWriteTimeUtc(item))
                .FirstOrDefault();

            return string.IsNullOrEmpty(latestMap)
                ? new string[0]
                : new string[] { latestMap };
        }

        /// <summary>
        /// 取得本次扫描中用于判断更新的主文件，优先选择ELF。
        /// </summary>
        private string GetPrimaryDebugFile(string[] files)
        {
            return files.FirstOrDefault(item =>
                string.Equals(Path.GetExtension(item), ".elf",
                    StringComparison.OrdinalIgnoreCase)) ??
                files.FirstOrDefault();
        }

        /// <summary>
        /// 检查主调试文件签名，只有重新构建后才启动昂贵的DWARF解析。
        /// </summary>
        private void CheckDebugDirectoryUpdate()
        {
            if (string.IsNullOrEmpty(mDebugDirectory) ||
                !Directory.Exists(mDebugDirectory) ||
                mIsDebugDirectoryScanning)
            {
                return;
            }

            string[] files = FindLatestDebugFiles();
            string primaryFile = GetPrimaryDebugFile(files);

            if (string.IsNullOrEmpty(primaryFile) || !File.Exists(primaryFile))
            {
                return;
            }

            FileInfo fileInfo = new FileInfo(primaryFile);
            bool isChanged = !string.Equals(
                    primaryFile,
                    mLoadedDebugImagePath,
                    StringComparison.OrdinalIgnoreCase) ||
                fileInfo.LastWriteTimeUtc != mLoadedDebugImageWriteTimeUtc ||
                fileInfo.Length != mLoadedDebugImageLength;

            if (isChanged)
            {
                StartDebugDirectoryScan(false);
            }
        }

        /// <summary>
        /// 在后台解析最新调试文件，避免大型ELF阻塞WinForms消息循环。
        /// </summary>
        private void StartDebugDirectoryScan(bool showErrorMessage)
        {
            if (string.IsNullOrEmpty(mDebugDirectory) ||
                !Directory.Exists(mDebugDirectory))
            {
                if (showErrorMessage)
                {
                    MessageBox.Show("请选择有效的Debug目录！");
                }
                return;
            }

            // 已经扫描时只登记一次补充扫描，避免并发访问解析器静态状态。
            if (mIsDebugDirectoryScanning)
            {
                mIsDebugDirectoryScanPending = true;
                return;
            }

            string[] debugFiles = FindLatestDebugFiles();
            string primaryFile = GetPrimaryDebugFile(debugFiles);

            if (string.IsNullOrEmpty(primaryFile))
            {
                mResidentVarStatusLabel.Text =
                    "Debug目录中没有找到ELF或MAP文件";

                if (showErrorMessage)
                {
                    MessageBox.Show(
                        "Debug目录中没有找到.elf或.map文件。\r\n" +
                        "请先完成STM32 Debug构建。",
                        "扫描Debug目录",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
                return;
            }

            FileInfo primaryInfo = new FileInfo(primaryFile);

            // 与参考实现一致，拒绝一次性载入超过128 MiB的异常调试文件。
            if (primaryInfo.Length > 128L * 1024L * 1024L)
            {
                mResidentVarStatusLabel.Text =
                    "调试文件超过128 MiB，已拒绝载入";

                if (showErrorMessage)
                {
                    MessageBox.Show(
                        "调试文件超过128 MiB，已拒绝载入。",
                        "扫描Debug目录",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
                return;
            }

            mIsDebugDirectoryScanning = true;
            mIsDebugDirectoryScanPending = false;
            mResidentVarStatusLabel.Text =
                "正在读取ELF/MAP与DWARF类型……";
            btnReadVar.Enabled = false;

            // 地址刷新期间暂停轮询，防止向旧地址继续发送读取请求。
            if (mReadPollingStarted)
            {
                mReadPollingStarted = false;
                mResumePollingAfterDebugScan = true;
                btnReadVar.Text = "读取";
            }

            // 从发现新调试文件开始就禁止继续使用旧地址；解析成功后再逐项恢复。
            foreach (VarOnlineExtend item in mVarListExt)
            {
                item.resolved = false;
            }
            UpdateVarSelectWin();
            mResidentVarStatusLabel.Text =
                "正在读取ELF/MAP与DWARF类型……";

            TaskScheduler uiScheduler =
                TaskScheduler.FromCurrentSynchronizationContext();

            Task.Factory.StartNew(delegate
            {
                string warning;
                List<VarOnline> variables =
                    AnalysisDebugFiles(debugFiles, out warning);

                VarDebugDirectoryScanResult result =
                    new VarDebugDirectoryScanResult();
                result.files = debugFiles;
                result.variables = variables;
                result.warning = warning;
                return result;
            }).ContinueWith(task =>
            {
                mIsDebugDirectoryScanning = false;
                btnReadVar.Enabled = true;

                if (task.IsFaulted)
                {
                    Exception error = task.Exception == null
                        ? null
                        : task.Exception.GetBaseException();
                    string message = error == null
                        ? "未知错误"
                        : error.Message;
                    mResidentVarStatusLabel.Text =
                        "读取调试文件失败，稍后自动重试：" + message;

                    if (showErrorMessage)
                    {
                        MessageBox.Show(
                            "解析Debug目录失败！\r\n" + message,
                            "扫描Debug目录",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
                else
                {
                    ApplyDebugDirectoryScanResult(
                        task.Result,
                        primaryInfo);
                }

                // 自动更新前正在轮询时，只在仍有有效变量的情况下恢复。
                if (mResumePollingAfterDebugScan &&
                    mVarListExt.Any(item => item.resolved))
                {
                    mResumePollingAfterDebugScan = false;
                    mReadPollingStarted = true;
                    btnReadVar.Text = "停止";
                    VarDebugOnlineReadPollingStart();
                }

                // 扫描期间文件再次变化时立即补扫一次。
                if (mIsDebugDirectoryScanPending)
                {
                    mIsDebugDirectoryScanPending = false;
                    StartDebugDirectoryScan(false);
                }
            }, uiScheduler);
        }

        /// <summary>
        /// 在UI线程应用解析结果，并按稳定身份重新绑定已保存变量的地址。
        /// </summary>
        private void ApplyDebugDirectoryScanResult(
            VarDebugDirectoryScanResult result,
            FileInfo primaryInfo)
        {
            mVarList = result.variables ?? new List<VarOnline>();
            mLoadedDebugImagePath = primaryInfo.FullName;
            mLoadedDebugImageWriteTimeUtc = primaryInfo.LastWriteTimeUtc;
            mLoadedDebugImageLength = primaryInfo.Length;

            int updatedCount;
            int unresolvedCount;
            RebindOnlineVariables(out updatedCount, out unresolvedCount);

            UpdateVarSelectWin();
            RefreshResidentVarList();
            SaveVarDebugOnlineConfig();

            string summary = string.Format(
                "{0} · {1}个变量 · 更新{2}个地址",
                Path.GetFileName(primaryInfo.FullName),
                mVarList.Count,
                updatedCount);

            if (unresolvedCount > 0)
            {
                summary += " · " + unresolvedCount + "个未匹配";
            }

            mResidentVarStatusLabel.Text = summary;
            mDebugScanSummary = summary;

            // 非致命DWARF提示只写入原工程日志，避免自动刷新时反复弹窗。
            if (!string.IsNullOrEmpty(result.warning))
            {
                LogMsg("Debug目录扫描提示：" + result.warning + "\r\n");
            }
        }

        /// <summary>
        /// 按完整路径、变量大小和原始类型重新绑定当前ELF中的变量。
        /// </summary>
        private void RebindOnlineVariables(
            out int updatedCount,
            out int unresolvedCount)
        {
            updatedCount = 0;
            unresolvedCount = 0;

            foreach (VarOnlineExtend saved in mVarListExt)
            {
                List<VarOnline> candidates = mVarList.Where(item =>
                    string.Equals(item.name, saved.name,
                        StringComparison.OrdinalIgnoreCase) &&
                    !item.isBitField).ToList();

                // 旧配置没有大小信息时允许按名称迁移；新配置必须保持大小一致。
                if (saved.size > 0)
                {
                    candidates = candidates.Where(item =>
                        item.size == saved.size).ToList();
                }

                // 使用调试文件原始类型匹配，不受用户手工选择的协议类型影响。
                if (!string.IsNullOrEmpty(saved.debugType))
                {
                    candidates = candidates.Where(item =>
                        string.Equals(item.type, saved.debugType,
                            StringComparison.OrdinalIgnoreCase)).ToList();
                }

                // 同名候选存在多个时优先选择ELF中的可靠成员。
                VarOnline matched = candidates
                    .OrderByDescending(item =>
                        string.Equals(item.source, "ELF",
                            StringComparison.OrdinalIgnoreCase))
                    .FirstOrDefault();

                if (matched == null)
                {
                    saved.resolved = false;
                    unresolvedCount++;
                    continue;
                }

                if (!string.IsNullOrEmpty(saved.addr) &&
                    !string.Equals(saved.addr, matched.addr,
                        StringComparison.OrdinalIgnoreCase))
                {
                    updatedCount++;
                }

                saved.addr = matched.addr;
                saved.size = matched.size;
                saved.debugType = matched.type;
                saved.type = string.IsNullOrEmpty(saved.type)
                    ? matched.type
                    : saved.type;
                saved.resolved = true;
            }
        }

        /// <summary>
        /// 根据“.”和数组下标拆分完整变量路径。
        /// </summary>
        private List<string> SplitResidentVarPath(string path)
        {
            List<string> tokens = new List<string>();

            if (string.IsNullOrEmpty(path))
            {
                return tokens;
            }

            int index = 0;

            while (index < path.Length)
            {
                if (path[index] == '.')
                {
                    index++;
                    continue;
                }

                int start = index;

                if (path[index] == '[')
                {
                    int closeIndex = path.IndexOf(']', index);
                    index = closeIndex < 0
                        ? path.Length
                        : closeIndex + 1;
                }
                else
                {
                    while (index < path.Length &&
                        path[index] != '.' &&
                        path[index] != '[')
                    {
                        index++;
                    }
                }

                if (index > start)
                {
                    tokens.Add(path.Substring(start, index - start));
                }
            }

            return tokens;
        }

        /// <summary>
        /// 从筛选后的扁平叶子变量建立结构体和数组树。
        /// </summary>
        private List<ResidentVarTreeNode> BuildResidentVarTree(
            IEnumerable<VarOnline> variables)
        {
            List<ResidentVarTreeNode> roots =
                new List<ResidentVarTreeNode>();
            Dictionary<string, ResidentVarTreeNode> rootMap =
                new Dictionary<string, ResidentVarTreeNode>(
                    StringComparer.OrdinalIgnoreCase);

            foreach (VarOnline variable in variables)
            {
                List<string> tokens = SplitResidentVarPath(variable.name);

                if (tokens.Count == 0)
                {
                    continue;
                }

                ResidentVarTreeNode root;

                if (!rootMap.TryGetValue(tokens[0], out root))
                {
                    root = new ResidentVarTreeNode();
                    root.label = tokens[0];
                    root.fullPath = tokens[0];
                    rootMap.Add(tokens[0], root);
                    roots.Add(root);
                }

                ResidentVarTreeNode current = root;
                uint address;
                TryParseResidentVarAddress(variable.addr, out address);
                current.firstAddress = Math.Min(current.firstAddress, address);

                for (int tokenIndex = 1;
                    tokenIndex < tokens.Count;
                    tokenIndex++)
                {
                    string token = tokens[tokenIndex];
                    ResidentVarTreeNode child = current.children.FirstOrDefault(
                        item => string.Equals(item.label, token,
                            StringComparison.OrdinalIgnoreCase));

                    if (child == null)
                    {
                        child = new ResidentVarTreeNode();
                        child.label = token;
                        child.fullPath = current.fullPath +
                            (token.StartsWith("[") ? token : "." + token);
                        current.children.Add(child);
                    }

                    child.firstAddress = Math.Min(child.firstAddress, address);
                    current = child;
                }

                current.variable = variable;
            }

            foreach (ResidentVarTreeNode root in roots)
            {
                CountResidentVarLeaves(root);
            }

            return roots.OrderBy(item => item.label,
                StringComparer.CurrentCultureIgnoreCase).ToList();
        }

        /// <summary>
        /// 递归统计分支叶子数量。
        /// </summary>
        private int CountResidentVarLeaves(ResidentVarTreeNode node)
        {
            int count = node.variable == null ? 0 : 1;

            foreach (ResidentVarTreeNode child in node.children)
            {
                count += CountResidentVarLeaves(child);
            }

            node.leafCount = count;
            return count;
        }

        /// <summary>
        /// 尝试把“0x”地址字符串转换为32位地址。
        /// </summary>
        private bool TryParseResidentVarAddress(string text, out uint address)
        {
            address = 0;

            if (string.IsNullOrEmpty(text))
            {
                return false;
            }

            string value = text.Trim();

            if (value.StartsWith("0x", StringComparison.OrdinalIgnoreCase))
            {
                value = value.Substring(2);
            }

            return UInt32.TryParse(
                value,
                System.Globalization.NumberStyles.HexNumber,
                System.Globalization.CultureInfo.InvariantCulture,
                out address);
        }

        /// <summary>
        /// 按搜索词和来源筛选变量并刷新左侧常驻树。
        /// </summary>
        private void RefreshResidentVarList()
        {
            if (mResidentVarGrid == null)
            {
                return;
            }

            string searchText = mResidentVarSearchTextBox.Text.Trim();
            string[] keywords = searchText.Split(
                new char[] { ' ', '\t' },
                StringSplitOptions.RemoveEmptyEntries);
            string sourceFilter = mResidentVarSourceComboBox.SelectedItem as string;

            IEnumerable<VarOnline> filtered = mVarList.Where(item =>
            {
                if (sourceFilter == "ELF变量" &&
                    !string.Equals(item.source, "ELF",
                        StringComparison.OrdinalIgnoreCase))
                {
                    return false;
                }

                if (sourceFilter == "MAP变量" &&
                    !string.Equals(item.source, "MAP",
                        StringComparison.OrdinalIgnoreCase))
                {
                    return false;
                }

                string searchable = (item.name ?? string.Empty) + " " +
                    (item.addr ?? string.Empty) + " " +
                    (item.type ?? string.Empty);

                return keywords.All(keyword => searchable.IndexOf(
                    keyword,
                    StringComparison.OrdinalIgnoreCase) >= 0);
            });

            List<ResidentVarTreeNode> roots =
                BuildResidentVarTree(filtered);
            bool forceOpen = keywords.Length > 0;
            int displayedCount = 0;

            mResidentVarGrid.SuspendLayout();
            mResidentVarGrid.Rows.Clear();

            try
            {
                foreach (ResidentVarTreeNode root in roots)
                {
                    AppendResidentVarNode(
                        root,
                        0,
                        forceOpen,
                        ref displayedCount);

                    if (displayedCount >= MAX_RESIDENT_VAR_COUNT)
                    {
                        break;
                    }
                }
            }
            finally
            {
                mResidentVarGrid.ResumeLayout();
            }

            if (mVarList.Count > 0 && roots.Count == 0)
            {
                mResidentVarStatusLabel.Text = "没有匹配的变量或结构体成员";
            }
            else if (!string.IsNullOrEmpty(mDebugScanSummary))
            {
                // 搜索重新命中或清空后恢复最近一次扫描摘要。
                mResidentVarStatusLabel.Text = mDebugScanSummary;
            }
        }

        /// <summary>
        /// 递归把一个变量树节点转换成DataGridView行。
        /// </summary>
        private void AppendResidentVarNode(
            ResidentVarTreeNode node,
            int depth,
            bool forceOpen,
            ref int displayedCount)
        {
            if (displayedCount >= MAX_RESIDENT_VAR_COUNT)
            {
                return;
            }

            bool isBranch = node.children.Count > 0;
            bool isOpen = forceOpen ||
                mExpandedResidentVarNodeSet.Contains(node.fullPath);
            string indent = new string(' ', depth * 3);
            string title = indent;

            if (isBranch)
            {
                title += (isOpen ? "▼ " : "▶ ") + node.label;
            }
            else
            {
                title += node.label;
            }

            string metadata;

            if (node.variable != null && !isBranch)
            {
                metadata = string.Format(
                    "{0} · {1}{2}",
                    node.variable.addr,
                    node.variable.type,
                    node.variable.isBitField ? "（位域）" : string.Empty);
            }
            else
            {
                string address = node.firstAddress == UInt32.MaxValue
                    ? ""
                    : "0x" + node.firstAddress.ToString("X8") + " · ";
                metadata = address + node.leafCount + " 项";
            }

            int rowIndex = mResidentVarGrid.Rows.Add(
                title + Environment.NewLine + indent + metadata,
                string.Empty);
            DataGridViewRow row = mResidentVarGrid.Rows[rowIndex];
            row.Tag = node;
            row.Height = 42;

            if (isBranch)
            {
                row.DefaultCellStyle.BackColor = Color.FromArgb(242, 248, 250);
                row.DefaultCellStyle.Font = mResidentVarBranchFont;
                row.Cells[1].Value = string.Empty;
            }
            else if (node.variable != null)
            {
                bool alreadyAdded = mVarListExt.Any(item =>
                    string.Equals(item.name, node.variable.name,
                        StringComparison.OrdinalIgnoreCase));

                row.Cells[1].Value = node.variable.isBitField
                    ? "—"
                    : alreadyAdded ? "✓" : "+";
                row.Cells[1].Style.Alignment =
                    DataGridViewContentAlignment.MiddleCenter;
            }

            displayedCount++;

            if (isBranch && isOpen)
            {
                foreach (ResidentVarTreeNode child in node.children)
                {
                    AppendResidentVarNode(
                        child,
                        depth + 1,
                        forceOpen,
                        ref displayedCount);

                    if (displayedCount >= MAX_RESIDENT_VAR_COUNT)
                    {
                        break;
                    }
                }
            }
        }

        private void mResidentVarSearchTextBox_TextChanged(
            object sender,
            EventArgs e)
        {
            RefreshResidentVarList();
        }

        private void mResidentVarSourceComboBox_SelectedIndexChanged(
            object sender,
            EventArgs e)
        {
            RefreshResidentVarList();
        }

        /// <summary>
        /// 单击分支行展开/收起，单击“+”把叶子变量加入在线表。
        /// </summary>
        private void mResidentVarGrid_CellClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 ||
                e.RowIndex >= mResidentVarGrid.Rows.Count)
            {
                return;
            }

            ResidentVarTreeNode node =
                mResidentVarGrid.Rows[e.RowIndex].Tag as ResidentVarTreeNode;

            if (node == null)
            {
                return;
            }

            if (node.children.Count > 0 && e.ColumnIndex == 0)
            {
                if (mExpandedResidentVarNodeSet.Contains(node.fullPath))
                {
                    mExpandedResidentVarNodeSet.Remove(node.fullPath);
                }
                else
                {
                    mExpandedResidentVarNodeSet.Add(node.fullPath);
                }

                RefreshResidentVarList();
                return;
            }

            if (node.variable != null && e.ColumnIndex == 1)
            {
                AddResidentOnlineVariable(node.variable);
            }
        }

        /// <summary>
        /// 双击叶子信息区域也可以快速添加变量。
        /// </summary>
        private void mResidentVarGrid_CellDoubleClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != 0)
            {
                return;
            }

            ResidentVarTreeNode node =
                mResidentVarGrid.Rows[e.RowIndex].Tag as ResidentVarTreeNode;

            if (node != null &&
                node.children.Count == 0 &&
                node.variable != null)
            {
                AddResidentOnlineVariable(node.variable);
            }
        }

        /// <summary>
        /// 将一个可直接读取的标量叶子加入右侧在线变量表。
        /// </summary>
        private void AddResidentOnlineVariable(VarOnline variable)
        {
            if (variable.isBitField ||
                VarDebugOnlineGetVarType(variable.type) == 0)
            {
                MessageBox.Show(
                    "该成员是位域或当前通信协议不支持此标量类型。",
                    "添加在线变量",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            if (mVarListExt.Any(item => string.Equals(
                item.name,
                variable.name,
                StringComparison.OrdinalIgnoreCase)))
            {
                return;
            }

            if (mVarListExt.Count >= 32)
            {
                MessageBox.Show("在线变量最多只能添加32个通道！");
                return;
            }

            VarOnlineExtend newItem = new VarOnlineExtend();
            newItem.isSelected = true;
            newItem.isNeedWrite = false;
            newItem.name = variable.name;
            newItem.addr = variable.addr;
            newItem.type = string.IsNullOrEmpty(variable.type)
                ? "Uint16"
                : variable.type;
            newItem.debugType = variable.type;
            newItem.size = variable.size;
            newItem.rdValue = "0";
            newItem.wrValue = "0";
            newItem.resolved = true;
            mVarListExt.Add(newItem);

            UpdateVarSelectWin();
            RefreshResidentVarList();
            SaveVarDebugOnlineConfig();
        }

        /// <summary>
        /// 在右侧选中一行或多行后按Delete键即可移除变量。
        /// </summary>
        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Delete ||
                dataGridView1.SelectedRows.Count == 0)
            {
                return;
            }

            List<int> rowIndexes = dataGridView1.SelectedRows
                .Cast<DataGridViewRow>()
                .Select(row => row.Index)
                .Where(index => index >= 0 && index < mVarListExt.Count)
                .OrderByDescending(index => index)
                .ToList();

            foreach (int rowIndex in rowIndexes)
            {
                mVarListExt.RemoveAt(rowIndex);
            }

            UpdateVarSelectWin();
            RefreshResidentVarList();
            SaveVarDebugOnlineConfig();
            e.Handled = true;
        }

        /// <summary>
        /// 复选框单击后立即提交值，使“选中写”状态能够马上保存。
        /// </summary>
        private void dataGridView1_CurrentCellDirtyStateChanged(
            object sender,
            EventArgs e)
        {
            if (dataGridView1.IsCurrentCellDirty &&
                dataGridView1.CurrentCell != null &&
                dataGridView1.CurrentCell.ColumnIndex == 5)
            {
                dataGridView1.CommitEdit(
                    DataGridViewDataErrorContexts.Commit);
            }
        }

        /// <summary>
        /// “选中写”变化后同步模型并立即持久化。
        /// </summary>
        private void dataGridView1_CellValueChangedForSave(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 ||
                e.RowIndex >= mVarListExt.Count ||
                e.ColumnIndex != 5)
            {
                return;
            }

            mVarListExt[e.RowIndex].isNeedWrite = Convert.ToBoolean(
                dataGridView1.Rows[e.RowIndex].Cells[5].Value ?? false);
            SaveVarDebugOnlineConfig();
        }

        /// <summary>
        /// 把右侧表格可编辑字段同步回模型，保存前调用。
        /// </summary>
        private void SyncVarListFromGrid()
        {
            int count = Math.Min(dataGridView1.Rows.Count, mVarListExt.Count);

            for (int index = 0; index < count; index++)
            {
                DataGridViewRow row = dataGridView1.Rows[index];
                VarOnlineExtend item = mVarListExt[index];

                if (row.Cells[1].Value != null && item.resolved)
                {
                    item.addr = row.Cells[1].Value.ToString();
                }

                if (row.Cells[2].Value != null)
                {
                    item.type = row.Cells[2].Value.ToString();
                }

                if (row.Cells[4].Value != null)
                {
                    item.wrValue = row.Cells[4].Value.ToString();
                }

                item.isNeedWrite = Convert.ToBoolean(
                    row.Cells[5].Value ?? false);
            }
        }
    }
}
