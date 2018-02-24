using System;

namespace _3sum_closest {
    class Program {
        static void Main (string[] args) {
            Console.WriteLine ("Hello World!");
        }
    }

    public class Solution {
        public int ThreeSumClosest (int[] nums, int target) {
            return PreSorted (nums, target);
        }

        public int PreSorted (int[] nums, int target) {
            Array.Sort(nums);
            int result = target >= 0 ? Int32.MinValue : Int32.MaxValue;
            int delta = Int32.MaxValue;

            for(int i = 0; i < nums.Length - 2; i++){
                int left = i+1;
                int right = nums.Length - 1;
                while(right > left){
                    int curSum = nums[i] + nums[left] + nums[right];
                    int curDelta = Math.Abs(target - curSum);

                    if (curDelta == 0)
                        return curSum;

                    if (curDelta < delta){
                        result = curSum;
                        delta = curDelta;
                    }
                    
                    else if(curSum < target)
                        left++;
                    else
                        right--;
                }
            }

            return result;
        }

        public int BruteForce (int[] nums, int target) {
            int result = target >= 0 ? Int32.MinValue : Int32.MaxValue;
            int delta = Int32.MaxValue;
            for (int i = 0; i < nums.Length - 2; i++) {
                for (int j = i + 1; j < nums.Length - 1; j++) {
                    for (int k = j + 1; k < nums.Length; k++) {
                        int sum = nums[i] + nums[j] + nums[k];

                        if (sum == target)
                            return sum;

                        if (Math.Abs ((sum) - target) < delta) {
                            result = sum;
                            delta = Math.Abs ((sum) - target);
                        }
                    }
                }
            }

            return result;
        }
    }
}