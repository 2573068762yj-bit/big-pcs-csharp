using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;


namespace PcDebuger
{
    public enum ProtoType : byte
    {
        CMD = 0x00,
        MODBUS = 0x01,
        SOUTH_DEV = 0x02,
    }

    public enum DataType
    {
        INT16 = 0x02,
        INT32 = 0x03,
        UINT16 = 0x00,
        UINT32 = 0x01,
    }

    public enum NumberBase
    {        
        DECIMAL = 0x00,
        HEXADECIMAL = 0x01,
        BINARY = 0x02,
        OCTAL = 0x03,
    }

    public enum MsgName : ushort
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

        RunState,
        PrefChgDisChg,
        Pout,
        InternalDebug,
        FsmStatus,
        AlarmGroup1,
        AlarmGroup2,
        PrimaryNtcTemp,
        SecondaryNtcTemp,
        AnalogData,
        Version,
        PcsStateAnalog,
        BmsRunState,
    }

    public delegate void CmdDataProcess();

    public class RegCmdPair
    {
	    public ushort regAddr;
        public ushort writeCmd;
        public ushort readCmd;
        public ushort datLen;
        public byte[] pDat;
        public ushort zoomFactor;
        public bool isReady;
        public string name;

        public RegCmdPair(ushort addr, ushort wCmd, ushort rCmd, ushort len, byte[] dat, ushort factor, bool ready, string nm)
        {
            regAddr = addr;
            writeCmd = wCmd;
            readCmd = rCmd;
            datLen = len;
            pDat = dat;
            zoomFactor = factor;
            isReady = ready;
            name = nm;
        }
        public RegCmdPair()
        {
            regAddr = 0;
            writeCmd = 0;
            readCmd = 0;
            datLen = 0;
            pDat = null;
            zoomFactor = 0;
            isReady = false;
            name = null;
        }
    };

    public struct PcsCtrlObj
    {
        public ProtoType mProtoType;  // 0x01: modbus mode, 0x00: cmd mode, 0x02: south device proto
        public byte mRunState;  //  0x00：指令停机; 0x01：运行; 0x02：待机; 0x03：休眠 0x04：异常关机
        public byte mTurnOnOff;  // 0x00：关机; 0x01：开机
        public byte mInvMode; // 0x00：并网; 0x01：离网
        public double mQpfCtrl;
    }

    public class PartiParaObj
    {
        public ushort mWriteCmd;
        public ushort mReadCmd;
        public ushort mLen;
        public ushort mZoom;
        public double mMin;
        public double mMax;

        public PartiParaObj(ushort writeCmd, ushort readCmd, ushort len, ushort zoom, double min, double max)
        {
            mWriteCmd = writeCmd;
            mReadCmd = readCmd;
            mLen = len;
            mZoom = zoom;
            mMin = min;
            mMax = max;
        }

        public PartiParaObj()
        {
            mWriteCmd = 0x0000;
            mReadCmd = 0x0000;
            mLen = 0x00;
            mZoom = 0;
            mMin = 0;
            mMax = 0;
        }
    }

    partial class MainForm
    {
        public ProtoType mProtoType;  // 0x01: modbus mode, 0x00: cmd mode, 0x02: south device proto
        public byte mRunState;  //  0x00：指令停机; 0x01：运行; 0x02：待机; 0x03：休眠 0x04：异常关机
        public byte mTurnOnOff;  // 0x00：关机; 0x01：开机
        public byte mInvMode; // 0x00：并网; 0x01：离网
        public byte mVerErr;  // 0x00：版本匹配; 0x01：版本错误

        PartiParaObj[] mPartiParaObjDefine = new PartiParaObj[] { 
            new PartiParaObj( 0x2009,    0x210E,    2,   10000,     1,        1.4),//电网一级过压保护点
            new PartiParaObj( 0x200A,    0x210F,    4,   1,        50,    7200000),//电网一级过压保护时间
            new PartiParaObj( 0x200B,    0x2110,    2,   10000,     1,        1.4),//电网二级过压保护点
            new PartiParaObj( 0x200C,    0x2111,    4,   1,        50,    7200000),//电网二级过压保护时间
            new PartiParaObj( 0x200D,    0x2112,    2,   10000,  0.15,          1),//电网一级欠压保护点
            new PartiParaObj( 0x200E,    0x2113,    4,   1,        50,    7200000),//电网一级欠压保护时间
            new PartiParaObj( 0x200F,    0x2114,    2,   10000,  0.15,          1),//电网二级欠压保护点
            new PartiParaObj( 0x2010,    0x2115,    4,   1,        50,    7200000),//电网二级欠压保护时间
            new PartiParaObj( 0x2011,    0x2116,    2,   10000,     1,        1.2),//电网一级过频保护点
            new PartiParaObj( 0x2012,    0x2117,    4,   1,        50,    7200000),//电网一级过频保护时间
            new PartiParaObj( 0x2013,    0x2118,    2,   10000,     1,        1.2),//电网二级过频保护点
            new PartiParaObj( 0x2014,    0x2119,    4,   1,        50,    7200000),//电网二级过频保护时间
            new PartiParaObj( 0x2015,    0x211A,    2,   10000,   0.8,          1),//电网一级欠频保护点
            new PartiParaObj( 0x2016,    0x211B,    4,   1,        50,    7200000),//电网一级欠频保护时间
            new PartiParaObj( 0x2017,    0x211C,    2,   10000,   0.8,          1),//电网二级欠频保护点
            new PartiParaObj( 0x2018,    0x211D,    4,   1,        50,    7200000),//电网二级欠频保护时间
            new PartiParaObj( 0x2026,    0x2126,    2,   10000,     0,          1),//低电压穿越触发阈值
            new PartiParaObj( 0x2027,    0x2127,    2,   10000,     1,        1.3),//高电压穿越触发阈值
        };

        public PcsCtrlObj mPcsCtrlObjs;

        private static RegCmdPair[] mRegCmdObjs = new RegCmdPair[]{
            new RegCmdPair((ushort)MsgName.CFG_GRID_CODE_OUTER,     0x2000, 0x2100, 2, new byte[2], 1,       false, "外部电网码"),
            new RegCmdPair((ushort)MsgName.CFG_TURN_ON_OFF,         0x2001, 0x2101, 2, new byte[2], 1,       false, "开关机指令"),
            new RegCmdPair((ushort)MsgName.CFG_INV_RUN_MODE,        0x2002, 0x2102, 2, new byte[2], 1,       false, "逆变器工作模式"),
            new RegCmdPair((ushort)MsgName.CFG_P_CTRL_KW,           0x2004, 0x2104, 4, new byte[4], 10000,   false, "有功功率固定值降额"),
            new RegCmdPair((ushort)MsgName.CFG_P_CTRL_PERCENT,      0x2003, 0x2103, 2, new byte[2], 10,      false, "有功功率百分比降额"),
            new RegCmdPair((ushort)MsgName.CFG_Q_CTRL_PERCENT,      0x2005, 0x2105, 2, new byte[2], 10,      false, "无功功率百分比降额"),
            new RegCmdPair((ushort)MsgName.CFG_Q_CTRL_KVAR,         0x2006, 0x2106, 4, new byte[4], 10000,   false, "无功功率固定值降额"),
            new RegCmdPair((ushort)MsgName.CFG_Q_CTRL_PF,           0x201A, 0x211F, 2, new byte[2], 1000,    false, "无功功率PF值调度"),

            new RegCmdPair((ushort)MsgName.CFG_GRID_OVI_THRES,      0x2009, 0x210E, 2, new byte[2], 10000,   false, "电网一级过压保护点"),
            new RegCmdPair((ushort)MsgName.CFG_GRID_OVI_TIME,       0x200A, 0x210F, 4, new byte[4], 1,       false, "电网一级过压保护时间"),
            new RegCmdPair((ushort)MsgName.CFG_GRID_OVII_THRES,     0x200B, 0x2110, 2, new byte[2], 10000,   false, "电网二级过压保护点"),
            new RegCmdPair((ushort)MsgName.CFG_P_CTRL_KW,           0x200C, 0x2111, 4, new byte[4], 1,       false, "电网二级过压保护时间"),
            new RegCmdPair((ushort)MsgName.CFG_P_CTRL_KW,           0x200D, 0x2112, 2, new byte[2], 10000,   false, "电网一级欠压保护点"),
            new RegCmdPair((ushort)MsgName.CFG_P_CTRL_KW,           0x200E, 0x2113, 4, new byte[4], 1,       false, "电网一级欠压保护时间"),
            new RegCmdPair((ushort)MsgName.CFG_P_CTRL_KW,           0x200F, 0x2114, 2, new byte[2], 10000,   false, "电网二级欠压保护点"),
            new RegCmdPair((ushort)MsgName.CFG_P_CTRL_KW,           0x2010, 0x2115, 4, new byte[4], 1,       false, "电网二级欠压保护时间"),

            new RegCmdPair((ushort)MsgName.CFG_P_CTRL_KW,           0x2011, 0x2116, 2, new byte[2], 10000,   false, "电网一级过频保护点"),
            new RegCmdPair((ushort)MsgName.CFG_P_CTRL_KW,           0x2012, 0x2117, 4, new byte[4], 1,       false, "电网一级过频保护时间"),
            new RegCmdPair((ushort)MsgName.CFG_P_CTRL_KW,           0x2013, 0x2118, 2, new byte[2], 10000,   false, "电网二级过频保护点"),
            new RegCmdPair((ushort)MsgName.CFG_P_CTRL_KW,           0x2014, 0x2119, 4, new byte[4], 1,       false, "电网二级过频保护时间"),
            new RegCmdPair((ushort)MsgName.CFG_P_CTRL_KW,           0x2015, 0x211A, 2, new byte[2], 10000,   false, "电网一级欠频保护点"),
            new RegCmdPair((ushort)MsgName.CFG_P_CTRL_KW,           0x2016, 0x211B, 4, new byte[4], 1,       false, "电网一级欠频保护时间"),
            new RegCmdPair((ushort)MsgName.CFG_P_CTRL_KW,           0x2017, 0x211C, 2, new byte[2], 10000,   false, "电网二级欠频保护点"),
            new RegCmdPair((ushort)MsgName.CFG_P_CTRL_KW,           0x2018, 0x211D, 4, new byte[4], 1,       false, "电网二级欠频保护时间"),

            new RegCmdPair((ushort)MsgName.CFG_P_CTRL_KW,           0x201B, 0x2120, 2, new byte[2], 10,      false, "绝缘阻抗保护阈值"),
            new RegCmdPair((ushort)MsgName.CFG_P_CTRL_KW,           0x201D, 0x2122, 4, new byte[4], 1000,    false, "有功功率梯度"),
            new RegCmdPair((ushort)MsgName.CFG_P_CTRL_KW,           0x201E, 0x2123, 4, new byte[4], 1000,    false, "无功功率梯度"),
            new RegCmdPair((ushort)MsgName.CFG_P_CTRL_KW,           0x201F, 0x2124, 4, new byte[4], 1,       false, "开机软启时间"),
            new RegCmdPair((ushort)MsgName.CFG_P_CTRL_KW,           0x2026, 0x2126, 2, new byte[2], 10000,   false, "低电压穿越触发阈值"),
            new RegCmdPair((ushort)MsgName.CFG_P_CTRL_KW,           0x2027, 0x2127, 2, new byte[2], 10000,   false, "高电压穿越触发阈值"),

            new RegCmdPair((ushort)MsgName.CFG_P_CTRL_KW,           0x2007, 0x2107, 2, new byte[2], 1,       false, "复位指令"),
            new RegCmdPair((ushort)MsgName.CFG_P_CTRL_KW,           0x2008, 0,      2, new byte[2], 1,       false, "恢复出厂设置"),

            new RegCmdPair((ushort)MsgName.CFG_P_CTRL_KW,           0,      0x2108, 2, new byte[2], 10,      false, "电网电压"),
            new RegCmdPair((ushort)MsgName.CFG_P_CTRL_KW,           0,      0x2109, 2, new byte[2], 1000,    false, "电网频率"),
            new RegCmdPair((ushort)MsgName.CFG_P_CTRL_KW,           0,      0x210A, 2, new byte[2], 1000,    false, "功率因素PF"),
            new RegCmdPair((ushort)MsgName.CFG_P_CTRL_KW,           0,      0x210B, 2, new byte[2], 100,     false, "输出电流"),
            new RegCmdPair((ushort)MsgName.Pout,                    0,      0x210C, 4, new byte[4], 1000,    false, "输出有功功率"),
            new RegCmdPair((ushort)MsgName.CFG_P_CTRL_KW,           0,      0x210D, 4, new byte[4], 1000,    false, "输出无功功率"),

            new RegCmdPair((ushort)MsgName.AlarmGroup1,             0,      0x2130, 10, new byte[10], 1,       false, "告警组号查询1"),
            new RegCmdPair((ushort)MsgName.AlarmGroup2,             0,      0x2131, 10, new byte[10], 1,       false, "告警组号查询2"),

            new RegCmdPair((ushort)MsgName.PrimaryNtcTemp,          0,      0x2190, 2, new byte[2], 10,      false, "原边NTC温度"),
            new RegCmdPair((ushort)MsgName.SecondaryNtcTemp,        0,      0x2191, 2, new byte[2], 10,      false, "副边NTC温度"),
            new RegCmdPair((ushort)MsgName.InternalDebug,           0,      0x2192, 10, new byte[10], 1,     false, "内部调试项目"),
			new RegCmdPair((ushort)MsgName.FsmStatus,               0,      0x2507, 14, new byte[14], 1,     false, "读状态机"),
            new RegCmdPair((ushort)MsgName.AnalogData,              0,      0x1E0E, 44, new byte[44], 10000, false, "模拟量数据"),
            new RegCmdPair((ushort)MsgName.Version,                 0,      0x2125, 2,  new byte[2],  100,   false, "软件版本"),
			
            new RegCmdPair((ushort)MsgName.CFG_P_CTRL_KW, 0x2083, 0x2183, 2, new byte[2], 100,     false, "PCS电池电压采样"),
            new RegCmdPair((ushort)MsgName.CFG_P_CTRL_KW, 0x2084, 0x2184, 2, new byte[2], 100,     false, "PCS电池电流计算"),
            new RegCmdPair((ushort)MsgName.PcsStateAnalog,0,      0x2175, 12, new byte[12], 1,     false, "PCS状态模拟量"),
            new RegCmdPair((ushort)MsgName.CFG_P_CTRL_KW, 0,      0x2174, 4, new byte[4], 1000,    false, "电池放电量"),
            new RegCmdPair((ushort)MsgName.CFG_P_CTRL_KW, 0,      0x2173, 4, new byte[4], 1000,    false, "电池充电量"),
            new RegCmdPair((ushort)MsgName.CFG_P_CTRL_KW, 0,      0x2129, 2, new byte[2], 1,       false, "硬件版本号"),
            new RegCmdPair((ushort)MsgName.CFG_P_CTRL_KW, 0,      0x2137, 2, new byte[2], 1,       false, "机型ID"),
            new RegCmdPair((ushort)MsgName.CFG_P_CTRL_KW, 0,      0x2139, 4, new byte[4], 10000,   false, "额定有功功率"),
            new RegCmdPair((ushort)MsgName.CFG_P_CTRL_KW, 0,      0x213A, 4, new byte[4], 10000,   false, "最大有功功率"),
            new RegCmdPair((ushort)MsgName.CFG_P_CTRL_KW, 0,      0x213B, 4, new byte[4], 10000,   false, "最大视在功率"),
            new RegCmdPair((ushort)MsgName.CFG_P_CTRL_KW, 0,      0x213C, 4, new byte[4], 10000,   false, "最大无功功率"),

            new RegCmdPair((ushort)MsgName.CFG_P_CTRL_KW, 0x2040, 0x2140, 2, new byte[2], 1,       false, "电网故障恢复并网时间"),
            new RegCmdPair((ushort)MsgName.CFG_P_CTRL_KW, 0x2041, 0x2141, 2, new byte[2], 1,       false, "电网故障开机软启时间"),
            new RegCmdPair((ushort)MsgName.CFG_P_CTRL_KW, 0x2042, 0x2142, 2, new byte[2], 10000,   false, "电网重连电压上限"),
            new RegCmdPair((ushort)MsgName.CFG_P_CTRL_KW, 0x2043, 0x2143, 2, new byte[2], 10000,   false, "电网重连电压下限"),
            new RegCmdPair((ushort)MsgName.CFG_P_CTRL_KW, 0x2044, 0x2144, 2, new byte[2], 10000,   false, "电网重连频率上限"),
            new RegCmdPair((ushort)MsgName.CFG_P_CTRL_KW, 0x2045, 0x2145, 2, new byte[2], 10000,   false, "电网重连频率下限"),

            new RegCmdPair((ushort)MsgName.CFG_P_CTRL_KW, 0,      0x213D, 20, new byte[20], 1,     false, "机型"),

            new RegCmdPair((ushort)MsgName.CFG_P_CTRL_KW, 0x2019, 0,      2, new byte[2], 1,       false, "发电量清除"),
            new RegCmdPair((ushort)MsgName.CFG_P_CTRL_KW, 0x2028, 0,      4, new byte[4], 1,       false, "发电量校正"),
            new RegCmdPair((ushort)MsgName.CFG_P_CTRL_KW, 0x2046, 0x2146, 20, new byte[20], 1,     false, "Q-U特征曲线设置"),// 长度待定
            new RegCmdPair((ushort)MsgName.CFG_P_CTRL_KW, 0x2047, 0x2147, 2, new byte[2], 10000,   false, "十分钟过压保护点"),
            new RegCmdPair((ushort)MsgName.CFG_P_CTRL_KW, 0x2048, 0x2148, 4, new byte[4], 1,       false, "十分钟过压保护时间"),
            new RegCmdPair((ushort)MsgName.CFG_P_CTRL_KW, 0x2049, 0x2149, 20, new byte[20], 1,     false, "cosφ-P/Pn特征曲线设置"),
            new RegCmdPair((ushort)MsgName.CFG_P_CTRL_KW, 0x204A, 0x214A, 20, new byte[20], 1,     false, "P-U特征曲线设置"),
            new RegCmdPair((ushort)MsgName.CFG_P_CTRL_KW, 0x204B, 0x214B, 2, new byte[2], 1,       false, "过频降额"),
            new RegCmdPair((ushort)MsgName.CFG_P_CTRL_KW, 0x204C, 0x214C, 2, new byte[2], 10000,   false, "过频降额触发频率(Hz)"),
            new RegCmdPair((ushort)MsgName.CFG_P_CTRL_KW, 0x204D, 0x214D, 2, new byte[2], 10000,   false, "过频降额退出频率(Hz)"),
            new RegCmdPair((ushort)MsgName.CFG_P_CTRL_KW, 0x204F, 0x214F, 2, new byte[2], 1,       false, "过频降额截止频率(Hz)"),
            new RegCmdPair((ushort)MsgName.CFG_P_CTRL_KW, 0x2050, 0x2150, 2, new byte[2], 1,       false, "过频降额功率下降梯度"),
            new RegCmdPair((ushort)MsgName.CFG_P_CTRL_KW, 0x2051, 0x2151, 2, new byte[2], 1,       false, "过频降额功率恢复梯度"),

            new RegCmdPair((ushort)MsgName.RunState,      0,      0x2171, 2, new byte[2], 1,       false, "PCS工作状态"),
            new RegCmdPair((ushort)MsgName.PrefChgDisChg, 0x2072, 0x2172, 4, new byte[4], 10000,   false, "电池充放电功率运行值"),
            new RegCmdPair((ushort)MsgName.CFG_P_CTRL_KW, 0x2077, 0,      2, new byte[2], 1,       false, "BMS端风扇运行状态"),
            new RegCmdPair((ushort)MsgName.BmsRunState,   0,      0x2177, 2, new byte[2], 1,       false, "PCS内部的BMS运行状态"),            
            new RegCmdPair((ushort)MsgName.CFG_P_CTRL_KW, 0x2079, 0,      2, new byte[2], 1,       false, "BMS端加热膜供电请求"),
            new RegCmdPair((ushort)MsgName.CFG_P_CTRL_KW, 0,      0,      2, new byte[2], 1,       false, "PCS端风扇运行请求"),
            new RegCmdPair((ushort)MsgName.CFG_P_CTRL_KW, 0x2081, 0,      2, new byte[2], 100,     false, "BMS电池电压采样"),
            new RegCmdPair((ushort)MsgName.CFG_P_CTRL_KW, 0x2081, 0,      2, new byte[2], 100,     false, "BMS电池电流采样"),
            new RegCmdPair((ushort)MsgName.CFG_P_CTRL_KW, 0x2085, 0x2185, 2, new byte[2], 1,       false, "单/三相接线方式检测使能"),
            new RegCmdPair((ushort)MsgName.CFG_P_CTRL_KW, 0,      0x2186, 2, new byte[2], 1,       false, "单/三相接线方式检测结果"),
            new RegCmdPair((ushort)MsgName.CFG_P_CTRL_KW, 0x2087, 0x2187, 2, new byte[2], 1,       false, "单/三相接线方式检测信息传递"),
            new RegCmdPair((ushort)MsgName.CFG_P_CTRL_KW, 0x2088, 0,      2, new byte[2], 1,       false, "BMS板温采样"),
        };


        private void InitPcsDebugerView()
        {
            btnSelectProtoType.Click += btnSelectProtoType_Click;
            btnGenWriteCmd.Click += btnGenWriteCmd_Click;

            mProtoType = ProtoType.SOUTH_DEV;
            radioBtnCmdProto.Checked = false;
            radioBtnCmdProto.CheckedChanged += radioBtnCmdProto_CheckedChanged;
            radioBtnModbusProto.Checked = false;
            radioBtnModbusProto.CheckedChanged += radioBtnModbusProto_CheckedChanged;
            radioBtnSouthDevProto.Checked = true;
            radioBtnSouthDevProto.CheckedChanged += radioBtnSouthDevProto_CheckedChanged;

            comboBoxDecHex.Items.AddRange(new object[] { " 十进制", " 十六进制" });
            comboBoxDecHex.SelectedIndex = 0;

            comboBoxDatType.Items.AddRange(new object[] { "uint16", "uint32" , "int16" ,"int32" });
            comboBoxDatType.SelectedIndex = 0;

            btnGetRunState.Click += btnGetRunState_Click;
            mRunState = 0x00;
            radioButtonRunStateStop.Checked = true;
            radioButtonRunStateRun.Checked = false;
            radioButtonRunStateStandby.Checked = false;
            radioButtonRunStateSleep.Checked = false;
            radioButtonRunStateErrStop.Checked = false;

            btnSetTurnOnOff.Click += btnSetTurnOnOff_Click;
            btnGetTurnOnOff.Click += btnGetTurnOnOff_Click;
            mTurnOnOff = 0x00;
            radioButtonTurnOff.Checked = true;
            radioButtonTurnOff.CheckedChanged += radioButtonTurnOff_CheckedChanged;
            radioButtonTurnOn.Checked = false;
            radioButtonTurnOn.CheckedChanged += radioButtonTurnOn_CheckedChanged;

            btnSetInvMode.Click += btnSetInvMode_Click;
            btnGetInvMode.Click += btnGetInvMode_Click;
            mInvMode = 0x00;
            radioButtonOnGrid.Checked = true;
            radioButtonOnGrid.CheckedChanged += radioButtonOnGrid_CheckedChanged;
            radioButtonOffGrid.Checked = false;
            radioButtonOffGrid.CheckedChanged += radioButtonOffGrid_CheckedChanged;

            btnSetChgDisChgLimitPower.Click += btnSetChgDisChgLimitPower_Click;
            btnGetChgDisChgLimitPower.Click += btnGetChgDisChgLimitPower_Click;
            btnGetActivePower.Click += btnGetActivePower_Click;
            btnReadStatus.Click += btnReadStatus_Click;
            btnReadAlarm.Click += btnReadAlarm_Click;
            btnGetPcsTemp.Click += btnGetPcsTemp_Click;

            btnCfg_Q_CTRL_PF_W.Click += btnCfg_Q_CTRL_PF_W_Click;
            btnCfg_Q_CTRL_PF_R.Click += btnCfg_Q_CTRL_PF_R_Click;
            mPcsCtrlObjs.mQpfCtrl = 0.1;

            comboBoxParticularPara.Items.AddRange(new object[] { "电网一级过压保护点", "电网一级过压保护时间", "电网二级过压保护点", "电网二级过压保护时间", "电网一级欠压保护点",
                                                                 "电网一级欠压保护时间", "电网二级欠压保护点", "电网二级欠压保护时间", "电网一级过频保护点", "电网一级过频保护时间",
                                                                 "电网二级过频保护点", "电网二级过频保护时间", "电网一级欠频保护点", "电网一级欠频保护时间", "电网二级欠频保护点",
                                                                 "电网二级欠频保护时间", "低电压穿越触发阈值", "高电压穿越触发阈值"});
            comboBoxParticularPara.SelectedIndex = 0;
            btnSetParticularPara.Click += btnSetParticularPara_Click;
            btnGetParticularPara.Click += btnGetParticularPara_Click;

            comboHeatFilmPwrSup.Items.AddRange(new object[] { "0-停止", "1-开启模式1", "2-开启模式2", "3-不支持开启" });
            comboHeatFilmPwrSup.SelectedIndex = 0;
            btnSetHeatFilmPwrSup.Click += btnSetHeatFilmPwrSup_Click;
            btnGetHeatFilmPwrSup.Click += btnGetHeatFilmPwrSup_Click;
            btnGetPcsSoftwareVer.Click += btnGetPcsSoftwareVer_Click;
            btnSetLimitQ.Click += btnSetLimitQ_Click;
            btnGetLimitQ.Click += btnGetLimitQ_Click;
            btnGetBmsRunState.Click += btnGetBmsRunState_Click;
        }

        void btnCfg_Q_CTRL_PF_R_Click(object sender, EventArgs e)
        {
            byte[] cmdBuf = ModbusProto.MakeSouthDevReadCmdFrame(GetModbusAddr(), 0x211F, 2);

            txtSendData.Text = BitConverter.ToString(cmdBuf.ToArray()).Replace("-", " ");
            cmdBuf = ModbusProto.TransparentToModbusCmd(cmdBuf, (mCommMode == CommMode.CAN));
            CommSendCmd(cmdBuf);
        }

        void btnCfg_Q_CTRL_PF_W_Click(object sender, EventArgs e)
        {
            try
            {
                float result = float.Parse(textBoxCfg_Q_CTRL_PF.Text);
                short cfg_Q_CTRL_PF = (short)(result * 1000);
                byte[] sendData = new byte[2];
                sendData[0] = (byte)((cfg_Q_CTRL_PF >> 8) & 0x00FF);
                sendData[1] = (byte)((cfg_Q_CTRL_PF >> 0) & 0x00FF);

                byte[] cmdBuf = ModbusProto.MakeSouthDevWriteCmdFrame(GetModbusAddr(), 0x201A, 2, sendData);

                txtSendData.Text = BitConverter.ToString(cmdBuf.ToArray()).Replace("-", " ");
                cmdBuf = ModbusProto.TransparentToModbusCmd(cmdBuf, (mCommMode == CommMode.CAN));
                CommSendCmd(cmdBuf);
            }
            catch (FormatException)
            {
                LogMsg("字符串不是有效的浮点数格式。\r\n");
            }
            catch (OverflowException)
            {
                LogMsg("字符串表示的数字太大或太小，无法转换为float。\r\n");
            }
        }

        void btnGetPcsTemp_Click(object sender, EventArgs e)
        {
            byte[] cmdBuf = ModbusProto.MakeSouthDevReadCmdFrame(GetModbusAddr(), 0x2175, 12);

            txtSendData.Text = BitConverter.ToString(cmdBuf.ToArray()).Replace("-", " ");
            cmdBuf = ModbusProto.TransparentToModbusCmd(cmdBuf, (mCommMode == CommMode.CAN));
            CommSendCmd(cmdBuf);
        }

        private void btnReadAlarm_Click(object sender, EventArgs e)
        {
            byte[] cmdBuf = ModbusProto.MakeSouthDevReadCmdFrame(GetModbusAddr(), 0x2130, 10);
            LogMsg(cmdBuf, true);
            cmdBuf = ModbusProto.TransparentToModbusCmd(cmdBuf, (mCommMode == CommMode.CAN));
            LogMsg(cmdBuf, true);
            CommSendCmd(cmdBuf);

            cmdBuf = ModbusProto.MakeSouthDevReadCmdFrame(GetModbusAddr(), 0x2131, 10);            
            cmdBuf = ModbusProto.TransparentToModbusCmd(cmdBuf, (mCommMode == CommMode.CAN));
            CommSendCmd(cmdBuf);

            txtSendData.Text = BitConverter.ToString(cmdBuf.ToArray()).Replace("-", " ");
        }

        void btnReadStatus_Click(object sender, EventArgs e)
        {
            byte[] cmdBuf = ModbusProto.MakeSouthDevReadCmdFrame(GetModbusAddr(), 0x2507, 14);
            cmdBuf = ModbusProto.TransparentToModbusCmd(cmdBuf, (mCommMode == CommMode.CAN));
            CommSendCmd(cmdBuf);

            txtSendData.Text = BitConverter.ToString(cmdBuf.ToArray()).Replace("-", " ");
        }

        void btnGetActivePower_Click(object sender, EventArgs e)
        {
            byte[] cmdBuf = ModbusProto.MakeSouthDevReadCmdFrame(GetModbusAddr(), 0x210C, 4);
            cmdBuf = ModbusProto.TransparentToModbusCmd(cmdBuf, (mCommMode == CommMode.CAN));            
            CommSendCmd(cmdBuf);

            txtSendData.Text = BitConverter.ToString(cmdBuf.ToArray()).Replace("-", " ");
        }

        void btnGetChgDisChgLimitPower_Click(object sender, EventArgs e)
        {
            byte[] cmdBuf = ModbusProto.MakeSouthDevReadCmdFrame(GetModbusAddr(), 0x2172, 4);
            cmdBuf = ModbusProto.TransparentToModbusCmd(cmdBuf, (mCommMode == CommMode.CAN));
            CommSendCmd(cmdBuf);

            txtSendData.Text = BitConverter.ToString(cmdBuf.ToArray()).Replace("-", " ");
        }

        void btnSetChgDisChgLimitPower_Click(object sender, EventArgs e)
        {
            try
            {
                float result = float.Parse(textBoxChgDisChgLimitPower.Text);
                UInt32 powerLimitZoom10000 = (UInt32)(result * 10000);
                byte[] sendData = new byte[4];
                sendData[0] = (byte)((powerLimitZoom10000 >> 24) & 0x000000FF);
                sendData[1] = (byte)((powerLimitZoom10000 >> 16) & 0x000000FF);
                sendData[2] = (byte)((powerLimitZoom10000 >> 8) & 0x000000FF);
                sendData[3] = (byte)((powerLimitZoom10000 >> 0) & 0x000000FF);

                byte[] cmdBuf = ModbusProto.MakeSouthDevWriteCmdFrame(GetModbusAddr(), 0x2072, 4, sendData);
                cmdBuf = ModbusProto.TransparentToModbusCmd(cmdBuf, (mCommMode == CommMode.CAN));
                CommSendCmd(cmdBuf);

                txtSendData.Text = BitConverter.ToString(cmdBuf.ToArray()).Replace("-", " ");
            }
            catch (FormatException)
            {
                LogMsg("字符串不是有效的浮点数格式。\r\n");
            }
            catch (OverflowException)
            {
                LogMsg("字符串表示的数字太大或太小，无法转换为float。\r\n");
            }
        }

        void btnGetInvMode_Click(object sender, EventArgs e)
        {
            byte[] cmdBuf = ModbusProto.MakeSouthDevReadCmdFrame(GetModbusAddr(), 0x2102, 2);
            cmdBuf = ModbusProto.TransparentToModbusCmd(cmdBuf, (mCommMode == CommMode.CAN));
            CommSendCmd(cmdBuf);

            txtSendData.Text = BitConverter.ToString(cmdBuf.ToArray()).Replace("-", " ");
        }

        void btnSetInvMode_Click(object sender, EventArgs e)
        {
            byte[] cmdBuf = ModbusProto.MakeSouthDevWriteCmdFrame(GetModbusAddr(), 0x2002, 2, new byte[2] { 0x00, mInvMode });
            cmdBuf = ModbusProto.TransparentToModbusCmd(cmdBuf, (mCommMode == CommMode.CAN));
            CommSendCmd(cmdBuf);

            txtSendData.Text = BitConverter.ToString(cmdBuf.ToArray()).Replace("-", " ");
        }

        void btnGetTurnOnOff_Click(object sender, EventArgs e)
        {
            byte[] cmdBuf = ModbusProto.MakeSouthDevReadCmdFrame(GetModbusAddr(), 0x2101, 2);
            cmdBuf = ModbusProto.TransparentToModbusCmd(cmdBuf, (mCommMode == CommMode.CAN));
            CommSendCmd(cmdBuf);

            txtSendData.Text = BitConverter.ToString(cmdBuf.ToArray()).Replace("-", " ");
        }

        private void btnSetTurnOnOff_Click(object sender, EventArgs e)
        {
            byte[] cmdBuf = ModbusProto.MakeSouthDevWriteCmdFrame(GetModbusAddr(), 0x2001, 2, new byte[2] { 0x00, mTurnOnOff });
            cmdBuf = ModbusProto.TransparentToModbusCmd(cmdBuf, (mCommMode == CommMode.CAN));
            CommSendCmd(cmdBuf);

            txtSendData.Text = BitConverter.ToString(cmdBuf.ToArray()).Replace("-", " ");
        }

        void btnGetBmsRunState_Click(object sender, EventArgs e)
        {
            byte[] cmdBuf = ModbusProto.MakeSouthDevReadCmdFrame(GetModbusAddr(), 0x2177, 2);
            cmdBuf = ModbusProto.TransparentToModbusCmd(cmdBuf, (mCommMode == CommMode.CAN));
            CommSendCmd(cmdBuf);

            txtSendData.Text = BitConverter.ToString(cmdBuf.ToArray()).Replace("-", " ");
        }

        private RegCmdPair FindPcsCtrlObjByCmd(ushort cmd)
        {
            for (int i = 0; i < mRegCmdObjs.Length; i++)
            {
                if ((mRegCmdObjs[i].writeCmd == cmd) || (mRegCmdObjs[i].readCmd == cmd))
                {
                    return mRegCmdObjs[i];
                }
            }
            return (new RegCmdPair());
        }

        public void RecvDataProcess(byte[] frame)
        {
            ushort cmd = (ushort)((frame[1] << 8) + frame[2]);

            RegCmdPair cmdObj = FindPcsCtrlObjByCmd(cmd);
            if ((cmdObj.pDat == null) || ((cmdObj.datLen + 6) > frame.Length))
            {
                return;
            }

            for (int i = 0; i < cmdObj.datLen; i++)
            {
                cmdObj.pDat[i] = frame[6 + i];  //  addr*1+cmd*2+err*1+len*2
            }

            if (cmdObj.pDat.Length <= 0)
            {
                return;
            }
            byte srcAddr = (byte)(frame[0] >> 4);
            switch (cmdObj.regAddr)
            {
                case (ushort)MsgName.RunState:
                    GetRunStateFromRecvFrame(cmdObj.pDat);
                    break;
                case (ushort)MsgName.CFG_TURN_ON_OFF:
                    GetTurnOnOffFromRecvFrame(cmdObj.pDat);
                    break;
                case (ushort)MsgName.CFG_Q_CTRL_KVAR:
                    GetLimitQFromRecvFrame(cmdObj.pDat);
                    break;
                case (ushort)MsgName.PrefChgDisChg:
                    GetChgDisChgLimitPowerFromRecvFrame(cmdObj.pDat);
                    break;
                case (ushort)MsgName.Pout:
                    GetOutActivePowerFromRecvFrame(cmdObj.pDat);
                    break;
                case (ushort)MsgName.CFG_INV_RUN_MODE:
                    GetInvModeFromRecvFrame(cmdObj.pDat);
                    break;
                case (ushort)MsgName.FsmStatus:
                    GetFsmStatusFromRecvFrame(srcAddr, cmdObj.pDat);
                    break;
                case (ushort)MsgName.AlarmGroup1:
                    GetAlarmGroup1InfoFromRecvFrame(srcAddr, cmdObj.pDat);
                    break;
                case (ushort)MsgName.AlarmGroup2:
                    GetAlarmGroup2InfoFromRecvFrame(srcAddr, cmdObj.pDat);
                    break;
                case (ushort)MsgName.PrimaryNtcTemp:
                    GetPriTempFromRecvFrame(srcAddr, cmdObj.pDat);
                    break;
                case (ushort)MsgName.SecondaryNtcTemp:
                    GetSecTempFromRecvFrame(srcAddr, cmdObj.pDat);
                    break;
                case (ushort)MsgName.AnalogData:
                    GetAnalogDataFromRecvFrame(srcAddr, cmdObj.pDat);
                    break;
                case (ushort)MsgName.Version:
                    GetPcsSoftwareVerFromRecvFrame(srcAddr, cmdObj.pDat);
                    break;
                case (ushort)MsgName.PcsStateAnalog:
                    GetPcsStateAnalogFromRecvFrame(srcAddr, cmdObj.pDat);
                    break;
                case (ushort)MsgName.BmsRunState:
                    GetBmsRunStateFromRecvFrame(cmdObj.pDat);
                    break;
                default:
                    GetParticularParaFrame(cmd, srcAddr, cmdObj.pDat);
                    break;
            }
            

            if (frame[1] == 0x21 && frame[2] == 0x1F)
            {
                short qPfCtrl = (short)((frame[6] << 8) + frame[7]);
                mPcsCtrlObjs.mQpfCtrl = (double)(qPfCtrl * 1.0 / 1000.0);
                UpdateCfg_Q_CTRL_PF_Show((float)mPcsCtrlObjs.mQpfCtrl);
            }
            else if (frame[1] == 0x21 && frame[2] == 0x92)
            {

            }

        }

        public void RecvDataProcessLoadee(byte[] frame)
        {
            if (frame.Length < 6)
            {
                return;
            }

            ushort cmd = (ushort)((frame[1] << 8) + frame[2]);

            RegCmdPair cmdObj = FindPcsCtrlObjByCmd(cmd);
            if ((cmdObj.pDat == null))
            {
                return;
            }

            byte[] cmdBuf = new byte[0];
            int offset = 0;
            switch (cmdObj.regAddr)
            {
                case (ushort)MsgName.RunState:
                    cmdBuf = ModbusProto.MakeSouthDevWriteCmdFrame(GetModbusAckAddr(), cmdObj.readCmd, 2, new byte[2] { 0x00, mRunState });
                    break;
                case (ushort)MsgName.CFG_TURN_ON_OFF:
                    cmdBuf = ModbusProto.MakeSouthDevWriteCmdFrame(GetModbusAckAddr(), cmdObj.readCmd, 2, new byte[2] { 0x00, mTurnOnOff });
                    break;
                case (ushort)MsgName.PrefChgDisChg:
                    int PrefChgDisChg = (int)(0.45F * 10000);
                    byte[] datBuf = new byte[4];
                    datBuf[0] = (byte)((PrefChgDisChg >> 24) & 0x000000FF);
                    datBuf[1] = (byte)((PrefChgDisChg >> 16) & 0x000000FF);
                    datBuf[2] = (byte)((PrefChgDisChg >> 8) & 0x000000FF);
                    datBuf[3] = (byte)((PrefChgDisChg >> 0) & 0x000000FF);
                    cmdBuf = ModbusProto.MakeSouthDevWriteCmdFrame(GetModbusAckAddr(), cmdObj.readCmd, cmdObj.datLen, datBuf);
                    break;
                case (ushort)MsgName.Pout:
                    int pOut = (int)(0.25F * 1000);
                    byte[] pOutDatBuf = new byte[4];
                    pOutDatBuf[0] = (byte)((pOut >> 24) & 0x000000FF);
                    pOutDatBuf[1] = (byte)((pOut >> 16) & 0x000000FF);
                    pOutDatBuf[2] = (byte)((pOut >> 8) & 0x000000FF);
                    pOutDatBuf[3] = (byte)((pOut >> 0) & 0x000000FF);
                    cmdBuf = ModbusProto.MakeSouthDevWriteCmdFrame(GetModbusAckAddr(), cmdObj.readCmd, cmdObj.datLen, pOutDatBuf);
                    break;
                case (ushort)MsgName.CFG_INV_RUN_MODE:
                    cmdBuf = ModbusProto.MakeSouthDevWriteCmdFrame(GetModbusAckAddr(), cmdObj.readCmd, 2, new byte[2] { 0x00, mInvMode });
                    break;
                case (ushort)MsgName.FsmStatus:
                    byte[] fsmDatBuf = new byte[12];
                    offset = 0;
                    offset++;
                    fsmDatBuf[offset++] = 1;
                    offset++;
                    fsmDatBuf[offset++] = 2;
                    offset++;
                    fsmDatBuf[offset++] = 3;
                    offset++;
                    fsmDatBuf[offset++] = 4;
                    offset++;
                    fsmDatBuf[offset++] = 5;
                    offset++;
                    fsmDatBuf[offset++] = 6;
                    cmdBuf = ModbusProto.MakeSouthDevWriteCmdFrame(GetModbusAckAddr(), cmdObj.readCmd, 12, fsmDatBuf);
                    break;
                case (ushort)MsgName.AlarmGroup1:
                case (ushort)MsgName.AlarmGroup2:
                    byte[] AlarmDatBuf = new byte[10];
                    offset = 0;
                    offset++;
                    AlarmDatBuf[offset++] = 1;
                    offset++;
                    AlarmDatBuf[offset++] = 2;
                    offset++;
                    AlarmDatBuf[offset++] = 3;
                    offset++;
                    AlarmDatBuf[offset++] = 4;
                    offset++;
                    AlarmDatBuf[offset++] = 5;
                    cmdBuf = ModbusProto.MakeSouthDevWriteCmdFrame(GetModbusAckAddr(), cmdObj.readCmd, 10, AlarmDatBuf);
                    break;
                case (ushort)MsgName.PrimaryNtcTemp:
                case (ushort)MsgName.SecondaryNtcTemp:
                    byte[] tmpDatBuf = new byte[2];
                    short dcTemp = (short)(5.9 * 10.0);
                    offset = 0;
                    tmpDatBuf[offset++] = (byte)(dcTemp >> 8 & 0x00FF);
                    tmpDatBuf[offset++] = (byte)(dcTemp >> 0 & 0x00FF);
                    cmdBuf = ModbusProto.MakeSouthDevWriteCmdFrame(GetModbusAckAddr(), cmdObj.readCmd, 2, tmpDatBuf);
                    break;
                case (ushort)MsgName.AnalogData:
                    byte[] AnalogDatBuf = new byte[38];
                    offset = 0;
                    offset += 3;
                    AnalogDatBuf[offset++] = 1;
                    offset += 3;
                    AnalogDatBuf[offset++] = 2;
                    offset += 3;
                    AnalogDatBuf[offset++] = 3;
                    offset += 3;
                    AnalogDatBuf[offset++] = 4;
                    offset += 3;
                    AnalogDatBuf[offset++] = 5;
                    offset += 3;
                    AnalogDatBuf[offset++] = 6;
                    offset++;
                    AnalogDatBuf[offset++] = 7;
                    offset++;
                    AnalogDatBuf[offset++] = 8;
                    offset += 3;
                    AnalogDatBuf[offset++] = 9;
                    offset += 3;
                    AnalogDatBuf[offset++] = 10;
                    offset++;
                    AnalogDatBuf[offset++] = 11;
                    cmdBuf = ModbusProto.MakeSouthDevWriteCmdFrame(GetModbusAckAddr(), cmdObj.readCmd, 38, AnalogDatBuf);
                    break;
                default:
                    break;
            }
            if (frame[1] == 0x21 && frame[2] == 0x1F)
            {
                short qPfCtrl = (short)(mPcsCtrlObjs.mQpfCtrl * 1000);
                byte[] pfCtrlData = new byte[2];
                pfCtrlData[0] = (byte)((qPfCtrl >> 8) & 0x00FF);
                pfCtrlData[1] = (byte)((qPfCtrl >> 0) & 0x00FF);
                cmdBuf = ModbusProto.MakeSouthDevWriteCmdFrame(GetModbusAckAddr(), 0x211F, 2, pfCtrlData);
            }

            mLoadee.mIsAckFrame = true;
            cmdBuf = ModbusProto.TransparentToModbusCmd(cmdBuf, (mCommMode == CommMode.CAN));
            CommSendCmd(cmdBuf);
            mLoadee.mIsAckFrame = false;
        }

        private void GetRunStateFromRecvFrame(byte[] frame)
        {
            mRunState = frame[1];
            Invoke(new Action(() =>
            {
                radioButtonRunStateStop.Checked = false;
                radioButtonRunStateRun.Checked = false;
                radioButtonRunStateStandby.Checked = false;
                radioButtonRunStateSleep.Checked = false;
                radioButtonRunStateErrStop.Checked = false;
                if (mRunState == 0x00)
                {
                    radioButtonRunStateStop.Checked = true;
                }
                else if (mRunState == 0x01)
                {
                    radioButtonRunStateRun.Checked = true;
                }
                else if (mRunState == 0x02)
                {
                    radioButtonRunStateStandby.Checked = true;
                }
                else if (mRunState == 0x03)
                {
                    radioButtonRunStateSleep.Checked = true;
                }
                else if (mRunState == 0x04)
                {
                    radioButtonRunStateErrStop.Checked = true;
                }

            }));
        }

        private void GetTurnOnOffFromRecvFrame(byte[] frame)
        {
            mTurnOnOff = frame[1];
            Invoke(new Action(() =>
            {
                radioButtonTurnOn.Checked = false;
                radioButtonTurnOff.Checked = false;
                if (mTurnOnOff == 0x01)
                {
                    radioButtonTurnOn.Checked = true;
                }
                else if (mTurnOnOff == 0x00)
                {
                    radioButtonTurnOff.Checked = true;
                }

            }));
        }

        private void GetInvModeFromRecvFrame(byte[] frame)
        {
            if (frame[1] < 0x04)
            {
                mInvMode = frame[1];
                Invoke(new Action(() =>
                {
                    radioButtonOnGrid.Checked = false;
                    radioButtonOffGrid.Checked = false;
                    if (mInvMode == 0x01)
                    {
                        radioButtonOffGrid.Checked = true;
                    }
                    else if (mInvMode == 0x00)
                    {
                        radioButtonOnGrid.Checked = true;
                    }
                    else
                    {
                        LogMsg("未知逆变模式！\r\n");
                    }

                }));
            }
        }

        public void UpdateCfg_Q_CTRL_PF_Show(float data)
        {
            Invoke(new Action(() =>
            {
                textBoxCfg_Q_CTRL_PF.Text = data.ToString();

            }));
        }

        private void GetLimitQFromRecvFrame(byte[] frame)
        {
            float result = 0;
            int offset = 0;
            int recvData = (int)((frame[offset] << 24) + (frame[offset + 1] << 16) + (frame[offset + 2] << 8) + (frame[offset + 3]));
            result = (float)((float)(recvData) / 10000.0);

            Invoke(new Action(() =>
            {
                textBoxCFG_Q_CTRL_KVAR.Text = result.ToString();

            }));
        }

        private void GetPcsStateAnalogFromRecvFrame(byte srcAddr, byte[] frame)
        {
            int offset = 4;
            short priTemp = (short)((frame[offset++] << 8) + frame[offset++]);
            float priTemp_f = (float)(((float)priTemp) / 10.0);
            short secTemp = (short)((frame[offset++] << 8) + frame[offset++]);
            float secTemp_f = (float)(((float)secTemp) / 10.0);
            offset = 11;
            ushort heatFilmPwrSupState = (ushort)((frame[offset++]));

            Invoke(new Action(() =>
            {
                switch (srcAddr)
                {
                    case 0x01:
                        txtAPriTemp.Text = priTemp_f.ToString();
                        txtASecTemp.Text = secTemp_f.ToString();
                        break;
                    case 0x02:
                        txtBPriTemp.Text = priTemp_f.ToString();
                        txtBSecTemp.Text = secTemp_f.ToString();
                        break;
                    case 0x03:
                        txtCPriTemp.Text = priTemp_f.ToString();
                        txtCSecTemp.Text = secTemp_f.ToString();
                        break;
                    default:
                        break;
                }
            }));

            Invoke(new Action(() =>
            {
                if (heatFilmPwrSupState <= comboHeatFilmPwrSup.Items.Count - 1 || heatFilmPwrSupState < 0)
                {
                    comboHeatFilmPwrSup.SelectedIndex = heatFilmPwrSupState;
                }
                else
                {
                    LogMsg("读取加热膜供电状态错误\r\n");
                }
            })); 
        }

        private void GetChgDisChgLimitPowerFromRecvFrame(byte[] frame)
        {
            float result = 0;
            int offset = 0;
            int recvData = (int)((frame[offset] << 24) + (frame[offset + 1] << 16) + (frame[offset + 2] << 8) + (frame[offset + 3]));
            result = (float)((float)(recvData) / 10000.0);

            Invoke(new Action(() =>
            {
                textBoxChgDisChgLimitPower.Text = result.ToString();

            }));
        }

        private void GetOutActivePowerFromRecvFrame(byte[] frame)
        {
            int offset = 0;
            int recvData = (int)((frame[offset] << 24) + (frame[offset + 1] << 16) + (frame[offset + 2] << 8) + (frame[offset + 3]));
            float result = (float)((float)(recvData) / 1000.0);
            Invoke(new Action(() =>
            {
                textBoxActivePower.Text = result.ToString();

            }));
        }

        private void GetFsmStatusFromRecvFrame(byte srcAddr, byte[] frame)
        {
            if (frame.Length < 14)
            {
                return;
            }

            int offset = 0;
			string[] stateArray = new string[] { "init", "idle", "start", "run", "standby", "shuntdown" };
            ushort fsmStatus = (ushort)((frame[offset++] << 8) + frame[offset++]);
            ushort initStep = (ushort)((frame[offset++] << 8) + frame[offset++]);
            ushort idleStep = (ushort)((frame[offset++] << 8) + frame[offset++]);
            ushort startStep = (ushort)((frame[offset++] << 8) + frame[offset++]);
            ushort runStep = (ushort)((frame[offset++] << 8) + frame[offset++]);
            ushort standbyStep = (ushort)((frame[offset++] << 8) + frame[offset++]);
            ushort shutDownStep = (ushort)((frame[offset++] << 8) + frame[offset++]);

            Invoke(new Action(() =>
            {
                switch (srcAddr)
                {
                    case 0x01:
                        if (fsmStatus >= 0 && fsmStatus < stateArray.Length)
                        {
                            txtAFsmStatus.Text = stateArray[fsmStatus];
                        }
                        lableAInitStep.Text = "init: " + initStep.ToString();
                        labelAIdleStep.Text = "idle: " + idleStep.ToString();
                        labelAStartStep.Text = "start: " + startStep.ToString();
                        labelARunStep.Text = "run: " + runStep.ToString();
                        labelAStandbyStep.Text = "standby: " + standbyStep.ToString();
                        labelAShutDownStep.Text = "shutdown: " + shutDownStep.ToString();
                        break;
                    case 0x02:
                        if (fsmStatus >= 0 && fsmStatus < stateArray.Length)
                        {
                            txtBFsmStatus.Text = stateArray[fsmStatus];
                        }
                        lableBInitStep.Text = "init: " + initStep.ToString();
                        labelBIdleStep.Text = "idle: " + idleStep.ToString();
                        labelBStartStep.Text = "start: " + startStep.ToString();
                        labelBRunStep.Text = "run: " + runStep.ToString();
                        labelBStandbyStep.Text = "standby: " + standbyStep.ToString();
                        labelBShutDownStep.Text = "shutdown: " + shutDownStep.ToString();
                        break;
                    case 0x03:
                        if (fsmStatus >= 0 && fsmStatus < stateArray.Length)
                        {
                            txtCFsmStatus.Text = stateArray[fsmStatus];
                        }
                        lableCInitStep.Text = "init: " + initStep.ToString();
                        labelCIdleStep.Text = "idle: " + idleStep.ToString();
                        labelCStartStep.Text = "start: " + startStep.ToString();
                        labelCRunStep.Text = "run: " + runStep.ToString();
                        labelCStandbyStep.Text = "standby: " + standbyStep.ToString();
                        labelCShutDownStep.Text = "shutdown: " + shutDownStep.ToString();
                        break;
                    default:
                        break;
                }
            }));
        }

        private void GetAlarmGroup1InfoFromRecvFrame(byte srcAddr, byte[] frame)
        {
            if (frame.Length != 0x0A)
            {
                return;
            }

            string[] AlmGrp10Name = new string[] { "PV1电压高0-00", "PV2电压高0-01", "0-02", "0-03", "0-04", "0-05", "0-06", "0-07", "0-08", "0-09", "0-10", "0-11", "0-12", "0-13", "0-14", "0-15" };
            string[] AlmGrp11Name = new string[] { "1-00", "1-01", "1-02", "1-03", "1-04", "1-05", "1-06", "1-07", "1-08", "1-09", "1-10", "1-11", "1-12", "1-13", "1-14", "1-15" };
            string[] AlmGrp12Name = new string[] { "电网电压掉电2-00", "电网电压欠压2-01", "电网电压过压2-02", "电网电压欠频2-03", "电网电压过频2-04", "输出电流过流直流电流分量过大2-05", "绝缘检测异常2-06", "2-07", "2-08", "2-09", "2-2-10", "2-11", "2-12", "2-13", "2-14", "2-15" };
            string[] AlmGrp13Name = new string[] { "辅助电源异常3-00", "EEPROM读写失败3-01", "模拟电路异常3-02", "反复OCP逐波保护3-03", "反复软开关逐波保护3-04", "逆变器温度异常3-05", "M-Relay故障3-06", "软件版本不匹配3-07", "PCS Relay故障3-08", "M-Relay过温3-09", "3-10", "交流接线异常3-11", "3-12", "3-13", "3-14", "3-15" };
            string[] AlmGrp14Name = new string[] { "PV1电流反灌保护4-00", "PV1过流保护4-01", "输出过流保护4-02", "PV1瞬态过流保护4-03", "PV1瞬态过压保护4-04", "输出瞬态过流保护4-05", "电池瞬时过压保护4-06", "电池瞬时欠压保护4-07", 
                                                   "电池过压保护4-08","电池欠压保护4-09", "电网电压峰值过压保护4-10", "BMS-PCS通讯断链保护4-11", "电池过压硬件保护4-12", "电池过流硬件保护4-13", "过载故障4-14", "4-15" };

            string[][] AlmNameGroups1x = new string[][]{ AlmGrp10Name, AlmGrp11Name, AlmGrp12Name, AlmGrp13Name, AlmGrp14Name, };

            int offset = 0;
            ushort[] AlarmGroup1x = new ushort[5];
            List<int>[] almBit1List1x = new List<int>[5];

            for (int dat_i = 0; dat_i < 5; dat_i++)//0-4Group
            {
                AlarmGroup1x[dat_i] = (ushort)((frame[offset++] << 8) | frame[offset++]);
                almBit1List1x[dat_i] = GetAlmDataBit1(AlarmGroup1x[dat_i], 16);
            }

            StringBuilder result = new StringBuilder();

            for (int i = 0; i < almBit1List1x.Length; i++)
            {
                foreach (int position in almBit1List1x[i])
                {
                    if (position >= 0 && position < AlmNameGroups1x[i].Length)
                    {
                        result.AppendFormat("{0}, ", AlmNameGroups1x[i][position]);
                    }
                }
            }

            if (result.Length > 0)
            {
                result.Remove(result.Length - 2, 2);
            }

            Invoke(new Action(() =>
            {
                switch (srcAddr)
                {
                    case 0x01:
                        if (result.Length == 0)
                        {
                            textBoxAAlarm1.Text = "本组无告警";
                        }
                        else
                        {
                            textBoxAAlarm1.Text = result.ToString();
                        }
                        break;
                    case 0x02:
                        if (result.Length == 0)
                        {
                            textBoxBAlarm1.Text = "本组无告警";
                        }
                        else
                        {
                            textBoxBAlarm1.Text = result.ToString();
                        }
                        break;
                    case 0x03:
                        if (result.Length == 0)
                        {
                            textBoxCAlarm1.Text = "本组无告警";
                        }
                        else
                        {
                            textBoxCAlarm1.Text = result.ToString();
                        }
                        break;
                    default:
                        break;
                }
            }));
        }

        private static List<int> GetAlmDataBit1(int data, ushort len)
        {
            List<int> positions = new List<int>();

            for (int j = 0; j < len; j++)
            {
                if ((data & (1 << j)) != 0)
                {
                    positions.Add(j);
                }
            }
            return positions;
        }

        private void GetAlarmGroup2InfoFromRecvFrame(byte srcAddr, byte[] frame)
        {
            if (frame.Length != 0x0A)
            {
                return;
            }

            string[] AlmGrp25Name = new string[] { "PVA欠压5-00", "PVB欠压5-01", "PVB过流5-02", "_5-03", "5-04", "5-05", "5-06", "5-07", "5-08", "5-09", "5-10", "5-11", "5-12", "5-13", "5-14", "5-15" };
            string[] AlmGrp26Name = new string[] { "MPPTA过流6-00", "MPPTB过流6-01", "总线过压6-02", "6-03", "6-04", "6-05", "6-06", "6-07", "6-08", "6-09", "6-10", "6-11", "6-12", "6-13", "6-14", "6-15" };
            string[] AlmGrp27Name = new string[] { "电网过压一段7-00", "电网过压二段7-01", "电网欠压一段7-02", "电网欠压二段7-03", "电网过频一段7-04", "电网过频二段7-05", "电网欠频一段7-06", "电网欠频二段7-07", "电网过压10min7-08", "内部离网模式下过压7-09", "内部离网模式下欠压7-10", "内部交流过载保护7-11", "内部备电盒故障7-12", "内部离网状态异常7-13", "内部黑启动故障7-14", "内部加热膜故障7-15" };
            string[] AlmGrp28Name = new string[] { "8-00", "输出电流过流8-01", "PVA瞬时欠压8-02", "PV初始电压检测故障8-03", "PV欠功率8-04", "内部异常低功率8-05", "内部PCS_STATE故障8-06", "内部单次OCP8-07", "内部MCU通信故障8-08", "-/内部电网电压闪击异常8-09", "8-10", "8-11", "8-12", "8-13", "8-14", "8-15" };
            string[] AlmGrp29Name = new string[] { "9-00", "9-01", "9-02", "9-03", "9-04", "9-05", "9-06", "9-07", "9-08", "9-09", "9-10", "9-11", "9-12", "9-13", "9-14", "9-15" };

            string[][] AlmNameGroups2x = new string[][]{ AlmGrp25Name, AlmGrp26Name, AlmGrp27Name, AlmGrp28Name, AlmGrp29Name, };

            int offset = 0;
            ushort[] AlarmGroup2x = new ushort[5];
            List<int>[] almBit1List2x = new List<int>[5];

            for (int dat_i = 0; dat_i < 5; dat_i++)//5-9Group
            {
                AlarmGroup2x[dat_i] = (ushort)((frame[offset++] << 8) | frame[offset++]);
                almBit1List2x[dat_i] = GetAlmDataBit1(AlarmGroup2x[dat_i], 16);
            }

            StringBuilder result = new StringBuilder();

            for (int i = 0; i < almBit1List2x.Length; i++)
            {
                foreach (int position in almBit1List2x[i])
                {
                    if (position >= 0 && position < AlmNameGroups2x[i].Length)
                    {
                        result.AppendFormat("{0}, ", AlmNameGroups2x[i][position]);
                    }
                }
            }

            if (result.Length > 0)
            {
                result.Remove(result.Length - 2, 2);
            }

            Invoke(new Action(() =>
            {
                switch (srcAddr)
                {
                    case 0x01:
                        if (result.Length == 0)
                        {
                            textBoxAAlarm2.Text = "本组无告警";
                        }
                        else
                        {
                            textBoxAAlarm2.Text = result.ToString();
                        }
                        break;
                    case 0x02:
                        if (result.Length == 0)
                        {
                            textBoxBAlarm2.Text = "本组无告警";
                        }
                        else
                        {
                            textBoxBAlarm2.Text = result.ToString();
                        }
                        break;
                    case 0x03:
                        if (result.Length == 0)
                        {
                            textBoxCAlarm2.Text = "本组无告警";
                        }
                        else
                        {
                            textBoxCAlarm2.Text = result.ToString();
                        }
                        break;
                    default:
                        break;
                }
            }));
        }

        private void GetPriTempFromRecvFrame(byte srcAddr, byte[] frame)
        {
            int offset = 0;
            short priTemp = (short)((frame[offset++] << 8) + frame[offset++]);
            float priTemp_f = (float)(((float)priTemp) / 10.0);

            Invoke(new Action(() =>
            {
                switch (srcAddr)
                {
                    case 0x01:
                        txtAPriTemp.Text = priTemp_f.ToString();
                        break;
                    case 0x02:
                        txtBPriTemp.Text = priTemp_f.ToString();
                        break;
                    case 0x03:
                        txtCPriTemp.Text = priTemp_f.ToString();
                        break;
                    default:
                        break;
                }                
            }));
        }

        private void GetPcsSoftwareVerFromRecvFrame(byte srcAddr, byte[] frame)
        {
            if (frame.Length < 1)
            {
                MessageBox.Show("版本查询失败，数据过少", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            int offset = 0;
            ushort softwareVer = (ushort)((frame[offset++] << 8) + frame[offset++]);
            float softwareVer_f = (float)(((float)softwareVer) / 100.0);
            float softwareVer_r = (float)22.0;

            Invoke(new Action(() =>
            {
                switch (srcAddr)
                {
                    case 0x01:
                        if (softwareVer_f == softwareVer_r)
                        {
                            mVerErr = 0;
                            labelAPcsSoftwareVer.Text = "A相:" + softwareVer_f.ToString() + "ok";
                        }
                        else
                        {
                            mVerErr = 1;
                            labelAPcsSoftwareVer.Text = "A相:" + softwareVer_f.ToString() + "err";
                            MessageBox.Show("A相版本不匹配，请升级芯片程序或更换适配上位机！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            tabControl2.SelectedIndex = 2;
                        }
                        break;
                    case 0x02:
                        if (softwareVer_f == softwareVer_r)
                        {
                            mVerErr = 0;
                            labelBPcsSoftwareVer.Text = "B相:" + softwareVer_f.ToString() + "ok";
                        }
                        else
                        {
                            mVerErr = 1;
                            labelBPcsSoftwareVer.Text = "B相:" + softwareVer_f.ToString() + "err";
                            MessageBox.Show("B相版本不匹配，请升级芯片程序或更换适配上位机！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            tabControl2.SelectedIndex = 2;
                        }
                        break;
                    case 0x03:
                        if (softwareVer_f == softwareVer_r)
                        {
                            labelCPcsSoftwareVer.Text = "C相:" + softwareVer_f.ToString() + "ok";
                            mVerErr = 0;
                        }
                        else
                        {
                            mVerErr = 1;
                            labelCPcsSoftwareVer.Text = "C相:" + softwareVer_f.ToString() + "err";
                            MessageBox.Show("C相版本不匹配，请升级芯片程序或更换适配上位机！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            tabControl2.SelectedIndex = 2;
                        }
                        break;
                    default:
                        break;
                }
            }));
        }
     
        private void GetSecTempFromRecvFrame(byte srcAddr, byte[] frame)
        {
            int offset = 0;
            short secTemp = (short)((frame[offset++] << 8) + frame[offset++]);
            float secTemp_f = (float)(((float)secTemp) / 10.0);

            Invoke(new Action(() =>
            {
                switch (srcAddr)
                {
                    case 0x01:
                        txtASecTemp.Text = secTemp_f.ToString();
                        break;
                    case 0x02:
                        txtBSecTemp.Text = secTemp_f.ToString();
                        break;
                    case 0x03:
                        txtCSecTemp.Text = secTemp_f.ToString();
                        break;
                    default:
                        break;
                }
            }));
        }

        private void GetBmsRunStateFromRecvFrame(byte[] frame)
        {
            ushort state = frame[1];
            Invoke(new Action(() =>
            {
                if (state == 0x00)
                {
                    textBoxBmsRunState.Text = "0-正常";
                }
                else if (state == 0x01)
                {
                    textBoxBmsRunState.Text = "1-故障";
                }
                else if (state == 0x02)
                {
                    textBoxBmsRunState.Text = "2-提示/警告";
                }
            }));
        }

        private void radioButtonTurnOn_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioBtn = (RadioButton)sender;
            if (radioBtn.Checked)
            {
                mTurnOnOff = 0x01;
            }
        }

        private void radioButtonTurnOff_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioBtn = (RadioButton)sender;
            if (radioBtn.Checked)
            {
                mTurnOnOff = 0x00;
            }
        }

        private void radioButtonOnGrid_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioBtn = (RadioButton)sender;
            if (radioBtn.Checked)
            {
                mInvMode = 0x00;
            }
        }

        private void radioButtonOffGrid_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioBtn = (RadioButton)sender;
            if (radioBtn.Checked)
            {
                mInvMode = 0x01;
            }
        }

        private void radioBtnCmdProto_CheckedChanged(object sender, EventArgs e)
        {
            mProtoType = ProtoType.CMD;
        }

        private void radioBtnModbusProto_CheckedChanged(object sender, EventArgs e)
        {
            mProtoType = ProtoType.MODBUS;
        }

        private void radioBtnSouthDevProto_CheckedChanged(object sender, EventArgs e)
        {
            mProtoType = ProtoType.SOUTH_DEV;
        }

        private void btnSelectProtoType_Click(object sender, EventArgs e)
        {
            SendSetProtoTypeCmd();
        }

        private void SendSetProtoTypeCmd()
        {
            List<byte> sendList = new List<byte>();

            byte addr = (byte)((m_srcAddr << 4) + m_dstAddr);
            sendList.Add(addr);
            sendList.Add(0x2D);
            sendList.Add((byte)mProtoType);

            byte[] crcDat = sendList.ToArray();
            ushort crcShort = ModbusCrc.Crc16(crcDat, crcDat.Length);
            sendList.Add((byte)(crcShort & 0xFF));
            sendList.Add((byte)(crcShort >> 8));

            txtSendData.Text = BitConverter.ToString(sendList.ToArray()).Replace("-", " ");
            CommSendCmd(ModbusProto.TransparentToModbusCmd(sendList.ToArray(), (mCommMode == CommMode.CAN)));
            sendList.Clear();
        }

        private void btnGenWriteCmd_Click(object sender, EventArgs e)
        {
            try
            {
                byte[] cmdTemp = DataFormatConvert.CmdStringToAscii(textBoxCmd.Text);
                byte[] sendTempData = DataFormatConvert.CmdStringToAscii(textBoxCmdData.Text);

                if (cmdTemp == null || sendTempData == null || cmdTemp.Length != 2)
                {
                    return;
                }

                ushort cmd = (ushort)((cmdTemp[0] << 8) | cmdTemp[1]);
                ushort len = 0x02;
                if (comboBoxDatType.SelectedIndex == (int)DataType.INT32 || comboBoxDatType.SelectedIndex == (int)DataType.UINT32)
                {
                    len = 0x04;
                }

                byte[] sendData = new byte[len];
                if (comboBoxDecHex.SelectedIndex == (int)NumberBase.DECIMAL)
                {
                    switch (comboBoxDatType.SelectedIndex)
                    {
                        case (int)DataType.UINT16:
                            try
                            {
                                UInt16 uint16Dat = Convert.ToUInt16(textBoxCmdData.Text);
                                sendData[0] = (byte)((uint16Dat >> 8) & 0x00FF);
                                sendData[1] = (byte)((uint16Dat >> 0) & 0x00FF);
                            }
                            catch (OverflowException)
                            {
                                MessageBox.Show("输入数值过大或过小，无法转换为 UInt16！");
                                return;
                            }
                            break;
                        case (int)DataType.UINT32:
                            try
                            {
                                UInt32 uint32Dat = Convert.ToUInt32(textBoxCmdData.Text);
                                sendData[0] = (byte)((uint32Dat >> 24) & 0x000000FF);
                                sendData[1] = (byte)((uint32Dat >> 16) & 0x000000FF);
                                sendData[2] = (byte)((uint32Dat >> 8) & 0x000000FF);
                                sendData[3] = (byte)((uint32Dat >> 0) & 0x000000FF);
                            }
                            catch (OverflowException)
                            {
                                MessageBox.Show("输入数值过大或过小，无法转换为 UInt32！");
                                return;
                            }
                            break;
                        case (int)DataType.INT16:
                            try
                            {
                                Int16 int16Dat = Convert.ToInt16(textBoxCmdData.Text);
                                sendData[0] = (byte)((int16Dat >> 8) & 0x00FF);
                                sendData[1] = (byte)((int16Dat >> 0) & 0x00FF);
                            }
                            catch (OverflowException)
                            {
                                MessageBox.Show("输入数值过大或过小，无法转换为 Int16！");
                                return;
                            }
                            break;
                        case (int)DataType.INT32:
                            try
                            {
                                Int32 int32Dat = Convert.ToInt32(textBoxCmdData.Text);
                                sendData[0] = (byte)((int32Dat >> 24) & 0x000000FF);
                                sendData[1] = (byte)((int32Dat >> 16) & 0x000000FF);
                                sendData[2] = (byte)((int32Dat >> 8) & 0x000000FF);
                                sendData[3] = (byte)((int32Dat >> 0) & 0x000000FF);
                            }
                            catch (OverflowException)
                            {
                                MessageBox.Show("输入数值过大或过小，无法转换为 Int32！");
                                return;
                            }
                            break;
                        default:
                            break;
                    }
                }
                else
                {                    
                    if (textBoxCmdData.Text.Length % 2 != 0
                        || ((comboBoxDatType.SelectedIndex == (int)DataType.UINT16 || comboBoxDatType.SelectedIndex == (int)DataType.INT16) && textBoxCmdData.Text.Length > 4)
                        || ((comboBoxDatType.SelectedIndex == (int)DataType.UINT32 || comboBoxDatType.SelectedIndex == (int)DataType.INT32) && textBoxCmdData.Text.Length > 8))
                    {
                        MessageBox.Show("输入数值过大或过小，输入长度必须为偶数，请输入有效的数据！");
                        return;
                    }                    
                    for (ushort i = 0; i < len; i++)
                    {
                        if (i < sendTempData.Length)
                        {
                            sendData[i] = sendTempData[i];
                        }
                        else 
                        {
                            sendData[i] = 0x00;
                        }
                    }             
                }

                byte[] cmdBuf = ModbusProto.MakeSouthDevWriteCmdFrame(GetModbusAddr(), cmd, len, sendData);
                cmdBuf = ModbusProto.TransparentToModbusCmd(cmdBuf, (mCommMode == CommMode.CAN));
                CommSendCmd(cmdBuf);

                txtSendData.Text = BitConverter.ToString(cmdBuf.ToArray()).Replace("-", " ");
            }
            catch (FormatException)
            {
                MessageBox.Show("输入格式不正确，请输入有效的整数！");
            }
        }

        private void btnGetRunState_Click(object sender, EventArgs e)
        {
            byte[] cmdBuf = ModbusProto.MakeSouthDevReadCmdFrame(GetModbusAddr(), 0x2171, 2);
            cmdBuf = ModbusProto.TransparentToModbusCmd(cmdBuf, (mCommMode == CommMode.CAN));
            CommSendCmd(cmdBuf);

            txtSendData.Text = BitConverter.ToString(cmdBuf.ToArray()).Replace("-", " ");
        }

        private void SetDateTimeFormat(Excel.Worksheet worksheet, string columnName)
        {
            string customDateFormat = "yyyy/m/d h:mm:ss";

            Excel.Range columnRange = worksheet.get_Range(columnName + "1", columnName + worksheet.UsedRange.Rows.Count);
            columnRange.NumberFormat = customDateFormat;
        }

        private void btnSetParticularPara_Click(object sender, EventArgs e)
        {
            try
            {
                int objIndex = comboBoxParticularPara.SelectedIndex;
                float result = float.Parse(textBoxPartiParaValue.Text);
                PartiParaObj tmp = mPartiParaObjDefine[objIndex];
                byte[] sendData = new byte[tmp.mLen];

                result = ZoomDataValue(result, tmp.mMin, tmp.mMax);
                Invoke(new Action(() =>
                {
                    textBoxPartiParaValue.Text = result.ToString();
                })); 
                UInt32 PartiParaValue = (UInt32)(result * tmp.mZoom);

                if (tmp.mLen == 0x02)
                {
                    sendData[0] = (byte)((PartiParaValue >> 8) & 0x00FF);
                    sendData[1] = (byte)((PartiParaValue >> 0) & 0x00FF);
                }
                else if (tmp.mLen == 0x04)
                {
                    sendData[0] = (byte)((PartiParaValue >> 24) & 0x000000FF);
                    sendData[1] = (byte)((PartiParaValue >> 16) & 0x000000FF);
                    sendData[2] = (byte)((PartiParaValue >> 8) & 0x000000FF);
                    sendData[3] = (byte)((PartiParaValue >> 0) & 0x000000FF);
                }

                byte[] cmdBuf = ModbusProto.MakeSouthDevWriteCmdFrame(GetModbusAddr(), tmp.mWriteCmd, tmp.mLen, sendData);
                cmdBuf = ModbusProto.TransparentToModbusCmd(cmdBuf, (mCommMode == CommMode.CAN));
                CommSendCmd(cmdBuf);

                txtSendData.Text = BitConverter.ToString(cmdBuf.ToArray()).Replace("-", " ");
            }
            catch (FormatException)
            {
                LogMsg("字符串不是有效的浮点数格式。\r\n");
            }
            catch (OverflowException)
            {
                LogMsg("字符串表示的数字太大或太小，无法转换为float。\r\n");
            }
        }

        private void btnGetParticularPara_Click(object sender, EventArgs e)
        {
            int objIndex = comboBoxParticularPara.SelectedIndex;
            PartiParaObj tmp = mPartiParaObjDefine[objIndex];

            byte[] cmdBuf = ModbusProto.MakeSouthDevReadCmdFrame(GetModbusAddr(), tmp.mReadCmd, tmp.mLen);
            cmdBuf = ModbusProto.TransparentToModbusCmd(cmdBuf, (mCommMode == CommMode.CAN));
            CommSendCmd(cmdBuf);

            textBoxPartiParaValue.Text = "NA";
            txtSendData.Text = BitConverter.ToString(cmdBuf.ToArray()).Replace("-", " ");
        }

        private void GetParticularParaFrame(ushort regAddr, byte srcAddr, byte[] frame)
        {
            int offset = 0;
            int recvData = 0;
            PartiParaObj obj = new PartiParaObj();

            for (int j = 0; j < mPartiParaObjDefine.Length; j++)
            {
                if (regAddr == mPartiParaObjDefine[j].mReadCmd)
                {
                    obj = mPartiParaObjDefine[j];
                    break;
                }
                else if (j == mPartiParaObjDefine.Length)
                {
                    textBoxPartiParaValue.Text = "NA";
                    LogMsg("回读失败\r\n");
                    return;
                }
            }

            if (obj.mLen == 4)
            {
                recvData = (int)((frame[offset] << 24) + (frame[offset + 1] << 16) + (frame[offset + 2] << 8) + (frame[offset + 3]));
            }
            else if (obj.mLen == 2)
            {
                recvData = (short)((frame[offset++] << 8) + frame[offset++]);
            }

            float result = (float)((float)(recvData) / obj.mZoom);
            Invoke(new Action(() =>
            {
                textBoxPartiParaValue.Text = result.ToString();
            }));            
        }

        private float ZoomDataValue(float value, double min, double max)
        {
            if (value > max)
            {
                LogMsg("数据大于数据最大值，已取最大值" + max.ToString() + "发送。\r\n");
                return (float)max;
            }
            else if (value < min)
            {
                LogMsg("数据小于数据最小值，已取最小值" + min.ToString() + "发送。\r\n");
                return (float)min;
            }
            else 
            {
                return value;
            }
        }

        private void btnSetHeatFilmPwrSup_Click(object sender, EventArgs e)
        {
            if (comboHeatFilmPwrSup.SelectedIndex == 0x03)
            {
                return;
            }

            byte[] sendData = new byte[2];
            sendData[0] = (byte)((comboHeatFilmPwrSup.SelectedIndex >> 8) & 0x00FF);
            sendData[1] = (byte)((comboHeatFilmPwrSup.SelectedIndex >> 0) & 0x00FF);

            byte[] cmdBuf = ModbusProto.MakeSouthDevWriteCmdFrame(GetModbusAddr(), 0x2079, 2, sendData);
            cmdBuf = ModbusProto.TransparentToModbusCmd(cmdBuf, (mCommMode == CommMode.CAN));
            CommSendCmd(cmdBuf);

            txtSendData.Text = BitConverter.ToString(cmdBuf.ToArray()).Replace("-", " ");
        }

        private void btnGetHeatFilmPwrSup_Click(object sender, EventArgs e)
        {
            byte[] cmdBuf = ModbusProto.MakeSouthDevReadCmdFrame(GetModbusAddr(), 0x2175, 12);
            cmdBuf = ModbusProto.TransparentToModbusCmd(cmdBuf, (mCommMode == CommMode.CAN));
            CommSendCmd(cmdBuf);

            txtSendData.Text = BitConverter.ToString(cmdBuf.ToArray()).Replace("-", " ");
        }

        private void btnGetPcsSoftwareVer_Click(object sender, EventArgs e)
        {
            byte dstAddr = 0x0F;
            byte[] cmdBuf = ModbusProto.MakeSouthDevReadCmdFrame((byte)((m_srcAddr << 4) + dstAddr), 0x2125, 2);
            cmdBuf = ModbusProto.TransparentToModbusCmd(cmdBuf, (mCommMode == CommMode.CAN));
            CommSendCmd(cmdBuf);

            txtSendData.Text = BitConverter.ToString(cmdBuf.ToArray()).Replace("-", " ");
        }

        private void btnSetLimitQ_Click(object sender, EventArgs e)
        {
            try
            {
                float result = float.Parse(textBoxCFG_Q_CTRL_KVAR.Text);
                result = ZoomDataValue(result, -1000, 1000);
                UInt32 powerLimitZoom10000 = (UInt32)(result * 10000);
                byte[] sendData = new byte[4];
                sendData[0] = (byte)((powerLimitZoom10000 >> 24) & 0x000000FF);
                sendData[1] = (byte)((powerLimitZoom10000 >> 16) & 0x000000FF);
                sendData[2] = (byte)((powerLimitZoom10000 >> 8) & 0x000000FF);
                sendData[3] = (byte)((powerLimitZoom10000 >> 0) & 0x000000FF);

                byte[] cmdBuf = ModbusProto.MakeSouthDevWriteCmdFrame(GetModbusAddr(), 0x2006, 4, sendData);
                cmdBuf = ModbusProto.TransparentToModbusCmd(cmdBuf, (mCommMode == CommMode.CAN));
                CommSendCmd(cmdBuf);

                txtSendData.Text = BitConverter.ToString(cmdBuf.ToArray()).Replace("-", " ");
            }
            catch (FormatException)
            {
                LogMsg("字符串不是有效的浮点数格式。\r\n");
            }
            catch (OverflowException)
            {
                LogMsg("字符串表示的数字太大或太小，无法转换为float。\r\n");
            }
        }

        private void btnGetLimitQ_Click(object sender, EventArgs e)
        {
            byte[] cmdBuf = ModbusProto.MakeSouthDevReadCmdFrame(GetModbusAddr(), 0x2106, 4);
            cmdBuf = ModbusProto.TransparentToModbusCmd(cmdBuf, (mCommMode == CommMode.CAN));
            CommSendCmd(cmdBuf);

            txtSendData.Text = BitConverter.ToString(cmdBuf.ToArray()).Replace("-", " ");
        }
    }

    class PcsDebuger
    {
    }
}
