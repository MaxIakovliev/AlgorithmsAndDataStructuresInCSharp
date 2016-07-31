using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O3.DataStructures.Trees
{
    public sealed class AvlTree<T> : BalancedBinaryTree<T> where T : IComparable<T>
    {
        private Func<T, IBalancedTreeNode<T>> _createNode;
        public AvlTree(Func<T, IBalancedTreeNode<T>> createNode)
        {
            _createNode = createNode;
            Count = 0;
            _head = null;
        }
        public void Insert(T item)
        {
            _head = Insert(item, _head);
        }

        private IBalancedTreeNode<T> Insert(T item, IBalancedTreeNode<T> node)
        {
            if (node == null)
                node = _createNode(item);
            else if (item.CompareTo(node.Data) < 0)
            {
                node.Left = Insert(item, node.Left);
                if (GetDepth(node.Left) - GetDepth(node.Right) == 2)
                {
                    if (item.CompareTo(node.Left.Data) < 0)
                    {
                        node = RotateWithLeftChild(node);
                    }
                    else
                    {
                        node = RotateWithLeftChildDouble(node);
                    }
                }
            }
            else if (item.CompareTo(node.Data) > 0)
            {
                node = Insert(item, node);
                if (GetDepth(node.Right) - GetDepth(node.Left) == 2)
                {
                    if (item.CompareTo(node.Right.Data) > 0)
                    {
                        node = RotateWithRightChild(node);
                    }
                    else
                    {
                        node = RotateWithRightChildDouble(node);
                    }
                }
            }
            else
            {
                throw new Exception("Attempting to insert dublicate value");
            }
            node.Height = Math.Max(GetDepth(node.Left), GetDepth(node.Right)) + 1;
            return node;
        }

        public T GetMin()
        {
            return GetMin(_head);
        }

        private T GetMin(IBalancedTreeNode<T> node)
        {
            if (node.Left == null)
                return node.Data;

            while (node.Left != null)
                node = node.Left;

            return node.Data;
        }


        public T GetMax(IBalancedTreeNode<T> node)
        {
            if (node.Right == null)
                return node.Data;

            while (node.Right != null)
                node = node.Right;

            return node.Data;
        }

        public IBalancedTreeNode<T> Find(T item)
        {
            var tmp = _head;
            while (tmp != null)
            {
                if (item.CompareTo(tmp.Data) < 0)
                    tmp = tmp.Left;
                else if (item.CompareTo(tmp.Data) > 0)
                    tmp = tmp.Right;
                else
                    return tmp;
            }
            return tmp;
        }

    }
}
