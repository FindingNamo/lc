using System;
using System.Collections.Generic;

namespace binary_tree_preorder_traversal {
    class Program {
        static void Main (string[] args) {
            Console.WriteLine ("Hello World!");
        }
    }

    public class TreeNode {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode (int x) { val = x; }
    }

    public class Solution {
        public IList<int> PreorderTraversal (TreeNode root) {
            IList<int> l = new List<int> ();
            DFS (root, l);

            return l;
        }

        private void DFS (TreeNode n, IList<int> l) {
            if (n == null)
                return;

            l.Add (n.val);
            DFS (n.left, l);
            DFS (n.right, l);
        }

        private void Iterative (TreeNode n, IList<int> l) {
            if (n == null)
                return;

            Stack<TreeNode> s = new Stack<TreeNode> ();
            s.Push (n);

            while (s.Count > 0) {
                var cn = s.Pop ();
                l.Add (cn.val);

                if (cn.right != null)
                    s.Push (cn.right);

                if (cn.left != null)
                    s.Push (cn.left);
            }
        }
    }
}