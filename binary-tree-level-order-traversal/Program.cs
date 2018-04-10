using System;
using System.Collections.Generic;

namespace lc {
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
        public IList<IList<int>> LevelOrder (TreeNode root) {

            IList<IList<int>> l = new List<IList<int>> ();

            BFS (root, l);

            return l;
        }

        private void BFS (TreeNode n, IList<IList<int>> l) {
            if (n == null)
                return;

            Queue<Tuple<TreeNode, int>> q = new Queue<Tuple<TreeNode, int>> ();
            q.Enqueue (Tuple.Create (n, 0));

            while (q.Count > 0) {
                var ct = q.Dequeue ();
                var left = ct.Item1.left;
                var right = ct.Item1.right;
                CreateOrInsert (l, ct.Item2, ct.Item1.val);

                if (left != null)
                    q.Enqueue (Tuple.Create (left, ct.Item2 + 1));

                if (right != null)
                    q.Enqueue (Tuple.Create (right, ct.Item2 + 1));
            }
        }

        private void CreateOrInsert (IList<IList<int>> l, int level, int val) {
            while (l.Count < (level + 1)) {
                l.Add (new List<int> ());
            }
            l[level].Add (val);
        }
    }
}