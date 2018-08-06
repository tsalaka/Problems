using System.Collections.Generic;
using System;

namespace LeetCode.Strings
{
    public class Permutation2
    {
		public IList<IList<int>> PermuteUnique(int[] nums)
		{
			Array.Sort(nums);
			var res = new List<IList<int>>();
			BackTracking(nums, new Dictionary<int, int>(), res);
			return res;
		}

		private void BackTracking(int[] nums, Dictionary<int, int> item, IList<IList<int>> res)
		{
			if (item.Count == nums.Length)
			{
				res.Add(new List<int>(item.Values));
				return;
			}

			for (int i = 0; i < nums.Length; i++)
			{
				if (i > 0 && nums[i] == nums[i - 1] && !item.ContainsKey(i - 1)) continue;
				if (item.ContainsKey(i)) continue;
				item.Add(i, nums[i]);
				BackTracking(nums, item, res);
				item.Remove(i);
			}
		}
    }
}
