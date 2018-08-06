using NUnit.Framework;
using System;
using LeetCode.Strings;

namespace LeetCode.Tests.Strings
{
    [TestFixture()]
    public class LongestPalindromeSubsequenceTests
    {
        [Test()]
        public void TestCase()
        {
            var p = new LongestPalindromeSubsequence();
            Assert.AreEqual(3, p.LongestPalindromeSubseq("babad"));
            Assert.AreEqual(5, p.LongestPalindromeSubseq("agbdba"));
            Assert.AreEqual(4, p.LongestPalindromeSubseq("bbbab"));
            Assert.AreEqual(2, p.LongestPalindromeSubseq("cbbd"));
            Assert.AreEqual(3, p.LongestPalindromeSubseq("aabcb"));
        }
    }
}
