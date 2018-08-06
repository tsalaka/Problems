using System;
using System.Collections.Generic;

namespace LeetCode.BackTracking
{
    //55
    public class CanJumps
    {
		public bool CanJump(int[] nums)
		{
            var list = new List<int>();
            list.Insert(list.Count-1, 2);
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
