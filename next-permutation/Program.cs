using System;

namespace next_permutation {
    class Program {
        static void Main (string[] args) {
            int[] nums = new int[] {1,20,26,1,15,29,4,29,10,9,21,7,27,11,21,5,9,7,27,16,17,3,6,5,16,23,29,14,28,21,2,29,3,29,0,18,28,5,10,9,6,23,8,25,26,21,1,5,29,28,14,8,1,20,13,10};
            new Solution().NextPermutation(nums);
            Console.WriteLine ("Hello World!");
        }
    }

    public class Solution {
        // is increasing if at least one of more significant digit is bigger
        // start trying to increase from least significant digit
        // smallest increase by minimizing decrease from most significant digit
        // so find first digit with any less significant digit bigger than it
        // swap those
        // sort under it to minimize increase

        public void NextPermutation (int[] nums) {
            if (nums.Length <= 1)
                return;

            // current digit index starting from least significant index
            int cdi = nums.Length - 2;

            while (cdi >= 0) {
                // current digit
                int cd = nums[cdi];

                // Are there any digits larger than it that are less sig dig?
                // What is the index of the minimimally larger number?
                int nldi = GetIndexOfMinimallyLarger (cdi, cd, nums);

                // next smaller digit
                if (nldi >= 0) {
                    int nsd = nums[nldi];

                    // swap if found
                    Swap (nums, nldi, nsd, cdi, cd);

                    // 1,2,3
                    // sort 2 and 3
                    // sort (1 = 0 + 1, 2 = 3 - 0))
                    Array.Sort (nums, cdi + 1, nums.Length - (cdi + 1));
                    return;
                }

                cdi--;
            }

            // stuff is already in increasing order so nothign is bigger
            // sort it so that we get the smallest possible order
            Array.Sort (nums);
        }

        private int GetIndexOfMinimallyLarger (int cdi, int cd, int[] nums) {
            int mldi = -1;
            int mld = int.MaxValue;

            for(int i = cdi + 1; i < nums.Length; i++){
                if(nums[i] > cd && nums[i] < mld){
                    mld = nums[i];
                    mldi = i;
                }
            }

            return mldi;
        }

        private void Swap (int[] nums, int nsdi, int nsd, int cdi, int cd) {
            nums[nsdi] = cd;
            nums[cdi] = nsd;
        }
    }
}