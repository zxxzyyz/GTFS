using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProtoGTFS.Common
{
    public static class Utility
    {
        public static byte[] SJISToBytes(string text, int byteLength)
        {
            var result = Encoding.GetEncoding("Shift-JIS").GetBytes(text);
            Array.Resize(ref result, byteLength);
            return result;
        }

        public static void AddSJIS(this List<byte> list, string text, int byteLength)
        {
            var totalsize = 0;
            for (int i = 0; i < text.Length; i++)
            {
                var size = Encoding.GetEncoding("Shift-JIS").GetByteCount(text.Substring(i, 1));
                if (totalsize + size <= byteLength)
                {
                    totalsize += size;
                }
            }
            var result = Encoding.GetEncoding("Shift-JIS").GetBytes(text);
            Array.Resize(ref result, totalsize);
            list.AddRange(result.ToArray());
            if (byteLength > totalsize) list.AddRange(new byte[byteLength - totalsize]);
        }

        public static string Right(this string str, int length)
        {
            return str.Substring(str.Length - length, length);
        }

        public static byte GetSum(byte[] bytes, int dimension = 0)
        {
            int totalByte = 0;
            for (int i = 0; i <= bytes.GetUpperBound(dimension); i++) totalByte += -bytes[i];

            return BitConverter.GetBytes(totalByte)[0];
        }

        public static byte[] ToBytes(object value, int byteLength, bool toHex, bool padLeft = true)
        {
            var result = new List<byte>();
            string strValue = Convert.ToString(value);

            if (toHex)
            {
                int intValue;
                if (int.TryParse(strValue, out intValue)) strValue = intValue.ToString("X");
                else return new byte[0];
            }

            if (padLeft) strValue = strValue.PadLeft(byteLength * 2, '0');
            else strValue = strValue.PadRight(byteLength * 2, '0');

            for (int i = 0; i < strValue.Length - 1; i += 2)
            {
                string temp = Convert.ToString(strValue[i]) + Convert.ToString(strValue[i + 1]);
                result.Add(Convert.ToByte(temp, 16));
            }

            return result.ToArray();
        }

        public static byte[] t(object value, int byteLength, bool isToHex, char paddingChar = '0', bool IsPadLeft = true, bool isUnit10 = false)
        {
            var bytes = new List<byte>();
            string workValue = Convert.ToString(value);

            if (isUnit10 == true)
            {
                int intRet;
                // 10円単位の場合、10で割って小数を切り捨てる。
                if (int.TryParse(workValue, out intRet) == true)
                {
                    int intWork = intRet / 10;
                    workValue = Convert.ToString(intWork);
                }
                else
                {
                    //- 数値に変換できない場合、エラーを発生させる。
                }
            }

            if (isToHex == true)
            {
                // HEX変換が必要な場合、変換を行う。
                int intRet;
                if (int.TryParse(workValue, out intRet) == true)
                {
                    workValue = intRet.ToString("X");
                }
                else
                {
                    //- 数値に変換できない場合、エラーを発生させる。
                }
            }

            // 指定桁数まで、埋め込み文字で埋める。
            if (IsPadLeft == true)
            {
                //!左埋め
                workValue = workValue.PadLeft(byteLength * 2, paddingChar);
            }
            else
            {
                //!右埋め
                workValue = workValue.PadRight(byteLength * 2, paddingChar);
            }

            // Byte変換を行う。
            for (int index = 0; index < workValue.Length - 1; index += 2)
            {
                string work = Convert.ToString(workValue[index]) + Convert.ToString(workValue[index + 1]);
                bytes.Add(System.Convert.ToByte(work, 16));
            }

            return bytes.ToArray();
        }
    }
}
