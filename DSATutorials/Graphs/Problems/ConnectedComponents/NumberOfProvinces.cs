

//class Graph
//{
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

//    public void AddEdge(int source, int destination)
//    {
//        adj[source].Add(destination);
//        adj[destination].Add(source);
//    }

//    public int Solve()
//    {
//        int count = 0;

//        int[] explored = new int[v];

//        for (int i = 0; i < v; i++)
//        {
//            if (explored[i] == 0)
//            {
//                DFS(i, explored);
//                count++;
//            }
//        }

//        return count;
//    }

//    private void DFS(int v, int[] explored)
//    {
//        explored[v] = 1;

//        foreach (var item in adj[v])
//        {
//            if (explored[item] == 0)
//            {
//                DFS(item, explored);
//            }
//        }
//    }
//}

//class Program
//{
//    public static void Main()
//    {
//        int[][] arr = new int[][] {
//            new int[] { 0,1,0},
//            new int[] { 1,0,0},
//            new int[] { 0,0,0}
//        };

//        int rows = arr.Length;
//        int cols = arr[0].Length;

//        Graph g = new Graph(rows);

//        for (int i = 0; i < arr.Length; i++)
//        {
//            for (int j = 0; j < arr[0].Length; j++)
//            {
//                if (arr[i][j] == 1)
//                {
//                    g.AddEdge(i, j);
//                }
//            }
//        }

//        Console.WriteLine(g.Solve());
//    }
//}

//// Complexity : O(V+E)