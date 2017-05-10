using System;
using System.Collections;
using System.Collections.Generic;

namespace MyLinkedList
{
    public class LinkedList<T> : IEnumerable<T>
    {
        private ListNode<T> head;
        private ListNode<T> current;
        private int length;

        public int Length { get { return length; } }

        public void Add(T value)
        {
            var listNode = new ListNode<T>(value, null, current);
            if (head == null)
            {
                head = listNode;
            }
            else
            {
                current.Next = listNode;
                //listNode.Prev = current;
            }
            current = listNode;
            length++;
        }

        public void AddAt(T value, int position)
        {
            if (position >= Length || position < 1) throw new IndexOutOfRangeException();

            var newValue = new ListNode<T>(value);
            var currentValueAtPosition = head.ElementAt(position);
            var prevValue = currentValueAtPosition.Prev;
            prevValue.Next = newValue;
            newValue.Prev = prevValue;
            newValue.Next = currentValueAtPosition;
            currentValueAtPosition.Prev = newValue;
            length++;
        }

        public void Remove(T value)
        {
            //var index = 1;
            for(int index = 1; index <= length; index++)
            //while(index <= length)
            {
                if(head.ElementAt(index).Value.Equals(value))
                //var currentValueAtPosition = head.ElementAt(index);
                //if (currentValueAtPosition.Value.Equals(value))
                {
                    RemoveAt(index);
                    return;
                }
                //else index++;
            }
        }

        public void RemoveAt(int position)
        {
            if (position < 1 || position > length) throw new IndexOutOfRangeException();

            ListNode<T> currentValueAtPosition;
            ListNode<T> nextValue;

            if (position == 1)
            {
                nextValue = head.Next;
                nextValue.Prev = null;
                head = nextValue;
            }
            else
            {
                currentValueAtPosition = head.ElementAt(position);
                var prevValue = currentValueAtPosition.Prev;
                nextValue = currentValueAtPosition.Next;
                prevValue.Next = nextValue;
                nextValue.Prev = prevValue;
                //currentValueAtPosition.Next = null;
                //currentValueAtPosition.Prev = null;
            }
            length--;
        }

        public T ElementAt(int position)
        {
            if (position < 1 || position > length) throw new IndexOutOfRangeException();

            //ListNode<T> element = head.ElementAt(position);
            return head.ElementAt(position).Value;//element != null ? element.Value : throw new IndexOutOfRangeException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return null;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
