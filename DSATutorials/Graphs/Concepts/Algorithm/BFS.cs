
//class Graph
//{
//    private int _vertices;
//    private List<int>[] _adjList;

//    public Graph(int vertices)
//    {
//        _vertices = vertices;
//        _adjList = new List<int>[_vertices];

//        for (int i = 0; i < _vertices; i++)
//        {
//            _adjList[i] = new List<int>();
//        }
//    }

//    public void AddEdge(int source, int destination)
//    {
//        _adjList[source].Add(destination);
//        _adjList[destination].Add(source);
//    }

//    public void BFS()
//    {
//        // create a visisted array
//        int[] visited = new int[_vertices];

//        // Create a queue to store nodes
//        Queue<int> queue = new Queue<int>();

//        // Add the start node to the queue
//        queue.Enqueue(0);

//        // Mark the start node as visisted
//        visited[0] = 1;

//        // start BFS
//        while (queue.Count > 0)
//        {
//            // get the front node
//            int currentNode = queue.Dequeue();

//            Console.Write($"{currentNode}" + " ");

//            //Explore its neighbors
//            foreach (int neighbour in _adjList[currentNode])
//            {
//                // Only if the node is not visited
//                if (visited[neighbour] == 0)
//                {
//                    queue.Enqueue(neighbour);
//                    visited[neighbour] = 1;
//                }
//            }
//        }
//    }
//}

//class Program
//{
//    public static void Main()
//    {
//        Graph g = new Graph(5);

//        g.AddEdge(0, 2);
//        g.AddEdge(0, 3);
//        g.AddEdge(0, 1);
//        g.AddEdge(2, 4);

//        g.BFS();

//    }
//}

////Time Complexity: O(V + E), where V is the number of nodes and E is the number of edges.
////Auxiliary Space: O(V), total space : O(V+E) for creating adjList