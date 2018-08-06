using System;
using System.Collections.Generic;

namespace LeetCode
{
    public class HeapItem<TValue>{
		public int Key { get; set; }
		public TValue Value { get; set; }
	}

	public class MaxHeap<TValue>
	{
		private readonly IList<HeapItem<TValue>> items;

		public MaxHeap()
		{
			items = new List<HeapItem<TValue>>();
		}

		public void Insert(HeapItem<TValue> item)
		{
			items.Add(item);
            int i = items.Count - 1;
			while (i > 0)
			{
                if (items[(i - 1) / 2].Key >= item.Key) break;
				Swap(i, (i - 1) / 2);
				i = (i - 1) / 2;
			}
		}

		private void Sort(int i)
		{
			int leftInd = 2 * i + 1;
			int rightInd = 2 * i + 2;

			int maxValInd = i;
            if (leftInd < items.Count && items[leftInd].Key > items[i].Key)
				maxValInd = leftInd;
            if (rightInd < items.Count && items[rightInd].Key > items[maxValInd].Key)
				maxValInd = rightInd;
			if (i != maxValInd)
			{
				Swap(i, maxValInd);
				Sort(maxValInd);
			}
		}

		private void Swap(int i, int j)
		{
			var temp = items[i];
			items[i] = items[j];
			items[j] = temp;
		}

		public int Count()
		{
            return items.Count;
		}

		public HeapItem<TValue> GetMax()
		{
            Swap(0, items.Count - 1);
            var res = items[items.Count - 1];
            items.RemoveAt(items.Count-1);
			Sort(0);
			return res;
		}
	}
}
