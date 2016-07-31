using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O3.DataStructures.Trees
{
    public interface IAvlTreeNode<T> : IBaseTreeNode<T>, IComparable<T> where T : IComparable<T>
    {
        IAvlTreeNode<T> Right { get; set; }
        IAvlTreeNode<T> Left { get; set; }
        int Height { get; set; }
    }
}
