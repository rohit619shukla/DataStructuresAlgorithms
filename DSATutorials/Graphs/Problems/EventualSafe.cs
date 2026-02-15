//using System.Xml.Linq;

//public class Solution
//{

//    public IList<int> EventualSafeNodes(int[][] graph)
//    {
//        int vertices = graph.Length;

//        List<int> result = new List<int>();

//        List<int>[] adjList = new List<int>[vertices];

//        for (int i = 0; i < vertices; i++)
//        {
//            adjList[i] = new List<int>();
//        }

//        for (int i = 0; i < vertices; i++)
//        {
//            int[] currentRow = graph[i];

//            foreach (var neigh in currentRow)
//            {
//                AddEgde(i, neigh, adjList);
//            }
//        }

//        bool[] visited = new bool[vertices];
//        bool[] pathVisited = new bool[vertices];

//        for (int i = 0; i < vertices; i++)
//        {
//            if (visited[i] == false)
//            {
//                if (DFS(i, adjList, visited, pathVisited))
//                {
//                    continue;
//                }
//            }
//        }

//        // Idea is any node which is not part the cycle will eventually lead to a terminal node
//        for (int i = 0; i < vertices; i++)
//        {
//            if (pathVisited[i] == false)
//            {
//                result.Add(i);
//            }
//        }

//        return result;
//    }

//    private bool DFS(int node, List<int>[] adjList, bool[] visited, bool[] pathVisited)
//    {
//        visited[node] = true;
//        pathVisited[node] = true;

//        foreach (var neigbor in adjList[node])
//        {
//            if (visited[neigbor] == false)
//            {
//                if (DFS(neigbor, adjList, visited, pathVisited))
//                {
//                    return true;
//                }
//            }
//            else if (pathVisited[neigbor] == true)
//            {
//                // cycle exist
//                return true;
//            }
//        }


//        // backtrack
//        pathVisited[node] = false;

//        return false;
//    }

//    private void AddEgde(int src, int dest, List<int>[] adjList)
//    {
//        adjList[src].Add(dest);
//    }
//}

//class Program
//{
//    public static void Main()
//    {
//        int[][] graph = {
//            new int[] { 1,2},
//            new int[] {2,3 },
//            new int[] { 5},
//            new int[] { 0},
//            new int[] { 5},
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