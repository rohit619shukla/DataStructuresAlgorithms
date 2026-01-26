

//class Graph
//{
//    private int _vertices;
//    private int[] parent;
//    private int[] rank;
//    private int[] size;

//    public Graph(int vertices)
//    {
//        _vertices = vertices;
//        parent = new int[_vertices];
//        rank = new int[_vertices];
//        size = new int[_vertices];

//        for (int i = 0; i < _vertices; i++)
//        {
//            // each node will be a parent of itself
//            parent[i] = i;
//            size[i] = 1;
//        }
//    }

//    public int FindParent(int node)
//    {
//        // if the node is the parent of himself
//        if (node == parent[node])
//        {
//            return node;
//        }

//        // path compression to get the ultimate parent
//        return parent[node] = FindParent(parent[node]);
//    }

//    public void UnionByRank(int node1, int node2)
//    {
//        // Get the ultimate parents of bot the node
//        int parent1 = FindParent(node1);
//        int parent2 = FindParent(node2);


//        // if both the parents are same , means they belong to same compnonent
//        if (parent1 == parent2)
//        {
//            return;
//        }

//        // If the rank is greater no need to update the rank
//        if (rank[parent1] > rank[parent2])
//        {
//            parent[parent2] = parent1;
//        }
//        else if (rank[parent2] > rank[parent1])
//        {
//            parent[parent1] = parent2;
//        }
//        else
//        {
//            // if the rank is same, assign anyone as parent and increase the parent's rank
//            parent[parent2] = parent1;
//            rank[parent1]++;
//        }
//    }

//    public void UnionBySize(int node1, int node2)
//    {
//        int parent1 = FindParent(node1);
//        int parent2 = FindParent(node2);

//        if (parent1 == parent2)
//        {
//            return;
//        }

//        if (size[parent1] > size[parent2])
//        {
//            parent[parent2] = parent1;
//            size[parent1] += size[parent2];
//        }
//        else
//        {
//            parent[parent1] = parent2;
//            size[parent2] += size[parent1];
//        }
//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        Graph dis = new Graph(7);
//        dis.UnionByRank(0, 1);
//        dis.UnionByRank(1, 2);
//        dis.UnionByRank(3, 4);
//        dis.UnionByRank(5, 6);
//        dis.UnionByRank(4, 5);

//        if (dis.FindParent(2) == dis.FindParent(6))
//        {
//            Console.WriteLine(" same");
//        }
//        else
//        {
//            Console.WriteLine(" not same");
//        }


//        dis.UnionByRank(2, 6);

//        if (dis.FindParent(2) == dis.FindParent(6))
//        {
//            Console.WriteLine(" same");
//        }
//        else
//        {
//            Console.WriteLine(" not same");

//        }
//    }
//}

//// Complexity : O(alpha(n))  for both Find and Union functions