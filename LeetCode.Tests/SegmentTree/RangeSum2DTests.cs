using System;
using NUnit.Framework;
using LeetCode.SegmentTree;

namespace LeetCode.Tests.SegmentTree
{
    [TestFixture]
    public class RangeSum2DTests
    {
        [TestCase]
        public void Tests()
        {
            var matrix = new int[,] { { 3, 0, 1, 4, 7}, { 5, 6, 3, 2, 1 }, { 1, 2, 0, 1, 3 }, { 8, 4, 2, 0, 2 } };

            RangeSum2D sum = new RangeSum2D(matrix);
            Assert.AreEqual(11, sum.SumRegion(1,1,2,2));
            sum.Update(2, 1, 4);
            Assert.AreEqual(13, sum.SumRegion(1, 1, 2, 2));
            Assert.AreEqual(16, sum.SumRegion(1, 1, 2, 3));
            Assert.AreEqual(24, sum.SumRegion(0, 0, 1, 3));
            Assert.AreEqual(12, sum.SumRegion(1, 1, 1, 4));
            sum.Update(1,4,0);
            sum.Update(1, 1, 0);
			sum.Update(1, 2, 0);
            sum.Update(1, 3, 0);
			Assert.AreEqual(0, sum.SumRegion(1, 1, 1, 4));
        }
    }
}
