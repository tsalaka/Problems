using NUnit.Framework;
using System;
using LeetCode.Strings;

namespace LeetCode.Tests.Strings
{
    [TestFixture()]
    public class RemoveInvalidParenthesesTests
    {
        [Test()]
        public void TestCase()
        {
            var p = new RemoveInvalidParentheses();
            Assert.AreEqual(2, p.Remove("()())()").Count);
        }
    }
}
