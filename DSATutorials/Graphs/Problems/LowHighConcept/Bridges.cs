//public class Solution
//{
//    private int timer;

//    public IList<IList<int>> CriticalConnections(int n, IList<IList<int>> connections)
//    {
//        IList<IList<int>> result = new List<IList<int>>();

//        // step 1: need to create AdjList
//        List<int>[] adjList = new List<int>[n];
//        for (int i = 0; i < n; i++)
//        {
//            adjList[i] = new List<int>();
//        }

//        for (int i = 0; i < connections.Count; i++)
//        {
//            AddEdges(connections[i][0], connections[i][1], adjList);
//        }

//        // Step 2: Create visited, discovery and low array
//        bool[] visited = new bool[n];
//        int[] disc = new int[n];
//        int[] low = new int[n];


//        // Step 3 : start DFS
//        DFS(0, -1, adjList, disc, low, visited, result);

//        return result;
//    }

//    private void AddEdges(int src, int dest, List<int>[] adjList)
//    {
//        adjList[src].Add(dest);
//        adjList[dest].Add(src);
//    }

//    private void DFS(int currentNode, int parentNode, List<int>[] adjList, int[] disc, int[] low, bool[] visited, IList<IList<int>> result)
//    {
//        // Need to mark the current node as visited
//        visited[currentNode] = true;

//        // increase the timer
//        disc[currentNode] = low[currentNode] = ++timer;

//        foreach (var neighNode in adjList[currentNode])
//        {
//            // if the neightNode is the parent for currentNode, no need to do anything
//            if (neighNode == parentNode)
//            {
//                continue;
//            }

//            if (!visited[neighNode])
//            {
//                // Move deeper
//                DFS(neighNode, currentNode, adjList, disc, low, visited, result);

//                // While retruning we need to update the low. As there might be a child node in the path below who might have found aother better way to reach a node via backedge
//                low[currentNode] = Math.Min(low[currentNode], low[neighNode]);

//                // check for bridge
//                if (disc[currentNode] < low[neighNode])
//                {
//                    result.Add(new List<int> { currentNode, neighNode });
//                }
//            }
//            else
//            {
//                // We found a backedge and another way so see if this is better
//                low[currentNode] = Math.Min(low[currentNode], disc[neighNode]);
//            }
//        }
//    }
//}

//class Program
//{
//    public static void Main()
//    {
//        IList<IList<int>> connections = new List<IList<int>>();
//        connections.Add(new List<int> { 0, 1 });
//        connections.Add(new List<int> { 1, 2 });
//        connections.Add(new List<int> { 2, 0 });
//        connections.Add(new List<int> { 1, 3 });

//        Solution s = new Solution();

//        var result = s.CriticalConnections(4, connections);

//        foreach (var con in result)
//        {
//            foreach (var nodes in con)
//            {
//                Console.Write($"{nodes}" + " ");
//            }
//        }
//    }
//}

//// Time : O(V+E), space : O(V+E)