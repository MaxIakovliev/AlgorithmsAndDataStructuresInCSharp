using System;

namespace O3.DataStructures.Lists
{
    public interface INode<T>// : IComparable<INode<T>>// where T : IComparable<T> 
    {
        INode<T> Next { get; set; }
        INode<T> Prev { get; set; }
        T Data { get; set; }

        void Invalidate();

        Guid GetCode();

    }
}
