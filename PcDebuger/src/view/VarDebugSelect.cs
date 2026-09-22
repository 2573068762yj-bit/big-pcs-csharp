using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PcDebuger
{
    public partial class VarDebugSelect : Form
    {
        // 搜索结果过多时只显示前2000项，避免近两万行同时创建造成界面卡顿。
        private const int MAX_DISPLAY_VAR_COUNT = 2000;

        private List<VarOnline> mVarList;  // MAP或ELF文件中所有的变量列表
        public List<VarOnlineExtend> mVarListExt;  //  每次选中的变量列表

        // 保存跨搜索条件勾选的变量，隐藏后的选择不会丢失。
        private HashSet<string> mSelectedVarKeySet;

        // 保存运行时创建的变量搜索输入框。
        private TextBox mVarSearchTextBox;

        // 保存搜索结果和已选数量提示控件。
        private Label mVarSearchResultLabel;

        // 防止刷新表格时触发选择事件并重复修改选择集合。
        private bool mIsRefreshingVarList;

        // 保存当前搜索条件下的总匹配数量。
        private int mMatchedVarCount;

        public VarDebugSelect()
        {
            InitializeComponent();

            mVarList = new List<VarOnline>();
            mVarListExt = new List<VarOnlineExtend>();
            mSelectedVarKeySet = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

            // 在原选择窗口上增加搜索栏、类型列和来源列。
            InitVarSearchView();
        }

        private void InitVarSearchView()
        {
            // 增加类型列，让用户在添加前确认自动识别结果。
            DataGridViewTextBoxColumn typeColumn = new DataGridViewTextBoxColumn();
            typeColumn.Name = "VarType";
            typeColumn.HeaderText = "类型";
            typeColumn.ReadOnly = true;
            typeColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView2.Columns.Add(typeColumn);

            // 增加来源列，用来区分MAP补充符号和ELF类型成员。
            DataGridViewTextBoxColumn sourceColumn = new DataGridViewTextBoxColumn();
            sourceColumn.Name = "VarSource";
            sourceColumn.HeaderText = "来源";
            sourceColumn.ReadOnly = true;
            sourceColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView2.Columns.Add(sourceColumn);

            // 禁止用户手工增加空行，变量只能来自MAP或ELF解析结果。
            dataGridView2.AllowUserToAddRows = false;

            // 名称和地址只用于显示，只有第一列复选框允许编辑。
            dataGridView2.Columns[1].ReadOnly = true;
            dataGridView2.Columns[2].ReadOnly = true;

            // 调整各列宽度比例，让完整变量路径占据主要空间。
            dataGridView2.Columns[0].FillWeight = 18;
            dataGridView2.Columns[1].FillWeight = 150;
            dataGridView2.Columns[2].FillWeight = 55;
            dataGridView2.Columns[3].FillWeight = 40;
            dataGridView2.Columns[4].FillWeight = 28;

            // 创建搜索栏布局。
            TableLayoutPanel searchLayout = new TableLayoutPanel();
            searchLayout.ColumnCount = 3;
            searchLayout.RowCount = 1;
            searchLayout.Dock = DockStyle.Fill;
            searchLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 75F));
            searchLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            searchLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 190F));

            // 创建搜索标题。
            Label searchLabel = new Label();
            searchLabel.Text = "搜索变量";
            searchLabel.TextAlign = ContentAlignment.MiddleCenter;
            searchLabel.Dock = DockStyle.Fill;

            // 创建搜索输入框。
            mVarSearchTextBox = new TextBox();
            mVarSearchTextBox.Dock = DockStyle.Fill;
            mVarSearchTextBox.Margin = new Padding(3, 7, 3, 3);

            // 创建结果数量提示。
            mVarSearchResultLabel = new Label();
            mVarSearchResultLabel.TextAlign = ContentAlignment.MiddleLeft;
            mVarSearchResultLabel.Dock = DockStyle.Fill;

            // 将搜索控件加入搜索栏。
            searchLayout.Controls.Add(searchLabel, 0, 0);
            searchLayout.Controls.Add(mVarSearchTextBox, 1, 0);
            searchLayout.Controls.Add(mVarSearchResultLabel, 2, 0);

            // 把原来的两行布局扩展为“搜索、变量表、按钮”三行。
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Clear();
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel1.SetRow(dataGridView2, 1);
            tableLayoutPanel1.SetRow(tableLayoutPanel2, 2);
            tableLayoutPanel1.Controls.Add(searchLayout, 0, 0);

            // 放大窗口，以便查看较长的嵌套成员路径。
            this.ClientSize = new Size(820, 540);
            this.MinimumSize = new Size(700, 450);
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "变量搜索与选择";

            // 搜索内容变化时立即刷新匹配结果。
            mVarSearchTextBox.TextChanged += mVarSearchTextBox_TextChanged;

            // 复选框点击后立即提交编辑值。
            dataGridView2.CurrentCellDirtyStateChanged +=
                dataGridView2_CurrentCellDirtyStateChanged;

            // 复选框值变化时同步保存选择状态。
            dataGridView2.CellValueChanged += dataGridView2_CellValueChanged;

            // 双击变量行可以快速切换勾选状态。
            dataGridView2.CellDoubleClick += dataGridView2_CellDoubleClick;

            // 接通原界面上未绑定事件的全选和全不选按钮。
            button3.Click += buttonSelectAll_Click;
            button2.Click += buttonSelectNone_Click;
        }

        public void UpdateVarListView(List<VarOnline> varList)
        {
            // 清除旧文件留下的变量。
            mVarList.Clear();

            // 保存新的MAP和ELF合并变量列表。
            mVarList = varList;

            // 切换调试文件后清除旧选择。
            mSelectedVarKeySet.Clear();
        }

        private void VarDebugSelect_Shown(object sender, EventArgs e)
        {
            if (mVarList.Count == 0)
            {
                MessageBox.Show("没有变量列表！");
                return;
            }

            // 初次打开时按照空搜索条件显示变量。
            RefreshVarListView();
        }

        private void RefreshVarListView()
        {
            // 刷新前保存当前可见行的勾选状态。
            SaveVisibleSelectedState();

            // 取得搜索关键字，并允许用空格分隔多个条件。
            string searchText = mVarSearchTextBox.Text.Trim();
            string[] keywordList = searchText.Split(
                new char[] { ' ', '\t' },
                StringSplitOptions.RemoveEmptyEntries);

            // 清空旧搜索结果。
            dataGridView2.Rows.Clear();

            // 标记正在刷新，避免Rows.Add触发选择事件。
            mIsRefreshingVarList = true;

            // 暂停布局可以明显减少批量增加行时的闪烁和耗时。
            dataGridView2.SuspendLayout();

            // 重新统计匹配数量。
            mMatchedVarCount = 0;

            try
            {
                // 逐个检查MAP和ELF合并后的变量。
                foreach (VarOnline varItem in mVarList)
                {
                    // 变量必须同时匹配用户输入的全部关键字。
                    if (!IsVarMatched(varItem, keywordList))
                    {
                        continue;
                    }

                    // 先统计完整匹配数量，即使超过显示上限也不能少算。
                    mMatchedVarCount++;

                    // 超过显示上限后不再创建DataGridView行，用户可以继续缩小搜索范围。
                    if (dataGridView2.Rows.Count >= MAX_DISPLAY_VAR_COUNT)
                    {
                        continue;
                    }

                    // 创建一个与现有列结构匹配的数据行。
                    DataGridViewRow newRow = new DataGridViewRow();
                    newRow.CreateCells(dataGridView2);

                    // 根据跨搜索选择集合恢复复选框状态。
                    newRow.Cells[0].Value =
                        mSelectedVarKeySet.Contains(GetVarKey(varItem));

                    // 显示结构体或数组成员的完整路径。
                    newRow.Cells[1].Value = varItem.name;

                    // 显示最终绝对地址。
                    newRow.Cells[2].Value = varItem.addr;

                    // 位域成员明确标记，不允许误当普通整数使用。
                    newRow.Cells[3].Value = varItem.isBitField
                        ? varItem.type + "（位域）"
                        : varItem.type;

                    // 显示变量来自MAP还是ELF。
                    newRow.Cells[4].Value = varItem.source;

                    // 将完整变量对象绑定到行，排序后仍能正确取回。
                    newRow.Tag = varItem;

                    // 将行加入搜索结果。
                    dataGridView2.Rows.Add(newRow);
                }
            }
            finally
            {
                // 恢复表格布局。
                dataGridView2.ResumeLayout();

                // 结束刷新状态。
                mIsRefreshingVarList = false;
            }

            // 更新匹配、显示和已选数量。
            UpdateSearchResultLabel();
        }

        private bool IsVarMatched(VarOnline varItem, string[] keywordList)
        {
            // 将可搜索字段组合在一起，支持按名称、地址、类型或来源搜索。
            string searchableText = (varItem.name ?? string.Empty) + " " +
                (varItem.addr ?? string.Empty) + " " +
                (varItem.type ?? string.Empty) + " " +
                (varItem.source ?? string.Empty);

            // 每个关键字都必须命中。
            foreach (string keyword in keywordList)
            {
                if (searchableText.IndexOf(keyword,
                    StringComparison.OrdinalIgnoreCase) < 0)
                {
                    return false;
                }
            }

            // 空搜索条件或全部关键字命中时返回真。
            return true;
        }

        private void SaveVisibleSelectedState()
        {
            // 表格正在批量刷新时不能读取尚未完成的行。
            if (mIsRefreshingVarList)
            {
                return;
            }

            // 逐行保存当前可见搜索结果的勾选状态。
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                VarOnline varItem = row.Tag as VarOnline;

                if (varItem == null)
                {
                    continue;
                }

                bool isSelected = Convert.ToBoolean(row.Cells[0].Value ?? false);
                string varKey = GetVarKey(varItem);

                if (isSelected)
                {
                    mSelectedVarKeySet.Add(varKey);
                }
                else
                {
                    mSelectedVarKeySet.Remove(varKey);
                }
            }
        }

        private string GetVarKey(VarOnline varItem)
        {
            // 名称和绝对地址共同确定一个唯一变量或结构成员。
            return (varItem.name ?? string.Empty) + "@" +
                (varItem.addr ?? string.Empty).ToUpperInvariant();
        }

        private void UpdateSearchResultLabel()
        {
            // 显示结果上限和跨搜索条件保存的已选数量。
            mVarSearchResultLabel.Text = string.Format(
                "匹配 {0}，显示 {1}，已选 {2}",
                mMatchedVarCount,
                dataGridView2.Rows.Count,
                mSelectedVarKeySet.Count);
        }

        private void mVarSearchTextBox_TextChanged(object sender, EventArgs e)
        {
            // 输入关键字后立即重新筛选变量。
            RefreshVarListView();
        }

        private void dataGridView2_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            // 复选框单击后立即提交，否则切换搜索时可能丢失最后一次点击。
            if (dataGridView2.IsCurrentCellDirty)
            {
                dataGridView2.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dataGridView2_CellValueChanged(
            object sender,
            DataGridViewCellEventArgs e)
        {
            // 刷新过程或非复选框列变化不需要处理。
            if (mIsRefreshingVarList || e.RowIndex < 0 || e.ColumnIndex != 0)
            {
                return;
            }

            // 保存当前搜索结果中的全部选择状态。
            SaveVisibleSelectedState();

            // 更新已选数量。
            UpdateSearchResultLabel();
        }

        private void dataGridView2_CellDoubleClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            // 表头和无效行不能切换选择。
            if (e.RowIndex < 0 || e.RowIndex >= dataGridView2.Rows.Count)
            {
                return;
            }

            // 双击任意列都切换该行复选框。
            DataGridViewRow row = dataGridView2.Rows[e.RowIndex];
            bool oldValue = Convert.ToBoolean(row.Cells[0].Value ?? false);
            row.Cells[0].Value = !oldValue;
        }

        private void buttonSelectAll_Click(object sender, EventArgs e)
        {
            // 批量设置期间暂停单行事件，避免反复遍历全部可见行。
            mIsRefreshingVarList = true;

            try
            {
                // “全选”只作用于当前搜索结果中实际显示的行。
                foreach (DataGridViewRow row in dataGridView2.Rows)
                {
                    row.Cells[0].Value = true;

                    VarOnline varItem = row.Tag as VarOnline;

                    if (varItem != null)
                    {
                        mSelectedVarKeySet.Add(GetVarKey(varItem));
                    }
                }
            }
            finally
            {
                // 恢复正常的复选框事件处理。
                mIsRefreshingVarList = false;
            }

            // 更新已选数量。
            UpdateSearchResultLabel();
        }

        private void buttonSelectNone_Click(object sender, EventArgs e)
        {
            // 批量设置期间暂停单行事件，避免反复遍历全部可见行。
            mIsRefreshingVarList = true;

            try
            {
                // “全不选”只取消当前搜索结果中实际显示的行。
                foreach (DataGridViewRow row in dataGridView2.Rows)
                {
                    row.Cells[0].Value = false;

                    VarOnline varItem = row.Tag as VarOnline;

                    if (varItem != null)
                    {
                        mSelectedVarKeySet.Remove(GetVarKey(varItem));
                    }
                }
            }
            finally
            {
                // 恢复正常的复选框事件处理。
                mIsRefreshingVarList = false;
            }

            // 更新已选数量。
            UpdateSearchResultLabel();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            // 确认前保存当前搜索结果中的最后选择状态。
            SaveVisibleSelectedState();

            // 清除上一次确认结果。
            mVarListExt.Clear();

            // 统计被忽略的位域数量，最后统一提示一次。
            int bitFieldCount = 0;

            // 从完整变量列表中提取跨搜索条件勾选的变量。
            foreach (VarOnline selectedVar in mVarList)
            {
                // 未勾选变量不加入结果。
                if (!mSelectedVarKeySet.Contains(GetVarKey(selectedVar)))
                {
                    continue;
                }

                // 位域只有字节地址，当前通信协议无法携带位偏移和位宽。
                if (selectedVar.isBitField)
                {
                    bitFieldCount++;
                    continue;
                }

                // 创建在线变量或示波器使用的扩展对象。
                VarOnlineExtend varRow = new VarOnlineExtend();

                // 标记该变量已经被用户选择。
                varRow.isSelected = true;

                // 保存结构体或数组成员完整路径。
                varRow.name = selectedVar.name;

                // 保存最终绝对地址。
                varRow.addr = selectedVar.addr;

                // ELF使用自动类型，MAP在解析时已经设置默认Uint16。
                varRow.type = string.IsNullOrEmpty(selectedVar.type)
                    ? "Uint16"
                    : selectedVar.type;

                // 保存调试文件中的原始类型和大小，供工作区恢复后严格重新匹配。
                varRow.debugType = selectedVar.type;
                varRow.size = selectedVar.size;

                // 当前变量刚从本次解析结果选择，因此地址已经匹配。
                varRow.resolved = true;

                // 初始化读写值。
                varRow.wrValue = "0";
                varRow.rdValue = "0";
                varRow.isNeedWrite = false;

                // 将变量加入确认结果。
                mVarListExt.Add(varRow);
            }

            // 位域不能直接读取时统一提示，避免连续弹出多个窗口。
            if (bitFieldCount > 0)
            {
                MessageBox.Show(
                    bitFieldCount.ToString() +
                    "个位域成员未添加，当前协议不支持位偏移和位宽。");
            }

            // 没有有效变量时保留窗口，让用户继续搜索和选择。
            if (mVarListExt.Count == 0)
            {
                MessageBox.Show("没有任何变量！");
                return;
            }

            // 设置成功结果并关闭选择窗口。
            this.DialogResult = DialogResult.OK;
            this.Close();
        }


    }
}
