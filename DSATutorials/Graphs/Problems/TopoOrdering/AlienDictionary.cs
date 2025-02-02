

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

//    public void AddEdge(int source, int destination)
//    {
//        adj[source].Add(destination);
//    }

//    public void AlienDictionary(string[] arr, int n, int k)
//    {
//        // Iterate over each word in dictionary and try creating a DAG
//        // We will do n-1 comprison because we are doing the comaprison in pairs
//        for (int i = 0; i < n - 1; i++)
//        {
//            string str1 = arr[i];
//            string str2 = arr[i + 1]; // next in sequence

//            // Which ever is smaller we will compare
//            int len = Math.Min(str1.Length, str2.Length);

//            for (int j = 0; j < len; j++)
//            {
//                if (str1[j] != str2[j])
//                {
//                    // Create DAG
//                    AddEdge(str1[j] - 'a', str2[j] - 'a');
//                    break;
//                }
//            }
//        }


//        int[] visited = new int[k];

//        // start DFS for ordering using Topo sort and here we will store the node in 0 based numeric indexing

//        Stack<int> st = new Stack<int>();

//        for (int i = 0; i < k; i++)
//        {
//            if (visited[i] == 0)
//            {
//                DFS(i, st, visited);
//            }
//        }

//        // Now print the numbers back to char format
//        while (st.Count > 0)
//        {
//            Console.Write($"{(char)(st.Pop() + 'a')}" + " ");
//        }
//    }

//    private void DFS(int node, Stack<int> st, int[] visited)
//    {
//        visited[node] = 1;

//        foreach (var neigh in adj[node])
//        {
//            if (visited[neigh] == 0)
//            {
//                DFS(neigh, st, visited);
//            }
//        }

//        st.Push(node);
//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        string[] arr = { "baa", "abcd", "abca", "cab", "cad" };
//        int k = 4;
//        int N = 5;
//        Graph g = new Graph(k);
//        g.AlienDictionary(arr, N, k);
//    }
//}


//// O(N*len)+O(K+E), where N is the number of words in the dictionary, ‘len’ is the length up to the index where the first inequality occurs, K = no. of nodes, and E = no. of edges.
//// Space : O(N)