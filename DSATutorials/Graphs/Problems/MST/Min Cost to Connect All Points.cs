public class Solution
{
    public int MinCostConnectPoints(int[][] points)
    {
        // Hint : Since we have been asked to connect all points in plane with minimum cost, hence this is MST problem

        // NOTE : Each point [x, y] is ONE node in the graph. We identify a node by its
        // index in the points array (0..n-1), NOT by the individual x or y number.
        // So n points => n nodes. The edge weight between node i and node j is the
        // Manhattan distance between point i and point j.

        // Step 1 : Create Adjacency list to store the edges and weights
        int n = points.Length;   // n = number of points = number of nodes

        List<int[]>[] adjList = new List<int[]>[n];

        for (int i = 0; i < n; i++)
        {
            adjList[i] = new List<int[]>();
        }

        // Step 2 : start filling them 

        for (int i = 0; i < n; i++)         // i = index of first point (a node)
        {
            for (int j = i + 1; j < n; j++)  // j = index of second point (another node)
            {
                int x1 = points[i][0];
                int y1 = points[i][1];

                int x2 = points[j][0];
                int y2 = points[j][1];

                // Manhattan distance between point i and point j = edge weight
                int weight = Math.Abs(x1 - x2) + Math.Abs(y1 - y2);

                // Step 3 : Create undirected graph (edge i <-> j with this weight)
                AddEdge(i, j, weight, adjList);
            }
        }

        // Step 4 : Apply Prims Algorithm
        PriorityQueue<int, int> pq = new PriorityQueue<int, int>();

        bool[] visited = new bool[n];

        int result = 0;

        pq.Enqueue(0, 0);

        while (pq.Count > 0)
        {
            pq.TryDequeue(out int currentNode, out int weight);

            if (visited[currentNode] == true)
            {
                continue;
            }

            visited[currentNode] = true;
            result += weight;

            foreach (var neighbors in adjList[currentNode])
            {
                if (visited[neighbors[0]] == false)
                {
                    pq.Enqueue(neighbors[0], neighbors[1]);
                }
            }
        }

        return result;
    }

    private void AddEdge(int src, int dest, int weight, List<int[]>[] adjList)
    {
        adjList[src].Add(new int[] { dest, weight });
        adjList[dest].Add(new int[] { src, weight });
    }
}


class Program
{
    public static void Main()
    {
        int[][] points = {
            new int[] { 0,0},
            new int[] { 2,2},
            new int[] { 3,10},
            new int[] { 5,2},
            new int[]{ 7,0}
        };

        Solution s = new Solution();

        Console.WriteLine(s.MinCostConnectPoints(points));
    }
}


// Let V = number of points (nodes), E = number of edges.
// Since every pair of points is connected, the graph is DENSE: E = V*(V-1)/2 = O(V^2).
//
// Time  : O(V^2 + E log E) = O(V^2 + V^2 log V^2) = O(V^2 log V)
//   - O(V^2)        : building the adjacency list (nested loop over all pairs).
//   - O(E log E)    : Prim's with a priority queue. We may push up to E edges, and the
//                     PQ holds O(E) = O(V^2) entries, so each op costs log(V^2) = 2 log V.
//                     => V^2 * log(V^2) = O(V^2 log V).
//
// Space : O(V + E) = O(V^2)
//   - Adjacency list stores all edges (O(E) = O(V^2)) plus the PQ/visited arrays (O(V)).
//   - For a dense graph this is dominated by O(V^2).
//
// Your stated complexity O(V^2 + V^2 log V^2) is CORRECT; it just simplifies to
// O(V^2 log V) since log V^2 = 2 log V. Space O(V+E) is also correct (= O(V^2) here).