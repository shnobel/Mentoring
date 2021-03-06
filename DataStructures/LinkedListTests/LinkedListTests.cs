﻿using System;
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
        public void Add_ShouldAddValueToTheList()
        {
            //arrange 
            list = new LinkedList<int>();
            //act
            list.Add(19);
            //assert
            Assert.IsTrue(list.Length.Equals(1));
            Assert.AreEqual(list.ElementAt(0).Value, 19);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void Get_ShouldThrowException_WhenIndexOutOfRange()
        {
            //arrange
            list = new LinkedList<int>();
            list.Add(19);

            //act & assert
            list.ElementAt(-1);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void GetValueFromEmptyList_ShouldThrowException_WhenEmptyList()
        {
            //arrange
            list = new LinkedList<int>();
            //act & assert
            list.ElementAt(0);
        }

        [TestMethod]
        public void AddElementInSpecificPosition_ShouldAddElementIntoIndexPosition()
        {
            //arrange
            list = new LinkedList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            //act
            list.AddAt(5, 2);
            list.AddAt(6, 2);
            list.AddAt(7, 2);
            list.AddAt(8, 2);
            //assert
            Assert.AreEqual(list.ElementAt(2).Value, 8);
        }

        [TestMethod]
        public void RemoveElementByValue_ShouldRemoveElementFromListByValue()
        {
            //arrange
            list = new LinkedList<int>();
            int valueToRemove = 100;
            list.Add(1);
            list.Add(valueToRemove);
            list.Add(3);
            list.Add(4);
            //act
            list.Remove(valueToRemove);
            //assert
            Assert.AreNotEqual(list.ElementAt(2).Value, valueToRemove);
            Assert.IsTrue(list.Length.Equals(3));
        }

        [TestMethod]
        public void RemoveElementByIndex_ShouldRemoveElementFromListByIndex_WhenPassedCorrectIndex()
        {
            //arrange
            list = new LinkedList<int>();
            int index = 2;
            int valueToVerify = 100;
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            //act
            list.RemoveAt(3);
            list.Add(1);
            //assert
            Assert.AreNotEqual(list.ElementAt(2).Value, valueToVerify);
            Assert.IsTrue(list.Length.Equals(4));
        }
    }
}
