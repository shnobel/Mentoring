using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHashTable
{
    class Program
    {
        static void Main(string[] args)
        {
            var table = new HashTable();
            table.Add(1, "value1");
            table.Add(2, "value1");
            table.Add(3, "value1");
            table.Add(4, "value1");
            table.Add(1, "value100");
        }
    }
}
