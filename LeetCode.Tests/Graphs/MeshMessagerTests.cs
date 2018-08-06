using NUnit.Framework;
using System.Collections.Generic;
using LeetCode.Graphs;

namespace LeetCode.Tests.Graphs
{
    [TestFixture()]
    public class MessMessagerTests
    {
        [Test()]
        public void TestCase()
        {
            var rc = new MeshMessager();
            var network = new Dictionary<string, string[]>();
			network.Add("Min", new string[] { "William", "Jayden", "Omar" });
			network.Add("William", new string[] { "Min", "Noam" });
			network.Add("Jayden", new string[] { "Min", "Amelia", "Ren", "Noam" });
			network.Add("Ren", new string[] { "Jayden", "Omar" });
			network.Add("Amelia", new string[] { "Jayden", "Adam", "Miguel" });
			network.Add("Adam", new string[] { "Amelia", "Miguel", "Sofia", "Lucas" });
			network.Add("Miguel", new string[] { "Amelia", "Adam", "Liam", "Nathan" });
			network.Add("Noam", new string[] { "Nathan", "Jayden", "William" });
			network.Add("Omar", new string[] { "Ren", "Min", "Scott" });

            Assert.AreEqual(4,rc.GetShortestPathBfs("Ren", "William", network).Count);
            Assert.Null(rc.GetShortestPathBfs("Ren2", "William", network));
            Assert.Null(rc.GetShortestPathBfs("Ren", "William2", network));
            Assert.Null(rc.GetShortestPathBfs("Ren", "Ren", network));

        }
    }
}
