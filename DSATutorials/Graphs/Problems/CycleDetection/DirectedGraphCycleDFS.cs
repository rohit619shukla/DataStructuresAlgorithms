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

//    private bool IsCyclicUtil(int[] explored, int node, int[] path)
//    {
//        // Mark the node as visited
//        explored[node] = 1;

//        // Mark the node as true in same path
//        path[node] = 1;

//        // apply DFS on nearby nodes
//        foreach (var item in adj[node])
//        {
//            // If the node has not been visited then apply DFS
//            if (explored[item] == 0)
//            {
//                if (IsCyclicUtil(explored, item, path))
//                {
//                    return true;
//                }
//            }
//            else if (path[item] == 1)
//            {
//                return true;
//            }
//        }

//        // backtracking (very imp)
//        path[node] = 0;
//        return false;
//    }
//    public bool IsCyclic()
//    {
//        int[] explored = new int[v];
//        int[] path = new int[v];

//        for (int i = 0; i < v; i++)
//        {
//            if (explored[i] == 0)
//            {
//                if (IsCyclicUtil(explored, i, path))
//                {
//                    return true;
//                }
//            }
//        }
//        return false;
//    }
//}

//class Program
//{
//    public static void Main()
//    {
//        //Graph graph = new Graph(4);

//        //graph.AddEdge(0, 1);
//        //graph.AddEdge(0, 2);
//        //graph.AddEdge(1, 2);
//        //graph.AddEdge(2, 0);
//        //graph.AddEdge(2, 3);
//        //graph.AddEdge(3, 3);

//        Graph graph = new Graph(6);
//        graph.AddEdge(0, 1);
//        graph.AddEdge(0, 2);
//        graph.AddEdge(1, 3);
//        graph.AddEdge(4, 1);
//        graph.AddEdge(4, 5);
//        graph.AddEdge(5, 3);

//        if (graph.IsCyclic())
//        {
//            Console.WriteLine("Graph contains cycle");
//        }
//        else
//        {
//            Console.WriteLine("Graph does not contains cycle");
//        }

//    }
//}


//// Complexity : O(V+E)