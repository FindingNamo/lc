using System;
using System.Collections.Generic;

namespace coin_change {
    class Program {
        static void Main (string[] args) {
            Console.WriteLine ("Hello World!");
            var res = new Solution ().CoinChange (new [] { 5,306,188,467,494 }, 7047);
        }
    }

    public class Solution {

        Dictionary<int, int> dp = new Dictionary<int, int> ();

        public int CoinChange (int[] coins, int amount) {
            dp = new Dictionary<int, int> ();
            return Util (coins, amount);
        }

        private int Util (int[] coins, int amount) {
            if (amount == 0)
                return 0;

            if (amount < 0)
                return -1;

            int minCoins = int.MaxValue;
            if (dp.ContainsKey (amount)) {
                minCoins = dp[amount];
            } else {
                foreach(int coin in coins) {
                    int res = Util(coins, amount - coin);
                    if (res != -1) {
                        minCoins = Math.Min (res+1, minCoins);
                    }
                }

                minCoins = minCoins == int.MaxValue ? -1 : minCoins;
                dp[amount] = minCoins;
            }

            return minCoins;
        }
    }
}