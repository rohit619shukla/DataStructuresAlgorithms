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

//        for (int i = 0; i < this.v; i++)
//        {
//            adj[i] = new List<int>();
//        }
//    }

//    public void AddEdge(int source, int destination)
//    {
//        this.adj[source].Add(destination);
//    }

//    public void BFS(int start)
//    {
//        int[] explored = new int[this.v];

//        explored[start] = 1;

//        Queue<int> q = new Queue<int>();
//        q.Enqueue(start);

//        while (q.Count != 0)
//        {
//            int temp = q.Peek();
//            q.Dequeue();

//            Console.Write($"{temp}" + " -> ");

//            foreach (var item in this.adj[temp])
//            {
//                if (explored[item] == 0)
//                {
//                    explored[item] = 1;
//                    q.Enqueue(item);
//                }
//            }
//        }
//    }

//    public void PrintGraph()
//    {
//        for (int i = 0; i < this.v; i++)
//        {
//            Console.Write($"{i}" + "->");

//            foreach (var item in this.adj[i])
//            {
//                Console.Write($"{item}" + "->");
//            }
//        }
//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        Graph g = new Graph(4);

//        g.AddEdge(0, 1);
//        g.AddEdge(0, 2);
//        g.AddEdge(1, 2);
//        g.AddEdge(2, 0);
//        g.AddEdge(2, 3);
//        g.AddEdge(3, 3);

//        g.BFS(2);
//    }
//}

////Time Complexity: O(V + E), where V is the number of nodes and E is the number of edges.
////Auxiliary Space: O(V)