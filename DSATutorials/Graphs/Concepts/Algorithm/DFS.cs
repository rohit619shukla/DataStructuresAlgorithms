
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

//    public void DFS()
//    {
//        // create a visited array
//        int[] visited = new int[_vertices];

//        Solve(0, visited);
//    }

//    private void Solve(int currentNode, int[] visited)
//    {

//        // Mark it as visited
//        visited[currentNode] = 1;

//        // Print it
//        Console.Write($"{currentNode}" + " ");

//        // Apply DFS
//        foreach (int neighbor in _adjList[currentNode])
//        {
//            if (visited[neighbor] == 0)
//            {
//                Solve(neighbor, visited);
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

//        g.DFS();
//    }
//}


//// Time : O(V+E)
//// Aux : O(2V) for visited and recursive stack, and Actual space : O(V+E) for adjlist