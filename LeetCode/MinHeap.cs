using System;
using System.Collections.Generic;

namespace LeetCode
{
	public class TrieNode
	{
		public string Dictionary<char, TrieNode> Children{ get; set; }
		public bool IsEndOfWord { get; set; }

		public TrieNode()
		{
			Children = new Dictionary<char, TrieNode>();
		}
	}

	public class Trie
	{
		private readonly TrieNode root;
		public Trie()
		{
			root = new TrieNode();
		}

		public void Insert(string word)
		{
			var node = root;
			for (int i = 0; i < word.Length; i++)
			{
				if (!node.Children.ContainsKey(word[i]))
					node.Children.Add(word[i], new TrieNode());
				node = node.Children[word[i]];
			}
			node.IsEndOfWord = true;
		}

		public void Search(string word)
		{
			var node = root;
			for (int i = 0; i < word.Length; i++)
			{
				if (!node.Children.ContainsKey(word[i]))
					return false;
				node = node.Children[word[i]];
			}
			return node.IsEndOfWord;
		}

		public void SearchPrefix(string prefix)
		{
			var node = root;
			for (int i = 0; i < prefix.Length; i++)
			{
				if (!node.Children.ContainsKey(prefix[i]))
					return false;
				node = node.Children[prefix[i]];
			}
			return true;
		}

		public void Remove(string word)
		{
			Remove(word, 0, root);
		}

		private bool Remove(string word, int i, TrieNode node)
		{
			if (p == word.Length)
				return node.Children.Count == 0;

			var next = node.Children[word[i]];
			var markedForDeletion = Remove(word, i + 1, next);
			if (markedForDeletion)
				node.Children.Remove(word[i]);
			return !node.IsEndOfWord && node.Children.Count == 0;
		}
	}
	public class Solution
	{
		public IList<string> FindWords(char[,] board, string[] words)
		{
			var trie = new Trie();
			for (int i = 0; i < words[i].Length; i++)
			{
				trie.Insert(words[i]);
			}

			var res = new List<string>();
			BackTracking(board, 0, 0, trie, new StringBuilder(), res);
			return res;
		}

		private void BackTracking(char[,] board, int i, int j, Trie trie, StringBuilder str, IList<string> res)
		{
			if (i < 0 || i >= board.GetLength(0) || j < 0 || j >= board.GetLength(1) || board[i, j] == '\0') return;
			var c = board[i, j];
			board[i, j] = '\0';
			str.Append(c);
			var word = str.ToString();
			if (trie.Search(word))
			{
				res.Add(word);
				trie.Remove(word);
			}
			if (trie.SearchPrefix(word))
			{

				BackTracking(board, i + 1, j, marked, res);
				BackTracking(board, i - 1, j, marked, res);
				BackTracking(board, i, j - 1, marked, res);
				BackTracking(board, i, j + 1, marked, res);
				//marked[i,j] = false;
			}
			board[i, j] = c;
			str.Remove(str.Length - 1, 1);
		}
	}
    public class MinHeapItem
    {
        public int Key { get; set; }
        public int Value { get; set; }
    }

    public class MinHeap
    {
        private readonly IList<MinHeapItem> nums;

        public MinHeap()
        {
            nums = new List<MinHeapItem>();
        }

        public void Insert(MinHeapItem item){
            nums.Add(item);
            int i = nums.Count - 1;
            while(i > 0){
                int parentInd = (i - 1) / 2;
                if (nums[parentInd].Key < nums[i].Key) break;
                Swap(i, parentInd);
                i = parentInd;
            }
        }

        public MinHeapItem GetMin(){
            Swap(0, nums.Count-1);
            var min = nums[nums.Count - 1];
            nums.RemoveAt(nums.Count-1);
            Sort(0);
            return min;
        }

        private void Sort(int i){
            int left = 2 * i + 1;
            int right = 2 * i + 2;
            int newInd = i;
            if (left < nums.Count && nums[left].Key < nums[i].Key)
                newInd = left;
            if (right < nums.Count && nums[right].Key < nums[i].Key)
                newInd = right;

            if (i != newInd){
                Swap(i, newInd);
                Sort(newInd);
            }
        }

        private void Swap(int i, int j){
            var temp = nums[i];
            nums[i] = nums[j];
            nums[j] = temp;
        }
    }
}
