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
            //arrange
            table = new HashTable<int, string>(20);
            //act
            var size = table.Size;
            //assert
            Assert.IsTrue(size.Equals(20));
        }

        [TestMethod]
        public void AddElementToHashTable_ShouldAddElementToHashTable_WhenValueNotNull()
        {
            //arrange
            table = new HashTable<int, string>(20);
            //act
            table.Add(1, "test");
            //assert
            Assert.IsTrue(table[1].Equals("test"));
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TryToAddElementToHashTable_ShouldThrowException_WhenValueIsNull()
        {
            //arrange
            table = new HashTable<int, string>(20);
            //act
            table.Add(1, null);
            // assert is handled by the ExpectedException 
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TryToAddElementToHashTable_ShouldThrowException_WhenHashTableContainsKey()
        {
            //arrange
            table = new HashTable<int, string>(20);
            //act
            table.Add(1, "test");
            table.Add(1, "test2");
            // assert is handled by the ExpectedException 
        }

        [TestMethod]
        public void VerifyContainsElementByKey_ShouldReturnTrue_WhenHashTableContainsKey()
        {
            //arrange
            table = new HashTable<int, string>(20);
            //act
            table.Add(1, "test");
            table.Add(2, "test2");
            //assert
            Assert.IsTrue(table.Contains(1));
            Assert.IsTrue(table.Contains(2));
        }

        [TestMethod]
        public void VerifyContainsElementByKey_ShouldReturnFalse_WhenHashTableDoesnotContainKey()
        {
            //arrange
            table = new HashTable<int, string>(20);
            //act
            table.Add(1, "test");
            table.Add(2, "test2");
            //assert
            Assert.IsFalse(table.Contains(100));
        }

        [TestMethod]
        public void TryGetElement_ShouldReturnTrueAndElement_WhenValueNotNullAndPresent()
        {
            //arrange
            table = new HashTable<int, string>(20);
            object result = null;
            //act
            table.Add(1, "test");
            //assert
            Assert.IsTrue(table.TryGet(1, out result));
            Assert.IsTrue(result.Equals("test"));
        }

        [TestMethod]
        public void TryGetElement_ShouldReturnTrueAndElement_WhenValueNotNullAndPresent_Negative()
        {
            //arrange
            table = new HashTable<int, string>(20);
            object result = null;
            //act
            table.Add(1, "test");
            //assert
            Assert.IsFalse(table.TryGet(2, out result));
            Assert.IsTrue(result == null);
        }
    }
}
