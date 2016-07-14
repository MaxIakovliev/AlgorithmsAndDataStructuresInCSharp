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
        [Test]
        public void TestLinkedListAdd()
        {
            var linkedList = new DataStructures.Lists.LinkedList<bool>(() => new DataStructures.Lists.Node<bool>());
            var size = 100;
            for(int i=0; i<size; i++)
            {
                linkedList.Add(true);
            }

            Assert.AreEqual(size, linkedList.Count);
        }


        [Test]
        public void TestLinkedListAddFirst()
        {
            var linkedList = new DataStructures.Lists.LinkedList<int>(() => new DataStructures.Lists.Node<int>());
            var size = 100;
            for (int i = 0; i < size; i++)
            {
                linkedList.AddFirst(i);
            }

            Assert.AreEqual(size, linkedList.Count);

            for (int i = 0; i < size; i++)
            {
                Assert.AreEqual(size-1-i, linkedList.Get(i));
            }


        }

    }
}
