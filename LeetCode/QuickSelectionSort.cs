using System;
namespace LeetCode
{
    public class QuickSelectionSort
    {
        //O(N) without large amount of duplication items
		public int FindKthLargest(int[] nums, int k)
		{
			Shuffle(nums);

			Sort(nums, k - 1, 0, nums.Length - 1);
			return nums[k-1];
		}

		private void Shuffle(int[] nums)
		{
			var r = new Random();
			for (int i = 0; i < nums.Length; i++)
			{
				int j = r.Next(i + 1);
				Swap(nums, i, j);
			}
		}

        private void Sort(int[] arr, int k, int l, int h){
            if (l >= h) return;
            int ind = Partition(arr, l, h);
            if (k == ind) return;
            if (k < ind) Sort(arr, k, l, ind - 1);
            else Sort(arr, k, ind + 1, h);
        }

        private int Partition(int[] arr, int l, int h){
            int i = l;
            int j = h+1;
            while(true){
                while (arr[++i] > arr[l])
                    if (i == h) break;

                while (arr[--j] < arr[l])
                    if (j == l) break;

                if (i >= j) break;
                Swap(arr, i, j);
            }
            Swap(arr, l, j);
            return j;
        }
		
		private void Swap(int[] nums, int i, int j)
		{
			var temp = nums[i];
			nums[i] = nums[j];
			nums[j] = temp;
		}
    }
}
