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
            Assert.IsTrue(new LinkedList<int>().Length.Equals(0));
        }

        [TestMethod]
        public void AddValueToList_ShouldAddValueToTheList()
        {
            list = new LinkedList<int>();
            var valueToAdd = 19;
            list.Add(valueToAdd);
            Assert.IsTrue(list.Length.Equals(1));
            Assert.IsTrue(list.ElementAt(1).Equals(valueToAdd));
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void GetValueFromList_ShouldThrowException_WhenIndexOutOfRange()
        {
            list = new LinkedList<int>();
            var valueToAdd = 19;
            list.Add(valueToAdd);
            list.ElementAt(-1);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void GetValueFromEmptyList_ShouldThrowException_WhenEmptyList()
        {
            list = new LinkedList<int>();
            list.ElementAt(1);
        }

        [TestMethod]
        public void AddElementInSpecificPosition_ShouldAddElementIntoIndexPosition()
        {
            list = new LinkedList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.AddAt(5, 2);
            Assert.IsTrue(list.ElementAt(2).Equals(5));
        }

        [TestMethod]
        public void RemoveElementByValue_ShouldRemoveElementFromListByValue()
        {
            list = new LinkedList<int>();
            int valueToRemove = 100;
            list.Add(1);
            list.Add(valueToRemove);
            list.Add(3);
            list.Add(4);
            list.Remove(valueToRemove);
            Assert.IsTrue(!list.ElementAt(2).Equals(valueToRemove));
            Assert.IsTrue(list.Length.Equals(3));
        }

        [TestMethod]
        public void RemoveElementByIndex_ShouldRemoveElementFromListByIndex_WhenPassedCorrectIndex()
        {
            list = new LinkedList<int>();
            int index = 2;
            int valueToVerify = 100;
            list.Add(1);
            list.Add(valueToVerify);
            list.Add(3);
            list.Add(4);
            list.RemoveAt(2);
            Assert.IsTrue(!list.ElementAt(2).Equals(valueToVerify));
            Assert.IsTrue(list.Length.Equals(3));
        }
    }
}
