using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O3.DataStructures.Trees
{
    /// <summary>
    /// Binary Search Tree (BST) is a special type of Binary Tree that follows following condition
    /// 1. Left child node is smaller than its parent Node
    /// 2. Right child node is greater than its parent Node
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BinarySearchTree<T> : IBinaryTree<T>, IEnumerable<T> where T : IComparable<T>
    {
        public int Count
        {
            get { throw new NotImplementedException(); }
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public void Add(T item)
        {
            throw new NotImplementedException();
        }

        public bool Contains(T item)
        {
            throw new NotImplementedException();
        }

        public IBinaryTreeNode<T> Find(T item)
        {
            throw new NotImplementedException();
        }

        public IBinaryTreeNode<T> Find(T item, out IBinaryTreeNode<T> parent)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
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
