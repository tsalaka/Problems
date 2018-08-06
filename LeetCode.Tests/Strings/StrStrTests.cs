using NUnit.Framework;
using System;
using System.Text;
using LeetCode.Strings;
using System.Collections;
using System.Collections.Generic;
namespace LeetCode.Tests.Strings
{
	public class Point
	{
		public int x;
		public int y;
		public Point() { x = 0; y = 0; }
		public Point(int a, int b) { x = a; y = b; }
	}

	public class PointsComparer : IComparer<Point>
	{
		public int Compare(Point p1, Point p2)
		{
			if (p1.x == p2.x)
				return p1.y - p2.y;
			return p1.x - p2.x;
		}
	}

	public class Solution
	{
		public IList<Point> OuterTrees(Point[] points)
		{
			Array.Sort(points, new PointsComparer());
            var used = new HashSet<Point>();
            var res = new List<Point>();
			var fencePoints = new List<Point>();
			if (points.Length == 0) return res;

			for (int i = 0; i < points.Length;i++)
			{
				while (fencePoints.Count >= 2
                && PointCanBeExcluded(points[i], fencePoints[fencePoints.Count - 2],
                                        fencePoints[fencePoints.Count - 1], true))
                {
                  fencePoints.RemoveAt(fencePoints.Count - 1);
                }
                fencePoints.Add(points[i]);

			}

            for (int i=fencePoints.Count - 1; i >= 0;i--)
            {
                res.Add(fencePoints[i]);
                used.Add(fencePoints[i]);
                fencePoints.RemoveAt(i);
            }

            for (int i = points.Length-1; i >= 0; i--)
			{
				while (fencePoints.Count >= 2
			             && PointCanBeExcluded(points[i], fencePoints[fencePoints.Count - 2],
                                                fencePoints[fencePoints.Count - 1], false))
				{
					fencePoints.RemoveAt(fencePoints.Count - 1);
				}
                if(!used.Contains(points[i]))
			        fencePoints.Add(points[i]);
			}

			for (int i = fencePoints.Count - 1; i >= 0; i--)
				res.Add(fencePoints[i]);

			return res;
		}

		private bool PointCanBeExcluded(Point p1, Point p2, Point pointToExclude, bool isAboveLine)
		{
            int lineY = 0;
            if (p2.x == p1.x)
                lineY = isAboveLine ? Math.Min(p2.y, p1.y) : Math.Max(p2.y, p1.y);
            else
            {
                var m = (p2.y - p1.y) / (p2.x - p1.x);
                var b = p2.y - m * p2.x;

                lineY = m * pointToExclude.x + b;
            }
			if (isAboveLine)
				return lineY < pointToExclude.y;
			return lineY > pointToExclude.y;
		}

		static void Main()
		{
			var s = new Solution();
            var res = s.OuterTrees(new Point[] { new Point(1, 1), new Point(2, 2), new Point(2, 4) });
			foreach (var r in res)
				Console.Write(r.x + "," + r.y + "; ");
		}
	}

    [TestFixture()]
    public class StrStrTests
    {
        [Test()]
        public void TestCase()
        {
			var s = new Solution();
			//[[0,0],[0,100],[100,100],[100,0],[50,50]]
            var res = s.OuterTrees(new Point[] { new Point(0, 0), new Point(0, 100), new Point(100, 100), new Point(100, 0), new Point(40, 50) });

            var intr = new Interval[1];
            intr[0] = new Interval(2, 2);
            //intr[1] = new Interval(2, 3);
            //intr[2] = new Interval(4, 5);
            //intr[3] = new Interval(2, 3);
            var v = CanAttendMeetings(intr);
           
            var c = new StrStr();
            Assert.AreEqual(4, c.Check("mississippi", "issip"));
            Assert.AreEqual(5, c.Check("aaaaaabaabaac","abaabaa"));
            StringBuilder str = new StringBuilder();
            for (int i = 0; i < 999;i++){
                str.Append("a");
            }
            str.Append("b");

            Assert.AreEqual(997, c.Check(str.ToString(), "aab"));
        }
		public class Interval
		{
		  public int start;
		  public int end;
		  public Interval() { start = 0; end = 0; }
		  public Interval(int s, int e) { start = s; end = e; }
		}
		public class IntervalComparer : IComparer<Interval>
		{
			public int Compare(Interval a, Interval b)
			{
				if (a.start > b.start)
					return 1;
				if (a.start == b.start && a.end > b.end)
					return 1;
				return -1;
			}
		}

		public bool CanAttendMeetings(Interval[] intervals)
		{
			Array.Sort(intervals, new IntervalComparer());

			for (int i = 1; i < intervals.Length; i++)
			{
				if (intervals[i - 1].end > intervals[i].start)
					return false;
			}
			return true;
		}


    }
}
