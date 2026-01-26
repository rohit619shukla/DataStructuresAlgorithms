
//class Graph
//{
//    private int _vertices;
//    private List<int[]>[] _adjList;

//    public Graph(int vertices)
//    {
//        _vertices = vertices;
//        _adjList = new List<int[]>[_vertices];

//        for (int i = 0; i < _vertices; i++)
//        {
//            _adjList[i] = new List<int[]>();
//        }
//    }

//    public void AddEdge(int source, int destination, int weight)
//    {
//        _adjList[source].Add(new int[] { destination, weight });
//        _adjList[destination].Add(new int[] { source, weight });
//    }

//    public void Solve(int startNode)
//    {
//        // Declare a PQ
//        PriorityQueue<int, int> pq = new PriorityQueue<int, int>();

//        // create a distance array to keep track
//        int[] result = new int[_vertices];

//        // All the vertices will have the distance as Max
//        for (int i = 0; i < _vertices; i++)
//        {
//            result[i] = int.MaxValue;
//        }


//        // Add the start node to the queue
//        pq.Enqueue(startNode, 0);

//        // The distance of the sourceNode will be 0
//        result[startNode] = 0;

//        // start the algorithm
//        while (pq.Count > 0)
//        {
//            // get the current min priority node from PQ
//            if (!pq.TryDequeue(out int currentNode, out int distance)) continue;
//
//            if(result[currentNode] < distance) continue; this guarantees thst V+E you were confused about in BFS or lese you will again explore the path

//            // Explore the neighbors
//            foreach (int[] neighbour in _adjList[currentNode])
//            {
//                int neighbourNode = neighbour[0];
//                int neighbourWeight = neighbour[1];

//                // perform relaxation
//                if (distance + neighbourWeight < result[neighbourNode])
//                {
//                    result[neighbourNode] = distance + neighbourWeight;
//                    pq.Enqueue(neighbourNode, result[neighbourNode]);
//                }
//            }
//        }

//        for (int i = 0; i < result.Length; i++)
//        {
//            Console.WriteLine($"{startNode} - >  {result[i]}");
//        }
//    }
//}

//class Program
//{
//    public static void Main()
//    {
//        Graph g = new Graph(5);

//        g.AddEdge(0, 1, 4);
//        g.AddEdge(0, 2, 8);
//        g.AddEdge(1, 2, 3);
//        g.AddEdge(1, 4, 6);
//        g.AddEdge(2, 3, 2);
//        g.AddEdge(4, 3, 10);


//        g.Solve(0);

//    }
//}

//// Time :VLogV+ELogV, space :O(V+E) , for PQ its just E