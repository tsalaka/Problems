using System;
namespace LeetCode.DynamicProgramming
{
	/// <summary>
	/// 276
	/// There is a fence with n posts, each post can be painted with one of the k colors.
	///You have to paint all the posts such that no more than two adjacent fence posts have the same color.
	///Return the total number of ways you can paint the fence.
	/// </summary>

	//same - N of ways when colors of two last posts are the same
	//diff - N of ways when colors of two last posts are different
	//N = 1:
	//    diff = k
	//    same = 0
	//    total = k
	//N = 2:
	//    diff = k*(k-1) - second post can be the same color as first one
	//    same = k
	//    total = diff + same = k*(k-1) + k
	//N = 3:
	//    diff = (k*(k-1)+k)*(k-1) - ways to get diff posts for k-1(diff means no same last two posts) * (k-1) - still last post can't be teh same color as previous one
	//    same = k*(k-1) - k -  ways to color first post, k-1 ways to color last two posts with the same color(but no the same as first  post)
	//    total = (k*(k-1)+k)*(k-1) + k*(k-1)

	//Formula:
	//    same[i] = diff[i-1];
	//    total[i] = diff[i] + same[i] = diff[i-1] + diff[i-2];
	//    diff[i] = (diff[i-1] + same[i-1])*(k-1) = (diff[i-1] + diff[i-2])*(k-1) = total[i-1]*(k-1);

	public class Solution
	{
		public int NumWays(int n, int k)
		{
			if (n == 0 || k == 0 || (k == 1 && n > 2)) return 0;
			var dp = new int[n + 1];
			dp[1] = k;
			var diff = k;
			var same = 0;
			for (int i = 2; i <= n; i++)
			{
				same = diff;
				diff = dp[i - 1] * (k - 1);
				dp[i] = diff + same;
			}
			return dp[n];
		}
	}
}
