
//class Graph
//{
//    private int v;
//    private List<int>[] adj;

//    public Graph(int ver)
//    {
//        v = ver;
//        adj = new List<int>[v];

//        for (int i = 0; i < v; i++)
//        {
//            adj[i] = new List<int>();
//        }
//    }
//    public void AddEdge(int source, int destination)
//    {
//        adj[source].Add(destination);
//        adj[destination].Add(source);
//    }
//    public int CountCompleteComponents()
//    {
//        int[] explored = new int[v];
//        int finalCount = 0;

//        for (int i = 0; i < v; i++)
//        {
//            int nodes = 0, edges = 0;

//            if (explored[i] == 0)
//            {
//                DFS(i, explored, ref nodes, ref edges);

//                // since this is undirected graph, hence we are focused on unique edges only
//                edges /= 2;

//                if (edges == nodes * (nodes - 1) / 2)
//                {
//                    finalCount++;
//                }
//            }
//        }
//        return finalCount;
//    }

//    private void DFS(int node, int[] explored, ref int nodes, ref int edges)
//    {
//        explored[node] = 1;

//        nodes++;

//        edges += adj[node].Count;

//        foreach (var neigh in adj[node])
//        {
//            if (explored[neigh] == 0)
//            {
//                DFS(neigh, explored, ref nodes, ref edges);
//            }
//        }
//    }


//}

//class Program
//{
//    public static void Main()
//    {
//        int[][] edges = new int[][] {
//            new int[] { 0,1},
//            new int[] { 0,2},
//            new int[] { 1,2},
//            new int[] { 3,4},
//            new int[] { 3,5}
//        };

//        Graph g = new Graph(6);

//        foreach (var edge in edges)
//        {
//            int i = edge[0];
//            int j = edge[1];

//            g.AddEdge(i, j);
//        }

//        Console.WriteLine(g.CountCompleteComponents());
//    }
//}

//// Complexity : O(v+E) both space and time. As each node will be explored once .The DFS traverses each vertex and its edges exactly once