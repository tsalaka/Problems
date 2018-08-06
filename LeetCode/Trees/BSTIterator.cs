using System;
using System.Collections.Generic;

namespace LeetCode.Trees
{
    public class BSTIterator
    {
		private Stack<TreeNode> _nodes;

		public BSTIterator(TreeNode root)
		{
			_nodes = new Stack<TreeNode>();
			while (root != null)
			{
				_nodes.Push(root);
				root = root.left;
			}
		}

		/** @return whether we have a next smallest number */
		public bool HasNext()
		{
            return _nodes.Count != 0;
		}

		/** @return the next smallest number */
		public int Next()
		{
			var node = _nodes.Pop();
			int val = node.val;
            var next = node.right;
			while (next != null)
			{
				_nodes.Push(next);
                next = next.left;
			}
			
			return val;
		}
    }
}
