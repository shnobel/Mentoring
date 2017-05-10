namespace MyLinkedList
{
    public class ListNode<T>
    {
        private T value;
        private ListNode<T> next;
        private ListNode<T> prev;

        public ListNode(T value, ListNode<T> next, ListNode<T> prev)
        {
            this.value = value;
            this.next = next;
            this.prev = prev;
        }

        public T Value { get { return value; } set { } }
        public ListNode<T> Next { get { return next; } set { next = value; } }
        public ListNode<T> Prev { get { return prev; } set { prev = value; } }

        public ListNode(T value) : this(value, null, null){}

        public ListNode<T> ElementAt(int position)
        {
            ListNode<T> result;
            if (position == 1) result = this;
            else if (position < 1 )//|| next == null)
            {
                result = null;
            }
            else
            {
                result = next.ElementAt(position - 1);
            }
            return result;
        }

    }
}
