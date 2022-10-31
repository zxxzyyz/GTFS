using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using ProtoGTFS.Common;
using ProtoGTFS.GTFS;
using System.Text;
using ProtoGTFS.GTFS.Entity;

namespace ProtoGTFS
{
    class Program
    {
        static void Main(string[] args)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            var a1 = int.Parse(null);
            var a2 = int.Parse("");
            var master = new List<byte>();

            master.AddBytes(0, 1, true);
            master.AddBytes(0, 1, true);
            master.AddBytes(0, 1, true);
            master.AddBytes(0, 1, true);
            master.AddBytes(0, 1, true);
            master.AddBytes(0, 1, true);
            master.AddBytes(2, 1, true);

            var add = master.Count;
            master.AddBytes(16777215, 3, true);

            master.AddBytes(0, 1, true);
            master.AddBytes(0, 1, true);
            master.AddBytes(0, 1, true);
            master.AddBytes(0, 1, true);
            master.AddBytes(0, 1, true);
            master.AddBytes(0, 1, true);
            master.AddBytes(0, 1, true);
            master.AddBytes(0, 1, true);
            master.AddBytes(0, 1, true);
            var size = master.Count;
            master.AddBytes(2, 1, true);
            master.AddBytes(2, 1, true);
            master.AddBytes(2, 1, true);
            master.AddBytes(2, 1, true);
            master.AddBytes(2, 1, true);
            master.AddBytes(2, 1, true);
            master.AddBytes(2, 1, true);
            master.AddBytes(2, 1, true);
            master.AddBytes(2, 1, true);
            master.AddBytes(2, 1, true);
            master.AddBytes(2, 1, true);
            master.AddBytes(2, 1, true);

            size = master.Count - size;

            var b = master.ToArray();
            var c = new List<byte>();
            c.AddBytes(size, 3, true);
            var d = c.ToArray();
            Array.Copy(d, 0, b, add, d.Length);

            var master2 = b.ToList();
            Console.WriteLine(master.Count);
            Console.WriteLine(master2.Count);



