using NUnit.Framework;
using System;
using LeetCode.Maths;

namespace LeetCode.Tests.Maths
{
    [TestFixture()]
    public class FractionToDecimalTests
    {
        [Test()]
        public void TestCase()
        {
            var f = new FractionToDecimal();
            Assert.AreEqual("0.0000000004656612873077392578125", f.Convert(-1, -2147483648));
            Assert.AreEqual("-2147483648", f.Convert(-2147483648, 1));
        }
    }
}
