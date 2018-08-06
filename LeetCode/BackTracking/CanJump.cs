using System;
using System.Collections.Generic;

namespace LeetCode.BackTracking
{
	//55
	//Given an array of non-negative integers, you are initially positioned at the first index of the array.//
	//Each element in the array represents your maximum jump length at that position.
	//Determine if you are able to reach the last index.
    //Input: [2,3,1,1,4]
    //Output: true
    //Explanation: Jump 1 step from index 0 to 1, then 3 steps to the last index.
	public class CanJumps
    {
		public bool CanJump(int[] nums)
		{
			if (nums.Length == 0) return true;
			int lastIndex = nums.Length - 1;
			for (int i = nums.Length - 1; i >= 0; i--)
			{
				if (i + nums[i] >= lastIndex)
					lastIndex = i;

			}
			return lastIndex == 0;
		}
    }
}
