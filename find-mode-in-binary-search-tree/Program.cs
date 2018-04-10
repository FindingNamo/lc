using System;

namespace find_mode_in_binary_search_tree {
    class Program {
        static void Main (string[] args) {
            Console.WriteLine ("Hello World!");
        }
    }

  /**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class Solution {
    public int[] FindMode(TreeNode root) {
        var r = new List<int>();
        DFS(root, r);
        
        if (r.Count == 0)
            return new int[0];
        
        if (r.Count == 1)
            return new int[] {r[0]};
        
        int maxRep = 1;
        int curRep = 1;
        int last = r[0];
        List<int> modes = new List<int> {r[0]};
        for(int i = 1; i < r.Count; i++){
            if(r[i] == last){
                curRep++;
                if(curRep == maxRep){
                    modes.Add(r[i]);
                }
                else if(curRep > maxRep){
                    modes = new List<int> {r[i]};
                    maxRep = curRep;
                }
            }
            else{
                curRep = 1;
                
                if(curRep == maxRep){
                    modes.Add(r[i]);
                }
            }
            
            last = r[i];
        }
        
        return modes.ToArray();
    }
    
    private void DFS(TreeNode node, IList<int> r){
        if (node == null)
            return;
        
        DFS(node.left, r);
        r.Add(node.val);
        DFS(node.right, r);
    }
}
}