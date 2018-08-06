using System;
namespace LeetCode.LinkedList
{
    public class Palindrome
    {
        public bool IsPalindrome(ListNode head)
        {
            if (head == null)
                return true;
            int count = 1;
            var fast = head;
            var slow = head;
            while (fast != null && fast.Next != null)
            {
                count += fast.Next.Next != null ? 2 : 1;
                slow = slow.Next;
                fast = fast.Next.Next;
            }
            //exclude middle node in case of odd linked list nodes count
            if (count % 2 == 1)
                slow = slow.Next;

            //reverse half of linked list
            var current = slow;
            ListNode prev = null;
            ListNode next;
            while (current != null)
            {
                next = current.Next;
                current.Next = prev;
                prev = current;
                current = next;
            }

            fast = head;
            while (prev != null)
            {
                if (prev.Val != fast.Val)
                    return false;
                prev = prev.Next;
                fast = fast.Next;
            }
            return true;
        }
    }
}

