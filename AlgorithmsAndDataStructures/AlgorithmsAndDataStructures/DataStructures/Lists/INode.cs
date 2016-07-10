using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Lists
{
    public interface INode<T> : IComparable<INode<T>> where T : IComparable<T>
    {
        INode<T> Next { get; set; }
        INode<T> Prev { get; set; }
        T Data { get; set; }

        void Invalidate();
    }
}
