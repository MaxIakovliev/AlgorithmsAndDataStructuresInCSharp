using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Lists
{
    public class LinkedList<T> : ILinkedList<T> where T:IComparable<T>
    {
        private int _count;

        private INode<T> _head;

        private INode<T> _current;

        private Func<INode<T>> createInstance;

        public int Count
        {
            get { return _count; }
        }
        public LinkedList(Func<INode<T>> nodeInstance)
        {
            _count = 0;
            _head = null;
            _current = _head;
            createInstance = nodeInstance;
        }

        public bool IsEmpty()
        {
            return Count == 0;
        }

        public void Add(T newItem)
        {
            if (_head == null)
            {
                _head = createInstance();
                _head.Data = newItem;
                _current = _head;
            }
            else
            {
                var tmp = _current;
                _current.Next = createInstance();
                _current = _current.Next;
                _current.Prev = tmp;
                _current.Data = newItem;
            }

        }

        public void Add(INode<T> newItem)
        {
            if (_head == null)
            {
                _head = newItem;
                _current = _head;
            }
            else
            {
                var tmp = _current;
                _current.Next = newItem;
                _current = _current.Next;
                _current.Prev = tmp;
            }
        }

        public void AddAfter(INode<T> existingItem, T newItem)
        {
            var exNext = existingItem.Next;
            existingItem.Next = createInstance();//createnew instance

            var newNextItem = existingItem.Next;
            newNextItem.Data = newItem;//store value into newly created node
            newNextItem.Prev = existingItem;
            newNextItem.Next = exNext;
            exNext.Next = newNextItem;
        }

        public void AddAfter(INode<T> existingItem, INode<T> newItem)
        {
            var exNext = existingItem.Next;
            existingItem.Next = newItem;

            var newNextItem = existingItem.Next;
            newNextItem.Prev = existingItem;
            newNextItem.Next = exNext;
            exNext.Next = newNextItem;
        }

        public void AddFirst(T item)
        {
            var tmp = _head;
            _head = createInstance();
            _head.Data = item;
            _head.Next = tmp;
        }

        public void AddFirst(INode<T> item)
        {
            var tmp = _head;
            _head = item;
            _head.Next = tmp;
        }

        public void AddLast(T item)
        {
            throw new NotImplementedException();
        }

        public void AddLast(INode<T> item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(T value)
        {
            throw new NotImplementedException();
        }

        public INode<T> Find(T item)
        {
            var current = _head;
            while (current != null)
            {
                if (current.Data.Equals(item))
                    return current;
                current = current.Next;
            }
            return null;
        }

        public void RemoveFirst()
        {
            throw new NotImplementedException();
        }

        public void RemoveLast()
        {
            throw new NotImplementedException();
        }
    }
}
