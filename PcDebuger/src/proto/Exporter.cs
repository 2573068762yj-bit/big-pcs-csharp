using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;

namespace PcDebuger
{
    public enum ExportFileSubCmd : byte
    {
        CONSULT = 0x01,
        START = 0x02,
        TRANSFER = 0x03,
        FILE_END = 0x04,
        SLIDECRC = 0x05,
    }

    public enum ExporterStatus
    {
        EXPORT_IDLE,
        EXPORT_SEND_START,
        EXPORT_SEND_START_WAIT,
        EXPORT_SEND_TRANSFER,
        EXPORT_SEND_TRANSFER_WAIT,
        EXPORT_CAL_CRC,
        EXPORT_DECISION,
        EXPORT_PAUSE,
        EXPORT_SEND_END,
        EXPORT_SEND_END_WAIT,
        EXPORT_STOP,
        EXPORT_SHOW_FILE,
    }

    public struct LogSubfileTypeObj
    {
        public byte subFileType;

        public LogSubfileTypeObj(byte type)
        {
            subFileType = type;
        }
    }

    public enum PcsLogSubFileType : byte
    {
        MASTER_RAM_LOG = 0x01,
        SLAVE_RAM_LOG  = 0x02,
    }

    //public enum PcsLogSubFileType : byte
    //{
    //    BMS_01_FAULT_LOG = 0x01,
    //    BMS_02_ADAPTER_LOG = 0x02,
    //    BMS_03_FAULT_BAK_LOG = 0x03,
    //    BMS_04_ADAPTER_BAK_LOG = 0x04,
    //    PCS_05_A_PHASE_LOGA = 0x05,
    //    PCS_06_A_PHASE_LOGB = 0x06,
    //    PCS_07_B_PHASE_LOGA = 0x07,
    //    PCS_08_B_PHASE_LOGB = 0x08,
    //    PCS_09_C_PHASE_LOGA = 0x09,
    //    PCS_10_C_PHASE_LOGB = 0x0A,
    //    BMS_11_FAULT_RECORD = 0x0B,
    //    BMS_12_PERF_5MIN_HEAD = 0x0C,
    //    BMS_13_PERF_5MIN_DATA1 = 0x0D,
    //    BMS_14_PERF_5MIN_DATA2 = 0x0E,
    //    BMS_15_PERF_5MIN_DATA3 = 0x0F,
    //    BMS_16_PERF_5MIN_DATA4 = 0x10,
    //    BMS_17_PERF_5MIN_DATA5 = 0x11,
    //    BMS_18_VER_INFO = 0x12,
    //    BMS_19_VER_INFO_BAK = 0x13,
    //    PCS_20_A_PHASE_BOMB = 0x14,
    //    PCS_21_A_PHASE_BOMB1 = 0x15,
    //    PCS_22_A_PHASE_BOMB2 = 0x16,
    //    PCS_23_A_PHASE_BOMB3 = 0x17,
    //    PCS_24_A_PHASE_BOMB4 = 0x18,
    //    PCS_25_B_PHASE_BOMB = 0x19,
    //    PCS_26_B_PHASE_BOMB1 = 0x1A,
    //    PCS_27_B_PHASE_BOMB2 = 0x1B,
    //    PCS_28_B_PHASE_BOMB3 = 0x1C,		
    //    PCS_29_B_PHASE_BOMB4 = 0x1D,	
    //    PCS_30_C_PHASE_BOMB = 0x1E,
    //    PCS_31_C_PHASE_BOMB1 = 0x1F,
    //    PCS_32_C_PHASE_BOMB2 = 0x20,
    //    PCS_33_C_PHASE_BOMB3 = 0x21,		
    //    PCS_34_B_PHASE_BOMB4 = 0x22	
    //}

    class ExporterProto
    {
        private MainForm formCaller;

        public FileDeviceType mDeviceTypeE;//设备类型：0x1300:PCS
        public List<ExportObj> mExportObjs;//文件类型列表
        public List<LogSubfileTypeObj> mLogSubfileTypeObjs;//日志类型列表
        public ExporterStatus mExportStatus;//日志导出状态机状态

