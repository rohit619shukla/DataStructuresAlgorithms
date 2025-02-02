
//class Graph
//{
//    public static int Timer = 0;
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

//    public void AddEdge(int src, int dest)
//    {
//        adj[src].Add(dest);
//    }

//    public void SCC()
//    {
//        int[] disc = new int[v];
//        int[] low = new int[v];
//        int[] explored = new int[v];

//        Stack<int> st = new Stack<int>();
//        HashSet<int> seen = new HashSet<int>();

//        for (int i = 0; i < v; i++)
//        {
//            if (explored[i] == 0)
//            {
//                DFS(i, disc, low, explored, st, seen);
//            }
//        }
//    }

//    private void DFS(int currentNode, int[] disc, int[] low, int[] explored, Stack<int> st, HashSet<int> seen)
//    {
//        // Add the node to stack
//        st.Push(currentNode);

//        // Mark the node as seen
//        seen.Add(currentNode);

//        explored[currentNode] = 1;

//        disc[currentNode] = low[currentNode] = ++Timer;

//        foreach (var neighNode in adj[currentNode])
//        {
//            if (explored[neighNode] == 0)
//            {
//                DFS(neighNode, disc, low, explored, st, seen);

//                low[currentNode] = Math.Min(low[currentNode], low[neighNode]);
//            }
//            else
//            {
//                if (seen.Contains(neighNode))
//                {
//                    low[currentNode] = Math.Min(low[currentNode], disc[neighNode]);
//                }
//            }
//        }

//        if (low[currentNode] == disc[currentNode])
//        {
//            while (st.Peek() != currentNode)
//            {
//                Console.Write($"{st.Pop()}" + " ");
//                seen.Remove(currentNode);
//            }

//            Console.Write($"{st.Pop()}" + " ");
//            seen.Remove(currentNode);
//            Console.WriteLine();
//        }
//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        Graph g = new Graph(5);

//        // Add edges to the graph
//        g.AddEdge(0, 3);
//        g.AddEdge(3, 4);
//        g.AddEdge(1, 0);
//        g.AddEdge(0, 2);
//        g.AddEdge(2, 1);

//        Console.WriteLine("Strongly Connected Components:");
//        g.SCC();

//        Graph g2 = new Graph(4);
//        g2.AddEdge(0, 1);
//        g2.AddEdge(1, 2);
//        g2.AddEdge(2, 3);
//        Console.WriteLine("\nSSC in second graph ");
//        g2.SCC();

//        Graph g3 = new Graph(7);
//        g3.AddEdge(0, 1);
//        g3.AddEdge(1, 2);
//        g3.AddEdge(2, 0);
//        g3.AddEdge(1, 3);
//        g3.AddEdge(1, 4);
//        g3.AddEdge(1, 6);
//        g3.AddEdge(3, 5);
//        g3.AddEdge(4, 5);
//        Console.WriteLine("\nSSC in third graph ");
//        g3.SCC();



//        Graph g5 = new Graph(5);
//        g5.AddEdge(0, 1);
//        g5.AddEdge(1, 2);
//        g5.AddEdge(2, 3);
//        g5.AddEdge(2, 4);
//        g5.AddEdge(3, 0);
//        g5.AddEdge(4, 2);
//        Console.WriteLine("\nSSC in fifth graph ");
//        g5.SCC();
//    }
//}

////Time Complexity: The above algorithm mainly calls DFS, DFS takes O(V+E) for a graph represented using an adjacency list.
////Auxiliary Space: O(V)