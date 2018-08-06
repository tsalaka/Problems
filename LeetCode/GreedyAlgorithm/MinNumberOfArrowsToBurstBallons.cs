using System;
using System.Collections.Generic;

namespace LeetCode.GreedyAlgorithm
{
    //c# doesn't have native support of two dimentional array sort
    //that's why it is better to use java for this problem
    public class MinNumberOfArrowsToBurstBallons
    {
		private class PointsComparer : IComparer<int[,]>
		{
			public int Compare(int[,] a, int[,] b)
			{
				if (a[0,0] == b[0,0])
					return a[0,1] - b[0,1];
				return a[0,0] - b[0,0];
			}
		}

		public int FindMinArrowShots(int[,] points)
		{
			if (points.Length == 0) return 0;
            //Comparer should be called here
            //Array.Sort(paoints, (a,b) => { a[0]==b[0] ? a[1]-b[1] : a[0]-b[0]});
            Array.Sort(points);
			int number = 1;
			int lo = points[0,0];
			int hi = points[0,1];
			for (int i = 1; i < points.Length; i++)
			{
				if (points[i,0] < hi)
				{
					lo = Math.Max(lo, points[i,0]);
					hi = Math.Min(hi, points[i,1]);
				}
				else number++;
			}
			return number;
		}

		private int Compare(int[,] a, int[,] b)
		{
			if (a[0, 0] == b[0, 0])
				return a[0, 1] - b[0, 1];
			return a[0, 0] - b[0, 0];
		}
    }
}
