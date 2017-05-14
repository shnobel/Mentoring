using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataStructures;

namespace StackAndQueueTests
{
    [TestClass]
    public class StackTests
    {
        Stack<int> stack;

        [TestMethod]
        public void InitStack_ShouldInitialiseEqmptyStackWithCorrectSize()
        {
            //arrange
            stack = new Stack<int>();
            //act and assert
            Assert.AreEqual(0, stack.Size);
        }

        [TestMethod]
        public void PushStack_ShouldAddValueToTheStack()
        {
            //arrange
            stack = new Stack<int>();
            //act
            stack.Push(10);
            //assert
            Assert.AreEqual(1, stack.Size);
        }

        [TestMethod]
        public void PushTwiceStack_ShouldAddTwoValuesToTheStack()
        {
            //arrange
            stack = new Stack<int>();
            //act
            stack.Push(10);
            stack.Push(20);
            //assert
            Assert.AreEqual(2, stack.Size);
        }

        [TestMethod]
        public void PopStack_ShouldReturnCorrectValue_WhenWasCalledPopMethod()
        {
            //arrange
            stack = new Stack<int>();
            var valueToPush = 10;
            //act
            stack.Push(valueToPush);
            //assert
            Assert.AreEqual(valueToPush, stack.Pop());
        }

        [TestMethod]
        public void PopTwiceStack__ShouldReturnCorrectValues_WhenWasCalledPopMethod()
        {
            //arrange
            stack = new Stack<int>();
            var valueToPush = 10;
            var secondValueToPush = 20;
            //act
            stack.Push(valueToPush);
            stack.Push(secondValueToPush);
            stack.Pop();
            //assert
            Assert.AreEqual(valueToPush, stack.Pop());
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void PopFromEmptyStack_ShouldThrowException_WhenWasCalledPopForEmptyStack()
        {
            //arrange
            stack = new Stack<int>();
            //act
            stack.Pop();
            // assert is handled by the ExpectedException 
        }
    }
}
