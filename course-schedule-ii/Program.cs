using System;
using System.Collections.Generic;

namespace course_schedule_ii {
    class Program {
        static void Main (string[] args) {
            int[, ] p = new int[2, 2];
            p[0, 0] = 0;
            p[0, 1] = 1; // (0,1)
            p[1, 0] = 1;
            p[1, 1] = 0; // (1,0)
            Console.WriteLine (new Solution ().FindOrder (3, p));
        }
    }

    public class Solution {
        public int[] FindOrder (int numCourses, int[, ] prerequisites) {
            List<int>[] g = BuildGraph (numCourses, prerequisites);
            Stack<int> s = new Stack<int> ();
            HashSet<int> v = new HashSet<int> ();

            try {
                for (int i = 0; i < g.Length; i++) {
                    HashSet<int> c = new HashSet<int> ();
                    if (!v.Contains (i))
                        DFS (g, s, v, c, i);
                }
            }
            catch (CycleException){
                return new int[0];
            }

            int[] r = new int[numCourses];
            for (int i = 0; i < numCourses; i++) {
                r[i] = s.Pop ();
            }

            return r;
        }

        private List<int>[] BuildGraph (int numCourses, int[, ] prerequisites) {
            List<int>[] r = new List<int>[numCourses];
            for (int i = 0; i < numCourses; i++) {
                r[i] = new List<int> ();
            }

            int pairs = prerequisites.GetLength (0);
            for (int i = 0; i < pairs; i++) {
                r[prerequisites[i, 1]].Add (prerequisites[i, 0]);
            }

            return r;
        }

        private void DFS (List<int>[] g, Stack<int> s, HashSet<int> v, HashSet<int> cycle, int c) {

            if (cycle.Contains (c))
                throw new CycleException ();
            else
                cycle.Add(c);

            foreach (int i in g[c]) {
                if (!v.Contains (i))
                    DFS (g, s, v, cycle, i);
            }

            v.Add (c);
            s.Push (c);
        }
    }

    class CycleException : Exception {

    }
}