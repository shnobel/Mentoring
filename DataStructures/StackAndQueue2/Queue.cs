using System;

namespace StackAndQueue
{
    public class Queue<T>
    {
        private int _tail = 0;
        private int _head = 0;
        private T[] _queue; 

        public Queue(int capacity = 10)
        {
            _queue = new T[capacity];
        }

        public int Size
        {
            get{ return _queue.Length;}
        }

        public void Enqueue(T value)
        {
            if(_tail < _queue.Length)
            {
                _queue[_tail] = value;
                _tail++;
                return;
            }
            AddCapacity();
            _queue[_tail] = value;
            _tail++;
        }

        public T Dequeue()
        {
            if (_queue != null && _queue.Length > 0)
            {
                var result = _queue[_head];
                _head++;
                return result;
            }
            throw new InvalidOperationException();
        }

        public T Peek()
        {
            if (_queue != null && _queue.Length > 0)
            {
                return _queue[_head];
            }
            throw new InvalidOperationException();
        }

        private void AddCapacity(int index = 2)
        {
            var newQueue = new T[_queue.Length * index];
            _queue.CopyTo(newQueue, (long)_head);
            _queue = newQueue;
        }
    }
}
