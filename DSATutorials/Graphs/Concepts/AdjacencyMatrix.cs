
//class Graph
//{
//    private int vertices;
//    private int[,] adjMatrix;

//    public Graph(int vert)
//    {
//        vertices = vert;
//        adjMatrix = new int[vertices, vertices];
//    }

//    public void AddEdge(int source, int dest)
//    {
//        adjMatrix[source, dest] = 1;
//        adjMatrix[dest, source] = 1;
//    }

//    public void PrintGraph()
//    {
//        int rows = adjMatrix.GetLength(0);
//        int cols = adjMatrix.GetLength(1);

//        for (int i = 0; i < rows; i++)
//        {
//            for (int j = 0; j < cols; j++)
//            {
//                Console.Write($"{adjMatrix[i, j]}" + " ");
//            }
//            Console.WriteLine();
//        }
//    }
//}

//class Program
//{
//    public static void Main()
//    {
//        Graph g = new Graph(4);

//        g.AddEdge(0, 1);
//        g.AddEdge(0, 2);
//        g.AddEdge(1, 2);
//        g.AddEdge(2, 3);

//        g.PrintGraph();

//    }
//}

//// Complexity : O(V*E)