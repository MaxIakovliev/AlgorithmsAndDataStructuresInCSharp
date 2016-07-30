using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O3.DataStructures.Trees
{
    public class OrderedBinaryTree<T> : BinaryTree<T> where T : IComparable<T>
    {
        public OrderedBinaryTree()
            : base() { }

        public override void Insert(T item)
        {
            Insert(item, _head);
        }

        private void Insert(T item, IBinaryTreeNode<T> node)
        {
            if (node==null)
            {
                node = new BinaryTreeNode<T>(item);
                Count++;
            }
            else
            {
                if (item.CompareTo(node.Data) < 0)
                    Insert(item, node.Left);
                else
                    Insert(item, node.Right);
            }
        }

        public override IBinaryTreeNode<T> Find(T item)
        {
            return Find(item, _head);
        }

        public IBinaryTreeNode<T> Find (T item, IBinaryTreeNode<T> node)
        {
            if (node == null)
                return null;

            if (item.CompareTo(node.Data) < 0)
                return Find(item, node.Left);
            else if (item.CompareTo(node.Data) > 0)
                return Find(item, node.Right);
            else
                return node;
        }
    }
}
