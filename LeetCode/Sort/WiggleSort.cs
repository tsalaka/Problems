using System;
using System.Collections;
namespace LeetCode.Sort
{
    //324
    //Given an unsorted array nums, reorder it such that nums[0] < nums[1] > nums[2] < nums[3]..
    public class WiggleSort
    {
        public void Sort(int[] nums)
        {
			int n = nums.Length;
			if (n == 1) return;
			var temp = new int[n];
			for (int k = 0; k < n; k++)
			{
				temp[k] = nums[k];
			}

            int medianInd = (n % 2 == 1 ? n/2 : (n + 1) / 2);
			int median = GetMedian(temp, 0, n - 1, medianInd);

			int l = 0;
			int h = n - 1;
			int m = 0;
			//3,3,2,2,2,2,1,1 //descendant order because if we  out in ascendant order result after choosing nums from left and right
			//one by one will be: temp=[1,1,2,2,2,2,3,3], nums=[1,2,1,2,2,3,2,3]
			while (m <= h)
			{
				if (temp[m] < median)
					Exchange(temp, m, h--);
				else if (temp[m] > median)
					Exchange(temp, m++, l++);
				else m++;
			}

			int i = 0;
			int j = medianInd;
			for (int p = 0; p < n; p++)
			{
				if (p % 2 == 1 && i < medianInd)
					nums[p] = temp[i++];
				else
					nums[p] = temp[j++];
			}
		}

		private int GetMedian(int[] nums, int l, int h, int medianInd)
		{
			var ind = Partition(nums, l, h);
			if (ind == medianInd) return nums[ind];

			if (ind < medianInd)
				return GetMedian(nums, ind + 1, h, medianInd);
			return GetMedian(nums, l, ind - 1, medianInd);
		}

		private int Partition(int[] nums, int l, int h)
		{
			int lo = l;
			int i = l;
			int j = h + 1;
			while (true)
			{
				while (++i < h)
				{
					if (nums[i] > nums[lo]) break;
				}

				while (--j > l)
				{
					if (nums[j] < nums[lo]) break;
				}
				if (i >= j) break;
				Exchange(nums, i, j);
			}

			Exchange(nums, j, lo);
			return j;
		}

		private void Exchange(int[] nums, int i, int j)
		{
			var temp = nums[i];
			nums[i] = nums[j];
			nums[j] = temp;
		}
    }
}