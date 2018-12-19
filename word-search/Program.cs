using System;

namespace word_search {
    class Program {
        static void Main (string[] args) {
            Console.WriteLine ("Hello World!");
            char[,] data =  new char[,] {{'A','B','C','E'},{'S','F','C','S'},{'A','D','E','E'}};
            new Solution().Exist(data, "ABCCED");
        }
    }

    public class Solution {
        // keep [,] of bool to mark visited
        // make helpers to not go past board
        // for each character on board evaluate for correctness
        // for each correct character keep and increment index of letter being evaluated
        // also mark that letter as visited
        // break condition and return false if all visited and still letters remain
        // break condition and true if last character and match
        // use DFS and backtracking on the visited to track success
        public bool Exist (char[, ] board, string word) {
            var v = new bool[board.GetLength (0), board.GetLength (1)];
            for (int row = 0; row < board.GetLength (0); row++) {
                for (int col = 0; col < board.GetLength (1); col++) {
                    if (board[row, col] == word[0]) {

                        v[row, col] = true;
                        if (DFS (board, v, word, row, col, 0))
                            return true;
                        v[row, col] = false;
                    }
                }
            }

            return false;

        }

        private bool DFS (char[, ] board, bool[, ] v, string word, int row, int col, int i) {
            if (board[row, col] != word[i])
                return false;

            if (i == word.Length - 1)
                return true;

            if (CanGoUp (board, v, row, col)) {
                v[row-1, col] = true;
                if (DFS (board, v, word, row-1, col, i + 1))
                    return true;
                v[row-1, col] = false;
            }

            if (CanGoDown (board, v, row, col)) {
                v[row+1, col] = true;
                if (DFS (board, v, word, row+1, col, i + 1))
                    return true;
                v[row+1, col] = false;
            }

            if (CanGoLeft (board, v, row, col)) {
                v[row, col-1] = true;
                if (DFS (board, v, word, row, col-1, i + 1))
                    return true;
                v[row, col-1] = false;
            }

            if (CanGoRight (board, v, row, col)) {
                v[row, col+1] = true;
                if (DFS (board, v, word, row, col+1, i + 1))
                    return true;
                v[row, col+1] = false;
            }

            return false;
        }

        private bool CanGoUp (char[, ] board, bool[, ] v, int row, int col) {
            return row > 0 && !v[row-1, col];
        }

        private bool CanGoDown (char[, ] board, bool[, ] v, int row, int col) {
            return row + 1 < board.GetLength (0) && !v[row+1, col];
        }

        private bool CanGoLeft (char[, ] board, bool[, ] v, int row, int col) {
            return col > 0 && !v[row, col-1];
        }

        private bool CanGoRight (char[, ] board, bool[, ] v, int row, int col) {
            return col + 1 < board.GetLength (1) && !v[row, col+1];
        }
    }
}