        private ushort mFrameSize;//帧字节数
        private ushort mSlidWinNum;//滑窗帧数

        private ushort mSlidWinNumTmp;//当前文件滑窗帧数
        private UInt32 mStartSequence;//当前文件起始序列号
        private byte[] mExportDataBuf;//当前文件导出数据缓存区
        private UInt32 mExportDataLen;//当前文件导出数据长度
        private ushort mSlidWinTotalNum;//当前文件的总滑窗数
        private ushort mLastSlidWinTotalNum;//当前文件不能整除的滑窗数剩余的数据帧数
        private ushort mlastFrameSize;//当前文件不能整除的滑窗数剩余帧的字节数
        private ushort mSlidWinCnt;//当前文件已传输的滑窗数
        private ushort mSlidCrcCal;//当前文件计算的校验码
        private ushort mTryTimes;//滑窗校验失败次数

        private bool mIsGetAckFromSlave;//回复标志，false:未收到回复，true:收到回复
        public ushort mFileTypeFromSlave;//文件类型，0x000F:日志
        private UInt32 mFileSizeFromSlave;//本次文件大小
        private ushort mLogTaskIdFromSlave;//本次日志任务编号
        private UInt32 mSlidDataSizeFromSlave;//回复的滑窗字节数
        private ushort mSlidCrcFromSlave;//回复的滑窗校验码
        private ushort mSlidCrcWinNumFromSlave;//回复的滑窗帧数
        private UInt32 mSlidCrcStartSeqFromSlave;//回复的滑窗起始序列号
        private ushort mFileCrcFromSlave;//回复的文件校验
		private DateTime mCmdSendTime;//指令发送时间
		
        private bool mIsPauseBtnClicked;
        private bool mIsStopBtnClicked;
		
        System.Threading.Thread mExportFileTaskThread;

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

        public ExporterProto(MainForm f)
        {
            formCaller = f;
            mDeviceTypeE = FileDeviceType.PCS;
            mExportObjs = new List<ExportObj>();

            mFrameSize = 128;
            mSlidWinNum = 6;
            mExportStatus = ExporterStatus.EXPORT_IDLE;
            mLogTaskIdFromSlave = 0x01;

            mLogSubfileTypeObjs = new List<LogSubfileTypeObj>();

            mExportFileTaskThread = new Thread(new ThreadStart(ExportFileThread));
            mExportFileTaskThread.Priority = ThreadPriority.Lowest;
            mExportFileTaskThread.IsBackground = true;
            mExportFileTaskThread.Start();
            mCmdSendTime = DateTime.Now;
        }

