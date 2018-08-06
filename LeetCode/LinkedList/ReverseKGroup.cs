using System;
namespace LeetCode.LinkedList
{
    public class ReverseKGroup
    {
		public ListNode Reverse(ListNode head, int k)
		{
			ListNode tailInGroup = null;
			ListNode headInGroup = head;
			bool notFirstRun = false;
			while (headInGroup != null)
			{
				ListNode node = headInGroup;

				for (int i = 1; i < k; i++)
				{
                    //check null
					if (node == null) return head;
					node = node.Next;
				}
                if (node == null)
                    return head;
				var prev = headInGroup;
                var nextTailInGroup = headInGroup;
				var next = node.Next;
				headInGroup = node.Next;
				while (prev != node)
				{
					var temp = prev.Next;
					prev.Next = next;
					next = prev;
					prev = temp;
				}
				node.Next = next;
				if (notFirstRun)
					tailInGroup.Next = node;
				else
					head = node;

                tailInGroup = nextTailInGroup;
				notFirstRun = notFirstRun || !notFirstRun;
			}
			return head;
		}

		public ListNode Reverse2(ListNode head, int k)
		{

			if (k == 0 || k == 1) return head;
			ListNode list = null;

			var groupHead = head;
			ListNode prev = null;
			while (groupHead != null)
			{
				var tail = groupHead;
				for (int i = 1; i < k; i++)
				{
					tail = tail.Next;
					if (tail == null)
						return list == null ? head : list;
				}
				var next = tail.Next;
				//swap two adjacent nodes till tail
				//if k is odd, tail won't be swapped
				//given: 1->2->3->4->5->6->7->8, k= 7, res:7->6->5->4->3->2->1->8
				//here: 2->1->4->3->6->5->7->8
				int c = k / 2;
				var node = groupHead;
				ListNode newHead = node.Next; //2
				ListNode newTail = groupHead; //1
				ListNode prevNode = null;
				while (c > 0)
				{
					if (prevNode != null)
						prevNode.Next = node.Next;
					var n = node.Next.Next;
					node.Next.Next = node;
					node.Next = n;
					prevNode = node;
					node = n;
					c--;
				}

				//merge tail and head of each pairs one by one:
				//4->3->2->1->6->5->7->8
				//6->5->4->3->2->1->7->8
				c = k / 2 - 1;
				while (c > 0)
				{
					node = newHead; //2
					newHead = newTail.Next;//4
					var temp = newHead.Next.Next;
					newHead.Next.Next = node;
					newTail.Next = temp;
					c--;
				}
				//we left last node and now it's time to put as first node
				if (k % 2 == 1)
				{
					tail.Next = newHead; //7.next = 6
					newHead = tail;
				}
				if (prev == null)
					list = newHead;
				else
					prev.Next = newHead;
				newTail.Next = next;
				prev = newTail;
				groupHead = next;
			}
			return list;
		}
	}
}
