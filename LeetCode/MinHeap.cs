using System;
using System.Collections.Generic;

namespace LeetCode
{
    public class MinHeapItem
    {
        public int Key { get; set; }
        public int Value { get; set; }
    }

    public class MinHeap
    {
        private readonly IList<MinHeapItem> nums;

        public MinHeap()
        {
            nums = new List<MinHeapItem>();
        }

        public void Insert(MinHeapItem item){
            nums.Add(item);
            int i = nums.Count - 1;
            while(i > 0){
                int parentInd = (i - 1) / 2;
                if (nums[parentInd].Key < nums[i].Key) break;
                Swap(i, parentInd);
                i = parentInd;
            }
        }

        public MinHeapItem GetMin(){
            Swap(0, nums.Count-1);
            var min = nums[nums.Count - 1];
            nums.RemoveAt(nums.Count-1);
            Sort(0);
            return min;
        }

        private void Sort(int i){
            int left = 2 * i + 1;
            int right = 2 * i + 2;
            int newInd = i;
            if (left < nums.Count && nums[left].Key < nums[i].Key)
                newInd = left;
            if (right < nums.Count && nums[right].Key < nums[i].Key)
                newInd = right;

            if (i != newInd){
                Swap(i, newInd);
                Sort(newInd);
            }
        }

        private void Swap(int i, int j){
            var temp = nums[i];
            nums[i] = nums[j];
            nums[j] = temp;
        }
    }
}
