using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O3.DataStructures.Trees
{
    public interface IBinaryTree<T> where T : IComparable<T>
    {
        int Count { get; }
        
        void Clear();

        void Add(T item);

        bool Contains(T item);

        IBinaryTreeNode<T> Find(T item);

        IBinaryTreeNode<T> Find(T item, out IBinaryTreeNode<T> parent);

        bool Remove(T item);
    }
}
