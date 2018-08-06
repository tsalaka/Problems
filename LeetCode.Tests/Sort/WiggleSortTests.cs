using NUnit.Framework;
using System;
using LeetCode.Sort;
using LeetCode.Trees;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Tests.Sort
{
    [TestFixture()]
    public class WiggleSortTests
	{
        [Test()]
        public void TestCase()
        {
            var nums = new int[] { 1, 2, 3, 4, 5, 6, 7 };
            int k = 3;

			if (nums.Length == 0) return;
			//skip unnecessary rounds if k > nums.Length 
			k = k % nums.Length;
			
			int i = 0;
			var diff = Math.Abs((nums.Length - k) - k);
		    int step = Math.Min(diff, k);
			while (i < nums.Length - k)
			{
				int j = nums.Length - k;
				while (j < nums.Length)
				{
					var temp = nums[j];
					nums[j++] = nums[i];
					nums[i++] = temp;
				}
                k = step;
			}
		
            var sort = new WiggleSort();
            var arr = new int[] {1, 5, 1, 1, 6, 4 };
            sort.Sort(arr);
            Check(arr);
			arr = new int[] { 2, 3, 3, 2, 2, 2, 1, 1 };
			sort.Sort(arr);
			Check(arr);
			
			arr = new int[] { 5, 3, 1, 2, 6, 7, 8, 5, 5 };
			sort.Sort(arr);
			Check(arr);

			arr = new int[] { 1, 2, 1, 2, 1, 1, 2, 2, 1 };
			sort.Sort(arr);
			Check(arr);

			arr = new int[] { 1, 2, 2, 1, 2, 1, 1, 1, 1, 2, 2, 2 };
			sort.Sort(arr);
			Check(arr);

            arr = new int[] { 2, 1, 6, 4, 5, 7, 3 };
            sort.Sort(arr);
            Check(arr);

            arr = new int[] { 3, 4, 6, 1, 5, 8 };
            sort.Sort(arr);
            Check(arr);

            arr =  new int[]{1, 5, 1, 1, 6, 4 };
            sort.Sort(arr);
            Check(arr);

			arr = new int[] { 1 };
			sort.Sort(arr);
			Check(arr);

			arr = new int[] { 1, 5 };
			sort.Sort(arr);
			Check(arr);
        }

		[Test()]
		public void TestCase2()
		{
			var sort = new WiggleSort2();
			var arr = new int[] { 5, 6, 3, 6, 7, 4 };
			sort.Sort(arr);
			Check(arr);

			sort.Sort(arr);
            Check(arr);
		}

        private void Check(int[] arr){
			bool isLess = false;
			for (int i = 0; i < arr.Length; i++)
			{
				if (i == 0)
					continue;
				if (isLess)
					Assert.True(arr[i] < arr[i - 1]);
				else
					Assert.True(arr[i] > arr[i - 1]);
				isLess = !isLess;
			}
        }

    }
}
