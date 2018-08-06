using NUnit.Framework;
using System;
using LeetCode.Trees;

namespace LeetCode.Tests.Trees
{
    [TestFixture()]
    public class BSTIteratorTests
    {
        [Test()]
        public void TestCase()
        {
            var root = new TreeNode(9);
            root.left = new TreeNode(4);
            root.left.left = new TreeNode(2);
            root.left.left.left = new TreeNode(1);
            root.left.left.right = new TreeNode(3);
            root.left.right = new TreeNode(5);

            root.right = new TreeNode(10);
            root.right.right = new TreeNode(12);
            root.right.right.left = new TreeNode(11);
            Check(root);

            root = new TreeNode(1);
            root.right = new TreeNode(2);
            Check(root);
        }

        private void Check(TreeNode root)
        {
            var it = new BSTIterator(root);

            var v = 0;
            while (it.HasNext())
            {
                var n = it.Next();
                Assert.True(v < n);
                v = n;
            }
        }
    }
}
