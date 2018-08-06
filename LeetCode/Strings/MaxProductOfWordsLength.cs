using System;
namespace LeetCode.Strings
{
    //318
    public class MaxProductOfWordsLength
    {
        int maxProduct = 0;

        public int MaxProduct(string[] words)
        {
            int[] checkerArray = new int[words.Length];
            for (int i = 0; i < words.Length; i++)
            {
                for (int k = 0; k < words[i].Length; k++)
                {
                    int bitIndex = words[i][k] - 'a';
                    checkerArray[i] = checkerArray[i] | (1 << bitIndex);
                }
            }
            for (int i = 0; i < checkerArray.Length; i++)
            {
                for (int j = i + 1; j < checkerArray.Length; j++)
                {
                    if((checkerArray[i] & checkerArray[j]) == 0)
                    {
						int currentProduct = words[i].Length * words[j].Length;
						maxProduct = maxProduct == 0 || currentProduct > maxProduct ? currentProduct : maxProduct;
                    }
                }
            }
            return maxProduct;
        }
    }

}
