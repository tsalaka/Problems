using System;
namespace LeetCode.Arrays
{
    //186 
    //Given s = "the sky is blue",
    //return "blue is sky the".
    public class ReverseWords
    {
		public void Reverse(char[] str)
		{
			int start = 0;
			int end = str.Length - 1;
			//rotate: the moon -> noom eht
			Reverse(str, start, end);
			//reverse each word
			int i = 0;
			while (i < str.Length)
			{
				int j = i;//word length
				while (j < str.Length && str[j] != ' ') j++;
				Reverse(str, i, j - 1);
				i = j + 1;//word + space
			}
			//end = ShiftFirstWordToLeft(str, start, end);
			//if (start >= end) break;
			//start = ShiftLastWordToRight(str, start, end);
		
		}

        private void Reverse(char[] str, int start, int end){
			while (start < end)
			{
				var temp = str[start];
				str[start] = str[end];
				str[end] = temp;
				start++;
				end--;
			}
        }



        //----------------------------//
        //should be reworked//
		// first word will be shift to the end of sentence
		// return new end position(skip shifted word)
		private int ShiftFirstWordToLeft(char[] s, int start, int end)
		{
			//we shoudn't leave space if it is last character of string
			if (end != s.Length - 1 && s[end+1] != ' ')
				while (end > start && s[end] == ' ') end--;
            int n = end - start + 1;
            // count first word length
            //skip space before a word
            int i = start;
            int k = 0; //number letters to shift
			if(s[start] == ' ')
            {
                i += 1;
                k += 1;
            }
            while (i <= end && s[i] != ' ') { i++; k++; }
			int gcd = GreatestCommonDivisor(n, k); // shift round
			for (int round = 0; round < gcd; round++)
			{
				int count = n / gcd; // number of steps for one shift round
				i = round;
				var current = s[start + i];
				while (count-- > 0)
				{
					int j = i < k ? i + (n - k) : i - k;
					var temp = s[start + j];
					s[start + j] = current;
					current = temp;
					i = j;
				}
			}
			end -= k;
			return end;
		}

		// last word will be shift to the begging of sentence
		// return new end position(skip shifted word)
		private int ShiftLastWordToRight(char[] s, int start, int end)
		{
			//Trim(s, ref start, ref end);
			//we shouldn't leave space if it is first character of string
			if (start != 0 && s[start-1] != ' ')
				while (start < end && s[start] == ' ') start++;
            int n = end - start + 1;
			int i = end;
            int k = 0; //number letters to shift
            if(s[end] == ' '){
                i -= 1;
                k += 1;
            }
            while (i >= start && s[i] != ' ') { i--; k++; }
			int gcd = GreatestCommonDivisor(n, k); // shift round
			for (int round = 0; round < gcd; round++)
			{
				int count = n / gcd; // number of steps for one shift round
				i = round;
				var current = s[start + i];
				while (count-- > 0)
				{
					int j = i + k >= n ? i + k - n : i + k;
					var temp = s[start + j];
					s[start + j] = current;
					current = temp;
					i = j;
				}
			}
			start += k;
            //while (s[end] == ' ') end--;
			//while (s[start] == ' ') start++;
			return start;
		}

        private void Trim(char[] s, ref int start, ref int end){
			//we shouldn't leave space if it is first character of string
			if(start != 0)
                while (start < end && s[start] == ' ') start++;
            //we shoudn't leave space if it is last character of string
            if(end != s.Length-1)
                while (end > start && s[end] == ' ') end--;
        }

		private int GreatestCommonDivisor(int a, int b)
		{
			int n1 = Math.Min(a, b);
			int n2 = Math.Max(a, b);
			if (n1 == 0) return 1;
			var r = n2 % n1;
			while (r != 0)
			{
				n2 = Math.Max(r, n1);
                n1 = Math.Min(r, n1);
				r = n2 % n1;
			}
			return n1;
		}
    }
}
