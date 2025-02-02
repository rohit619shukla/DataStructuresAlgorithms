

//using DS_Tutorials.Linked_list.Types;

//class Graph
//{
//    private int v;
//    private List<int>[] adj;

//    public Graph(int vertices)
//    {
//        v = vertices;
//        adj = new List<int>[v];

//        for (int i = 0; i < v; i++)
//        {
//            adj[i] = new List<int>();
//        }
//    }

//    public void AddEdge(int source, int dest)
//    {
//        adj[source].Add(dest);
//    }

//    public void TopologicalSort()
//    {
//        // Topo sort is only for Directed acyclic graph since u should always come before v

//        int[] visited = new int[v];

//        Stack<int> st = new Stack<int>();

//        // Start DFS
//        for (int i = 0; i < v; i++)
//        {
//            if (visited[i] == 0)
//            {
//                DFS(visited, i, st);
//            }
//        }

//        while (st.Count > 0)
//        {
//            Console.Write($"{st.Pop()}" + " ");
//        }
//    }

//    private void DFS(int[] visited, int node, Stack<int> st)
//    {
//        // mark the node as visited
//        visited[node] = 1;

//        // Explore adjacent nodes
//        foreach (var neigh in adj[node])
//        {
//            if (visited[neigh] == 0)
//            {
//                DFS(visited, neigh, st);
//            }
//        }

//        // once a node has been explored we can add it to the stack
//        st.Push(node);
//    }
//}

//class Program
//{
//    public static void Main()
//    {
//        Graph g = new Graph(6);
//        g.AddEdge(5, 2);
//        g.AddEdge(5, 0);
//        g.AddEdge(4, 0);
//        g.AddEdge(4, 1);
//        g.AddEdge(2, 3);
//        g.AddEdge(3, 1);

//        Console.WriteLine(
//          "Following is a Topological Sort of");
//        g.TopologicalSort();
//    }
//}

//Time Complexity: O(V + E).
//The outer for loop will be executed V number of times and the inner for loop will be executed E number of times.
//Auxiliary Space: O(V).
//The queue needs to store all the vertices of the graph. So the space required is O(V)