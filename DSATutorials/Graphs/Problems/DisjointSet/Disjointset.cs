//using System;

//class Graph
//{
//    public int v;
//    public int[] parent;
//    public int[] rank;

//    public int[] size;
//    public Graph(int vertices)
//    {
//        v = vertices;
//        parent = new int[v];
//        rank = new int[v];
//        size = new int[v];

//        for (int i = 0; i < v; i++)
//        {
//            parent[i] = i;
//            size[i] = 1;
//        }
//    }

//    public int FindParent(int i)
//    {
//        if (i == parent[i])
//        {
//            return i;
//        }
//        else
//        {
//            return parent[i] = FindParent(parent[i]);
//        }
//    }

//    public void UnionByRank(int u, int v)
//    {
//        int parentOfU = FindParent(u);
//        int parentOfV = FindParent(v);

//        if (parentOfU == parentOfV)
//        {
//            return;
//        }

//        if (rank[parentOfU] < rank[parentOfV])
//        {
//            parent[parentOfU] = parentOfV;
//        }
//        else if (rank[parentOfV] < rank[parentOfU])
//        {
//            parent[parentOfV] = parentOfU;
//        }
//        else
//        {
//            parent[parentOfV] = parentOfU;
//            rank[parentOfU]++;   // rank will always increase by 1
//        }
//    }

//    public void UnionBySize(int u, int v)
//    {
//        int parentOfU = FindParent(u);
//        int parentOfV = FindParent(v);

//        if (parentOfU == parentOfV)
//        {
//            return;
//        }

//        if (size[parentOfU] < size[parentOfV])
//        {
//            parent[parentOfU] = parentOfV;
//            size[parentOfV] += size[parentOfU];
//        }
//        else
//        {
//            parent[parentOfV] = parentOfU;
//            size[parentOfU] += size[parentOfV];    // we dont increase by 1 but rather how many components small one has
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
//            Console.WriteLine(" not same")[;
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