using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O3.Algorithms.Sort
{
    public interface ISort<T> where T:IComparable
    {
        void Sort(T[] arr);
    }
}
