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
                 return _stack.Count;
            }
        }

        public T Peek()
        {
             return _stack.First.Value;
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
            _stack.AddFirst(value);
        }
    }
}