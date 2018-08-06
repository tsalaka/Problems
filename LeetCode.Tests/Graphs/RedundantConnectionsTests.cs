using NUnit.Framework;
using System;
using LeetCode.Graphs;

namespace LeetCode.Tests.Graphs
{
    [TestFixture()]
    public class RedundantConnectionsTests
    {
        [Test()]
        public void TestCase()
        {
            var rc = new RedundantConnections();
            var res = rc.FindRedundantConnection(new int[,] { { 1, 2 }, { 2, 3 }, { 3, 4 }, { 1, 4 }, { 1, 5 } });
            Assert.AreEqual(1,res[0]);
            Assert.AreEqual(4, res[1]);
        }
    }
}
