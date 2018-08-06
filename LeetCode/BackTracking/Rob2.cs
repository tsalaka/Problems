using System;
using System.Collections.Generic;

namespace LeetCode.BackTracking
{
    public class Rob2
    {
		public int Rob(int[] nums)
		{
			int max = 0;
			var memos = new Dictionary<int, int>();
			for (int i = 0; i < nums.Length - 1; i++)
				BackTracking(nums, i, ref max, memos, nums.Length - 1);
			memos.Clear();
			for (int i = 1; i < nums.Length; i++)
				BackTracking(nums, i, ref max, memos, nums.Length);
			return max;
		}

        private void BackTracking(int[] nums, int i, ref int max, Dictionary<int, int> memos, int n)
        {
            if (i == n)
                return;
            if (memos.ContainsKey(i))
            {
                return;
            }
            int m = nums[i];
            for (int j = i + 2; j < n; j++)
            {
                if (!memos.ContainsKey(j))
                    BackTracking(nums, j, ref max, memos, n);
                m = Math.Max(nums[i] + memos[j], m);
            }

            memos.Add(i, m);
            max = Math.Max(max, m);
        }
    }
}
