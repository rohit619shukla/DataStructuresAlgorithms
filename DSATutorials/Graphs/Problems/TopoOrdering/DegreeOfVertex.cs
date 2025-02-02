//using System;
//using System.Collections.Generic;

//class Graph
//{
//    public int v;
//    public LinkedList<int>[] adj;

//    public Graph(int vertices)
//    {
//        v = vertices;
//        adj = new LinkedList<int>[v];

//        for (int i = 0; i < v; i++)
//        {
//            adj[i] = new LinkedList<int>();
//        }
//    }

//    public void AddEdge(int source, int destination)
//    {
//        adj[source].AddLast(destination);
//    }

//    public void DegreesOfVertices()
//    {
//        int[] inDegree = new int[v];
//        int[] outDegree = new int[v];

//        for (int u = 0; u < v; u++)
//        {
//            var edges = adj[u];

//            outDegree[u] = edges.Count;

//            foreach (var v in edges)
//            {
//                inDegree[v]++;
//            }
//        }

//        for (int i = 0; i < v; i++)
//        {
//            Console.WriteLine($"For the vertex: {i} , its indegree is: {inDegree[i]}, and outdegree is: {outDegree[i]}");
//        }
//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        Graph g = new Graph(7);

//        g.AddEdge(0, 1);
//        g.AddEdge(0, 2);
//        g.AddEdge(1, 3);
//        g.AddEdge(2, 0);
//        g.AddEdge(2, 6);
//        g.AddEdge(2, 5);
//        g.AddEdge(3, 1);
//        g.AddEdge(3, 4);
//        g.AddEdge(4, 2);
//        g.AddEdge(4, 3);
//        g.AddEdge(5, 4);
//        g.AddEdge(5, 6);
//        g.AddEdge(6, 5);

//        g.DegreesOfVertices();
//    }
//}

////Complexity Analysis:

////Time Complexity: O(V + E) where V and E are the numbers of vertices and edges in the graph respectively.
////Auxiliary Space: O(V + E).  