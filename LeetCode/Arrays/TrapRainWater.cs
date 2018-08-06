using System;
namespace LeetCode.Arrays
{
    public class TrapRainWater
    {
		public int Trap(int[] height)
		{
			int vol = 0;
            int left = 0;
            int right = height.Length - 1;
            int maxLeft = 0;
            int maxRight = 0;
            while (left < right){
                if (height[left] > height[right])
                {
                    if (height[right] < maxRight)
                        vol += maxRight - height[right];
                    else
                        maxRight = height[right];
                    right--;
                }
                else{
                    if (height[left] < maxLeft)
                        vol += maxLeft - height[left];
                    else
                        maxLeft = height[left];
                    left++;

                }
            }
            return vol;
		}
    }
}
