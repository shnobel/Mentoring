using System;
using System.Linq;

namespace MyHashTable
{
    public class HashTable : IHashTable
    {
        private Entry[] list;

        public HashTable()
        {
            list = new Entry[10];
        }

        public int Size
        {
            get
            {
                return list.Select(item => item).OfType<Entry>().Count();
            }
        }


        public object this[object key]
        {
            get
            {
                if (!Contains(key))
                {
                    throw new Exception();
                }
                object result;
                TryGet(key, out result);
                return result;
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
            value = list.Single(item => item != null && item.Key.Equals(key)).Data;
            return value != null ? true : false;
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
