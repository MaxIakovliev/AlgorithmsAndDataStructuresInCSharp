using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Lists
{
    public interface ISkipListNode<T> : INode<T> where T : IComparable<T> 
    {
        INode<T> Top { get; set; }
        INode<T> Bottom { get; set; }
    }
}
