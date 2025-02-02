//using System;

//class Edge : IComparable<Edge>
//{
//    public int s;
//    public int d;
//    public int w;

//    public int CompareTo(Edge ed)
//    {
//        return w - ed.w;
//    }
//}
//class Graph
//{
//    public Edge[] adj;
//    public int e;
//    public int v;

//    public Graph(int vertices, int edges)
//    {
//        v = vertices;
//        e = edges;

//        adj = new Edge[e];

//        for (int i = 0; i < e; i++)
//        {
//            adj[i] = new Edge();
//        }
//    }

//    public void AddEdge(int source, int destination, int weight, ref int count)
//    {
//        adj[count].s = source;
//        adj[count].d = destination;
//        adj[count].w = weight;

//        count++;
//    }

//    public void KruskalAlgorithm()
//    {
//        int[] parent = new int[v];
//        Edge[] output = new Edge[v - 1];

//        for (int x = 0; x < v; x++)
//        {
//            parent[x] = x;
//        }

//        int edgeCount = 0;
//        int i = 0;

//        Array.Sort(adj);

//        while (edgeCount != v - 1)
//        {
//            Edge ed = adj[i];

//            int source = ed.s;
//            int destination = ed.d;

//            int sourceParent = FindParent(source, parent);
//            int destinationParent = FindParent(destination, parent);

//            if (sourceParent != destinationParent)
//            {
//                parent[destinationParent] = sourceParent;
//                output[edgeCount] = ed;
//                edgeCount++;
//            }
//            i++;
//        }

//        for (int j = 0; j < edgeCount; j++)
//        {
//            Console.WriteLine($" From source: {output[j].s} , to destination: {output[j].d}. the weight: {output[j].w}");
//        }
//    }

//    private int FindParent(int v, int[] parent)
//    {
//        if (parent[v] == v)
//        {
//            return v;
//        }
//        else
//        {
//            return FindParent(parent[v], parent);
//        }
//    }
//}

//class Program
//{
//    public static void Main()
//    {
//        Graph g = new Graph(5, 7);
//        int count = 0;

//        g.AddEdge(0, 1, 4, ref count);
//        g.AddEdge(0, 2, 8, ref count);
//        g.AddEdge(1, 3, 6, ref count);
//        g.AddEdge(1, 2, 2, ref count);
//        g.AddEdge(2, 3, 3, ref count);
//        g.AddEdge(2, 4, 9, ref count);
//        g.AddEdge(3, 4, 5, ref count);

//        g.KruskalAlgorithm();
//    }
//}

////Time Complexity: O(E * logE) or O(E* logV)

////Sorting of edges takes O(E * logE) time.
////After sorting, we iterate through all edges and apply the find-union algorithm. The find and union operations can take at most O(logV) time.
////So overall complexity is O(E * logE + E * logV) time.
////The value of E can be at most O(V2), so O(logV) and O(logE) are the same. Therefore, the overall time complexity is O(E * logE) or O(E* logV)
////Auxiliary Space: O(V + E), where V is the number of vertices and E is the number of edges in the graph.  