        private void ExportFileThread()
        {
            ushort overTimeCnt = 0;

            while (true)
            {
                switch (mExportStatus)
                {
                    case ExporterStatus.EXPORT_IDLE:
                        break;
                    case ExporterStatus.EXPORT_SEND_START:
                        byte[] startCmd = MakeExportStartCmd();
                        formCaller.CommSendCmd(startCmd);
                        mExportStatus = ExporterStatus.EXPORT_SEND_START_WAIT;
                        mIsGetAckFromSlave = false;
                        mCmdSendTime = DateTime.Now;
                        mSlidWinCnt = 0;
                        break;
                    case ExporterStatus.EXPORT_SEND_START_WAIT:
                        if (mIsGetAckFromSlave == true)
                        {
                            overTimeCnt = 0;
                            mStartSequence = 0;                           
                            mSlidWinNumTmp = mSlidWinNum;
                            mExportStatus = ExporterStatus.EXPORT_SEND_TRANSFER;
                        }
                        else if (((DateTime.Now - mCmdSendTime).TotalMilliseconds > 7000))
                        {
                            formCaller.LogMsg("超时未收到启动回复，开始重传\r\n");
                            overTimeCnt++;
                            if (overTimeCnt > 3)
                            {
                                overTimeCnt = 0;
                                ParamInit();
                                mExportStatus = ExporterStatus.EXPORT_IDLE;
                                formCaller.LogMsg("超过3次收到超时，退出本次导出启动\r\n");
                            }
                            else 
                            {
                                mExportStatus = ExporterStatus.EXPORT_SEND_START;
                            }                           
                        }
                        break;
                    case ExporterStatus.EXPORT_SEND_TRANSFER:
                        byte[] transferCmd = MakeExportTransferCmd();
                        formCaller.CommSendCmd(transferCmd);
                        mExportStatus = ExporterStatus.EXPORT_SEND_TRANSFER_WAIT;
                        mIsGetAckFromSlave = false;
                        mCmdSendTime = DateTime.Now;
                        break;
                    case ExporterStatus.EXPORT_SEND_TRANSFER_WAIT:
                        if (mIsGetAckFromSlave == true)
                        {
                            overTimeCnt = 0;
                            mExportStatus = ExporterStatus.EXPORT_CAL_CRC;
                        }
                        else if (((DateTime.Now - mCmdSendTime).TotalMilliseconds > 7000))
                        {
                            formCaller.LogMsg("超时未收到滑窗CRC，开始重传\r\n");
                            overTimeCnt++;
                            if (overTimeCnt > 3)
                            {
                                overTimeCnt = 0;
                                ParamInit();
                                mExportStatus = ExporterStatus.EXPORT_IDLE;
                                formCaller.LogMsg("超过3次收到超时，退出本次导出传输\r\n");
                            }
                            else
                            {
                                mExportStatus = ExporterStatus.EXPORT_SEND_TRANSFER;
                            }     
                        }
                        break;
                    case ExporterStatus.EXPORT_CAL_CRC:
                        CalSlidWinCrc();
                        mExportStatus = ExporterStatus.EXPORT_DECISION;
                        break;
                    case ExporterStatus.EXPORT_DECISION:
                        ExportDecision();
                        break;
                    case ExporterStatus.EXPORT_PAUSE:
                        if (!mIsPauseBtnClicked)
                        {
                            mExportStatus = ExporterStatus.EXPORT_DECISION;
                        }
                        if (mIsStopBtnClicked)
                        {
                            mIsStopBtnClicked = false;
                            mIsPauseBtnClicked = false;
                            mExportStatus = ExporterStatus.EXPORT_SEND_END;
                        }
                        break;
                    case ExporterStatus.EXPORT_SEND_END:
                        byte[] endCmd = MakeExportEndCmd();
                        formCaller.CommSendCmd(endCmd);
                        mExportStatus = ExporterStatus.EXPORT_SEND_END_WAIT; 
                        mIsGetAckFromSlave = false;
                        mCmdSendTime = DateTime.Now;
                        break;
                    case ExporterStatus.EXPORT_SEND_END_WAIT:
                        if (mIsGetAckFromSlave)
                        {
                            ushort fileCrc = ModbusCrc.Crc16(mExportDataBuf, (int)mFileSizeFromSlave);
                            if (mFileCrcFromSlave == fileCrc)
                            {
                                overTimeCnt = 0;
                                formCaller.LogMsg("\r\n文件校验通过，导出成功，本次导出任务结束\r\n");
                            }
                            else
                            {
                                formCaller.LogMsg("\r\n文件校验不通过，导出失败，本次导出任务结束\r\n");
                            }
                            mExportDataLen = mFileSizeFromSlave;
                            formCaller.UpdateHexDataView(mExportDataBuf, (int)mExportDataLen);
                            ParamInit();
                            mExportStatus = ExporterStatus.EXPORT_IDLE;
                        }
                        else if (((DateTime.Now - mCmdSendTime).TotalMilliseconds > 7000))
                        {
                            formCaller.LogMsg("超时未收到结束回复，开始重传\r\n");                                                      
                            overTimeCnt++;
                            if (overTimeCnt > 3)
                            {
                                overTimeCnt = 0;
                                ParamInit();
                                mExportStatus = ExporterStatus.EXPORT_IDLE;
                                formCaller.LogMsg("\r\n超过3次收到超时，导出失败，本次导出任务结束\r\n");
                            }
                            else
                            {
                                mExportStatus = ExporterStatus.EXPORT_SEND_END; 
                            }     
                        }
                        break;
                    case ExporterStatus.EXPORT_STOP:
                        ParamInit();
                        mExportStatus = ExporterStatus.EXPORT_IDLE;
                        formCaller.LogMsg("\r\n手动退出，本次导出任务结束\r\n");
                        break;                                               
                    default:
                        break;
                }
                Thread.Sleep(10);
            }
        }

