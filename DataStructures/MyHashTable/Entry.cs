namespace MyHashTable
{
    public class Entry
    {
        public object Key { get; set; }
        public object Data { get; set; }
        public Entry(object key, object data)
        {
            Key = key;
            Data = data;
        }
    }
}
