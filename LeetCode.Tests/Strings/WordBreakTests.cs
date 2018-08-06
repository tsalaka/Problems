using NUnit.Framework;
using System;
using LeetCode.Strings;
using System.Collections.Generic;

namespace LeetCode.Tests.Strings
{
    [TestFixture()]
    public class WordBreakTests
    {
        [Test()]
        public void TestCase()
        {
			var b = new WordBreak();
            Assert.True(b.Check("catsanddog", new List<string>() { "cats", "cat", "sand", "dog", "and" }));
            Assert.True(b.Check("aaaaaaa", new List<string>() { "aaaa", "aaa", "aa" }));
            Assert.True(b.Check("ab", new List<string>() { "a", "b" }));
        }
    }
}