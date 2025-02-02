//using System;
//using System.Collections.Generic;

//class Graph
//{
//    public int v;
//    public List<int>[] adj;
//    public Graph(int vertices)
//    {
//        v = vertices;
//        adj = new List<int>[v];

//        for (int i = 0; i < v; i++)
//        {
//            adj[i] = new List<int>();
//        }
//    }

//    public void AddEdge(int source, int destination)
//    {
//        adj[source].Add(destination);
//    }

//    public void DFS(int start, int[] explored)
//    {
//        explored[start] = 1;

//        Console.Write($"{start}" + "-> ");

//        foreach (var item in adj[start])
//        {
//            if (explored[item] == 0)
//            {
//                DFS(item, explored);
//            }
//        }
//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        Graph g = new Graph(4);

//        int[] explored = new int[g.v];

//        g.AddEdge(0, 1);
//        g.AddEdge(0, 2);
//        g.AddEdge(1, 2);
//        g.AddEdge(2, 0);
//        g.AddEdge(2, 3);
//        g.AddEdge(3, 3);


//        g.DFS(2, explored);
//    }
//}

////Complexity Analysis: 
////Time complexity: O(V + E), where V is the number of vertices and E is the number of edges in the graph.
////Space Complexity: O(V).Since an extra visited array is needed of size V.
