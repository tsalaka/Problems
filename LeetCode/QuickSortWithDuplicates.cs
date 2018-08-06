using System;
namespace LeetCode
{
    // O(NlgN) if all elements are distinct
    // O(N) if only a constant number of distinct keys
    public class QuickSortWithDuplicates
    {
        public void Sort(int[] nums)
        {
            Sort(nums, 0, nums.Length - 1);
        }

        private void Sort(int[] arr, int lo, int hi){
            if(lo >= hi) return;
            int i = lo;
            int l = lo;
            int h = hi;
            while(i <= h)
            {
                if (arr[i] < arr[l]) Swap(arr, i++, l++);
                else if (arr[i] > arr[l]) Swap(arr, i, h--);
                else i++;
            }
            Sort(arr, lo, l - 1);
            Sort(arr, h + 1, hi);
        }

        private void Swap(int[] nums, int i, int j){
            var temp = nums[i];
            nums[i] = nums[j];
            nums[j] = temp;
        }
    }
}
