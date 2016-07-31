using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O3.DataStructures.Trees
{
    public abstract class BalancedBinaryTree<T> : BinaryTree<T> where T : IComparable<T>
    {

        protected IAvlTreeNode<T> RotateWithLeftChild(AvlTreeNode<T> currentRoot)
        {
            if (currentRoot == null)
                return null;

            var tmp = currentRoot.Left;
            
            currentRoot.Left = tmp.Right;

            tmp.Right = currentRoot;

            //currentRoot.Height = Math.Max(GetDepth(currentRoot.Left), GetDepth(currentRoot.Right));
            //tmp.Height = Math.Max(GetDepth(tmp.Left), GetDepth(tmp.Right));
            return tmp;
        }
    }
}
