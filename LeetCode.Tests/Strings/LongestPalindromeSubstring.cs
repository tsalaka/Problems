using NUnit.Framework;
using System;
using LeetCode.Strings;

namespace LeetCode.Tests.Strings
{
    [TestFixture()]
    public class LongestPalindromeSubstringTests
    {
        [Test()]
        public void TestCase()
        {
            var p = new LongestPalindromeSubstring();
            Assert.AreEqual("bab", p.GetResult("babad"));
            Assert.AreEqual("abcbabcba", p.GetResult("babcbabcbaccba"));
            Assert.AreEqual("abaaba", p.GetResult("abaaba"));
            Assert.AreEqual("abababa", p.GetResult("abababa"));
            Assert.AreEqual("abcbabcbabcba", p.GetResult("abcbabcbabcba"));
            Assert.AreEqual("geeksskeeg", p.GetResult("forgeeksskeegfor"));
            Assert.AreEqual("abba", p.GetResult("abacdfgdcabba"));
        }
    }
}
