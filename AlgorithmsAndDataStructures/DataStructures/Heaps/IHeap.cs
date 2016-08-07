using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O3.DataStructures.Heaps
{
    public interface IHeap<T> where T :IComparable<T>
    {
        void Add(T item);
        
        /// <summary>
        /// return head value (value retain in  heap) 
        /// </summary>
        /// <returns>head value</returns>
        T PeekHead();

        /// <summary>
        /// return  value from head and remove it from  heap
        /// </summary>
        /// <returns>head value</returns>
        T PopHead();


            

    }
}
