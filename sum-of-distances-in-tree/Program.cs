using System;
using System.Collections.Generic;

namespace sum_of_distances_in_tree
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = new Solution();
            s.SumOfDistancesInTree(6, new [] { new [] {0,1}, new []{0,2},new []{2,3},new []{2,4},new []{2,5}});
        }
    }

public class Node {
    public List<int> Edges {get; set;} = new List<int>();
    public int Value {get; private set;}
    public Node(int v){
        Value = v;
    }
}

public class Solution {
    List<Node> graph;
    
    public int[] SumOfDistancesInTree(int N, int[][] edges) {
        graph = new List<Node>();
        Build(N, edges);
        
        var result = new List<int>();
        foreach(Node n in graph){
            result.Add(Sum(n));
        }
        return result.ToArray();
    }
    
    private void Build (int N, int[][] edges){
        for(int i = 0; i<N;i++){
            graph.Add(new Node(i));
        }
        
        for(int i=0;i<edges.Length; i++){
            graph[edges[i][0]].Edges.Add(edges[i][1]);
            graph[edges[i][1]].Edges.Add(edges[i][0]);
        }
    }
    
    private int Sum(Node n){
        var h = new HashSet<int>();
        h.Add(n.Value);
        var q = new Queue<Tuple<Node, int>>();
        q.Enqueue(Tuple.Create(n, 0));
        int res = 0;
        while(q.Count > 0){
            var cn = q.Dequeue();
            foreach(int e in cn.Item1.Edges){
                if(!h.Contains(e)){
                    q.Enqueue(Tuple.Create(graph[e],cn.Item2+1));
                    h.Add(e);
                    res+=cn.Item2;
                }
            }
        }
        
        return res;
    }
}
}
