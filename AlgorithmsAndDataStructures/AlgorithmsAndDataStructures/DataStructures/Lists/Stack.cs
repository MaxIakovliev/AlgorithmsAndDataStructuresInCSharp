using DataStructures.Lists;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsAandDataStructures.DataStructures.Lists
{
    public class Stack<T>:IStack<T> where T : IComparable<T>
    {
        private LinkedList<T> data;
        public Stack()
        {
            data = new LinkedList<T>(() => new Node<T>());
        }
        public Stack(int capacity):this()
        {
            //TODO implement support for predefined capacity
        }
        public void Push(T item)
        {
            data.Add(item);
        }

        public T Pop()
        {
            if (!data.IsEmpty())
            {
                var item= data.GetLast();
                data.RemoveLast();
                return item;
            }
            throw new Exception("Stack is empty");
        }

        public T Peek()
        {
            if (!data.IsEmpty())
                return data.GetLast();

            throw new Exception("Stack is empty");
        }

        public void Clear()
        {
            data.Clear();
        }

        public bool Contains(T item)
        {
            return data.Contains(item);
        }

        public bool IsEmpty()
        {
            return data.IsEmpty();
        }

        public int Count
        {
            get { return data.Count; }
        }
    }
}
