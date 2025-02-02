
// class Graph
// {
//    public int v;
//    public List<int[]>[] adj;
//    private const int INF = int.MaxValue;

//    public Graph(int vertices)
//    {
//        v = vertices;
//        adj = new List<int[]>[v];

//        for (int i = 0; i < v; i++)
//        {
//            adj[i] = new List<int[]>();
//        }
//    }

//    public void AddEdge(int source, int destination, int weight)
//    {
//        adj[source].Add(new int[] { destination, weight });
//    }

//    public void ShortestPath(int source)
//    {
//        Stack<int> st = new Stack<int>();
//        int[] visited = new int[v];
//        int[] dest = new int[v];

//        for (int i = 0; i < v; i++)
//        {
//            visited[i] = -1;
//            dest[i] = INF;
//        }

//        // perform topological sort to create an order in which we would like to process the nodes
//        for (int i = 0; i < v; i++)
//        {
//            if (visited[i] == -1)
//            {
//                DFS(i, st, visited);
//            }
//        }

//        // Mark the destination of source as 0
//        dest[source] = 0;

//        while (st.Count != 0)
//        {
//            int temp = st.Peek();
//            st.Pop();

//            if (dest[temp] == INF)
//            {
//                continue;
//            }

//            foreach (var item in adj[temp])
//            {
//                int destNode = item[0];
//                int destWeight = item[1];

//                if (dest[temp] + destWeight < dest[destNode])
//                {
//                    dest[destNode] = dest[temp] + destWeight;
//                }
//            }
//        }

//        for (int i = 0; i < v; i++)
//        {
//            Console.WriteLine($"From source  : {source} , to dest :{i}, distance is  : {dest[i]}");
//        }
//    }
//    private void DFS(int u, Stack<int> st, int[] visited)
//    {
//        visited[u] = 1;

//        foreach (var item in adj[u])
//        {
//            var edges = item;
//            int destNode = edges[0];

//            if (visited[destNode] == -1)
//            {
//                DFS(destNode, st, visited);
//            }
//        }

//        // while returning back add to stack. This is part of topological sort via DFS
//        st.Push(u);
//    }
// }
// class Program
// {
//    public static void Main()
//    {
//        Graph g = new Graph(6);

//        g.AddEdge(0, 1, 5);
//        g.AddEdge(0, 2, 3);
//        g.AddEdge(1, 3, 6);
//        g.AddEdge(1, 2, 2);
//        g.AddEdge(2, 4, 4);
//        g.AddEdge(2, 5, 2);
//        g.AddEdge(2, 3, 7);
//        g.AddEdge(3, 4, -1);
//        g.AddEdge(4, 5, -2);
//        g.ShortestPath(1);
//    }
// }

// //Time Complexity: Time complexity of topological sorting is O(V+E). 
// // After finding topological order, the algorithm process all vertices and for every vertex, it runs a loop for all adjacent vertices. Total adjacent vertices in a graph is O(E). So the inner loop runs O(V+E) times.Therefore, overall time complexity of this algorithm is O(V+E).

// //Auxiliary Space : O(V + E)