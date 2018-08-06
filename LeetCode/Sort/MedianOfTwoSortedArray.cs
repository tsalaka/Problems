using System;
namespace LeetCode.Sort
{
   public class MedianOfTwoSortedArray
	{
		public double FindMedianSortedArrays(int[] nums1, int[] nums2)
		{
			// we should divide each array into two parts 
			// first halfs should contain values less than valus in second halfs
			if (nums1.Length <= nums2.Length)
				return GetMedian(nums1, nums2, 0, nums1.Length);
			return GetMedian(nums2, nums1, 0, nums2.Length);
		}

		private double GetMedian(int[] nums1, int[] nums2, int start, int end)
		{
			int position1 = start + (end - start) / 2; //it is not index;
													   // (num1 + num2 + 1)/2 should be less than second part
			int position2 = (nums1.Length + nums2.Length + 1) / 2 - position1;

			int lastPartition1Num1 = GetPartitionIndex(position1, nums1);
			int lastPartition1Num2 = GetPartitionIndex(position2, nums2);

			int firstPartition2Num1 = GetPartitionIndex(position1 + 1, nums1);
			int firstPartition2Num2 = GetPartitionIndex(position2 + 1, nums2);

			//found right splits
			if (lastPartition1Num1 <= firstPartition2Num2
			   && lastPartition1Num2 <= firstPartition2Num1)
			{
				//median is mean of two middle elements;
				if ((nums1.Length + nums2.Length) % 2 == 0)
					return (double)(Math.Max(lastPartition1Num1, lastPartition1Num2)
							+ Math.Min(firstPartition2Num1, firstPartition2Num2)) / 2;
				//else median if middle element(contains in first partition)
				return (double)Math.Max(lastPartition1Num1, lastPartition1Num2);
			}

			if (lastPartition1Num1 > firstPartition2Num2)
			{
				return GetMedian(nums1, nums2, start, position1 - 1);
			}
			return GetMedian(nums1, nums2, position1 + 1, end);
		}

		private int GetPartitionIndex(int position, int[] nums)
		{
			if (position == 0)
				return Int32.MinValue;
			if (position > nums.Length)
				return Int32.MaxValue;
			return nums[position - 1];
		}
    }
}
