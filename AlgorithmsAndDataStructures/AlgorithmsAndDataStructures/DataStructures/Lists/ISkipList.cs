using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Lists
{
    public interface ISkipList<T> where T : IComparable<T>
    {
        void Add(T item);
        void Delete(T item);
        bool Find(T item);
    }
}
