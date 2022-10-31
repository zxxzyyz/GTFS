using ProtoGTFS.GTFS.Entity;
using System;
using System.Collections.Generic;

namespace ProtoGTFS.GTFS.Collection
{
    public class UniqueEntityCollection<T> : IEntityCollection<T> where T : GTFSEntity
    {
        private List<T> list;

        private Func<T, string, bool> hasKey;

        public UniqueEntityCollection(List<T> list, Func<T, string, bool> hasKey)
        {
            this.list = list;
            this.hasKey = hasKey;
        }

        public int Count { get { return list.Count; } }

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
            foreach (var element in list) if (hasKey(element, key)) return element;
            return default(T);
        }

        public T Get(string key1, string key2)
        {
            throw new NotImplementedException();
        }

        public T Get(int index)
        {
            return list[index];
        }

        public bool Remove(string key)
        {
            for (int index = 0; index < list.Count; index++)
            {
                if (hasKey(list[index], key))
                {
                    list.RemoveAt(index);
                    return true;
                }
            }
            return false;
        }
        public bool Remove(string key1, string key2)
        {
            throw new NotImplementedException();
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

        public void ParseCsvToList(string[] csv)
        {
            throw new NotImplementedException();
        }
    }
}
