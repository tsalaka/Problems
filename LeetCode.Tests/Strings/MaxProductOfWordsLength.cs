using System;
using NUnit.Framework;
using LeetCode.Strings;

namespace LeetCode.Tests.Strings
{
    [TestFixture]
    public class MaxProductOfWordsLengthTests
    {
        [TestCase]
        public void Test()
        {
            var pr = new MaxProductOfWordsLength();
            var words = new string[] { "abcw", "baz", "foo", "bar", "xtfn", "abcdef" };
            //var result = pr.MaxProduct(words);
            //Assert.AreEqual(16, result);

            words = new string[] { "eae", "ea", "aaf", "bda", "fcf", "dc", "ac", "ce", "cefde", "dabae" };
			var result = pr.MaxProduct(words);
            Assert.AreEqual(15, result);
        }
    }
}
