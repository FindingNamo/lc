using System;
using System.Collections.Generic;
using System.Text;

namespace zigzag_conversion {
    class Program {
        static void Main (string[] args) {
            Console.WriteLine ("Hello World!");
            var s = new Solution ().Convert ("PAYPALISHIRING", 3);
            Console.WriteLine ($"{s}");
        }
    }

    public class Solution {
        public string Convert (string s, int numRows) {
            if (string.IsNullOrWhiteSpace (s) || numRows == 0)
                return string.Empty;
            
            if (numRows == 1)
                return s;

            var zigZagConvert = new ZigZagConverter (s);
            return zigZagConvert.Convert (numRows);
        }
    }

    public class ZigZagConverter {

        readonly string s;

        public ZigZagConverter (string s) {
            this.s = s;
        }

        public string Convert (int numRows) {
            var rows = Fill (numRows);
            StringBuilder sb = new StringBuilder ();
            for (int i = 0; i < numRows; i++) {
                if (rows[i] != null) {
                    foreach (char c in rows[i]) {
                        sb.Append (c);
                    }
                }

            }

            return sb.ToString ();
        }

        public IList<char>[] Fill (int numRows) {
            // make array of numRows if IList<char>
            // keep track of current row
            // for each character, increment row and add to corresponding list
            // when max row reached, decrement rows while adding to corresponding list
            // do that until end of string
            // then read in order of array
            int currentRow = 1;
            bool goingDown = true;
            IList<char>[] rows = new IList<char>[numRows];
            foreach (char c in s) {
                AppendCharacter (ref rows[currentRow - 1], c);
                if (goingDown) {
                    if (currentRow + 1 > numRows) {
                        goingDown = !goingDown;
                        currentRow--;
                    } else {
                        currentRow++;
                    }
                } else {
                    if (currentRow - 1 < 1) {
                        goingDown = !goingDown;
                        currentRow++;
                    } else {
                        currentRow--;
                    }
                }
            }

            return rows;
        }

        private void AppendCharacter (ref IList<char> s, char c) {
            if (s == null) {
                s = new List<char> ();
                s.Add (c);
            } else
                s.Add (c);
        }

    }
}