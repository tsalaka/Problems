using NUnit.Framework;
using System;
using LeetCode.Dequeues;
namespace LeetCode.Tests
{
    [TestFixture()]
    public class DequeTests
    {
        [Test()]
        public void TestCase()
        {
            var deque = new Deque<int>();
            deque.Push(new ListNode<int>(1));
            deque.Push(new ListNode<int>(2));
            deque.Push(new ListNode<int>(3));
            Assert.AreEqual(1, deque.PeekFirst().Value);
            Assert.AreEqual(3, deque.PeekLast().Value);
            Assert.AreEqual(1, deque.PullFirst().Value);
            Assert.AreEqual(2, deque.PullFirst().Value);
            deque.Push(new ListNode<int>(4));
            Assert.AreEqual(4, deque.PullLast().Value);
            Assert.AreEqual(3, deque.PullLast().Value);
            Assert.True(deque.IsEmpty());
        }
    }
}
