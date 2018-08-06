using NUnit.Framework;
using System;
using LeetCode.Graphs;

namespace LeetCode.Tests.Graphs
{
    [TestFixture()]
    public class RedundantConnections2Tests
    {
        [Test()]
        public void TestCase()
        {
            var rc = new RedundantConnections2();

            var res = rc.FindRedundantDirectedConnection(new int[,] { { 1, 2 }, { 1, 3 }, { 2, 3 } });
			Assert.AreEqual(2, res[0]);
			Assert.AreEqual(3, res[1]);

			res = rc.FindRedundantDirectedConnection(new int[,] { { 3, 4 }, { 4, 1 }, { 1, 2 }, { 2, 3 }, { 5, 1 } });
			Assert.AreEqual(4, res[0]);
			Assert.AreEqual(1, res[1]);

            res = rc.FindRedundantDirectedConnection(new int[,] { { 1, 2 }, { 2, 3 }, { 3, 1 }, { 4, 1 } });
            Assert.AreEqual(3, res[0]);
            Assert.AreEqual(1, res[1]);


		    res = rc.FindRedundantDirectedConnection(new int[,] { { 1, 2 }, { 2, 3 }, { 3, 4 }, { 4, 1 }, { 1, 5 } });
            Assert.AreEqual(4,res[0]);
            Assert.AreEqual(1, res[1]);


		}
    }
}
