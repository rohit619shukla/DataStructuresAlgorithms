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

//    public void AddEdge(int source, int destination, int weight)
//    {
//        adj[source, destination] = weight;
//        adj[destination, source] = weight;
//    }

//    public void PrintShorestPathFromSource(int start)
//    {
//        int[] explored = new int[v];
//        int[] distance = new int[v];

//        // Mark initial distance of all nodes as infinity
//        for (int i = 0; i < v; i++)
//        {
//            distance[i] = int.MaxValue;
//        }

//        // Mark distance of start node as 0
//        distance[start] = 0;

//        // start extracting all nodes
//        for (int i = 0; i < v; i++)
//        {
//            // Get min node
//            int minNode = GetMinNode(explored, distance);

//            // Mark the MinNode as visited
//            explored[minNode] = 1;

//            // determine distance of destination node from source
//            for (int j = 0; j < v; j++)
//            {
//                // detsination should have not been visited and a path should have existed
//                if (explored[j] == 0 && adj[minNode, j] != 0)
//                {
//                    if (distance[minNode] + adj[minNode, j] < distance[j])
//                    {
//                        distance[j] = distance[minNode] + adj[minNode, j];
//                    }
//                }
//            }
//        }

//        for (int i = 0; i < v; i++)
//        {
//            Console.WriteLine($" from source : {start} to destination : {distance[i]}");
//        }

//    }

//    private int GetMinNode(int[] explored, int[] distance)
//    {
//        int minNode = -1;

//        for (int i = 0; i < v; i++)
//        {
//            if (explored[i] == 0 && (minNode == -1 || distance[minNode] > distance[i]))
//            {
//                minNode = i;
//            }
//        }
//        return minNode;
//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        Graph g = new Graph(5);

//        g.AddEdge(0, 1, 4);
//        g.AddEdge(0, 2, 8);
//        g.AddEdge(1, 2, 2);
//        g.AddEdge(1, 3, 5);
//        g.AddEdge(2, 3, 5);
//        g.AddEdge(2, 4, 9);
//        g.AddEdge(3, 4, 4);

//        g.PrintShorestPathFromSource(0);
//    }
//}

//// Complexity : O(N^2)