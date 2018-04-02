using System;
using System.Collections.Generic;
using System.Text;

namespace generate_parentheses {
    class Program {
        static void Main (string[] args) {
            Console.WriteLine (new Solution ().GenerateParenthesis (3));
        }
    }

    public class Solution {

        Dictionary<int, IList<string>> memoizedResults = new Dictionary<int, IList<string>> ();

        public IList<string> GenerateParenthesis (int n) {
            return UsingStringBuilder (n);
        }

        private IList<string> UsingStringBuilder (int n) {
            IList<string> combinations = new List<string> ();
            AppendRecursion (ref combinations, "", 0, n, n*2);

            return combinations;
        }

        private void AppendRecursion(ref IList<string> results, string currentCandidate, int balance, int openLeft, int maxSize){
            if(currentCandidate.Length == maxSize){
                results.Add(currentCandidate.ToString());
            }
            else{
                if(balance > 0 && openLeft > 0){
                    AppendRecursion(ref results, $"{currentCandidate}(", balance + 1, openLeft - 1, maxSize);
                    AppendRecursion(ref results, $"{currentCandidate})", balance - 1, openLeft, maxSize);
                }
                
                if (balance == 0 && openLeft > 0){
                    AppendRecursion(ref results, $"{currentCandidate}(", balance + 1, openLeft - 1, maxSize);
                }

                if (balance > 0 && openLeft == 0) {
                    AppendRecursion(ref results, $"{currentCandidate})", balance - 1, openLeft, maxSize);
                }
            }
        }



        private IList<string> UsingCharArray (int n) {
            var combinations = new List<String> ();
            generateAll (new char[2 * n], 0, combinations);

            return combinations;
        }

        public void generateAll (char[] current, int pos, List<String> result) {
            if (pos == current.Length) {
                if (valid (current))
                    result.Add (new string (current));
            } else {
                current[pos] = '(';
                generateAll (current, pos + 1, result);
                current[pos] = ')';
                generateAll (current, pos + 1, result);
            }
        }
        public bool valid (char[] current) {
            int balance = 0;
            foreach (char c in current) {
                if (c == '(') balance++;
                else balance--;
                if (balance < 0) return false;
            }
            return (balance == 0);
        }

        private IList<string> BruteForce (int n) {
            IList<string> result = new List<string> ();
            string baseString = "";
            for (int i = 0; i < n * 2; i++) {
                baseString = baseString + ")";
            }

            for (int i = 1; i <= n * 2; i++) {
                for (int j = 0; j < n * 2 + 1 - i; j++) {
                    StringBuilder sb = new StringBuilder (baseString);
                    for (int k = 0; k < i; k++) {
                        sb[j + k] = '(';
                    }
                    string candidate = sb.ToString ();
                    if (UsingStack (candidate))
                        result.Add (candidate);
                }
            }

            return result;
        }

        private IList<string> BruteForceDynProg (int n) {
            if (n == 1) {
                if (!memoizedResults.ContainsKey (1))
                    memoizedResults.Add (1, new List<string> { "()" });

                // base case
                return new List<string> { "()" };
            } else {
                if (memoizedResults.ContainsKey (n)) {
                    return memoizedResults[n];
                } else {
                    if (!memoizedResults.ContainsKey (n - 1)) {
                        // recursively build memo
                        memoizedResults[n - 1] = BruteForceDynProg (n - 1);
                    }

                    // valid new cases are parentheses wrapped around, before and after
                    var results = new List<string> ();
                    foreach (string s in memoizedResults[n - 1]) {
                        for (int i = 0; i < s.Length; i++) {
                            string opened = s.Insert (i, "(");
                            for (int j = i + 1; j < opened.Length; j++) {
                                string closed = opened.Insert (j, ")");
                                if (!results.Contains (closed))
                                    results.Add (closed);
                            }
                            string lastclosed = $"{opened})";
                            if (!results.Contains (lastclosed))
                                results.Add (lastclosed);
                        }
                    }

                    memoizedResults[n] = results;
                    return results;
                }
            }
        }

        private bool UsingStack (string s) {
            Stack<char> openParentheses = new Stack<char> ();
            foreach (char c in s) {
                if (c == '(') {
                    openParentheses.Push (c);
                } else {
                    if (openParentheses.Count == 0)
                        return false;
                    openParentheses.Pop ();
                }
            }

            if (openParentheses.Count != 0)
                return false;

            return true;
        }
    }
}