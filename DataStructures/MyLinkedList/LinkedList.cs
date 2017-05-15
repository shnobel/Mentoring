using System;
using System.Collections;
using System.Collections.Generic;

namespace MyLinkedList
{
    public class LinkedList<T> : IEnumerable<T>
    {
        private ListNode<T> head;
        private ListNode<T> current;

        public int Length { get; private set; }

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

            var currentValueAtPosition = head.ElementAt(position);
            var prevValue = currentValueAtPosition.Prev;
            var newValue = new ListNode<T>(value, prevValue, currentValueAtPosition);
            prevValue.Next = newValue;
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

           
            if (position == 1)
            {
                head = head.Next;
            }
            else
            {
                var currentValueAtPosition = head.ElementAt(position);
                var prevValue = currentValueAtPosition.Prev;
                var nextValue = currentValueAtPosition.Next;
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
