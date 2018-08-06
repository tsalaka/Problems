using System;
using NUnit.Framework;
using LeetCode.Graphs;

namespace LeetCode.Tests.Graphs
{
    [TestFixture]
    public class CloneUndirectedGraphTests
    {
        [TestCase]
        public void Tests()
        {
            var gr = new UndirectedGraphNode(0);
            gr.neighbors.Add(gr);
            gr.neighbors.Add(gr);
            var c = new CloneUndirectedGraph();

            Assert.NotNull(c.CloneGraph(gr));
        }
    }
}
