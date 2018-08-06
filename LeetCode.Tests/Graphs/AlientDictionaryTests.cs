using NUnit.Framework;
using System;
using LeetCode.Graphs;
using System.Collections.Generic;
using System.Collections;

namespace LeetCode.Tests.Graphs
{
	public class Solution
	{
		public bool ValidTree(int n, int[,] edges)
		{
			var adjacents = new List<int>[n];
			for (int i = 0; i < adjacents.Length; i++)
				adjacents[i] = new List<int>();
			var marked = new bool[n];
			var currentlyUsed = new bool[n];
            int componentsNumber = 0;
			for (int i = 0; i < edges.GetLength(0); i++)
			{
				adjacents[edges[i, 0]].Add(edges[i, 1]);
				adjacents[edges[i, 1]].Add(edges[i, 0]);
			}

			for (int i = 0; i < adjacents.Length; i++)
			{
                if (!marked[i])
                {
                    if (HasCycled(adjacents, i, null, marked, currentlyUsed)) return false;
                    componentsNumber++;
                }
			}
			return componentsNumber == 1;
		}

		private bool HasCycled(List<int>[] adjacents, int v, int? prev, bool[] marked, bool[] currentlyUsed)
		{
			marked[v] = true;
			currentlyUsed[v] = true;
			foreach (var w in adjacents[v])
			{
				if (prev.HasValue && prev.Value != w && currentlyUsed[w]) return true;
				if (!marked[w])
					if (HasCycled(adjacents, w, v, marked, currentlyUsed)) return true;
			}
			currentlyUsed[v] = false;
			return false;
		}
	}
    [TestFixture()]
    public class AlientDictionaryTests
    {


        [Test()]
        public void TestCase()
        {
            var s = new Solution();
            var arr = new int[2,2] { { 0, 1 },{1,2}};

            Assert.AreEqual(false, s.ValidTree(4, arr));
            var d = new AlientDictionary();
			var res = d.AlienOrder(new string[] { "ab", "adc" });
			Assert.AreEqual("cbda", res);

            res = d.AlienOrder(new string[] { "z", "z"});
            Assert.AreEqual("z", res);

			res = d.AlienOrder(new string[] { "z", "x", "z" });
            Assert.AreEqual(string.Empty, res);


			res = d.AlienOrder(new string[] { "mtr", "mta", "bac", "bdt", "rd", "ad" });
			Assert.AreEqual("tmcbrad", res);

            res = d.AlienOrder(new string[]{"wrt",
				  "wrf",
				  "er",
				  "ett",
                  "rftt"});

            Assert.AreEqual("wertf", res);
        }
    }
}
