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
        public override void Insert(T item)
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


        public override IBinaryTreeNode<T> Find(T item)
        {
            throw new NotImplementedException();
        }
    }
}
