using System;

namespace minimum_window_subsequence {
    class Program {
        static void Main (string[] args) {
            Console.WriteLine ("Hello World!");
            new Solution().MinWindow("abcdebdde","bde");
        }
    }

    public class Solution {

        public string MinWindow (string S, string T) {
            return SmartBrute (S, T);
        }

        private string SmartBrute (string S, string T) {
            int start = 0;
            int end = 0;
            int ti = 0;
            bool found = false;
            for (int i = 0; i < S.Length; i++) {
                if (S[i] == T[ti]) {
                    if (ti == T.Length - 1) {
                        end = i;
                        found = true;
                        break;
                    }
                    ti++;
                }
            }

            if (!found)
                return string.Empty;

            string result = S.Substring (start, end - start + 1);

            for (int i = end; i < S.Length; i++) {
                if (S[i] == T[T.Length - 1]) {
                    ti = T.Length - 1;
                    for (int j = i; j >= 0; j--) {
                        if (S[j] == T[ti]) {
                            if (ti == 0) {
                                start = j;
                                if (i - start + 1 < result.Length)
                                    result = S.Substring (start, i - start + 1);
                                break;
                            }
                            ti--;
                        }
                    }
                }
            }

            return result;
        }
    }
}