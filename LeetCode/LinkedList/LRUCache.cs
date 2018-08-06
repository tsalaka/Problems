using System;
using System.Collections.Generic;
namespace LeetCode.LinkedList.Cache
{
	public class DoublyListNode
	{
		public int val { get; set; }
		public int key { get; set; }
		public DoublyListNode next { get; set; }
		public DoublyListNode prev { get; set; }

		public DoublyListNode(int key, int val)
		{
			this.key = key;
			this.val = val;
		}
	}

	public class LRUCache
	{
		private DoublyListNode head;
		private DoublyListNode tail;
		private readonly Dictionary<int, DoublyListNode> dic;
		private readonly int capacity;
		private int count;

		public LRUCache(int capacity)
		{
			this.capacity = capacity;
			dic = new Dictionary<int, DoublyListNode>();
		}

		public void Put(int key, int value)
		{
			if (capacity == 0) return;
			var node = GetNode(key);

			if (node == null)
			{
				if (count == capacity)
				{
					var exHeadKey = head.key;
					head = head.next;
					if (head == null)
						tail = null;
					else
					{
						head.prev = null;
						if (head == tail)
							tail.prev = null;
					}
					dic.Remove(exHeadKey);
					count--;
				}
				node = new DoublyListNode(key, value);
				if (head == null && tail == null)
				{
					head = node;
					tail = node;
				}
				else
				{
					tail.next = node;
					node.prev = tail;
					tail = node;
				}
				dic.Add(key, node);
				count++;
			}
			else
			{
				node.val = value;
				dic[key] = node;
				MoveToTail(node);
			}
		}

		public int Get(int key)
		{
			var node = GetNode(key);
			if (node == null) return -1;
			MoveToTail(node);
			return node.val;
		}

		private DoublyListNode GetNode(int key)
		{
			if (dic.ContainsKey(key))
				return dic[key];
			return null;
		}

		private void MoveToTail(DoublyListNode node)
		{
			if (node == null || node.next == null) return; //it is tail already

			if (node.prev == null)
			{
				head = node.next;
				node.next.prev = null;
			}
			else
			{
				node.prev.next = node.next;
				node.next.prev = node.prev;
			}
			tail.next = node;
			node.prev = tail;
			tail = node;
		}
	}
}
