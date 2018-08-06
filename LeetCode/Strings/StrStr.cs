using System;
namespace LeetCode.Strings
{
    public class StrStr
    {
		public int Check(string haystack, string needle)
		{
            if (haystack.Length < needle.Length) return - 1;
            if (haystack.Length == 0 || needle.Length == 0) return 0;

            int i = 0;
            int j = 0;
            var arr = PrepareKMPArray(needle);

            while(i < haystack.Length && j < needle.Length){
                if(haystack[i] == needle[j]){
                    i++;
                    j++;
                }else{
                    if (j == 0) i++;
                    else j = arr[j - 1];
                }
            }
            return j == needle.Length ? i - needle.Length : -1;
		}

        private int[] PrepareKMPArray(string needle){
            int[] arr = new int[needle.Length];
            if (arr.Length < 1)
                return arr;
            
            int i = 1;
            int j = 0;
            arr[0] = 0;
            while(i < needle.Length){
                if (needle[i] == needle[j])
                {
                    arr[i] = j + 1;
                    i++; j++;
                }
                else{
                    if(j == 0) arr[i++] = 0;
                    else j = arr[j - 1];
                }
            }
            return arr;
        }
    }
}
