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
        public void InitStack()
        {
            stack = new Stack<int>();
            Assert.AreEqual(0, stack.Size);
        }

        [TestMethod]
        public void PushStack()
        {
            stack = new Stack<int>();
            stack.Push(10);
            Assert.AreEqual(1, stack.Size);
        }

        [TestMethod]
        public void PushTwiceStack()
        {
            stack = new Stack<int>();
            stack.Push(10);
            stack.Push(20);
            Assert.AreEqual(2, stack.Size);
        }

        [TestMethod]
        public void PopStack()
        {
            stack = new Stack<int>();
            var valueToPush = 10;
            stack.Push(valueToPush);
            Assert.AreEqual(valueToPush, stack.Pop());
        }

        [TestMethod]
        public void PopTwiceStack()
        {
            stack = new Stack<int>();
            var valueToPush = 10;
            var secondValueToPush = 20;
            stack.Push(valueToPush);
            stack.Push(secondValueToPush);
            stack.Pop();
            Assert.AreEqual(valueToPush, stack.Pop());
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void PopFromEmptyStack()
        {
            stack = new Stack<int>();
            stack.Pop();
        }
    }
}
