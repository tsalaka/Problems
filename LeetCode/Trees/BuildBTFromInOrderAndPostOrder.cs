using System.Collections.Generic;
namespace LeetCode.Trees
{
	//106
	//Given inorder and postorder traversal of a tree, construct the binary tree.
	//inorder = [9,3,15,20,7]
	//postorder = [9,15,7,20,3]
	public class BuildBTFromInOrderAndPostOrder
	{
		public TreeNode BuildTree(int[] inorder, int[] postorder)
		{
            return BuildNode(inorder, postorder, 0, inorder.Length - 1, 0, postorder.Length - 1);
		}

		private TreeNode BuildNode(int[] inorder, int[] postorder, int lIn, int hIn, int lPost, int hPost)
		{
			if (lPost > hPost) return null;
			var middle = new TreeNode(postorder[hPost]);
			if (lPost == hPost) return middle;
			int m = hIn;
			while (m >= lIn && inorder[m] != middle.val) m--;
            int indForRightSubtree = hPost - (hIn - m);

            middle.left = BuildNode(inorder, postorder, lIn, m - 1, lPost, indForRightSubtree - 1);
			middle.right = BuildNode(inorder, postorder, m + 1, hIn, indForRightSubtree, hPost - 1);
			return middle;
		}
	}
}
