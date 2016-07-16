using System;

namespace DataStructures.Lists
{
    public interface IStack<T> where T:IComparable<T>
    {
        void Push(T item);
        T Pop();
        T Peek();
        void Clear();
        bool Contains(T item);
        bool IsEmpty();
        int Count { get; }

    }
}
