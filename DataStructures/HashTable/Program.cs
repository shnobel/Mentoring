using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable
{
    class Program
    {
        static void Main(string[] args)
        {
            var table = new HashTable<int, string>(10);
            table.Add(1, "Ara");
            table.Add(200, "Ara");
            table.Add(200, "Ara");
            table.Add(700, "Ara");
            table.Add(1000, "Ara");
            table.Add(-1, "Ara");
            table.Add(-1300, "Ara");
            table.Add(23904293, "Ara");
            table.Add(10293912, "Ara");
            table.Add(54065, "Ara");
            table.Add(1289312, "Ara");
        }
    }
}
