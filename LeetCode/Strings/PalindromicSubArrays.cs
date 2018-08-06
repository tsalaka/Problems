using System;
namespace LeetCode.Strings
{
	// 647
	// Given a string, your task is to count how many palindromic substrings in this string.
	// The substrings with different start indexes or end indexes are counted 
    // as different substrings even they consist of same characters.
    public class PalindromicSubArrays
    {
        public int GetResult(string str)
        {
            if(str == null || str.Length == 0)
                return 0;
			// increase n to insert separation like | before each letter and at the end
			int n = str.Length * 2 + 1;
			int[] p = new int[n];
			p[0] = 0;
			p[1] = 1;

			int center = 1;
			int rightCenter = 2;
			int currentLeft;
			int diff;
			bool expand = false;
			int palindromeCount = 1;

			for (int currentRight = 2; currentRight < n; currentRight++)
			{
				currentLeft = 2 * center - currentRight;
				diff = rightCenter - currentRight;
				if (diff > 0)
				{
					if (p[currentLeft] < diff && center - p[center] != currentLeft)
						p[currentRight] = p[currentLeft];
					else if (p[currentLeft] == diff
							 && center - p[center] == currentLeft
							 && rightCenter == n - 1)
						p[currentRight] = p[currentLeft];
					else if (p[currentLeft] == diff && rightCenter < n - 1)
					{
						p[currentRight] = p[currentLeft];
						expand = true;
					}
					else if (p[currentLeft] > diff)
					{
						p[currentRight] = diff;
						expand = true;
					}
				}
				else
				{
					expand = true;
				}

				if (expand)
				{
					//Attempt to expand palindrome centered at currentRight position 
					//Here for odd positions, we compare characters and 
					//if match then increment p Length by ONE
					//If even position, we just increment p by ONE without 
					//any character comparison
					while (true)
					{
						var rp = currentRight + p[currentRight] + 1;
						var lp = currentRight - p[currentRight] - 1;
						if (rp == n)
							break;
						if (lp < 0)
							break;
						// just increment when meet separation
						if (rp % 2 == 0)
						{
							p[currentRight]++;
						}
						// devide to 2 because realstring doesn't contain separations
						else if (str[rp / 2] == str[lp / 2])
							p[currentRight]++;
						else
							break;
					}
				}
				//change center
				if (currentRight + p[currentRight] > rightCenter)
				{
					center = currentRight;
					rightCenter = center + p[currentRight];
				}
                var rem = p[currentRight] % 2 == 0 ? 0 : 1;
                var c = p[currentRight] - rem;
                palindromeCount += c / 2 + rem;
			}


            return palindromeCount;
        }
    }
}
