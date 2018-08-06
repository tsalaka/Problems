using System;

namespace LeetCode.Strings
{
	// 409
    // Given a string which consists of lowercase or uppercase letters, 
    // find the length of the longest palindromes that can be built with those letters.
    // This is case sensitive, for example "Aa" is not considered a palindrome here.
	public class BuildLongestPalindrome
	{
		public int LongestPalindrome(string s)
		{
			var arr = new int[128];
			for (int i = 0; i < s.Length; i++)
			{
				arr[s[i]] += 1;
			}
			var count = 0;
			var wasOddCount = false;
			for (var i = 0; i < arr.Length; i++)
			{
				if (arr[i] % 2 != 0)
				{
					if (wasOddCount)
						count += arr[i] - 1;
					else
					{
						count += arr[i];
						wasOddCount = true;
					}
				}
				else
					count += arr[i];
			}
			return count;
		}
	}
}
