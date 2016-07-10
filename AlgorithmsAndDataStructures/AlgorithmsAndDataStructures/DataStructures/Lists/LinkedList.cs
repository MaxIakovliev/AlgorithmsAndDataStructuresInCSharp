using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Lists
{
    public class LinkedList<T> : ILinkedList<T> where T : IComparable<T>
    {
        private int _count;

        private INode<T> _head;

        private INode<T> _current;

        private Func<INode<T>> _createInstance;

        public int Count
        {
            get { return _count; }
        }
        public LinkedList(Func<INode<T>> nodeInstance)
        {
            _count = 0;
            _head = null;
            _current = _head;
            _createInstance = nodeInstance;
        }

        public bool IsEmpty()
        {
            return Count == 0;
        }

        public void Add(T newItem)
        {
            if (_head == null)
            {
                _head = _createInstance();
                _head.Data = newItem;
                _current = _head;
            }
            else
            {
                var tmp = _current;
                _current.Next = _createInstance();
                _current = _current.Next;
                _current.Prev = tmp;
                _current.Data = newItem;
            }
            _count++;
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
            _count++;
        }

        public void AddAfter(INode<T> existingItem, T newItem)
        {
            var exNext = existingItem.Next;
            existingItem.Next = _createInstance();//createnew instance

            var newNextItem = existingItem.Next;
            newNextItem.Data = newItem;//store value into newly created node
            newNextItem.Prev = existingItem;
            newNextItem.Next = exNext;
            exNext.Next = newNextItem;
            _count++;
        }

        public void AddAfter(INode<T> existingItem, INode<T> newItem)
        {
            var exNext = existingItem.Next;
            existingItem.Next = newItem;

            var newNextItem = existingItem.Next;
            newNextItem.Prev = existingItem;
            newNextItem.Next = exNext;
            exNext.Next = newNextItem;
            _count++;
        }

        public void AddFirst(T item)
        {
            var tmp = _head;
            _head = _createInstance();
            _head.Data = item;
            _head.Next = tmp;
        }

        public void AddFirst(INode<T> item)
        {
            var tmp = _head;
            _head = item;
            _head.Next = tmp;
            _count++;
        }

        public void AddLast(T item)
        {
            _current.Next = _createInstance();
            _current = _current.Next;
            _current.Data = item;
            _count++;
        }

        public void AddLast(INode<T> item)
        {
            _current.Next = item;
            _current = _current.Next;
            _count++;
        }

        public void Clear()
        {
            var tmp = _head;
            while(tmp!=null)
            {
                var cur = tmp;
                tmp = tmp.Next;
                cur.Invalidate();
            }
            _head = null;
            _count = 0;
        }

        public bool Contains(T value)
        {
            var forv = _head;
            while (forv != null)
            {
                if (forv != null)
                {
                    if (forv.Data.Equals(value))
                        return true;
                    forv = forv.Next;
                }
            }
            return false;
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
            if (_head != null && _head.Next != null)
            {
                var oldHead = _head;
                _head = _head.Next;
                _head.Prev = null;
                oldHead.Invalidate();
                _count--;
            }
        }

        public void RemoveLast()
        {
            if (_current != null && _current.Prev != null)
            {
                var oldTail = _current;
                _current = _current.Prev;
                oldTail.Invalidate();
                _count--;
            }
        }
    }
}
