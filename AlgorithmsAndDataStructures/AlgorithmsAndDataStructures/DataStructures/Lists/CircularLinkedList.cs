using System;

namespace O3.DataStructures.Lists
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

            if (Exists(newItem))
                throw new Exception("Specified  item is ALREADY exists in List");

            if (_count < _maxCapacity)
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
            if (Exists(item))
            {
                throw new Exception("Node already belong to List");
            }

            if (_count < _maxCapacity)
            {
                item.Next = _head;
                _current.Next = item;
                _head.Prev = item;
                _head = item;
                _count++;
            }
        }

        public void AddLast(T item)
        {
            if (_count < _maxCapacity)
            {
                _current.Next = _createInstance();
                _current.Data = item;
                _current.Next.Prev = _current;
                _current = _current.Next;
                _current.Next = _head;
                _count++;
            }
            else
            {
                _current.Next.Data = item;
                _current = _current.Next;
            }
        }

        public void AddLast(INode<T> item)
        {
            if (Exists(item))
            {
                throw new Exception("Node already belong to List");
            }

            if (_count < _maxCapacity)
            {
                _current.Next = item;
                item.Prev = _current;
                item.Next = _head;
                _current = item;
                _count++;
            }
            else
            {
                var prevNext = _current.Next;
                _current.Next = item;
                item.Prev = _current;
                item.Next = prevNext.Next;

                if (prevNext.Equals(_head))
                    _head = item;
                _current = item;

                prevNext.Invalidate();
            }
        }

        public void Clear()
        {
            var cur = _head;
            while (cur != null)
            {
                var tmp = cur.Next;
                cur.Invalidate();
                cur = tmp;
            }
        }

        public bool Contains(T value)
        {
            if (_head == null)
                return false;
            var cur = _head;
            do
            {
                if (cur.Data.Equals(value))
                    return true;

                cur = cur.Next;
                 
            } while (!cur.Equals(_head));
            return false;
        }

        public INode<T> Find(T item)
        {
            if (_head == null)
                return null;
            
            var cur = _head;
            do
            {
                if (cur.Data.Equals(item))
                    return cur;

                cur = cur.Next;

            } while (!cur.Equals(_head));

            return null;
        }

        public void RemoveFirst()
        {
            if (_head == null)
                throw new Exception("List is empty");

            var tmp = _head.Next;
            var tmpPrev = _head.Prev;
            _head.Invalidate();
            _head = tmp;
            _head.Prev = tmpPrev;

            _count--;
        }

        public void RemoveLast()
        {
            throw new NotImplementedException();
        }

        public T GetFirst()
        {
            if (_head == null)
                throw new Exception("List is empty");

            return _head.Data;
        }

        public T GetLast()
        {
            if (_head==null)
                throw new Exception("List is empty");

            return _current.Data;
        }

        public T Get(int index)
        {
            if (_count < index)
                throw new ArgumentOutOfRangeException("required index is out");

            int count = 0;
            var cur = _head;
            while (count!=index)
                cur = cur.Next;
            return cur.Data;
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


        public void Reverse()
        {
            throw new NotImplementedException();
        }
    }
}
