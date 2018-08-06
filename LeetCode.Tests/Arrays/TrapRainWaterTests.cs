using NUnit.Framework;
using System;
using LeetCode.Arrays;
using System.Text;
namespace LeetCode.Tests.Arrays
{
    [TestFixture()]
    public class TrapRainWaterTests
    {
        [Test()]
        public void TestCase()
        {
            var t = new TrapRainWater();
            var arr = new int[]{ 6, 4, 2, 0, 3, 2, 0, 3, 1, 4, 5, 3, 2, 7, 5, 3, 0, 1, 2, 1, 3, 4, 6, 8, 1, 3 };
            Assert.AreEqual(83, t.Trap(arr));

            arr = new int[]{0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1};
            Assert.AreEqual(6, t.Trap(arr));
        }
    }
}
