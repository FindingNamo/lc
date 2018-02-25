using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace letter_combinations_of_a_phone_number {
    class Program {
        static void Main (string[] args) {
            Console.WriteLine ("Hello World!");
        }
    }

    public class Solution {

        private Dictionary<char, IList<string>> characterMap = new Dictionary<char, IList<string>> { { '2', new List<string> { "a", "b", "c" } },
            { '3', new List<string> { "d", "e", "f" } },
            { '4', new List<string> { "g", "h", "i" } },
            { '5', new List<string> { "j", "k", "l" } },
            { '6', new List<string> { "m", "n", "o" } },
            { '7', new List<string> { "p", "q", "r", "s" } },
            { '8', new List<string> { "t", "u", "v" } },
            { '9', new List<string> { "w", "x", "y", "z" } }
        };

        public IList<string> LetterCombinations (string digits) {
            return BruteForce (digits);
        }

        private IList<string> BruteForce (string digits) {
            var result = new List<string> ();

            foreach (char d in digits) {
                var newResult = new List<string> ();
                if (result.Count == 0) {
                    foreach (string s in characterMap[d]) {
                        newResult.Add ($"{s}");
                    }
                } else {
                    foreach (string r in result) {
                        foreach (string s in characterMap[d]) {
                            newResult.Add ($"{r}{s}");
                        }
                    }
                }
                result = newResult;
            }

            return result;
        }
    }
}