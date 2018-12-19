using System;
using System.Collections.Generic;
using System.Text;

namespace remove_invalid_parentheses {
    class Program {
        static void Main (string[] args) {
            Console.WriteLine ("Hello World!");
            new Solution().RemoveInvalidParentheses("()())()");
        }
    }

    public class Solution {

        public IList<string> RemoveInvalidParentheses (string s) {
            List<string> ans = new List<string>();
            remove (s, ans, 0, 0, new char[] { '(', ')' });
            return ans;
        }

        public void remove (string s, List<string> ans, int last_i, int last_j, char[] par) {
            int stack = 0;
            for (int i = last_i; i < s.Length; i++) {
                if (s[i] == par[0]) 
                    stack++;
                if (s[i] == par[1]) 
                    stack--;
                if (stack >= 0) 
                    continue;
                for (int j = last_j; j <= i; j++)
                    if (s[j] == par[1] && (j == last_j || s[j-1] != par[1]))
                        remove (s.Remove(j,1), ans, i, j, par);
                return;
            }
            string reversed = Reverse(s);
            if (par[0] == '(') // finished left to right
                remove (reversed, ans, 0, 0, new char[] { ')', '(' });
            else // finished right to left
                ans.Add (reversed);
        }

        private string Reverse( string s )
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse( charArray );
            return new string( charArray );
        }
    }
}