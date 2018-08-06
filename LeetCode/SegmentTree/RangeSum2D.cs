using System;
namespace LeetCode.SegmentTree
{
    public class RangeSum2D
    {
		private readonly int[] _tree;
		private readonly int n;
	    private readonly int m;
	    
	    public RangeSum2D(int[,] matrix)
        {
			n = matrix.GetLength(0);
			m = matrix.GetLength(1);
			_tree = new int[2 * n * m];

			var p = n * m;
			for (int i = 0; i < matrix.GetLength(0); i++)
				for (int j = 0; j < matrix.GetLength(1); j++)
				{
					_tree[p++] = matrix[i, j];
				}
			
	        
	        for(int i=n* m-1; i>0;i--){
	            _tree[i] = _tree[i * 2] + _tree[i * 2 + 1];
	        }

		}

		public void Update(int row, int col, int val)
		{
			if (row < 0 || row >= n || col < 0 || col >= m)
				throw new Exception("Invalid data");

			int i = n * m + row * m + col;
			var diff = val - _tree[i];
			while (i > 0)
			{
				_tree[i] += diff;
				i /= 2;
			}
		}

		public int SumRegion(int row1, int col1, int row2, int col2)
		{
			int c = 0;
			int sum = 0;
			while (c <= (row2 - row1))
			{
				int i = n * m + (row1 + c) * m + col1;
				int j = i + col2 - col1;
				while (i <= j)
				{
					if (i % 2 == 1)
					{
						sum += _tree[i];
						i++;
					}
					if (j % 2 == 0)
					{
						sum += _tree[j];
						j--;
					}
					i /= 2;
					j /= 2;
				}
                c++;
			}
            return sum;
		}
    }
}
