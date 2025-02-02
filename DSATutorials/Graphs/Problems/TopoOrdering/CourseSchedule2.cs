
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

////#region DFS
////public class Solution
////{
////    public int[] FindOrder(int numCourses, int[][] prerequisites)
////    {
////        // Add edges
////        Graph g = new Graph(numCourses);

////        for (int i = 0; i < prerequisites.Length; i++)
////        {
////            g.AddEdge(prerequisites[i][1], prerequisites[i][0]);
////        }

////        int[] result = new int[numCourses];
////        int[] explored = new int[numCourses];
////        int[] pathVisited = new int[numCourses];

////        Stack<int> st = new Stack<int>();

////        for (int i = 0; i < g.v; i++)
////        {
////            if (explored[i] == 0)
////            {
////                if (DFS(i, explored, st, g.adj, pathVisited))
////                {
////                    return Array.Empty<int>();
////                }
////            }
////        }

////        List<int> finalList = new List<int>();

////        while (st.Count > 0)
////        {
////            finalList.Add(st.Pop());
////        }

////        return finalList.ToArray();
////    }

////    private bool DFS(int node, int[] explored, Stack<int> st, List<int>[] adj, int[] pathVisited)
////    {
////        explored[node] = 1;
////        pathVisited[node] = 1;

////        foreach (var item in adj[node])
////        {
////            if (explored[item] == 0)
////            {
////                if (DFS(item, explored, st, adj, pathVisited))
////                {
////                    return true;
////                }
////            }
////            else if (pathVisited[item] != 0)
////            {
////                return true;
////            }
////        }

////        st.Push(node);
////        pathVisited[node] = 0;
////        return false;
////    }
////}
////#endregion

//#region BFS
////public class Solution
////{
////    public int[] FindOrder(int numCourses, int[][] prerequisites)
////    {
////        int rows = prerequisites.Length;

////        Graph g = new Graph(numCourses);

////        for (int i = 0; i < rows; i++)
////        {
////            g.AddEdge(prerequisites[i][0], prerequisites[i][1]);
////        }

////        Queue<int> q = new Queue<int>();

////        int[] indegree = new int[numCourses];

////        for (int j = 0; j < numCourses; j++)
////        {
////            foreach (var neigh in g.adj[j])
////            {
////                indegree[neigh]++;
////            }
////        }

////        for (int x = 0; x < numCourses; x++)
////        {
////            if (indegree[x] == 0)
////            {
////                q.Enqueue(x);
////            }
////        }

////        List<int> lst = new List<int>();
////        int[] result = new int[numCourses];

////        while (q.Count > 0)
////        {
////            int node = q.Dequeue();

////            lst.Add(node);

////            foreach (var neigh in g.adj[node])
////            {
////                indegree[neigh]--;

////                if (indegree[neigh] == 0)
////                {
////                    q.Enqueue(neigh);
////                }
////            }
////        }


////        if (lst.Count != numCourses)
////        {
////            return Array.Empty<int>();
////        }
////        else
////        {
////            int k = 0;
////            foreach (var item in lst)
////            {
////                result[k] = item;
////                k++;
////            }
////        }

////        return result;
////    }
////}
//#endregion
////class Program
////{
////    public static void Main()
////    {
////        int numCourses = 3;
////        int[][] prerequisites = new int[][] {
////                    new int[] { 1,0},
////                    new int[]{1,2 }
////                    //new int[] { 0,1}
////                 };


////        Solution s = new Solution();
////        var result = s.FindOrder(numCourses, prerequisites);

////        foreach (var item in result)
////        {
////            Console.Write($"{item}" + " ");
////        }
////    }
////}


// Time : O(V+E)