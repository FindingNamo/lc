using System;

namespace longest_palindromic_substring {
    class Program {
        static void Main (string[] args) {
            Console.WriteLine (new Solution ().LongestPalindrome ("cbbd"));
        }
    }

    public class Solution {
        public string LongestPalindrome (string s) {
            var pa = new PalindromeAnalyzer ();
            return pa.LongestPalindromeFromLeast (s);
        }
    }

    public class PalindromeAnalyzer {

        public PalindromeAnalyzer () {

        }

        public string LongestPalindromeFromMost (string s) {
            int length = s.Length;
            int index = 0;
            string subString = s.Substring (index, length);
            while (!FromMost (subString)) {
                if (index + length == s.Length) {
                    index = 0;
                    length--;
                } else {
                    index++;
                }
                subString = s.Substring (index, length);
            }

            return s.Substring (index, length);
        }

        private bool FromMost (string s) {
            if (string.IsNullOrWhiteSpace (s))
                return false;

            if (s.Length == 1)
                return true;

            for (int i = 0; i <= s.Length / 2; i++) {
                if (s[i] != s[s.Length - 1 - i])
                    return false;
            }

            return true;
        }

        public string LongestPalindromeFromLeast (string s) {
            string result = string.Empty;
            int maxSize = 0;
            for (int i = 0; i < s.Length; i++) {
                int padding = 0;
                var size = 1;
                while (!TooBig (i, padding + 1, s) && StillPalindrome (i, padding + 1, s)) {
                    padding++;
                    size = 1 + padding * 2;
                }

                if (size > maxSize) {
                    maxSize = size;
                    result = s.Substring (i - padding, size);
                }
            }

            for (int i = 0; i < s.Length - 1; i++) {
                if (s[i] == s[i + 1]) {
                    int padding = 0;
                    var size = 2;
                    while (!TooBig (i, i + 1, padding + 1, s) && StillPalindrome (i, i + 1, padding + 1, s)) {
                        padding++;
                        size = 2 + padding * 2;

                    }
                    
                    if (size > maxSize) {
                        maxSize = size;
                        result = s.Substring (i - padding, size);
                    }
                }
            }

            return result;
        }

        private bool TooBig (int index, int padding, string s) {
            return (index - padding < 0 || index + padding >= s.Length);
        }

        private bool StillPalindrome (int index, int padding, string s) {
            return s[index - padding] == s[index + padding];
        }

        private bool TooBig (int start, int end, int padding, string s) {
            return (start - padding < 0 || end + padding >= s.Length);
        }

        private bool StillPalindrome (int start, int end, int padding, string s) {
            return s[start - padding] == s[end + padding];
        }
    }
}