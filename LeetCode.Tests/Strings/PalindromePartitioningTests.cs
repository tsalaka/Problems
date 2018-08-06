using NUnit.Framework;
using System.Linq;
using System;
using LeetCode.Strings;
using System.Collections.Generic;

namespace LeetCode.Tests.Strings
{
    [TestFixture()]
    public class PalendromePartioningTests
    {

		[Test()]
		public void TestCase2()
		{
            int x = 10;
			
			int reverseNumber = 0;
			int i = 0;
			while (x > 0)
			{
				int reminder = x % 10;
				x = x / 10;
				reverseNumber += Convert.ToInt32((reminder == 0 && i != 0 ? 1 : reminder) * Math.Pow(10, i++));
			}


			var p = new PalindromePartitioning();
            var result = p.Partition("bb");
            Assert.AreEqual(new List<string>{ "bb"}, result[1]);
            Assert.AreEqual(new List<string> { "b","b" }, result[0]);

            result = p.Partition("fff");
            Assert.NotNull(result.Single(s=>s.SequenceEqual(new List<string>{"f","f","f"})));
            Assert.NotNull(result.Single(s => s.SequenceEqual(new List<string> { "ff", "f" })));
            Assert.NotNull(result.Single(s => s.SequenceEqual(new List<string> { "f", "ff" })));
            Assert.NotNull(result.Single(s => s.SequenceEqual(new List<string> { "fff" })));

			result = p.Partition("aab");
			Assert.AreEqual("a", result[0][0]);
			Assert.AreEqual("a", result[0][1]);
			Assert.AreEqual("b", result[0][2]);
			Assert.AreEqual("aa", result[1][0]);
			Assert.AreEqual("b", result[1][1]);

			result = p.Partition("abcbm");
			Assert.AreEqual("a", result[0][0]);
			Assert.AreEqual("b", result[0][1]);
			Assert.AreEqual("c", result[0][2]);
			Assert.AreEqual("b", result[0][3]);
			Assert.AreEqual("m", result[0][4]);

			Assert.AreEqual("a", result[1][0]);
			Assert.AreEqual("bcb", result[1][1]);
			Assert.AreEqual("m", result[1][2]);
		}

		[Test()]
		public void MinSplitsCountTests()
		{
			var p = new PalindromePartitioningMin();
            Assert.AreEqual(1,p.MinCut("aab"));
            Assert.AreEqual(2, p.MinCut("abcbm"));
            Assert.AreEqual(0, p.MinCut("aaa"));
		}
    }
}
