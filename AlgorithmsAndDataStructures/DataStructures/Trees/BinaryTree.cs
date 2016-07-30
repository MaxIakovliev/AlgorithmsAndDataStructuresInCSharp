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

        private int GetDepth(IBinaryTreeNode<T> item)
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

        public abstract void Insert(T item);

        public abstract IBinaryTreeNode<T> Find(T item);

    }
}
