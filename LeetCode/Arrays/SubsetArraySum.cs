using System;
namespace LeetCode.Arrays
{
    //given an array
    //check if it contains numbers sum of that gives target number
    public class SubsetArraySum
    {
		public bool SubsetSum(int[] nums, int target)
		{
			if (nums.Length == 0) return target == 0;
            Array.Sort(nums);
			bool[,] dp = new bool[nums.Length, target + 1];
			for (int i = 0; i < dp.GetLength(0); i++)
				dp[i, 0] = true;
			dp[0, nums[0]] = true;
			for (int i = 1; i < nums.Length; i++)
			{
				for (int j = 1; j <= target; j++)
				{
                    if (dp[i - 1, j]) dp[i, j] = true;
                    else if (j - nums[i] >= 0)
                        dp[i, j] = dp[i - 1, j] ? true : dp[i - 1, j - nums[i]];
				}
			}
			return dp[nums.Length - 1, target];
		}
    }
}
