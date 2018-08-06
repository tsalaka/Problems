using NUnit.Framework;
using System;
using LeetCode.Trees;

namespace LeetCode.Tests.Trees
{
    [TestFixture()]
    public class BuildBTFromInOrderAndPostOrderTests
    {
        [Test()]
        public void TestCase()
        {
            var b = new BuildBTFromInOrderAndPostOrder();
            var tree = b.BuildTree(new int[] { 8, 9, 5, 11, 2, 4, 6, 3, 15, 20, 7, 10 }, new int[] { 8, 11, 2, 5, 6, 4, 9, 15, 10, 7, 20, 3 });
            //var tree = b.BuildTree(new int[] { 9, 3, 15, 20, 7 }, new int[] { 9, 15, 7, 20, 3 });

        }
    }
}
