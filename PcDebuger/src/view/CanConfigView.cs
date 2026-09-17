using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZLGCAN;
using ZLGCANDemo;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace PcDebuger
{
    public delegate void CAN_RecvCallback(CAN_Frame frame);
    public class CAN_RecvEventSource
    {
        public event CAN_RecvCallback CanRecvCallback;

        public void RaiseEvent(CAN_Frame frame)
        {
            if (CanRecvCallback != null)
            {
                CanRecvCallback.Invoke(frame);
            }
        }
    }

    partial class MainForm
    {
        const int NULL = 0;
        const int CANFD_BRS = 0x01; /* bit rate switch (second bitrate for payload data) */
        const int CANFD_ESI = 0x02; /* error state indicator of the transmitting node */

        /* CAN payload length and DLC definitions according to ISO 11898-1 */
        const int CAN_MAX_DLC = 8;
        const int CAN_MAX_DLEN = 8;

        /* CAN FD payload length and DLC definitions according to ISO 11898-7 */
        const int CANFD_MAX_DLC = 15;
        const int CANFD_MAX_DLEN = 64;

        const uint CAN_EFF_FLAG = 0x80000000U; /* EFF/SFF is set in the MSB */
        const uint CAN_RTR_FLAG = 0x40000000U; /* remote transmission request */
        const uint CAN_ERR_FLAG = 0x20000000U; /* error message frame */
        const uint CAN_ID_FLAG = 0x1FFFFFFFU; /* id */

        DeviceInfo[] kDeviceType = 
        {
	        new DeviceInfo(Define.ZCAN_USBCANFD_200U, 2),
	        new DeviceInfo(Define.ZCAN_USBCANFD_100U, 1),
	        new DeviceInfo(Define.ZCAN_USBCANFD_MINI, 1)
        };

        bool m_isCanOpen = false;
        bool m_isCanStart = false;
        bool m_isCanCloud = false;
        IProperty property_;
        int channel_index_;
        IntPtr device_handle_;
        IntPtr channel_handle_;
        IntPtr channel_handle2_; //CAN2

        recvdatathread recv_data_thread_;

        const int CAN_RECV_BUF_MAX_LEN = 512;
        const int CAN_LONG_FRAME_ONE_FRAME_MAX_LEN = 60;

        uint[] kAbitTiming = 
        {
	        1000000,//1Mbps
	        800000,//800kbps
	        500000,//500kbps
	        250000,//250kbps
	        125000,//125kbps
	        100000,//100kbps
	        50000 //50kbps
        };

        uint[] kDbitTiming = 
        {
	        5000000,//5Mbps
	        4000000,//4Mbps
	        2000000,//2Mbps
	        1000000, //1Mbps
            800000,//800kbps
	        500000,//500kbps
	        250000,//250kbps
	        125000//125kbps
        };

        int m_protocol_index;
        int m_frame_type_index;
        int m_chan;
        uint m_canid;
        CAN_RecvEventSource mCanRecvEvent;
        byte mCanIdSrcAddr;
        byte mCanIdDestAddr;
        byte mCanIdProtoType;

        private void InitCanConfigView()
        {
            comboBox_device.SelectedIndex = 0;
            comboBox_standard.SelectedIndex = 0;
            comboBox_mode.SelectedIndex = 0;
            comboBox_ABIT.SelectedIndex = 2;
            comboBox_ABIT2.SelectedIndex = 5;
            comboBox_standard2.SelectedIndex = 2;
            comboBox_frametype.SelectedIndex = 1;
            comboBox_protocol.SelectedIndex = 1;
            textBox_startid.Text = "00000000";
            textBox_endid.Text = "FFFFFFFF";
            textBox_ID.Text = "18FF023F";

            setComboboxIndex(0, 32, 0);
            m_protocol_index = 1;
            mCanRecvEvent = new CAN_RecvEventSource();
            mCanRecvEvent.CanRecvCallback += ShowCanRecvData;
            mCanRecvEvent.CanRecvCallback += CommRecvCallback;

            checkBoxIsUseCanId.CheckedChanged += new System.EventHandler(this.checkBoxIsUseCanId_CheckedChanged);
           
            //mCanIdProtoType = 0x31;
            //mCanIdSrcAddr = 0x01;    //  源地址表示是本机地址，上位机的本机地址是0x01
            //mCanIdDestAddr = 0x7F;   //  目的地址表示BMS的地址，BMS地址从0x02开始编址，默认先以广播地址0x00发送

            mCanIdProtoType = 0x32;
            mCanIdDestAddr = 0x78;
            mCanIdSrcAddr = 0x01;

            textBoxCanIDSrcAddr.Text = mCanIdSrcAddr.ToString("X");
            textBoxCanIdDestAddr.Text = mCanIdDestAddr.ToString("X");
        }

        private void checkBoxIsUseCanId_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            if (checkBox.Checked && textBoxCanIdDestAddr.Text != "" && textBoxCanIDSrcAddr.Text != "")
            {
                mCanIdSrcAddr = Convert.ToByte(textBoxCanIDSrcAddr.Text, 16);
                mCanIdDestAddr = Convert.ToByte(textBoxCanIdDestAddr.Text, 16);
                uint canId = GetCanIdCfg();
                textBox_ID.Text = canId.ToString("X");
            }
            else
            {
                //if (GetConnectObj() == (byte)ConnectObj.CONNECT_OBJ_BACKUP_BOX)
                //{
                //    mCanIdProtoType = 0x32;
                //    mCanIdSrcAddr = 0x01;
                //    mCanIdDestAddr = 0x78;
                //    uint canId = GetCanIdCfg();
                //    textBox_ID.Text = canId.ToString("X");
                //}
                //else 
                //{
                    textBox_ID.Text = "18FF023F";
                //}
            }
        }

        public uint GetCanIdCfg()
        {
            CAN_ID canId = new CAN_ID();
            canId.DestAddr = mCanIdDestAddr;
            canId.Prototye = mCanIdProtoType;
            canId.SrcAddr = mCanIdSrcAddr;
            canId.QorR = 0x00;
            if (mLoadee.mIsAckFrame)
            {
                canId.QorR = 0x01;
            }
            return canId.can_id;
        }

        private void setComboboxIndex(int start, int end, int current)
        {
            for (int i = start; i < end; ++i)
            {
                comboBox_index.Items.Add(i);
            }

            comboBox_index.SelectedIndex = current;
        }

        private void button_open_Click(object sender, EventArgs e)
        {
            uint device_type_index_ = (uint)comboBox_device.SelectedIndex;
            uint device_index_;

            device_index_ = (uint)comboBox_index.SelectedIndex;

            device_handle_ = Method.ZCAN_OpenDevice(kDeviceType[device_type_index_].device_type, device_index_, 0);
            if (NULL == (int)device_handle_)
            {
                MessageBox.Show("打开设备失败,请检查设备类型和设备索引号是否正确", "提示",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            m_isCanOpen = true;
            EnableCtrl(true);
            button_open.Enabled = false;
            button_init.Enabled = true;
            button_start.Enabled = true;
            button_reset.Enabled = true;
            button_close.Enabled = true;

            CAN_Init();
            CAN_Start();
        }

        private void button_close_Click(object sender, EventArgs e)
        {
            if (recv_data_thread_ != null)
            {
                recv_data_thread_.setStart(false);
            }

            Method.ZCAN_CloseDevice(device_handle_);
            m_isCanOpen = false;
            m_isCanCloud = false;
            EnableCtrl(false);
            button_open.Enabled = true;
            button_start.Enabled = true;
            button_init.Enabled = true;
            button_reset.Enabled = true;
        }

        private void comboBox_device_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox_channel.Items.Clear();
            setChannelCombobox(0, (int)kDeviceType[comboBox_device.SelectedIndex].channel_count, 0);
            EnableSet();
        }

        private void EnableSet()
        {
            uint type = kDeviceType[comboBox_device.SelectedIndex].device_type;
            bool usbCanfd = type == Define.ZCAN_USBCANFD_100U ||
                type == Define.ZCAN_USBCANFD_200U ||
                type == Define.ZCAN_USBCANFD_MINI;
            bool canfdDevice = usbCanfd;

            comboBox_mode.Enabled = true;
            comboBox_standard.Enabled = canfdDevice;
            comboBox_ABIT.Enabled = canfdDevice;
            comboBox_ABIT2.Enabled = canfdDevice;
            //checkBox_ABIT.Enabled = true;
            //textBox_ABIT.Enabled = true;
            //checkBox_resistance.Enabled = usbCanfd;
            comboBox_standard2.Enabled = true;
            textBox_startid.Enabled = true;
            textBox_endid.Enabled = true;
            comboBox_index.Enabled = true;
            //label_baudprompt.Enabled = true;
            label_standard.Enabled = canfdDevice;
            label_mode.Enabled = canfdDevice;
            label_ABIT.Enabled = canfdDevice;
            label_ABIT2.Enabled = canfdDevice;
            label_ABIT.Enabled = canfdDevice;
            label_ABIT.Enabled = canfdDevice;
            label_standard2.Enabled = true;
            label_startid.Enabled = true;
            label_endid.Enabled = true;
            label_index.Enabled = true;
        }

        private void setChannelCombobox(int start, int end, int current)
        {
            for (int i = start; i < end; ++i)
            {
                comboBox_channel.Items.Add(i);
            }

            comboBox_channel.SelectedIndex = current;
            channel_index_ = comboBox_channel.SelectedIndex;
        }

        private void EnableCtrl(bool opened)
        {
            comboBox_device.Enabled = !opened;
            comboBox_index.Enabled = !opened;
            //comboBox_channel.Enabled = !opened;
            button_open.Enabled = !opened;
        }

        private void CAN_Init()
        {
            if (!m_isCanOpen)
            {
                MessageBox.Show("设备还没打开", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            uint type = kDeviceType[comboBox_device.SelectedIndex].device_type;

            bool usbCanfd = type == Define.ZCAN_USBCANFD_100U ||
                type == Define.ZCAN_USBCANFD_200U ||
                type == Define.ZCAN_USBCANFD_MINI;
            bool canfdDevice = usbCanfd;
            if (!m_isCanCloud)
            {
                IntPtr ptr = Method.GetIProperty(device_handle_);
                if (NULL == (int)ptr)
                {
                    MessageBox.Show("设置指定路径属性失败", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                property_ = (IProperty)Marshal.PtrToStructure((IntPtr)((UInt32)ptr), typeof(IProperty));

                {
                    if (usbCanfd)
                    {
                        if (!setCANFDStandard(comboBox_standard.SelectedIndex)) //设置CANFD标准
                        {
                            MessageBox.Show("设置CANFD标准失败", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                    }
                    /*
                    if (checkBox_ABIT.Checked)//设置波特率
                    {
                        if (!setCustomBaudrate())
                        {
                            MessageBox.Show("设置自定义波特率失败", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                    }                   
                    else
                    */
                    {
                        // set rates fd
                        if (!setBaudrateFD('A', kAbitTiming[comboBox_ABIT.SelectedIndex]))
                        {
                            MessageBox.Show("设置仲裁波特率失败", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                        if (!setBaudrateFD('D', kDbitTiming[comboBox_ABIT2.SelectedIndex]))
                        {
                            MessageBox.Show("设置数据波特率失败", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                    }
                }
            }

            ZCAN_CHANNEL_INIT_CONFIG config_ = new ZCAN_CHANNEL_INIT_CONFIG();

            {
                config_.canfd.mode = (byte)comboBox_mode.SelectedIndex;
                if (canfdDevice)
                {
                    config_.can_type = Define.TYPE_CANFD;
                }
                else
                {
                    config_.can_type = Define.TYPE_CAN;
                }
            }
            IntPtr pConfig = Marshal.AllocHGlobal(Marshal.SizeOf(config_));
            Marshal.StructureToPtr(config_, pConfig, true);

            channel_handle_ = Method.ZCAN_InitCAN(device_handle_, (uint)0, pConfig);
            //CAN2
            channel_handle2_ = Method.ZCAN_InitCAN(device_handle_, (uint)1, pConfig);
            Marshal.FreeHGlobal(pConfig);


            if (NULL == (int)channel_handle_)
            {
                MessageBox.Show("初始化CAN1失败", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (NULL == (int)channel_handle2_)
            {
                MessageBox.Show("初始化CAN2失败", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }


            {
                /*
                if (usbCanfd && checkBox_resistance.Checked)
                {
                    if (!setResistanceEnable())
                    {
                        MessageBox.Show("使能终端电阻失败", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }   
                */

                if (canfdDevice && !setFilter())
                {
                    MessageBox.Show("设置滤波失败", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }

            button_init.Enabled = false;
        }

        //设置CANFD标准
        private bool setCANFDStandard(int canfd_standard)
        {
            string path = channel_index_ + "/canfd_standard";
            string value = canfd_standard.ToString();
            return 1 == property_.SetValue(path, value);
        }

        //设置波特率
        private bool setBaudrateFD(char ad, UInt32 baud)
        {
            /*
                    string path="";
                    if(ad=='A')
                    {
                        path = channel_index_ + "/canfd_abit_baud_rate";
                    }
                    else if (ad == 'D')
                    {
                        path = channel_index_ + "/canfd_dbit_baud_rate";
                    }

                    string value = baud.ToString();

                    return 1 == property_.SetValue(path, value);
            */
            //修改为2个通道同时设置相同参数
            string value = baud.ToString();

            if (ad == 'A')
            {
                if (1 != property_.SetValue("0/canfd_abit_baud_rate", value))
                    return false;
                return 1 == property_.SetValue("1/canfd_abit_baud_rate", value);
            }
            else if (ad == 'D')
            {
                if (1 != property_.SetValue("0/canfd_dbit_baud_rate", value))
                    return false;
                return 1 == property_.SetValue("1/canfd_dbit_baud_rate", value);
            }
            else
                return false;
        }

        //设置滤波
        private bool setFilter()
        {
            if (comboBox_standard2.SelectedIndex == 2)
                return true;

            //2通道同时设置相同参数
            string path = channel_index_ + "/filter_clear";//清除滤波
            string value = "0";
            if (0 == property_.SetValue("0/filter_clear", value))
            {
                return false;
            }
            if (0 == property_.SetValue("1/filter_clear", value))
            {
                return false;
            }

            path = channel_index_ + "/filter_mode";
            value = comboBox_standard2.SelectedIndex.ToString();
            if (0 == property_.SetValue("0/filter_mode", value))
            {
                return false;
            }
            if (0 == property_.SetValue("1/filter_mode", value))
            {
                return false;
            }

            path = channel_index_ + "/filter_start";
            value = "0x" + textBox_startid.Text;
            if (0 == property_.SetValue("0/filter_start", value))
            {
                return false;
            }
            if (0 == property_.SetValue("1/filter_start", value))
            {
                return false;
            }

            path = channel_index_ + "/filter_end";
            value = "0x" + textBox_endid.Text;
            if (0 == property_.SetValue("0/filter_end", value))
            {
                return false;
            }
            if (0 == property_.SetValue("1/filter_end", value))
            {
                return false;
            }
            /*
            //add more  1
            path = channel_index_ + "/filter_start";
            value = "0x11";
            if (0 == property_.SetValue(path, value))
            {
                return false;
            }
            path = channel_index_ + "/filter_end";
            value = "0x20";
            if (0 == property_.SetValue(path, value))
            {
                return false;
            }
            //add more  2
            path = channel_index_ + "/filter_start";
            value = "0x101";
            if (0 == property_.SetValue(path, value))
            {
                return false;
            }
            path = channel_index_ + "/filter_end";
            value = "0x200";
            if (0 == property_.SetValue(path, value))
            {
                return false;
            }
            //add more  3
            path = channel_index_ + "/filter_start";
            value = "0x150";
            if (0 == property_.SetValue(path, value))
            {
                return false;
            }
            path = channel_index_ + "/filter_end";
            value = "0x300";
            if (0 == property_.SetValue(path, value))
            {
                return false;
            }
            //add more  4
            path = channel_index_ + "/filter_start";
            value = "0x401";
            if (0 == property_.SetValue(path, value))
            {
                return false;
            }
            path = channel_index_ + "/filter_end";
            value = "0x500";
            if (0 == property_.SetValue(path, value))
            {
                return false;
            }
            //add more  5
            path = channel_index_ + "/filter_start";
            value = "0x601";
            if (0 == property_.SetValue(path, value))
            {
                return false;
            }
            path = channel_index_ + "/filter_end";
            value = "0x602";
            if (0 == property_.SetValue(path, value))
            {
                return false;
            }
            */

            //path = channel_index_ + "/filter_ack";//滤波生效
            value = "0";

            //2个通道 同时生效
            if (0 == property_.SetValue("0/filter_ack", value))
            {
                return false;
            }
            if (0 == property_.SetValue("1/filter_ack", value))
            {
                return false;
            }

            //如果要设置多条滤波，在清除滤波和滤波生效之间设置多条滤波即可
            return true;
        }

        private void CAN_Start()
        {
            if (Method.ZCAN_StartCAN(channel_handle_) != Define.STATUS_OK)
            {
                MessageBox.Show("启动CAN1失败", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            //CAN2
            if (Method.ZCAN_StartCAN(channel_handle2_) != Define.STATUS_OK)
            {
                MessageBox.Show("启动CAN2失败", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            button_start.Enabled = false;
            button_reset.Enabled = true;
            m_isCanStart = true;
            if (null == recv_data_thread_)
            {
                recv_data_thread_ = new recvdatathread();
                recv_data_thread_.setChannelHandle(channel_handle_, channel_handle2_);
                recv_data_thread_.setStart(m_isCanStart);
                recv_data_thread_.RecvCANData += this.AddData;
                recv_data_thread_.RecvFDData += this.AddData;
            }
            else
            {
                recv_data_thread_.setChannelHandle(channel_handle_, channel_handle2_);
                recv_data_thread_.setStart(m_isCanStart);
            }
        }

        public bool IsEFF(uint id)//1:extend frame 0:standard frame
        {
            return !!Convert.ToBoolean((id & CAN_EFF_FLAG));
        }

        public bool IsRTR(uint id)//1:remote frame 0:data frame
        {
            return !!Convert.ToBoolean((id & CAN_RTR_FLAG));
        }

        public bool IsERR(uint id)//1:error frame 0:normal frame
        {
            return !!Convert.ToBoolean((id & CAN_ERR_FLAG));
        }

        public uint GetId(uint id)
        {
            return id & CAN_ID_FLAG;
        }

        private void AddData(ZCAN_Receive_Data[] data, uint len, uint ch)
        {
            for (uint i = 0; i < len; ++i)
            {
                ZCAN_Receive_Data can = data[i];
                uint id = data[i].frame.can_id;
                byte[] frame = new byte[can.frame.can_dlc];
                for (int k = 0; k < can.frame.can_dlc; k++)
                {
                    frame[k] = can.frame.data[k];
                }
                CAN_Frame canFrame = new CAN_Frame();
                canFrame.mCanId.can_id = id;
                canFrame.mData = frame;
                canFrame.len = (uint)canFrame.mData.Length;
                canFrame.mChannel = ch;

                mCanRecvEvent.RaiseEvent(canFrame);
            }
        }

        private void AddData(ZCAN_ReceiveFD_Data[] data, uint len, uint ch)
        {
            for (uint i = 0; i < len; ++i)
            {
                ZCAN_ReceiveFD_Data canfd = data[i];
                uint id = data[i].frame.can_id;
                byte[] frame = new byte[canfd.frame.len];
                for (int k = 0; k < canfd.frame.len; k++)
                {
                    frame[k] = canfd.frame.data[k];
                }
                CAN_Frame canFrame = new CAN_Frame();
                canFrame.mCanId.can_id = id;
                canFrame.mData = frame;
                canFrame.len = (uint)canFrame.mData.Length;
                canFrame.mChannel = ch;

                mCanRecvEvent.RaiseEvent(canFrame); 
            }

        }

        void ShowCanRecvData(CAN_Frame frame)
        {
            string list_box_data_ = "";
            if (!mIsShowRecvFlag || mIsLoading)
            {
                return;
            }
            else
            {
                string eff = IsEFF(frame.mCanId.can_id) ? "扩展帧" : "标准帧";
                string rtr = IsRTR(frame.mCanId.can_id) ? "远程帧" : "数据帧";

                if (frame.mChannel == 0)
                {
                    list_box_data_ = list_box_data_ + DateTime.Now.ToString() + String.Format(" [通道0] RX ID:0x{0:X8} {1:G} {2:G} 长度:{3:D1} 数据:", GetId(frame.mCanId.can_id), eff, rtr, frame.len);
                }
                else
                {
                    list_box_data_ = list_box_data_ + DateTime.Now.ToString() + String.Format(" [通道1] RX ID:0x{0:X8} {1:G} {2:G} 长度:{3:D1} 数据:", GetId(frame.mCanId.can_id), eff, rtr, frame.len);
                }

                for (uint j = 0; j < frame.len; ++j)
                {
                    list_box_data_ = String.Format("{0:G}{1:X2} ", list_box_data_, frame.mData[j]);
                }
                LogMsg(list_box_data_, true);
            }
        }
        
        private void SendBtnData_CAN(string frame)
        {
            string data = frame;
            byte[] databuf = DataFormatConvert.CmdStringToAscii(data);
            if (databuf == null)
            {
                return;
            }

            int datalen = databuf.Length;  
            int oneFrameMaxDataLen = 0;

            if (0 == m_protocol_index) 
            {
                oneFrameMaxDataLen = (int)CAN_MAX_DLEN;
            }
            else
            {
                oneFrameMaxDataLen = (int)CANFD_MAX_DLEN;
            }
            if (datalen <= oneFrameMaxDataLen)
            {
                CAN_Frame canFrame = new CAN_Frame();
                canFrame.mCanId.can_id = (uint)System.Convert.ToInt32(textBox_ID.Text, 16);
                canFrame.mData = databuf;
                canFrame.len = (uint)canFrame.mData.Length;
                CAN_SendData(canFrame);
            }
            else if (datalen <= CAN_RECV_BUF_MAX_LEN)
            {
                //mLongFrameSendTread.CanSendEnqueue(databuf);
            }
            else
            {
                MessageBox.Show("数据长度有误", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public uint MakeCanId(uint id, int eff, int rtr, int err)//1:extend frame 0:standard frame
        {
            uint ueff = (uint)(!!(Convert.ToBoolean(eff)) ? 1 : 0);
            uint urtr = (uint)(!!(Convert.ToBoolean(rtr)) ? 1 : 0);
            uint uerr = (uint)(!!(Convert.ToBoolean(err)) ? 1 : 0);
            return id | ueff << 31 | urtr << 30 | uerr << 29;
        }

        private void CopyData(byte[] data, ref byte[] transData)
        {
            for (int i = 0; (i < data.Length); i++)
            {
                transData[i] = data[i];
            }
        }

        public void ListViewShowSendData(ZCAN_Transmit_Data candata, uint ch)
        {
            if (!mIsShowSendFlag || mIsLoading)
            {
                return;
            }

            string list_box_data_ = "";
            uint id = candata.frame.can_id;
            string eff = IsEFF(id) ? "扩展帧" : "标准帧";
            string rtr = IsRTR(id) ? "远程帧" : "数据帧";
            if (ch == 0)
            {
                list_box_data_ = DateTime.Now.ToString() + String.Format(" [通道0] TX ID:0x{0:X8} {1:G} {2:G} 长度:{3:D1} 数据:", GetId(id), eff, rtr, candata.frame.can_dlc);
            }
            else
            {
                list_box_data_ = DateTime.Now.ToString() + String.Format(" [通道1] TX ID:0x{0:X8} {1:G} {2:G} 长度:{3:D1} 数据:", GetId(id), eff, rtr, candata.frame.can_dlc);
            }

            for (uint j = 0; j < candata.frame.can_dlc; ++j)
            {
                list_box_data_ = String.Format("{0:G}{1:X2} ", list_box_data_, candata.frame.data[j]);
            }

            LogMsg(list_box_data_, true);
        }

        public void ListViewShowSendData(ZCAN_TransmitFD_Data candata, uint ch)
        {
            if (!mIsShowSendFlag || mIsLoading)
            //if(!mIsShowSendFlag)
            {
                return;
            }

            string list_box_data_ = "";
            uint id = candata.frame.can_id;
            string eff = IsEFF(id) ? "扩展帧" : "标准帧";
            string rtr = IsRTR(id) ? "远程帧" : "数据帧";
            if (ch == 0)
            {
                list_box_data_ = DateTime.Now.ToString() + String.Format(" [通道0] TX ID:0x{0:X8} {1:G} {2:G} 长度:{3:D1} 数据:", GetId(id), eff, rtr, candata.frame.len);
            }
            else
            {
                list_box_data_ = DateTime.Now.ToString() + String.Format(" [通道1] TX ID:0x{0:X8} {1:G} {2:G} 长度:{3:D1} 数据:", GetId(id), eff, rtr, candata.frame.len);
            }

            for (uint j = 0; j < candata.frame.len; ++j)
            {
                list_box_data_ = String.Format("{0:G}{1:X2} ", list_box_data_, candata.frame.data[j]);
            }

            LogMsg(list_box_data_, true);

        }

        private int MakeCanFdFrame(byte[] data, byte len, ref byte[] transData)
        {
            int[] dataLen = new int[] { 12, 16, 20, 24, 32, 48, 64 };
            int resLen = 0;
            if (data.Length <= 8)
            {
                resLen = len;
            }
            else
            {
                for (int i = 0; i < dataLen.Length; i++)
                {
                    if (len <= dataLen[i])
                    {
                        resLen = dataLen[i];
                        break;
                    }
                }
            }
            resLen = 64;
            for (int i = 0; i < resLen; i++)
            {
                if (i < len)
                {
                    transData[i] = data[i];
                }
                else
                {
                    transData[i] = 0;
                }
            }

            return resLen;

        }

        private void AddErr()
        {
            ZCAN_CHANNEL_ERROR_INFO pErrInfo = new ZCAN_CHANNEL_ERROR_INFO();
            IntPtr ptr = Marshal.AllocHGlobal(Marshal.SizeOf(pErrInfo));
            Marshal.StructureToPtr(pErrInfo, ptr, true);
            if (Method.ZCAN_ReadChannelErrInfo(channel_handle_, ptr) != Define.STATUS_OK)
            {
                MessageBox.Show("获取错误信息失败", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            Marshal.FreeHGlobal(ptr);

            string errorInfo = String.Format("错误码：{0:D1}", pErrInfo.error_code);
            LogMsg(errorInfo, true);
        }

        public void CAN_SendData(CAN_Frame frame)
        {
            Invoke(new Action(() =>
            {
                uint result; //发送的帧数
                uint canid = frame.mCanId.can_id;
                m_chan = comboBox_channel.SelectedIndex;

                ZCAN_TransmitFD_Data canfd_data = new ZCAN_TransmitFD_Data();
                canfd_data.frame.can_id = MakeCanId(canid, 1, 0, 0);
                canfd_data.frame.data = new byte[64];
                canfd_data.frame.len = (byte)MakeCanFdFrame(frame.mData, (byte)frame.len, ref canfd_data.frame.data);
                canfd_data.transmit_type = 0;
                canfd_data.frame.flags = 0;
                IntPtr ptr = Marshal.AllocHGlobal(Marshal.SizeOf(canfd_data));
                Marshal.StructureToPtr(canfd_data, ptr, true);
                result = Method.ZCAN_TransmitFD((m_chan == 0) ? channel_handle_ : channel_handle2_, ptr, 1);
                Marshal.FreeHGlobal(ptr);

                ListViewShowSendData(canfd_data, (uint)m_chan);
                if (mIsLoading)
                {
                    LogMsg("+", false);
                }

                if (mVerErr == 1 && tabControl2.SelectedIndex != 2)
                {
                    MessageBox.Show("版本不匹配，请升级芯片程序或更换适配上位机！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    tabControl2.SelectedIndex = 2;
                }
                else if (result != 1)
                {
                    MessageBox.Show("发送数据失败", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    AddErr();
                }
            }));
        }

        public void can_send_data(byte[] data, byte len)
        {
            Invoke(new Action(() =>
            {
                uint result; //发送的帧数
                m_canid = (uint)System.Convert.ToInt32(textBox_ID.Text, 16);
                m_frame_type_index = comboBox_frametype.SelectedIndex;
                m_protocol_index = comboBox_protocol.SelectedIndex;
                m_chan = comboBox_channel.SelectedIndex;

                if (0 == m_protocol_index) //can
                {
                    ZCAN_Transmit_Data can_data = new ZCAN_Transmit_Data();
                    can_data.frame.can_id = MakeCanId(m_canid, m_frame_type_index, 0, 0);
                    //can_data.frame.data = new byte[8];
                    can_data.frame.data = new byte[64]; // 用最大的数组，避免输入错误导致出错。
                    can_data.frame.can_dlc = len;
                    CopyData(data, ref can_data.frame.data);
                    //can_data.frame.can_dlc = (can_data.frame.can_dlc > 8) ? 8 : can_data.frame.can_dlc;
                    can_data.transmit_type = 0;
                    IntPtr ptr = Marshal.AllocHGlobal(Marshal.SizeOf(can_data));
                    Marshal.StructureToPtr(can_data, ptr, true);
                    result = Method.ZCAN_Transmit((m_chan == 0) ? channel_handle_ : channel_handle2_, ptr, 1);
                    Marshal.FreeHGlobal(ptr);

                    ListViewShowSendData(can_data, (uint)m_chan);

                }
                else //canfd
                {
                    ZCAN_TransmitFD_Data canfd_data = new ZCAN_TransmitFD_Data();
                    canfd_data.frame.can_id = MakeCanId(m_canid, m_frame_type_index, 0, 0);
                    canfd_data.frame.data = new byte[64];
                    // canfd_data.frame.len = len;
                    canfd_data.frame.len = (byte)MakeCanFdFrame(data, len, ref canfd_data.frame.data);
                    canfd_data.transmit_type = 0;
                    canfd_data.frame.flags = 0;
                    IntPtr ptr = Marshal.AllocHGlobal(Marshal.SizeOf(canfd_data));
                    Marshal.StructureToPtr(canfd_data, ptr, true);
                    result = Method.ZCAN_TransmitFD((m_chan == 0) ? channel_handle_ : channel_handle2_, ptr, 1);
                    Marshal.FreeHGlobal(ptr);

                    ListViewShowSendData(canfd_data, (uint)m_chan);
                }

                if (result != 1)
                {
                    MessageBox.Show("发送数据失败", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    AddErr();
                }

            }));
        }
    }
}
