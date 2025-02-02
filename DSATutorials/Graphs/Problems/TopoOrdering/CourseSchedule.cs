
////#region DFS
////public class Graph
////{
////    public int v;
////    public List<int>[] adj;

////    public Graph(int vertices)
////    {
////        v = vertices;
////        adj = new List<int>[v];

////        for (int i = 0; i < v; i++)
////        {
////            adj[i] = new List<int>();
////        }
////    }

////    public void AddEdge(int src, int dest)
////    {
////        adj[src].Add(dest);
////    }
////}
////public class Solution
////{
////    public bool CanFinish(int numCourses, int[][] prerequisites)
////    {
////        if (numCourses == 1)
////        {
////            return true;
////        }
////        // Add all edges to graph
////        Graph g = new Graph(numCourses);

////        for (int i = 0; i < prerequisites.Length; i++)
////        {
////            g.AddEdge(prerequisites[i][1], prerequisites[i][0]);
////        }

////        Stack<int> st = new Stack<int>();

////        int[] pathVisited = new int[g.v];
////        int[] explored = new int[g.v];

////        for (int i = 0; i < g.v; i++)
////        {
////            if (explored[i] == 0)
////            {
////                if (DFS(i, explored, g.adj, pathVisited))
////                {
////                    return false;
////                }
////            }
////        }
////        return true;
////    }

////    private bool DFS(int node, int[] explored, List<int>[] adj, int[] pathVisited)
////    {
////        explored[node] = 1;
////        pathVisited[node] = 1;

////        foreach (var item in adj[node])
////        {
////            if (explored[item] == 0)
////            {
////                if (DFS(item, explored, adj, pathVisited))
////                {
////                    return true;
////                }
////            }
////            else if (pathVisited[item] != 0)
////            {
////                return true;
////            }
////        }

////        pathVisited[node] = 0;
////        return false;
////    }
////}
////#endregion

//#region BFS with Topo sort
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

//    public void AddEdge(int src, int dest)
//    {
//        adj[src].Add(dest);
//    }
//}
//public class Solution
//{
//    public bool CanFinish(int numCourses, int[][] prerequisites)
//    {
//        if (numCourses == 1)
//        {
//            return true;
//        }

//        Graph g = new Graph(numCourses);

//        for (int i = 0; i < prerequisites.Length; i++)
//        {
//            g.AddEdge(prerequisites[i][1], prerequisites[i][0]);
//        }
//        int[] indegree = new int[numCourses];

//        for (int i = 0; i < g.v; i++)
//        {
//            foreach (var item in g.adj[i])
//            {
//                indegree[item]++;
//            }
//        }

//        Queue<int> q = new Queue<int>();

//        for (int i = 0; i < g.v; i++)
//        {
//            if (indegree[i] == 0)
//            {
//                q.Enqueue(i);
//            }
//        }

//        int count = 0;

//        while (q.Count > 0)
//        {
//            int temp = q.Dequeue();

//            count++;

//            foreach (var item in g.adj[temp])
//            {
//                indegree[item]--;

//                if (indegree[item] == 0)
//                {
//                    q.Enqueue(item);
//                }
//            }
//        }

//        return count == numCourses;
//    }
//}
//#endregion
//class Program
//{
//    public static void Main()
//    {
//        int[][] prerequisites = new int[][] {
//            new int[] {1,0},
//             new int[] {0,1}
//                   };

//        Solution s = new Solution();
//        Console.WriteLine(s.CanFinish(2, prerequisites));
//    }
//}

////Time Complexity: O(V + E), where V is the number of vertices and E is the number of edges.
////Auxiliary Space: O(V + E)