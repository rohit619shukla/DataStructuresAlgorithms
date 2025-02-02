//// Leetcode 802 (Medium)

//public class Solution
//{
//    public IList<int> EventualSafeNodes(int[][] graph)
//    {
//        int nodes = graph.Length;

//        Graph g = new Graph(nodes);


//        for (int i = 0; i < nodes; i++)
//        {
//            int nodeCols = graph[i].Length;

//            for (int j = 0; j < nodeCols; j++)
//            {
//                g.AddEdge(i, graph[i][j]);
//            }
//        }

//        IList<int> result = new List<int>();

//        int[] explored = new int[nodes];
//        int[] pathVisited = new int[nodes];

//        for (int i = 0; i < nodes; i++)
//        {
//            if (explored[i] == 0)
//            {
//                DFS(i, explored, pathVisited, g.adj);
//            }
//        }


//        // The idea behind using path visited is that all the nodes which are part of cycle will not lead to terminal nodes 
//        // Also any node leading to cycle will also be not part of terminal node path
//        for (int i = 0; i < nodes; i++)
//        {
//            if (pathVisited[i] == 0)
//            {
//                result.Add(i);
//            }
//        }

//        return result;
//    }

//    private bool DFS(int currentNode, int[] explored, int[] pathVisited, List<int>[] adj)
//    {
//        explored[currentNode] = 1;

//        pathVisited[currentNode] = 1;

//        foreach (var neigh in adj[currentNode])
//        {
//            if (explored[neigh] == 0)
//            {
//                if (DFS(neigh, explored, pathVisited, adj))
//                {
//                    return true;
//                }
//            }
//            else
//            {
//                if (pathVisited[neigh] == 1)
//                {
//                    return true;
//                }
//            }
//        }

//        pathVisited[currentNode] = 0;
//        return false;
//    }
//}

//public class Graph
//{
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

//    public void AddEdge(int source, int dest)
//    {
//        adj[source].Add(dest);
//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        int[][] graph = new int[][] {
//            new int[] {1,2 },
//            new int[] { 2,3},
//            new int[] {5 },
//            new int[] {0 },
//            new int[] {5 },
//            new int[] { },
//            new int[] { }
//        };

//        Solution s = new Solution();

//        var result = s.EventualSafeNodes(graph);

//        foreach (var item in result)
//        {
//            Console.Write($"{item}" + " ");
//        }
//    }
//}

//// Time Complexity: O(V + E) + O(V), where V = no.of nodes and E = no. of edges. There can be at most V components. So, another O(V) time complexity.

//// Space Complexity: O(3N) + O(N) ~O(3N): O(3N) for three arrays required during dfs calls and O(N) for recursive stack space.