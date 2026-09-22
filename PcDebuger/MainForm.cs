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

    public enum ConnectObj : byte
    {
        CONNECT_OBJ_BIG_PCS_MASTER,
        CONNECT_OBJ_BIG_PCS_SLAVE,
        CONNECT_OBJ_BIG_PCS_BROADCAST,
    }

    public partial class MainForm : Form
    {
        SerialBufferThread mSerialBufferThread;

        public int mSendPeriod;
        public bool mIsSendPeriod;

        public byte mConnectObj;

        public MainForm()
        {
            InitializeComponent();

            InitCommConfigView();
            InitCanConfigView();
            InitSendRecvTestView();
            InitUartConfigView();
            InitFileLoaderView();
            InitFileExportView();
            InitPcsDebugerView();
            InitAnalogDataMonitView();
            InitBmsDebugerView();
            InitSwOscView();
            InitBackupBoxDebugerView();
            InitVarDebugOnlineView();

            // 所有业务控件和原有事件初始化完成后，再应用现代工作台布局与主题。
            // 该步骤只调整WinForms表现层，不修改通信、协议或变量调试核心逻辑。
            InitModernUi();

            mSerialBufferThread = new SerialBufferThread(this);

            mIsSendPeriod = false;
            mSendPeriod = 1000;
        }


        private void btnPeriodSend_Click(object sender, EventArgs e)
        {
            mSendPeriod = Convert.ToInt32(textBoxSendPeriod.Text);
            if (mIsSendPeriod)
            {
                mIsSendPeriod = false;
                btnPeriodSend.Text = "定时发送";
            }
            else
            {
                mIsSendPeriod = true;
                btnPeriodSend.Text = "停止";
            }
        }
    }
}
