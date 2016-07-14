using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.DataStructuresTest
{
    [TestFixture]
    public class LinkedListTest
    {
        private int _size = 100;

        [Test]
        public void TestLinkedListAdd()
        {
            var linkedList = new DataStructures.Lists.LinkedList<bool>(() => new DataStructures.Lists.Node<bool>());
            for(int i=0; i<_size; i++)
            {
                linkedList.Add(true);
            }

            Assert.AreEqual(_size, linkedList.Count);
        }


        [Test]
        public void TestLinkedListAddFirst()
        {
            var linkedList = new DataStructures.Lists.LinkedList<int>(() => new DataStructures.Lists.Node<int>());
            for (int i = 0; i < _size; i++)
            {
                linkedList.AddFirst(i);
            }

            Assert.AreEqual(_size, linkedList.Count);

            for (int i = 0; i < _size; i++)
            {
                Assert.AreEqual(_size-1-i, linkedList.Get(i));
            }
        }


        [Test]
        public void TestLinkedListRemoveFirst()
        {
            var linkedList = new DataStructures.Lists.LinkedList<int>(() => new DataStructures.Lists.Node<int>());
            for (int i = 0; i < _size; i++)
            {
                linkedList.AddFirst(i);
            }

            Assert.AreEqual(_size, linkedList.Count);

            for (int i = 0; i < _size; i++)
            {
                Assert.AreEqual(_size - 1 - i, linkedList.GetFirst());
                linkedList.RemoveFirst();

            }
        }


        [Test]
        public void TestLinkedListRemoveLast()
        {
            var linkedList = new DataStructures.Lists.LinkedList<int>(() => new DataStructures.Lists.Node<int>());
            for (int i = 0; i < _size; i++)
            {
                linkedList.AddFirst(i);
            }

            Assert.AreEqual(_size, linkedList.Count);

            for (int i = 0; i < _size; i++)
            {
                Assert.AreEqual(i, linkedList.GetLast());
                linkedList.RemoveLast();

            }
        }
    }
}
