using System;
using System.Collections.Generic;
using System.Linq;

namespace MyHashTable
{
    public class HashTable : IHashTable
    {
        private LinkedList<Entry>[] buckets;
        private const double LoadFactor = 0.95;

        public HashTable()
        {
            buckets = new LinkedList<Entry>[10];
        }

        public int Size { get; private set; }

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
            var index = GetBucketIndex(key);
            var bucket = GetBucket(index);
            if(bucket.Any(item => item.Key.Equals(key)) || value == null)
            {
                throw new Exception();
            }

            var entry = new Entry(key, value);
            bucket.AddLast(entry);
            Size++;
            Resize();
        }

        public bool Contains(object key)
        {
            var index = GetBucketIndex(key);
            var bucket = GetBucket(index);
            return bucket.Any(item => item!=null && item.Key.Equals(key));
        }

        public bool TryGet(object key, out object value)
        {
            if (!Contains(key))
            {
                value = null;
                return false;
            }
            var bucket = GetBucket(GetBucketIndex(key));
            value = bucket.Single(item => item != null && item.Key.Equals(key)).Data;
            return value != null ? true : false;
        }

        public int GetBucketIndex(object obj)
        {
            int index = GetHashCode(obj) % buckets.Length;
            return index < 0 ? index * -1 : index;
        }

        private int GetHashCode(object obj)
        {
            unchecked // Overflow is fine, just wrap
            {
                int hash = 17;
                return hash * 23 + obj.GetHashCode();
            }
        }

        private LinkedList<Entry> GetBucket(int index)
        {
            if (buckets[index] == null)
            {
                buckets[index] = new LinkedList<Entry>();
            }
            return buckets[index];
        }

        private void Resize()
        {
            if(Size/buckets.Length < LoadFactor)
            {
                return;
            }
            Array.Resize(ref buckets, buckets.Length * 2);
        }
    }
}