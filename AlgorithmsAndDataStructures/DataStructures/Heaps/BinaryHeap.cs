using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O3.DataStructures.Heaps
{
    public class BinaryHeap<T> : IHeap<T> where T : IComparable<T>
    {
        public enum HeapType
        {
            MaxHeap,
            MinHeap
        }
        private List<T> _data;
        private HeapType _type;
        public BinaryHeap( HeapType heapType)
        {
            _data = new List<T>();
            _type = heapType;
        }
        public void Add(T item)
        {
            _data.Add(item);
            if (_type == HeapType.MaxHeap)
                HeapUp(_data.Count - 1);
            else 
                HeadDown(_data.Count - 1);
        }

        private void HeadDown(int idx)
        {
            var item = _data[idx];
            if (item == null)
                return;

            while(idx>=0)
            {
                int parentIdx = GetParent(idx);
                if (parentIdx < 0)
                    return;
                var parentItem = _data[parentIdx];

                if(item.CompareTo(parentItem)<0)
                {
                    _data[parentIdx] = item;
                    _data[idx] = parentItem;
                }
            }
        }

        public T PeekHead()
        {
            return _data[0];
        }

        public T PopHead()
        {
            var item = _data[0];
            _data.RemoveAt(0);
            return item;
        }

        private void HeapUp(int idx)
        {
            var item = _data[idx];
            if (item == null)
                return;

            while (idx >= 0)
            {
                int parentIdx = GetParent(idx);
                if (parentIdx < 0)
                    return;

                var parentItem = _data[parentIdx];
                if (item.CompareTo(parentItem) > 0)
                {
                    _data[parentIdx] = item;
                    _data[idx] = parentItem;
                }
                idx = parentIdx;
            }
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
