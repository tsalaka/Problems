using NUnit.Framework;
using System;
using System.Collections.Generic;
namespace LeetCode.Tests
{
    [TestFixture()]
    public class QuickSortTests
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
            var sort = new QuickSort();
            sort.Sort(array);
            var expected = new List<int>(array);
            expected.Sort();

            for (int i = 0; i < array.Length; i++)
            {
                Assert.AreEqual(expected[i], array[i]);
            }
        }

		

        [TestCase]
        public void TestSelection()
        {
            var sort = new QuickSelectionSort();
            Assert.AreEqual(5, sort.FindKthLargest(new int[]{3,2,1,5,6,4}, 2));
            Assert.AreEqual(4, sort.FindKthLargest(new int[] { 3, 2, 3, 1, 2, 4, 5, 5, 6 }, 4)); 
            Assert.AreEqual(99, sort.FindKthLargest(new int[] { 99, 99 }, 1));
		}

		[TestCase(15)]
		[TestCase(233)]
		[TestCase(1500)]
		public void TestWithDuplicates(int n)
		{
			var array = new int[n];
			var r = new Random();
			for (int i = 0; i < n; i++)
			{

				array[i] = r.Next(n);
			}
            var sort = new QuickSortWithDuplicates();
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
