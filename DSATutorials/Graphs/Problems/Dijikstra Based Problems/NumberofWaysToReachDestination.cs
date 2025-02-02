////Leetcode 1976. (Medium)

//class Node
//{
//    public int nodeVal;
//    public long nodeWeight;

//    public Node(int val, long weight)
//    {
//        nodeVal = val;
//        nodeWeight = weight;
//    }
//}

//class Graph
//{
//    private int v;
//    public List<int[]>[] adj;

//    public Graph(int vertices)
//    {
//        v = vertices;
//        adj = new List<int[]>[v];

//        for (int i = 0; i < v; i++)
//        {
//            adj[i] = new List<int[]>();
//        }
//    }

//    public void AddEdge(int source, int destination, int weight)
//    {
//        adj[source].Add(new int[] { destination, weight });
//        adj[destination].Add(new int[] { source, weight });
//    }
//}

//class Solution
//{
//    public int CountPaths(int n, int[][] roads)
//    {
//        int rows = roads.Length;

//        // create 2 arrays to store distance covered and ways
//        long[] distance = new long[n];
//        int[] ways = new int[n];


//        // assign intial values to the arrays
//        for (int i = 0; i < n; i++)
//        {
//            distance[i] = long.MaxValue;
//        }

//        // Number of ways to reach destination from node itself is 1
//        ways[0] = 1;
//        distance[0] = 0;

//        // Add Edges to adjacency list
//        Graph g = new Graph(n);

//        for (int i = 0; i < rows; i++)
//        {
//            g.AddEdge(roads[i][0], roads[i][1], roads[i][2]);
//        }

//        // Create a Priority Queue
//        Node startNode = new Node(0, 0);
//        SortedSet<Node> pq = new SortedSet<Node>(new DistanceComparer());

//        // Add start node to queue
//        pq.Add(startNode);

//        // create mod value
//        int mod = (int)1e9 + 7;


//        // start dijkstra
//        while (pq.Count > 0)
//        {
//            Node nodeArr = pq.Min;
//            pq.Remove(nodeArr);

//            int currNode = nodeArr.nodeVal;
//            long currNodeWeight = nodeArr.nodeWeight;

//            // start exploring adjacent nodes from start node
//            foreach (var neigh in g.adj[currNode])
//            {
//                int destNode = neigh[0];
//                int destWeight = neigh[1];

//                // We will add to pq only if we get less weighted values
//                if (currNodeWeight + destWeight < distance[destNode])
//                {
//                    distance[destNode] = currNodeWeight + destWeight;
//                    ways[destNode] = (ways[currNode]) % mod;     // Since we are reaching this node for firts time, hence simply copy source node's distance
//                    pq.Add(new Node(destNode, currNodeWeight + destWeight));
//                } // no point of adding to pq if we get same weight for the node simply update the ways
//                else if (currNodeWeight + destWeight == distance[destNode])
//                {
//                    ways[destNode] = (ways[destNode] + ways[currNode]) % mod;
//                }
//            }
//        }

//        return ways[n - 1];
//    }
//}

//internal class DistanceComparer : IComparer<Node>
//{
//    public int Compare(Node n1, Node n2)
//    {
//        if (n1.nodeWeight != n2.nodeWeight)
//        {
//            return n1.nodeWeight.CompareTo(n2.nodeWeight);
//        }

//        return n1.nodeVal.CompareTo(n2.nodeVal);
//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        Solution s = new Solution();

//        int[][] roads = new int[][] {
//        new int[] { 0,6,7},
//        new int[] {0,1,2 },
//        new int[] {1,2,3 },
//        new int[] {1,3,3 },
//        new int[] { 6,3,3},
//        new int[] {3,5,1 },
//        new int[] { 6,5,1},
//        new int[] {2,5,1},
//        new int[] {0,4,5},
//        new int[] {4,6,2}
//        };

//        int n = 7;

//        Console.WriteLine(s.CountPaths(n, roads));
//    }
//}


//// Time : O((V + E) log V)