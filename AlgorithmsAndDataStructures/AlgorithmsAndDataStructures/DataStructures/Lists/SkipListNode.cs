using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Lists
{
    public class SkipListNode<T> where T : IComparable<T>
    {
        public int CompareTo(T other)
        {
            throw new NotImplementedException();
        }

        public List<SkipListNode<T>> Nodes { get; set; }
        public SkipListNode(Func<ILinkedList<T>> createInstance)
        {
            Nodes = new List<SkipListNode<T>>();
        }
    }
}
