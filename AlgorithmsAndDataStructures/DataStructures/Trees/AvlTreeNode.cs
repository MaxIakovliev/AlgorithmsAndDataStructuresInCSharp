﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O3.DataStructures.Trees
{
    public class AvlTreeNode<T> : IBalancedTreeNode<T>, IComparable<T> where T : IComparable<T>
    {

        public int Height { get; set; }

        public IBalancedTreeNode<T> Right { get; set; }

        public IBalancedTreeNode<T> Left { get; set; }

        public T Data { get; private set; }

        public void Invalidate()
        {
            Data = default(T);
            Right = null;
            Left = null;
        }

        public int CompareTo(T other)
        {
            return Data.CompareTo(other);
        }
    }
}
