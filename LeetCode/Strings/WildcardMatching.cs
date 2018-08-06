using System;
using System.Collections.Generic;

namespace LeetCode.Strings
{
    public class WildcardMatching
    {
		public bool IsMatch(string s, string p)
		{
            if (s.Length == 0) return IsEmptyPattern(p);
            var memos = new Dictionary<string, IList<int>>();
			return IsMatch(s, 0, p, memos);
		}

		private bool IsMatch(string s, int start, string p, Dictionary<string, IList<int>> memos)
		{
			if (start == s.Length)
				return IsEmptyPattern(p);
			var patterns = GetNextPatterns(s[start], p);
            if (!patterns.Item1) {
				if (memos.ContainsKey(p))
					memos[p].Add(start);
				else memos.Add(p, new List<int> { start });
                return false;
            }
            foreach (var pattern in patterns.Item2)
            { 
                if (memos.ContainsKey(pattern) && memos[pattern].Contains(start + 1))
                    return false;
				if (IsMatch(s, start + 1, pattern, memos)) return true;
            }

			return false;
		}

		private bool IsEmptyPattern(string p)
		{
			int i = 0;
			while (i < p.Length)
			{
				if (p[i++] != '*') return false;
			}
			return true;
		}

        private Tuple<bool, IList<string>> GetNextPatterns(char c, string p)
        {
            if (String.IsNullOrEmpty(p)) return new Tuple<bool, IList<string>>(false, null);
            bool found = false;
            var list = new List<string>();
            int i = 0;
            if (p[i] == '*')
            {
                found = true;
                list.Add(p);
            }
            while (i < p.Length && p[i] == '*') i++;
            if (i == p.Length) return new Tuple<bool, IList<string>>(found, list);
            if (p[i] == '?')
            {
                list.Add(i == p.Length-1 ? string.Empty : p.Substring(i + 1, p.Length - (i + 1)));
                found = true;
            }
            else if (p[i] == c)
            {
                list.Add(i == p.Length-1 ? string.Empty : p.Substring(i + 1, p.Length - (i + 1)));
                found = true;
            }
            return new Tuple<bool, IList<string>>(found, list);
		}
    }
}
