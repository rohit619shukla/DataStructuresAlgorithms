
//class Graph
//{
//    private int _vertices;
//    private int[,] _adjMatrix;

//    public Graph(int vertices)
//    {
//        _vertices = vertices;
//        _adjMatrix = new int[_vertices, _vertices];
//    }

//    public void AddEdge(int source, int destination, int weight)
//    {
//        _adjMatrix[source, destination] = weight;
//        _adjMatrix[destination, source] = weight;
//    }

//    public void PrintShorestPathFromSource(int startNode)
//    {
//        // create a distance array to keep track of distance
//        int[] distance = new int[_vertices];

//        // visisted array
//        int[] visited = new int[_vertices];

//        // Set the distance of all nodes to Max
//        for (int i = 0; i < _vertices; i++)
//        {
//            distance[i] = int.MaxValue;
//        }

//        // set distance for first Node as 0
//        distance[0] = 0;

//        // start algo
//        for (int i = 0; i < _vertices; i++)
//        {
//            // get the minvertex
//            int minVertex = FindMinVertex(visited, distance);

//            // mark this node as visisted
//            visited[minVertex] = 1;

//            // From minvertex explore all paths and realx them
//            for (int j = 0; j < _vertices; j++)
//            {
//                if (_adjMatrix[minVertex, j] != 0 && visited[j] == 0)
//                {
//                    // relaxation
//                    if (distance[minVertex] + _adjMatrix[minVertex, j] < distance[j])
//                    {
//                        distance[j] = distance[minVertex] + _adjMatrix[minVertex, j];
//                    }
//                }
//            }
//        }

//        for (int i = 0; i < _vertices; i++)
//        {
//            Console.WriteLine($"{startNode} - >  {i} => {distance[i]}");
//        }
//    }

//    private int FindMinVertex(int[] visited, int[] distance)
//    {
//        int minVertex = -1;

//        for (int i = 0; i < _vertices; i++)
//        {
//            if (visited[i] == 0 && (minVertex == -1 || distance[minVertex] > distance[i]))
//            {
//                minVertex = i;
//            }
//        }

//        return minVertex;
//    }
//}

//class Program
//{
//    public static void Main()
//    {
//        Graph g = new Graph(5);

//        g.AddEdge(0, 1, 4);
//        g.AddEdge(0, 2, 8);
//        g.AddEdge(1, 2, 2);
//        g.AddEdge(1, 3, 5);
//        g.AddEdge(2, 3, 5);
//        g.AddEdge(2, 4, 9);
//        g.AddEdge(3, 4, 4);

//        g.PrintShorestPathFromSource(0);
//    }

//}

//// Time Complexity : O(N^2) as outer lop is for N , then we have 2 independent loops of size N as well