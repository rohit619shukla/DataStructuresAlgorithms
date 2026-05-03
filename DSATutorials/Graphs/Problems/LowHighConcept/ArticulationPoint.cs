//class Solution
//{
//    private int timer;

//    public List<int> ArticulationPoints(int V, List<int>[] adj)
//    {
//        List<int> result = new List<int>();

//        // Step 1: Create visited, disc and low arrays
//        int[] disc = new int[V];
//        int[] low = new int[V];
//        bool[] visited = new bool[V];

//        DFS(0, -1, adj, result, disc, low, visited);

//        return result;
//    }

//    private void DFS(int currentNode, int parentNode, List<int>[] adjList, List<int> result, int[] disc, int[] low, bool[] visited)
//    {
//        int children = 0;

//        // Mark the currentNode as visited
//        visited[currentNode] = true;

//        disc[currentNode] = low[currentNode] = ++timer;


//        foreach (var neighNode in adjList[currentNode])
//        {
//            if (neighNode == parentNode)
//            {
//                continue;
//            }


//            if (!visited[neighNode])
//            {
//                children++;
//                // Go deeper
//                DFS(neighNode, currentNode, adjList, result, disc, low, visited);

//                //While returning check for low
//                low[currentNode] = Math.Min(low[currentNode], low[neighNode]);

//                if (parentNode == -1 && children > 1)
//                {
//                    result.Add(currentNode);
//                }

//                if (parentNode != -1 && disc[currentNode] <= low[neighNode])
//                {
//                    result.Add(currentNode);
//                }


//            }
//            else
//            {
//                low[currentNode] = Math.Min(low[currentNode], disc[neighNode]);
//            }
//        }

//    }
//}

//public class Program
//{
//    public static void Main()
//    {
//        int n = 5;

//        List<int>[] adj = new List<int>[n];

//        for (int i = 0; i < n; i++)
//        {
//            adj[i] = new List<int>();
//        }

//        adj[0].Add(1);
//        adj[1].Add(0);
//        adj[1].Add(4);
//        adj[4].Add(1);
//        adj[3].Add(4);
//        adj[4].Add(3);
//        adj[3].Add(2);
//        adj[2].Add(3);
//        adj[4].Add(2);
//        adj[2].Add(4);

//        Solution s = new Solution();

//        var result = s.ArticulationPoints(n, adj);

//        foreach (var node in result)
//        {
//            Console.Write($"{node}" + " ");
//        }
//    }
//}