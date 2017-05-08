using System;

namespace HashTable
{
    public class HashTable<TKey, TValue> : IHashTable
    {
        Entry<TKey, TValue>[] list;

        public HashTable(int size)
        {
            list = new Entry<TKey, TValue>[size];
        }

        public object this[object key] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Add(object key, object value)
        {
            if (Contains(key))
            {
                throw new Exception();
            }

            var entry = new Entry<TKey,TValue>((TKey)key, (TValue)value);
            var hash = GetHashCode(key);
            while (list[hash] != null)
            {
                if(hash == list.Length)
                {
                    hash--;
                    break;
                }
                else
                {
                    hash++;
                }
            }
            list[hash] = entry;
        }

        public bool Contains(object key)
        {
            var result = false;
            foreach(var item in list)
            {
                if (item.Getkey() != null)
                {
                    result = item.Getkey().Equals(key) ? true : false;
                }
                else break;
            }
            return result;
        }

        public bool TryGet(object key, out object value)
        {
            value = 5;
            return true;

            //hash the key
            //Search chain for entry with diven key
            //if found return it, otherwise null
        }

        //Optional
        public void Remove(object key)
        {
            //hash the key
            //Search chain for entry with diven key
            //Remove it from chain if found
            //Return entry or null
        }

        public int GetHashCode(object obj)
        {
            unchecked // Overflow is fine, just wrap
            {
                int hash = 17;
                hash = (hash * 23 + obj.GetHashCode()) % list.Length;
                return hash < 0 ? hash*-1 : hash;
            }
        }
    }
}
