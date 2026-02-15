
//using System.ComponentModel.DataAnnotations;

//class Solution
//{
//    private int _vertices;
//    private List<int>[] _adjList;

//    public Solution(int vertices)
//    {
//        _vertices = vertices;
//        _adjList = new List<int>[vertices];

//        for (int i = 0; i < _vertices; i++)
//        {
//            _adjList[i] = new List<int>();
//        }
//    }

//    public void AddEdge(int src, int dest)
//    {
//        _adjList[src].Add(dest);
//    }

//    public void TopoSortBFS()
//    {
//        // Create indegree for the vertex in graph
//        int[] indegree = new int[_vertices];

//        for (int i = 0; i < _vertices; i++)
//        {
//            foreach (var neighbor in _adjList[i])
//            {
//                indegree[neighbor]++;
//            }
//        }

//        Queue<int> q = new Queue<int>();

//        // All nodes with indegree 0 will be put in the q
//        for (int i = 0; i < indegree.Length; i++)
//        {
//            if (indegree[i] == 0)
//            {
//                q.Enqueue(i);
//            }
//        }

//        while (q.Count > 0)
//        {
//            int node = q.Dequeue();

//            Console.WriteLine($"{node}" + " ");


//            foreach (var neighbour in _adjList[node])
//            {
//                indegree[neighbour]--;
//                if (indegree[neighbour] == 0)
//                {
//                    q.Enqueue(neighbour);
//                }
//            }

//        }
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

//        g.TopoSortBFS();
//    }
//}