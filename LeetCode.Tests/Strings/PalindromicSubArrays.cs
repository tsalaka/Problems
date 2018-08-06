using NUnit.Framework;
using System;
using LeetCode.Strings;

namespace LeetCode.Tests.Strings
{
    [TestFixture()]
    public class PalendromicSubArraysTests
    {
        [Test()]
        public void TestCase()
        {
            var p = new PalindromicSubArrays();
            Assert.AreEqual(7, p.GetResult("babad"));
            Assert.AreEqual(11, p.GetResult("abaaba"));
            Assert.AreEqual(16, p.GetResult("abababa"));
            Assert.AreEqual(16, p.GetResult("abacdfgdcabba"));
        }
    }
}
