﻿using System;
using System.Linq;

namespace HashTable
{
    public class HashTable<TKey, TValue> : IHashTable
    {
        Entry<TKey, TValue>[] list;

        public HashTable(int size)
        {
            list = new Entry<TKey, TValue>[size];
        }

        public int Size
        {
            get
            {
                return list.Length;
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
                object result = null;
                foreach(var item in list)
                {
                    if (result != null) return result;
                    if (item == null)
                    {
                        continue;
                    }
                    result = item.GetValue();
                }
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
                if (result) return result;
                try
                {
                    result = item.Getkey().Equals(key);
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
            try
            {
                value = this[key];
                return true;
            }
            catch(Exception e)
            {
                value = null;
                return false;
            }
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