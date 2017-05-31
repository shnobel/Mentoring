using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MyHashTable;

namespace HashTableTests
{
    [TestClass]
    public class HashTableTests
    {
        HashTable table;

        [TestMethod]
        public void Init_ShouldInitHashTableWithFixedSize()
        {
            //arrange
            table = new HashTable();
            //act
            var size = table.Size;
            //assert
            Assert.IsTrue(size.Equals(0));
        }

        [TestMethod]
        public void Add_ShouldAddElementToHashTable_WhenValueNotNull()
        {
            //arrange
            table = new HashTable();
            //act
            table.Add(1, "test");
            table.Add(2, "test");
            //assert
            Assert.IsTrue(table[2].Equals("test"));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Set_ShouldRemoveElementFromHashTable_WhenValueNullAndContainsKey()
        {
            //arrange
            table = new HashTable();
            //act
            table.Add(1, "test");
            table.Add(2, "test");
            table[1] = null;
            //assert is handled by the ExpectedException 
            var value = table[1];
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Add_ShouldThrowException_WhenValueIsNull()
        {
            //arrange
            table = new HashTable();
            //act
            table.Add(1, null);
            // assert is handled by the ExpectedException 
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Add_ShouldThrowException_WhenHashTableContainsKey()
        {
            //arrange
            table = new HashTable();
            //act
            table.Add(1, "test");
            table.Add(1, "test2");
            // assert is handled by the ExpectedException 
        }

        [TestMethod]
        public void Contains_ShouldReturnTrue_WhenHashTableContainsKey()
        {
            //arrange
            table = new HashTable();
            //act
            table.Add(1, "test");
            table.Add(2, "test2");
            //assert
            Assert.IsTrue(table.Contains(1));
            Assert.IsTrue(table.Contains(2));
        }

        [TestMethod]
        public void Contains_ShouldReturnFalse_WhenHashTableDoesnotContainKey()
        {
            //arrange
            table = new HashTable();
            //act
            table.Add(1, "test");
            table.Add(2, "test2");
            //assert
            Assert.IsFalse(table.Contains(100));
        }

        [TestMethod]
        public void TryGet_ShouldReturnTrueAndElement_WhenValueNotNullAndPresent()
        {
            //arrange
            table = new HashTable();
            object result = null;
            //act
            table.Add(1, "test");
            //assert
            Assert.IsTrue(table.TryGet(1, out result));
            Assert.IsTrue(result.Equals("test"));
        }

        [TestMethod]
        public void TryGet_ShouldReturnTrueAndElement_WhenValueNotNullAndPresent_Negative()
        {
            //arrange
            table = new HashTable();
            object result = null;
            //act
            table.Add(1, "test");
            //assert
            Assert.IsFalse(table.TryGet(2, out result));
            Assert.IsTrue(result == null);
        }
    }
}
