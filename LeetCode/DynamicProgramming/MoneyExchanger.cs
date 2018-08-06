﻿using System;
namespace LeetCode.DynamicProgramming
{
	//322
	//You are given coins of different denominations and a total amount of money amount. 
    //Write a function to compute the fewest number of coins that you need to make up that amount. 
    //If that amount of money cannot be made up by any combination of the coins, return -1.
	public class MoneyExchanger
    {
        public int GetExchange(int[] coins, int amount){
			if (coins == null || coins.Length == 0)
				return -1;
            
            var sort = new MergeSort();
            // sort in descendent order
            Array.Sort(coins, (x,y) => x - y);

            var change = new int[amount+1];
            for (int l = 1; l <= amount;l++){
                change[l] = amount + 1; //Int32.MaxValue if coins are double, since they are int the max can be 'amount
            }
            //change[0]=0, others have max(amount+1) values
            for (int i = 1; i <= amount; i++){
                for (int j = 0; j < coins.Length;j++){
                    if(coins[j] <= i){
                        var current = 1 + change[i - coins[j]]; // 1 is current coint + reminder
                        change[i] = Math.Min(change[i], current);
                    }
                }
            }

            return change[amount] > amount ? -1 : change[amount];
        }
    }
}
