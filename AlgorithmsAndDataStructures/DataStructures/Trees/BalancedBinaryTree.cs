using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O3.DataStructures.Trees
{
    public abstract class BalancedBinaryTree<T> : BinaryTree<T> where T : IComparable<T>
    {
        protected IAvlTreeNode<T> _head { get; set; }
        public int Count { get; protected set; }

        /// <summary>
        /// Rotate balanced binary tree with left child, calculate height, return updated tree
        /// Case 1. Left child available
        /// </summary>
        /// <param name="currentRoot">root of sub tree- that we are going to rotate</param>
        /// <returns> new  node  after rotation</returns>
        protected IAvlTreeNode<T> RotateWithLeftChild(IAvlTreeNode<T> currentRoot)
        {
            if (currentRoot == null)
                return null;

            var tmp = currentRoot.Left;

            currentRoot.Left = tmp.Right;

            tmp.Right = currentRoot;

            currentRoot.Height = Math.Max(GetDepth(currentRoot.Left), GetDepth(currentRoot.Right));
            tmp.Height = Math.Max(GetDepth(tmp.Left), GetDepth(tmp.Right));
            return tmp;
        }

        /// <summary>
        /// Double rotate binary tree.
        /// </summary>
        /// <param name="currentNode"> root of sub tree for rotating</param>
        /// <returns>new root</returns>
        protected IAvlTreeNode<T> RotateWithLeftChildDouble(IAvlTreeNode<T> currentNode)
        {
            currentNode.Left = RotateWithLeftChild(currentNode.Left);
            return RotateWithLeftChild(currentNode);
        }

        /// <summary>
        /// Rotate binary tree with right child, calculate height, return updated tree
        /// Case 2. Right child available
        /// </summary>
        /// <param name="currentNode">root of sub tree- that we are going to rotate</param>
        /// <returns>new  node  after rotation</returns>
        protected IAvlTreeNode<T> RotateWithRightChild(IAvlTreeNode<T> currentRoot)
        {
            if (currentRoot == null)
                return null;

            var tmp = currentRoot.Right;

            currentRoot.Right = tmp.Left;

            tmp.Left = currentRoot;

            currentRoot.Height = Math.Max(GetDepth(currentRoot.Left), GetDepth(currentRoot.Right));
            tmp.Height = Math.Max(GetDepth(tmp.Left), GetDepth(tmp.Right));

            return tmp;
        }

        /// <summary>
        /// Double rotate binary tree
        /// </summary>
        /// <param name="currentRoot"></param>
        /// <returns>new root</returns>
        protected IAvlTreeNode<T> RotateWithRightChildDouble(IAvlTreeNode<T> currentRoot)
        {
            currentRoot.Right = RotateWithRightChild(currentRoot.Right);
            return RotateWithRightChild(currentRoot);
        }

        protected int GetDepth(IAvlTreeNode<T> item)
        {
            if (item == null)
                return 0;

            int lh, rh;
            lh = rh = 0;
            if (item.Left != null)
                lh += GetDepth(item.Left);

            if (item.Right != null)
                rh += GetDepth(item.Right);

            return rh > lh ? rh : lh;
        }

        public int GetDepth()
        {
            return GetDepth(_head);
        }

    }
}
