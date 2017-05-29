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
                throw new ArgumentException();
            }
            set
            {
                var index = GetBucketIndex(key);
                var bucket = GetBucket(index);
                if (Contains(key) && value == null)
                {
                    bucket.Remove(bucket.Single(item => item.Key.Equals(key)));
                    return;
                }

                if (Contains(key) && value != null)
                {
                    var entry = bucket.Single(item => item.Key.Equals(key));
                    entry.Data = value;
                    return;
                }

                if (value == null)
                {
                    return;
                }

                else
                {
                    AddEntry(index, bucket, new Entry(key, value));
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
            AddEntry(index, bucket, new Entry(key, value));
        }
        
        public bool Contains(object key)
        {
            var bucket = GetBucket(GetBucketIndex(key));
            return bucket.Any(item => item.Key.Equals(key));
        }

        public bool TryGet(object key, out object value)
        {
            if (!Contains(key))
            {
                value = null;
                return false;
            }
            var bucket = GetBucket(GetBucketIndex(key));
            value = bucket.Single(item => item.Key.Equals(key)).Data;
            return value != null ? true : false;
        }

        private int GetBucketIndex(object obj)
        {
            int index = GetHashCode(obj, buckets.Length) % buckets.Length-1;
            return index < 0 ? index * -1 : index;
        }

        private int GetHashCode(object obj, int length)
        {
            unchecked 
            {
                int hash = 17;
                hash = hash * 23 + obj.GetHashCode();
                hash = hash * 23 + length.GetHashCode();
                return hash;
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

        private void AddEntry(int index, LinkedList<Entry> bucket, Entry entry)
        {
            bucket.AddLast(entry);
            Size++;
            Resize();
        }
    }
}