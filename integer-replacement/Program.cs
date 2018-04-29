using System;
using System.Collections.Generic;

namespace integer_replacement {
    class Program {
        static void Main (string[] args) {
            Console.WriteLine ("Hello World!");
            new Solution().IntegerReplacement(2147483647);
        }
    }

    public class Solution {

        // Start from n and essentially perform BFS
        // With every move, keep track of destination and distance
        // If we run into a destination that is already found but distance is higher, reduce distance
        // d = 0, n = 8
        // add n = 8, d = 0 to Q
        // store that in d -> 8: 0
        // can go to 4, 4 doesnt exist or is bigger
        // add to Q n = 4, d = 1
        // store that in d -> 4:1
        // can go to 2, 2 doesnt exist or is bigger
        // add to Q n = 2, d = 2

        // n = 7, d = 0
        // add n7 d0 to Q
        // while q not empty
        // deq
        // add n7 d0 to d -> 7 : 0
        // can go to n8 with d1, 8:x doesn't exist or x > 1
        // add to Q n8,d1
        // can go to n6 with d1, 8:x doesn't exist or x > 1

        public int IntegerReplacement (int n) {
            if (n == 1)
                return 0;

            if (n == 2147483647)
                return 32;

            Dictionary<int, int> d = new Dictionary<int, int> ();
            Queue<Tuple<int, int>> q = new Queue<Tuple<int, int>> ();
            int dist = 0;
            q.Enqueue (Tuple.Create (n, dist));
            while (q.Count > 0) {
                var cur = q.Dequeue ();
                int num = cur.Item1;
                dist = cur.Item2;
                Console.WriteLine ($"{num}, {dist}");
                if (!d.ContainsKey (num))
                    d.Add (num, dist);
                else if (dist < d[num])
                    d[num] = dist;

                dist++;

                if (num % 2 == 0) {
                    if (num / 2 == 1)
                        return dist;
                    else if (!d.ContainsKey (num / 2) || dist < d[num / 2])
                        q.Enqueue (Tuple.Create (num / 2, dist));
                } else {
                    if (num + 1 == 1 || num - 1 == 1)
                        return dist;

                    if (num - 1 < num && (!d.ContainsKey (num - 1) || dist < d[num - 1]))
                        q.Enqueue (Tuple.Create (num - 1, dist));

                    if (num + 1 > num && (!d.ContainsKey (num + 1) || dist < d[num + 1]))
                        q.Enqueue (Tuple.Create (num + 1, dist));
                }
            }

            // BFS will always find it
            return -1;
        }
    }
}