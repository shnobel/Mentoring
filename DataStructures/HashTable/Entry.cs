namespace HashTable
{
    public class Entry<TKey, TValue>
    {
        private object Key { get; set; }
        private object Data { get; set; }
        public Entry(object key, object data)
        {
            Key = key;
            Data = data;
        }

        public object Getkey()
        {
            return Key ?? null;
        }
        public object GetValue()
        {
            return Data;
        }
    }
}
