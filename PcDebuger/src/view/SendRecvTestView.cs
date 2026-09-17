using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PcDebuger
{
    partial class MainForm
    {
        private bool mIsShowRecvFlag;
        private bool mIsShowSendFlag;
        private bool mIsHexShow;
        private bool mIsHexSend;

        private void InitSendRecvTestView()
        {
            mIsShowRecvFlag = true;
            mIsShowSendFlag = true;
            mIsHexShow = true;
            mIsHexSend = true;

            chkBoxHexShow.CheckedChanged += new System.EventHandler(this.chkBoxHexShow_CheckedChanged);
            chkBoxHexSend.CheckedChanged += new System.EventHandler(this.chkBoxHexSend_CheckedChanged);
            checkBoxShowRecv.CheckedChanged += new System.EventHandler(this.checkBoxShowRecv_CheckedChanged);
            checkBoxShowSend.CheckedChanged += new System.EventHandler(this.checkBoxShowSend_CheckedChanged);

            btnSend.Click += btnSend_Click;
            button_clear.Click += button_clear_Click;
            btnCmdRecordFileSaveAs.Click += btnCmdRecordFileSaveAs_Click;
        }

        private void checkBoxShowSend_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            if (checkBox.Checked)
            {
                mIsShowSendFlag = true;
            }
            else
            {
                mIsShowSendFlag = false;
            }
        }

        private void checkBoxShowRecv_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            if (checkBox.Checked)
            {
                mIsShowRecvFlag = true;
            }
            else
            {
                mIsShowRecvFlag = false;
            }
        }

        private void chkBoxHexShow_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            if (checkBox.Checked)
            {
                mIsHexShow = true;
            }
            else
            {
                mIsHexShow = false;
            }
        }

        private void chkBoxHexSend_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            if (checkBox.Checked)
            {
                mIsHexSend = true;
            }
            else
            {
                mIsHexSend = false;
            }
        }

        public void LogMsg(byte[] dataBuf)
        {
            string receivedData;
            if (dataBuf.Length == 0)
            {
                return;
            }
            if (mIsHexShow)
            {
                receivedData = BitConverter.ToString(dataBuf).Replace("-", " ");
            }
            else
            {
                receivedData = Encoding.UTF8.GetString(dataBuf);
            }

            LogMsg(receivedData);
        }

        public void LogMsg(byte[] dataBuf, bool isNextLine)
        {
            LogMsg(dataBuf);
            if (isNextLine)
            {
                LogMsg("\r\n");
            }
        }

        public void LogMsg(string log)
        {
            bool debugMode = false; 

            if (this.IsHandleCreated)
            {
                Invoke(new Action(() =>
                {
                    if (debugMode)
                    {
                        txtReceivedData.AppendText("[" + DateTime.Now.ToString("HH:mm:ss fff") + "]" + "->");
                    }
                    txtReceivedData.AppendText(log);
                }));
            }
        }

        public void LogMsg(string log, bool isNextLine)
        {
            if (isNextLine)
            {
                LogMsg(log + "\r\n");
            }
            else
            {
                LogMsg(log);
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (mCommMode == CommMode.CAN)
            {
                SendBtnData_CAN(txtSendData.Text);
            }
            else if (mCommMode == CommMode.UART)
            {
                SendBtnData_Uart(txtSendData.Text);
            }
        }

        private void button_clear_Click(object sender, EventArgs e)
        {
            txtReceivedData.Clear();
        }

        private void btnCmdRecordFileSaveAs_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text files All files (*.*)|*.*";
            saveFileDialog.FilterIndex = 1;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;
                byte[] buf = Encoding.UTF8.GetBytes(txtReceivedData.Text);
                System.IO.File.WriteAllBytes(filePath, buf);
            }
        }

    }
}
