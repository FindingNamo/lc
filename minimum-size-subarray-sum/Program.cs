using System;

namespace minimum_size_subarray_sum {
    class Program {
        static void Main (string[] args) {
            Console.WriteLine ("Hello World!");
            new Solution().MinSubArrayLen(11, new int[] {1,2,3,4,5});
        }
    }

    public class Solution {

        // have 2 pointers l and r
        // inc r until we reach at least s 
        // if we reach end and don't reach s, return 0
        // if we do reach s save 
        // [2,3,1,2,4,3]
        //        ^   ^       sum 7 size 3
        public int MinSubArrayLen (int s, int[] nums) {
            int l = 0;
            int r = 0;
            int sum = 0;
            int size = int.MaxValue;

            // inc r until we reach s
            for (int i = 0; i < nums.Length; i++) {
                sum = sum + nums[i];
                if (sum >= s) {
                    r = i;
                    break;
                }
            }

            // if we never reach s, return
            if (sum < s)
                return 0;

            // calc current size
            size = r - l + 1;

            while (r < nums.Length) {

                // inc l until we have smallest array
                while (sum - nums[l] >= sum) {
                    sum = sum - nums[l];
                    l++;
                }

                // check if size has improved (smaller)
                size = Math.Min (size, r - l + 1);

                // inc r
                r++;

                // update if r is valid
                if (r < nums.Length)
                    sum = sum + nums[r];
            }

            return size;
        }
    }
}