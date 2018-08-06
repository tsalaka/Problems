using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Graphs
{
    public class AlientDictionary
    {
        private bool[] _marked;
        private Stack<char> _stack;
        private bool[] _inStack;
        private HashSet<int> _inDictionary;
        private List<int>[] _adjacents;

		public string AlienOrder(string[] words)
		{
            _marked = new bool[26];
            _stack = new Stack<char>();
            _inStack = new bool[26];
            _inDictionary = new HashSet<int>();
            _adjacents = new List<int>[26];

            if (words.Length == 0) return string.Empty;
            if (words.Length == 1) return words[0];
			for (int i = 0; i < 26; i++)
				_adjacents[i] = new List<int>();

			for (int j = 0; j < words[0].Length; j++)
			{
				if (!_inDictionary.Contains((int)(words[0][j] - 'a')))
					_inDictionary.Add((int)(words[0][j] - 'a'));
			}
            //add dependencies based on equal prefixes of words(ex, mtr, mta => r->a; mta, bac=> m->b)
			for (int i = 1; i < words.Length; i++)
			{
                for (int j = 0; j < words[i].Length;j++)
                {
                    if (!_inDictionary.Contains((int)(words[i][j] - 'a')))
                        _inDictionary.Add((int)(words[i][j] - 'a'));
                }
                int p = 0;
                int m = 0;
                while(p < words[i-1].Length && m < words[i].Length && words[i-1][p] == words[i][m])
                {
                    p++; m++;
                }

                if (p < words[i - 1].Length && m < words[i].Length)
                {
                    var v = (int)(words[i - 1][p] - 'a');
                    var w = (int)(words[i][m] - 'a');
                    _adjacents[v].Add(w);
                }
			}

			for (int i = 0; i < _adjacents.Length; i++)
			{
                if (!_inDictionary.Contains(i)) continue;
				if (!_marked[i])
					if (Dfs(i)) return string.Empty;
			}

			var str = new StringBuilder();
			while (_stack.Count != 0)
			{
				str.Append(_stack.Pop());
			}
			return str.ToString();
		}

		//returns true if there is cycle
		private bool Dfs(int v)
		{
			_marked[v] = true;
			_inStack[v] = true;
			foreach (var w in _adjacents[v])
			{
				if (_inStack[w]) return true;
				if (!_marked[w])
					if (Dfs(w)) return true;
			}
			_stack.Push((char)(v + (int)'a'));
			_inStack[v] = false;
			return false;
		}
    }
}
