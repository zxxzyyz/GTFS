using System;
using System.IO;
using System.Reflection;
using System.Collections.Generic;

namespace ProtoGTFS.Common
{
    public static class CsvHelper
    {
        public static void ReadCsv<T> (List<T> list, string file)
        {
            Type listType = list.GetType().GetTypeInfo().GenericTypeArguments[0];
            PropertyInfo[] prop = listType.GetProperties();
            var skipField = new bool[prop.Length];
            var colIndex = new int[prop.Length];
            string[] csvData = File.ReadAllLines(file);
            string[] csvHeaders = csvData[0].Split(',');

            for (int i = 0; i < prop.Length; i++)
            {
                if (prop[i].GetCustomAttribute(typeof(Key), false) != null || prop[i].GetCustomAttribute(typeof(Required), false) != null)
                {
                    for (int j = 0; j < csvHeaders.Length; j++)
                    {

                    }
                    if (csvData[0].IndexOf(prop[i].Name, StringComparison.OrdinalIgnoreCase) < 0)
                    {
                        // Csv file does not have key header or required header.
                    }
                }

                var headerExist = false;
                for (int j = 0; j < csvHeaders.Length; j++)
                {
                    if (prop[i].Name.Equals(csvHeaders[j], StringComparison.OrdinalIgnoreCase))
                    {
                        // Header exists in csv file.
                        headerExist = true;
                        colIndex[i] = j;
                        break;
                    }
                }
                if (!headerExist) skipField[i] = true; // Header does not exist in csv file.
            }

            var skipHeaderRow = true;
            foreach (var csv in csvData)
            {
                if (skipHeaderRow)
                {
                    skipHeaderRow = false;
                    continue;
                }
                var csvField = csv.Split(',');
                var listElement = Activator.CreateInstance<T>();

                for (int i = 0; i < prop.Length; i++)
                {
                    if (skipField[i]) continue;
                    prop[i].SetValue(listElement, csvField[colIndex[i]]);
                }
                list.Add(listElement);
            }
        }
    }
}
