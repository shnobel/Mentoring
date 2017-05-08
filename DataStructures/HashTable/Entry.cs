namespace HashTable
{
    public class Entry<TKey, TValue>
    {
        TKey key;
        TValue data;
        public Entry(TKey key, TValue data)
        {
            this.key = key;
            this.data = data;
        }
        public TKey Getkey()
        {
            return key;
        }
        public TValue GetValue()
        {
            return data;
        }
    }
}
