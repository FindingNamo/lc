using System;

namespace implement_trie_prefix_tree {
    class Program {
        static void Main (string[] args) {
            Console.WriteLine ("Hello World!");
        }
    }

    public class Trie {

        private Node root = null;

        /** Initialize your data structure here. */
        public Trie () {
            root = new Node ();
        }

        /** Inserts a word into the trie. */
        public void Insert (string word) {
            if (word == null)
                return;

            var cur = root;
            for (int i = 0; i < word.Length; i++) {
                cur = cur.GetOrAdd (word[i]);
            }
            cur.HasEnd = true;
        }

        /** Returns if the word is in the trie. */
        public bool Search (string word) {
            if (word == null)
                return false;

            var cur = root;
            for (int i = 0; i < word.Length; i++) {
                if (cur.Map.ContainsKey (word[i]))
                    cur = cur.Map[word[i]];
                else
                    return false;

            }
            return cur.HasEnd;
        }

        /** Returns if there is any word in the trie that starts with the given prefix. */
        public bool StartsWith (string prefix) {
            if (prefix == null)
                return false;

            var cur = root;
            for (int i = 0; i < prefix.Length; i++) {
                if (cur.Map.ContainsKey (prefix[i]))
                    cur = cur.Map[prefix[i]];
                else
                    return false;

            }
            return true;
        }
    }

    public class Node {

        // pseudo-edges
        public Dictionary<char, Node> Map { get; }

        // End of a word
        public bool HasEnd { get; set; } = false;

        public Node () {
            Map = new Dictionary<char, Node> ();
        }

        public Node GetOrAdd (char c) {
            if (!Map.ContainsKey (c)) {
                var n = new Node ();
                Map.Add (c, n);
                return n;
            }

            return Map[c];
        }
    }
}