
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
//        adj[dest].Add(source);
//    }
//}
//public class Solution
//{
//    public static int Timer = 0;
//    public IList<IList<int>> CriticalConnections(int n, IList<IList<int>> connections)
//    {
//        IList<IList<int>> result = new List<IList<int>>();

//        Graph g = new Graph(n);

//        // Create adjacency list graph
//        for (int i = 0; i < connections.Count; i++)
//        {
//            g.AddEdge(connections[i][0], connections[i][1]);
//        }

//        int[] disc = new int[n];
//        int[] low = new int[n];
//        int[] explored = new int[n];

//        // Start DFS from any node
//        DFS(0, -1, explored, disc, low, g.adj, result);

//        return result;
//    }

//    private void DFS(int currentNode, int parentNode, int[] explored, int[] disc, int[] low, List<int>[] adj, IList<IList<int>> result)
//    {
//        // mark the node as visited
//        explored[currentNode] = 1;

//        // Update low and disc for the node
//        disc[currentNode] = low[currentNode] = ++Timer;

//        // explore adjacent node
//        foreach (var neighNode in adj[currentNode])
//        {
//            // if the neigh node is parent of the current node
//            if (neighNode == parentNode)
//            {
//                continue;
//            }

//            if (explored[neighNode] == 0)
//            {
//                // Mode next node
//                DFS(neighNode, currentNode, explored, disc, low, adj, result);

//                // backtracking
//                low[currentNode] = Math.Min(low[currentNode], low[neighNode]);

//                // bridge detection
//                if (low[neighNode] > disc[currentNode])
//                {
//                    result.Add(new List<int> { currentNode, neighNode });
//                }
//            }
//            else
//            {
//                low[currentNode] = Math.Min(low[currentNode], low[neighNode]);
//            }
//        }
//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        int n = 2;
//        IList<IList<int>> connections = new List<IList<int>>();
//        connections.Add(new List<int> { 0, 1 });
//        //connections.Add(new List<int> { 1, 2 });
//        //connections.Add(new List<int> { 2, 0 });
//        //connections.Add(new List<int> { 0, 3 });
//        //connections.Add(new List<int> { 3, 4 });

//        Solution s = new Solution();

//        var result = s.CriticalConnections(n, connections);

//        foreach (var item in result)
//        {
//            foreach (var con in item)
//            {
//                Console.Write($"{con}" + " ");
//            }
//            Console.WriteLine();
//        }
//    }
//}

////Time Complexity: O(V + E), 

////The above approach uses simple DFS along with Tarjan’s Algorithm. 
////So time complexity is the same as DFS which is O(V+E) for adjacency list representation of the graph.
////Auxiliary Space: O(V) is used for visited, disc and low arrays.