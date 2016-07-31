using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O3.DataStructures.Trees
{
    public interface IBalancedTreeNode<T> : IBaseTreeNode<T>, IComparable<T> where T : IComparable<T>
    {
        IBalancedTreeNode<T> Right { get; set; }
        IBalancedTreeNode<T> Left { get; set; }
        int Height { get; set; }
    }
}
