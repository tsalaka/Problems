using System;
namespace LeetCode.DivideAndConqur
{
	// 169
	//Given an array of size n, find the majority element.
    //The majority element is the element that appears more than ⌊ n/2 ⌋ times.
    public class MajorityElement
    {
        public int GetMajority(int[] nums)
        {
            int majority = nums[0];
            int count = 1;
            for (int i = 1; i < nums.Length; i++)
            {
                if (count == 0)
                {
                    majority = nums[i];
                    count = 1;
                }
                else
                {
                    if (majority == nums[i])
                        count++;
                    else
                        count--;
                }
            }

            return majority;
        }
    }
}
