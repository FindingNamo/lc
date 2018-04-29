using System;

namespace balanced_binary_tree {
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

        // if the node is null consider it balanced
        // if not null check that it is balanced by definition (the depth of its left child and right child differ by at most 1)
        // then make sure that both left and right child are balanced themselves
        public bool IsBalanced (TreeNode root) {
            if (root == null)
                return true;

            int l = Depth (root.left);
            int r = Depth (root.right);
            if (Math.Abs (l - r) > 1)
                return false;
            else
                return IsBalanced (root.left) && IsBalanced (root.right);
        }

        // this is a bit crummy because we end up recalculating depth quite a few times
        // the code is easy to read though
        // to optimize we would probably want to have some kind of back tracking mechanism or a way to store depth
        private int Depth (TreeNode n) {
            if (n == null)
                return 0;

            return Math.Max (Depth (n.left), Depth (n.right)) + 1;
        }
    }
}