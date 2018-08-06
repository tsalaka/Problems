using System;
namespace LeetCode.Trees
{
    public class MaxPathSum
    {
		public int Sum(TreeNode root)
		{
			int max = Int32.MinValue;
			Traverse(root, ref max);
			return max;
		}

		private int Traverse(TreeNode node, ref int max)
		{
			if (node == null) return 0;
			var leftVal = Traverse(node.left, ref max);
			//max = Math.Max(max, leftVal);
			var rightVal = Traverse(node.right, ref max);
			//max = Math.Max(max, rightVal);
			int val = Math.Max(node.val, Math.Max(rightVal + node.val, leftVal + node.val));
            max = Math.Max(max, val);
			max = Math.Max(max, leftVal + rightVal + node.val);

			return val;
		}
    }
}
