using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Strings
{
    //301
    public class RemoveInvalidParentheses
    {
		public IList<string> Remove(string s)
		{
			var res = new List<string>();
			if (string.IsNullOrEmpty(s)) return res;
			var list = new List<List<string>>();
			int c = 0;
			int lastInvalidCloseInd = -1;
			for (int i = 0; i < s.Length; i++)
			{
				if (s[i] == '(') c++;
				if (s[i] == ')') c--;
				if (c < 0)
				{
					//skip invalid ')' which are going one by one, ex "()))()"
					if (i != lastInvalidCloseInd - 1)
						list.Add(RemoveParentheses(s, lastInvalidCloseInd + 1, i, ')', false));
					lastInvalidCloseInd = i;
					c = 0;
				}
			}
            if (c > 0)
                list.Add(RemoveParentheses(s, lastInvalidCloseInd + 1, s.Length - 1, '(', true));
           // else if()
                //put end of string
             //   list.Add(new List<string> { s.Substring(lastInvalidCloseInd + 1, s.Length - lastInvalidCloseInd) });

			if (list.Count != 0)
				res = list[0];
			//combine strings
			for (int i = 1; i < list.Count; i++)
			{
				for (int j = 0; j < res.Count; j++)
				{
					foreach (var p in list[i])
						res.Add(res[j] + p);
				}
			}
			return res;
		}

		private bool IsValid(string s)
		{
			int c = 0;
			for (int i = 0; i < s.Length; i++)
			{
				if (s[i] == '(') c++;
				if (s[i] == ')') c--;
			}
			return c == 0;
		}

		private List<string> RemoveParentheses(string s, int start, int end, char bracket, bool checkIsValid)
		{
			var res = new List<string>();
            int lastRemovedInd = -1;
			for (int i = start; i <= end; i++)
			{
				if (s[i] == bracket && i-1 != lastRemovedInd)
				{
					var builder = new StringBuilder();
					builder.Append(s.Substring(start, i - start));
					if (i + 1 <= end)
						builder.Append(s.Substring(i + 1, end - i));
					var str = builder.ToString();
                    if (!checkIsValid || (IsValid(str)))
                    {
                        res.Add(str);
                        lastRemovedInd = i;
                    }
				}
			}
			return res;
		}
    }
}
