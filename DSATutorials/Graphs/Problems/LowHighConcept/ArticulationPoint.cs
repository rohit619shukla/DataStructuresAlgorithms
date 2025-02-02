//class Graph
//{
//    private static int timer;
//    private int v;
//    private List<int>[] adj;

//    public Graph(int vertices)
//    {
//        v = vertices;
//        adj = new List<int>[v];

//        for (int i = 0; i < v; i++)
//        {
//            adj[i] = new List<int>();
//        }
//    }

//    public void AddEdge(int source, int dest)
//    {
//        adj[source].Add(dest);
//        adj[dest].Add(source);
//    }

//    public void AP()
//    {
//        int[] low = new int[v];
//        int[] disc = new int[v];
//        int[] explored = new int[v];

//        for (int i = 0; i < v; i++)
//        {
//            if (explored[i] == 0)
//            {
//                DFS(i, -1, low, disc, explored);
//            }
//        }
//    }

//    private void DFS(int currentNode, int parentNode, int[] low, int[] disc, int[] explored)
//    {
//        // create childrens to keep track
//        int children = 0;

//        // mark the node as visited
//        explored[currentNode] = 1;

//        // update the timer as DFS proceeds
//        low[currentNode] = disc[currentNode] = timer++;

//        // Explore the adjcent nodes
//        foreach (int neighNode in adj[currentNode])
//        {
//            if (parentNode == currentNode)
//            {
//                continue;
//            }

//            if (explored[neighNode] == 0)
//            {
//                // increase children count
//                children++;
//                DFS(neighNode, currentNode, low, disc, explored);

//                // update low of the currentNode
//                low[currentNode] = Math.Min(low[currentNode], low[neighNode]);


//                // The node should be parent and children is greater than 1
//                if (parentNode == -1 && children > 1)
//                {
//                    Console.WriteLine($"{currentNode}" + " ");
//                }

//                if (parentNode != -1 && low[neighNode] >= disc[currentNode])
//                {
//                    Console.WriteLine($"{currentNode}" + " ");
//                }
//            }
//            else
//            {
//                low[currentNode] = Math.Min(low[currentNode], disc[neighNode]);
//            }
//        }
//    }
//}

//class Program
//{
//    public static void Main()
//    {
//        Console.WriteLine("Articulation points in first graph ");
//        Graph g1 = new Graph(5);
//        g1.AddEdge(1, 0);
//        g1.AddEdge(0, 2);
//        g1.AddEdge(2, 1);
//        g1.AddEdge(0, 3);
//        g1.AddEdge(3, 4);
//        g1.AP();
//        Console.WriteLine();

//        Console.WriteLine("Articulation points in Second graph");
//        Graph g2 = new Graph(4);
//        g2.AddEdge(0, 1);
//        g2.AddEdge(1, 2);
//        g2.AddEdge(2, 3);
//        g2.AP();
//        Console.WriteLine();

//        Console.WriteLine("Articulation points in Third graph ");
//        Graph g3 = new Graph(7);
//        g3.AddEdge(0, 1);
//        g3.AddEdge(1, 2);
//        g3.AddEdge(2, 0);
//        g3.AddEdge(1, 3);
//        g3.AddEdge(1, 4);
//        g3.AddEdge(1, 6);
//        g3.AddEdge(3, 5);
//        g3.AddEdge(4, 5);
//        g3.AP();
//    }
//}

////Time Complexity: O(V + E), For DFS it takes O(V+E) time.
////Auxiliary Space: O(V + E), For visited array, adjacency list array

//// Low : earliest possible time to reach a Node
//// Disc : discovery tim eof the node