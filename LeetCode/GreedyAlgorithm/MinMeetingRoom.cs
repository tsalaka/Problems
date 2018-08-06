using System;
using System.Collections.Generic;

namespace LeetCode.GreedyAlgorithm
{
    public class Interval
    {
        public int start;
        public int end;
        public Interval() { start = 0; end = 0; }
        public Interval(int s, int e) { start = s; end = e; }
    }

    public class Solution
    {
		private class IntervalStartComparer : IComparer<Interval>
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

		private class IntervalEndComparer : IComparer<Interval>
		{
			public int Compare(Interval a, Interval b)
			{
				if (a.end > b.end)
					return 1;
				if (a.end == b.end)
					return 1;
				return -1;
			}
		}

        //12:30-12:45 12:35-12:50 12:55-13:05 13:00-13:20 13:00-13:20 13:10-13:30
        public int MinMeetingRooms(Interval[] intervals)
        {
            if (intervals.Length == 0)
                return 0;
            Array.Sort(intervals, new IntervalStartComparer());
            int n = intervals.Length;
            // the best solution to implement PriorityQueue where to store
            // meeting with the less end time frame at the beginning
            // like: https://visualstudiomagazine.com/Articles/2012/11/01/Priority-Queues-with-C.aspx
            var groupIntervals = new List<Interval>();

            for (int i = 0; i < intervals.Length; i++)
            {
                bool newRoom = true;
                if (groupIntervals.Count > 0)
                {
                    if (intervals[i].start >= groupIntervals[0].end)
                    {
                        groupIntervals[0].end = Math.Max(groupIntervals[0].end, intervals[i].end);
                        newRoom = false;
                    }
                }
				if (newRoom)
					groupIntervals.Add(intervals[i]);
				groupIntervals.Sort(new IntervalEndComparer());
            }
            return groupIntervals.Count;
        }
    }
}

