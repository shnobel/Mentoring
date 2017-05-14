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

        public int Length { get { return length; } private set { length = value; }}

        public void Add(T value)
        {
            var listNode = new ListNode<T>(value, current, null);
            if (head == null)
            {
                head = listNode;
            }
            else
            {
                current.Next = listNode;
            }
            current = listNode;
            Length++;
        }

        public void AddAt(T value, int position)
        {
            if (position >= Length || position < 1) throw new IndexOutOfRangeException();

            var newValue = new ListNode<T>(value, current.Prev, current.Next);
            var currentValueAtPosition = head.ElementAt(position);
            var prevValue = currentValueAtPosition.Prev;
            prevValue.Next = newValue;
            newValue.Prev = prevValue;
            newValue.Next = currentValueAtPosition;
            currentValueAtPosition.Prev = newValue;
            Length++;
        }

        public void Remove(T value)
        {
            for(int index = 1; index <= Length; index++)
            {
                if(head.ElementAt(index).Value.Equals(value))
                {
                    RemoveAt(index);
                    return;
                }
            }
        }

        public void RemoveAt(int position)
        {
            if (position < 1 || position > Length) throw new IndexOutOfRangeException();

            ListNode<T> currentValueAtPosition;
            ListNode<T> nextValue;

            if (position == 1)
            {
                head = head.Next;
            }
            else
            {
                currentValueAtPosition = head.ElementAt(position);
                var prevValue = currentValueAtPosition.Prev;
                nextValue = currentValueAtPosition.Next;
                prevValue.Next = nextValue;
                nextValue.Prev = prevValue;
            }
            Length--;
        }

        public T ElementAt(int position)
        {
            if (position < 1 || position > Length) throw new IndexOutOfRangeException();
            return head.ElementAt(position).Value;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var element = head;
            while (element != null)
            {
                yield return element.Value;
                element = element.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
