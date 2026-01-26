
//class Graph
//{
//    private int _vertices;
//    private List<int>[] _adjMatrix;

//    public Graph(int vertices)
//    {
//        _vertices = vertices;
//        _adjMatrix = new List<int>[_vertices];

//        for (int i = 0; i < _vertices; i++)
//        {
//            _adjMatrix[i] = new List<int>();
//        }
//    }

//    public void AddEdge(int source, int destination)
//    {
//        _adjMatrix[source].Add(destination);
//    }

//    public void PrintGraph()
//    {
//        for (int i = 0; i < _vertices; i++)
//        {
//            Console.Write($"{i} => ");
//            foreach (var neightBors in _adjMatrix[i])
//            {
//                Console.Write($"{neightBors} , ");
//            }
//            Console.WriteLine();
//        }
//    }
//}

//class Program
//{
//    public static void Main()
//    {
//        Graph g = new Graph(5);

//        g.AddEdge(0, 1);
//        g.AddEdge(0, 4);
//        g.AddEdge(1, 2);
//        g.AddEdge(1, 3);
//        g.AddEdge(1, 4);
//        g.AddEdge(2, 3);
//        g.AddEdge(3, 4);

//        g.PrintGraph();

//    }

//}

//// Complexity : O(V+E) : Space