            //var a = "ハソ通り【朝霞警察署】";
            //var b = Utility.SJISToBytes(a, 10);
            //var c = a.Substring(a.Length - 1, 1);
            //var d = "1";
            //Console.WriteLine(c);
            //Console.WriteLine(Encoding.GetEncoding("Shift-JIS").GetByteCount(c));
            //Console.WriteLine(Encoding.GetEncoding("Shift-JIS").GetByteCount(d));
            //Console.WriteLine(Encoding.UTF8.GetByteCount(c));
            //Console.WriteLine(Encoding.UTF8.GetByteCount(d));
            //Console.WriteLine("");
            //foreach (var item in a)
            //{
            //    Console.WriteLine(item);
            //}
            //foreach (var item in b)
            //{
            //    Console.WriteLine(item);
            //    Console.WriteLine(System.Text.Encoding.GetEncoding("sjis").GetString(new byte[1] { item }));
            //}
        }
        static void ReadCsv()
        {
            //CsvHelper.ReadCsv(agency1st, ".\\Agency.txt");
            //CsvHelper.ReadCsv(agencyjp1st, ".\\Agency_jp.txt");
            //CsvHelper.ReadCsv(calendar1st, ".\\Calendar.txt");
            //CsvHelper.ReadCsv(calendarDates1st, ".\\Calendar_dates.txt");
            //CsvHelper.ReadCsv(fareAttributes1st, ".\\Fare_attributes.txt");
            //CsvHelper.ReadCsv(fareRules1st, ".\\Fare_rules.txt");
            //CsvHelper.ReadCsv(feedInfo1st, ".\\Feed_info.txt");
            //CsvHelper.ReadCsv(frequencies1st, ".\\Frequencies.txt");
            //CsvHelper.ReadCsv(officeJp1st, ".\\Office_jp.txt");
            //CsvHelper.ReadCsv(routes1st, ".\\Routes.txt");
            //CsvHelper.ReadCsv(routesJp1st, ".\\Routes_jp.txt");
            //CsvHelper.ReadCsv(shapes1st, ".\\Shapes.txt");
            //CsvHelper.ReadCsv(stopTimes1st, ".\\Stop_times.txt");
            //CsvHelper.ReadCsv(stops1st, ".\\Stops.txt");
            //CsvHelper.ReadCsv(transfers1st, ".\\Transfers.txt");
            //CsvHelper.ReadCsv(translations1st, ".\\Translations.txt");
            //CsvHelper.ReadCsv(trips1st, ".\\Trips.txt");

            //CsvHelper.ReadCsv(agency2nd, ".\\Agency.txt");
            //CsvHelper.ReadCsv(agencyjp2nd, ".\\Agency_jp.txt");
            //CsvHelper.ReadCsv(calendar2nd, ".\\Calendar.txt");
            //CsvHelper.ReadCsv(calendarDates2nd, ".\\Calendar_dates.txt");
            //CsvHelper.ReadCsv(fareAttributes2nd, ".\\Fare_attributes.txt");
            //CsvHelper.ReadCsv(fareRules2nd, ".\\Fare_rules.txt");
            //CsvHelper.ReadCsv(feedInfo2nd, ".\\Feed_info.txt");
            //CsvHelper.ReadCsv(frequencies2nd, ".\\Frequencies.txt");
            //CsvHelper.ReadCsv(officeJp2nd, ".\\Office_jp.txt");
            //CsvHelper.ReadCsv(routes2nd, ".\\Routes.txt");
            //CsvHelper.ReadCsv(routesJp2nd, ".\\Routes_jp.txt");
            //CsvHelper.ReadCsv(shapes2nd, ".\\Shapes.txt");
            //CsvHelper.ReadCsv(stopTimes2nd, ".\\Stop_times.txt");
            //CsvHelper.ReadCsv(stops2nd, ".\\Stops.txt");
            //CsvHelper.ReadCsv(transfers2nd, ".\\Transfers.txt");
            //CsvHelper.ReadCsv(translations2nd, ".\\Translations.txt");
            //CsvHelper.ReadCsv(trips2nd, ".\\Trips.txt");
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
    }
    public static class StringExtension
    {
        public static void ReplaceBytes(this List<byte> list, object value, int replaceLength, int replaceIndex, bool toHex, bool padLeft = true)
        {
            var a = new List<byte>();
            a.AddBytes(value, replaceLength, toHex, padLeft);
            for (int i = 0; i < a.Count; i++)
            {
                list[replaceIndex + i] = a[i];
            }
        }

        public static void AddBytes(this List<byte> list, object value, int byteLength, bool toHex, bool padLeft = true)
        {
            var result = new List<byte>();
            string strValue = Convert.ToString(value);

            if (toHex)
            {
                int intValue;
                if (int.TryParse(strValue, out intValue)) strValue = intValue.ToString("X");
                else return;
            }

            if (padLeft) strValue = strValue.PadLeft(byteLength * 2, '0');
            else strValue = strValue.PadRight(byteLength * 2, '0');

            for (int i = 0; i < strValue.Length - 1; i += 2)
            {
                string temp = Convert.ToString(strValue[i]) + Convert.ToString(strValue[i + 1]);
                result.Add(Convert.ToByte(temp, 16));
            }

            list.AddRange(result.ToArray());
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

        public static string Left(this string str, int length)
        {
            return str.Substring(0, length);
        }

        public static string Right(this string str, int length)
        {
            return str.Substring(str.Length - length, length);
        }

        public static string LeftBytes(this string str, int length)
        {
            return str.Substring(0, length);
        }

        public static bool Eq(this string string1, string string2)
        {
            return string1.Equals(string2, StringComparison.OrdinalIgnoreCase);
        }
    }
}