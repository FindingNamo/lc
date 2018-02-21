using System;
using System.Text;

namespace longest_common_prefix {
    class Program {
        static void Main (string[] args) {
            Console.WriteLine (new Solution().LongestCommonPrefix(new [] {"aba", "ab", "abder"}));
        }
    }

    public class Solution {
        public string LongestCommonPrefix (string[] strs) {
            if (strs.Length == 0)
                return string.Empty;

            if (strs.Length == 1)
                return strs[0];

            return BruteForce(strs);
        }

        private string BruteForce(string[] strs){

            StringBuilder sb = new StringBuilder();

            for(int i = 0; i < strs[0].Length; i++){
                char curChar = strs[0][i];
                for(int j = 1; j < strs.Length; j++){
                    if(strs[j].Length <= i  || strs[j][i] != curChar)
                        return sb.ToString();
                }
                sb.Append(curChar);
            }

            return sb.ToString();
        }
    }
}