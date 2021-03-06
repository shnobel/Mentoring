﻿using System;
using System.Collections.Generic;

namespace DataStructures
{
    public class Stack<T> 
    {
        private List<T> _stack  { get; set; }

        public Stack()
        {
            _stack = new List<T>();
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
            if (_stack != null && _stack[0] != null)
            {
                return _stack[0];
            }
            throw new InvalidOperationException();
        }

        public T Pop()
        {
            if (_stack != null && _stack[0] != null)
            {
                var result = _stack[0];
                _stack.Remove(result);
                return result;
            }
            throw new InvalidOperationException();
        }

        public void Push(T value)
        {
            if (_stack != null)
            {
                _stack.Add(value);
            }
        }
    }
}