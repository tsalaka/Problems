using NUnit.Framework;
using System;
using LeetCode.Strings;

namespace LeetCode.Tests.Strings
{
    [TestFixture()]
    public class RegexMatchingTests
    {
        [Test()]
        public void TestCase()
        {
            var r = new RegexMatching();
            Assert.False(r.IsMatch("bbba", ".*b"));
            Assert.True(r.IsMatch("aa", "a*.*a"));
            Assert.True(r.IsMatch("aa", "a*"));
            Assert.False(r.IsMatch("ab", ".c*"));
            Assert.True(r.IsMatch("ab", ".*"));
            Assert.True(r.IsMatch("a", "ab*"));
            Assert.False(r.IsMatch("mississippi", "mis*is*p*."));
            Assert.True(r.IsMatch("aa", "aa*.*a"));
            Assert.True(r.IsMatch("aab", "c*a*b"));
            Assert.False(r.IsMatch("aa", "a"));
        }
    }
}
