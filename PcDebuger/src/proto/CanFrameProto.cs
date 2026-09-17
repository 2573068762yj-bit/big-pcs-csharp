using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcDebuger
{
    public struct CAN_ID
    {
        public UInt32 can_id;

        public CAN_ID(UInt32 id)
        {
            can_id = id;
        }

        public byte Prototye
        {
            get { return (byte)((can_id >> 23) & 0x0000003F); }
            set { can_id = (UInt32)((can_id & 0x007FFFFF) | (((UInt32)value & 0x3F) << 23)); }
        }

        public byte DestAddr
        {
            get { return (byte)((can_id >> 16) & 0x0000007F); }
            set { can_id = (UInt32)((can_id & 0xFF80FFFF) | (((UInt32)value & 0x7F) << 16)); }
        }

        public byte SrcAddr
        {
            get { return (byte)((can_id >> 9) & 0x0000007F); }
            set { can_id = (UInt32)((can_id & 0xFFFF01FF) | (((UInt32)value & 0x7F) << 9)); }
        }

        public byte QorR
        {
            get { return (byte)((can_id >> 8) & 0x00000001); }
            set { can_id = (UInt32)((can_id & 0xFFFFFEFF) | (((UInt32)value & 0x01) << 8)); }
        }

        public byte CmdHigh
        {
            get { return (byte)((can_id >> 0) & 0x0000003F); }
            set { can_id = (UInt32)((can_id & 0xFFFFFFC0) | (((UInt32)value & 0x3F) << 0)); }
        }

    }

    public struct CAN_Frame
    {
        public CAN_ID mCanId;
        public byte[] mData;
        public UInt32 len;
        public UInt32 mChannel;
    }

    public struct CAN_Data
    {
        public byte[] mData;
        public byte mDlen;

        public CAN_Data(byte len)
        {
            mData = new byte[len];
            mDlen = len;
        }
        public CAN_Data(byte[] data, byte len)
        {
            mData = new byte[len];
            mDlen = len;
            if (data == null || data.Length == 0)
            {
                return;
            }

            for (int i = 0; i < len; i++)
            {
                if (i < data.Length)
                {
                    mData[i] = data[i];
                }
                else
                {
                    mData[i] = 0;
                }
            }
        }

        public byte SubCmd
        {
            get { return mData[0]; }
            set { mData[0] = value; }
        }

        public byte PayloadLen
        {
            get { return mData[1]; }
            set { mData[1] = value; }
        }

        public byte MultiFrameType
        {
            get { return (byte)((mData[2] >> 4) & 0x0F); }
            set { mData[2] = (byte)((mData[2] & 0x0F) | ((value & 0x0F) << 4)); }
        }

        public byte FrameCnt
        {
            get { return (byte)((mData[2] >> 0) & 0x0F); }
            set { mData[2] = (byte)((mData[2] & 0xF0) | ((value & 0x0F) << 0)); }
        }

    }

    class CanFrameProto
    {
    }
}
