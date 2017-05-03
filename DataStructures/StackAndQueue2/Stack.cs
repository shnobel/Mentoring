using System;
using System.Collections.Generic;

namespace DataStructures
{
    public class Stack<T> 
    {
        private LinkedList<T> _stack  { get; set; }

        public Stack()
        {
            _stack = new LinkedList<T>();
        }

        public int Size
        {
            get
            {
                if (_stack != null)
                {
                    return _stack.Count;
                }
                throw new InvalidOperationException();
            }
        }

        public T Peek()
        {
            if (_stack != null && _stack.First != null)
            {
                return _stack.First.Value;
            }
            throw new InvalidOperationException();
        }

        public T Pop()
        {
            if (_stack != null && _stack.First != null)
            {
                var result = _stack.First.Value;
                _stack.Remove(result);
                return result;
            }
            throw new InvalidOperationException();
        }

        public void Push(T value)
        {
            if (_stack != null)
            {
                _stack.AddFirst(value);
            }
        }
    }
}