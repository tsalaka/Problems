using System;
using System.Collections;
using System.Collections.Generic;

namespace LeetCode.LinkedList.LFU
{
	public class ListNode
	{
		public int val { get; set; }
		public int key { get; set; }
		public int hits { get; set; }
		public ListNode prev { get; set; }
		public ListNode next { get; set; }

		public ListNode(int key, int val)
		{
			this.key = key;
			this.val = val;
			this.hits = 1;
		}
	}

    public class LFUCache
    {
		private ListNode head;
		private readonly Dictionary<int, ListNode> keysDic;
		private readonly Dictionary<int, ListNode> hitsDic;
		private readonly int capacity;
		private int itemsCount;
		private const int InitialHitNumber = 1;

		public LFUCache(int capacity)
		{
			this.capacity = capacity;
			keysDic = new Dictionary<int, ListNode>();
			hitsDic = new Dictionary<int, ListNode>();
		}

		public void Put(int key, int val)
		{
			if (capacity == 0) return;
			var node = GetNode(key);
			if (node == null)
			{
				node = new ListNode(key, val);
				if (itemsCount == capacity)
				{
					RemoveLeastFrequentlyUsed();
					itemsCount--;
				}
				if (head == null)
					head = node;
				else if (head.hits > InitialHitNumber)
				{
					head.prev = node;
					node.next = head;
					head = node;
				}

				keysDic.Add(key, node);
				UpdateHitsDictionary(InitialHitNumber, node, null);
				itemsCount++;
			}
			else
			{
				node.val = val;
				MoveToNextHitsLevel(node);
			}
		}

		public int Get(int key)
		{
			var node = GetNode(key);
			if (node == null) return -1;
			// if(key == 1) return node.Hits;
			MoveToNextHitsLevel(node);
			return node.val;
		}

		private ListNode GetNode(int key)
		{
			if (keysDic.ContainsKey(key))
				return keysDic[key];
			return null;
		}

		private void MoveToNextHitsLevel(ListNode node)
		{
            var next = node.next;
			//if node is not in the end of list already
			if (next != null)
			{
				if (node.prev != null)
					node.prev.next = node.next;
				node.next.prev = node.prev;
				if (head == node)
					head = head.next;
			}
			//check if current node is tail of hitsDic
			//if so, remove hitsDic item if it contains only this node
			//otherwise, update tail to tail.prev
			if (hitsDic[node.hits] == node)
			{
				var prev = node.prev;
				if (prev == null || (prev != null && prev.hits < node.hits))
					hitsDic.Remove(node.hits);
				else
					hitsDic[node.hits] = node.prev;
			}
			UpdateHitsDictionary(++node.hits, node, next);
		}

		private void UpdateHitsDictionary(int hitsNum, ListNode node, ListNode exNext)
		{
            ListNode prev = null;
			if (hitsDic.ContainsKey(hitsNum))
			{
				prev = hitsDic[hitsNum];
                hitsDic[hitsNum] = node;
			}
			else
			{
                if(exNext != null)
                    prev = hitsDic[exNext.hits];             			
			}
            if (prev != null)
            {
                var temp = prev.next;
                prev.next = node;
                node.prev = prev;
                node.next = temp;
            }
            if (hitsDic.ContainsKey(hitsNum))
                hitsDic[hitsNum] = node;
            else
                hitsDic.Add(hitsNum, node);
		}

		private void RemoveLeastFrequentlyUsed()
		{
			var exHead = head;
			head = head.next;
			if (head != null)
				head.prev = null;
			if (hitsDic[exHead.hits] == exHead)
				hitsDic.Remove(exHead.hits);
			keysDic.Remove(exHead.key);
		}
    }
}
