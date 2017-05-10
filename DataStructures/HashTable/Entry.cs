namespace HashTable
{
    public class Entry<TKey, TValue>
    {
        object key;
        object data;
        public Entry(object key, object data)
        {
            this.key = key;
            this.data = data;
        }

        public object Getkey()
        {
            //if (this != null)
            //{
            //    return key;
            //}
            //else
            //{
            //    return null;
            //}
            return key ?? null;
        }
        public object GetValue()
        {
            return data;
        }
    }
}
