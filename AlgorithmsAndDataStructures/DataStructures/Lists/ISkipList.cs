using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O3.DataStructures.Lists
{
    public interface ISkipList<T>:ICollection, IEnumerable where T : IComparable<T>
    {
        void Add(T item);
        void Delete(T item);
        bool Find(T item);
    }
}
