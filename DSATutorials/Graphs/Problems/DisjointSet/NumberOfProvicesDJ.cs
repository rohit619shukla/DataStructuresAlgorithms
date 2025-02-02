
//class Graph
//{
//    private int v;
//    private int[] size;
//    private int[] parent;

//    public Graph(int vertices)
//    {
//        v = vertices;
//        size = new int[v];
//        parent = new int[v];

//        for (int i = 0; i < size.Length; i++)
//        {
//            size[i] = 1;
//            parent[i] = i;
//        }
//    }

//    public void UnionBySize(int v, int u)
//    {
//        int parentOfU = FindParent(u);
//        int parentOfV = FindParent(v);

//        if (parentOfU == parentOfV)
//        {
//            return;
//        }

//        if (size[parentOfU] < size[parentOfV])
//        {
//            size[parentOfV] += size[parentOfU];
//            parent[parentOfU] = parentOfV;
//        }
//        else
//        {
//            size[parentOfU] += size[parentOfV];
//            parent[parentOfV] = parentOfU;
//        }
//    }

//    private int FindParent(int node)
//    {
//        if (node == parent[node])
//        {
//            return parent[node];
//        }

//        return parent[node] = FindParent(parent[node]);
//    }

//    public int CountProvinces()
//    {
//        int count = 0;

//        for (int i = 0; i < parent.Length; i++)
//        {
//            if (parent[i] == i)
//            {
//                count++;
//            }
//        }

//        return count;
//    }
//}

//class Program
//{
//    public static void Main()
//    {
//        Graph g = new Graph(3);

//        int[][] mat = new int[][] {
//            new int[] {1,1,0},
//            new int[]{ 1,1,0},
//            new int[]{0,0,1 }
//        };

//        int rows = mat.Length;
//        int cols = mat[0].Length;

//        for (int i = 0; i < rows; i++)
//        {
//            for (int j = 0; j < cols; j++)
//            {
//                if (mat[i][j] == 1)
//                {
//                    g.UnionBySize(i, j);
//                }
//            }
//        }

//        Console.WriteLine(g.CountProvinces());

//    }
//}