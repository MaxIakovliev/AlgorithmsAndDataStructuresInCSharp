using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Lists
{
    public class Node<T> : INode<T> where T : IComparable<T>
    {
        private T _data;
        private INode<T> _next;
        private INode<T> _prev;

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

        public Node()
        {
            Next = null;
            Data = default(T);
        }


        public int CompareTo(INode<T> other)
        {
            if (other == null) return -1;

            return Data.CompareTo(other.Data);
        }



       

        public void Invalidate()
        {
            throw new NotImplementedException();
        }
    }
}
