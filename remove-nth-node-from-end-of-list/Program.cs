using System;
using System.Collections.Generic;

namespace remove_nth_node_from_end_of_list {
    class Program {
        static void Main (string[] args) {
            Console.WriteLine ("Hello World!");
        }
    }

    public class ListNode {
        public int val;
        public ListNode next;
        public ListNode (int x) { val = x; }
    }

    public class Solution {
        public ListNode RemoveNthFromEnd (ListNode head, int n) {

            if (n == 1 && head.next == null)
                return null;
            else if (n == 1)
                return RemoveLast (head);
            else {
                var curNode = head;
                var nthNode = head;
                var trailingNode = head;
                for (int i = 0; i < n - 1; i++) {
                    curNode = curNode.next;
                }

                if (curNode.next == null) {
                    head = head.next;
                    return head;
                }

                nthNode = nthNode.next;
                curNode = curNode.next;
                while (curNode.next != null) {
                    curNode = curNode.next;
                    nthNode = nthNode.next;
                    trailingNode = trailingNode.next;
                }
                trailingNode.next = nthNode.next;
            }
            return head;
        }

        private ListNode RemoveLast (ListNode head) {
            ListNode curNode = head.next;
            ListNode prevNode = head;
            while (curNode.next != null) {
                prevNode = prevNode.next;
                curNode = curNode.next;
            }

            prevNode.next = null;

            return head;
        }
    }
}