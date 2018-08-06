using NUnit.Framework;
using System;
using LeetCode.LinkedList;
using System.Collections.Generic;
using System.Text;
using LeetCode.Trees;
namespace LeetCode.Tests.LinkedList
{
    [TestFixture()]
    public class MergeKListTests
    {
		public int[] FindMode(TreeNode root)
		{
			if (root == null) return new int[0];
            List<int> list = new List<int>();
			int maxVal = 0;
			int maxCount = 0;
			int currentVal = root.val;
			int currentCount = 0;
			Traverse(root, currentCount, currentVal, ref maxCount, ref maxVal, list);
			if (list == null)
				return new int[] { maxVal };
			return list.ToArray();
		}

		private void Traverse(TreeNode node, int currentCount, int currentVal, ref int maxCount, ref int maxVal, IList<int> list)
		{
			if (node == null) return;

			if (node.val != currentVal)
			{
				if (currentCount > maxCount)
				{
					maxCount = currentCount;
					maxVal = currentVal;
                    list.Clear();
				}
				else if (currentCount == maxCount)
				{
                    if (list.Count == 0)
					{
						list.Add(maxVal);
					}
					list.Add(currentVal);
				}
				currentCount = 0;
				currentVal = node.val;
			}
			currentCount++;
			bool isLeaf = node.left == null && node.right == null;
			if (isLeaf)
			{
				if (currentCount > maxCount)
				{
					maxCount = currentCount;
					maxVal = currentVal;
                    list.Clear();
				}
				else if (currentCount == maxCount)
				{
                    if (list.Count == 0)
					{
						list.Add(maxVal);
					}
					list.Add(currentVal);
				}
			}
			else
			{
				//traverse the child with the same value firstly  
				if (node.right != null && node.right.val == node.val)
				{
					Traverse(node.right, currentCount, currentVal, ref maxCount, ref maxVal, list);
					Traverse(node.left, currentCount, currentVal, ref maxCount, ref maxVal, list);
				}
				else
				{
					Traverse(node.left, currentCount, currentVal, ref maxCount, ref maxVal, list);
					Traverse(node.right, currentCount, currentVal, ref maxCount, ref maxVal, list);
				}
			}
		}
		public IList<string> FindStrobogrammatic(int n)
		{
			char[] nums = new char[] { '0', '1', '6', '9', '8' };
			var str = new StringBuilder();
			var res = new List<string>();
            if (n == 0) return res;
			BuildNumbers(n, nums, str, res);
			return res;
		}

		private void BuildNumbers(int n, char[] nums, StringBuilder str, List<string> res)
		{
			if (str.Length == (n + 1) / 2)
			{
				//build second part of number
				int start = str.Length - (n % 2 == 0 ? 1 : 2);
				for (int i = start; i >= 0; i--)
				{
                    str.Append(ReturnPair(str[i]));
				}
				res.Add(str.ToString());
				return;
			}
			for (int i = 0; i < nums.Length; i++)
			{
				//skip 01, 010 ect.
				if (str.Length == 0 && n > 1 && nums[i] == '0') continue;

				//if n is odd(181) and the next will be middle number
				//skip 6 and 9 since it will be different numbers
				if (n % 2 == 1
				   && str.Length == ((n + 1) / 2 - 1)
				   && ReturnPair(nums[i]) != nums[i])
					continue;
				str.Append(nums[i]);
				int ind = str.Length - 1;
				BuildNumbers(n, nums, str, res);
				str.Remove(ind, str.Length - ind);
			}
		}

		private char ReturnPair(char c)
		{
			return c == '6' ? '9' : c == '9' ? '6' : c;
		}
        [Test()]
        public void TestCase()
        {
            TreeNode root = new TreeNode(1);
            root.right = new TreeNode(2);
            root.right.left = new TreeNode(2);
            var p = FindMode(root);
            FindStrobogrammatic(3);
            var list1 = new ListNode(-6);
			list1.Next = new ListNode(-3);
			list1.Next.Next = new ListNode(-1);
            list1.Next.Next.Next = new ListNode(1);
            Push(list1, 2);
            Push(list1, 2);
            Push(list1, 2);

			var list2 = new ListNode(-10);
			list2.Next = new ListNode(-8);
			list2.Next.Next = new ListNode(-6);
            Push(list2, -2);
            Push(list2, 4);

			var list3 = new ListNode(-2);

            var list4 = new ListNode(-8);
            Push(list4, -4);
            Push(list4, -3);
            Push(list4, -3);
            Push(list4, -2);
            Push(list4, -1);
            Push(list4, 1);
            Push(list4, 2);
            Push(list4, 3);

			var list5 = new ListNode(-8);
			Push(list5, -6);
			Push(list5, -5); 
			Push(list5, -4); 
            Push(list5, -2);
			Push(list5, -2);
			Push(list5, 2);
			Push(list5, 4);

			var m = new MergeKList();
            Assert.NotNull(m.MergeKLists(new ListNode[]{list1,list2,list3,list4,list5}));
        }

        private void Push(ListNode node, int val){
            while (node.Next != null)
                node = node.Next;
            node.Next = new ListNode(val);
        }
    }
}
