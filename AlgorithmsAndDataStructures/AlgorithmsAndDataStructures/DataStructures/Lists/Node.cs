using System;

namespace DataStructures.Lists
{
    public class Node<T> : INode<T> where T : IComparable<T>
    {
        private T _data;
        private INode<T> _next;
        private INode<T> _prev;

        private readonly Guid _code;
        public Node()
        {
            _code = Guid.NewGuid();
            Next = null;
            Data = default(T);
        }

        public T Data
        {
            get { return _data; }
            set { _data = value; }
        }
        public INode<T> Next
        {
            get { return _next; }
            set { _next = value; }
        }

        public INode<T> Prev
        {
            get { return _prev; }
            set { _prev = value; }
        }

         

        public int CompareTo(INode<T> other)
        {
            if (other == null) return -1;
            return GetCode().CompareTo(other.GetCode());
        }


        public void Invalidate()
        {
            _next = null;
            _prev = null;
            Data = default(T);
        }


        public Guid GetCode()
        {
            return _code;
        }

        //public static bool operator == (T x, T y)
        //{
        //    if (x == null || y == null)
        //        return false;
        //    return x.Equals(y);
        //}
    }
}
