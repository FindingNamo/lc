using System;
using System.Collections.Generic;

namespace frog_jump {
    class Program {
        static void Main (string[] args) {
            Console.WriteLine ("Hello World!");
            new Solution ().CanCross (new int[] { 0, 1, 3, 4, 5, 7, 9, 10, 12 });
        }
    }

    public class Solution {
        public bool CanCross (int[] stones) {
            Dictionary<int, HashSet<int>> d = new Dictionary<int, HashSet<int>>();
            HashSet<int> h = new HashSet<int> ();
            for (int i = 0; i < stones.Length; i++) {
                h.Add (stones[i]);
            }

            int max = stones[stones.Length - 1];
            
            if(stones[0] + 1 != stones[1])
                return false;

            return Jump (1, stones[1], h, max, d);
        }

        public bool Jump (int dist, int pos, HashSet<int> h, int max, Dictionary<int, HashSet<int>> d) {
            if(d.ContainsKey(pos) && d[pos].Contains(dist))
                return false;
            else if (!d.ContainsKey(pos))
                d.Add(pos, new HashSet<int> {dist});
            else
                d[pos].Add(dist);
            
            int jd1 = dist + 1;
            int jd2 = dist;
            int jd3 = dist - 1;
            int nx1 = pos + jd1;
            int nx2 = pos + jd2;
            int nx3 = pos + jd3;

            if (nx1 == max || nx2 == max || nx3 == max)
                return true;

            bool jp1 = false;
            bool jp2 = false;
            bool jp3 = false;

            if (nx1 > pos && h.Contains (nx1))
                jp1 = Jump (jd1, nx1, h, max, d);
            
            if(jp1)
                return true;

            if (nx2 > pos && h.Contains (nx2))
                jp2 = Jump (jd2, nx2, h, max, d);
            
            if(jp2)
                return true;

            if (nx3 > pos && h.Contains (nx3))
                jp3 = Jump (jd3, nx3, h, max, d);
            
            if(jp3)
                return true;

            return false;
        }
    }
}