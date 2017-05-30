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
                throw new ArgumentException($"Table doesn't contain a key {key}");
            }
            set
            {
                var bucket = GetBucket(key);
                if (bucket.Count != 0)
                {
                    if(value == null)
                    {
                        bucket.Remove(bucket.Single(item => item.Key.Equals(key)));
                        Size--;
                        return;
                    }
                    var entry = bucket.Single(item => item.Key.Equals(key));
                    entry.Data = value;
                    return;
                }

                else
                {
                    if (value == null)
                    {
                        return;
                    }
                    AddEntry(bucket, new Entry(key, value));
                    Size++;
                }
            }
        }

        public void Add(object key, object value)
        {
            var bucket = GetBucket(key);
            if(bucket.Any(item => item.Key.Equals(key)) || value == null)
            {
                throw new Exception();
            }
            AddEntry(bucket, new Entry(key, value));
            Size++;
        }
        
        public bool Contains(object key)
        {
            var bucket = GetBucket(key);
            return bucket.Any(item => item.Key.Equals(key));
        }

        public bool TryGet(object key, out object value)
        {
            var bucket = GetBucket(key);
            if (bucket.Count == 0)
            {
                value = null;
                return false;
            }
            value = bucket.Single(item => item.Key.Equals(key)).Data;
            return value != null ? true : false;
        }

        private int GetBucketIndex(object obj)
        {
            int index = Math.Abs(200 * GetHashCode(obj, buckets.Length) + 17) % 1232432453 % (buckets.Length-1);
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

        private LinkedList<Entry> GetBucket(object key)
        {
            int index = GetBucketIndex(key);
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
            var entriesToMove = buckets.Where(bucket => bucket != null && bucket.Count != 0 ).SelectMany(item => item);
            buckets = new LinkedList<Entry>[buckets.Length * 2];
            foreach(var entry in entriesToMove)
            {
                Add(entry.Key, entry.Data);
            }
        }

        private void AddEntry(LinkedList<Entry> bucket, Entry entry)
        {
            bucket.AddLast(entry);
            Resize();
        }
    }
}