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
                var leftMag = (int)Math.Pow(10,m-i);
                var leftMost = (x / leftMag) % 10;
                var rightMag = (int)Math.Pow(10,i);
                var rightMost = (x / rightMag) % 10;

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