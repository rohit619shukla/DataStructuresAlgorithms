//using Microsoft.Azure.Cosmos;
//using Microsoft.Azure.Cosmos.Serialization.HybridRow;

//class Solution
//{
//    private int _vertices;
//    private List<int[]>[] _adjList;

//    public Solution(int vertices)
//    {
//        _vertices = vertices;
//        _adjList = new List<int[]>[_vertices];

//        for (int i = 0; i < _vertices; i++)
//        {
//            _adjList[i] = new List<int[]>();
//        }
//    }

//    public void AddEdge(int source, int dest, int weight)
//    {
//        _adjList[source].Add(new int[] { dest, weight });
//        _adjList[dest].Add(new int[] { source, weight });
//    }

//    public void Prims(int sourceNode)
//    {
//        // The idea is to start with vertex with min weight and explore the connected weights with less size
//        // MST is basically a tree with V-1 edges

//        int result = 0;

//        // Create a visisted array
//        int[] visited = new int[_vertices];

//        // Keep track of Parent array
//        int[] parent = new int[_vertices];

//        Array.Fill(parent, -1);

//        PriorityQueue<int[], int> pq = new PriorityQueue<int[], int>();

//        pq.Enqueue(new int[] { 0, 0 }, 0);

//        while (pq.Count > 0)
//        {
//            if (!pq.TryDequeue(out int[] node, out int weight)) continue;

//            int currentNode = node[0];

//            if (visited[currentNode] != 0)
//            {
//                continue;
//            }

//            visited[currentNode] = 1;
//            result += weight;
//            parent[currentNode] = node[1];


//            foreach (var neighbors in _adjList[currentNode])
//            {
//                int neighborNode = neighbors[0];

//                if (visited[neighborNode] == 0)
//                {
//                    pq.Enqueue(new int[] { neighborNode, currentNode }, neighbors[1]);
//                }
//            }
//        }


//        for (int i = 0; i < _vertices; i++)
//        {
//            Console.WriteLine($"{i} - {parent[i]}");
//        }

//        Console.WriteLine($"Total cost is {result}");
//    }
//}

//class Program
//{
//    public static void Main()
//    {
//        Solution g = new Solution(5);

//        g.AddEdge(0, 1, 4);
//        g.AddEdge(0, 2, 8);
//        g.AddEdge(1, 3, 6);
//        g.AddEdge(1, 2, 2);
//        g.AddEdge(2, 3, 3);
//        g.AddEdge(2, 4, 9);
//        g.AddEdge(3, 4, 5);

//        g.Prims(0);

//    }
//}

//// Time : (V+E)LogE

