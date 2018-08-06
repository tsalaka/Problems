using System;
namespace LeetCode.Dequeues
{
	public class ListNode<T>
	{
		public T Value { get; set; }
		public ListNode<T> Next { get; set; }
		public ListNode<T> Prev { get; set; }

		public ListNode(T val)
		{
			Value = val;
		}
	}

	public class Deque<T>
	{
		private ListNode<T> head;
		private ListNode<T> tail;

		public void Push(ListNode<T> node)
		{
			if (head == null && tail == null)
			{
				head = tail = node;
			}
			else
			{
                tail.Next = node;
                node.Prev = tail;
                tail = node;
			}
		}

		public ListNode<T> PullLast()
		{
			if (tail == null) return null;

			var node = tail;
			if (tail == head)//only one element in dequeue
				tail = head = null;
			else
			{
				tail.Prev.Next = null;
				tail = tail.Prev;
			}
			return node;
		}

		public ListNode<T> PeekLast()
		{
			return tail;
		}

		public ListNode<T> PullFirst()
		{
			if (head == null) return null;

			var node = head;
			if (head == tail)//only one element in dequeue
				head = tail = null;
			else
			{
				head.Next.Prev = null;
				head = head.Next;
			}
			return node;
		}

		public ListNode<T> PeekFirst()
		{
			return head;
		}

		public bool IsEmpty()
		{
			return head == null;
		}
	}
}
