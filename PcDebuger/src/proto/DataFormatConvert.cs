using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace PcDebuger
{
    class DataFormatConvert
    {
        private static DataFormatConvert instance;
        private static readonly object lockObject = new object();

        private DataFormatConvert() { }

        public static DataFormatConvert Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (lockObject)
                    {
                        if (instance == null)
                        {
                            instance = new DataFormatConvert();
                        }
                    }
                }
                return instance;
            }
        }

        public static string HexArrayToString(byte[] data)
        {
            return BitConverter.ToString(data).Replace("-", " ");
        }

        public static byte[] CmdStringToAscii(string cmd)
        {
            if (cmd == null)
            {
                return null;
            }
            string[] words = cmd.Split(' ');
            cmd = string.Join(string.Empty, words);
            return HexStringToAscii(cmd);
        }

        public static byte[] HexStringToAscii(string hexString)
        {
            List<byte> tmpList = new List<byte>();
            if (ContainsInvalidHexChars(hexString))
            {
                return null;
            }
            for (int i = 0; i < hexString.Length - 1; i += 2)
            {
                string hex = hexString.Substring(i, 2);
                byte sb = Convert.ToByte(hex, 16);
                tmpList.Add(sb);
            }
            return tmpList.ToArray();
        }

        private static bool ContainsInvalidHexChars(string input)
        {
            // 正则表达式匹配任何非0-9或A-F的字符
            return Regex.IsMatch(input, "[^0-9A-Fa-f ]");
        }
    }
}
