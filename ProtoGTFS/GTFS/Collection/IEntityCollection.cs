using ProtoGTFS.GTFS.Entity;
using System.Collections.Generic;

namespace ProtoGTFS.GTFS.Collection
{
    public interface IEntityCollection<T> : IEnumerable<T> where T : GTFSEntity
    {
        int Count { get; }

        void ParseCsvToList(string[] csv);

        void Add(T element);

        void AddRange(IEntityCollection<T> list);

        T Get(string key1);

        T Get(string key1, string key2);

        T Get(int index);

        bool Remove(string key1);

        bool Remove(string key1, string key2);

        void RemoveAll();

        IEnumerable<T> Get();
    }
}
