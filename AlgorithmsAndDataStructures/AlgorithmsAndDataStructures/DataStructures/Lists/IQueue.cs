using System;

namespace DataStructures.Lists
{
    public interface IQueue<T> where T : IComparable<T>
    {
        void Enqueue(T item);
        T Dequeue();
        T Peek();
        void Clear();
        int Count { get; }
        bool Contains(T item);
    }
}
