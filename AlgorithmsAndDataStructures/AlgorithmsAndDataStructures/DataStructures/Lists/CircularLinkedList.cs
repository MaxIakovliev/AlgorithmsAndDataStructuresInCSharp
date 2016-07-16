using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Lists
{
    public class CircularLinkedList<T> : ILinkedList<T> where T : IComparable<T>
    {
        private INode<T> _head;
        private INode<T> _current;
        private Func<INode<T>> _createInstance;
        private int _count;
        private int _maxCapacity;

        public CircularLinkedList(Func<INode<T>> createInstance, int maxCapacity)
        {
            _head = null;
            _current = _head;
            _count = 0;
            _createInstance = createInstance;
            _maxCapacity = maxCapacity;
        }

        public int Count
        {
            get { return _count; }
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
                _count++;
            }
            else
            {
                if (_count < _maxCapacity)
                {
                    _current.Next = _createInstance();
                    _count++;
                }
                var prev = _current;
                _current = _current.Next;
                _current.Prev = prev;
                _current.Data = newItem;

                if (_count == _maxCapacity - 1)
                {
                    _current.Next = _head;
                }
            }
        }

        public void Add(INode<T> newItem)
        {
            if (_head == null)
            {
                _head = newItem;
                _current = _head;
                _head.Next = _current;
                _count++;
            }
            else
            {
                if (_count < _maxCapacity)
                {
                    _current.Next = newItem;
                    newItem.Prev = _current;
                    _current.Next = _head;

                    _head.Prev = _current;

                    _count++;
                }
                else
                {
                    var oldNext = _current.Next;
                    _current.Next = newItem;
                    newItem.Prev = _current;
                    oldNext.Next.Prev = newItem;
                    oldNext.Invalidate();
                }
            }
        }

        public void AddAfter(INode<T> existingItem, T newItem)
        {
            if (!Exists(existingItem))
                throw new Exception("Specified  item is not exists in List");

            if (_count < _maxCapacity)
            {
                var oldNext = existingItem.Next;
                existingItem.Next = _createInstance();
                existingItem.Next.Prev = existingItem;
                existingItem.Next.Next = oldNext;
                if (oldNext != null)
                    oldNext.Prev = existingItem.Next;
                _count++;
            }
            else
            {
                existingItem.Next.Data = newItem;
            }
        }

        public void AddAfter(INode<T> existingItem, INode<T> newItem)
        {
            if (!Exists(existingItem))
                throw new Exception("Specified  item is not exists in List");

            if(Exists(newItem))
                throw new Exception("Specified  item is ALREADY exists in List");
            
            if(_count<_maxCapacity)
            {
                var oldNext = existingItem.Next;
                existingItem.Next = newItem;
                newItem.Prev = existingItem;
                newItem.Next = oldNext;
                if (oldNext != null)
                    oldNext.Prev = newItem;

                _count++;
            }
            else
            {
                var oldNext = existingItem.Next;

                existingItem.Next = newItem;
                newItem.Next = oldNext.Next;
                oldNext.Next.Prev = newItem;
                oldNext.Invalidate();
            }

        }

        public void AddFirst(T item)
        {
            if (_count < _maxCapacity)
            {
                var newItem = _createInstance();
                newItem.Data = item;
                newItem.Next = _head;

                var tmpPrev = _head.Prev;
                _head.Prev = newItem;
                _current.Next = newItem;
                _count++;
            }
            else
            {
                _head.Data = item;
            }
        }

        public void AddFirst(INode<T> item)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public void RemoveFirst()
        {
            throw new NotImplementedException();
        }

        public void RemoveLast()
        {
            throw new NotImplementedException();
        }

        public T GetFirst()
        {
            throw new NotImplementedException();
        }

        public T GetLast()
        {
            throw new NotImplementedException();
        }

        public T Get(int index)
        {
            throw new NotImplementedException();
        }


        public bool Exists(INode<T> item)
        {
            if (_head == null)
                return false;

            var cur = _head;
            do
            {
                if (cur.Equals(item))
                    return true;
                cur = cur.Next;

            } while (cur.Equals(_head));

            return false;
        }
    }
}
