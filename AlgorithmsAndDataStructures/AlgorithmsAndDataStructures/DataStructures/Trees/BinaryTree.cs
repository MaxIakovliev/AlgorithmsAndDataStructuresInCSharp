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

        public bool Contains(T item)
        {
            return Find(item) == null ? false : true;
        }

        public IBinaryTreeNode<T> Find(T item)
        {
            var current = _head;
            while (current != null)
            {
                if (current.CompareTo(item) == 0)
                    return current;//Case 1. Found exact match
                if (current.CompareTo(item) > 0)
                    current = current.Left;//Case 2 item less than  current node- go to left node
                else if (current.CompareTo(item) < 0)
                    current = current.Right;//Case 3 item greather than cuurent node- goto right node
            }
            return current;
        }


        private IBinaryTreeNode<T> Find(T item, out IBinaryTreeNode<T> parent)
        {
            parent = null;
            var current = _head;
            while (current != null)
            {
                if (current.CompareTo(item) > 0)
                {
                    parent = current;
                    return current.Left;
                }
                else if (current.CompareTo(item) < 0)
                {
                    parent = current;
                    return current.Right;
                }
                else
                    return current;
            }
            return current;
        }

        /// <summary>
        /// Remove First occurance of the specified item from the tree
        /// </summary>
        /// <param name="item">item to remove</param>
        /// <returns>result of remove attempt</returns>
        public bool Remove(T item)
        {
            IBinaryTreeNode<T> current, parent;
            if ((current = Find(item, out parent)) == null)
                return false;

            //1. If current has no right child, then  left  child replaces current item
            if (current.Right == null)
            {
                if (parent == null)
                {
                    _head = current.Left;
                    return true;
                }

                if (parent.CompareTo(current.Data) > 0)
                {
                    // if parent value is greater than current value  make the current left child a left child of parent
                    parent.Left = current.Left;
                    return true;
                }

                if (parent.CompareTo(current.Data) < 0)
                {
                    // if parent value is less than current value  make the current left child a right child of parent
                    parent.Right = current.Left;
                    return true;
                }
            }
            //2. If current  right child has no left child, then current's right child -  replaces current node
            else if (current.Right.Left == null)
            {
                current.Right.Left = current.Left;
                if (parent == null)
                {
                    _head = current.Right;
                    return true;
                }

                if (parent.CompareTo(current.Data) > 0)
                {
                    // if parent value is greater than current value  make the current right child a left child of parent
                    parent.Left = current.Right;
                    return true;
                }

                if (parent.CompareTo(current.Data) < 0)
                {
                    // if parent value is less than current value  make the current right child a right child of parent
                    parent.Right = current.Right;
                    return true;
                }
            }
            //3. If current's right child has a left child, replace current with current's  right child's left-most child
            else
            {
                var leftmost = current.Right.Left;
                var leftmostParent = current.Right;
                while (leftmost.Left != null)
                {
                    leftmostParent = leftmost;
                    leftmost = leftmost.Left;
                }
                // the parent's left subtree becomes the leftmost's right subtree
                leftmostParent.Left = leftmost.Right;

                // assign leftmost's left and right to current's left and right children
                leftmost.Left = current.Left;
                leftmost.Right = current.Right;

                if (parent == null)
                {
                    _head = leftmost;
                    return true;
                }

                if (parent.CompareTo(current.Data) > 0)
                {
                    // if parent item is greater than current item  make leftmost the parent's left child
                    parent.Left = leftmost;
                    return true;
                }

                if (parent.CompareTo(current.Data) < 0)
                {
                    // if parent item is less than current item make leftmost the parent's right child
                    parent.Right = leftmost;
                    return true;
                }

            }
            return true;
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
