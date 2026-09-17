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
