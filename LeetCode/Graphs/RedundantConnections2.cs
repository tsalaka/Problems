using System;
namespace LeetCode.Graphs
{
    public class RedundantConnections2
    {
		private const int MaxCount = 1000;
		public int[] FindRedundantDirectedConnection(int[,] edges)
		{
			int[] arr = new int[MaxCount + 1];
			for (int i = 0; i < arr.Length; i++) arr[i] = i;
			int[] candidate1 = new int[] { 0, 0 };
			int[] candidate2 = new int[] { 0, 0 };

			for (int i = 0; i < edges.GetLength(0); i++)
			{
				var p = edges[i, 0];
				var c = edges[i, 1];
				if (arr[c] != c)
				{
					//parent of this vertix already exists (1->2->3->4->1<-5)
					//masked parents as candidates
					candidate1 = new int[2] { arr[c], c };
					candidate2 = new int[2] { p, c };
					//set to 0 to exclude this edge from tree construction in union find cycle
					edges[i, 1] = 0;
				}
				else
					arr[c] = p;
			}
			//union find
			for (int i = 0; i < arr.Length; i++) arr[i] = i;
			for (int i = 0; i < edges.GetLength(0); i++)
			{
				var parent = edges[i, 0];
				var child = edges[i, 1];
				if (child == 0) continue;

				// detect cycle
				if (Parent(arr, arr[parent]) == child)
				{
					//if candidate is absent, the graph is just cycled(no two parents for one node)
					if (candidate1[0] == 0)
						return new int[] { edges[i, 0], edges[i, 1] };
					return candidate1;
				}
                arr[child] = parent;
			}

            return candidate2;
		}

		public int Parent(int[] arr, int p)
		{
			if (arr[p] != p) p = Parent(arr, arr[p]);
			return arr[p];
		}
    }
}
