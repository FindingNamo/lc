using System;

namespace search_a_2d_matrix {
    class Program {
        static void Main (string[] args) {
            Console.WriteLine ("Hello World!");
            new Solution ().SearchMatrix (new int[2, 1] { {1} , {3} }, 2);
        }
    }

    public class Solution {
        public bool SearchMatrix (int[, ] matrix, int target) {

            if (matrix.GetLength (0) == 0 || matrix.GetLength (1) == 0)
                return false;

            int row = Row (0, matrix.GetLength (0) - 1, target, matrix);

            if (row == -1)
                return false;

            int col = Col (0, matrix.GetLength (1) - 1, target, matrix, row);

            return col != -1;
        }

        private int Col (int mn, int mx, int t, int[, ] a, int r) {
            if (mn == mx)
                return a[r, mn] == t ? mn : -1;

            int md = (mx - mn) / 2;

            if (a[r, md] > t) {
                if (md - 1 < 0)
                    return -1;

                return Col (mn, md - 1, t, a, r);
            } else if (a[r, md] < t) {
                if(md+1 > a.GetLength(1) - 1)
                    return -1;

                return Col (md + 1, mx, t, a, r);
            } else {
                return md;
            }

        }

        private int Row (int minr, int maxr, int target, int[, ] m) {
            if (minr == maxr)
                return minr;

            int midr = (maxr - minr) / 2;

            if (m[midr, 0] > target) {
                if (midr - 1 < 0)
                    return -1;
                
                return Row (minr, midr - 1, target, m);
            } else if (m[midr, 0] < target) {
                return Row (midr, maxr, target, m);
            } else {
                return midr;
            }
        }
    }
}