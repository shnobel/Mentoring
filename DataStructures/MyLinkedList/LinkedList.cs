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

        public LinkedList()
        {
            head = null;
            length = 0;
        }

        public int Length
        {
            get
            {
                if(length != 0)
                {
                    return length;
                }
                return 0;
            }
        }

        public void Add(T value)
        {
            var listNode = new ListNode<T>(value);
            if (head == null)
            {
                head = listNode;
            }
            else
            {
                current.next = listNode;
                listNode.prev = current;
            }
            current = listNode;
            length++;
        }

        public void AddAt(T value, int position)
        {
            var newValue = new ListNode<T>(value);
            //TODO
            //if (head == null)
            //{
            //    head = newValue;
            //    return;
            //}
            var currentValueAtPosition = head.ElementAt(position);
            var prevValue = currentValueAtPosition.prev;
            prevValue.next = newValue;
            newValue.prev = prevValue;
            newValue.next = currentValueAtPosition;
            currentValueAtPosition.prev = newValue;
            length++;
        }

        public void Remove(T value)
        {
            var index = 1;
            while(index <= length)
            {
                var currentValueAtPosition = head.ElementAt(index);
                if (currentValueAtPosition.value.Equals(value))
                {
                    RemoveAt(index);
                }
                else index++;
            }
        }

        public void RemoveAt(int position)
        {
            if (position < 1 || position > length) throw new IndexOutOfRangeException();

            ListNode<T> currentValueAtPosition;
            ListNode<T> nextValue;

            if (position == 1)
            {
                nextValue = head.next;
                nextValue.prev = null;
                head = nextValue;
                length--;
            }
            else
            {
                currentValueAtPosition = head.ElementAt(position);
                ListNode<T> prevValue = currentValueAtPosition.prev;
                nextValue = currentValueAtPosition.next;
                prevValue.next = nextValue;
                nextValue.prev = prevValue;
                currentValueAtPosition.next = null;
                currentValueAtPosition.prev = null;
                length--;
            }
        }

        public T ElementAt(int position)
        {
            ListNode<T> element = head.ElementAt(position);
            return element != null ? element.value : throw new IndexOutOfRangeException();
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
