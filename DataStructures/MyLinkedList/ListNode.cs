namespace MyLinkedList
{
    public class ListNode<T>
    {
        public T value;
        public ListNode<T> next;
        public ListNode<T> prev;

        public ListNode(T value, ListNode<T> next, ListNode<T> prev)
        {
            this.value = value;
            this.next = next;
            this.prev = prev;
        }

        public ListNode(T value) : this(value, null, null){}

        public ListNode<T> ElementAt(int position)
        {
            if (position == 1) return this;
            else if (position < 1 || next == null)
            {
                return null;
            }
            else
            {
                return next.ElementAt(position - 1);
            }
        }

    }
}
