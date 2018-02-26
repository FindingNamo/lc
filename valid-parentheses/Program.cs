using System;
using System.Collections.Generic;

namespace valid_parentheses {
    class Program {
        static void Main (string[] args) {
            Console.WriteLine ("Hello World!");
        }
    }
    public class Solution {

        private Dictionary<char, char> parenthesesPairs = new Dictionary<char, char> { { '(', ')' },
            { '{', '}' },
            { '[', ']' }
        };

        public bool IsValid (string s) {
            return UsingStack (s);
        }

        private bool UsingStack (string s) {
            Stack<char> openParentheses = new Stack<char> ();
            foreach (char c in s) {
                if (parenthesesPairs.ContainsKey (c)) {
                    openParentheses.Push (c);
                } else {
                    if (openParentheses.Count == 0)
                        return false;
                    char lastOpened = openParentheses.Pop ();
                    if (c != parenthesesPairs[lastOpened])
                        return false;
                }
            }

            if (openParentheses.Count != 0)
                return false;

            return true;
        }
    }
}