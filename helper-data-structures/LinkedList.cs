using System;

namespace helper_data_structures
{
    public interface ILinkedListNode<T>
    {
        ILinkedListNode<T>  Next { get; set; }

        ILinkedListNode<T>  Previous { get; set; }

        T Value{ get; set; }

        void Add(ILinkedListNode<T> node);
    }

    public class LinkedListNode<T> : ILinkedListNode<T>
    {
        public ILinkedListNode<T> Next { get; set; }

        public ILinkedListNode<T> Previous { get; set; }

        public T Value{ get; set; }

        public void Add(ILinkedListNode<T> node)
        {
            Next.Previous = node;
            Next = node;
        }
    }
}
