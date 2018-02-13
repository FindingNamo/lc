using System;

namespace palindrome_number
{
    class Program {
        static void Main (string[] args) {
            Console.WriteLine (new Solution().IsPalindrome(-2147483648));
        }
    }

    public class Solution {
        public bool IsPalindrome (int x) {
            if (x < 0)
                return false;

            var m = GetMagnitude (x);

            for (int i = 0; i <= m/2; i++) {
                var leftMost = (x / (int)Math.Pow(10,m-i)) % 10;
                var rightMost = (x / (int)Math.Pow(10,i)) % 10;

                if (leftMost != rightMost)
                    return false;
            }

            return true;
        }

        private int GetMagnitude (int x) {
            var result = Math.Log ((double)x, 10d);
            return (int)result;
        }
    }
}