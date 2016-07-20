using System;

namespace DataStructures.Lists
{
    public interface ILinkedList<T> where T:IComparable<T>
    {
        int Count { get; }

        bool IsEmpty();

        void Add(T newItem);

        void Add(INode<T> newItem);

        void AddAfter(INode<T> existingItem, T newItem);

        void AddAfter(INode<T> existingItem, INode<T> newItem);

        void AddFirst(T item);
        void AddFirst(INode<T> item);

        void AddLast(T item);

        void AddLast(INode<T> item);

        void Clear();

        bool Contains(T value);

        bool Exists(INode<T> item);

        INode<T> Find(T item);

        void RemoveFirst();

        void RemoveLast();

        T GetFirst();

        T GetLast();

        T Get(int index);

        void Reverse();

    }
}
