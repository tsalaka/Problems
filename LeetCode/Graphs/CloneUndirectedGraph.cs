using System;
using System.Collections.Generic;
using System.Collections;

namespace LeetCode.Graphs
{
    /// <summary>
    /// 133
    /// </summary>
	public class UndirectedGraphNode
	{
      public int label;
      public IList<UndirectedGraphNode> neighbors;
      public UndirectedGraphNode(int x) { label = x; neighbors = new List<UndirectedGraphNode>(); }
    };

    public class CloneUndirectedGraph
    {
		public UndirectedGraphNode CloneGraph(UndirectedGraphNode node)
		{
			Dictionary<int, UndirectedGraphNode> marked = new Dictionary<int, UndirectedGraphNode>();
			return Dfs(node, marked);
		}

		private UndirectedGraphNode Dfs(UndirectedGraphNode node, Dictionary<int, UndirectedGraphNode> marked)
		{
			var clone = new UndirectedGraphNode(node.label);
			marked.Add(node.label, clone);
			foreach (var neighbor in node.neighbors)
			{
				UndirectedGraphNode n = null;
				if (!marked.ContainsKey(neighbor.label))
					n = Dfs(neighbor, marked);
				else
                    n = marked[neighbor.label];
				clone.neighbors.Add(n);
			}
            return clone;
		}
    }
}
