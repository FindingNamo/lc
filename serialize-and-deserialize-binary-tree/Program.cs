using System;
using System.Collections.Generic;
using System.Text;

namespace serialize_and_deserialize_binary_tree
{
 class Program {
        static void Main (string[] args) {
            /*
              1
              /\
             4  5
               / 
              2
             / \
            2   10   */
            Node n = new Node { Value = 1 };
            n.Left = new Node { Value = 4 };
            n.Right = new Node {
                Value = 5,
                Left = new Node {
                Value = 2,
                Left = new Node { Value = 2, },
                Right = new Node { Value = 10 }
                }
            };

            Console.WriteLine ("Serialize");
            Console.WriteLine (new TreeSerializer().Serialize(n));
            Console.WriteLine ("Deserialize");
            var s = new TreeSerializer().Serialize(n);
            Node root = new TreeSerializer().Deserialize(s);
            Console.WriteLine (new TreeSerializer().Serialize(root));
        }
    }

    class Node {
        public Node Left { get; set; }

        public Node Right { get; set; }

        public int Value { get; set; }
    }

    class TreeSerializer {

        const string nullstr = "null";

        public string Serialize (Node node) {
            if (node == null)
                return string.Empty;

            StringBuilder sb = new StringBuilder ();
            sb.Append ($"{node.Value}");
            Queue<Node> q = new Queue<Node> ();
            q.Enqueue (node.Left);
            q.Enqueue (node.Right);

            while (q.Count > 0) {
                Node curNode = q.Dequeue ();

                string val = curNode == null ? nullstr : curNode.Value.ToString ();
                sb.Append ($",{val}");

                if (curNode != null) {
                    if (curNode.Left != null)
                        q.Enqueue (curNode.Left);
                    else
                        q.Enqueue (null);

                    if (curNode.Right != null)
                        q.Enqueue (curNode.Right);
                    else
                        q.Enqueue (null);
                }
            }

            return sb.ToString ();
        }

        public Node Deserialize (string s) {
            string[] tokens = s.Split (',');

            Node root = new Node {Value = int.Parse(tokens[0])};
            Queue<Node> q = new Queue<Node> ();
            q.Enqueue (root);
            int i = 1;
            while (i < tokens.Length) {
                Node curNode = q.Dequeue ();
                if (curNode != null) {
                    if (i < tokens.Length) {
                        if (tokens[i] != nullstr) {
                            Node left = new Node{Value = int.Parse(tokens[i])};
                            curNode.Left = left;
                            q.Enqueue (left);
                        } else {
                            curNode.Left = null;
                            q.Enqueue (null);
                        }
                        i++;
                    }

                    if (i < tokens.Length) {
                        if (tokens[i] != nullstr) {
                            Node right = new Node{Value = int.Parse(tokens[i])};
                            curNode.Right = right;
                            q.Enqueue (right);
                        } else {
                            curNode.Right = null;
                            q.Enqueue (null);
                        }
                        i++;
                    }
                }
            }

            return root;
        }
    }
}
