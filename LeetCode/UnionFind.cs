using System;
namespace LeetCode
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
        public void Union(int v1, int v2)
        {
            var p1 = GetParent(v1);
            var p2 = GetParent(v2);

            if (p1 == p2) return;

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
        }

        public bool Connected(int v1, int v2)
        {
            return GetParent(v1) == GetParent(v2);
        }

        public int GetParent(int p)
        {
            if (p != _arr[p])
                p = GetParent(_arr[p]);
            return _arr[p];
        }
    }
}

