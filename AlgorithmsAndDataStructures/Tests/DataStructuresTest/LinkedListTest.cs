using DataStructures.Lists;
using NUnit.Framework;
using System;
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
        public void Add()
        {
            var linkedList = new DataStructures.Lists.LinkedList<bool>(() => new DataStructures.Lists.Node<bool>());
            for (int i = 0; i < _size; i++)
            {
                linkedList.Add(true);
            }

            Assert.AreEqual(_size, linkedList.Count);
        }


        [Test]
        public void AddFirst()
        {
            var linkedList = new DataStructures.Lists.LinkedList<int>(() => new DataStructures.Lists.Node<int>());
            for (int i = 0; i < _size; i++)
            {
                linkedList.AddFirst(i);
            }

            Assert.AreEqual(_size, linkedList.Count);

            for (int i = 0; i < _size; i++)
            {
                Assert.AreEqual(_size - 1 - i, linkedList.Get(i));
            }
        }


        [Test]
        public void RemoveFirst()
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
        public void RemoveLast()
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

        [Test]
        public void IsEmptySuccess()
        {
            var linkedList = new DataStructures.Lists.LinkedList<decimal>(() => new DataStructures.Lists.Node<decimal>());
            Assert.AreEqual(true, linkedList.IsEmpty());

            linkedList.Add(1m);
            Assert.AreEqual(false, linkedList.IsEmpty());

            linkedList.RemoveFirst();
            Assert.AreEqual(true, linkedList.IsEmpty());

            for (int i = 0; i < _size; i++)
            {
                linkedList.Add(i);
                Assert.AreEqual(false, linkedList.IsEmpty());
            }

            for (int i = 0; i < _size - 1; i++)
            {
                linkedList.RemoveFirst();
                Assert.AreEqual(false, linkedList.IsEmpty());
            }
            linkedList.RemoveFirst();
            Assert.AreEqual(true, linkedList.IsEmpty());

        }


        [Test]
        public void IsAddNode()
        {
            var linkedList = new DataStructures.Lists.LinkedList<UInt16>(() => new DataStructures.Lists.Node<UInt16>());
            for (UInt16 i = 0; i < _size; i++)
            {
                INode<UInt16> node = new Node<UInt16>
                    {
                        Data = i
                    };
                linkedList.Add(node);
                Assert.AreEqual(i + 1, linkedList.Count);
            }
        }

        [Test]
        public void AddAfter()
        {
            var linkedList = new DataStructures.Lists.LinkedList<int>(() => new DataStructures.Lists.Node<int>());
            INode<int> node = new Node<int>
                {
                    Data = -5
                };

            linkedList.Add(node);

            for(int i=0; i<9; i++)
            {
                linkedList.AddAfter(node, i);
                Assert.AreEqual(i + 2, linkedList.Count);
                Assert.AreEqual(i, linkedList.Get(1));
            }
        }

        [Test]
        public void AddAfterNode()
        {

        }

        [Test]
        public void AddFirstNode()
        {

        }


        [Test]
        public void AddLast()
        {

        }

        [Test]
        public void AddLastNode()
        {

        }

        [Test]
        public void Clear()
        {

        }

        [Test]
        public void Contains()
        {

        }


        [Test]
        public void Exists()
        {

        }

        [Test]
        public void Find()
        {

        }



        [Test]
        public void GetFirst()
        {

        }

        [Test]
        public void GetLast()
        {

        }

        [Test]
        public void Get()
        {

        }

    }
}
