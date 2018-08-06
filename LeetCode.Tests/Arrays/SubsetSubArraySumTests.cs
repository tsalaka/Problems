using NUnit.Framework;
using System;
using LeetCode.Arrays;
namespace LeetCode.Tests.Arrays
{
    [TestFixture()]
    public class SubsetSubArraySumTests
    {
        [Test()]
        public void TestCase()
        {
            var sum = new SubsetArraySum();
            Assert.True(sum.SubsetSum(new int[]{2,3,7, 8,10}, 11));
            Assert.True(sum.SubsetSum(new int[] { 2, 3, 7, 8, 10 }, 10));
            Assert.False(sum.SubsetSum(new int[] { 2, 3, 7, 8, 10 }, 14));
            Assert.False(sum.SubsetSum(new int[] { 2, 3, 7, 8, 10 }, 4));
			Assert.True(sum.SubsetSum(new int[] { 2, 7, 3, 8, 10 }, 11));
        }
    }
}
