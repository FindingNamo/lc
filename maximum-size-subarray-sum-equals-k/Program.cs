using System;

namespace maximum_size_subarray_sum_equals_k {
    class Program {
        static void Main (string[] args) {
            Console.WriteLine ("Hello World!");
            new Solution ().MaxSubArrayLen (new int[] {-1, 1 }, 1);
        }
    }

    public class Solution {
        public int MaxSubArrayLen (int[] nums, int k) {
            return Hash (nums, k);
        }

        private int Hash (int[] nums, int k) {
            Dictionary<int, int> h = new Dictionary<int, int> (); // remember sum up to this index, and the index it corresponds to
            int s = 0;
            int max = 0;

            for (int i = 0; i < nums.Length; i++) {
                s += nums[i];
                int delta = s - k;

                if (s == k) // if we found k, store that as current max
                    max = Math.Max (i + 1, max);
                else if (h.ContainsKey (delta)) // if we have found the delta (which is the further delta), then we have found an array that fits
                    max = Math.Max (max, i - h[delta]); // only update max if it's bigger

                if (!h.ContainsKey (s)) // add sum so far but only add once because we want the furthest found
                    h.Add (s, i);

            }

            return max;
        }

        // [-2, -1, 2, 1]
        //  l
        //  r
        // l:0  r:1  sum:-3 k:1 i:2
        private int Brute (int[] nums, int k) {

            // start at biggest test size 
            for (int i = nums.Length; i > 0; i--) {
                int l = 0;
                int r = 0;
                int sum = 0;

                // as long as r not past max testing size
                r = i - 1;
                for (int j = 0; j <= r; j++) {
                    sum += nums[j];
                }

                if (sum == k) // if we find k we found biggest size
                    return r - l + 1;

                // as long as r is not past end
                while (r < nums.Length) {
                    r++;
                    if (r < nums.Length) {

                        sum += nums[r];
                        sum -= nums[l];

                    }
                    l++;

                    if (sum == k) // if we find k we found biggest size
                        return r - l + 1;
                }
            }

            return 0;

        }
    }
}