using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O3.DataStructures.Trees
{
    public class BinaryTreeNode<T>:IBinaryTreeNode<T>, IComparable<T> where T:IComparable<T>
    {
        public IBinaryTreeNode<T> Right { get; set; }

        public IBinaryTreeNode<T> Left { get; set; }

        public T Data { get; private set; }
        public BinaryTreeNode(T item)
        {
            Data = item;
        }

        public int CompareTo(T other)
        {
            return Data.CompareTo(other);
        }


        public void Invalidate()
        {
            Data = default(T);
            Right = null;
            Left = null;
        }
    }
}
