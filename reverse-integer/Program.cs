using System;

namespace reverse_integer {
    class Program {
        static void Main (string[] args) {
            Console.WriteLine ($"{new Solution().Reverse(1534236469)}");
        }
    }

    public class Solution {
        public int Reverse (int x) {
            int result = 0;
            try {
                do {
                    // increment by least significant digit
                    result = checked (result + (x % 10));

                    // get ready to get next least significant digit
                    x = x / 10;

                    // if we're not done, prep result for next round of addition
                    if (x != 0)
                        result = checked (result * 10);
                } while (x != 0);
            } catch (OverflowException e) {
                return 0;
            }

            return result;
        }
    }
}