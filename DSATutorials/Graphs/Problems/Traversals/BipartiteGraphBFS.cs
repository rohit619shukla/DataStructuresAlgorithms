//public class Solution
//{

//    public bool IsBipartite(int[][] graph)
//    {
//        int rows = graph.Length;

//        int[] color = new int[rows];

//        Array.Fill(color, -1);

//        // Create adjlist
//        List<int>[] adjList = new List<int>[rows];

//        for (int i = 0; i < rows; i++)
//        {
//            adjList[i] = new List<int>();


//        }

//        for (int i = 0; i < rows; i++)
//        {
//            for (int j = 0; j < graph[i].Length; j++)
//            {
//                AddEdge(i, graph[i][j], adjList);
//            }
//        }

//        for (int i = 0; i < rows; i++)
//        {
//            if (color[i] == -1)
//            {
//                if (!BFS(adjList, color, i))
//                {
//                    return false;
//                }

//            }
//        }
//        return true;
//    }

//    private void AddEdge(int source, int dest, List<int>[] adjList)
//    {
//        adjList[source].Add(dest);
//    }


//    private bool BFS(List<int>[] adjList, int[] color, int startNode)
//    {

//        Queue<int> q = new Queue<int>();

//        // Add the start node ot queue
//        q.Enqueue(startNode);

//        // Mark the color to something : 0 / 1
//        color[startNode] = 0;

//        while (q.Count > 0)
//        {
//            int currentNode = q.Dequeue();

//            foreach (var neighbours in adjList[currentNode])
//            {
//                // Color the node if not visited
//                if (color[neighbours] == -1)
//                {
//                    color[neighbours] = 1 - color[currentNode];
//                    q.Enqueue(neighbours);
//                }
//                else if (color[neighbours] == color[currentNode])
//                {
//                    return false;
//                }
//            }
//        }

//        return true;
//    }
//}


//class Program
//{
//    public static void Main()
//    {
//        int[][] graph = {
//             new int[] {1,3},
//             new int[] {0,2 },
//             new int []{1,3 },
//             new int []{0,2 },
//        };

//        Solution s = new Solution();
//        Console.WriteLine(s.IsBipartite(graph));
//    }
//}

//// Time : (V+E), space : O(V+E)  , since this is jagged array we already have each node and its adj nodes next to it