using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsAandDataStructures.DataStructures.Lists
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
