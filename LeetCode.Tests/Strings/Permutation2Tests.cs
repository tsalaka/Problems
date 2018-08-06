using NUnit.Framework;
using System;
using LeetCode.Strings;

namespace LeetCode.Tests.Strings
{
    [TestFixture()]
    public class Permutation2Tests
    {
        [Test()]
        public void TestCase()
        {
            var per = new Permutation2();
            Assert.AreEqual(3, per.PermuteUnique(new int[]{1,1,2}).Count);
        }
    }
}
