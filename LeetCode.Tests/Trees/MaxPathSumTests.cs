using NUnit.Framework;
using System;
using LeetCode.Trees;

namespace LeetCode.Tests.Trees
{
    [TestFixture()]
    public class MaxPathSumTests
    {
        [Test()]
        public void TestCase()
        {
            var tree = new TreeNode(1);
            tree.left = new TreeNode(2);
            tree.right = new TreeNode(3);
            var s = new MaxPathSum();
            Assert.AreEqual(6, s.Sum(tree));
        }
    }
}
