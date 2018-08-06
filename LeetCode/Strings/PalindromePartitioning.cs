using System;
using System.Collections.Generic;
using System.Linq;
namespace LeetCode.Strings
{
    //131
    //Given a string s, partition s such that every substring of the partition is a palindrome.
    //Return all possible palindrome partitioning of s.
    public class PalindromePartitioningMin
    {
		public int MinCut(string s)
		{
			int n = s.Length;
			bool[,] palindromes = new bool[n, n];
			int[] c = new int[n];

			for (int p = 0; p < n; p++)
			{
				int i = 0;
				for (int j = p; j < n; j++)
				{
					if (i == j)
						palindromes[i, j] = true;
					else
					{
						palindromes[i, j] = (Math.Abs(i - j) == 1 || palindromes[i + 1, j - 1]) && (s[i] == s[j]);
						//    Console.WriteLine(palindromes[i,j] +"i="+i+" j="+j);
					}
					i++;
				}
			}

			for (int i = 0; i < n; i++)
			{
				if (palindromes[0, i])
				{
					c[i] = 0;
					continue;
				}
				int minCuts = int.MaxValue;
				for (int j = 1; j <= i; j++)
				{
					//Console.WriteLine("i="+i+" j="+j+" c"+c[j-1]+" p"+palindromes[j, i]);
					if (palindromes[j, i])
						minCuts = Math.Min(minCuts, c[j - 1] + 1);
				}
				c[i] = minCuts;
			}
			return c[n - 1];
		}

    }

    public class PalindromePartitioning
    {
		public IList<IList<string>> Partition(string s)
		{
			var res = new List<IList<string>>();
			var list = new List<string>();
			Dfs(s, 0, list, res);
			return res;
		}

		private void Dfs(string s, int l, List<string> list, List<IList<string>> res)
		{
			if (l == s.Length)
                res.Add(new List<string>(list));

			for (int i = l; i < s.Length; i++)
			{
				if (IsPalindrome(s, l, i))
				{
					list.Add(s.Substring(l, i - l + 1));
					Dfs(s, i + 1, list, res);
					list.RemoveAt(list.Count - 1);
				}
			}
		}

		private bool IsPalindrome(string s, int low, int high)
		{
			while (low < high)
			{
				if (s[low++] != s[high--]) return false;
			}
			return true;
		}
	}
}
