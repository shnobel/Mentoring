using System;
using System.Linq;

namespace MyHashTable
{
    public class HashTable : IHashTable
    {
        private Entry[] buckets;

        public HashTable()
        {
            buckets = new Entry[10];
        }

        public int Size
        {
            get
            {
                return buckets.Select(item => item).OfType<Entry>().Count();
            }
        }

        public object this[object key]
        {
            get
            {
                object result;
                if (TryGet(key, out result))
                {
                    return result;
                }
                throw new IndexOutOfRangeException();
            }
            set
            {
                if (Contains(key))
                {
                    throw new Exception();
                }

                if (value == null)
                {
                    return;
                }
               
                else
                {
                    Add(key, value);
                }
            }
        }

        public void Add(object key, object value)
        {
            if (Contains(key) || value == null)
            {
                throw new Exception();
            }

            var entry = new Entry(key, value);
            var hash = GetHashCode(key);
            while (buckets[hash] != null)
            {
                if(hash == buckets.Length)
                {
                    hash--;
                    break;
                }
                else
                {
                    hash++;
                }
            }
            buckets[hash] = entry;
        }

        public bool Contains(object key)
        {
            var result = false;
            foreach(var item in buckets)
            {
                if (result) return result;
                try
                {
                    result = item.Key.Equals(key);
                }
                catch (NullReferenceException e)
                {
                    result = false;
                }
            }
            return result;
        }

        public bool TryGet(object key, out object value)
        {
            if (!Contains(key))
            {
                value = null;
                return false;
            }
            value = buckets.Single(item => item != null && item.Key.Equals(key)).Data;
            return value != null ? true : false;
        }

        public int GetHashCode(object obj)
        {
            unchecked // Overflow is fine, just wrap
            {
                int hash = 17;
                hash = (hash * 23 + obj.GetHashCode()) % buckets.Length;
                return hash < 0 ? hash*-1 : hash;
            }
        }
    }
}
