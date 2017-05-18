namespace MyHashTable
{
    interface IHashTable
    {
        int Size { get; }
        bool Contains(object key);
        void Add(object key, object value);
        object this[object key] { get; set; }
        bool TryGet(object key, out object value);
    }
}
