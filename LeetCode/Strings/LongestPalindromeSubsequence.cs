using System;
namespace LeetCode.Strings
{
	//516
	//Given a string s, find the longest palindromic subsequence's length in s. 
    //bbbab-> bbbb (4)
	public class LongestPalindromeSubsequence
    {
		public int LongestPalindromeSubseq(string s)
		{
            var n = s.Length;
            int[,] matrix = new int[n, n];

            for (int k = 0; k < n; k++){
                int i = -1;
                for (int j = k; j < n; j++)
                {
                    i++;
                    if (i == j)
                    {
                        matrix[i, j] = 1;
                        continue;
                    }
                    if(s[i] == s[j]){
                        matrix[i, j] = 2 + matrix[i + 1, j - 1];
                    }
                    else{
                        matrix[i,j] = Math.Max(matrix[i, j - 1], matrix[i + 1, j]);
                    }
                }
            }

            return matrix[0, n - 1];
		}
    }
}
