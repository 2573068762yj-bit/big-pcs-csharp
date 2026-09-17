using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using System.Globalization;
using Excel = Microsoft.Office.Interop.Excel;

namespace PcDebuger
{
    public enum ExportType
    {
        Exporter,
        Exportee,
    }

    public class ExportObj
    {
        public ushort mFileType;
        public string mFileInfo;
        public ExportObj(ushort id, string name)
        {
            mFileType = id;
            mFileInfo = name;
        }
        public ExportObj()
        {
            mFileType = 0;
            mFileInfo = "null";
        }
    }

    public enum PcsVerType : byte
    {
        PCS_VER_OFFGRID_TYPE = 0,
        PCS_VER_ONGRID_TYPE,
    }

    partial class MainForm
    {
        ExportType mExportType;
        ExporterProto mExporterProto;
        Exportee mExportee;
        public List<ExportObj> mExportObjList;
        private List<int> mExportSubfileIdList = new List<int>();
        public ExportObj mSelectedExportObj;
        public ExportObj mSelectedExporterObj;
        public byte mPcsVerType;

        ExportObj[] mExportObjDefine = new ExportObj[] { 
            new ExportObj(0x0F, "日志"),
        };

        public byte mPrintOriginLogFlag;//打印原始数据标志，0：不打印，1：打印
        public int mLogSubfileType;

        private LogAnalysis mLogAnalysis;

        private void InitFileExportView()
        {
            mExportType = ExportType.Exporter;
            mExporterProto = new ExporterProto(this);
            mExportee = new Exportee(this);
            mExportObjList = new List<ExportObj>();
            mSelectedExportObj = new ExportObj();
            mSelectedExporterObj = new ExportObj();
            mLogAnalysis = new LogAnalysis(this);

            mPrintOriginLogFlag = 0x01;
            chkboxPrintOriginLog.Checked = true;

            btnSwitchExporterOrExportee.Click += btnSwitchExporterOrExportee_Click;
            cmbFileTypeExport.SelectedIndexChanged += comboBoxExportObj_SelectedIndexChanged;
            chkboxPrintOriginLog.CheckedChanged += chkboxPrintOriginLog_CheckedChanged;
            btnExportConsult.Click += btnExportConsult_Click;
            btnExportStart.Click += btnExportStart_Click;
            btnExportEnd.Click += btnExportEnd_Click;
            btnExportFileSaveAs.Click += btnExportFileSaveAs_Click;
            btnExportClear.Click += btnExportClear_Click;
            btnTimeSync.Click += btnTimeSync_Click;
            btnFindLogFile.Click += btnFindLogFile_Click;
            btnLogManualTxtAnalysis.Click += btnLogManualTxtAnalysis_Click;
            comboLogSubfileType.SelectedIndexChanged += new System.EventHandler(comboLogSubfileType_SelectedIndexChanged);

            SplitContainer splitContainer = new SplitContainer();
            splitContainer.Dock = DockStyle.Fill;
            splitContainer.Orientation = Orientation.Horizontal; 

            groupBox25.Dock = DockStyle.Fill;
            splitContainer.Panel1.Controls.Add(groupBox25);

            textBoxExport.Dock = DockStyle.Fill;
            splitContainer.Panel2.Controls.Add(textBoxExport);

            tabPage6.Controls.Add(splitContainer);

            int totalHeight = tabPage6.Height;
            splitContainer.SplitterDistance = (int)(totalHeight * 0.39); 

            this.Resize += (s, e) =>
            {
                if (this.WindowState == FormWindowState.Minimized)
                {
                    return;
                }
                else if (splitContainer.Parent != null)
                {
                    splitContainer.SplitterDistance = (int)(splitContainer.Height * 0.39);
                }
            };

        }

        public ExportType GetExportType()
        {
            return mExportType;
        }

        private void btnSwitchExporterOrExportee_Click(object sender, EventArgs e)
        {
            if (mExportType == ExportType.Exporter)
            {
                mExportType = ExportType.Exportee;
                btnSwitchExporterOrExportee.Text = "下位机";
            }
            else
            {
                mExportType = ExportType.Exporter;
                btnSwitchExporterOrExportee.Text = "上位机";
            }
        }

