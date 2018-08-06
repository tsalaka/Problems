using System;
using LeetCode.BackTracking;
using NUnit.Framework;

namespace LeetCode.Tests.BackTracking
{
    [TestFixture]
    public class CanJumpTests
    {
        [TestCase]
        public void Test()
        {
            var jump = new CanJumps();
            Assert.True(jump.CanJump(new int[] { 2500, 3000, 1, 2, 4, 0 }));
            Assert.True(jump.CanJump(new int[] { 2, 3, 1, 2, 4, 0 }));
            Assert.False(jump.CanJump(new int[] { 2, 3, 1, 1, 0, 4 }));
            Assert.True(jump.CanJump(new int[] { 1 }));
            Assert.True(jump.CanJump(new int[] { }));
            Assert.True(jump.CanJump(new int[] { 2, 1 }));
            Assert.True(jump.CanJump(new int[]{2, 3, 1, 1, 4 }));
            Assert.False(jump.CanJump(new int[] { 3, 2, 1, 0, 4 }));
        }
    }
}
