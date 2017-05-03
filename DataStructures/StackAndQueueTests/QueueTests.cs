using Microsoft.VisualStudio.TestTools.UnitTesting;
using StackAndQueue;
using System;

namespace StackAndQueueTests
{
    [TestClass]
    public class QueueTests
    {
        Queue<int> queue;
        [TestMethod]
        public void InitQueue()
        {
            queue = new Queue<int>(5);
            Assert.AreEqual(5, queue.Size);
        }

        [TestMethod]
        public void Enqueue()
        {
            queue = new Queue<int>(5);
            queue.Enqueue(10);
            Assert.AreEqual(10, queue.Peek());
        }

        [TestMethod]
        public void EnqueueTwice()
        {
            queue = new Queue<int>(5);
            queue.Enqueue(10);
            queue.Enqueue(20);
            Assert.AreEqual(10, queue.Dequeue());
            Assert.AreEqual(20, queue.Dequeue());
        }

        [TestMethod]
        public void AddCapacityToQueue()
        {
            queue = new Queue<int>(1);
            queue.Enqueue(10);
            queue.Enqueue(20);
            queue.Enqueue(30);
            queue.Enqueue(40);
            queue.Enqueue(50);
            queue.Enqueue(60);
            Assert.AreEqual(10, queue.Dequeue());
            Assert.AreEqual(20, queue.Dequeue());
        }

        [TestMethod]
        public void GetPeekQueue()
        {
            queue = new Queue<int>(1);
            queue.Enqueue(60);
            queue.Enqueue(50);
            Assert.AreEqual(60, queue.Dequeue());
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void DequeueEmptyQueue()
        {
            queue = new Queue<int>(0);
            queue.Dequeue();
        }
    }
}
