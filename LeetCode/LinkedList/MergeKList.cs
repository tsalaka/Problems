using System;
using System.Collections.Generic;

namespace LeetCode.LinkedList
{
    public class MergeKList
    {
		public ListNode MergeKLists(ListNode[] lists)
		{
            int count = lists.Length;
			if (count == 0)
				return null;

			while (count > 1)
			{
                int  j = 0;
				for (int i = 0; i < count; i += 2)
				{
                    if (i + 1 == count){
                        lists[j] = lists[i];
                        break;
                    }
					lists[j++] = MergeNodes(lists[i], lists[i + 1]);
				}
				count = (count + 1) / 2;
			}
			return lists[0];
		}

		private ListNode MergeNodes(ListNode n1, ListNode n2)
		{
			if (n1 == null) return n2;
			if (n2 == null) return n1;

			ListNode node = null;
			if (n1.Val <= n2.Val)
			{
				node = n1;
				node.Next = MergeNodes(n1.Next, n2);
			}
			else
			{
				node = n2;
				node.Next = MergeNodes(n1, n2.Next);
			}

			return node;
		}
    }
}
