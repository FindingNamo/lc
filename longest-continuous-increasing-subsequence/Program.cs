using System;

namespace longest_continuous_increasing_subsequence {
    class Program {
        static void Main (string[] args) {
            Console.WriteLine ("Hello World!");
        }
    }

    public class Solution {

        // Start at index 0 and count 1 and max = 1
        // if 1 or higher, check if num is higher than last
        // if so count++ and max = math max count and max
        // else count back at 1
        public int FindLengthOfLCIS (int[] nums) {

            if (nums.Length == 0)
                return 0;

            if (nums.Length == 1)
                return 1;

            int count = 1;
            int max = 1;
            for (int i = 0; i < nums.Length; i++) {
                if (i > 0) {
                    if (nums[i] > nums[i - 1]) {
                        count++;
                        max = Math.Max (count, max);
                    } else {
                        count = 1;
                    }
                }
            }

            return max;
        }
    }
}