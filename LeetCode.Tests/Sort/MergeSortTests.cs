using NUnit.Framework;
using System;
using System.Collections.Generic;
namespace LeetCode.Tests
{
    [TestFixture()]
    public class MergeSortTests
    {
        [TestCase(15)]
        [TestCase(233)]
        [TestCase(1500)]
        public void TestAscending(int n)
        {
            var array = new int[n];
            var r = new Random();
            for (int i = 0; i < n; i++)
            {

                array[i] = r.Next(n);
            }
            var sort = new MergeSort();
            sort.Sort(array);
            var expected = new List<int>(array);
            expected.Sort();

            for (int i = 0; i < array.Length; i++)
            {
                Assert.AreEqual(expected[i], array[i]);
            }
        }
    }

}
