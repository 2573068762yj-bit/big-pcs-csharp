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
        private List<VarOnline> mVarList;  // MAP或ELF文件中所有的变量列表
        public List<VarOnlineExtend> mVarListExt;  //  每次选中的变量列表

        public VarDebugSelect()
        {
            InitializeComponent();

            mVarList = new List<VarOnline>();
            mVarListExt = new List<VarOnlineExtend>();
        }

        public void UpdateVarListView(List<VarOnline> varList)
        {
            mVarList.Clear();
            mVarList = varList;
        }

        private void VarDebugSelect_Shown(object sender, EventArgs e)
        {
            if (mVarList.Count == 0)
            {
                MessageBox.Show("没有变量列表！");
                return;
            }

            dataGridView2.Rows.Clear();

            foreach(VarOnline va in mVarList)
            {
                DataGridViewRow newRow = new DataGridViewRow();
                newRow.CreateCells(dataGridView2); // 关键：按网格结构创建单元格

                // 2. 给每一列赋值
                newRow.Cells[0].Value = false;         // 第1列
                newRow.Cells[1].Value = va.name;       // 第2列（下拉框）
                newRow.Cells[2].Value = va.addr;       // 第3列（地址）

                // 将完整变量对象绑定到表格行，排序后仍能取得正确的类型和位域信息。
                newRow.Tag = va;

                // 3. 最后把这行添加到网格
                dataGridView2.Rows.Add(newRow);
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            mVarListExt.Clear();
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                if (row.Cells[0].Value == null || row.Cells[1].Value == null || row.Cells[2].Value == null)
                {
                    break;
                }
                VarOnlineExtend varRow = new VarOnlineExtend();
                varRow.isSelected = Convert.ToBoolean(row.Cells[0].Value ?? false);
                if (varRow.isSelected)
                {
                    // 优先从表格行中取得绑定的完整变量对象。
                    VarOnline selectedVar = row.Tag as VarOnline;

                    // 兼容没有绑定Tag的旧表格行，再按行号尝试读取。
                    if (selectedVar == null &&
                        row.Index >= 0 && row.Index < mVarList.Count)
                    {
                        selectedVar = mVarList[row.Index];
                    }

                    // 理论上每一行都应该对应一个变量，这里增加保护避免异常。
                    if (selectedVar == null)
                    {
                        continue;
                    }

                    // 位域只有字节地址还不够，现有协议无法携带位偏移和位宽。
                    if (selectedVar.isBitField)
                    {
                        MessageBox.Show(
                            selectedVar.name + "是位域成员，当前通信协议不能直接读写！");
                        continue;
                    }

                    // 保存界面中显示的完整变量路径。
                    varRow.name = row.Cells[1].Value.ToString();

                    //  获取地址
                    varRow.addr = row.Cells[2].Value.ToString();
                    //string addrStr = row.Cells[2].Value.ToString();
                    //if (addrStr.StartsWith("0x"))
                    //{
                    //    addrStr = addrStr.Substring(2);
                    //}
                    //addrStr = addrStr.Replace(" ", "");
                    //if (addrStr.Length != 8)
                    //{
                    //    MessageBox.Show(varRow.name + "地址位数少于8！");
                    //    return;
                    //}

                    //byte[] addrBytes = DataFormatConvert.CmdStringToAscii(addrStr);
                    //if (addrBytes.Length != 4)
                    //{
                    //    MessageBox.Show(varRow.name + "地址字节数少于4！");
                    //    return;
                    //}
                    //varRow.addr = (uint)((addrBytes[0] << 24) + (addrBytes[1] << 16) + (addrBytes[2] << 8) + (addrBytes[3]));

                    // ELF变量使用DWARF自动识别的类型，MAP变量仍然默认Uint16。
                    varRow.type = string.IsNullOrEmpty(selectedVar.type)
                        ? "Uint16"
                        : selectedVar.type;
                    //DataGridViewComboBoxCell comboCell = dataGridView2.CurrentRow.Cells[3] as DataGridViewComboBoxCell;

                    //if (comboCell == null)
                    //{
                    //    MessageBox.Show(varRow.name + "数据类型有误！");
                    //    return;
                    //}

                    //varRow.type = comboCell.Items.IndexOf(comboCell.Value);

                    //  初始化其他成员
                    varRow.wrValue = "0";
                    varRow.rdValue = "0";
                    varRow.isNeedWrite = false;
                    mVarListExt.Add(varRow);
                }
            }
            if (mVarListExt.Count == 0)
            {
                MessageBox.Show("没有任何变量！");
            }

            this.Close();
        }


    }
}
