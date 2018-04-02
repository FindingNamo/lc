using System;

namespace merge_two_sorted_lists {
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
        public ListNode MergeTwoLists (ListNode l1, ListNode l2) {
            ListNode head = null;
            ListNode curNode = null;
            ListNode l1Walker = l1;
            ListNode l2Walker = l2;
            while(l1Walker != null || l2Walker != null){
                if(head == null){
                    if(l1Walker != null && (l2Walker == null || l1Walker.val <= l2Walker.val)){
                        head = new ListNode(l1Walker.val);
                        curNode = head;
                        l1Walker = l1Walker.next;
                    }
                    else{
                        head = new ListNode(l2Walker.val);
                        curNode = head;
                        l2Walker = l2Walker.next;
                    }
                }
                else{
                    if(l1Walker != null && (l2Walker == null || l1Walker.val <= l2Walker.val)){
                        curNode.next = new ListNode(l1Walker.val);
                        curNode = curNode.next;
                        l1Walker = l1Walker.next;
                    }
                    else{
                        curNode.next = new ListNode(l2Walker.val);
                        curNode = curNode.next;
                        l2Walker = l2Walker.next;
                    }
                }
            }

            return head;
        }
    }
}