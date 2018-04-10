using System;
using System.Collections.Generic;

namespace same_tree {
    class Program {
        static void Main (string[] args) {
            Console.WriteLine ("Hello World!");
        }
    }

    /**
     * Definition for a binary tree node.
     * public class TreeNode {
     *     public int val;
     *     public TreeNode left;
     *     public TreeNode right;
     *     public TreeNode(int x) { val = x; }
     * }
     */
    public class Solution {
        public bool IsSameTree (TreeNode p, TreeNode q) {

            var pt = Traverse (p);
            var qt = Traverse (q);

            if (qt.Length != qt.Length)
                return false;
            else {
                for (int i = 0; i < qt.Length; i++) {
                    if (pt[i] != qt[i])
                        return false;
                }
            }

            return true;

        }

        private int?[] Traverse (TreeNode n) {
            List<int?> r = new List < ();

            DFS (n, r);

            return r.ToArray ();
        }

        private void DFS (TreeNode n, List<int?> r) {
            if (n = null) {
                r.Add (null);
                return;
            }

            r.Add (n.val);
            DFS (n.left, r);
            DFS (n.right, r);
        }
    }
}