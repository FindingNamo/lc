using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _3sum {
    class Program {
        static void Main (string[] args) {
            Console.WriteLine (new Solution ().ThreeSum (new [] {-1,0,1,2,-1,-4}));
        }
    }

    public class Solution {
        public IList<IList<int>> ThreeSum (int[] nums) {
            return PreSortedWithoutHashMaps (nums);
        }

        private IList<IList<int>> PreSortedWithoutHashMaps (int[] nums) {
            Array.Sort (nums);

            var result = new List<IList<int>> ();
            for (int i = 0; i < nums.Length - 2; i++) {                 // Go through every number
                if (i == 0 || ( i > 0 && nums[i] != nums[i - 1])) {     // Skip seed number since they will return same set of result
                    int left = i + 1;
                    int right = nums.Length - 1;
                    int target = nums[i] * -1;
                    while (left < right) {                              // Search bi directionally for complement
                        if (nums[left] + nums[right] == target) {
                            result.Add (new List<int> () { nums[i], nums[left], nums[right] });
                            left++;
                            right--;
                            while(nums[left] == nums[left-1] && left < right){ // Skip all similar left numbers since we already found that solution and it would repeat
                                left++;
                            }
                            while(nums[right] == nums[right+1] && left < right){ // Skip all similar right number since we already found that solution and it would repeat
                                right--;
                            }
                        } else if (nums[left] + nums[right] < target) {
                            left++;
                        } else {
                            right--;
                        }
                    }
                }

            }

            return result;

        }

        private IList<IList<int>> PreSorted (int[] nums) {
            Array.Sort (nums);

            var result = new List<IList<int>> ();
            var resultHashSet = new List<Dictionary<int, int>> ();
            for (int i = 0; i < nums.Length - 2; i++) {
                int left = i + 1;
                int right = nums.Length - 1;
                int target = nums[i] * -1;
                while (left < right) {
                    if (nums[left] + nums[right] == target && !InSet (nums[i], nums[left], nums[right], resultHashSet)) {
                        result.Add (new List<int> () { nums[i], nums[left], nums[right] });
                        resultHashSet.Add (ToDictionary (nums[i], nums[left], nums[right]));
                        left++;
                        right--;
                    } else if (nums[left] + nums[right] < target) {
                        left++;
                    } else {
                        right--;
                    }
                }
            }

            return result;

        }

        private IList<IList<int>> BruteForce (int[] nums) {

            var result = new List<IList<int>> ();
            var resultHashSet = new List<Dictionary<int, int>> ();

            for (int i = 0; i < nums.Length - 2; i++) {
                for (int j = i + 1; j < nums.Length - 1; j++) {
                    for (int k = j + 1; k < nums.Length; k++) {

                        if (nums[i] + nums[j] + nums[k] == 0 && !InSet (nums[i], nums[j], nums[k], resultHashSet)) {
                            result.Add (new List<int> () { nums[i], nums[j], nums[k] });
                            resultHashSet.Add (ToDictionary (i, j, k));
                        }
                    }
                }
            }

            return result;
        }

        private bool InSet (int i, int j, int k, IList<Dictionary<int, int>> resultHashSet) {

            var hashMap = ToDictionary (i, j, k);

            return resultHashSet.Any ((d) => {
                foreach (int key in hashMap.Keys) {
                    if (!d.ContainsKey (key) || d[key] != hashMap[key])
                        return false;
                }
                return true;
            });
        }

        private Dictionary<int, int> ToDictionary (int i, int j, int k) {
            var hashMap = new Dictionary<int, int> ();
            hashMap.Add (i, 1);

            if (hashMap.ContainsKey (j)) {
                hashMap[j]++;
            } else {
                hashMap.Add (j, 1);
            }

            if (hashMap.ContainsKey (k)) {
                hashMap[k]++;
            } else {
                hashMap.Add (k, 1);
            }

            return hashMap;
        }
    }
}