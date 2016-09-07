using NUnit.Framework;
using O3.Algorithms.Sort;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Algorithms.Sort
{
    [TestFixture]
    public class SelectionTest
    {
        private List<int[]> _data;

        private Random _rnd = new Random();

        [SetUp]
        public void Init()
        {
            _data = new List<int[]>();
            int size = _rnd.Next(10, 100);
            for (int i = 0; i < size; i++)
            {
                var list = new int[size];
                for (int j = 0; j < size; j++)
                {
                    list[j] = _rnd.Next(0, 1000);
                }
                _data.Add(list);
            }
        }

        [Test]
        public void TestSelectionSort()
        {
            ISort<int> p = new Selection<int>();

            for (int i = 0; i < _data.Count(); i++)
            {
                int min = Int32.MinValue;
                p.Sort(_data[i]);
                for (int j = 0; j < _data[i].Length; j++)
                {
                    Assert.True(min <= _data[i][j]);
                    min=_data[i][j];
                    Console.Write("{0} ", _data[i][j]);

                }
                Console.WriteLine();
            }
        }
    }
}
