

//using System.Xml.Linq;

//class Graph
//{
//    private int v;
//    private int[,] adj;

//    public Graph(int vertices)
//    {
//        v = vertices;
//        adj = new int[v, v];
//    }

//    public void AddEdge(int s, int d, int w)
//    {
//        adj[s, d] = w;
//        adj[d, s] = w;
//    }

//    public void Solve(int start)
//    {
//        // distance array to store cost
//        int[] distance = new int[v];
//        int[] parent = new int[v];

//        Array.Fill(distance, int.MaxValue);
//        Array.Fill(parent, -1);

//        // mark the start node as cost 0
//        distance[0] = 0;

//        // explored array
//        int[] explored = new int[v];

//        // iterate over graph
//        for (int i = 0; i < v - 1; i++)
//        {
//            // Get the minVertex
//            int minVertex = MinVertex(i, explored, distance);

//            // mark the node as explored
//            explored[minVertex] = 1;

//            // Explore adjacent vertices
//            for (int j = 0; j < v; j++)
//            {
//                if (adj[minVertex, j] != 0 && explored[j] == 0)
//                {
//                    if (adj[minVertex, j] < distance[j])
//                    {
//                        distance[j] = adj[minVertex, j];
//                        parent[j] = minVertex;
//                    }
//                }
//            }
//        }

//        for (int i = 0; i < v; i++)
//        {
//            Console.WriteLine($"To node {i} , from parent : {parent[i]} , the cost is : {distance[i]}");
//        }
//    }

//    private int MinVertex(int node, int[] explored, int[] distance)
//    {
//        int minVertex = -1;

//        for (int i = 0; i < v; i++)
//        {
//            if (explored[i] == 0 && (minVertex == -1 || distance[minVertex] > distance[i]))
//            {
//                minVertex = i;
//            }
//        }

//        return minVertex;
//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        Graph g = new Graph(5);

//        g.AddEdge(0, 1, 4);
//        g.AddEdge(0, 2, 8);
//        g.AddEdge(1, 3, 6);
//        g.AddEdge(1, 2, 2);
//        g.AddEdge(2, 3, 3);
//        g.AddEdge(2, 4, 9);
//        g.AddEdge(3, 4, 5);

//        g.Solve(0);
//    }
//}

////Complexity: O(N ^ 2)

////= O(V - 1. (V + V))
////= O(V ^ 2 + V ^ 2)
////= O(V ^ 2)  