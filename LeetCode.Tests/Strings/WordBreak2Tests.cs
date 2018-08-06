using NUnit.Framework;
using System;
using LeetCode.Strings;
using System.Collections.Generic;

namespace LeetCode.Tests.Strings
{
    [TestFixture()]
    public class WordBreak2Tests
    {
        [Test()]
        public void TestCase()
        {
            var w = new WordBreak2();
            Assert.AreEqual(2, w.WordBreak("catsanddog", new List<string>() { "cats", "cat", "sand", "dog", "and" }).Count);
            Assert.AreEqual(4, w.WordBreak("aaa", new List<string>() { "a", "aa", "aaa" }).Count);
            Assert.AreEqual(1, w.WordBreak("ab", new List<string>() { "a", "b", "sand", "dog", "and" }).Count);
            Assert.AreEqual(0, w.WordBreak("ab", new List<string>() { "cats", "cat", "sand", "dog", "and" }).Count);
            Assert.AreEqual(0, w.WordBreak("", new List<string>() { "cats", "cat", "sand", "dog", "and" }).Count);
        }
    }
}
