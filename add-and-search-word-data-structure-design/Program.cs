using System;
using System.Collections.Generic;
using System.Linq;

namespace add_and_search_word_data_structure_design {
    class Program {
        static void Main (string[] args) {
            Console.WriteLine ("Hello World!");
            var d = new WordDictionary();
            d.AddWord("bad");
            d.AddWord("dad");
            d.AddWord("mad");
            d.Search("pad");
            d.Search("bad");
            d.Search(".ad");
            d.Search("p..");
        }
    }

    public class WordDictionary {

        private Node root = null;

        /** Initialize your data structure here. */
        public WordDictionary () {
            root = new Node ();
        }

        /** Adds a word into the data structure. */
        public void AddWord (string word) {
            if (word == null)
                return;

            var cur = root;
            for (int i = 0; i < word.Length; i++) {
                cur = cur.GetOrAdd (word[i]);
            }
            cur.HasEnd = true;
        }

        /** Returns if the word is in the data structure. A word could contain the dot character '.' to represent any one letter. */
        public bool Search (string word) {
            if (word == null)
                return false;

            return Search (word, 0, root);
        }

        private bool Search (string word, int i, Node n) {
            if (i == word.Length - 1) {
                return (word[i] == '.' && n.Map.Values.Any(v => v.HasEnd)) || (n.Map.ContainsKey(word[i]) && n.Map[word[i]].HasEnd);
            }

            if (word[i] == '.') {
                if (n.Map.Count() == 0)
                    return false;
                else
                    return n.Map.Values.Any (v => Search (word, i + 1, v));
            } else if (n.Map.ContainsKey (word[i]))
                return (Search (word, i + 1, n.Map[word[i]]));
            else
                return false;
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

    /**
     * Your WordDictionary object will be instantiated and called as such:
     * WordDictionary obj = new WordDictionary();
     * obj.AddWord(word);
     * bool param_2 = obj.Search(word);
     */
}