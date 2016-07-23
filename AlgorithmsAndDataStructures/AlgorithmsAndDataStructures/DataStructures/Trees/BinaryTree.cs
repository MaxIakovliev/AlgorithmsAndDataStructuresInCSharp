using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O3.DataStructures.Trees
{
    public class BinaryTree<T> : IEnumerable<T> where T : IComparable<T>
    {
        private IBinaryTreeNode<T> _head;
        private int _count;

        public void Add(T item)
        {
            if (_head == null)
            {
                _head = new BinaryTreeNode<T>(item);
                return;
            }
            AddTo(_head, item);

        }
        /// <summary>
        /// Recursive algorithms for adding new nodes into BinaryTree
        /// </summary>
        /// <param name="node">node</param>
        /// <param name="item">value</param>
        private void AddTo(IBinaryTreeNode<T> node, T item)
        {
            if (node.Data.CompareTo(item) < 0)
            {
                if (node.Left == null)
                    node.Left = new BinaryTreeNode<T>(item);
                else
                    AddTo(node.Left, item);
            }
            else
            {
                if (node.Right == null)
                    node.Right = new BinaryTreeNode<T>(item);
                else
                    AddTo(node.Right, item);
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
