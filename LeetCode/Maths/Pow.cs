using System;
namespace LeetCode.Maths
{
    public class Pow
    {
		public double MyPow(double x, int n)
		{
			if (n == 0)
				return 1;
			int sign = (x < 0 && n % 2 == 1) ? -1 : 1;
			x = x < 0 ? (-1) * x : x;
			double res = x;
			// use uint to avoid stack overflow use uint;
			// instead of uint you can do the next:
			//if (n > Int32.MaxValue/ 2)
			//{
			//   x *= x;
			// n /= n;
			//}
			// int n = int.MinValue (-1)*n throws overflow exc -> cast to long
			uint uPower = Convert.ToUInt32(n < 0 ? ((-1) * (long)n) : n);
			GetValue(x, uPower, 1, ref res);
			if (n < 0)
				res = 1 / res;
			return sign * res;
		}

		private void GetValue(double x, uint power, uint currentPower, ref double res)
		{
			if (power <= currentPower)
				return;
			if (power >= currentPower + currentPower)
			{
				res *= res;
				currentPower *= 2;
				GetValue(x, power, currentPower, ref res);
			}
			else
			{
				uint reminder = power - currentPower;
				double reminderRes = x;
				GetValue(x, reminder, 1, ref reminderRes);
				res *= reminderRes;
			}
		}
    }
}