        public void Start(ushort fileType)
        {
            mExportStatus = ExporterStatus.EXPORT_SEND_START;
            mFileTypeFromSlave = fileType;
            mIsStopBtnClicked = false;
            mIsPauseBtnClicked = false;
        }

        public void Pause()
        {
            mIsPauseBtnClicked = true;
        }

        public void Continue()
        {
            mIsPauseBtnClicked = false;
        }

        public void Stop()
        {
            mExportStatus = ExporterStatus.EXPORT_STOP;
            mIsStopBtnClicked = true;
            formCaller.SetExportProgress(0);
        }

        private void ParamInit()
        {
            mIsGetAckFromSlave = false;
            mFileTypeFromSlave = 0;
            mFileSizeFromSlave = 0;
            mStartSequence = 0;
            mSlidDataSizeFromSlave = 0;
            mSlidCrcFromSlave = 0;
            mSlidCrcStartSeqFromSlave = 0;
            mSlidCrcWinNumFromSlave = 0;
            mSlidCrcCal = 0;
            mFileCrcFromSlave = 0;
            mIsPauseBtnClicked = false;
            mIsStopBtnClicked = false;
            mTryTimes = 0;
            mlastFrameSize = 0;
            formCaller.InitExportStartBtn();
            formCaller.SetExportProgress(0);
        }

        private void ExportDecision()
        {
            if (mIsStopBtnClicked)
            {
                mIsStopBtnClicked = false;
                mIsPauseBtnClicked = false;
                mExportStatus = ExporterStatus.EXPORT_SEND_END;
            }
            else if (mIsPauseBtnClicked)
            {
                mExportStatus = ExporterStatus.EXPORT_PAUSE;
                UInt32 recvDatLen = mSlidCrcStartSeqFromSlave * mFrameSize + mSlidDataSizeFromSlave;
                formCaller.UpdateHexDataView(mExportDataBuf, (int)recvDatLen);
            }
            else
            {
                if (mSlidCrcCal == mSlidCrcFromSlave)
                {
                    formCaller.LogMsg("\r\n滑窗CRC校验通过\r\n");
                    mSlidWinCnt++;                  
                    UInt32 recvDatLen = (UInt32)(mSlidWinCnt * (mFrameSize * mSlidWinNum));                   
                    if (mLastSlidWinTotalNum > 0)
                    {
                        formCaller.SetExportProgress((int)((recvDatLen * 100) / (int)(UInt32)((mSlidWinTotalNum + 1) * (mFrameSize * mSlidWinNum))));

                    }
                    else
                    {
                        formCaller.SetExportProgress((int)((recvDatLen * 100) / (int)(UInt32)((mSlidWinTotalNum) * (mFrameSize * mSlidWinNum))));
                    }  

                    if (mSlidWinCnt > mSlidWinTotalNum)
                    {
                        formCaller.LogMsg("\r\n文件传输完成\r\n");
                        mExportStatus = ExporterStatus.EXPORT_SEND_END;
                        return;
                    }
                    else if (mSlidWinCnt == mSlidWinTotalNum)
                    {
                        mSlidWinNumTmp = mLastSlidWinTotalNum;
                    }
                    else
                    {
                        mSlidWinNumTmp = mSlidWinNum;
                    }

                    if (mSlidWinNumTmp == 0)
                    {
                        formCaller.SetExportProgress((int)100);
                        formCaller.LogMsg("\r\nx文件传输完成\r\n");
                        mExportStatus = ExporterStatus.EXPORT_SEND_END;
                        return;
                    }

                    mStartSequence = (uint)(mSlidWinCnt * mSlidWinNum);
                    mSlidDataSizeFromSlave = 0;
                    mExportStatus = ExporterStatus.EXPORT_SEND_TRANSFER;
                }
                else
                {
                    mTryTimes++;
                    if (mTryTimes > 3)
                    {
                        mTryTimes = 0;
                        formCaller.LogMsg("\r\n滑窗CRC校验不通过，超过次数，结束传输\r\n");
                        mExportStatus = ExporterStatus.EXPORT_SEND_END_WAIT;
                    }
                    else
                    {
                        formCaller.LogMsg("\r\n滑窗CRC校验不通过，重新传输\r\n");
                        mExportStatus = ExporterStatus.EXPORT_SEND_TRANSFER;
                    }
                }
            }
        }
       
