using System;
namespace LeetCode.Graphs
{
    public class UnionFind
    {
        private readonly int[] _arr;
        private readonly int[] _size;

        public UnionFind(int n)
        {
            _arr = new int[n];
			_size = new int[_arr.Length];
            for (int i = 0; i < n; i++)
            {
                _arr[i] = i;
                _size[i] = 1;
            }
        }

        public bool Union(int v1, int v2)
        {
            var p1 = GetParent(v1);
            var p2 = GetParent(v2);

            if (p1 == p2) return false;

            if (_size[p1] < _size[p2])
            {
                _arr[p1] = p2;
                _size[p2] += _size[p1];
            }
            else
            {
                _arr[p2] = p1;
                _size[p1] += _size[p2];
            }
            return true;
        }

        public int GetParent(int p)
        {
            if (p != _arr[p])
                p = GetParent(_arr[p]);
            return _arr[p];
        }
    }
    public class RedundantConnections
    {
        private const int MaxCount = 1000;
        public int[] FindRedundantConnection(int[,] edges)
        {
            var uf = new UnionFind(MaxCount+1);
            for (int i = 0; i < edges.GetLength(0); i++)
            {
                if (!uf.Union(edges[i, 0], edges[i, 1]))
                    return new int[] { edges[i, 0], edges[i, 1] };
            }
            return new int[2];
        }
    }
}
