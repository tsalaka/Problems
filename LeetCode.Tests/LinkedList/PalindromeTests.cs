using NUnit.Framework;
using System;
using LeetCode.LinkedList;

namespace LeetCode.Tests.LinkedList
{
    [TestFixture()]
    public class PalindromeTests
    {
        [Test()]
        public void TestCase()
        {
            var p = new Palindrome();
            var list = new ListNode(1);
            list.Next = new ListNode(2);
            list.Next.Next = new ListNode(3);
            list.Next.Next.Next = new ListNode(2);
            list.Next.Next.Next.Next = new ListNode(1);
            Assert.True(p.IsPalindrome(list));

			list = new ListNode(2);
			list.Next = new ListNode(3);
			list.Next.Next = new ListNode(3);
            list.Next.Next.Next = new ListNode(2);
            Assert.True(p.IsPalindrome(list));

            list = new ListNode(1);
            Assert.True(p.IsPalindrome(list));

			list = new ListNode(1);
            list.Next = new ListNode(2);
            Assert.False(p.IsPalindrome(list));
        }
    }
}
