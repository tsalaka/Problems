using NUnit.Framework;
using System;
using LeetCode.BackTracking;

namespace LeetCode.Tests.BackTracking
{
    [TestFixture()]
    public class FlipGameTest
    {
		public int MinArea(char[,] image, int x, int y)
		{
			int x1 = image.GetLength(0);
			int x2 = 0;
			int y1 = image.GetLength(1);
			int y2 = 0;
			Bfs(image, x, y, ref x1, ref x2, ref y1, ref y2);
			return (x2 - x1 + 1) * (y2 - y1 + 1);
		}

		private bool IsBlackPixel(char[,] image, int i, int j)
		{
			if (i < 0 || j < 0 || i >= image.GetLength(0) || j >= image.GetLength(1)) return false;
			return image[i, j] == '1';
		}

		private void Bfs(char[,] image, int i, int j, ref int x1, ref int x2, ref int y1, ref int y2)
		{
			if (i < 0 || j < 0 || i >= image.GetLength(0) || j >= image.GetLength(1) || image[i, j] == '0')
				return;
			image[i, j] = '0';

			x1 = Math.Min(x1, i);
			x2 = Math.Max(x2, i);
			y1 = Math.Min(y1, j);
			y2 = Math.Max(y2, j);
			Bfs(image, i - 1, j, ref x1, ref x2, ref y1, ref y2);
			Bfs(image, i + 1, j, ref x1, ref x2, ref y1, ref y2);
			Bfs(image, i, j - 1, ref x1, ref x2, ref y1, ref y2);
			Bfs(image, i, j + 1, ref x1, ref x2, ref y1, ref y2);

			image[i, j] = '1';
		}

        [Test()]
        public void TestCase()
        {
            var image = new char[,] { 
                { '0', '0', '1', '0' }, 
                { '0', '1', '1', '0' }, 
                { '0', '1', '0', '0' } };
            Assert.AreEqual(6, MinArea(image, 0, 2));
            var p = new FlipGame();
            Assert.False(p.CanWin("+++++++++"));
			Assert.True(p.CanWin("++++"));
			Assert.False(p.CanWin("+++++"));
			Assert.False(p.CanWin("+--+++-++-+++++-"));
			Assert.True(p.CanWin("+--+++-++--++++-"));
        }
    }
}
