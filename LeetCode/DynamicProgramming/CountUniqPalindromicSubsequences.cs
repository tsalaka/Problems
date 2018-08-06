using System;
namespace LeetCode.DynamicProgramming
{
	// 730
	//Given a string S, find the number of different non-empty palindromic subsequences in S, and return that number modulo 10^9 + 7.
	//A subsequence of a string S is obtained by deleting 0 or more characters from S.
	//A sequence is palindromic if it is equal to the sequence reversed.
	//Two sequences A_1, A_2, ... and B_1, B_2, ... are different if there is some i for which A_i != B_i
    public class CountUniqPalindromicSubsequences
    {
		public int CountPalindromicSubsequences(string s)
		{
			int n = s.Length;
			int[,] matrix = new int[n, n];

			// if string consists of one letter('aaa') algorithm calculates all palindromes(including duplicates)
			// that's why we devide by 2 to get unique palindromes result
			//bool isOneLetterString = true;
			for (int k = 0; k < n; k++)
			{
				int i = 0;
				for (int j = k; j < n; j++)
				{
					if (i == j)
						matrix[i, j] = 1;
					else
					{
						//if (isOneLetterString && i == 0 && s[i] != s[j])
						//	isOneLetterString = false;
						matrix[i, j] = matrix[i, j - 1] + matrix[i + 1, j] - matrix[i + 1, j - 1];
                        if (s[i] == s[j])
                        {
                            bool isOneLetterSubstring = true; 
                            for (int m = i+1; m <= j;m++){
                                if (s[m - 1] != s[m])
                                {
                                    isOneLetterSubstring = false;
                                    break;
                                }
                                
                            }
                            if(! isOneLetterSubstring)
                                matrix[i, j] += 1;
                        }
					}
					i++;
				}
			}
            int count = matrix[0, n - 1];
			//if (isOneLetterString)
			//{
            //    count = count / 2 + (count % 2 == 0 ? 0 : 1);
			//}
            return (int)(count % (Math.Pow(10, 9) + 7));
		}
    }
}
