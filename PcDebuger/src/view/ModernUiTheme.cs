using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace PcDebuger
{
    /// <summary>
    /// 仅负责主窗体的现代化布局和视觉样式。
    /// 本文件不处理通信、协议、ELF解析或业务状态，所有按钮仍使用原有C#事件。
    /// </summary>
    partial class MainForm
    {
        // Rust参考界面的主强调色。
        private readonly Color mModernAccentColor =
            Color.FromArgb(27, 172, 173);

        // 鼠标悬停和选中区域使用的浅青色。
        private readonly Color mModernAccentLightColor =
            Color.FromArgb(234, 247, 247);

        // 页面工作区背景色。
        private readonly Color mModernWorkspaceColor =
            Color.FromArgb(238, 242, 245);

        // 卡片、表格和主内容区域背景色。
        private readonly Color mModernPanelColor = Color.White;

        // 控件边框和分隔线颜色。
        private readonly Color mModernBorderColor =
            Color.FromArgb(203, 213, 220);

        // 主文字颜色。
        private readonly Color mModernTextColor =
            Color.FromArgb(38, 55, 70);

        // 次级说明文字颜色。
        private readonly Color mModernMutedTextColor =
            Color.FromArgb(112, 132, 148);

        // 保存运行时创建的顶部应用栏。
        private Panel mModernAppBar;

        // 保存顶部“隐藏/显示通信”按钮。
        private Button mModernToggleCommButton;

        // 保存顶部状态标签。
        private Label mModernCoreStatusLabel;

        // 保存左侧窄导航栏。
        private Panel mModernNavigationRail;

        // 保存导航按钮及其对应的原有TabPage。
        private Button[] mModernNavigationButtons;
        private TabPage[] mModernNavigationPages;

        // 标记左侧旧通信面板当前是否显示。
        private bool mIsModernCommPanelVisible;

        /// <summary>
        /// 初始化参考Rust版本的WinForms工作台外观。
        /// </summary>
        private void InitModernUi()
        {
            // 主窗体使用更适合工作台的默认尺寸和最小尺寸。
            this.Text = "PCS Debug Studio";
            this.BackColor = mModernWorkspaceColor;
            this.Font = new Font("Microsoft YaHei UI", 9F, FontStyle.Regular);
            this.MinimumSize = new Size(1180, 800);
            this.Size = new Size(1280, 860);

            // 顶部应用栏需要占用独立空间，因此取消原左右区域的Dock布局。
            groupBox1.Dock = DockStyle.None;
            tabControl2.Dock = DockStyle.None;

            // 更新核心页面标题，但不移动已经创建句柄的旧版TabPage，避免破坏原页面索引。
            tabPage10.Text = "在线变量";
            tabPage3.Text = "Wave · 软件示波器";
            tabControl2.SelectedTab = tabPage10;

            // 创建顶部白色应用栏。
            CreateModernAppBar();

            // 创建与参考版相同思路的左侧窄导航栏。
            CreateModernNavigationRail();

            // 递归应用基础主题，原控件名称和事件绑定保持不变。
            ApplyModernTheme(this);

            // 对核心区域应用更有针对性的样式。
            StyleModernTabControl(tabControl1);
            StyleModernTabControl(tabControl2);
            StyleModernDataGrid(dataGridView1);
            StyleModernDataGrid(mResidentVarGrid);
            StyleModernChart(WaveChart);
            StyleModernLogTextBox(txtReceivedData);
            ApplyModernAccentButtons();

            // 根据主工作区宽度重新排列Debug目录和读取设置，避免旧绝对坐标互相遮挡。
            groupBox61.Resize += groupBox61_ModernResize;
            LayoutModernVarDebugToolbar();

            // 启动时默认收起旧通信配置，让变量和波形工作区占据主要空间。
            mIsModernCommPanelVisible = false;
            mModernToggleCommButton.Text = "显示通信面板";

            // 首次布局并在窗体尺寸变化时保持应用栏和内容区对齐。
            PerformModernMainLayout();
            this.Resize += MainForm_ModernUiResize;
        }

        /// <summary>
        /// 创建顶部品牌、菜单、后端状态和通信面板开关。
        /// </summary>
        private void CreateModernAppBar()
        {
            mModernAppBar = new Panel();
            mModernAppBar.Name = "modernAppBar";
            mModernAppBar.BackColor = mModernPanelColor;
            mModernAppBar.Height = 50;

            // 品牌图标使用文本绘制，避免引入额外图片资源。
            Label logoLabel = new Label();
            logoLabel.AutoSize = false;
            logoLabel.Location = new Point(14, 7);
            logoLabel.Size = new Size(34, 35);
            logoLabel.Text = "◇";
            logoLabel.Font = new Font("Segoe UI Symbol", 24F, FontStyle.Regular);
            logoLabel.ForeColor = mModernAccentColor;
            logoLabel.TextAlign = ContentAlignment.MiddleCenter;

            // 显示软件名称。
            Label brandLabel = new Label();
            brandLabel.AutoSize = true;
            brandLabel.Location = new Point(51, 9);
            brandLabel.Text = "PCS Debug Studio";
            brandLabel.Font = new Font(
                "Microsoft YaHei UI",
                11F,
                FontStyle.Bold);
            brandLabel.ForeColor = Color.FromArgb(10, 45, 73);

            // 显示当前实现方式，明确前端样式变化不影响C#后端。
            Label subtitleLabel = new Label();
            subtitleLabel.AutoSize = true;
            subtitleLabel.Location = new Point(52, 29);
            subtitleLabel.Text = "C# WinForms 工作台";
            subtitleLabel.Font = new Font(
                "Microsoft YaHei UI",
                7.5F,
                FontStyle.Regular);
            subtitleLabel.ForeColor = mModernMutedTextColor;

            // 菜单先作为模块提示，原有实际功能仍由页面内按钮执行。
            Label menuLabel = new Label();
            menuLabel.AutoSize = true;
            menuLabel.Location = new Point(225, 18);
            menuLabel.Text = "文件　连接　视图　数据　工具　帮助";
            menuLabel.ForeColor = Color.FromArgb(91, 105, 116);

            // 右侧使用流布局，窗口缩放时自动贴紧右边。
            FlowLayoutPanel rightPanel = new FlowLayoutPanel();
            rightPanel.Dock = DockStyle.Right;
            rightPanel.Width = 270;
            rightPanel.FlowDirection = FlowDirection.RightToLeft;
            rightPanel.WrapContents = false;
            rightPanel.Padding = new Padding(0, 9, 12, 0);
            rightPanel.BackColor = mModernPanelColor;

            // 后端状态用于说明当前仍然运行原C#核心。
            mModernCoreStatusLabel = new Label();
            mModernCoreStatusLabel.AutoSize = false;
            mModernCoreStatusLabel.Size = new Size(92, 30);
            mModernCoreStatusLabel.Text = "● C# 后端";
            mModernCoreStatusLabel.TextAlign = ContentAlignment.MiddleCenter;
            mModernCoreStatusLabel.ForeColor = Color.FromArgb(11, 158, 114);

            // 折叠通信区后可为变量或波形页面释放更多横向空间。
            mModernToggleCommButton = new Button();
            mModernToggleCommButton.Size = new Size(112, 30);
            mModernToggleCommButton.Text = "隐藏通信面板";
            mModernToggleCommButton.Click +=
                mModernToggleCommButton_Click;

            rightPanel.Controls.Add(mModernCoreStatusLabel);
            rightPanel.Controls.Add(mModernToggleCommButton);
            mModernAppBar.Controls.Add(logoLabel);
            mModernAppBar.Controls.Add(brandLabel);
            mModernAppBar.Controls.Add(subtitleLabel);
            mModernAppBar.Controls.Add(menuLabel);
            mModernAppBar.Controls.Add(rightPanel);

            // 分隔线与Rust版应用栏底边一致。
            Panel bottomBorder = new Panel();
            bottomBorder.Dock = DockStyle.Bottom;
            bottomBorder.Height = 1;
            bottomBorder.BackColor = mModernBorderColor;
            mModernAppBar.Controls.Add(bottomBorder);

            this.Controls.Add(mModernAppBar);
            mModernAppBar.BringToFront();
        }

        /// <summary>
        /// 创建左侧模块导航栏，并直接切换现有TabPage。
        /// </summary>
        private void CreateModernNavigationRail()
        {
            mModernNavigationRail = new Panel();
            mModernNavigationRail.Name = "modernNavigationRail";
            mModernNavigationRail.BackColor = Color.FromArgb(248, 250, 251);

            // 导航顺序参考日常调试流程，所有页面仍是设计器中原来的页面实例。
            mModernNavigationPages = new TabPage[]
            {
                tabPage10,
                tabPage3,
                tabPage4,
                tabPage5,
                tabPage6,
                tabPage7,
                tabPage8,
                tabPage9
            };

            string[] navigationText = new string[]
            {
                "变量",
                "波形",
                "PCS",
                "下载",
                "日志",
                "记录",
                "BMS",
                "备电"
            };

            string[] navigationToolTip = new string[]
            {
                "在线变量",
                "软件示波器",
                "PCS在线调试",
                "文件下载",
                "日志导出",
                "模拟量记录",
                "BMS在线调试",
                "备电盒在线调试"
            };

            ToolTip toolTip = new ToolTip();
            mModernNavigationButtons =
                new Button[mModernNavigationPages.Length];

            for (int index = 0;
                index < mModernNavigationPages.Length;
                index++)
            {
                Button button = new Button();
                button.Name = "modernNavigationButton" + index;
                button.Tag = mModernNavigationPages[index];
                button.Text = navigationText[index];
                button.Size = new Size(44, 48);
                button.Location = new Point(0, 8 + index * 50);
                button.FlatStyle = FlatStyle.Flat;
                button.FlatAppearance.BorderSize = 0;
                button.Font = new Font(
                    "Microsoft YaHei UI",
                    8F,
                    FontStyle.Regular);
                button.ForeColor = mModernMutedTextColor;
                button.BackColor = Color.Transparent;
                button.Cursor = Cursors.Hand;
                button.Click += ModernNavigationButton_Click;
                toolTip.SetToolTip(button, navigationToolTip[index]);
                mModernNavigationRail.Controls.Add(button);
                mModernNavigationButtons[index] = button;
            }

            // 在导航栏右边绘制一条浅色分隔线。
            Panel railBorder = new Panel();
            railBorder.Dock = DockStyle.Right;
            railBorder.Width = 1;
            railBorder.BackColor = mModernBorderColor;
            mModernNavigationRail.Controls.Add(railBorder);

            tabControl2.SelectedIndexChanged +=
                tabControl2_ModernSelectedIndexChanged;
            this.Controls.Add(mModernNavigationRail);
            UpdateModernNavigationState();
        }

        /// <summary>
        /// 点击导航按钮时选择它绑定的原有页面。
        /// </summary>
        private void ModernNavigationButton_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            TabPage page = button == null ? null : button.Tag as TabPage;

            if (page != null && tabControl2.TabPages.Contains(page))
            {
                tabControl2.SelectedTab = page;
                UpdateModernNavigationState();
            }
        }

        private void tabControl2_ModernSelectedIndexChanged(
            object sender,
            EventArgs e)
        {
            UpdateModernNavigationState();
        }

        /// <summary>
        /// 更新导航按钮的青绿色选中状态。
        /// </summary>
        private void UpdateModernNavigationState()
        {
            if (mModernNavigationButtons == null)
            {
                return;
            }

            foreach (Button button in mModernNavigationButtons)
            {
                bool selected = button.Tag == tabControl2.SelectedTab;
                button.BackColor = selected
                    ? mModernAccentLightColor
                    : Color.Transparent;
                button.ForeColor = selected
                    ? mModernAccentColor
                    : mModernMutedTextColor;
                button.Font = new Font(
                    "Microsoft YaHei UI",
                    8F,
                    selected ? FontStyle.Bold : FontStyle.Regular);
            }
        }

        /// <summary>
        /// 根据窗体大小排列应用栏、通信面板和主工作区。
        /// </summary>
        private void PerformModernMainLayout()
        {
            if (mModernAppBar == null)
            {
                return;
            }

            const int appBarHeight = 50;
            const int navigationWidth = 44;
            int communicationWidth = mIsModernCommPanelVisible ? 469 : 0;
            int contentHeight = Math.Max(1, this.ClientSize.Height - appBarHeight);

            mModernAppBar.SetBounds(0, 0, this.ClientSize.Width, appBarHeight);

            mModernNavigationRail.SetBounds(
                0,
                appBarHeight,
                navigationWidth,
                contentHeight);

            groupBox1.Visible = mIsModernCommPanelVisible;
            groupBox1.SetBounds(
                navigationWidth,
                appBarHeight,
                communicationWidth,
                contentHeight);

            tabControl2.SetBounds(
                navigationWidth + communicationWidth,
                appBarHeight,
                Math.Max(
                    1,
                    this.ClientSize.Width - navigationWidth - communicationWidth),
                contentHeight);

            // 保证应用栏始终位于其他控件上方。
            mModernNavigationRail.BringToFront();
            mModernAppBar.BringToFront();
        }

        private void MainForm_ModernUiResize(object sender, EventArgs e)
        {
            PerformModernMainLayout();
        }

        private void groupBox61_ModernResize(object sender, EventArgs e)
        {
            LayoutModernVarDebugToolbar();
        }

        /// <summary>
        /// 根据在线变量页宽度，把原有设置控件排列成单行或双行工具栏。
        /// </summary>
        private void LayoutModernVarDebugToolbar()
        {
            if (groupBox61 == null || groupBox61.Width <= 0)
            {
                return;
            }

            bool wideLayout = groupBox61.ClientSize.Width >= 960;

            if (wideLayout)
            {
                // 宽工作区使用单行排列，效果接近Rust版顶部工具栏。
                label343.SetBounds(12, 29, 64, 20);
                textBoxMapDir.SetBounds(78, 25, 300, 24);
                btnOpenMap.SetBounds(386, 23, 76, 28);
                btnVarSelect.SetBounds(470, 23, 82, 28);
                label344.SetBounds(570, 29, 72, 20);
                textBoxReadPeriod.SetBounds(642, 25, 78, 24);
                rdioBtnReadSingle.SetBounds(735, 27, 66, 22);
                rdioBtnPollingRead.SetBounds(804, 27, 66, 22);
                btnReadVar.SetBounds(884, 23, 72, 28);
                btnSetVarParam.SetBounds(964, 23, 72, 28);
                btnClearVars.SetBounds(1044, 23, 82, 28);
            }
            else
            {
                // 展开左侧通信面板后空间变窄，自动换成两行，保证全部操作仍可见。
                int pathWidth = Math.Max(150, groupBox61.ClientSize.Width - 264);
                label343.SetBounds(12, 20, 64, 20);
                textBoxMapDir.SetBounds(78, 16, pathWidth, 24);
                btnOpenMap.SetBounds(86 + pathWidth, 14, 76, 28);
                btnVarSelect.SetBounds(170 + pathWidth, 14, 82, 28);

                label344.SetBounds(12, 52, 72, 20);
                textBoxReadPeriod.SetBounds(84, 48, 78, 24);
                rdioBtnReadSingle.SetBounds(176, 50, 66, 22);
                rdioBtnPollingRead.SetBounds(245, 50, 66, 22);
                btnReadVar.SetBounds(326, 46, 72, 28);
                btnSetVarParam.SetBounds(406, 46, 72, 28);
                btnClearVars.SetBounds(486, 46, 82, 28);
            }
        }

        /// <summary>
        /// 展开或折叠左侧通信面板。
        /// </summary>
        private void mModernToggleCommButton_Click(object sender, EventArgs e)
        {
            mIsModernCommPanelVisible = !mIsModernCommPanelVisible;
            mModernToggleCommButton.Text = mIsModernCommPanelVisible
                ? "隐藏通信面板"
                : "显示通信面板";
            PerformModernMainLayout();
        }

        /// <summary>
        /// 递归设置通用WinForms控件的颜色、字体和边框风格。
        /// </summary>
        private void ApplyModernTheme(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                // 顶部应用栏和左侧导航栏已经单独完成样式，不再覆盖其子控件。
                if (control == mModernAppBar ||
                    control == mModernNavigationRail)
                {
                    continue;
                }

                control.Font = new Font(
                    "Microsoft YaHei UI",
                    control.Font.Size,
                    control.Font.Style);

                Button button = control as Button;
                GroupBox groupBox = control as GroupBox;
                TextBox textBox = control as TextBox;
                ComboBox comboBox = control as ComboBox;
                NumericUpDown numeric = control as NumericUpDown;
                TabPage tabPage = control as TabPage;
                Panel panel = control as Panel;
                TableLayoutPanel tablePanel = control as TableLayoutPanel;
                DataGridView dataGrid = control as DataGridView;
                Chart chart = control as Chart;
                TabControl tabControl = control as TabControl;
                Label label = control as Label;
                CheckBox checkBox = control as CheckBox;
                RadioButton radioButton = control as RadioButton;

                if (dataGrid != null)
                {
                    StyleModernDataGrid(dataGrid);
                }
                else if (chart != null)
                {
                    StyleModernChart(chart);
                }
                else if (tabControl != null)
                {
                    StyleModernTabControl(tabControl);
                }
                else if (button != null)
                {
                    StyleModernButton(button, false);
                }
                else if (groupBox != null)
                {
                    groupBox.BackColor = mModernPanelColor;
                    groupBox.ForeColor = mModernTextColor;
                    groupBox.Padding = new Padding(7, 5, 7, 7);
                }
                else if (textBox != null)
                {
                    textBox.BackColor = mModernPanelColor;
                    textBox.ForeColor = mModernTextColor;
                    textBox.BorderStyle = BorderStyle.FixedSingle;
                }
                else if (comboBox != null)
                {
                    comboBox.BackColor = mModernPanelColor;
                    comboBox.ForeColor = mModernTextColor;
                    comboBox.FlatStyle = FlatStyle.Flat;
                }
                else if (numeric != null)
                {
                    numeric.BackColor = mModernPanelColor;
                    numeric.ForeColor = mModernTextColor;
                    numeric.BorderStyle = BorderStyle.FixedSingle;
                }
                else if (tabPage != null)
                {
                    tabPage.BackColor = mModernPanelColor;
                    tabPage.ForeColor = mModernTextColor;
                    tabPage.UseVisualStyleBackColor = false;
                }
                else if (panel != null || tablePanel != null)
                {
                    control.BackColor = mModernPanelColor;
                }
                else if (label != null)
                {
                    label.ForeColor = mModernTextColor;
                }
                else if (checkBox != null)
                {
                    checkBox.ForeColor = mModernTextColor;
                    checkBox.BackColor = Color.Transparent;
                }
                else if (radioButton != null)
                {
                    radioButton.ForeColor = mModernTextColor;
                    radioButton.BackColor = Color.Transparent;
                }

                if (control.HasChildren)
                {
                    ApplyModernTheme(control);
                }
            }
        }

        /// <summary>
        /// 设置扁平按钮样式；强调按钮使用青绿色背景。
        /// </summary>
        private void StyleModernButton(Button button, bool accent)
        {
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 1;
            button.FlatAppearance.BorderColor = accent
                ? Color.FromArgb(21, 152, 153)
                : Color.FromArgb(170, 185, 197);
            button.BackColor = accent
                ? mModernAccentColor
                : Color.FromArgb(248, 250, 251);
            button.ForeColor = accent
                ? Color.White
                : Color.FromArgb(52, 73, 87);
            button.UseVisualStyleBackColor = false;

            // 使用FlatAppearance提供悬停反馈，不额外改变业务代码设置的状态。
            button.FlatAppearance.MouseOverBackColor = accent
                ? Color.FromArgb(17, 158, 159)
                : mModernAccentLightColor;
            button.FlatAppearance.MouseDownBackColor = accent
                ? Color.FromArgb(13, 137, 139)
                : Color.FromArgb(221, 241, 241);
        }

        /// <summary>
        /// 对主要操作按钮使用Rust版青绿色强调色。
        /// </summary>
        private void ApplyModernAccentButtons()
        {
            Button[] accentButtons = new Button[]
            {
                btnOpenMap,
                btnReadVar,
                btnStartGetWaveData,
                btnStartSingleTrigGetWaveData,
                btnSetVarParam
            };

            foreach (Button button in accentButtons)
            {
                if (button != null)
                {
                    StyleModernButton(button, true);
                }
            }

            // 应用栏按钮在递归主题之后创建，需要单独设置一次。
            if (mModernToggleCommButton != null)
            {
                StyleModernButton(mModernToggleCommButton, false);
            }
        }

        /// <summary>
        /// 将系统标签页绘制成白底、青绿色下划线的工作台标签。
        /// </summary>
        private void StyleModernTabControl(TabControl tabControl)
        {
            tabControl.DrawMode = TabDrawMode.OwnerDrawFixed;
            tabControl.SizeMode = TabSizeMode.Fixed;
            tabControl.ItemSize = new Size(
                tabControl == tabControl2 ? 116 : 90,
                31);
            tabControl.Padding = new Point(12, 4);
            tabControl.DrawItem -= ModernTabControl_DrawItem;
            tabControl.DrawItem += ModernTabControl_DrawItem;
        }

        private void ModernTabControl_DrawItem(
            object sender,
            DrawItemEventArgs e)
        {
            TabControl tabControl = sender as TabControl;

            if (tabControl == null ||
                e.Index < 0 ||
                e.Index >= tabControl.TabPages.Count)
            {
                return;
            }

            Rectangle bounds = e.Bounds;
            bool selected = e.Index == tabControl.SelectedIndex;

            using (SolidBrush backgroundBrush = new SolidBrush(mModernPanelColor))
            {
                e.Graphics.FillRectangle(backgroundBrush, bounds);
            }

            TextRenderer.DrawText(
                e.Graphics,
                tabControl.TabPages[e.Index].Text,
                tabControl.Font,
                bounds,
                selected ? mModernAccentColor : mModernMutedTextColor,
                TextFormatFlags.HorizontalCenter |
                TextFormatFlags.VerticalCenter |
                TextFormatFlags.EndEllipsis);

            if (selected)
            {
                using (SolidBrush accentBrush =
                    new SolidBrush(mModernAccentColor))
                {
                    e.Graphics.FillRectangle(
                        accentBrush,
                        bounds.Left + 4,
                        bounds.Bottom - 2,
                        Math.Max(1, bounds.Width - 8),
                        2);
                }
            }
        }

        /// <summary>
        /// 设置在线变量表的表头、网格线和选中颜色。
        /// </summary>
        private void StyleModernDataGrid(DataGridView grid)
        {
            grid.EnableHeadersVisualStyles = false;
            grid.BackgroundColor = mModernPanelColor;
            grid.BorderStyle = BorderStyle.None;
            grid.GridColor = Color.FromArgb(229, 234, 237);
            grid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            grid.ColumnHeadersBorderStyle =
                DataGridViewHeaderBorderStyle.Single;
            grid.ColumnHeadersDefaultCellStyle.BackColor =
                Color.FromArgb(244, 247, 249);
            grid.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.FromArgb(100, 120, 134);
            grid.ColumnHeadersDefaultCellStyle.SelectionBackColor =
                Color.FromArgb(244, 247, 249);
            grid.ColumnHeadersHeight = 32;
            grid.DefaultCellStyle.BackColor = mModernPanelColor;
            grid.DefaultCellStyle.ForeColor = mModernTextColor;
            grid.DefaultCellStyle.SelectionBackColor = mModernAccentLightColor;
            grid.DefaultCellStyle.SelectionForeColor = mModernTextColor;
            grid.RowTemplate.Height = 32;
            grid.RowHeadersVisible = false;
        }

        /// <summary>
        /// 设置软件示波器为浅色工程工作台风格。
        /// </summary>
        private void StyleModernChart(Chart chart)
        {
            chart.BackColor = mModernPanelColor;
            chart.BorderlineColor = mModernBorderColor;
            chart.BorderlineDashStyle = ChartDashStyle.Solid;
            chart.BorderlineWidth = 1;

            foreach (ChartArea area in chart.ChartAreas)
            {
                area.BackColor = mModernPanelColor;
                area.AxisX.LineColor = mModernBorderColor;
                area.AxisY.LineColor = mModernBorderColor;
                area.AxisX.MajorGrid.LineColor =
                    Color.FromArgb(226, 232, 236);
                area.AxisY.MajorGrid.LineColor =
                    Color.FromArgb(226, 232, 236);
                area.AxisX.LabelStyle.ForeColor = mModernMutedTextColor;
                area.AxisY.LabelStyle.ForeColor = mModernMutedTextColor;
            }

            foreach (Legend legend in chart.Legends)
            {
                legend.BackColor = Color.Transparent;
                legend.ForeColor = mModernTextColor;
            }
        }

        /// <summary>
        /// 将原通信日志框调整为更接近Rust版底部日志的等宽显示。
        /// </summary>
        private void StyleModernLogTextBox(TextBox textBox)
        {
            textBox.Font = new Font("Consolas", 9F, FontStyle.Regular);
            textBox.BackColor = Color.FromArgb(250, 252, 253);
            textBox.ForeColor = Color.FromArgb(83, 104, 119);
            textBox.BorderStyle = BorderStyle.FixedSingle;
        }
    }
}
