using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcDebuger
{
    class Loadee
    {
        private MainForm formCaller;
        private static string[] mVersions = new string[]{
        "v01.01.01.00.08",
        "v01.01.01.00.01",
        "v01.01.01.00.01",
        "v01.01.01.00.01",
        };
        private static LoadObj[] mLoadeeObjs = new LoadObj[]{
        new LoadObj((byte)PcsSubFileType.APP, 0x01, 0x10000, 0x30000, mVersions[1]),
        new LoadObj((byte)PcsSubFileType.CPLD, 0x02, 0x00000, 0x30000, mVersions[2]),
        //new LoadObj((byte)PcsSubFileType.BMS, 0x03, 0x40000, 0x40000, mVersions[3]),
        new LoadObj((byte)PcsSubFileType.BOOT, 0x01, 0x00000, 0x10000, mVersions[0]),
        };

        private ushort mFileType;
        private ushort mOneFrameLen;
        private ushort mSlideFrameNum;
        private ushort mSupportPressMethod;
        private FileDeviceType mDeviceType;
        public bool mIsAckFrame;

        private byte[] mRecvSlidBuffer;
        private byte[] mRecvFileBuffer;

        private int mLastPackageStartIndex;
        private int mLastPackageTotalSize;

        private byte m_dstAddr;
        private byte m_srcAddr;

        public Loadee(MainForm f)
        {
            formCaller = f;
            mFileType = 0x0010;
            mOneFrameLen = 128;
            mSlideFrameNum = 32;
            mSupportPressMethod = 0x0000;
            mDeviceType = FileDeviceType.PCS;
        }

        private byte GetModbusAddr()
        {
            byte addr = (byte)((m_srcAddr << 4) + m_dstAddr);
            return addr;
        }

        public void LoadeeRecvProcess(ModbusTlvProto tlvFrame)
        {
            if (tlvFrame.cmd == (byte)ModbusCmd.LOAD_FILE)
            {
                m_srcAddr = (byte)((tlvFrame.addr & 0x0F));
                m_dstAddr = (byte)((tlvFrame.addr & 0xF0) >> 4);
                switch ((LoadFileSubCmd)tlvFrame.subCmd)
                {
                    case LoadFileSubCmd.CONSULT:
                        if (tlvFrame.tagNum == 4)
                        {
                            AckConsultCmd(tlvFrame);  //  下位机构建回复报文并发送应答
                        }
                        break;
                    case LoadFileSubCmd.START:
                        mLastPackageStartIndex = 0;
                        mLastPackageTotalSize = 0;
                        AckStartCmd(tlvFrame);
                        break;
                    case LoadFileSubCmd.SLIDECRC:
                        AckSlidCrcCmd(tlvFrame);
                        break;
                    case LoadFileSubCmd.TRANSFER:
                        RecvFileFrame(tlvFrame);
                        break;
                    case LoadFileSubCmd.FILE_END:
                        AckFileEndCmd(tlvFrame);
                        break;
                    default:
                        break;
                }
            }
        }

        private void AckConsultCmd(ModbusTlvProto tlvFrame)
        {
            byte[] frame = MakeConsultAckCmd();
            mIsAckFrame = true;
            formCaller.CommSendCmd(frame);
            mIsAckFrame = false;
        }


        public byte[] MakeConsultAckCmd()
        {
            List<byte> sendList = new List<byte>();

            ModbusTlvProto consultCmd = new ModbusTlvProto();
            consultCmd.addr = GetModbusAddr();
            consultCmd.cmd = (byte)ModbusCmd.LOAD_FILE;
            consultCmd.subCmd = (byte)LoadFileSubCmd.CONSULT;
            consultCmd.tagNum = 9;
            consultCmd.datLen = 0;  // update later
            consultCmd.tlvList = new List<TLV_Unit>();

            TLV_Unit tlv = new TLV_Unit();
            tlv.Type = 0x01;
            tlv.Length = 0x02;
            tlv.Value = new byte[2];
            tlv.Value[0] = (byte)(mFileType >> 8);
            tlv.Value[1] = (byte)(mFileType & 0x00FF);
            consultCmd.tlvList.Add(tlv);

            tlv.Type = 0x02;
            tlv.Length = 0x02;
            tlv.Value = new byte[2];
            tlv.Value[0] = (byte)(mOneFrameLen >> 8);
            tlv.Value[1] = (byte)(mOneFrameLen & 0x00FF);
            consultCmd.tlvList.Add(tlv);

            tlv.Type = 0x03;
            tlv.Length = 0x02;
            tlv.Value = new byte[2];
            tlv.Value[0] = (byte)(mSlideFrameNum >> 8);
            tlv.Value[1] = (byte)(mSlideFrameNum & 0x00FF);
            consultCmd.tlvList.Add(tlv);

            tlv.Type = 0x04;
            tlv.Length = 0x02;
            tlv.Value = new byte[2];
            tlv.Value[0] = (byte)(mSupportPressMethod >> 8);
            tlv.Value[1] = (byte)(mSupportPressMethod & 0x00FF);
            consultCmd.tlvList.Add(tlv);

            for (int i = 0; i < mLoadeeObjs.Length; i++)
            {
                tlv.Type = 0x06;
                tlv.Length = 0x13;
                tlv.Value = new byte[tlv.Length];
                int offset = 0;
                tlv.Value[offset++] = (byte)((ushort)mDeviceType >> 8);
                tlv.Value[offset++] = (byte)((ushort)mDeviceType & 0x00FF);
                ushort subFileType = mLoadeeObjs[i].subFileType;
                tlv.Value[offset++] = (byte)(subFileType >> 8);
                tlv.Value[offset++] = (byte)(subFileType & 0x00FF);
                tlv.Value[offset++] = 0x0E;
                for (int j = 0; j < 0x0E; j++)
                {
                    if ((j + 1) < mLoadeeObjs[i].version.Length)
                    {
                        tlv.Value[offset++] = (byte)mLoadeeObjs[i].version[j + 1];
                    }
                    else
                    {
                        tlv.Value[offset++] = 0;
                    }
                }
                consultCmd.tlvList.Add(tlv);
            }

            tlv.Type = 0x07;
            tlv.Length = 0x01;
            tlv.Value = new byte[1];
            tlv.Value[0] = 0x01;
            consultCmd.tlvList.Add(tlv);

            consultCmd.tagNum = (byte)(5 + mLoadeeObjs.Length);

            return ModbusProto.MakeModbusFrame(consultCmd);
        }

        private LoadObj FindLoaderObjByFileType(ushort fileType)
        {
            for (int i = 0; i < mLoadeeObjs.Length; i++)
            {
                if (mLoadeeObjs[i].subFileType == fileType)
                {
                    return mLoadeeObjs[i];
                }
            }
            return (new LoadObj(0, 0, 0, 0, "00"));
        }

        private void AckStartCmd(ModbusTlvProto tlvFrame)
        {
            if (tlvFrame.tagNum != 8 || tlvFrame.tlvList == null)
            {
                return;
            }

            ushort oneFrameLen = (ushort)((tlvFrame.tlvList[1].Value[0] << 8) + tlvFrame.tlvList[1].Value[1]);
            ushort oneSildFrameNum = (ushort)((tlvFrame.tlvList[2].Value[0] << 8) + tlvFrame.tlvList[2].Value[1]);
            uint fileSize = (uint)((tlvFrame.tlvList[4].Value[0] << 24) + (tlvFrame.tlvList[4].Value[1] << 16) + (tlvFrame.tlvList[4].Value[2] << 8) + (tlvFrame.tlvList[4].Value[3]));
            ushort deviceFileType = (ushort)((tlvFrame.tlvList[5].Value[0] << 8) + tlvFrame.tlvList[5].Value[1]);
            ushort subFileType = (ushort)((tlvFrame.tlvList[6].Value[0] << 8) + tlvFrame.tlvList[6].Value[1]);
            if (oneFrameLen != mOneFrameLen || oneSildFrameNum != mSlideFrameNum || deviceFileType != (ushort)mDeviceType || subFileType > 4)
            {
                return;
            }

            LoadObj loadObj = FindLoaderObjByFileType(subFileType);
            if (loadObj.memTotalSize == 0 || fileSize > loadObj.memTotalSize)
            {
                return;
            }

            int oneSlidDataSize = oneFrameLen * oneSildFrameNum;
            int slideWinTotalNum = (int)(fileSize / oneSlidDataSize);
            mLastPackageTotalSize = (int)(fileSize - slideWinTotalNum * oneSlidDataSize);
            mLastPackageStartIndex = slideWinTotalNum * oneSildFrameNum;

            mRecvFileBuffer = new byte[fileSize];

            mRecvSlidBuffer = new byte[mSlideFrameNum * mOneFrameLen];

            byte[] frame = MakeStartAckCmd(tlvFrame);
            mIsAckFrame = true;
            formCaller.CommSendCmd(frame);
            mIsAckFrame = false;
        }


        public byte[] MakeStartAckCmd(ModbusTlvProto tlvFrame)
        {
            ModbusTlvProto startCmd = tlvFrame;
            startCmd.addr = GetModbusAddr();
            startCmd.tagNum++;
            startCmd.datLen += 4;

            TLV_Unit tlv = new TLV_Unit();
            ushort MISSION_ID = 0x0000;
            tlv.Type = 0x09;
            tlv.Length = 0x02;
            tlv.Value = new byte[2];
            tlv.Value[0] = (byte)(MISSION_ID >> 8);
            tlv.Value[1] = (byte)(MISSION_ID & 0x00FF);
            startCmd.tlvList.Add(tlv);

            return ModbusProto.MakeModbusFrame(startCmd);
        }

        private void AckSlidCrcCmd(ModbusTlvProto tlvFrame)
        {
            if (tlvFrame.tagNum != 4)
            {
                return;
            }

            uint startSquenceNum = (uint)((tlvFrame.tlvList[1].Value[0] << 24) + (tlvFrame.tlvList[1].Value[1] << 16) + (tlvFrame.tlvList[1].Value[2] << 8) + (tlvFrame.tlvList[1].Value[3]));
            int slidWinDataLen = 0;
            if (startSquenceNum >= mLastPackageStartIndex)
            {
                //  最后一包数据
                slidWinDataLen = mLastPackageTotalSize;
            }
            else
            {
                slidWinDataLen = (int)(mSlideFrameNum * mOneFrameLen);
            }

            ushort crcFromLoader = (ushort)((tlvFrame.tlvList[3].Value[0] << 8) + tlvFrame.tlvList[3].Value[1]);

            //formCaller.LogMsg("Uart Rx: ", true);
            //formCaller.LogMsg(oneSlidWinBuffer, true);

            tlvFrame.addr = GetModbusAddr();
            ushort crcFromRecvBuffer = ModbusCrc.Crc16(mRecvSlidBuffer, slidWinDataLen);
            if (crcFromLoader == crcFromRecvBuffer)
            {
                formCaller.LogMsg("滑窗校验通过！", true);
                for (int i = 0; i < slidWinDataLen; i++)
                {
                    mRecvFileBuffer[startSquenceNum * mOneFrameLen + i] = mRecvSlidBuffer[i];
                }
                mIsAckFrame = true;                
                formCaller.CommSendCmd(ModbusProto.MakeModbusFrame(tlvFrame));
                mIsAckFrame = false;
            }
            else
            {
                mIsAckFrame = true;
                formCaller.LogMsg("滑窗校验失败！", true);
                formCaller.CommSendCmd(MakeNackFrame(tlvFrame.addr, tlvFrame.cmd, tlvFrame.subCmd, 5));
                mIsAckFrame = false;
            }
        }

        private byte[] MakeNackFrame(byte addr, byte cmd, byte subCmd, byte err)
        {
            if (cmd == 0x42)
            {
                cmd = 0xC2;
            }
            List<byte> sendList = new List<byte>();
            sendList.Add(addr);
            sendList.Add(cmd);
            sendList.Add(subCmd);
            sendList.Add(err);
            byte[] crcDat = sendList.ToArray();
            ushort crcShort = ModbusCrc.Crc16(crcDat, crcDat.Length);
            sendList.Add((byte)(crcShort & 0xFF));
            sendList.Add((byte)(crcShort >> 8));
            return sendList.ToArray();
        }

        private void RecvFileFrame(ModbusTlvProto tlvFrame)
        {
            if (tlvFrame.tagNum != 4 || tlvFrame.tlvList == null)
            {
                return;
            }
            uint frameSquenceNum = (uint)((tlvFrame.tlvList[1].Value[0] << 24) + (tlvFrame.tlvList[1].Value[1] << 16) + (tlvFrame.tlvList[1].Value[2] << 8) + (tlvFrame.tlvList[1].Value[3]));
            ushort dataLen = (ushort)((tlvFrame.tlvList[2].Value[0] << 8) + (tlvFrame.tlvList[2].Value[1]));
            if (tlvFrame.tlvList[3].Value.Length != dataLen)
            {
                return;
            }

            uint startIndex = (frameSquenceNum % mSlideFrameNum) * mOneFrameLen;
            //formCaller.LogMsg("squenceNum = " + frameSquenceNum.ToString() + ", dataLen = " + dataLen.ToString(), true);

            if ((startIndex + dataLen) > mRecvSlidBuffer.Length)
            {
                return;
            }
            for (int i = 0; i < dataLen; i++)
            {
                mRecvSlidBuffer[startIndex + i] = tlvFrame.tlvList[3].Value[i];
            }
        }

        private void AckFileEndCmd(ModbusTlvProto tlvFrame)
        {
            ushort crc = ModbusCrc.Crc16(mRecvFileBuffer, mRecvFileBuffer.Length);

            tlvFrame.tlvList[1].Value[0] = (byte)(crc >> 8);
            tlvFrame.tlvList[1].Value[1] = (byte)(crc & 0x00FF);
            tlvFrame.addr = GetModbusAddr();
            mIsAckFrame = true;
            formCaller.CommSendCmd(ModbusProto.MakeModbusFrame(tlvFrame));
            mIsAckFrame = false;
        }

    }
}
