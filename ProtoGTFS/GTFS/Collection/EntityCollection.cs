using System;
using System.Collections.Generic;
using System.Reflection;
using ProtoGTFS.Common;
using ProtoGTFS.GTFS.Entity;

namespace ProtoGTFS.GTFS.Collection
{
    public class EntityCollection<T> : IEntityCollection<T> where T : GTFSEntity
    {
        private List<T> list;

        private Func<T, string, string, bool> haveKeys;

        public EntityCollection(List<T> list, Func<T, string, string, bool> haveKeys)
        {
            this.list = list;
            this.haveKeys = haveKeys;
        }

        public int Count { get { return list.Count; } }

        public void ParseCsvToList(string[] csv)
        {
            Type type = typeof(T).GetTypeInfo().GenericTypeArguments[0];
            var classTagName = type.GetCustomAttribute<TagAttribute>().Name;
            var fileNode = Config.configGTFSDefine.Find(fileNode => fileNode.Name == classTagName);
            PropertyInfo[] p = type.GetProperties();

            string[] csvHeaders = csv[0].Split(',');
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
            foreach (var csvRow in csv)
            {
                if (skipHeaderRow)
                {
                    skipHeaderRow = false;
                    continue;
                }
                var csvField = csvRow.Split(',');
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

        public void Add(T element)
        {
            list.Add(element);
        }

        public void AddRange(IEntityCollection<T> list)
        {
            this.list.AddRange(list);
        }

        public T Get(string key)
        {
            throw new NotImplementedException();
        }

        public T Get(string key1, string key2)
        {
            foreach (var element in list) if (haveKeys(element, key1, key2)) return element;
            return default(T);
        }

        public T Get(int index)
        {
            return list[index];
        }

        public bool Remove(string key)
        {
            throw new NotImplementedException();
        }

        public bool Remove(string key1, string key2)
        {
            for (int index = 0; index < list.Count; index++)
            {
                if (haveKeys(list[index], key1, key2))
                {
                    list.RemoveAt(index);
                    return true;
                }
            }
            return false;
        }

        public void RemoveAll()
        {
            list = new List<T>();
        }

        public IEnumerable<T> Get() { return list; }

        public IEnumerator<T> GetEnumerator()
        {
            return list.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return list.GetEnumerator();
        }
    }
}
