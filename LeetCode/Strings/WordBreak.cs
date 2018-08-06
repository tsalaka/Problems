using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Strings
{
    public class WordBreak
    {
		public bool Check(string s, IList<string> wordDict)
		{
			var notFound = new HashSet<int>();
			var dic = new HashSet<string>(wordDict);
			return Dfs(s, 0, dic, notFound);
		}

		private bool Dfs(string s, int start, HashSet<string> dic, HashSet<int> notFound)
		{
			if (start == s.Length) return true;
			if (notFound.Contains(start)) return false;

			for (int i = start; i < s.Length; i++)
			{
				if (dic.Contains(s.Substring(start, i - start + 1)) && Dfs(s, i + 1, dic, notFound))
					return true;
			}

            notFound.Add(start);
			return false;
		}
    }
}
