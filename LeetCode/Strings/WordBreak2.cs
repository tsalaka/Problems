using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Strings
{
    public class WordBreak2
    {
		private Dictionary<int, List<string>> _dic;

		public IList<string> WordBreak(string s, IList<string> wordDict)
		{
            if (String.IsNullOrEmpty(s))
                return new List<string>();
            _dic = new Dictionary<int, List<string>>();
            s.Remove(0);
            return Find(0, s, wordDict);
		}

		private List<string> Find(int start, string s, IList<string> wordDict)
		{
			if (_dic.ContainsKey(start))
			{
				return _dic[start];
			}	
			var res = new List<string>();
			if (start == s.Length)
			{
                res.Add(string.Empty);
                return res;
			}
			
           	for (int end = start; end < s.Length; end++)
			{
				var word = s.Substring(start, end - start + 1);
				if (wordDict.Contains(word))
				{
					var list = Find(end + 1, s, wordDict);
                    foreach(var w in list){
                        res.Add(string.Format("{0}{2}{1}", word, w, w != string.Empty ? " " : string.Empty));
                    }
				}
			}

            _dic.Add(start, res);
            return res;
		}
    }
}
