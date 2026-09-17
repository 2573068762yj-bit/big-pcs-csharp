using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcDebuger
{
    class LogAnalysis
    {
        enum LogIdType : uint
        {
            LOG_ID_ALARM = (((uint)0x00000001 << 16) | 0x00000000),
            LOG_ID_FSM_STATE = (((uint)0x00000001 << 17) | 0x00000000),
            LOG_ID_DERATE_VOLT = (((uint)0x00000001 << 18) | 0x00000000),
            LOG_ID_DERATE_TEMP = (((uint)0x00000001 << 18) | 0x00000001),
            LOG_ID_PARAM_CFG = (((uint)0x00000001 << 19) | 0x00000000),
            LOG_ID_VRT = (((uint)0x00000001 << 20) | 0x00000000),
            LOG_ID_VOLT_DYN = (((uint)0x00000001 << 20) | 0x00000001),
            LOG_ID_RESET = (((uint)0x00000001 << 21) | 0x00000000),
            LOG_ID_INVM_CTRL = (((uint)0x00000001 << 21) | 0x00000001),
        }

        enum OnGridLogIdType : uint
        {
            LOG_ID_ALARM = (((uint)0x00000001 << 16) | 0x00000000),
            LOG_ID_FSM_STATE = (((uint)0x00000001 << 17) | 0x00000000),
            LOG_ID_DERATE_VOLT = (((uint)0x00000001 << 18) | 0x00000000),
            LOG_ID_DERATE_TEMP = (((uint)0x00000001 << 18) | 0x00000001),
            LOG_ID_PARAM_CFG = (((uint)0x00000001 << 19) | 0x00000000),
            LOG_ID_VRT = (((uint)0x00000001 << 20) | 0x00000000),
            LOG_ID_VOLT_DYN = (((uint)0x00000001 << 20) | 0x00000001),
            LOG_ID_RESET = (((uint)0x00000001 << 21) | 0x00000000),
        }

        enum BkpLogIdType : uint
        {
            LOG_ID_ALARM = (((uint)0x00000001 << 16) | 0x00000000),
            LOG_ID_FSM_STATE = (((uint)0x00000001 << 17) | 0x00000000),
            LOG_ID_DERATE_VOLT = (((uint)0x00000001 << 18) | 0x00000000),
            LOG_ID_DERATE_TEMP = (((uint)0x00000001 << 18) | 0x00000001),
            LOG_ID_PARAM_CFG = (((uint)0x00000001 << 19) | 0x00000000),
            LOG_ID_COMMON_LVRT = (((uint)0x00000001 << 20) | 0x00000000),
            LOG_ID_COMMON_HVRT = (((uint)0x00000001 << 20) | 0x00000001),
            LOG_ID_RESET = (((uint)0x00000001 << 21) | 0x00000000),
            LOG_ID_BYPASS = (((uint)0x00000001 << 22) | 0x00000000),
            LOG_ID_SYSTEM = (((uint)0x00000001 << 23) | 0x00000000),
        }

        enum FsmState : short
        {
            FSM_STATE_INIT = 0,
            FSM_STATE_IDLE = 1,
            FSM_STATE_START = 2,
            FSM_STATE_RUN = 3,
            FSM_STATE_STANDBY = 4,
            FSM_STATE_SHUTDOWN = 5,
        }

        enum OnGridFsmState : short //并网版本/备电盒共用
        {
            FSM_STATE_INIT = 0,
            FSM_STATE_IDLE = 1,
            FSM_STATE_START = 2,
            FSM_STATE_RUN = 3,
            FSM_STATE_SHUTDOWN = 4,
        }

        enum BkpLogSysState : short
        {
            LOG_SYS_ONOFFGRID = 0,
            LOG_SYS_BLACKSTART,
            LOG_SYS_ENERGY_CTRL,
            LOG_SYS_NETWORK,
            LOG_SYS_PCSMSM,
        }

        enum AlarmId : short
        {
            ALARM_ID_PVA_OV = 0,
            ALARM_ID_PVB_OV,
            ALARM_ID_GRID_OFF_CONNECT,
            ALARM_ID_GRID_UNDER_VOLT,
            ALARM_ID_GRID_OVER_VOLT,
            ALARM_ID_GRID_UNDER_FREQ,
            ALARM_ID_GRID_OVER_FREQ,
            ALARM_ID_OVER_DCI,
            ALARM_ID_ISO_FAULT,

            ALARM_ID_PVA_UV,
            ALARM_ID_PVB_UV,
            ALARM_ID_PVA_OC,
            ALARM_ID_PVB_OC,
            ALARM_ID_MPPTA_OC,
            ALARM_ID_MPPTB_OC,
            ALARM_ID_BUS_OV,

            ALARM_ID_GRID_OVI,
            ALARM_ID_GRID_OVII,
            ALARM_ID_GRID_UVI,
            ALARM_ID_GRID_UVII,
            ALARM_ID_GRID_OFI,
            ALARM_ID_GRID_OFII,
            ALARM_ID_GRID_UFI,
            ALARM_ID_GRID_UFII,
            ALARM_ID_GRID_OV_10MIN,

            ALARM_ID_AUX_FAULT,
            ALARM_ID_EEPROM_FAULT,
            ALARM_ID_ANALOG_FAULT,
            ALARM_ID_OCP_HARD_PROTECT,
            ALARM_ID_MOS_OT,
            ALARM_ID_PVA_REVERSE,
            ALARM_ID_IGRID_OC,
            ALARM_ID_PVA_OC_INSTANT,
            ALARM_ID_PVA_OV_INSTANT,
            ALARM_ID_IG_OC_INSTANT,
            ALARM_ID_IOUT_OC,
            ALARM_ID_VERSION,
            ALARM_ID_PVA_UV_INSTANT,
            ALARM_ID_PV_VOLT_START,
            ALARM_ID_PV_UNDER_PWR,

            ALARM_ID_PCS_RELAY_FAULT,
            ALARM_ID_BAT_OV_INSTANT,
            ALARM_ID_BAT_UV_INSTANT,
            ALARM_ID_BAT_OV,
            ALARM_ID_BAT_UV,
            ALARM_ID_UG_OV_INSTANT,
            ALARM_ID_BMS_COMM_BREAK,
            ALARM_ID_BAT_OV_HARD_PROTECT,
            ALARM_ID_BAT_OC_HARD_PROTECT,
            ALARM_ID_GRID_ROCOF,
            ALARM_ID_WIRING_FAULT,
            ALARM_ID_AC_UNDER_PWR,
            ALARM_ID_BMS_STATE_FAULT,
            ALARM_ID_OCP_ONCE,
            ALARM_ID_MCU_COMM_BREAK,
            ALARM_ID_OFFGRID_OV,
            ALARM_ID_OFFGRID_UV,
            ALARM_ID_AC_OVER_LOAD,
            ALARM_ID_BACKUP_BOX_FAULT,
            ALARM_ID_OFFGRID_STATE_FAULT,
            ALARM_ID_BLACKSTART_FAIL,
            ALARM_ID_HEATFILM_FAULT,
        }

        enum OngridAlarmId : short
        {
            ALARM_ID_PVA_OV = 0,
            ALARM_ID_PVB_OV,
            ALARM_ID_GRID_OFF_CONNECT,
            ALARM_ID_GRID_UNDER_VOLT,
            ALARM_ID_GRID_OVER_VOLT,
            ALARM_ID_GRID_UNDER_FREQ,
            ALARM_ID_GRID_OVER_FREQ,
            ALARM_ID_OVER_DCI,
            ALARM_ID_ISO_FAULT,

            ALARM_ID_PVA_UV,
            ALARM_ID_PVB_UV,
            ALARM_ID_PVA_OC,
            ALARM_ID_PVB_OC,
            ALARM_ID_MPPTA_OC,
            ALARM_ID_MPPTB_OC,
            ALARM_ID_BUS_OV,

            ALARM_ID_GRID_OVI,
            ALARM_ID_GRID_OVII,
            ALARM_ID_GRID_UVI,
            ALARM_ID_GRID_UVII,
            ALARM_ID_GRID_OFI,
            ALARM_ID_GRID_OFII,
            ALARM_ID_GRID_UFI,
            ALARM_ID_GRID_UFII,
            ALARM_ID_GRID_OV_10MIN,

            ALARM_ID_AUX_FAULT,
            ALARM_ID_EEPROM_FAULT,
            ALARM_ID_ANALOG_FAULT,
            ALARM_ID_OCP_HARD_PROTECT,
            ALARM_ID_MOS_OT,
            ALARM_ID_PVA_REVERSE,
            ALARM_ID_IGRID_OC,
            ALARM_ID_PVA_OC_INSTANT,
            ALARM_ID_PVA_OV_INSTANT,
            ALARM_ID_IG_OC_INSTANT,
            ALARM_ID_IOUT_OC,
            ALARM_ID_VERSION,
            ALARM_ID_PVA_UV_INSTANT,
            ALARM_ID_PV_VOLT_START,
            ALARM_ID_PV_UNDER_PWR,

            ALARM_ID_PCS_RELAY_FAULT,
            ALARM_ID_BAT_OV_INSTANT,
            ALARM_ID_BAT_UV_INSTANT,
            ALARM_ID_BAT_OV,
            ALARM_ID_BAT_UV,
            ALARM_ID_UG_OV_INSTANT,
            ALARM_ID_BMS_COMM_BREAK,
            ALARM_ID_BAT_OV_HARD_PROTECT,
            ALARM_ID_BAT_OC_HARD_PROTECT,
            ALARM_ID_GRID_ROCOF,
            ALARM_ID_WIRING_FAULT,
            ALARM_ID_AC_UNDER_PWR,
            ALARM_ID_BMS_STATE_FAULT,
            ALARM_ID_OCP_ONCE,
            ALARM_ID_MCU_COMM_BREAK,
            ALARM_ID_GRID_VOLT_FLICK_REPEAT,
        }

        enum BkpAlarmId : short
        {
            ALARM_ID_AUX_FAULT = 0,
            ALARM_ID_EEPROM_FAULT,
            ALARM_ID_ANALOG_FAULT,
            ALARM_ID_VERSION,
            ALARM_ID_RELAY_FAULT,
            ALARM_ID_BOX_OT,
            ALARM_ID_BYPASS_SWITCH_FAULT,
            ALARM_ID_CONNECT_PE_FAULT,
            ALARM_ID_OVER_LOAD,
        }

        enum ParamCfgId : short //B037,B020相同，暂不区分
        {
            CFG_GRID_CODE_INNER = 0,
            CFG_TURN_ON_OFF,
            CFG_INV_RUN_MODE,

            CFG_P_CTRL_PERCENT,
            CFG_P_CTRL_KW,
            CFG_Q_CTRL_PERCENT,
            CFG_Q_CTRL_KVAR,
            CFG_Q_CTRL_PF,

            CFG_GRID_OVI_THRES,
            CFG_GRID_OVI_TIME,
            CFG_GRID_OVII_THRES,
            CFG_GRID_OVII_TIME,
            CFG_GRID_UVI_THRES,
            CFG_GRID_UVI_TIME,
            CFG_GRID_UVII_THRES,
            CFG_GRID_UVII_TIME,
            CFG_GRID_OFI_THRES,
            CFG_GRID_OFI_TIME,
            CFG_GRID_OFII_THRES,
            CFG_GRID_OFII_TIME,
            CFG_GRID_UFI_THRES,
            CFG_GRID_UFI_TIME,
            CFG_GRID_UFII_THRES,
            CFG_GRID_UFII_TIME,

            CFG_ISO_THRES,
            CFG_PREF_SET,
            CFG_PCTRL_GRADIENT,
            CFG_QCTRL_GRADIENT,
            CFG_SOFT_START_TIME,
            CFG_P_CTRL_MODE,
            CFG_Q_CTRL_MODE,

            CFG_LVRT_THRES,
            CFG_HVRT_THRES,

            CFG_GRID_RECOVERY_TIME,
            CFG_GRID_RECOVERY_SOFT_START_TIME,
            CFG_GRID_VOLT_RECOVERY_UP_THRES,
            CFG_GRID_VOLT_RECOVERY_DN_THRES,
            CFG_GRID_FREQ_RECOVERY_UP_THRES,
            CFG_GRID_FREQ_RECOVERY_DN_THRES,


            CFG_QU_CURVE,
            //CFG_PU_CURVE,
            //CFG_UPDATA_MCU_APP,
            CFG_GRID_OV_THRES_10MIN,
            CFG_GRID_OV_TIME_10MIN,
            CFG_COSPHI2P_CURVE,
            CFG_PU_CURVE,

            CFG_FPM_DERATE_ONOFF,
            CFG_FPM_DERATE_TRIG_FREQ,
            CFG_FPM_DERATE_EXIT_FREQ,
            CFG_FPM_DERATE_STOP_FREQ,
            CFG_FPM_DERATE_STOP_POWER,
            CFG_FPM_DERATE_GRADIENT,
            CFG_FPM_DERATE_RECOVER_GRADIENT,
            CFG_FPM_DERATE_ROLLBACK_ONOFF,
            CFG_FPM_DERATE_DELAY,
            CFG_FPM_DERATE_RECOVER_DELAY,

            CFG_FPM_RISE_ONOFF,
            CFG_FPM_RISE_TRIG_FREQ,
            CFG_FPM_RISE_EXIT_FREQ,
            CFG_FPM_RISE_STOP_FREQ,
            CFG_FPM_RISE_STOP_POWER,
            CFG_FPM_RISE_GRADIENT,
            CFG_FPM_RISE_RECOVER_GRADIENT,
            CFG_FPM_RISE_ROLLBACK_ONOFF,
            CFG_FPM_RISE_DELAY,
            CFG_FPM_RISE_RECOVER_DELAY,
            CFG_GRID_CODE_OUTER,
            CFG_GRID_VOLT_RATED,
            CFG_GRID_FREQ_RATED,
            CFG_GRID_TYPE,

            CFG_HVRT_ONOFF,
            CFG_LVRT_ONOFF,
            CFG_SMS_ONOFF,
            CFG_HVRT_CURVE,
            CFG_LVRT_CURVE,
            CFG_COSPHI2P_LOCK_IN_VOLT,
            CFG_COSPHI2P_LOCK_OUT_VOLT,
            CFG_QUCURVE_FLT_TIME,
            CFG_QUCURVE_PF_MIN,
            CFG_QUCURVE_LOCK_IN_POWER,
            CFG_QUCURVE_LOCK_OUT_POWER,
            CFG_PUCURVE_FLT_TIME,
            CFG_ISO_ONOFF,
            CFG_COSPHI2P_FLT_TIME,
            CFG_QP_CURVE,
            CFG_QP_FLT_TIME,

            CFG_SELF_DETECT_TIME,
            CFG_SELF_DETECT_SOFT_START_TIME,
            CFG_SELF_DETECT_GRID_VOLT_UP_THRES,
            CFG_SELF_DETECT_GRID_VOLT_DN_THRES,
            CFG_SELF_DETECT_GRID_FREQ_UP_THRES,
            CFG_SELF_DETECT_GRID_FREQ_DN_THRES,

            //	CFG_ROCOF_THRES,
            //	CFG_ROCOF_ONOFF,
            CFG_Q_CTRL_KVAR_FLT_TIME,
            CFG_Q_CTRL_PERCENT_FLT_TIME,
            CFG_Q_CTRL_PF_FLT_TIME,
            CFG_PFMC_ONOFF,
            CFG_PFMC_DROOP,
            CFG_PFMC_FREQ_DEAD_ZONE,
            CFG_PFMC_PDELTA_MAX,
            CFG_PFMC_POUT_GRADIENT,
        }

        enum BkpParamCfgId : short
        {
            CFG_GRID_CODE_INNER = 0,
            CFG_OFFGRID_SWITCH_MODE,
            CFG_OILENGINE_CONNECT,
            CFG_OILENGINE_SWITCH_MODE,
            CFG_OILENGINE_START_SOC,
            CFG_OILENGINE_STOP_SOC,
            CFG_OILENGINE_PN,
            CFG_ATS,
            CFG_LVRT_THRES,
            CFG_HVRT_THRES,
            CFG_GRID_CODE_OUTER,
            CFG_GRID_VOLT_RATED,
            CFG_GRID_FREQ_RATED,
            CFG_GRID_TYPE,
            CFG_HVRT_ONOFF,
            CFG_LVRT_ONOFF,
            CFG_HVRT_CURVE,
            CFG_LVRT_CURVE,
            CFG_PV_CONNECT,
        }

        public class LogFormat
        {
            public uint mLogId;
            public DateTime mDateTime;
            public ushort mDatLen;
            public short[] mDatBuf;
        }

        public class LogObj
        {
            public uint mAddr;
            public byte[] mOriginDat;
            public LogFormat mLog;
        }

        public List<LogObj> mLogObjs;
        private MainForm formCaller;

        public LogAnalysis(MainForm f)
        {
            formCaller = f;
            mLogObjs = new List<LogObj>();
        }

        public bool ChangeHex2LogFormat(ref LogObj log)
        {
            int offset = 2;
            uint logId = (uint)((log.mOriginDat[offset + 1] << 24) + (log.mOriginDat[offset] << 16) + (log.mOriginDat[offset + 3] << 8) + log.mOriginDat[offset + 2]);
            offset += 8;
            uint timeStampL = (uint)((log.mOriginDat[offset + 1] << 24) + (log.mOriginDat[offset] << 16) + (log.mOriginDat[offset + 3] << 8) + log.mOriginDat[offset + 2]);
            DateTime dateTime = MainForm.TimestampConverter.ConvertUnixTimeStampToDateTime((double)timeStampL);
            offset += 4;
            ushort datLen = (ushort)((log.mOriginDat[offset + 1] << 8) + log.mOriginDat[offset]);
            offset += 2;
            short[] datBuf = new short[datLen];
            for (ushort i = 0; i < datLen; i++)
            {
                datBuf[i] = (short)((log.mOriginDat[offset + 1 + 2 * i] << 8) + log.mOriginDat[offset + 2 * i]);
            }

            log.mLog = new LogFormat();
            log.mLog.mLogId = logId;
            log.mLog.mDateTime = dateTime;
            log.mLog.mDatLen = datLen;
            log.mLog.mDatBuf = datBuf;

            return true;
        }

        public void ShowLog(List<LogObj> logObjs)
        {
            //formCaller.LogMsg("addr/hex: time, logId, subLogId/data[0](Dec), logContent(Dec)\r\n");
            formCaller.LogMsg("页码/日志时间, 地址/日志ID, 日志子ID, 日志数据0,	日志数据1,日志数据2,日志数据3,日志数据4,日志数据5,日志数据6,日志数据7,日志数据8,日志数据9,日志数据10,"+
                                                                    "日志数据11,日志数据12,日志数据13,日志数据14,日志数据15,日志数据16,日志数据17,日志数据18,日志数据19,日志数据20,"+
                                                                    "日志数据21,日志数据22,日志数据23,日志数据24,日志数据25,日志数据26,日志数据27,日志数据28,日志数据29,\r\n");
            for (int i = 0; i < logObjs.Count; i++)
            {
                LogObj log = logObjs[i];

                if (log.mAddr % 0x200 == 0)
                {
                    if (log.mAddr % 0x1000 == 0)
                    {
                        uint sectorId = log.mAddr / 0x1000;
                        formCaller.LogMsg("\r\nSector " + sectorId.ToString() + ":\r\n");
                    }
                    byte[] addr = new byte[4];
                    addr[0] = (byte)(log.mAddr >> 24);
                    addr[1] = (byte)(log.mAddr >> 16);
                    addr[2] = (byte)(log.mAddr >> 8);
                    addr[3] = (byte)(log.mAddr >> 0);
                    uint pageId = log.mAddr / 0x200;

                    formCaller.LogMsg("Page " + pageId.ToString() + ", ");
                    formCaller.LogMsg("Addr = ");
                    formCaller.LogMsg(addr, false);
                    formCaller.LogMsg(": \r\n");
                }

                if (formCaller.mPrintOriginLogFlag == 0x01)
                {
                    formCaller.LogMsg(String.Format("0x{0:X8}, ", log.mAddr));
                    formCaller.LogMsg(log.mOriginDat, false);
                    formCaller.LogMsg(", \r\n");
                }


                string logIdStr;
                string subLogIdStr;
                bool isMember;

                //if ((formCaller.GetConnectObj() == (byte)ConnectObj.CONNECT_OBJ_BACKUP_BOX))
                //{
                //    isMember = Enum.IsDefined(typeof(BkpLogIdType), log.mLog.mLogId);
                //}
                //else if (formCaller.mPcsVerType == (byte)PcsVerType.PCS_VER_ONGRID_TYPE)
                //{
                //    isMember = Enum.IsDefined(typeof(OnGridLogIdType), log.mLog.mLogId);
                //}
                //else 
                //{
                    isMember = Enum.IsDefined(typeof(LogIdType), log.mLog.mLogId);
                //}
                
                if (isMember)
                {
                    LogIdType logIdEm = (LogIdType)log.mLog.mLogId;
                    OnGridLogIdType OnGridlogIdEm = (OnGridLogIdType)log.mLog.mLogId;
                    BkpLogIdType BkplogIdEm = (BkpLogIdType)log.mLog.mLogId;

                    //if ((formCaller.GetConnectObj() == (byte)ConnectObj.CONNECT_OBJ_BACKUP_BOX))
                    //{
                    //    logIdStr = BkplogIdEm.ToString();
                    //}
                    //else if (formCaller.mPcsVerType == (byte)PcsVerType.PCS_VER_ONGRID_TYPE)
                    //{
                    //    logIdStr = OnGridlogIdEm.ToString();
                    //}
                    //else
                    //{
                        logIdStr = logIdEm.ToString();
                    //}
                    
                    bool isSubMember = false;
                    if (logIdEm == LogIdType.LOG_ID_FSM_STATE)
                    {
                        //if ((formCaller.GetConnectObj() == (byte)ConnectObj.CONNECT_OBJ_BACKUP_BOX) || (formCaller.mPcsVerType == (byte)PcsVerType.PCS_VER_ONGRID_TYPE))
                        //{
                        //    isSubMember = Enum.IsDefined(typeof(OnGridFsmState), log.mLog.mDatBuf[0]);
                        //    if (isSubMember)
                        //    {
                        //        OnGridFsmState subLogIdEm = (OnGridFsmState)log.mLog.mDatBuf[0];
                        //        subLogIdStr = subLogIdEm.ToString();
                        //    }
                        //    else
                        //    {
                        //        subLogIdStr = log.mLog.mDatBuf[0].ToString();
                        //    }
                        //}
                        //else 
                        //{
                            isSubMember = Enum.IsDefined(typeof(FsmState), log.mLog.mDatBuf[0]);
                            if (isSubMember)
                            {
                                FsmState subLogIdEm = (FsmState)log.mLog.mDatBuf[0];
                                subLogIdStr = subLogIdEm.ToString();
                            }
                            else
                            {
                                subLogIdStr = log.mLog.mDatBuf[0].ToString();
                            }
                        //}  
                    }
                    else if (logIdEm == LogIdType.LOG_ID_ALARM)
                    {
                        //if (formCaller.GetConnectObj() == (byte)ConnectObj.CONNECT_OBJ_BACKUP_BOX)
                        //{
                        //    isSubMember = Enum.IsDefined(typeof(BkpAlarmId), log.mLog.mDatBuf[0]);
                        //    if (isSubMember)
                        //    {
                        //        BkpAlarmId subLogIdEm = (BkpAlarmId)log.mLog.mDatBuf[0];
                        //        subLogIdStr = subLogIdEm.ToString();
                        //    }
                        //    else
                        //    {
                        //        subLogIdStr = log.mLog.mDatBuf[0].ToString();
                        //    }
                        //}
                        //else if (formCaller.mPcsVerType == (byte)PcsVerType.PCS_VER_ONGRID_TYPE)
                        //{
                        //    isSubMember = Enum.IsDefined(typeof(OngridAlarmId), log.mLog.mDatBuf[0]);
                        //    if (isSubMember)
                        //    {
                        //        OngridAlarmId subLogIdEm = (OngridAlarmId)log.mLog.mDatBuf[0];
                        //        subLogIdStr = subLogIdEm.ToString();
                        //    }
                        //    else
                        //    {
                        //        subLogIdStr = log.mLog.mDatBuf[0].ToString();
                        //    }
                        //}
                        //else 
                        //{
                            isSubMember = Enum.IsDefined(typeof(AlarmId), log.mLog.mDatBuf[0]);
                            if (isSubMember)
                            {
                                AlarmId subLogIdEm = (AlarmId)log.mLog.mDatBuf[0];
                                subLogIdStr = subLogIdEm.ToString();
                            }
                            else
                            {
                                subLogIdStr = log.mLog.mDatBuf[0].ToString();
                            }
                        //}

                    }
                    else if (BkplogIdEm == BkpLogIdType.LOG_ID_SYSTEM)
                    {
                        isSubMember = Enum.IsDefined(typeof(BkpLogSysState), log.mLog.mDatBuf[0]);
                        if (isSubMember)
                        {
                            BkpLogSysState subLogIdEm = (BkpLogSysState)log.mLog.mDatBuf[0];
                            subLogIdStr = subLogIdEm.ToString();
                        }
                        else
                        {
                            subLogIdStr = log.mLog.mDatBuf[0].ToString();
                        }
                    }

                    else if (logIdEm == LogIdType.LOG_ID_PARAM_CFG)
                    {
                        //if (formCaller.GetConnectObj() == (byte)ConnectObj.CONNECT_OBJ_BACKUP_BOX)
                        //{
                        //    isSubMember = Enum.IsDefined(typeof(BkpParamCfgId), log.mLog.mDatBuf[0]);
                        //    if (isSubMember)
                        //    {
                        //        BkpParamCfgId subLogIdEm = (BkpParamCfgId)log.mLog.mDatBuf[0];
                        //        subLogIdStr = subLogIdEm.ToString();
                        //    }
                        //    else
                        //    {
                        //        subLogIdStr = log.mLog.mDatBuf[0].ToString();
                        //    }
                        //}
                        //else
                        //{
                            isSubMember = Enum.IsDefined(typeof(ParamCfgId), log.mLog.mDatBuf[0]);
                            if (isSubMember)
                            {
                                ParamCfgId subLogIdEm = (ParamCfgId)log.mLog.mDatBuf[0];
                                subLogIdStr = subLogIdEm.ToString();
                            }
                            else
                            {
                                subLogIdStr = log.mLog.mDatBuf[0].ToString();
                            }
                        //}
                    }
                    else
                    {
                        //subLogIdStr = String.Format("0x{0:X4}", log.mLog.mDatBuf[0]);
                        subLogIdStr = log.mLog.mDatBuf[0].ToString();
                    }
                }
                else
                {
                    logIdStr = log.mLog.mLogId.ToString(); 
					subLogIdStr = log.mLog.mDatBuf[0].ToString();
                }

                string logBuf = "";
                for (int j = 1; j < log.mLog.mDatBuf.Length; j++)
                {
                    //logBuf += String.Format("0x{0:X4}, ", log.mLog.mDatBuf[j]);
                    logBuf += log.mLog.mDatBuf[j].ToString() + ", ";
                }
                formCaller.LogMsg(log.mLog.mDateTime.ToString() + ", " + logIdStr + ", " + subLogIdStr + ", " + logBuf + "\r\n");
            }
        }

        public void Analysis(byte[] dataBuf, int len)
        {
            uint offset = 0;
            uint start = 0;
            if (len < 16)
            {
                return;
            }
            mLogObjs.Clear();
            while (offset < len)
            {
                try
                {
                    if (dataBuf[offset] == 0xFE && dataBuf[offset + 1] == 0xFE)
                    {
                        start = offset;
                        offset += 14;
                        ushort datLen = (ushort)((dataBuf[offset + 1] << 8) + dataBuf[offset]);
                        if (datLen < 200)
                        {
                            offset = offset + 2 + (uint)(datLen * 2);
                            LogObj logObj = new LogObj();
                            logObj.mAddr = start;
                            logObj.mOriginDat = new byte[offset - start];
                            for (int i = 0; i < offset - start; i++)
                            {
                                logObj.mOriginDat[i] = dataBuf[start + i];
                            }
                            ChangeHex2LogFormat(ref logObj);
                            mLogObjs.Add(logObj);
                        }
                        else
                        {
                            offset++;
                        }
                    }
                    else
                    {
                        offset++;
                    }
                }
                catch
                {
                    formCaller.LogMsg("转换异常\r\n");
                    break;
                }
            }

            if (mLogObjs.Count != 0)
            {
                ShowLog(mLogObjs);
            }
        }
    }
}
