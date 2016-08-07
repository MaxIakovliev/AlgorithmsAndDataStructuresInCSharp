using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O3.DataStructures.Heaps
{
    public class BinaryHeap<T> : IHeap<T> where T : IComparable<T>
    {
        private List<T> data;
        public BinaryHeap()
        {
            data = new List<T>();
        }
        public void Add(T item)
        {
            data.Add(item);
        }

        public T PeekHead()
        {
            return data[0];
        }

        public T PopHead()
        {
            throw new NotImplementedException();
        }

        private int GetParent(int idx)
        {
            if (idx > 0)
                return (int)Math.Floor(((double)idx - 1) / 2);

            return int.MinValue;
        }

        private int GetLeftChild(int idx)
        {
            return 2 * idx + 1;
        }

        private int GetRightChild(int idx)
        {
            return 2 * idx + 2;
        }
    }
}
