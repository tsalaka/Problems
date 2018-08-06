using System;
namespace LeetCode
{
    //O((N^2) worse case(when elements are in asc order), O(n*LgN) average case(with shuffle)
    public class QuickSort
    {
        public void Sort(int[] arr){
            Shuffle(arr);
            Sort(arr, 0, arr.Length - 1);
        }

        private void Sort(int[] arr, int l, int h){
            if (l >= h) return;
            var ind = Partition(arr, l, h);
            Sort(arr, l, ind - 1);
            Sort(arr, ind + 1, h);
        }

        private void Shuffle(int[] arr){
            var r = new Random();
            for (int i = 0; i < arr.Length;i++){
                Exchange(arr, i, r.Next(i+1));
            }
        }

        private int Partition(int[] arr, int l, int h){
            int i = l;
            int j = h+1;
            while(true){
                while(arr[++i] < arr[l]){
                    if (i == h) break;
                }

                while(arr[--j] > arr[l])
                {
                    if (j == l) break;
                }

                if (i >= j) break;
                Exchange(arr, i, j);
            }
            Exchange(arr, l, j);
            return j;
        }
		
        private void Exchange(int[] array, int i, int j)
        {
            var temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }
}
