using System;
namespace LeetCode.LinkedList
{
    public class DetectCycleNode
    {
		public ListNode DetectCycle(ListNode head)
		{
			if (head == null || head.Next == null) return null;

			ListNode slow = head.Next;
			ListNode fast = head.Next.Next;
			while (fast != null && fast != slow)
			{
				if (fast.Next == null) break;
				fast = fast.Next.Next;
				slow = slow.Next;
			}

			if (fast == slow)
			{
				slow = head;
				while (slow != fast)
				{
					slow = slow.Next;
					fast = fast.Next;
				}
				return slow;
			}
			return null;
		}
    }
}
