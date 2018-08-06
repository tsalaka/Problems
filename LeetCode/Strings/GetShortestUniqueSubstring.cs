using System;
using System.Collections.Generic;

namespace LeetCode.Strings
{
    public class ShortestUniqueSubstring
    {
		public static string GetShortestUniqueSubstring(char[] arr, string str)
		{
			var dic = new Dictionary<char, int>();
			for (int i = 0; i < arr.Length; i++)
			{
				dic.Add(arr[i], 1);
			}
			var n = arr.Length;
			var count = 0;
			string minSubstr = string.Empty;

			int end = 0;
			int start = 0;
			while (end < str.Length)
			{
				if (dic.ContainsKey(str[end]))
				{
					dic[str[end]]--;
					if (dic[str[end]] == 0)
						count++;
				}
				while (count == n)
				{
					if (dic.ContainsKey(str[start]))
					{
						dic[str[start]]++;
						if (dic[str[start]] == 1) count--;
					}
					start++;
					var currentSubstr = str.Substring(start - 1, end - (start - 1) + 1);
					if (string.IsNullOrEmpty(minSubstr) || minSubstr.Length > currentSubstr.Length)
					{
						minSubstr = currentSubstr;
						if (minSubstr.Length == n) return minSubstr;
					}
				}

				end++;
			}
			return minSubstr;
		}
    }
}
