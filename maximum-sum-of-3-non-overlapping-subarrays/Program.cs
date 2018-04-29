using System;

namespace maximum_sum_of_3_non_overlapping_subarrays {
    class Program {
        static void Main (string[] args) {
            Console.WriteLine ("Hello World!");
            new Solution ().MaxSumOfThreeSubarrays (new int[] { 1,2,1,2,6,7,5,1 }, 2);
        }
    }

    public class Solution {

        /*
    
        Calculate all sums at each index
        Calculate max sum so far starting from left and store index at index
        Calculate max sum so far starting from right and store index at index
        [3,3,3,8,13,12,6] length 7: max: 4
        [0,0,0,3,4 ,4 ,4]
        [4,4,4,4,4 ,5 ,6]
    
    
        */
        public int[] MaxSumOfThreeSubarrays (int[] nums, int k) {
            int[] sums = GetSums (nums, k);
            int[] maxLeft = GetMaxFromLeft (sums);
            int[] maxRight = GetMaxFromRight (sums);

            int curSum = int.MinValue;
            int left = -1;
            int mid = -1;
            int right = -1;
            for (int i = k; i < sums.Length - k; i++) {
                if (sums[maxLeft[i - k]] + sums[i] + sums[maxRight[i + k]] > curSum) {
                    left = maxLeft[i - k];
                    mid = i;
                    right = maxRight[i + k];
                    curSum = sums[maxLeft[i - k]] + sums[i] + sums[maxRight[i + k]];
                }
            }

            return new int[] { left, mid, right };

        }

        private int[] GetSums (int[] nums, int k) {
            int[] sums = new int[nums.Length - k + 1];
            int curSum = 0;
            for (int i = 0; i < k; i++) {
                curSum += nums[i];
            }

            sums[0] = curSum;
            for (int i = 1; i < sums.Length; i++) {
                curSum -= nums[i - 1];
                curSum += nums[i+k-1];
                sums[i] = curSum;
            }

            return sums;
        }

        private int[] GetMaxFromLeft (int[] sums) {
            int[] max = new int[sums.Length];
            int curMax = sums[0];
            max[0] = 0;
            for (int i = 1; i < sums.Length; i++) {
                if (sums[i] > curMax) {
                    curMax = sums[i];
                    max[i] = i;
                } else {
                    max[i] = max[i - 1];
                }
            }

            return max;
        }

        private int[] GetMaxFromRight (int[] sums) {
            int[] max = new int[sums.Length];
            int curMax = sums[sums.Length - 1];
            max[sums.Length - 1] = sums.Length - 1;
            for (int i = sums.Length - 2; i >= 0; i--) {
                if (sums[i] >= curMax) {
                    curMax = sums[i];
                    max[i] = i;
                } else {
                    max[i] = max[i + 1];
                }
            }

            return max;
        }
    }
}