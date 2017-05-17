namespace MyLinkedList
{
    public class ListNode<T>
    {
        private T value;

        public ListNode(T value,  ListNode<T> prev, ListNode<T> next)
        {
            Value = value;
            Next = next;
            Prev = prev;
        }

        public T Value { get; private set; }
        public ListNode<T> Next { get; set ; }
        public ListNode<T> Prev { get; set; }

        public ListNode(T value) : this(value, null, null){}
    }
}
