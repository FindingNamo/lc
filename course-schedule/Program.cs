using System;
using System.Collections.Generic;

namespace course_schedule {
    class Program {
        static void Main (string[] args) {
            int[, ] p = new int[3, 2];
            p[0, 0] = 0;
            p[0, 1] = 1; // (0,1)
            p[1, 0] = 0;
            p[1, 1] = 2; // (0,2)
            p[2, 0] = 2;
            p[2, 1] = 1; // (2,1)

            Console.WriteLine (new Solution ().CanFinish (3, p));
        }
    }

    public class Solution {
        public bool CanFinish (int numCourses, int[, ] prerequisites) {
            List<int>[] g = new List<int>[numCourses];
            int numEdges = prerequisites.GetLength (0);
            for (int i = 0; i < numEdges; i++) {
                if (g[prerequisites[i, 0]] == null) {
                    g[prerequisites[i, 0]] = new List<int> { prerequisites[i, 1] };
                } else {
                    g[prerequisites[i, 0]].Add (prerequisites[i, 1]);
                }
            }

            HashSet<int> v = new HashSet<int> ();
            for (int i = 0; i < numCourses; i++) {
                if (!DFS (g, v, i))
                    return false;
            }

            return true;

        }

        private bool DFS (List<int>[] g, HashSet<int> v, int c) {
            if (v.Contains (c))
                return false;
            else
                v.Add (c);

            if (g[c] != null) {
                foreach (int e in g[c]) {
                    if (!DFS (g, v, e))
                        return false;
                }
            }

            v.Remove (c);

            return true;
        }
    }
}