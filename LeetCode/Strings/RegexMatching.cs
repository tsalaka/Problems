using System;
using System.Collections.Generic;

namespace LeetCode.Strings
{
    public class RegexMatching
    {
		public bool IsMatch(string s, string p)
		{
            return BackTracking(s, 0, p);
		}

		private bool BackTracking(string s, int start, string p)
		{
			if (start == s.Length)
                return IsEmptyStringMatch(p);
            
			var patterns = GetNextPatters(s[start], p);
            if (patterns.Count == 0)
            return false;
			foreach (var pattern in patterns)
			{
				if (BackTracking(s, start + 1, pattern))
					return true;
			}
			
			return false;
		}

        private bool IsEmptyStringMatch(string p){
            int n = p.Length;
            int i = 0;
			while (i < n - 1 && p[i + 1] == '*')
			{
				i += 2;
			}
            return i > n - 1;
        }

		private IList<string> GetNextPatters(char c, string p)
		{
			var list = new List<string>();
			if (String.IsNullOrEmpty(p))
				return list;
			var n = p.Length;
			int i = 0;

            // .*.*ab or c*.*a*b or a*.*b (where char = a)
			while (i < n - 1 && p[i + 1] == '*')
			{
                if (p[i] == c || p[i] == '.')
                {
                    list.Add(p.Substring(i, n - i));
                }
                
                i += 2;
			}

            if (i < n && (p[i] == c || p[i] == '.'))
			{
                if (i++ < n)
                    list.Add(p.Substring(i, n - i));
                else
                    list.Add(string.Empty);
			}
			return list;
		}
    }
}