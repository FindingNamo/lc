using System;
using System.Collections.Generic;
using System.Linq;

namespace minimum_window_substring {
    class Program {
        static void Main (string[] args) {
            Console.WriteLine ("Hello World!");
            new Solution().MinWindow("ADOBECODEBANC","ABC");
        }
    }

    public class Solution {
        public string MinWindow (string s, string t) {
            var req = BuildReq (t);
            int start = 0;
            int end = 0;
            for (int i = 0; i < s.Length; i++) {
                if (req.ContainsKey (s[i]))
                    req[s[i]]--;

                if (MeetsReq (req)) {
                    end = i;
                    break;
                }
            }

            if (!MeetsReq (req))
                return string.Empty;

            while (CanRemove (s[start], req)) {
                if (req.ContainsKey (s[start]))
                    req[s[start]]++;
                start++;
            }

            string result = s.Substring (start, end - start + 1);

            for (int i = end + 1; i < s.Length; i++) {
                if (req.ContainsKey (s[i]))
                    req[s[i]]--;

                while (CanRemove (s[start], req)) {
                    if (req.ContainsKey (s[start]))
                        req[s[start]]++;
                    start++;
                }

                if (i - start + 1 < result.Length)
                    result = s.Substring (start, i - start + 1);
            }

            return result;
        }

        private bool CanRemove (char c, Dictionary<char, int> req) {
            return !req.ContainsKey (c) || req[c] < 0;
        }

        private bool MeetsReq (Dictionary<char, int> req) {
            return req.Keys.All (k => req[k] <= 0);
        }

        private Dictionary<char, int> BuildReq (string t) {
            var d = new Dictionary<char, int> ();
            foreach (char c in t) {
                if (!d.ContainsKey (c))
                    d.Add (c, 1);
                else
                    d[c]++;
            }
            return d;
        }
    }
}