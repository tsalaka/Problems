using System;
using System.Collections.Generic;
namespace LeetCode.Closed.Array
{
     // Design and implement a TwoSum class. It should support the following operations: add and find.          
     // add - Add the number to an internal data structure.
     // find - Find if there exists any pair of numbers which sum is equal to the value.
	public class TwoSum170
    {
		private readonly Dictionary<int, int> uniqueNums;
        private int min = Int32.MaxValue;
        private int max = Int32.MinValue;
		/** Initialize your data structure here. */
		public TwoSum170()
		{
			uniqueNums = new Dictionary<int, int>();
		}

		/** Add the number to an internal data structure.. */
		public void Add(int number)
		{
			if (uniqueNums.ContainsKey(number))
				uniqueNums[number]++;
			else
				uniqueNums.Add(number, 1);
            min = Math.Min(min, number);
            max = Math.Max(max, number);
		}

		/** Find if there exists any pair of numbers which sum is equal to the value. */
		public bool Find(int value)
		{
            if(min+min > value || max+max < value) return false;

            foreach (var num in uniqueNums)
			{
				if (value - num.Key == num.Key)
				{
					if (num.Value > 1) return true;
				}
				else if (uniqueNums.ContainsKey(value - num.Key)) return true;
			}
			return false;
		}
    }
}
