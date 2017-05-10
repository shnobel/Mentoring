using Microsoft.VisualStudio.TestTools.UnitTesting;
using HashTable;
using System;

namespace HashTableTests
{
    [TestClass]
    public class HashTableTests
    {
        HashTable<int, string> table;

        [TestMethod]
        public void InitHashTable_ShouldInitHashTableWithFixedSize()
        {
            table = new HashTable<int, string>(20);
            Assert.IsTrue(table.Size.Equals(20));
        }

        [TestMethod]
        public void AddElementToHashTable_ShouldAddElementToHashTable_WhenValueNotNull()
        {
            table = new HashTable<int, string>(20);
            table.Add(1, "test");
            Assert.IsTrue(table[1].Equals("test"));
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TryToAddElementToHashTable_ShouldThrowException_WhenValueIsNull()
        {
            table = new HashTable<int, string>(20);
            table.Add(1, null);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TryToAddElementToHashTable_ShouldThrowException_WhenHashTableContainsKey()
        {
            table = new HashTable<int, string>(20);
            table.Add(1, "test");
            table.Add(1, "test2");
        }

        [TestMethod]
        public void VerifyContainsElementByKey_ShouldReturnTrue_WhenHashTableContainsKey()
        {
            table = new HashTable<int, string>(20);
            table.Add(1, "test");
            table.Add(2, "test2");
            Assert.IsTrue(table.Contains(1));
            Assert.IsTrue(table.Contains(2));
        }

        [TestMethod]
        public void VerifyContainsElementByKey_ShouldReturnFalse_WhenHashTableDoesnotContainKey()
        {
            table = new HashTable<int, string>(20);
            table.Add(1, "test");
            table.Add(2, "test2");
            Assert.IsFalse(table.Contains(100));
        }

        [TestMethod]
        public void TryGetElement_ShouldReturnTrueAndElement_WhenValueNotNullAndPresent()
        {
            table = new HashTable<int, string>(20);
            table.Add(1, "test");
            object result=null;
            Assert.IsTrue(table.TryGet(1, out result));
            Assert.IsTrue(result.Equals("test"));
        }

        [TestMethod]
        public void TryGetElement_ShouldReturnTrueAndElement_WhenValueNotNullAndPresent_Negative()
        {
            table = new HashTable<int, string>(20);
            table.Add(1, "test");
            object result = null;
            Assert.IsFalse(table.TryGet(2, out result));
            Assert.IsTrue(result == null);
        }
    }
}
