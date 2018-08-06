using NUnit.Framework;
using System;
using LeetCode.GreedyAlgorithm;
using System.Collections.Generic;

namespace LeetCode.Tests.GreedyAlgorithm.Tests
{
    //846, 845,844,847
    [TestFixture()]
    public class MinMeetingRoomsTests
    {
        [Test()]
        public void TestCase()
        {
            var head = new RandomListNode(1);
            head.next = new RandomListNode(2);
            head.next.next = new RandomListNode(3);
            head.next.next.next = new RandomListNode(4);
            head.next.next.next.next = new RandomListNode(5);
            head.random = head.next.next.next.next;
            head.next.random = head.next.next;
            head.next.next.next.random = head.next;
            CopyRandomList(head);
            Assert.AreEqual(5, MaxProfit(new int[] {7, 1, 5, 3, 6, 4 }));
            Assert.True(BackspaceCompare("nzp#o#g", "b#nzp#o#g"));
            Assert.False(BackspaceCompare("bbbextm", "bbb#extm"));
			Assert.True(BackspaceCompare("ab##", "a#c#d#b#"));
			Assert.False(BackspaceCompare("cab###", "cab##"));
            Assert.True(BackspaceCompare("bxj##tw", "bxo#j##tw"));
            Assert.True(BackspaceCompare("cab###ad#b", "cab###ab"));


            Assert.AreEqual(0, LongestMountain(new int[] { 2, 3, 3, 2, 0, 2 }));
            Assert.AreEqual(7,LongestMountain(new int[] { 3, 2, 1, 2, 3, 4, 3, 2, 1 }));
            Assert.AreEqual(0, LongestMountain(new int[] { 2,2,2 }));
            Assert.AreEqual(0, LongestMountain(new int[] { 3, 2, 1 }));
            Assert.AreEqual(0, LongestMountain(new int[] {  1, 2, 3, 4}));
            Assert.AreEqual(6, LongestMountain(new int[] { 1, 2, 3, 4, 3, 2, 5 }));
            Assert.AreEqual(5, LongestMountain(new int[] { 2, 1, 4, 7, 3, 2, 5 }));

            Assert.AreEqual(17, LongestMountain(new int[] { 3, 2, 1, 2, 3, 4, 6, 7,8,9,8,7,6,7,5,4,6,7,8,9,10,11,11,10,9,8,7,6,5,4,5,6,7,8,9,10,11,12,11,10,9,8,7,6,5,4,5,6 }));
            Assert.AreEqual(3, LongestMountain(new int[] { 0, 0, 1, 0, 0, 1, 1, 1, 1, 1 }));
            var s = new Solution();
            var list = new List<Interval>(){
                new Interval{start =3, end=2},
                new Interval{start=2,end=5}
            };
            var intr = new Interval[4];
            intr[0] = new Interval(2, 2);
            intr[1] = new Interval(2, 3);
            intr[2] = new Interval(4, 5);
            intr[3] = new Interval(2, 3);
            Assert.AreEqual(2, s.MinMeetingRooms(intr));
        }

		public class RandomListNode
		{
	      public int label;
	      public RandomListNode next, random;
	      public RandomListNode(int x) { this.label = x; }
	  }
		public RandomListNode CopyRandomList(RandomListNode head)
		{
			var node = head;
			//insert copy of each node after each node
			while (node != null)
			{
                var c = new RandomListNode(node.label);
				var next = node.next;
				node.next = c;
				node.next.next = next;
				node = node.next.next;
			}

			//go through each real node and get random
			//find random copy(as next node) and set to copy.random
			node = head;
			while (node != null)
			{
				var r = node.random;
				if (r != null)
				{
					node.next.random = node.random.next;
				}
				node = node.next.next;
			}

			//extract copies node to separate list and clean up initial list
			node = head;
			RandomListNode copy = null;
            RandomListNode cnode = null;
			while (node != null)
			{
                if (copy == null)
                {
                    copy = node.next;
                    cnode = copy;
                }
                else
                {
                    cnode.next = node.next;
                    cnode = cnode.next;
                }
				node.next = node.next.next;
				node = node.next;
			}
			return copy;
		}

        public int MaxProfit(int[] prices)
        {
            int[] profits = new int[prices.Length - 1];
            int max = 0; int current = Int32.MinValue;
            for (int i = 1; i < prices.Length; i++)
            {
                var profit = prices[i] - prices[i - 1];
                //input:7,1,5
                //1-7=-6 - profit if sell 1, buy 2
                //5-1=4 - profit if sell 2, buy 3
                //-6+4=-2 - profit if sell 1, buy 3
                //find max of 3 sums
                current = Math.Max(Math.Max(current, profit), current + profit);
                max = Math.Max(max, current);
            }

            return max < 0 ? 0 : max;

        }
		public bool BackspaceCompare(string S, string T)
		{
			int i = S.Length - 1;
			int j = T.Length - 1;
			while (i >= 0 && j >= 0)
			{
				i = NextChar(S, i);
				j = NextChar(T, j);
                if (i < 0 && j < 0) return true;
                else if (i < 0 || j < 0) break;
				if (S[i] != T[j]) return false;
                i--; j--;
			}

			//case S="nzp#", T="b#nzp#"
			if(i >= 0) i = NextChar(S, i);
            if(j >= 0) j = NextChar(T, j);

			return i < 0 && j < 0;
		}

		private int NextChar(string s, int i)
		{
			if (s[i] != '#') return i;
			int c = 1;
			i--;
            while (i >= 0 && (c > 0 || s[i] == '#'))
			{
				if (s[i] != '#') c--;
				else c++;
				i--;
			}
			return i;
		}

		public int LongestMountain(int[] A)
		{
			if (A.Length <= 1) return 0;
			int i = 1;
			int max = 0;
			bool start = false;
			bool wasDown = false;
			int c = 1;
			while (i < A.Length)
			{
				if (A[i] > A[i - 1] || A[i] == A[i - 1])
				{
					if (wasDown)
					{
						if (start)
						{
							max = Math.Max(max, c);
						}
						c = 1;
						wasDown = false;
					}
				}
				if (A[i] > A[i - 1]) start = true;
				else if (A[i] < A[i - 1]) wasDown = true;

                if (A[i] < A[i - 1] || A[i] > A[i - 1]) c++;
                else { c = 1; start = false; }
				i++;
			}
            if (wasDown && start)
                max = Math.Max(max, c);
			return max;
		}

    }
}