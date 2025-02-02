//using System;

//class Graph
//{
//    public int v;
//    public int[,] adj;

//    public Graph(int vertices)
//    {
//        v = vertices;
//        adj = new int[v, v];
//    }

//    public void AddEdge(int source, int destination)
//    {
//        this.adj[source, destination] = 1;
//        this.adj[destination, source] = 1;
//    }

//    public void PrintGraph()
//    {
//        for (int i = 0; i < this.v; i++)
//        {
//            for (int j = 0; j < this.v; j++)
//            {
//                Console.Write($"{this.adj[i, j]}" + " ");
//            }
//            Console.WriteLine();
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

//        g.PrintGraph();
//    }
//}

//// Complexity : O(V*E)