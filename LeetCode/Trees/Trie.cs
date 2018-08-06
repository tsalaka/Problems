using System;
using System.Collections.Generic;

namespace LeetCode.Trees
{
	public class TrieNode
	{
		public bool IsEndOfWord { get; set; }
        public Dictionary<char, TrieNode> Children { get; set; }
        public TrieNode(){
            Children = new Dictionary<char, TrieNode>();
        }
    }

    public class Trie
    {
        private readonly TrieNode _root;

        public Trie()
        {
            _root = new TrieNode();
        }

        public void Insert(string word)
        {
            var node = _root;
            for (int i = 0; i < word.Length; i++)
            {
                if (node.Children.ContainsKey(word[i]))
                {
                    node = node.Children[word[i]];
                }
                else
                {
                    var n = new TrieNode();
                    node.Children.Add(word[i], n);
                    node = n;
                }
                if (i == word.Length - 1)
                    node.IsEndOfWord = true;
            }
        }

        public bool Search(string word)
        {
            var node = _root;
            for (int i = 0; i < word.Length; i++)
            {
                if (!node.Children.ContainsKey(word[i]))
                    return false;
                node = node.Children[word[i]];
            }
            return node.IsEndOfWord;
        }

        public bool StartsWith(string prefix)
        {
            var node = _root;
            for (int i = 0; i < prefix.Length; i++)
            {
                if (!node.Children.ContainsKey(prefix[i]))
                    return false;
                node = node.Children[prefix[i]];
            }
            return true;
        }

		public void Delete(string word)
		{
			Delete(word, _root, 0);
		}

		private bool Delete(string word, TrieNode node, int p)
		{
			if (p == word.Length)
				node.IsEndOfWord = false;
			else
			{
				var next = node.Children[word[p]];

				var markedForDelete = Delete(word, next, p + 1);
                if (markedForDelete)
                    node.Children.Remove(word[p]);

			}
            return !node.IsEndOfWord && node.Children.Count == 0;
		}
    }
}
