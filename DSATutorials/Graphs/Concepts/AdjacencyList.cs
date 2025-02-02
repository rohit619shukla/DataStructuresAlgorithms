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

//    public void InsertEdge(int source, int destination)
//    {
//        this.adj[source].AddLast(destination);
//        this.adj[destination].AddLast(source);
//    }

//    public void PrintGraph()
//    {
//        for (int i = 0; i < this.v; i++)
//        {
//            Console.Write($"{i}" + " -> ");

//            foreach (var item in this.adj[i])
//            {
//                Console.Write($"{item}" + " -> ");
//            }

//            Console.WriteLine();
//        }
//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        Graph g = new Graph(5);

//        g.InsertEdge(0, 1);
//        g.InsertEdge(0, 4);
//        g.InsertEdge(1, 2);
//        g.InsertEdge(1, 3);
//        g.InsertEdge(1, 4);
//        g.InsertEdge(2, 3);
//        g.InsertEdge(3, 4);

//        g.PrintGraph();
//    }
//}

//// Complexity : O(V+2E) : Space