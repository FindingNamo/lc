using System;

namespace binary_tree_paths {
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
        public IList<string> BinaryTreePaths (TreeNode root) {

            if (root == null)
                return new List<string> ();

            IList<string> r = new List<string> ();
            IList<TreeNode> l = new List<TreeNode> ();
            DFS (root, l, r);

            return r;

        }

        /*
        
        Start from root
        Add to path list (to remember where we are)
        If no childs, add path list to results
        If child, recurse into that child
        When done looking at children, remove selves from path list and return back up stack

         */
        private void DFS (TreeNode n, IList<TreeNode> l, IList<string> r) {

            l.Add (n);

            if (n.left == null && n.right == null) {
                r.Add (Print (l));
            } else {
                if (n.left != null)
                    DFS (n.left, l, r);

                if (n.right != null)
                    DFS (n.right, l, r);
            }

            l.RemoveAt (l.Count - 1);
        }

        /*

        Crummy because we rewalk the path list each time
        If we wanted to improve we could also remember and backtrack based on previous
        string added

         */
        private string Print (IList<TreeNode> l) {
            StringBuilder sb = new StringBuilder ();
            sb.Append (l[0].val);
            for (int i = 1; i < l.Count; i++) {
                sb.Append ($"->{l[i].val}");
            }
            return sb.ToString ();
        }
    }
}