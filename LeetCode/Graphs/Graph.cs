using System;
namespace LeetCode.Graphs
{
	public class Graph : GraphBase
	{
		public Graph(int verticesCount) : base(verticesCount)
		{
		}

		public override void AddEdge(int v, int w)
		{
			ValidateVertex(v);
			ValidateVertex(w);
			EdgesCount++;
            _adjacents[v].AddLast(w);
			_adjacents[w].AddLast(v);
		}
	}
}
