using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable
{
    public class HashTable<Tkey, TValue> : IHashTable
    {
        LinkedList<Entry<Tkey, TValue>> list;

        public HashTable()
        {
            list = new LinkedList<Entry<Tkey, TValue>>();
        }


        public object this[object key] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Add(object key, object value)
        {
            var entry = new Entry<object, object>(key, value);
            
            //Compute the keys hash code
            var hash = key.GetHashCode();
            //Compress it to determine bucket
            //Insert the entry(key, value) into bucket's chain
        }

        public bool Contains(object key)
        {
            return true;
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

        //public override int GetHashCode()
        //{
        //    unchecked 
        //    {
        //        int hash = 17;
        //        hash = hash * 23 + field1.GetHashCode();
        //        hash = hash * 23 + field2.GetHashCode();
        //        hash = hash * 23 + field3.GetHashCode();
        //        return hash;
        //    }
        //}
    }
}
