using System;
using System.Collections.Generic;

namespace O3.DataStructures.Lists
{
    public interface IStack<T> //: IEnumerable<T> where T : IComparable<T>
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