        private void CalSlidWinCrc()
        {
            byte[] crcDat = new byte[mSlidWinNum * mFrameSize];
            UInt32 startId = mStartSequence * mFrameSize;
            int crcLen = crcDat.Length;            

            if (mSlidWinCnt == mSlidWinTotalNum)
            {
                if (mLastSlidWinTotalNum > 0)
                {
                    crcLen = (int)mFileSizeFromSlave - mSlidWinTotalNum * mSlidWinNum * mFrameSize;
                }
                else 
                {
                    crcLen = mSlidWinNumTmp * mFrameSize;
                }
            }            

            for (int i = 0; i < crcLen; i++)
            {
                crcDat[i] = mExportDataBuf[startId + i];
            }

            mSlidCrcCal = ModbusCrc.Crc16(crcDat, crcLen);
        }

        public byte[] MakeExportConsultCmd()
        {
            List<byte> sendList = new List<byte>();

            ModbusTlvProto consultCmd = new ModbusTlvProto();
            consultCmd.addr = formCaller.GetModbusAddr();
            consultCmd.cmd = (byte)ModbusCmd.EXPORT_FILE;
            consultCmd.subCmd = (byte)ExportFileSubCmd.CONSULT;
            consultCmd.tagNum = 0x04;
            consultCmd.datLen = 0x0010;
            consultCmd.tlvList = new List<TLV_Unit>();

            TLV_Unit tlv = new TLV_Unit();
            tlv.Type = 0x01;
            tlv.Length = 0x02;
            tlv.Value = new byte[2];
            tlv.Value[0] = 0x00;
            tlv.Value[1] = 0x0F;
            consultCmd.tlvList.Add(tlv);

            tlv.Type = 0x02;
            tlv.Length = 0x02;
            tlv.Value = new byte[2];
            tlv.Value[0] = 0x00;
            tlv.Value[1] = 0x80;
            consultCmd.tlvList.Add(tlv);

            tlv.Type = 0x03;
            tlv.Length = 0x02;
            tlv.Value = new byte[2];
            tlv.Value[0] = 0x00;
            tlv.Value[1] = 0x00;
            consultCmd.tlvList.Add(tlv);

            tlv.Type = 0x06;
            tlv.Length = 0x02;
            tlv.Value = new byte[2];
            tlv.Value[0] = 0x00;
            tlv.Value[1] = 0x06;
            consultCmd.tlvList.Add(tlv);

            return ModbusProto.MakeModbusFrame(consultCmd);
        }

        private byte[] MakeExportStartCmd()
        {
            List<byte> sendList = new List<byte>();

            ModbusTlvProto consultCmd = new ModbusTlvProto();
            consultCmd.addr = formCaller.GetModbusAddr();
            consultCmd.cmd = (byte)ModbusCmd.EXPORT_FILE;
            consultCmd.subCmd = (byte)ExportFileSubCmd.START;
            consultCmd.tagNum = 0x04;
            consultCmd.datLen = 0x0010;
            consultCmd.tlvList = new List<TLV_Unit>();

            TLV_Unit tlv = new TLV_Unit();
            tlv.Type = 0x01;
            tlv.Length = 0x02;
            tlv.Value = new byte[2];
            tlv.Value[0] = 0x00;
            tlv.Value[1] = 0x0F;
            consultCmd.tlvList.Add(tlv);

            tlv.Type = 0x02;
            tlv.Length = 0x02;
            tlv.Value = new byte[2];
            tlv.Value[0] = 0x00;
            tlv.Value[1] = 0x80;
            consultCmd.tlvList.Add(tlv);

            tlv.Type = 0x03;
            tlv.Length = 0x02;
            tlv.Value = new byte[2];
            tlv.Value[0] = 0x00;
            tlv.Value[1] = 0x00;
            consultCmd.tlvList.Add(tlv);

            tlv.Type = 0x04;
            tlv.Length = 0x02;
            tlv.Value = new byte[2];
            tlv.Value[0] = (byte)(formCaller.mLogSubfileType >> 8);
            tlv.Value[1] = (byte)(formCaller.mLogSubfileType & 0x00FF);
            consultCmd.tlvList.Add(tlv);

            return ModbusProto.MakeModbusFrame(consultCmd);
        }

