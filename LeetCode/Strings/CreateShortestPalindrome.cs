using System;
using System.Text;

namespace LeetCode.Strings
{
    public class CreateShortestPalindrome
    {
		public string ShortestPalindrome(string s)
		{
            if (string.IsNullOrEmpty(s)) return string.Empty;
			int center = 1;
			int endRight = 2;
			int left;
			int diff; //between endRight and right
			int maxPalindrome = 1; //the longest palindrome starts from beginning
			int n = 2 * s.Length + 1;
			int[] p = new int[n];
            p[0] = 0;
            p[1] = 1;

			for (int right = 2; right < n; right++)
			{
				left = center * 2 - right;
				diff = endRight - right;

				if (diff > 0)
					p[right] = Math.Min(p[left], diff);

				int rp = right + p[right] + 1;
				int lp = right - p[right] - 1;
				while (rp < n && lp >= 0 &&
					  (rp % 2 == 0 || s[rp / 2] == s[lp / 2]))
				{
					p[right]++;
					lp = right - p[right] - 1;
					rp = right + p[right] + 1;
				}

				//if palindrome starts from first character
				if (maxPalindrome < p[right] && right - p[right] == 0)
				{
					maxPalindrome = p[right];
				}

				if (right + p[right] > endRight)
				{
					center = right;
					endRight = center + p[right];
				}
			}

			var res = new StringBuilder();
			for (int i = 1; i <= s.Length - maxPalindrome; i++)
				res.Append(s[s.Length - i]);
			res.Append(s);

			return res.ToString();
		}
    }
}
