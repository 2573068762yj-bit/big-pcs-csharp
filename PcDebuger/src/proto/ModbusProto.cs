using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcDebuger
{
    public enum ModbusCmd : byte
    {
        ACTIVE_FILE = 0x43,
        LOAD_FILE = 0x42,
        EXPORT_FILE = 0x41,

        GET_SPECIAL_CODE = 0x2A,
        SET_SPECIAL_CODE = 0x2B,
        SET_PROTO_TYPE = 0x2D,
        GET_PROTO_TYPE = 0x2C,
        INV_CMD = 0xEF,

        SOUTH_DEV_MULT_WRITE = 0x1D,
        SOUTH_DEV_MULT_READ = 0x1E,
        SOUTH_DEV_WRITE = 0x20,
        SOUTH_DEV_READ = 0x21,
        SOUTH_EQP_WRITE = 0x24,
        SOUTH_EQP_READ = 0x25,
    }

    public struct TLV_Unit
    {
        public byte     Type;
        public byte     Length;
        public byte[]   Value;
    }

    public struct ModbusTlvProto
    {
        public byte addr;
        public byte cmd;
        public byte subCmd;
        public byte tagNum;
        public ushort datLen;
        public List<TLV_Unit> tlvList;
        public ushort crc;
    }

    class ModbusProto
    {
        private static ModbusProto instance;
        private static readonly object lockObject = new object();
        private static int mRecvCanFrameCnt = 0;
        private static List<byte> mRecvCanLongFrame;
        private static uint mCanId;
        private static uint mTpCanId = 0x18FF023F;

        private ModbusProto() { }

        public static ModbusProto Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (lockObject)
                    {
                        if (instance == null)
                        {
                            instance = new ModbusProto();
                        }
                    }
                }
                return instance;
            }
        }

        public static byte[] MakeModbusFrame(byte addr, byte cmd, byte[] data, int len, bool isAddCrc)
        {
            List<byte> sendList = new List<byte>();
            sendList.Add(addr);
            sendList.Add(cmd);
            int datLen = len;
            if (data.Length < len)
            {
                datLen = data.Length;
            }
            for (int i = 0; i < datLen; i++)
            {
                sendList.Add(data[i]);
            }
            if (isAddCrc)
            {
                byte[] crcDat = sendList.ToArray();
                ushort crcShort = ModbusCrc.Crc16(crcDat, crcDat.Length);
                sendList.Add((byte)(crcShort & 0xFF));
                sendList.Add((byte)(crcShort >> 8));
            }
            return sendList.ToArray();
        }

        public static byte[] MakeModbusFrame(byte addr, ushort cmd, byte[] data, int len, bool isAddDataLen, bool isAddCrc)
        {
            List<byte> sendList = new List<byte>();
            sendList.Add(addr);
            sendList.Add((byte)(cmd >> 8));
            sendList.Add((byte)(cmd));
            ushort datLen = (ushort)len;
            if (data.Length < len)
            {
                datLen = (ushort)data.Length;
            }

            if (isAddDataLen)
            {
                sendList.Add((byte)(datLen >> 8));
                sendList.Add((byte)(datLen & 0x00FF));
            }

            for (int i = 0; i < datLen; i++)
            {
                sendList.Add(data[i]);
            }
            if (isAddCrc)
            {
                byte[] crcDat = sendList.ToArray();
                ushort crcShort = ModbusCrc.Crc16(crcDat, crcDat.Length);
                sendList.Add((byte)(crcShort & 0xFF));
                sendList.Add((byte)(crcShort >> 8));
            }
            return sendList.ToArray();
        }

        public static byte[] MakeModbusFrame(ModbusTlvProto tlvFrame, bool isAck)
        {
            byte[] frameOrigin = MakeModbusFrame(tlvFrame);
            if (isAck)
            {
                byte[] frameAck = new byte[frameOrigin.Length + 1];
                frameAck[0] = frameOrigin[0];
                frameAck[1] = 0x00;
                for (int i = 1; i < frameOrigin.Length; i++)
                {
                    frameAck[i+1] = frameOrigin[i];
                }
                return frameAck;
            }
            return frameOrigin;
        }

        public static byte[] MakeModbusFrame(ModbusTlvProto tlvFrame)
        {
            List<byte> sendList = new List<byte>();
            sendList.Add(tlvFrame.addr);
            sendList.Add(tlvFrame.cmd);
            sendList.Add(tlvFrame.subCmd);
            sendList.Add(tlvFrame.tagNum);
            sendList.Add(0x00);  // update later
            sendList.Add(0x00);

            for (int i = 0; i < tlvFrame.tlvList.Count; i++)
            {
                sendList.Add(tlvFrame.tlvList[i].Type);
                sendList.Add(tlvFrame.tlvList[i].Length);
                for (int j = 0; j < tlvFrame.tlvList[i].Length; j++)
                {
                    sendList.Add(tlvFrame.tlvList[i].Value[j]);
                }
            }

            ushort datLen = (ushort)sendList.Count;
            datLen -= 6;
            sendList[4] = (byte)(datLen >> 8);
            sendList[5] = (byte)(datLen & 0xFF);

            byte[] crcDat = sendList.ToArray();
            ushort crcShort = ModbusCrc.Crc16(crcDat, crcDat.Length);
            sendList.Add((byte)(crcShort & 0xFF));
            sendList.Add((byte)(crcShort >> 8));

            return sendList.ToArray();
        }

        public static ModbusTlvProto GetModbusTlvFrame(byte[] frame)
        {
            ModbusTlvProto tlvFrame = new ModbusTlvProto();
            if (frame.Length < 8)
            {
                return tlvFrame;
            }
            int offset = 0;
            tlvFrame.addr = frame[offset++];
            tlvFrame.cmd = frame[offset++];
            tlvFrame.subCmd = frame[offset++];
            tlvFrame.tagNum = frame[offset++];
            byte lenH = frame[offset++];
            byte lenL = frame[offset++];
            tlvFrame.datLen = (ushort)((lenH << 8) + lenL);
            if ((tlvFrame.datLen + 8) != frame.Length)
            {
                return tlvFrame;
            }
            tlvFrame.tlvList = new List<TLV_Unit>();
            for (int i = 0; i < tlvFrame.tagNum; i++)
            {
                TLV_Unit tlv = new TLV_Unit();
                tlv.Type = frame[offset++];
                tlv.Length = frame[offset++];
                if (tlv.Length == 0)
                {
                    return tlvFrame;
                }
                tlv.Value = new byte[tlv.Length];
                for (int j = 0; j < tlv.Length; j++)
                {
                    tlv.Value[j] = frame[offset++];
                }
                tlvFrame.tlvList.Add(tlv);
            }
            byte crcH = frame[offset++];
            byte crcL = frame[offset++];
            tlvFrame.crc = (ushort)((crcH << 8) + crcL);

            return tlvFrame;
        }

        public static bool CheckCmdIsTlvCmd(byte cmd)
        {
            byte[] tlvCmd = new byte[] { (byte)ModbusCmd.ACTIVE_FILE, (byte)ModbusCmd.EXPORT_FILE, (byte)ModbusCmd.LOAD_FILE };
            for (int i = 0; i < tlvCmd.Length; i++)
            {
                if (cmd == tlvCmd[i])
                {
                    return true;
                }
            }
            return false;
        }

        public static bool CheckCmdIsTransparentCmd(byte cmd)
        {
            if (cmd == 0x01 || cmd == 0x02 || cmd == 0x00 || cmd == 0x28 || cmd == 0x0C || cmd == 0x08 || cmd == 0x06)//bms
            {
                return true;
            }
            
            byte[] tlvCmd = new byte[] { 
                (byte)ModbusCmd.SET_SPECIAL_CODE,
                (byte)ModbusCmd.GET_SPECIAL_CODE,
                (byte)ModbusCmd.SET_PROTO_TYPE, 
                (byte)ModbusCmd.GET_PROTO_TYPE, 
                (byte)ModbusCmd.SOUTH_DEV_MULT_WRITE, 
                (byte)ModbusCmd.SOUTH_DEV_MULT_READ,
                (byte)ModbusCmd.SOUTH_DEV_READ,
                (byte)ModbusCmd.SOUTH_DEV_WRITE,
                (byte)ModbusCmd.SOUTH_EQP_READ,
                (byte)ModbusCmd.SOUTH_EQP_WRITE,
                0x3F,
            };
            for (int i = 0; i < tlvCmd.Length; i++)
            {
                if (cmd == tlvCmd[i])
                {
                    return true;
                }
            }
            return false;
        }

        public static byte[] TransparentToModbusCmd(byte[] transFrame, bool isEnable)
        {
            if (isEnable)
            {
                List<byte> frameList = new List<byte>();
                frameList.Add(0x00);// addr
                frameList.Add(0x3F);// cmd
                frameList.Add(0x00);// subcmd
                frameList.Add((byte)transFrame.Length);// len
                frameList.AddRange(transFrame);
                return frameList.ToArray();
            }
            else
            {
                return transFrame;
            }
        }

        public static List<CAN_Frame> ModbusToCanFrame(byte[] mbFrame, uint canId)
        {
            mCanId = canId;
            CAN_ID canIdFormat = new CAN_ID();
            canIdFormat.can_id = canId;

            if (canIdFormat.QorR == 0x01)
            {
                mbFrame = ByteArrayInsert(mbFrame, 3, new byte[1] { 0x00 });
            }

            return ModbusToCanFrame(mbFrame);
        }
        public static List<CAN_Frame> ModbusToCanFrame(byte[] mbFrame)
        {
            List<CAN_Frame> canFrameList = new List<CAN_Frame>();
            byte cmd = mbFrame[1];
            byte subCmd = mbFrame[2];
            if (mbFrame.Length < 5)
            {
                return canFrameList;
            }

            byte mbDataLen = (byte)(mbFrame.Length - 5);  //  modbus的数据长度，即帧数据长度去掉地址、功能码、子功能码和CRC
            byte canPayloadMaxLen = 0;
            if (CheckCmdIsTlvCmd(cmd))
            {
                //  多帧
                cmd = (byte)(((((cmd & 0xF0) >> 4) - 1) << 4) | (cmd & 0x0F)); 

                canPayloadMaxLen = (64 - 3);  //  多帧数据长度最大61字节;

                if (mbDataLen <= canPayloadMaxLen)  // 多帧单次
                {
                    CAN_Frame canFrame = new CAN_Frame();
                    canFrame.mCanId.can_id = mCanId;
                    canFrame.mCanId.CmdHigh = cmd;
                    int canFrameLen = (mbDataLen + 3);  //  canFrameLen <= 64
                    canFrame.len = (uint)canFrameLen;
                    canFrame.mData = new byte[canFrameLen];
                    int offset = 0;
                    canFrame.mData[offset++] = subCmd;
                    canFrame.mData[offset++] = (byte)(canFrameLen - 2); //  有效数据长度，can帧长去掉命令字低8位、数据长度之后的数据长度，但是包括了帧序号这个字节
                    canFrame.mData[offset++] = 0x00;                    // 帧序号
                    for (int i = 0; i < (canFrameLen - offset); i++)
                    {
                        canFrame.mData[i + offset] = mbFrame[offset + i];
                    }
                    canFrameList.Add(canFrame);
                }
                else // 多帧多次
                {
                    int startIndex = 3;                  // exclude addr+cmd+subcmd
                    byte frameCnt = 1;                   //  frameCnt取值范围是0x01到0x7f，即bit0~6，bit7=0表示最后一帧，bit7=1表示非最后一帧
                    while (startIndex < (mbFrame.Length-2))
                    {
                        CAN_Frame canFrame = new CAN_Frame();
                        canFrame.mCanId.can_id = mCanId;
                        canFrame.mCanId.CmdHigh = cmd;

                        int endIndex = startIndex + canPayloadMaxLen;
                        if (endIndex > (mbDataLen + 3))  // (mbDataLen + 3): 有效数据+前面3个字节，也就是去掉crc之后modbus帧的长度，也就是crc字段前的一个索引
                        {
                            endIndex = (mbDataLen + 3);
                        }
                        int oneFrameCanPayloadLen = endIndex - startIndex;
                        canFrame.len = (uint)(oneFrameCanPayloadLen + 3);   //  数据长度+subcmd+payloadLen+ctrlCode
                        canFrame.mData = new byte[oneFrameCanPayloadLen + 3];  //  canFrameLen <= 64
                        int offset = 0;
                        canFrame.mData[offset++] = subCmd;
                        canFrame.mData[offset++] = (byte)(oneFrameCanPayloadLen+1);
                        if (endIndex == (mbDataLen + 3))
                        {
                            //  多帧多次的最后一帧
                            canFrame.mData[offset++] = (byte)(0x00 | (frameCnt & 0x7F));
                        }
                        else
                        {
                            //  多帧多次的非最后一帧
                            canFrame.mData[offset++] = (byte)(0x80 | (frameCnt & 0x7F)); 
                        }
                        for (int i = 0; i < oneFrameCanPayloadLen; i++)
                        {
                            canFrame.mData[i + offset] = mbFrame[i + startIndex];
                        }

                        canFrameList.Add(canFrame);
                        startIndex += oneFrameCanPayloadLen;
                        frameCnt++;
                    }
                }
            }
            //else if (CheckCmdIsTransparentCmd(cmd))
            //{
            //    //  透传帧
            //    canPayloadMaxLen = (64);  //  透传帧最大数据长度为64
            //    CAN_ID canId2 = new CAN_ID(mCanId);
            //    if (canId2.QorR == 0x01)
            //    {
            //        mbDataLen = (byte)(mbFrame.Length + 3);
            //    }
            //    else
            //    {
            //        mbDataLen = (byte)(mbFrame.Length + 2);
            //    }

            //    if ((mbFrame[0] == 0x08 || mbFrame[0] == 0x06) && mbFrame.Length == 0x06)
            //    {
            //        CAN_Frame canFrame = new CAN_Frame();
            //        canFrame.mCanId = new CAN_ID(0x18FF0221);
            //        int canFrameLen = (0x40);
            //        canFrame.len = (uint)canFrameLen;
            //        canFrame.mData = new byte[canFrameLen];
            //        for (int i = 0; i < (mbFrame.Length); i++)
            //        {
            //            canFrame.mData[i] = mbFrame[i];
            //        }
            //        canFrameList.Add(canFrame);
            //    }
            //    else if (mbFrame[0] == 0x11 || mbFrame[0] == 0x10 || mbFrame[0] == 0x12)
            //    {
            //        CAN_Frame canFrame = new CAN_Frame();
            //        canFrame.mCanId = new CAN_ID(mTpCanId);
            //        int canFrameLen = (0x40);
            //        canFrame.len = (uint)canFrameLen;
            //        canFrame.mData = new byte[canFrameLen];
            //        for (int i = 0; i < (mbFrame.Length); i++)
            //        {
            //            canFrame.mData[i] = mbFrame[i];
            //        }
            //        canFrameList.Add(canFrame);
            //    }
            //    else if (cmd == 0x01 || cmd == 0x02)  
            //    {
            //        CAN_Frame canFrame = new CAN_Frame();
            //        canFrame.mCanId = new CAN_ID(mTpCanId);
            //        int canFrameLen = (0x40);
            //        canFrame.len = (uint)canFrameLen;
            //        canFrame.mData = new byte[canFrameLen];
            //        canFrame.mData[0] = cmd;     
            //        canFrameList.Add(canFrame);
            //    }
            //    else if (cmd == 0x0C)
            //    { 
            //        CAN_Frame canFrame = new CAN_Frame();
            //        canFrame.mCanId = new CAN_ID(0x18FF0220);
            //        int canFrameLen = (0x40);
            //        canFrame.len = (uint)canFrameLen;
            //        canFrame.mData = new byte[canFrameLen];
            //        int offset = 0;
            //        for (int i = offset; i < (mbFrame.Length); i++)
            //        {
            //            canFrame.mData[i] = mbFrame[i];
            //        }
            //        canFrameList.Add(canFrame);
            //    }
            //    else if (mbFrame[0] == 0x20 && mbFrame.Length == 0x06)
            //    {
            //        CAN_Frame canFrame = new CAN_Frame();
            //        canFrame.mCanId = new CAN_ID(0x18FF0200);
            //        int canFrameLen = (0x02);
            //        canFrame.len = (uint)canFrameLen;
            //        canFrame.mData = new byte[canFrameLen];
            //        for (int i = 0; i < canFrameLen; i++)
            //        {
            //            canFrame.mData[i] = mbFrame[i];
            //        }
            //        canFrameList.Add(canFrame);
            //    }
            //    else if (mbDataLen <= canPayloadMaxLen)  // 单帧单次
            //    {
            //        CAN_Frame canFrame = new CAN_Frame();
            //        CAN_ID canId = new CAN_ID(mTpCanId);                    
            //        canId.QorR = canId2.QorR;
            //        canFrame.mCanId = canId;
            //        int canFrameLen = (mbDataLen);  //  canFrameLen <= 64
            //        canFrame.len = (uint)canFrameLen;
            //        canFrame.mData = new byte[canFrameLen];
            //        int offset = 0;
            //        canFrame.mData[offset++] = 0x00;                    
            //        if (canId2.QorR == 0x01)
            //        {
            //            canFrame.mData[offset++] = (byte)(mbFrame.Length + 1);
            //            canFrame.mData[offset++] = 0x00; // 应答帧CAN报文还要在加错误码
            //            for (int i = offset; i < (mbDataLen); i++)
            //            {
            //                canFrame.mData[i] = mbFrame[i - offset];
            //            }
            //        }
            //        else
            //        {
            //            canFrame.mData[offset++] = (byte)(mbFrame.Length);
            //            for (int i = offset; i < (mbDataLen); i++)
            //            {
            //                canFrame.mData[i] = mbFrame[i - offset];
            //            }
            //        }

            //        canFrameList.Add(canFrame);
            //    }
            //}
            else
            {
                //  单帧
                //canPayloadMaxLen = (64 - 2);  //  单帧最大数据长度为62
                canPayloadMaxLen = (64);
                mbDataLen = (byte)(mbFrame.Length - 2); // 去掉addr和cmd，剩下的都是can报文内容
                if (mbDataLen <= canPayloadMaxLen)  // 单帧单次
                {
                    CAN_Frame canFrame = new CAN_Frame();
                    canFrame.mCanId.can_id = mCanId;
                    canFrame.mCanId.CmdHigh = cmd;
                    int canFrameLen = mbDataLen;  //  canFrameLen <= 64
                    canFrame.len = (uint)canFrameLen;
                    canFrame.mData = new byte[canFrameLen];
                    int offset = 0;
                    //canFrame.mData[offset++] = subCmd;
                    //canFrame.mData[offset++] = mbDataLen;
                    for (int i = 0; i < mbDataLen; i++)
                    {
                        canFrame.mData[i + offset] = mbFrame[2 + i];
                    }
                    canFrameList.Add(canFrame);
                }
            }

            return canFrameList;
        }

        public static byte[] ByteArrayInsert(byte[] frame, int insertStartIndex, byte[] insertData)
        {
            byte[] result = new byte[frame.Length + insertData.Length];
            if (insertStartIndex > frame.Length)
            {
                return null;
            }
            for (int i = 0; i < (frame.Length + insertData.Length); i++)
            {
                if (i < insertStartIndex)
                {
                    result[i] = frame[i];
                }
                else if (i < (insertStartIndex + insertData.Length))
                {
                    result[i] = insertData[i - insertStartIndex];
                }
                else
                {
                    result[i] = frame[i - insertData.Length];
                }
            }
            return result;
        }

        public static uint GetTpCanId()
        {
            return mTpCanId;
        }

        public static byte[] CanToModbusJumpErrorCode(CAN_Frame canFrame)
        {
            byte[] mdFrame = new byte[0];
            int offset = 0;
            if (canFrame.mCanId.QorR == 0x01)
            {
                offset = 3;// 跳过错误码
            }
            else
            {
                offset = 2;
            }
            mdFrame = new byte[canFrame.len - offset];
            for (int i = 0; i < mdFrame.Length; i++)
            {
                mdFrame[i] = canFrame.mData[i + offset];
            }
            return mdFrame;
        }

        public static byte[] CanToModbusFrame(CAN_Frame canFrame)
        {
            byte[] mdFrame = new byte[0];

            byte cmd = canFrame.mCanId.CmdHigh;
            if (CheckCmdIsTransparentCmd(cmd))
            {
                byte[] mdFrame2 = new byte[0];
                mdFrame2 = CanToModbusJumpErrorCode(canFrame);
                //if (canFrame.mCanId.QorR == 0x01)  // 跳过modbus里面的错误码
                //{
                //    mdFrame = new byte[mdFrame2.Length - 1];
                //    for (int i = 0; i < mdFrame.Length; i++)
                //    {
                //        if (i < 3)
                //        {
                //            mdFrame[i] = mdFrame2[i];
                //        }
                //        else
                //        {
                //            mdFrame[i] = mdFrame2[i + 1];
                //        }
                //    }
                //}
                //else
                {
                    mdFrame = mdFrame2;
                }
            }
            else
            {
                cmd = (byte)(((((cmd & 0xF0) >> 4) + 1) << 4) | (cmd & 0x0F));
                if (CheckCmdIsTlvCmd(cmd))  //  判断是否是多帧
                {
                    if (canFrame.len < 2)
                    {
                        return mdFrame;
                    }
                    int offset = 0;
                    byte subcmd = canFrame.mData[offset++];    // 子功能码（1）+数据长度（1）+多帧序号（1）+错误码（1，如果是回复帧）+数据（N）
                    byte pyloadLen = canFrame.mData[offset++];

                    byte ctrlCode = canFrame.mData[offset++];
                    byte frameCnt = (byte)(ctrlCode & 0x0F);
                    ctrlCode = (byte)(ctrlCode & 0xF0);
                    byte qOrR = canFrame.mCanId.QorR;
                    pyloadLen = (byte)(pyloadLen - 1);  //  多帧的数据长度比实际payload多1个帧序号字节，所以要减去这个字节

                    if ((ctrlCode == 0x00) && (frameCnt == 0))  //  多帧单次帧
                    {
                        if (canFrame.mCanId.QorR == 0x01)
                        {
                            pyloadLen = (byte)(pyloadLen - 1);  //  实际payload还要少1个字节，这个字节是错误码
                            offset++;//  跳过错误码
                        }

                        int mdFrameLen = (int)(pyloadLen + 3 + 2);  // 3 = addr+cmd+subcmd, 2 = crc
                        mdFrame = new byte[mdFrameLen];
                        mdFrame[0] = 0x00;
                        mdFrame[1] = cmd;
                        mdFrame[2] = subcmd;

                        for (int i = 0; i < pyloadLen; i++)
                        {
                            mdFrame[3 + i] = canFrame.mData[offset + i];
                        }
                        ushort crcShort = ModbusCrc.Crc16(mdFrame, mdFrame.Length - 2);
                        mdFrame[mdFrameLen - 2] = (byte)(crcShort & 0xFF);
                        mdFrame[mdFrameLen - 1] = (byte)(crcShort >> 8);
                    }
                    else if ((ctrlCode == 0x00) && (frameCnt != 0))  //  多帧最后一帧
                    {
                        if (frameCnt == (mRecvCanFrameCnt + 1))
                        {
                            for (int i = 0; i < pyloadLen; i++)
                            {
                                mRecvCanLongFrame.Add(canFrame.mData[i + offset]);
                            }
                            mRecvCanFrameCnt = 0;

                            byte lenH = mRecvCanLongFrame[4];
                            byte lenL = mRecvCanLongFrame[5];
                            ushort datLen = (ushort)((lenH << 8) + lenL);
                            mdFrame = new byte[datLen + 8]; // 8 = addr+cmd+subcmd+tagNum+datLen+crc
                            for (int j = 0; j < (datLen + 8); j++)
                            {
                                if (j >= mRecvCanLongFrame.Count)
                                {
                                    mdFrame[j] = 0;
                                }
                                else
                                {
                                    mdFrame[j] = mRecvCanLongFrame[j];
                                }
                            }

                            return mdFrame;
                        }
                    }
                    else if (ctrlCode == 0x80)  //  多帧多次帧
                    {
                        if (frameCnt == 1)  //  多帧多次帧的首帧序号从1开始
                        {
                            mRecvCanFrameCnt++;
                            mRecvCanLongFrame = new List<byte>();

                            mRecvCanLongFrame.Add(0x00);
                            mRecvCanLongFrame.Add(cmd);
                            mRecvCanLongFrame.Add(subcmd);
                            if (canFrame.mCanId.QorR == 0x01)
                            {
                                pyloadLen = (byte)(pyloadLen - 1);  //  实际payload还要少1个字节，这个字节是错误码
                                offset++;//  跳过错误码
                            }
                            for (int i = 0; i < pyloadLen; i++)
                            {
                                mRecvCanLongFrame.Add(canFrame.mData[i + offset]);
                            }
                        }
                        else if (frameCnt == (mRecvCanFrameCnt + 1))
                        {
                            mRecvCanFrameCnt++;
                            for (int i = 0; i < pyloadLen; i++)
                            {
                                mRecvCanLongFrame.Add(canFrame.mData[i + offset]);
                            }
                        }
                    }
                }
            }
            
            return mdFrame;
        }

        public static byte[] MakeSouthDevWriteCmdFrame(byte addr, ushort cmd, ushort len, byte[] datbuf)
        {
            List<byte> sendList = new List<byte>();

            if (len != datbuf.Length)
            {
                return null;
            }
            
            sendList.Add(addr);
            sendList.Add((byte)(cmd >> 8));
            sendList.Add((byte)(cmd & 0x00FF));
            sendList.Add((byte)(len >> 8));
            sendList.Add((byte)(len & 0x00FF));

            for (int i = 0; i < len; i++)
            {
                sendList.Add(datbuf[i]);
            }

            byte[] crcDat = sendList.ToArray();
            ushort crcShort = ModbusCrc.Crc16(crcDat, crcDat.Length);
            sendList.Add((byte)(crcShort & 0xFF));
            sendList.Add((byte)(crcShort >> 8));

            return sendList.ToArray();
        }

        public static byte[] MakeSouthDevReadCmdFrame(byte addr, ushort cmd, ushort len)
        {
            List<byte> sendList = new List<byte>();

            sendList.Add(addr);
            sendList.Add((byte)(cmd >> 8));
            sendList.Add((byte)(cmd & 0x00FF));
            sendList.Add((byte)(len >> 8));
            sendList.Add((byte)(len & 0x00FF));

            for (int i = 0; i < len; i++)
            {
                //sendList.Add(0x00);
            }

            byte[] crcDat = sendList.ToArray();
            ushort crcShort = ModbusCrc.Crc16(crcDat, crcDat.Length);
            sendList.Add((byte)(crcShort & 0xFF));
            sendList.Add((byte)(crcShort >> 8));

            return sendList.ToArray();
        }
    }
}