        private byte[] MakeExportTransferCmd()
        {
            List<byte> sendList = new List<byte>();

            ModbusTlvProto consultCmd = new ModbusTlvProto();
            consultCmd.addr = formCaller.GetModbusAddr();
            consultCmd.cmd = (byte)ModbusCmd.EXPORT_FILE;
            consultCmd.subCmd = (byte)ExportFileSubCmd.TRANSFER;
            consultCmd.tagNum = 0x03;
            consultCmd.datLen = 0x000E;
            consultCmd.tlvList = new List<TLV_Unit>();

            TLV_Unit tlv = new TLV_Unit();
            tlv.Type = 0x01;
            tlv.Length = 0x02;
            tlv.Value = new byte[2];
            tlv.Value[0] = (byte)(mLogTaskIdFromSlave >> 8);
            tlv.Value[1] = (byte)(mLogTaskIdFromSlave & 0x00FF);
            consultCmd.tlvList.Add(tlv);

            tlv.Type = 0x02;
            tlv.Length = 0x04;
            tlv.Value = new byte[tlv.Length];
            tlv.Value[0] = (byte)(mStartSequence >> 24);
            tlv.Value[1] = (byte)(mStartSequence >> 16);
            tlv.Value[2] = (byte)(mStartSequence >> 8);
            tlv.Value[3] = (byte)(mStartSequence & 0xFF);
            consultCmd.tlvList.Add(tlv);

            tlv.Type = 0x03;
            tlv.Length = 0x02;
            tlv.Value = new byte[2];

            if (mSlidWinCnt == mSlidWinTotalNum)
            {
                mSlidWinNumTmp = mLastSlidWinTotalNum;
            }
            else
            {
                mSlidWinNumTmp = mSlidWinNum;
            }
            tlv.Value[0] = (byte)(mSlidWinNumTmp >> 8);
            tlv.Value[1] = (byte)(mSlidWinNumTmp & 0x00FF);
            consultCmd.tlvList.Add(tlv);

            return ModbusProto.MakeModbusFrame(consultCmd);
        }

        private byte[] MakeExportEndCmd()
        {
            List<byte> sendList = new List<byte>();

            ModbusTlvProto consultCmd = new ModbusTlvProto();
            consultCmd.addr = formCaller.GetModbusAddr();
            consultCmd.cmd = (byte)ModbusCmd.EXPORT_FILE;
            consultCmd.subCmd = (byte)ExportFileSubCmd.FILE_END;
            consultCmd.tagNum = 0x02;
            consultCmd.datLen = 0x0008;
            consultCmd.tlvList = new List<TLV_Unit>();

            TLV_Unit tlv = new TLV_Unit();
            tlv.Type = 0x01;
            tlv.Length = 0x02;
            tlv.Value = new byte[2];
            tlv.Value[0] = (byte)(mLogTaskIdFromSlave >> 8);
            tlv.Value[1] = (byte)(mLogTaskIdFromSlave & 0x00FF);
            consultCmd.tlvList.Add(tlv);

            ushort crc = ModbusCrc.Crc16(mExportDataBuf, (int)mFileSizeFromSlave);

            tlv.Type = 0x02;
            tlv.Length = 0x02;
            tlv.Value = new byte[2];
            tlv.Value[0] = (byte)(crc >> 8);
            tlv.Value[1] = (byte)(crc & 0x00FF);
            consultCmd.tlvList.Add(tlv);

            return ModbusProto.MakeModbusFrame(consultCmd);
        }

