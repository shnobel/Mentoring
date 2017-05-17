namespace MyHashTable
{
    public class Entry
    {
        private object Key { get; set; }
        private object Data { get; set; }
        public Entry(object key, object data)
        {
            Key = key;
            Data = data;
        }

        public object GetKey()
        {
            return Key ?? null;
        }
        public object GetValue()
        {
            return Data;
        }
    }
}
