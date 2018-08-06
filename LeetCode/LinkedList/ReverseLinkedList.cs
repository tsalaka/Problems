using System;
namespace LeetCode.LinkedList
{
    public class ReverseLinkedList
    {
		public ListNode ReverseBetween(ListNode head, int m, int n)
		{
			if (n <= m || m < 1)
				return head;

			ListNode right = head;
			ListNode leftPrev = head;
			for (int i = 1; i < n; i++)
			{
				if (i < m - 1)
					leftPrev = leftPrev.Next;
                right = right.Next;
			}
			var current = m == 1 ? head : leftPrev.Next;
			var prev = right.Next;

			while (n >= m)
			{
				var next = current.Next;
				current.Next = prev;
				prev = current;
				current = next;
				n--;
			}
			if (m == 1)
				head = prev;
			else
				leftPrev.Next = prev;
			return head;
		}
    }
}
