using System;
namespace LeetCode
{
    public class MergeSort
    {
        public void Sort(int[] arr){
            var auxArr = new int[arr.Length];
            Sort(arr, auxArr, 0, arr.Length - 1);
        }

        private void Sort(int[] arr, int[] auxArr, int l, int h){
            if (l >= h) return;
            int mid = l + (h - l) / 2;
            Sort(arr, auxArr, l, mid);
            Sort(arr, auxArr, mid + 1, h);
            Merge(arr, auxArr, l, mid+1, h);
        }

        private void Merge(int[] arr, int[] auxArr, int l, int r, int h){
            for (int p = l; p <= h;p++){
                auxArr[p] = arr[p];
            }

            int i = l;
            int j = r;
            for (int k = l; k <= h;k++){
                if (i == r)
                    arr[k] = auxArr[j++];
                else if (j > h)
                    arr[k] = auxArr[i++];
                else if (auxArr[i] <= auxArr[j])
                    arr[k] = auxArr[i++];
                else
                    arr[k] = auxArr[j++];
            }
        }
    }
}
