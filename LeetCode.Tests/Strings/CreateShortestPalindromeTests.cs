using NUnit.Framework;
using System;
using LeetCode.Strings;
using System.Text;

namespace LeetCode.Tests.Strings
{
    [TestFixture()]
    public class CreateShortestPalindromeTests
    {
        [Test()]
        public void TestCase()
        {
            //Assert.AreEqual(16, LengthLongestPath("dir\n        file.txt")); 
            //Assert.AreEqual(20, LengthLongestPath("dir\n\tsubdir1\n\tsubdir2\n\t\tfile.ext"));
            //Assert.AreEqual(12, LengthLongestPath("dir\n    file.txt"));
            //Assert.AreEqual(0, LengthLongestPath("a"));
            var p = new CreateShortestPalindrome();

            Assert.AreEqual("bbabb", p.ShortestPalindrome("abb"));
            Assert.AreEqual("aaacecaaa", p.ShortestPalindrome("aacecaaa"));
            Assert.AreEqual("aacecaa", p.ShortestPalindrome("aacecaa"));
            Assert.AreEqual("dcbabcd", p.ShortestPalindrome("abcd"));
        }

		public int LengthLongestPath(string s)
		{
			var res = new StringBuilder();
			int max = 0;
			int i = 0;
            // use while to handle few directories of files in root directory
            while(i < s.Length){
                if (s[i] == '\n') i++;
                BackTracking(s, ref i, res, 0, ref max);
            }
			return max;
		}

		private void BackTracking(string s, ref int p, StringBuilder res, int level, ref int max)
		{
			bool isFile = false;
			var str = new StringBuilder();
			while (p < s.Length && s[p] != '\n')
			{
				str.Append(s[p]);
				isFile = isFile || s[p] == '.';
                p++;
			}
			if (isFile)
			{
				max = Math.Max(max, res.Length + str.Length);
				return;
			}
			str.Append('/');
			res.Append(str.ToString());
			while (p < s.Length)
			{
				int k = p;
				int currentLevel = 0;
                while (k < s.Length && (s[k] == '\n' || s[k] == '\t'))
				{
					if (s[k] == '\t') currentLevel++;
                    k++;
                }

				if (currentLevel - level == 1)
				{
					p = k;
					BackTracking(s, ref p, res, currentLevel, ref max);
				}
				else
				{
					res.Remove(res.Length - str.Length, str.Length);
					return;
				}
			}
			res.Remove(res.Length - str.Length, str.Length);
		}
    }
}