        public void GetExportConsultResult(ModbusTlvProto tlvFrame)
        {
            formCaller.LogMsg("TAG数：" + tlvFrame.tagNum.ToString(), true);
            ushort len = tlvFrame.datLen;
            formCaller.LogMsg("数据长度： " + len.ToString(), true);
            if (tlvFrame.tlvList == null)
            {
                return;
            }

            mLogSubfileTypeObjs.Clear();
            mLogSubfileTypeObjs = new List<LogSubfileTypeObj>();

            for (int i = 0; i < tlvFrame.tagNum; i++)
            {
                TLV_Unit tlv = tlvFrame.tlvList[i];
                formCaller.LogMsg("Type：" + tlv.Type.ToString() + ", ");
                formCaller.LogMsg("Length：" + tlv.Length.ToString() + ", ");
                if (tlv.Length != 0x00)
                {
                    formCaller.LogMsg("Value：", false);
                    formCaller.LogMsg(tlv.Value, true);
                }

                switch (tlv.Type)
                {
                    case 0x01:
                        mFileTypeFromSlave = (ushort)((tlv.Value[0] << 8) + tlv.Value[1]);
                        break;
                    case 0x02:
                        //mFrameSize = (ushort)((tlv.Value[0] << 8) + tlv.Value[1]);
                        break;
                    case 0x05:
                        LogSubfileTypeObj Subfile = new LogSubfileTypeObj(tlv.Value[1]);
                        mLogSubfileTypeObjs.Add(Subfile);
                        break;
                    default:
                        break;
                }
            }
            formCaller.LogMsg("crc：" + tlvFrame.crc.ToString(), true);
            formCaller.ExportConsultResult();            
        }

        public void GetExportStartResult(byte[] dataBuf)
        {
            if (dataBuf.Length < 36)
            {
                return;
            }
            if (dataBuf[1] == 0x41 && dataBuf[2] == 0x02)
            {
                mIsGetAckFromSlave = true;
                mFileSizeFromSlave = (UInt32)((dataBuf[12] << 24) + (dataBuf[13] << 16) + (dataBuf[14] << 8) + dataBuf[15]);
                formCaller.UpdateLabFileInfo("文件大小：" + mFileSizeFromSlave.ToString());
            }
        }            

