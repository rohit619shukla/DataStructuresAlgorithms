

//using System.ComponentModel;

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
//        int[] explored = new int[v];

//        int count = 0;

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

//        foreach (int neigh in adj[v])
//        {
//            if (explored[neigh] == 0)
//            {
//                DFS(neigh, explored);
//            }
//        }
//    }
//}

//class Helper
//{
//    public static void Main()
//    {
//        Graph g = new Graph(5);

//        g.AddEdge(1, 0);
//        g.AddEdge(2, 1);
//        g.AddEdge(3, 4);

//        Console.WriteLine(g.Solve());
//    }
//}

//// Complexity : O(V+E) , time  and space both