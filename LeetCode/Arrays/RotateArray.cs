using System;
namespace LeetCode.Arrays
{
	//Given an array, rotate the array to the right by k steps, where k is non-negative.
   
	//Example 1:

	//Input: [1,2,3,4,5,6,7]
	//	and k = 3
	//Output: [5,6,7,1,2,3,4]
	//	Explanation:
	//rotate 1 steps to the right: [7,1,2,3,4,5,6]
	//	rotate 2 steps to the right: [6,7,1,2,3,4,5]
	//	rotate 3 steps to the right: [5,6,7,1,2,3,4]
    public class RotateArray
    {
		//если k не кратно n(nums.Length), то сдвинуть можно за один круг (GCD=1)
		//попеременно перемещая элем на n-k влево, начиная с k-го с конца: (n-k)-й станет 1-м, 1-й станет n-(n-k)-м
		//если k кратно n, то нужно найти GCD(greates common divisor) и повторять шаг выше GCD раз
		//(потому что k шагов мы вернемся к первому числу)

		public void Rotate(int[] nums, int k)
		{
			var n = nums.Length;
			k %= n;
			if (k == 0) return;

			var gcd = GreatestCommonDivisor(n, k); // shift rounds number
			for (int round = 0; round < gcd; round++)
			{
				int t = n / gcd; // number of steps for one shift round
				int i = round;
				var current = nums[i];
				while (t-- > 0)
				{
					var j = i < n - k ? i + k : i - (n - k);
					var temp = nums[j];
					nums[j] = current;
					current = temp;
					i = j;
				}
			}
		}

		private int GreatestCommonDivisor(int a, int b)
		{
			var n1 = Math.Min(a, b);
			var n2 = Math.Max(a, b);
			if (n1 == 0) return 1;
			while (n2 % n1 != 0)
			{
				var r = n2 % n1;
				n2 = Math.Max(n1, r);
				n1 = Math.Min(r, n1);
			}
			return n1;
		}
    }
}
