using ProtoGTFS.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace ProtoGTFS.GTFS.Entity
{
    public abstract class GTFSEntity
    {
        public override string ToString()
        {
            var sb = new StringBuilder();
            PropertyInfo[] properties = this.GetType().GetProperties();

            foreach (var prop in properties)
            {
                var value = prop.GetValue(this, null) ?? "(null)";
                sb.AppendLine(prop.Name + ": " + value.ToString());
            }

            return sb.ToString();
        }

        public void ReadCsv<T>(List<T> list, string file)
        {
            Type listType = list.GetType().GetTypeInfo().GenericTypeArguments[0];
            var fileTagName = listType.GetCustomAttribute<TagAttribute>().Name;
            var fileNode = Config.configGTFSDefine.Find(fileNode => fileNode.Name == fileTagName);
            PropertyInfo[] p = listType.GetProperties();
            string[] csvData = File.ReadAllLines(file);

            string[] csvHeaders = csvData[0].Split(',');
            for (int i = 0; i < p.Length; i++)
            {
                string fieldTagName = p[i].GetCustomAttribute<TagAttribute>().Name;
                if (p[i].GetCustomAttribute<Key>() != null || p[i].GetCustomAttribute<Required>() != null)
                {
                    var headerExists = false;
                    for (int j = 0; j < csvHeaders.Length; j++)
                    {
                        if (csvHeaders[j].Equals(fieldTagName, StringComparison.OrdinalIgnoreCase)) headerExists = true;
                    }
                    if (!headerExists)
                    {
                        // Csv file does not have key header or required header.
                    }
                }
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
                var entity = Activator.CreateInstance<T>();

                for (int i = 0; i < p.Length; i++)
                {
                    string fieldTagName = p[i].GetCustomAttribute<TagAttribute>().Name;
                    var fieldNode = fileNode.Find(fieldTagName);

                    p[i].SetValue(entity, csvField[Convert.ToInt32(fieldNode.Order)]);
                }
                list.Add(entity);
            }
        }
    }
}
