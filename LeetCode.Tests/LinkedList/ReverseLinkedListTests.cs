using NUnit.Framework;
using System;
using LeetCode.LinkedList;

namespace LeetCode.Tests.LinkedList
{
    [TestFixture()]
    public class ReverseLinkedListTests
    {
        [Test()]
        public void TestCase()
        {
            var p = new ReverseLinkedList();
            var list = new ListNode(1);
            list.Next = new ListNode(2);
            list.Next.Next = new ListNode(3);
            list.Next.Next.Next = new ListNode(4);
            list.Next.Next.Next.Next = new ListNode(5);
            p.ReverseBetween(list, 3, 4);
 
                
        }
    }
}
