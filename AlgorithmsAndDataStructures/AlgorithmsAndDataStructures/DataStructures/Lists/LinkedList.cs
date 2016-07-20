using System;

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
            //exNext.Next = newNextItem;
            _count++;
        }

        public void AddAfter(INode<T> existingItem, INode<T> newItem)
        {
            var exNext = existingItem.Next;
            existingItem.Next = newItem;

            var newNextItem = existingItem.Next;
            newNextItem.Prev = existingItem;
            newNextItem.Next = exNext;
            //exNext.Next = newNextItem;
            _count++;
        }

        public void AddFirst(T item)
        {
            bool updateCurrent = false;
            if (_head == null)
                updateCurrent = true;
            
            var tmp = _head;
            _head = _createInstance();
            _head.Data = item;
            _head.Next = tmp;
            if (tmp != null)
                tmp.Prev = _head;

            if (updateCurrent)
                _current = _head;
            
            _count++;
        }

        public void AddFirst(INode<T> item)
        {
            bool updateCurrent=false;
            if (_head == null)
                updateCurrent = true;

            var tmp = _head;
            _head = item;
            _head.Next = tmp;
            if (updateCurrent)
                _current = _head;
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
            while (tmp != null)
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
            if (_head != null)
            {
                var oldHead = _head;
                _head = _head.Next;
                if (_head != null)
                {
                    _head.Prev = null;
                }
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


        public T GetFirst()
        {
            if (_head == null)
            {
                throw new Exception("Linked list is empty");
            }
            return _head.Data;
        }

        public T GetLast()
        {
            if (_current == null)
                throw new Exception("Linked list is empty");

            return _current.Data;
        }

        public T Get(int index)
        {
            int count = 0;
            var tmp = _head;
            while (count < index)
            {
                if (tmp.Next == null)
                {
                    throw new IndexOutOfRangeException("specified index out of range");
                }
                tmp = tmp.Next;
                count++;
            }
            return tmp.Data;
        }


        public bool Exists(INode<T> item)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///  Reverse doubly linked list
        /// </summary>
        public void Reverse()
        {
            INode<T> tmp=null;// create temp node we are going to use it for swap next/prev links
            INode<T> currentNode = _head;// head is our start point

            //swap all prev/next nodes of  current  double linked list
            while(currentNode!=null) 
            {
                tmp = currentNode.Prev; //store  reference to prev node in our temp variable
                currentNode.Prev = currentNode.Next; 
                currentNode.Next = tmp;

                currentNode = currentNode.Prev;// go to next item in the list (now it's prev, because of swap)
            }

            if (tmp != null)
                _head = tmp.Prev;
        }
    }
}
