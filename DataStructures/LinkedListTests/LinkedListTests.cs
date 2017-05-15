using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyLinkedList;

namespace LinkedListTests
{
    [TestClass]
    public class LinkedListTests
    {
        LinkedList<int> list;
        [TestMethod]
        public void InitLinkedList_ShouldInitializeEmptyLinkedList()
        {
            //arrange 
            var newList = new LinkedList<int>();
            //act
            var length = newList.Length;
            //assert
            Assert.IsTrue(length.Equals(0));
        }

        [TestMethod]
        public void AddValueToList_ShouldAddValueToTheList()
        {
            //arrange 
            list = new LinkedList<int>();
            //act
            list.Add(19);
            //assert
            Assert.IsTrue(list.Length.Equals(1));
            Assert.IsTrue(list.ElementAt(1).Equals(19));
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void GetValueFromList_ShouldThrowException_WhenIndexOutOfRange()
        {
            //arrange
            list = new LinkedList<int>();
            //act
            list.Add(19);
            list.ElementAt(-1);
            // assert is handled by the ExpectedException 
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void GetValueFromEmptyList_ShouldThrowException_WhenEmptyList()
        {
            //arrange
            list = new LinkedList<int>();
            //act
            list.ElementAt(1);
            // assert is handled by the ExpectedException 
        }

        [TestMethod]
        public void AddElementInSpecificPosition_ShouldAddElementIntoIndexPosition()
        {
            //arrange
            list = new LinkedList<int>();
            //act
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.AddAt(5, 2);
            //assert
            Assert.IsTrue(list.ElementAt(2).Equals(5));
        }

        [TestMethod]
        public void RemoveElementByValue_ShouldRemoveElementFromListByValue()
        {
            //arrange
            list = new LinkedList<int>();
            int valueToRemove = 100;
            //act
            list.Add(1);
            list.Add(valueToRemove);
            list.Add(3);
            list.Add(4);
            list.Remove(valueToRemove);
            //assert
            Assert.AreNotEqual(list.ElementAt(2), valueToRemove);
            Assert.IsTrue(list.Length.Equals(3));
        }

        [TestMethod]
        public void RemoveElementByIndex_ShouldRemoveElementFromListByIndex_WhenPassedCorrectIndex()
        {
            //arrange
            list = new LinkedList<int>();
            int index = 2;
            int valueToVerify = 100;
            //act
            list.Add(1);
            list.Add(valueToVerify);
            list.Add(3);
            list.Add(4);
            list.RemoveAt(index);
            //assert
            Assert.AreNotEqual(list.ElementAt(2),valueToVerify);
            Assert.IsTrue(list.Length.Equals(3));
        }
    }
}
