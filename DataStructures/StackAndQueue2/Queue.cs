using System;
using System.Collections.Generic;

namespace StackAndQueue
{
    public class Queue<T>
    {
        private LinkedList<T> _queue; 

        public Queue()
        {
            _queue = new LinkedList<T>();
        }

        public int Size
        {
            get{ return _queue.Count;}
        }

        public void Enqueue(T value)
        {
            _queue.AddLast(value);
        }

        public T Dequeue()
        {
            if (_queue != null && _queue.Count > 0)
            {
                var result = _queue.First;
                _queue.Remove(result);
                return result.Value;
            }
            throw new InvalidOperationException();
        }

        public T Peek()
        {
            if (_queue != null && _queue.Count > 0)
            {
                return _queue.First.Value;
            }
            throw new InvalidOperationException();
        }
    }
}
