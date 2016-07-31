using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O3.DataStructures.Trees
{
    public interface IBaseTreeNode<T> : IComparable<T> where T : IComparable<T>
    {
        T Data { get; }
        void Invalidate();
    }
}
