using System;
using System.Collections;
using System.Collections.Generic;

namespace MyLinkedList
{
    public class LinkedList<T> : IEnumerable<T>
    {
        private ListNode<T> head;
        private ListNode<T> current;
        private ListNode<T> counter;

        public int Length { get; private set; }
        private ListNode<T> Counter
        {
            get
            {
                if(counter == null)
                {
                    return head.Next;
                }
                return counter;
            }
            set
            {
                counter = value;
            }
        }
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
            //var currentValueAtPosition = head.ElementAt(position);
            var prevValue = currentValueAtPosition.Prev;
            var newValue = new ListNode<T>(value, prevValue, currentValueAtPosition);
            prevValue.Next = newValue;
            currentValueAtPosition.Prev = newValue;
            Length++;
        }

        public void Remove(T value)
        {
            for(int index = 0; index <= Length; index++)
            {
                var currentElement = ElementAt(index);
                //var currentElement = head.ElementAt(index);
                if (currentElement.Value.Equals(value))
                {
                    DeleteElement(index, currentElement);
                    return;
                }
            }
        }

        public void RemoveAt(int position)
        {
            var currentValueAtPosition = ElementAt(position);
            //var currentValueAtPosition = head.ElementAt(position);
            DeleteElement(position, currentValueAtPosition);
        }

        private void DeleteElement(int position, ListNode<T> element)
        {
            if (position < 0 || position > Length) throw new IndexOutOfRangeException();
            if (position == 0)
            {
                head = head.Next;
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

        //public T ElementAt(int position)
        //{
        //    if (position < 1 || position > Length) throw new IndexOutOfRangeException();
        //    return head.ElementAt(position).Value;
        //}

        public ListNode<T> ElementAt(int position)
        {
            if (position < 0 || position > Length) throw new IndexOutOfRangeException();
            ListNode<T> result;
            //if (position == 1) result = this;
            if (position == 0) result = Counter;
            else if (position < 0)
            {
                result = null;
            }
            else
            {
                Counter = Counter.Next;
                result = ElementAt(position - 1);
                //result = Next.ElementAt(position - 1);
            }
            return result;
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
