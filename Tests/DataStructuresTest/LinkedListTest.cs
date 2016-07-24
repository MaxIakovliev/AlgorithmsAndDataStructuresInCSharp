using O3.DataStructures.Lists;
using NUnit.Framework;
using System;

namespace Tests.DataStructuresTest
{
    [TestFixture]
    public class LinkedListTest
    {
        private int _size = 1000;


        [Test]
        public void Add()
        {
            var linkedList = new LinkedList<bool>(() => new Node<bool>());
            for (int i = 0; i < _size; i++)
            {
                linkedList.Add(true);
            }

            Assert.AreEqual(_size, linkedList.Count);
        }


        [Test]
        public void AddFirst()
        {
            var linkedList = new LinkedList<int>(() => new Node<int>());
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
            var linkedList = new LinkedList<int>(() => new Node<int>());
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
            var linkedList = new LinkedList<int>(() => new Node<int>());
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
            var linkedList = new LinkedList<decimal>(() => new Node<decimal>());
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
            var linkedList = new LinkedList<UInt16>(() => new Node<UInt16>());
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
            var linkedList = new LinkedList<int>(() => new Node<int>());
            INode<int> node = new Node<int>
                {
                    Data = -5
                };

            linkedList.Add(node);

            for (int i = 0; i < _size; i++)
            {
                linkedList.AddAfter(node, i);
                Assert.AreEqual(i + 2, linkedList.Count);
                Assert.AreEqual(i, linkedList.Get(1));
            }
        }

        [Test]
        public void AddAfterNode()
        {
            var linkedList = new LinkedList<int>(() => new Node<int>());
            INode<int> node = new Node<int>
            {
                Data = -5
            };

            linkedList.Add(node);

            for (int i = 0; i < _size; i++)
            {
                var current = new Node<int>
                {
                    Data = i
                };
                linkedList.AddAfter(node, current);
                Assert.AreEqual(i + 2, linkedList.Count);
                Assert.AreEqual(i, linkedList.Get(1));
            }
        }

        [Test]
        public void AddFirstNode()
        {
            var linkedList = new LinkedList<int>(() => new Node<int>());
            for (int i = 0; i < _size; i++)
            {
                var current = new Node<int>
                {
                    Data = i
                };
                linkedList.AddFirst(current);
                Assert.AreEqual(i, linkedList.Get(0));
            }
        }


        [Test]
        public void AddLast()
        {
            var linkedList = new LinkedList<int>(() => new Node<int>());
            for (int i = 0; i < _size; i++)
            {

                linkedList.AddLast(i);
                Assert.AreEqual(i, linkedList.Get(linkedList.Count - 1));
            }
        }

        [Test]
        public void AddLastNode()
        {
            var linkedList = new LinkedList<int>(() => new Node<int>());
            for (int i = 0; i < _size; i++)
            {
                var current = new Node<int>
                {
                    Data = i
                };
                linkedList.AddLast(current);
                Assert.AreEqual(i, linkedList.Get(linkedList.Count - 1));
            }
        }

        [Test]
        public void Clear()
        {
            var linkedList = new LinkedList<int>(() => new Node<int>());
            linkedList.Clear();
            Assert.AreEqual(0, linkedList.Count);
            for (int i = 0; i < _size; i++)
            {
                var current = new Node<int>
                {
                    Data = i
                };
                linkedList.AddLast(current);
            }
            linkedList.Clear();
            Assert.AreEqual(0, linkedList.Count);
        }

        [Test]
        public void Contains()
        {
            var linkedList = new LinkedList<int>(() => new Node<int>());
            for (int i = 0; i < _size; i++)
            {
                linkedList.AddLast(i);
                Assert.AreEqual(true, linkedList.Contains(i));
                Assert.AreEqual(false, linkedList.Contains((i + _size) * _size));
            }
            linkedList.Clear();

            for (int i = 0; i < _size; i++)
            {
                linkedList.AddLast(i);
                linkedList.Clear();
                Assert.AreEqual(false, linkedList.Contains(i));
            }
            linkedList.Clear();

            for (int i = 0; i < _size; i++)
            {
                linkedList.AddLast(i);
                linkedList.RemoveLast();
                Assert.AreEqual(false, linkedList.Contains(i));
            }
            linkedList.Clear();

            for (int i = 0; i < _size; i++)
            {
                linkedList.AddFirst(i);
                linkedList.RemoveFirst();
                Assert.AreEqual(false, linkedList.Contains(i));
            }
        }



        [Test]
        public void Find()
        {
            var linkedList = new LinkedList<int>(() => new Node<int>());
            for (int i = 0; i < _size; i++)
            {
                linkedList.AddLast(i);
                var item = linkedList.Find(i);
                Assert.NotNull(item);
                Assert.AreEqual(i, item.Data);
            }
            while (linkedList.Count > 0)
            {
                var item = linkedList.Find(linkedList.Count - 1);

                Assert.NotNull(item);
                Assert.AreEqual(linkedList.Count - 1, item.Data);
                linkedList.RemoveLast();
            }
        }



        [Test]
        public void GetFirst()
        {
            var linkedList = new LinkedList<int>(() => new Node<int>());
            for (int i = 0; i < _size; i++)
            {
                linkedList.AddFirst(i);
                Assert.AreEqual(i + 1, linkedList.Count);
                Assert.AreEqual(i, linkedList.GetFirst());
            }
            linkedList.Clear();

            for (int i = 0; i < _size; i++)
            {
                linkedList.AddLast(i);
                Assert.AreEqual(i + 1, linkedList.Count);
                Assert.AreEqual(0, linkedList.GetFirst());
            }


            int count = 0;
            while (linkedList.Count > 0)
            {
                Assert.AreEqual(count, linkedList.GetFirst());
                linkedList.RemoveFirst();
                count++;
            }
        }

        [Test]
        public void GetLast()
        {
            var linkedList = new LinkedList<int>(() => new Node<int>());
            for (int i = 0; i < _size; i++)
            {
                linkedList.AddLast(i);
                Assert.AreEqual(i + 1, linkedList.Count);
                Assert.AreEqual(i, linkedList.GetLast());
            }
            linkedList.Clear();

            for (int i = 0; i < _size; i++)
            {
                linkedList.AddFirst(i);
                Assert.AreEqual(i + 1, linkedList.Count);
                Assert.AreEqual(0, linkedList.GetLast());
            }


            int count = 0;
            while (linkedList.Count > 0)
            {
                Assert.AreEqual(count, linkedList.GetLast());
                linkedList.RemoveLast();
                count++;
            }
        }

        [Test]
        public void Get()
        {
            var linkedList = new LinkedList<int>(() => new Node<int>());
            for (int i = 0; i < _size; i++)
            {
                linkedList.AddLast(i);
                Assert.AreEqual(i + 1, linkedList.Count);
                Assert.AreEqual(i, linkedList.Get(i));
            }
        }

    }
}
