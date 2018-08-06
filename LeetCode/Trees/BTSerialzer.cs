﻿using System;
using System.Text;
using System.Collections.Generic;

namespace LeetCode.Trees
{
    public class BTSerialzer
    {
		// Encodes a tree to a single string.
		public string serialize(TreeNode root)
		{
			StringBuilder str = new StringBuilder();
			var queue = new Queue<TreeNode>();
			queue.Enqueue(root);
			while (queue.Count != 0)
			{
				var node = queue.Dequeue();
                if (str.Length > 0)
					str.Append(',');
				if (node == null)
					str.Append("null");
                else{
					queue.Enqueue(node.left);
					queue.Enqueue(node.right);
                    str.Append(node.val);
				}
			}
            //remove nulls in the end of string
            var res = str.ToString();
            //,null is 5 characters
            while(res.Length >=5 && res.Substring(res.Length - 5, 5) == ",null")
            {
                res = res.Remove(res.Length - 5);
            }
			return res;
		}

		// Decodes your encoded data to tree.
		public TreeNode deserialize(string data)
		{
			if (string.IsNullOrEmpty(data)) return null;
			int i = 0;
			var queue = new Queue<TreeNode>();
			var root = getNode(data, ref i);
			queue.Enqueue(root);
			while (i < data.Length)
			{
				var node = queue.Dequeue();
				node.left = getNode(data, ref i);
				if (node.left != null) queue.Enqueue(node.left);

				node.right = getNode(data, ref i);
				if (node.right != null) queue.Enqueue(node.right);
			}
			return root;
		}

		private TreeNode getNode(string data, ref int i)
		{
			if (i >= data.Length) return null;

			var strVal = new StringBuilder();
            while (i < data.Length && data[i] != ',')
            {
                strVal.Append(data[i]);
                i++;
            }
			i++; //skip ','
			if (strVal.ToString() == "null") return null;

			int v;
			if (Int32.TryParse(strVal.ToString(), out v))
				return new TreeNode(v);
			else
				throw new InvalidOperationException(string.Format("data can't be deserialized: {0}", strVal.ToString()));
		}
    }
}
