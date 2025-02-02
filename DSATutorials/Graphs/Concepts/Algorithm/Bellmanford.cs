//using System;

//class Edge
//{
//    public int Source;
//    public int Destination;
//    public int Weight;

//}
//class Graph
//{
//    public int Vertices;
//    public int E;
//    public Edge[] edges;
//    public int edgeCount;

//    public Graph(int v, int e)
//    {
//        Vertices = v;
//        E = e;

//        edges = new Edge[E];

//        for (int i = 0; i < E; i++)
//        {
//            edges[i] = new Edge();
//        }
//    }

//    public void PrintShortestPath(int start)
//    {
//        int[] distance = new int[Vertices];

//        // intialize  all nodes to infinity
//        for (int i = 0; i < Vertices; i++)
//        {
//            distance[i] = int.MaxValue;
//        }

//        // Set the start node to 0
//        distance[start] = 0;

//        // Relaxing E edges V-1 times
//        for (int i = 0; i < Vertices - 1; i++)
//        {
//            // start with edges 1 by one
//            for (int j = 0; j < E; j++)
//            {
//                // get the edge
//                Edge e = edges[j];

//                int s = e.Source;
//                int d = e.Destination;
//                int weight = e.Weight;

//                // start relaxing the neighbouring vertices
//                if (distance[s] + weight < distance[d])
//                {
//                    distance[d] = distance[s] + weight;
//                }
//            }
//        }

//        for (int i = 0; i < Vertices; i++)
//        {
//            Console.WriteLine($"form source : {start}, to destination {i} , the weight is : {distance[i]}");
//        }

//        // Check if the graph contains cycle as well

//        for (int j = 0; j < E; j++)
//        {
//            // get the edge
//            Edge e = edges[j];

//            int s = e.Source;
//            int d = e.Destination;
//            int weight = e.Weight;

//            // start relaxing the neighbouring vertices
//            if (distance[s] + weight < distance[d])
//            {
//                Console.WriteLine("Cycle exists");
//                return;
//            }
//        }
//    }

//    public void AddEdge(int s, int d, int w)
//    {
//        edges[edgeCount].Source = s;
//        edges[edgeCount].Destination = d;
//        edges[edgeCount].Weight = w;

//        edgeCount++;
//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        Graph g = new Graph(5, 8);
//        g.AddEdge(0, 1, -1);
//        g.AddEdge(0, 2, 4);
//        g.AddEdge(1, 2, 3);
//        g.AddEdge(1, 3, 2);
//        g.AddEdge(1, 4, 2);
//        g.AddEdge(3, 2, 5);
//        g.AddEdge(3, 1, 1);
//        g.AddEdge(4, 3, -3);

//        //g.AddEdge(0, 1, 4);
//        //g.AddEdge(0, 2, 8);
//        //g.AddEdge(1, 2, 2);
//        //g.AddEdge(1, 3, 5);
//        //g.AddEdge(2, 3, 5);
//        //g.AddEdge(2, 4, 9);
//        //g.AddEdge(3, 4, 4);


//        g.PrintShortestPath(0);
//    }
//}

////Time Complexity:  O(V * E), where V is the number of vertices in the graph and E is the number of edges in the graph
////Auxiliary Space: O(E)

////Notes:

////Negative weights are found in various applications of graphs. For example, instead of paying the cost for a path, we may get some advantage if we follow the path.
////Bellman-Ford works better (better than Dijkstra’s) for distributed systems. Unlike Dijkstra’s where we need to find the minimum value of all vertices, in Bellman - Ford, edges are considered one by one.
////Bellman - Ford does not work with an undirected graph with negative edges as it will be declared as a negative cycle.