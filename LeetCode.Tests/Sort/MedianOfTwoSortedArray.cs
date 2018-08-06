using NUnit.Framework;
using System;
using LeetCode.Sort;
using System.Collections.Generic;

namespace LeetCode.Tests.Sort
{
    [TestFixture()]
    public class MedianOfTwoSortedArrayTests
    {
        [Test()]
        public void TestCase()
        {
            FindClosestElements(new int[]{1,2}, 1,1);
            NumTrees(4);

            var m = new MedianOfTwoSortedArray();
            Assert.AreEqual(6, m.FindMedianSortedArrays(new int[5] { 4, 5, 6, 8, 9 }, new int[] { }));
            Assert.AreEqual(5.5, m.FindMedianSortedArrays(new int[] { }, new int[4] { 4, 5, 6, 8, }));
            Assert.AreEqual(4.5, m.FindMedianSortedArrays(new int[5] { 4, 5, 6, 8, 9 }, new int[3] { 1, 2, 3 }));
            Assert.AreEqual(4, m.FindMedianSortedArrays(new int[4] { 4, 5, 6, 8 }, new int[3] { 1, 2, 3 }));
            Assert.AreEqual(7, m.FindMedianSortedArrays(new int[5] { 2, 5, 6, 8, 9 }, new int[3] { 1, 8, 10 }));
        }

		public IList<int> FindClosestElements(int[] arr, int k, int x)
		{
			var res = new List<int>();
			if (arr.Length == 0) return res;
			int ind = BinarySearch(arr, x, 0, arr.Length - 1);

			int i = ind;
			int j = ind + 1;
			while (j - i - 1 < k)
			{
				if (i >= 0 && (j == arr.Length || Math.Abs(x - arr[i]) <= Math.Abs(x - arr[j])))
					i--;
				else if (j < arr.Length)
					j++;
				else break;
			}
			for (int p = i + 1; p < j; p++)
				res.Add(arr[p]);
			return res;
		}

		private int BinarySearch(int[] arr, int x, int low, int high)
		{
			if (low >= high) return low;
			int mid = low + (high - low) / 2;
			if (arr[mid] == x) return mid;

			if (arr[mid] > x) return BinarySearch(arr, x, low, mid - 1);
			return BinarySearch(arr, x, mid + 1, high);
		}

		public int NumTrees(int n)
        {
            if (n == 0) return 0;
            if (n == 1) return 1;

            int[] arr = new int[n + 1];
            arr[1] = 1;
            for (int i = 2; i <= n; i++)
            {
                arr[i] = arr[i - 1] * 2 + arr[i - 2] * (i - 2);
            }

            return arr[n];
        }

    }
}
