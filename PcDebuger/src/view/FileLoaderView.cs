using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace PcDebuger
{
    public enum LoadType
    {
        Loader,
        Loadee,
    }

    partial class MainForm
    {
        LoadType mLoadType;
        UploaderProto mUploaderProto;
        Loadee mLoadee;
        public LoadObj mSelectedLoaderObj;
        public bool mIsLoading;
        public byte m_dstAddr;  //  应用层的目标地址
        public byte m_srcAddr;  //  应用层的源地址

        private void InitFileLoaderView()
        {
            mLoadType = LoadType.Loader;
            mUploaderProto = new UploaderProto(this);
            mLoadee = new Loadee(this);

            btnUpload.Visible = false;
            btnLoadFileStart.Visible = false;
            btnActiveApp.Visible = false;

            cmbFileType.SelectedIndexChanged += new System.EventHandler(cmbFileType_SelectedIndexChanged);

            mIsLoading = false;

            m_dstAddr = 1;  //  1表示主MCU，2表示从MCU
            m_srcAddr = 4;  //  4表示上位机
            labDestMcuAddr.Text = "MCU地址： 0x" + m_dstAddr.ToString("X");
            radioBtnConnectObjectPCS_A.Checked = true;
            mConnectObj = (byte)ConnectObj.CONNECT_OBJ_BIG_PCS_MASTER;
            radioBtnConnectObjectPCS_A.CheckedChanged += radioBtnConnectObjectPCS_A_CheckedChanged;
            radioBtnConnectObjectPCS_B.Checked = false;
            radioBtnConnectObjectPCS_B.CheckedChanged += radioBtnConnectObjectPCS_B_CheckedChanged;
            radioBtnConnectObjectBigPcs.CheckedChanged += radioBtnConnectObjectBigPcs_CheckedChanged;
            this.btnEnterBackDoor.Click += new System.EventHandler(this.btnEnterBackDoor_Click);
        }

        public byte GetConnectObj()
        {
            return (byte)mConnectObj;
        }

        public void SetConnectObj(byte obj)
        {
            mConnectObj = obj;
        } 
        
        private void radioBtnConnectObjectPCS_A_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioBtn = (RadioButton)sender;
            if (radioBtn.Checked)
            {
                m_dstAddr = 0x01;
                mConnectObj = (byte)ConnectObj.CONNECT_OBJ_BIG_PCS_MASTER;
                mCanIdProtoType = 0x32;
                mCanIdDestAddr = 0x78;
                mCanIdSrcAddr = 0x01;
                uint canId = GetCanIdCfg();
                textBox_ID.Text = canId.ToString("X");
                textBoxCanIDSrcAddr.Text = mCanIdSrcAddr.ToString("X");
                textBoxCanIdDestAddr.Text = mCanIdDestAddr.ToString("X");
                labDestMcuAddr.Text = "MCU地址： 0x" + m_dstAddr.ToString("X");
            }
        }

        private void radioBtnConnectObjectPCS_B_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioBtn = (RadioButton)sender;
            if (radioBtn.Checked)
            {
                m_dstAddr = 0x02;
                mConnectObj = (byte)ConnectObj.CONNECT_OBJ_BIG_PCS_SLAVE;
                mCanIdProtoType = 0x32;
                mCanIdDestAddr = 0x78;
                mCanIdSrcAddr = 0x01;
                uint canId = GetCanIdCfg();
                textBox_ID.Text = canId.ToString("X");
                textBoxCanIDSrcAddr.Text = mCanIdSrcAddr.ToString("X");
                textBoxCanIdDestAddr.Text = mCanIdDestAddr.ToString("X");
                labDestMcuAddr.Text = "MCU地址： 0x" + m_dstAddr.ToString("X");
            }
        }

        private void radioBtnConnectObjectBigPcs_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioBtn = (RadioButton)sender;
            if (radioBtn.Checked)
            {
                m_dstAddr = 0x0F;
                mConnectObj = (byte)ConnectObj.CONNECT_OBJ_BIG_PCS_BROADCAST;
                mCanIdProtoType = 0x32;
                mCanIdSrcAddr = 0x01;
                mCanIdDestAddr = 0x78;
                uint canId = GetCanIdCfg();
                textBox_ID.Text = canId.ToString("X");
                textBoxCanIDSrcAddr.Text = mCanIdSrcAddr.ToString("X");
                textBoxCanIdDestAddr.Text = mCanIdDestAddr.ToString("X");
                labDestMcuAddr.Text = "MCU地址： 0x" + m_dstAddr.ToString("X");
            }
        }
     
        public byte GetModbusAddr()
        {
            byte addr = (byte)((m_srcAddr << 4) + m_dstAddr);
            return addr;
        }

        public byte GetModbusAckAddr()
        {
            byte addr = (byte)((m_dstAddr << 4) + m_srcAddr);
            return addr;
        }

        public LoadType GetLoadType()
        {
            return mLoadType;
        }

        private void btnSwitchLoaderOrLoadee_Click(object sender, EventArgs e)
        {
            if (mLoadType == LoadType.Loader)
            {
                mLoadType = LoadType.Loadee;
                btnSwitchLoaderOrLoadee.Text = "下位机";
                //btnLoadFileConsult.Visible = false;
            }
            else
            {
                mLoadType = LoadType.Loader;
                btnSwitchLoaderOrLoadee.Text = "上位机";
                //btnLoadFileConsult.Visible = true;
            }
        }

        private void btnFindFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = false;//该值确定是否可以选择多个文件
            dialog.Title = "请选择文件夹";
            dialog.Filter = "所有文件(*.bin)|*.bin";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string file = dialog.FileName;
                txtFilePath.Text = file;
            }
        }

        private void cmbFileType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            Invoke(new Action(() => { txtInvSoftVersion.Text = mUploaderProto.mLoaderObjs[comboBox.SelectedIndex].version; }));
            mSelectedLoaderObj = mUploaderProto.mLoaderObjs[comboBox.SelectedIndex];
            mUploaderProto.SetTaskId((ushort)(comboBox.SelectedIndex + 1));
            LogMsg("选择升级的文件类型: " + mSelectedLoaderObj.subFileType.ToString() + ", 回读的软件版本: " + mSelectedLoaderObj.version + "\r\n");
        }

        private void btnLoadFileConsult_Click(object sender, EventArgs e)
        {
            byte[] cmd = mUploaderProto.MakeConsultCmd();
            txtSendData.Text = DataFormatConvert.HexArrayToString(cmd);
            CommSendCmd(cmd);
            mUploaderProto.mIsConsultSuccess = false;
            UpdateConsultResult();
        }

        private void btnEnterBackDoor_Click(object sender, EventArgs e)
        {
            byte[] cmd = new byte[8] { 0x01, 0x3E, 0x01, 0x04, 0x01, 0xEB, 0x40, 0x6F };
            txtSendData.Text = DataFormatConvert.HexArrayToString(cmd);
            if (m_isCanOpen == true) 
            {
                CommSendCmd(cmd);
            }
        }

        public void SetProgress(int prog)
        {
            Invoke(new Action(() =>
            {
                progBarUpload.Value = prog;
                labelProgress.Text = prog.ToString() + "%";
            }));

        }

        private void ReadFileData(FileStream fileStream)
        {
            int bytesRead;
            mUploaderProto.mFileBuffer = new byte[fileStream.Length];
            bytesRead = fileStream.Read(mUploaderProto.mFileBuffer, 0, (int)fileStream.Length);

            mUploaderProto.mSelectedLoaderObj = mSelectedLoaderObj;
            mUploaderProto.mIsStartLoader = true;
            mUploaderProto.mUploaderStatus = UploaderStatus.Init;

        }

        public bool UploadFile(string filePath)
        {
            try
            {
                LogMsg("Now open bin file.\r\n");

                if (File.Exists(filePath))
                {
                    FileInfo fileInfo = new FileInfo(filePath);
                    mUploaderProto.mfileSize = fileInfo.Length;
                    LogMsg("文件大小为：" + mUploaderProto.mfileSize.ToString() + "\r\n");
                }

                using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
                {
                    ReadFileData(fileStream);
                }

                return true;
            }
            catch (Exception ex)
            {
                LogMsg("上传失败：" + ex.Message);
                return false;
            }
            finally
            {
            }
        }

        public bool UploadFileNameCheck(string fileName)
        {
            if (cmbFileType.Items.Count > 0)
            {
                string firstItem = cmbFileType.Items[0] as string;
                string thirdItem = null;
                string fourthItem = null;
                if (cmbFileType.Items.Count > 2)
                {
                    thirdItem = cmbFileType.Items[2] as string;
                }
                if (cmbFileType.Items.Count > 3)
                {
                    fourthItem = cmbFileType.Items[3] as string;
                }

                if ((cmbFileType.SelectedIndex == 2) && (thirdItem == "升级主控") && (fileName.Contains("micro_inv_v1r1c00") || fileName.Contains("pcs_app")))
                {
                    return true;
                }
                else if ((cmbFileType.SelectedIndex == 3) && (fourthItem == "升级CPLD") && (fileName.Contains("micro_inv_v1r12") || fileName.Contains("pcs_cpld")))
                {
                    return true;
                }
            }
            return false;
        }
        
        private void btnUpload_Click(object sender, EventArgs e)
        {
            string file = txtFilePath.Text;

            //if (UploadFileNameCheck(file) == false) 
            //{
            //    MessageBox.Show("请确认文件与设备匹配,例如:" 
            //        + Environment.NewLine + "bms_app文件名须包含bms或BMS"
            //        + Environment.NewLine + "pcs_app文件名须包含pcs_app或micro_inv_v1r1c00"
            //        + Environment.NewLine + "pcs_cpld文件名须包含pcs_cpld或micro_inv_v1r12"
            //        + Environment.NewLine + "备电盒文件名须包含mc_relay或app_backup_box", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    return;
            //}

            if (!mIsLoading)
            {
                mIsLoading = true;
                btnUpload.Text = "停止";
                file = txtFilePath.Text;
                UploadFile(file);
            }
            else
            {
                mIsLoading = false;
                btnUpload.Text = "升级";
                mUploaderProto.mIsStartLoader = false;
                mUploaderProto.mUploaderStatus = UploaderStatus.Idle;
            }            
        }

        public void SetUploadBtn(bool isLoading)
        {
            Invoke(new Action(() =>
            {
                if (!isLoading)
                {
                    mIsLoading = true;
                    btnUpload.Text = "停止";
                }
                else
                {
                    mIsLoading = false;
                    btnUpload.Text = "升级";
                }
            }));
        }

        public void UpdateConsultResult()
        {
            Invoke(new Action(() =>
            {
                cmbFileType.Items.Clear();
                labFrameDatLen.Text = mUploaderProto.mOneFrameLen.ToString();
                labSlideFrameNum.Text = mUploaderProto.mSlideFrameNum.ToString();
                if ((ushort)(mUploaderProto.mDeviceType) == (ushort)FileDeviceType.MICRO_INV)
                {
                    labDeviceType.Text = "微逆";
                    for (int i = 0; i < mUploaderProto.mLoaderObjs.Count; i++)
                    {
                        string fileType;
                        if (mUploaderProto.mLoaderObjs[i].subFileType == (byte)InvSubFileType.APP)
                        {
                            fileType = "升级主控";
                        }
                        else if (mUploaderProto.mLoaderObjs[i].subFileType == (byte)InvSubFileType.CPLD)
                        {
                            fileType = "升级CPLD";
                        }
                        else if (mUploaderProto.mLoaderObjs[i].subFileType == (byte)InvSubFileType.PLC)
                        {
                            fileType = "升级PLC";
                        }
                        else if (mUploaderProto.mLoaderObjs[i].subFileType == (byte)InvSubFileType.BOOT)
                        {
                            fileType = "主控Boot";
                        }
                        else
                        {
                            continue;
                        }
                        Invoke(new Action(() => { cmbFileType.Items.Add(fileType); }));

                    }
                }
                else if ((ushort)(mUploaderProto.mDeviceType) == (ushort)FileDeviceType.BIG_RELAY)
                {
                    labDeviceType.Text = "Relay";
                }
                else if ((ushort)(mUploaderProto.mDeviceType) == (ushort)FileDeviceType.PCS)
                {
                    labDeviceType.Text = "PCS";
                    for (int i = 0; i < mUploaderProto.mLoaderObjs.Count; i++)
                    {
                        string fileType;
                        if (mUploaderProto.mLoaderObjs[i].subFileType == (byte)PcsSubFileType.BMS)
                        {
                            fileType = "升级BMS";
                        }
                        else if (mUploaderProto.mLoaderObjs[i].subFileType == (byte)PcsSubFileType.APP)
                        {
                            fileType = "升级主控";
                        }
                        else if (mUploaderProto.mLoaderObjs[i].subFileType == (byte)PcsSubFileType.CPLD)
                        {
                            fileType = "升级CPLD";
                        }
                        else if (mUploaderProto.mLoaderObjs[i].subFileType == (byte)PcsSubFileType.BOOT)
                        {
                            fileType = "PCS Boot";
                        }
                        else if (mUploaderProto.mLoaderObjs[i].subFileType == (byte)PcsSubFileType.BMS_BOOT)
                        {
                            fileType = "BMS Boot";
                        }
                        else
                        {
                            continue;
                        }
                        Invoke(new Action(() => { cmbFileType.Items.Add(fileType); }));

                    }
                }
                else if ((ushort)(mUploaderProto.mDeviceType) == (ushort)FileDeviceType.BACKUP_BOX)
                {
                    labDeviceType.Text = "备电盒";
                    for (int i = 0; i < mUploaderProto.mLoaderObjs.Count; i++)
                    {
                        string fileType;
                        if (mUploaderProto.mLoaderObjs[i].subFileType == (byte)InvSubFileType.APP)
                        {
                            fileType = "升级主控";
                        }
                        else if (mUploaderProto.mLoaderObjs[i].subFileType == (byte)InvSubFileType.CPLD)
                        {
                            fileType = "升级CPLD";
                        }
                        else if (mUploaderProto.mLoaderObjs[i].subFileType == (byte)InvSubFileType.PLC)
                        {
                            fileType = "升级PLC";
                        }
                        else if (mUploaderProto.mLoaderObjs[i].subFileType == (byte)InvSubFileType.BOOT)
                        {
                            fileType = "主控Boot";
                        }
                        else
                        {
                            continue;
                        }
                        Invoke(new Action(() => { cmbFileType.Items.Add(fileType); }));

                    }
                }
                else if ((ushort)(mUploaderProto.mDeviceType) == (ushort)FileDeviceType.BIG_PCS)
                {
                    labDeviceType.Text = "大储PCS";
                    for (int i = 0; i < mUploaderProto.mLoaderObjs.Count; i++)
                    {
                        string fileType;
                        if (mUploaderProto.mLoaderObjs[i].subFileType == (byte)BigPcsSubFileType.INV_APP)
                        {
                            fileType = "升级INV主控";
                        }
                        else if (mUploaderProto.mLoaderObjs[i].subFileType == (byte)BigPcsSubFileType.CPLD)
                        {
                            fileType = "升级CPLD";
                        }
                        else if (mUploaderProto.mLoaderObjs[i].subFileType == (byte)BigPcsSubFileType.BST_APP)
                        {
                            fileType = "升级BST主控";
                        }
                        else
                        {
                            continue;
                        }
                        Invoke(new Action(() => { cmbFileType.Items.Add(fileType); }));

                    }
                }
                else
                {
                    labDeviceType.Text = "未知设备";
                }

                if (mUploaderProto.mIsConsultSuccess)
                {
                    btnUpload.Visible = true;
                }
                else
                {
                    btnUpload.Visible = false;
                }
            }));

            Invoke(new Action(() =>
            {
                if (mUploaderProto.mLoaderObjs.Count != 0 && cmbFileType.Items.Count != 0)
                {
                    cmbFileType.SelectedIndex = 0;
                    txtInvSoftVersion.Text = mUploaderProto.mLoaderObjs[0].version;
                    mSelectedLoaderObj = mUploaderProto.mLoaderObjs[0];
                }
            }));
        }
       


    }
    class FileLoaderView
    {
    }
}
