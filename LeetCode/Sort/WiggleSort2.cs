using System;
namespace LeetCode.Sort
{
    public class WiggleSort2
    {
        public void Sort(int[] array){
            int i = 0; 
            int j = 1;
            //5,3,7,1,4
            //3,5,7,4,1
            while(i < array.Length && j < array.Length){
                if(i % 2 == 0)
                {
                    if (array[i] > array[j])
                        Exchange(array, i, j);
                }
                else{
                    if (array[i] < array[j])
                        Exchange(array, i, j);
                }
                i++; j++;
            }
        }

        private void Exchange(int[] array, int i, int j){
            var temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }
}
