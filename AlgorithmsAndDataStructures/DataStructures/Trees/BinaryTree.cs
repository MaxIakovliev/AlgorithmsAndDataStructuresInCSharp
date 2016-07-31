using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O3.DataStructures.Trees
{

    public abstract class BinaryTree<T> where T : IComparable<T>
    {
        protected IBinaryTreeNode<T> _head;
        public int Count { get; protected set; }
        public BinaryTree()
        {
            _head = null;
            Count = 0;
        }


        public abstract void Insert(T item);

        public abstract IBinaryTreeNode<T> Find(T item);
               
    }
}