        public void DataRecvProcess(byte[] buf)
        {
            if (mExportStatus == ExporterStatus.EXPORT_SEND_START_WAIT)
            {
                //if ((formCaller.GetConnectObj() == (byte)ConnectObj.CONNECT_OBJ_BACKUP_BOX) && buf.Length < 32)
                //{
                //    return;
                //}

                //if ((formCaller.GetConnectObj() != (byte)ConnectObj.CONNECT_OBJ_BACKUP_BOX) && buf.Length < 34)
                //{
                //    return;
                //}

                if (buf[1] == 0x41 && buf[2] == 0x02)
                {
                    mFileSizeFromSlave = (UInt32)((buf[12] << 24) + (buf[13] << 16) + (buf[14] << 8) + buf[15]);
                    formCaller.UpdateLabFileInfo("文件大小：" + mFileSizeFromSlave.ToString());
                    if (mFileSizeFromSlave > 0)
                    {
                        int frameNum = (int)(mFileSizeFromSlave / mFrameSize);
                        if ((int)(mFileSizeFromSlave % mFrameSize) != 0)
                        {
                            frameNum++;
                        }
                        mExportDataBuf = new byte[frameNum * mFrameSize];                        
                        mSlidWinTotalNum = (ushort)(mFileSizeFromSlave / (mFrameSize * mSlidWinNum));
                        mLastSlidWinTotalNum = (ushort)(mFileSizeFromSlave % (mFrameSize * mSlidWinNum) / mFrameSize);                      
                        if ((mFileSizeFromSlave % (mFrameSize * mSlidWinNum) % mFrameSize) != 0)
                        {
                            mLastSlidWinTotalNum++;
                            mlastFrameSize = (ushort)((mFileSizeFromSlave % (mFrameSize * mSlidWinNum) % mFrameSize));
                        }
                    }

                    //if (formCaller.GetConnectObj() == (byte)ConnectObj.CONNECT_OBJ_BACKUP_BOX)
                    //{
                    //    mIsGetAckFromSlave = true;
                    //}
                    //else 
                    //{
                        switch (buf[34])
                        {
                            case 0x00:
                                formCaller.LogMsg("启动未开始\r\n");
                                break;
                            case 0x01:
                                formCaller.LogMsg("启动准备中\r\n");
                                break;
                            case 0x02:
                                formCaller.LogMsg("启动准备完成\r\n");
                                mIsGetAckFromSlave = true;
                                break;
                            case 0x03:
                                formCaller.LogMsg("启动准备失败\r\n");
                                break;
                            default:
                                break;
                        }
                    //}                    
                    mLogTaskIdFromSlave = (ushort)((buf[26] << 8) + (buf[27]));
                }
            }
            else if (mExportStatus == ExporterStatus.EXPORT_SEND_TRANSFER_WAIT)
            {
                if (buf[2] == 0x03)
                {
                    ushort frameLen = (ushort)((buf[4] << 8) + (buf[5]));
                    if (buf.Length < frameLen + 8)
                    {
                        return;
                    }
                    UInt32 sequence = (UInt32)((buf[12] + (buf[13] << 16) + (buf[14] << 8) + buf[15]));
                    ushort datLen = (ushort)((buf[18] << 8) + buf[19]); 
                    UInt32 startId = sequence * mFrameSize;

                    mSlidDataSizeFromSlave += datLen;
                    if (mExportDataBuf.Length < startId + datLen)
                    {
                        return;
                    }
                    for (ushort i = 0; i < datLen; i++)
                    {
                        mExportDataBuf[startId + i] = buf[22 + i];
                    }                    
                    formCaller.LogMsg("+");

                    if (mSlidWinCnt == mSlidWinTotalNum && mLastSlidWinTotalNum == 1)
                    {
                        formCaller.SetExportProgress((int)100);
                        formCaller.LogMsg("\r\n文件传输完成\r\n");
                        mExportStatus = ExporterStatus.EXPORT_SEND_END;
                        return;
                    }
                }
                else if (buf[2] == 0x05)
                {
                    ushort frameLen = (ushort)((buf[4] << 8) + (buf[5]));
                    if (buf.Length < frameLen + 8)
                    {
                        return;
                    }
                    mSlidCrcStartSeqFromSlave = (UInt32)((buf[12] + (buf[13] << 16) + (buf[14] << 8) + buf[15]));
                    mSlidCrcWinNumFromSlave = (ushort)((buf[18] << 8) + (buf[19]));
                    mSlidCrcFromSlave = (ushort)((buf[22] << 8) + (buf[23]));
                    mSlidCrcCal = 0;
                    mIsGetAckFromSlave = true;
                }
            }
            else if (mExportStatus == ExporterStatus.EXPORT_SEND_END_WAIT)
            {
                if (buf.Length < 13)
                {
                    return;
                }
				if (buf[2] == 0x04)
                {
                    mFileCrcFromSlave = (ushort)((buf[12] << 8) + (buf[13]));
                    mIsGetAckFromSlave = true;
                }
            }
        }

        public void ExporterRecvNormalProcess(byte[] dataBuf)
        {
            if (dataBuf[1] == (byte)ModbusCmd.EXPORT_FILE)
            {
                switch (dataBuf[2])
                {
                    case (byte)ExportFileSubCmd.CONSULT:
                        GetExportConsultResult(ModbusProto.GetModbusTlvFrame(dataBuf));
                        break;
                    case (byte)ExportFileSubCmd.START:
                        GetExportStartResult(dataBuf);
                        break;
                    default:
                        break;
                }
            }
        }

        public byte[] GetRecvDataBuf()
        {
            byte[] datBuf = new byte[mExportDataLen];
            for (int i = 0; i < mExportDataLen; i++)
            {
                datBuf[i] = mExportDataBuf[i];
            }
            return datBuf;
        }
		
    }
}
