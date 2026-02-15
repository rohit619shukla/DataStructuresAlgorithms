

//class Solution
//{

//    private int _vertices;
//    private List<int>[] _adjList;


//    public Solution(int vertices)
//    {
//        _vertices = vertices;
//        _adjList = new List<int>[vertices];

//        for (int i = 0; i < vertices; i++)
//        {
//            _adjList[i] = new List<int>();
//        }
//    }

//    public void AddEdge(int sr, int dest)
//    {
//        _adjList[sr].Add(dest);
//    }

//    public void TopoSortDFS()
//    {
//        Stack<int> st = new Stack<int>();

//        bool[] visited = new bool[_vertices];

//        for (int i = 0; i < _vertices; i++)
//        {
//            if (visited[i] == false)
//            {
//                DFS(visited, i, _adjList, st);
//            }
//        }

//        while (st.Count > 0)
//        {
//            Console.Write($"{st.Peek()}" +" ");
//            st.Pop();
//        }
//    }

//    private void DFS(bool[] visited, int node, List<int>[] _adjList, Stack<int> st)
//    {
//        visited[node] = true;

//        foreach (var neighbors in _adjList[node])
//        {
//            if (visited[neighbors] == false)
//            {
//                DFS(visited, neighbors, _adjList, st);
//            }
//        }

//        // The moment you cant go any more further put it in stack
//        st.Push(node);
//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        Solution g = new Solution(6);
//        g.AddEdge(5, 2);
//        g.AddEdge(5, 0);
//        g.AddEdge(4, 0);
//        g.AddEdge(4, 1);
//        g.AddEdge(2, 3);
//        g.AddEdge(3, 1);

//        g.TopoSortDFS();
//    }
//}

//// Time  : O(V+E)