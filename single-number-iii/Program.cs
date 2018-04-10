using System;

namespace single_number_iii {
    class Program {
        static void Main (string[] args) {
            Console.WriteLine ("Hello World!");
        }
    }

    public class Solution {
        public int[] SingleNumber (int[] nums) {
            HashSet<int> r = new HashSet<int> ();
            for (int i = 0; i < nums.Length; i++) {
                if (!r.Contains (nums[i]))
                    r.Add (nums[i]);
                else
                    r.Remove (nums[i]);
            }

            int[] ret = new int[r.Count];
            r.CopyTo (ret);

            return ret;
        }
    }
}