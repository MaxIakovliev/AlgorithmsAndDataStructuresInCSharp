using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O3.Algorithms.Sort
{
    public class Selection<T> : ISort<T> where T : IComparable
    {

        public void Sort(T[] arr)
        {
            for(int i=0; i<arr.Length; i++)
            {
                for(int j=i+1; j<arr.Length; j++)
                {
                    if(arr[i].CompareTo(arr[j])>0)
                    {
                        T tmp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = tmp;
                    }
                }
            }
        }
    }
}