        public void SetExportProgress(int prog)
        {
            Invoke(new Action(() =>
            {
                progressBarExport.Value = prog;
                labelExportProgress.Text = prog.ToString() + "%";
            }));
        }

        public void UpdateHexDataView(byte[] dataBuf, int len)
        {
            string receivedData;
            string logStr = "";
            if (dataBuf == null || dataBuf.Length == 0)
            {
                return;
            }
            Invoke(new Action(() =>
            {
                textBoxExport.Clear();
            }));

            int rows = len / 0x10;
            int lastRowLen = len % 0x10;
            byte[] rowDat = new byte[16];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < 0x10; j++)
                {
                    if (i * 0x10 + j < len)
                    {
                        rowDat[j] = dataBuf[i * 0x10 + j];
                    }
                }
                receivedData = BitConverter.ToString(rowDat).Replace("-", " ");
                logStr += receivedData;
                logStr += "\r\n";
            }

            if (lastRowLen > 0)
            {
                Array.Clear(rowDat, 0, rowDat.Length);

                for (int j = 0; j < lastRowLen; j++)
                {
                    if ((rows * 0x10 + j) < len)
                    {
                        rowDat[j] = dataBuf[rows * 0x10 + j];
                    }
                }
                receivedData = BitConverter.ToString(rowDat).Replace("-", " ");
                logStr += receivedData;
                logStr += "\r\n";
            }
            LogExportMsg(logStr);
        }

        public void LogExportMsg(string log)
        {
            bool debugMode = false;

            if (this.IsHandleCreated)
            {
                Invoke(new Action(() =>
                {
                    if (debugMode)
                    {
                        textBoxExport.AppendText("[" + DateTime.Now.ToString("HH:mm:ss fff") + "]" + "->");
                    }
                    textBoxExport.AppendText(log);
                }));
            }
        }

        private void btnExportConsult_Click(object sender, EventArgs e)
        {
            byte[] cmd = mExporterProto.MakeExportConsultCmd();
            txtSendData.Text = DataFormatConvert.HexArrayToString(cmd);
            CommSendCmd(cmd);
        }

        private void comboBoxExportObj_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            if (comboBox.SelectedIndex == -1)
            {
                MessageBox.Show("请先选择一个文件类型项。");
                return;
            }
            if (comboBox.SelectedIndex >= 0 && comboBox.SelectedIndex < mExportSubfileIdList.Count)
            {
                mSelectedExportObj = mExportObjList[comboBox.SelectedIndex];
                LogMsg("选择导出的文件类型: " + mSelectedExportObj.mFileType.ToString() + "-" + mSelectedExportObj.mFileInfo + "\r\n");
            }
        }

        private void comboLogSubfileType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
         
            if (comboBox.SelectedIndex == -1)
            {
                MessageBox.Show("请先选择一个日志类型项。");
                return;
            }
            if (comboBox.SelectedIndex >= 0 && comboBox.SelectedIndex < mExportSubfileIdList.Count)
            {
                mLogSubfileType = mExportSubfileIdList[comboBox.SelectedIndex];
                string LogSubfileInfo = comboLogSubfileType.Items[comboBox.SelectedIndex].ToString();
                LogMsg("选择导出的日志类型: " + Convert.ToString(mLogSubfileType, 16).ToUpper() + ", " + LogSubfileInfo + "\r\n");
            }
        }

        private void btnExportStart_Click(object sender, EventArgs e)
        {
            if (mExporterProto.mExportStatus == PcDebuger.ExporterStatus.EXPORT_IDLE)
            {
                btnExportStart.Text = "导出文件暂停";
                mExporterProto.Start(mSelectedExporterObj.mFileType);
                return;
            }
            else if (mExporterProto.mExportStatus == PcDebuger.ExporterStatus.EXPORT_PAUSE)
            {
                btnExportStart.Text = "导出文件暂停";
                mExporterProto.Continue();
                return;
            }
            else
            {
                btnExportStart.Text = "导出文件继续";
                mExporterProto.Pause();
            }
        }

        private void btnExportEnd_Click(object sender, EventArgs e)
        {
            btnExportStart.Text = "导出文件启动";
            mExporterProto.Stop();
        }

        public void UartSendEnqueue(byte[] frame)
        {
            mSerialBufferThread.UartSendEnqueue(frame);
        }

        public void UpdateLabFileInfo(string info)
        {
            Invoke(new Action(() =>
            {
                labFileInfo.Text = info;
            }));
        }

        private void btnExportFileSaveAs_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text files All files (*.*)|*.*";
            saveFileDialog.FilterIndex = 1;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;
                txtLogFilePath.Text = filePath;       
                byte[] buf = mExporterProto.GetRecvDataBuf();
                System.IO.File.WriteAllBytes(filePath, buf);
            }
        }

        private void btnExportClear_Click(object sender, EventArgs e)
        {
            textBoxExport.Clear();
            txtLogFilePath.Clear();
        }

        private void btnTimeSync_Click(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now; 
            LogMsg("当前时间: " + now.ToString() + ", ");
            TimeSpan timeSpan = new TimeSpan(DateTime.UtcNow.Ticks - new DateTime(1970, 1, 1, 0, 0, 0).Ticks);
            long timestamp = (long)timeSpan.TotalSeconds;
            LogMsg("Unix时间戳: " + timestamp + "\r\n");

            byte[] timeStampBuf = new byte[8];
            timeStampBuf = BitConverter.GetBytes(timestamp);
            Array.Reverse(timeStampBuf);
            LogMsg(timeStampBuf);
            if (timeStampBuf.Length < 8)
            {
                for (int i = timeStampBuf.Length; i < 8; i++)
                {
                    timeStampBuf[i] = 0x00;
                }
            }

            byte[] cmdBuf = ModbusProto.MakeSouthDevWriteCmdFrame(GetModbusAddr(), 0x2020, 8, timeStampBuf);
            cmdBuf = ModbusProto.TransparentToModbusCmd(cmdBuf, (mCommMode == CommMode.CAN));
            CommSendCmd(cmdBuf);

            txtSendData.Text = BitConverter.ToString(cmdBuf.ToArray()).Replace("-", " ");
        }

        public void InitExportStartBtn()
        {
            Invoke(new Action(() =>
            {
                btnExportStart.Text = "导出文件启动";
            }));
        }

        public void ExportRecvDataProcess(byte[] dataBuf)
        {
            if (dataBuf.Length < 0x05)
            {
                return;
            }

            mExporterProto.ExporterRecvNormalProcess(dataBuf);

            if (mProtoType == ProtoType.CMD)
            {

            }
            else if (mProtoType == ProtoType.MODBUS)
            {
            }
            else if (mProtoType == ProtoType.SOUTH_DEV)
            {
                if (dataBuf.Length < 8)
                {
                    return;
                }
                AnalysisTimeStamp(dataBuf);
            }
            mExporterProto.DataRecvProcess(dataBuf);
        }

        private void AnalysisTimeStamp(byte[] dataBuf)
        {
            if (dataBuf[1] == 0x21 && dataBuf[2] == 0x92)
            {
                ushort len = (ushort)((dataBuf[4] << 8) + dataBuf[5]);
                if (len != 8 || dataBuf.Length != 16)
                {
                    return;
                }
                long timestamp = (long)((dataBuf[6] << 56) + (dataBuf[7] << 48) + (dataBuf[8] << 40) + (dataBuf[9] << 32)
                                + (dataBuf[10] << 24) + (dataBuf[11] << 16) + (dataBuf[12] << 8) + dataBuf[13]);
                LogMsg("Timestamp = " + timestamp.ToString() + "\r\n");

                System.DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
                dateTime = dateTime.AddSeconds(timestamp).ToLocalTime();
                LogMsg("PCS Time: " + dateTime.ToString() + "\r\n");
            }
        }

        public void ExportConsultResult()
        {
            ExportObj obj = new ExportObj();
            
            mExportObjList.Clear();
            Invoke(new Action(() => { cmbFileTypeExport.Items.Clear(); }));

            if (mExporterProto.mFileTypeFromSlave == 0x0F)
            {
                obj.mFileType = 0x0F;
            }
            else 
            {
                obj.mFileType = 0;
            }
         
            for (int j = 0; j < mExportObjDefine.Length; j++)
            {
                ExportObj tmp = mExportObjDefine[j];
                if (tmp.mFileType == obj.mFileType)
                {
                    obj.mFileInfo = tmp.mFileInfo;
                    break;
                }
            }
            if (obj.mFileInfo != "null")
            {
                mExportObjList.Add(obj);
            }

            if (mExportObjList.Count <= 0)
            {
                LogMsg("\r\n协商失败：没有导出对象\r\n");
            }
            else
            {
                for (int i = 0; i < mExportObjList.Count; i++)
                {
                    string fileType = mExportObjList[i].mFileInfo;
                    Invoke(new Action(() => { cmbFileTypeExport.Items.Add(fileType); }));
                }
                Invoke(new Action(() => { cmbFileTypeExport.SelectedIndex = 0; }));
                mSelectedExportObj = mExportObjList[0];
                mSelectedExporterObj = mExportObjList[0];
            }

            Invoke(new Action(() =>
            {
                mExportSubfileIdList.Clear();
                comboLogSubfileType.Items.Clear();
                if ((ushort)(mExporterProto.mDeviceTypeE) == (ushort)FileDeviceType.PCS)
                {
                    string fileType = "PCS";

                    for (int i = 0; i < mExporterProto.mLogSubfileTypeObjs.Count; i++)
                    {
                        if (mExporterProto.mLogSubfileTypeObjs[i].subFileType == (byte)PcsLogSubFileType.MASTER_RAM_LOG)
                        {
                            mExportSubfileIdList.Add((int)PcsLogSubFileType.MASTER_RAM_LOG);
                            fileType = "01-主MCU日志"; 
                        }
                        else if (mExporterProto.mLogSubfileTypeObjs[i].subFileType == (byte)PcsLogSubFileType.SLAVE_RAM_LOG)
                        {
                            mExportSubfileIdList.Add((int)PcsLogSubFileType.SLAVE_RAM_LOG);
                            fileType = "02-从MCU日志";
                        }
                        else
                        {
                            continue;
                        }
                        Invoke(new Action(() => { comboLogSubfileType.Items.Add(fileType); }));
                    }
                    if (fileType == "PCS")
                    {
                        LogMsg("\r\n协商失败：没有日志类型\r\n");
                    }
                }    
            }));
        }

        private void btnFindLogFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = false;
            dialog.Title = "请选择文件夹";
            dialog.Filter = "所有文件(*.*)|*.*";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string file = dialog.FileName;
                txtLogFilePath.Text = file;
                if (File.Exists(file))
                {
                    FileInfo fileInfo = new FileInfo(file);
                    long size = fileInfo.Length;
                    LogMsg("文件大小为：" + size.ToString() + "\r\n");
                }

                using (FileStream fileStream = new FileStream(file, FileMode.Open))
                {
                    byte[] fileBuffer = new byte[fileStream.Length];
                    int bytesRead = fileStream.Read(fileBuffer, 0, (int)fileStream.Length);

                    UpdateHexDataView(fileBuffer, bytesRead);
                }
            }
        }

        public class TimestampConverter
        {
            public static DateTime ConvertUnixTimeStampToDateTime(double unixTimeStamp)
            {
				//零时区[UTC+0]基准
                System.DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(unixTimeStamp);
                //dateTime = dateTime.AddSeconds(unixTimeStamp).ToLocalTime();//东八区[UTC+8]北京时间基准
                return dateTime;
            }
        }

        public enum LogFileType : byte 
        {
            NONE = 0,   
            PCS_ABC = 1,
            BKP_BOX = 2,
        }

        public static LogFileType CheckFileName(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
                return LogFileType.NONE;

            if (fileName.Contains("BMS_PCSA_1") || fileName.Contains("BMS_PCSB_2") || fileName.Contains("BMS_PCSC_3") ||
                fileName.Contains("PCS_A_日志") || fileName.Contains("PCS_B_日志") || fileName.Contains("PCS_C_日志"))
                return LogFileType.PCS_ABC;
            else if (fileName.Contains("BACKUP_APP_LOG") || fileName.Contains("备电盒"))
                return LogFileType.BKP_BOX;
            else
                return LogFileType.NONE;
        }

        private void CreateAnalysisExcelFile(string txtfilePath) 
        {
            string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(txtfilePath);
            string directory = Path.GetDirectoryName(txtfilePath);
            string xlsxFilePath = Path.Combine(directory, fileNameWithoutExtension + ".xlsx");

            Excel.Application excelApp = new Excel.Application();
            excelApp.Visible = false; 

            Excel.Workbook workbook = excelApp.Workbooks.Add();
            Excel._Worksheet worksheet = (Excel._Worksheet)workbook.ActiveSheet;

            string[] lines = File.ReadAllLines(txtfilePath);

            for (int row = 0; row < lines.Length; row++)
            {
                worksheet.Cells[row + 1, 1] = lines[row];

                string[] cells = lines[row].Split(','); 
                for (int col = 0; col < cells.Length; col++)
                {
                    worksheet.Cells[row + 1, col + 1] = cells[col];
                }
            }

            Excel.Range column1 = worksheet.Columns[1]; 
            column1.NumberFormat = "yyyy/m/d h:mm:ss";   
            column1.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
            column1.AutoFit();  

            Excel.Range column2 = worksheet.Columns[2]; 
            column2.WrapText = false;                    
            column2.ColumnWidth = 28;                                      


            Excel.Range column3 = worksheet.Columns[3];
            column3.AutoFit(); 

            Excel.Range range = worksheet.Range["D:AG"];
            range.ColumnWidth = 9.9;

            Excel.Range cellBelowHeader = worksheet.Cells[2, 1]; 
            cellBelowHeader.Select();
            excelApp.ActiveWindow.FreezePanes = true;
            workbook.SaveAs(xlsxFilePath, Excel.XlFileFormat.xlOpenXMLWorkbook);
            workbook.Close();
            excelApp.Quit();
        }

        private void btnLogManualTxtAnalysis_Click(object sender, EventArgs e)
        {
            DateTime startTime = DateTime.Now;
            byte connectObj = GetConnectObj();
            string file = txtLogFilePath.Text;

            if (File.Exists(file))
            {
                FileInfo fileInfo = new FileInfo(file);
                long size = fileInfo.Length;
                LogMsg("文件大小为：" + size.ToString() + "\r\n");

                //if (GetConnectObj() != (byte)ConnectObj.CONNECT_OBJ_BACKUP_BOX)
                //{
                //    SetConnectObj((byte)ConnectObj.CONNECT_OBJ_PCS_A);
                //}

                using (FileStream fileStream = new FileStream(file, FileMode.Open))
                {
                    btnLogManualTxtAnalysis.Text = "解析中，请等待";

                    byte[] fileBuffer = new byte[fileStream.Length];
                    int bytesRead = fileStream.Read(fileBuffer, 0, (int)fileStream.Length);

                    //if (fileBuffer[0] == 0xFE && fileBuffer[1] == 0xFE)
                    //{
                        txtReceivedData.Clear();
                        mLogAnalysis.Analysis(fileBuffer, bytesRead);

                    //    string txtfileName = Path.ChangeExtension(file, "AAA.txt");
                    //    string folderPath = Path.GetDirectoryName(file);

                    //    string txtfilePath = Path.Combine(folderPath, txtfileName);
                    //    byte[] buf = Encoding.UTF8.GetBytes(txtReceivedData.Text);
                    //    System.IO.File.WriteAllBytes(txtfilePath, buf);
                    //}
                    //else 
                    //{
                    //    LogMsg("\r\n文件无有效内容或文件内容格式错误！\r\n");
                    //}                    
                }

                btnLogManualTxtAnalysis.Text = "解析";
                double totalTime = (DateTime.Now - startTime).TotalSeconds;
                LogMsg("处理所花时间：" + totalTime.ToString() + " s.\r\n");
                LogMsg("\n" + DateTime.Now.ToString() + " 解析完成！");
            }
            else
            {
                LogMsg("\r\n文件路径错误！\r\n");
                byte[] buf = mExporterProto.GetRecvDataBuf();
                if (buf.Length > 0)
                {
                    mLogAnalysis.Analysis(buf, buf.Length);
                }
                else
                {
                    LogMsg("\r\n缓存没有内容！\r\n");
                }
            }

            SetConnectObj(connectObj);
        }

        private void chkboxPrintOriginLog_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            if (checkBox.Checked)
            {
                mPrintOriginLogFlag = 0x01;
            }
            else
            {
                mPrintOriginLogFlag = 0x00;
            }
        }
     }

    class FileExportView
    {
    }
}
