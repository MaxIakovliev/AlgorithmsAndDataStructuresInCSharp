using System;

namespace O3.DataStructures.Lists
{
    public class Queue<T> : IQueue<T> where T : IComparable<T>
    {
        private LinkedList<T> _data;
        private readonly bool _fixedCapacity;

        public Queue()
        {
            _data = new LinkedList<T>(() => new Node<T>());
            _fixedCapacity = false;
        }
        public Queue(int capacity, bool fixedCapacity=false)
            : this()
        {
            //TODO implement support of capacity
            _fixedCapacity = fixedCapacity;
        }

        public void Enqueue(T item)
        {
            _data.AddFirst(item);
        }

        public T Dequeue()
        {
            if(!_data.IsEmpty())
            {
                var item = _data.GetLast();
                _data.RemoveLast();
                return item;
            }
            throw new Exception("Queue is empty");
        }

        public T Peek()
        {
            if (!_data.IsEmpty())
                return  _data.GetLast();

            throw new Exception("Queue is empty");
        }

        public void Clear()
        {
            _data.Clear();
        }

        public int Count
        {
            get { return _data.Count; }
        }

        public bool Contains(T item)
        {
            return _data.Contains(item);
        }
    }
}
