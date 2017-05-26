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
            if (position >= Length || position < 0) throw new IndexOutOfRangeException();

            var currentValueAtPosition = ElementAt(position);
            var prevValue = currentValueAtPosition.Prev;
            var newValue = new ListNode<T>(value, prevValue, currentValueAtPosition);
            prevValue.Next = newValue;
            currentValueAtPosition.Prev = newValue;
            Length++;
        }

        public void Remove(T value)
        {
            var currentElement = head;
            for (int index = 0; index <= Length; index++)
            {
                if (currentElement.Value.Equals(value))
                {
                    DeleteElement(currentElement);
                    return;
                }
                currentElement = currentElement.Next;
            }
        }

        public void RemoveAt(int position)
        {
            var currentValueAtPosition = ElementAt(position);
            DeleteElement(currentValueAtPosition);
        }

        private void DeleteElement(ListNode<T> element)
        {
            if (element.Prev == null)
            {
                head = head.Next;
            }

            if (element.Next == null)
            {
                current = element.Prev;
                current.Next = null;
            }

            else
            {
                var prevValue = element.Prev;
                var nextValue = element.Next;
                prevValue.Next = nextValue;
                nextValue.Prev = prevValue;
            }
            Length--;
        }

        public ListNode<T> ElementAt(int position)
        {
            if (position < 0 || position > Length || head == null) throw new IndexOutOfRangeException();
            return ElementAt(position, head);
        }

        private ListNode<T> ElementAt(int position, ListNode<T> headValue)
        {
            return position == 0 ? headValue : ElementAt(position - 1, headValue.Next);
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
