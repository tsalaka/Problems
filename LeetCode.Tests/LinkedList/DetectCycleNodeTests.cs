using NUnit.Framework;
using System;
using LeetCode.LinkedList;

namespace LeetCode.Tests.LinkedList
{
    [TestFixture()]
    public class DetectCycleNodeTests
    {
        [Test()]
        public void TestCase1()
        {
            var cycle = new DetectCycleNode();
            var head = new ListNode(1);
            Push(head, 2);
            Push(head, 3);
            var n4 = Push(head, 4);
            var n5 = Push(head, 5);
            Push(head, 6);
            Push(head, 7);
            Push(head, 8);
            var n9 =Push(head, 9);
            Push(head, 10);
            Push(head, 11);
            var n12 = Push(head, 12);
            n12.Next = n5;
            Assert.AreEqual(5, cycle.DetectCycle(head).Val);
        }

		[Test()]
		public void TestCase2()
		{
			var cycle = new DetectCycleNode();
			var head = new ListNode(1);
			Push(head, 2);
			Push(head, 3);
			var n4 = Push(head, 4);
			var n5 = Push(head, 5);
			Push(head, 6);
			Push(head, 7);
			Push(head, 8);
			var n9 = Push(head, 9);
            n9.Next = n4;
			Assert.AreEqual(4, cycle.DetectCycle(head).Val);
		}

        [Test()]
        public void TestCase3()
        {
            var cycle = new DetectCycleNode();
            var head = new ListNode(1);
            Push(head, 2);
            Push(head, 3);
            var n4 = Push(head, 4);
            var n5 = Push(head, 5);
            Push(head, 6);
            Push(head, 7);
            Push(head, 8);
            var n9 = Push(head, 9);

            Assert.AreEqual(null, cycle.DetectCycle(head));
        }

        [Test()]
        public void TestCase4()
        {
            var cycle = new DetectCycleNode();
            var head = new ListNode(1);
            head.Next = head;  

            Assert.AreEqual(1, cycle.DetectCycle(head).Val);
        }

        private ListNode Push(ListNode head, int x){
            var node = head;
            while (node.Next != null)
                node = node.Next;
            
            node.Next = new ListNode(x);
            return node.Next;
        }
    }
}
