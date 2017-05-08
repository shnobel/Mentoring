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
        public void InitQueue_ShouldInitialiseEqmptyQueueWithCorrectSize()
        {
            queue = new Queue<int>();
            Assert.AreEqual(0, queue.Size);
        }

        [TestMethod]
        public void Enqueue_ShouldAddElementIntoQueue_WhenCorrectValuePassed()
        {
            queue = new Queue<int>();
            queue.Enqueue(10);
            Assert.AreEqual(10, queue.Peek());
        }

        [TestMethod]
        public void EnqueueTwice_ShouldAddElementIntoQueue2Times_WhenCorrectValuePassed()
        {
            queue = new Queue<int>();
            queue.Enqueue(10);
            queue.Enqueue(20);
            Assert.AreEqual(10, queue.Dequeue());
            Assert.AreEqual(20, queue.Dequeue());
        }

        [TestMethod]
        public void AddCapacityToQueue_ShouldVerifySizeOfQueue_WhenWasCalledEnqueueAndDequeueMethods()
        {
            queue = new Queue<int>();
            queue.Enqueue(10);
            queue.Enqueue(20);
            queue.Enqueue(30);
            queue.Enqueue(40);
            queue.Enqueue(50);
            queue.Enqueue(60);
            Assert.AreEqual(10, queue.Dequeue());
            Assert.AreEqual(20, queue.Dequeue());
            Assert.AreEqual(4, queue.Size);
        }

        [TestMethod]
        public void GetPeekQueue_ShouldReturnPeekValueOfTheQueue_WhenWasAddedFewValues()
        {
            queue = new Queue<int>();
            queue.Enqueue(60);
            queue.Enqueue(50);
            Assert.AreEqual(60, queue.Dequeue());
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void DequeueEmptyQueue_ShouldThrowException_WhenQueueIsEmpty()
        {
            queue = new Queue<int>();
            queue.Dequeue();
        }
    }
}
