using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O3.DataStructures.Trees
{
    public interface IBinaryTreeNode<T> where T:IComparable<T>
    {
        IBinaryTreeNode<T> Right { get; set; }
        IBinaryTreeNode<T> Left { get; set; }
        T Data { get; }
    }
}
