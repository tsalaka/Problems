using System;
namespace LeetCode.Trees
{
	//326
    //Given an integer, write a function to determine if it is a power of three(3^x=n)
	public class PowerOfThree
    {
        public bool IsPowerOfThreeBruteForce(int n)
        {
            if (n < 0)
                return false;
         
            while(n>1)
            {
                if (n % 3 != 0)
                    return false;
                n /= 3;
            }

            return n == 1;
        }

        public bool IsPowerOfThree(int n){
			//1162261467=3^19 is the max int
            //19~ log3MaxInt
			return n > 0 && 1162261467 % n == 0;
        }

		public bool IsPowerOfTwo(int n)
		{
            // 1000 & 0111 == 0
            return n > 0 && (n & (n - 1)) == 0;
		}



        public bool IsPowerOfFour(int n)
        {
			// check if 1 is in odd position
			// max number with 1 in odd is 1010101010101010101010101010101 = 1431655765
            return n > 0 && (n & (n - 1)) == 0 && (n & 1431655765) == n;
        }
    }
}
