using NUnit.Framework;
using System;
using LeetCode.LinkedList;

namespace LeetCode.Tests.LinkedList
{
    [TestFixture()]
    public class ReverseKGroupTests
    {
        [Test()]
        public void TestCase()
        {
            var list = new ListNode(1);
            Push(list, 2);
            Push(list, 3);
            Push(list, 4);
            Push(list, 5);
            Push(list, 6);
           // Push(list, 7);
            //Push(list, 8);
            var r = new ReverseKGroup();
            var head = r.Reverse(list, 6);
        }

		private void Push(ListNode node, int val)
		{
			while (node.Next != null)
				node = node.Next;
			node.Next = new ListNode(val);
		}
    }
}
