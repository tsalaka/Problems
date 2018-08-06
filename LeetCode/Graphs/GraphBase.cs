using System;
using System.Collections.Generic;

namespace LeetCode.Graphs
{
	public abstract class GraphBase
	{
        protected LinkedList<int>[] _adjacents;
		public int VerticesCount { protected set; get; }
		public int EdgesCount { protected set; get; }

		public GraphBase(int verticesCount)
		{
			if (verticesCount < 0) throw new ArgumentException("Number of vertices must be nonnegative");
			VerticesCount = verticesCount;
			EdgesCount = 0;
			_adjacents = new LinkedList<int>[verticesCount];
			for (int v = 0; v < verticesCount; v++)
			{
				_adjacents[v] = new LinkedList<int>();
			}
		}

		public abstract void AddEdge(int v, int w);

		public IEnumerable<int> Adjecents(int v)
		{
			ValidateVertex(v);
			return _adjacents[v];
		}

		protected void ValidateVertex(int v)
		{
			if (v < 0 || v >= VerticesCount)
				throw new ArgumentOutOfRangeException("vertex " + v + " is not between 0 and " + (VerticesCount - 1));
		}
	}
}
