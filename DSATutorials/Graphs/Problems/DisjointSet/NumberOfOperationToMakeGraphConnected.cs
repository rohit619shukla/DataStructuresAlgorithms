
//public class DisjointSet
//{
//    public int[] Parent;
//    public int[] Size;
//    public int V;

//    public DisjointSet(int vertices)
//    {
//        V = vertices;
//        Parent = new int[vertices];
//        Size = new int[vertices];

//        for (int i = 0; i < V; i++)
//        {
//            Parent[i] = i;
//            Size[i] = 1;
//        }
//    }

//    public void UnionBySize(int v, int u, ref int extraEdges)
//    {
//        int parentOfU = FindParent(u);
//        int parentOfV = FindParent(v);

//        if (parentOfU == parentOfV)
//        {
//            extraEdges++;
//            return;
//        }

//        if (Size[parentOfU] < Size[parentOfV])
//        {
//            Parent[parentOfU] = parentOfV;
//            Size[parentOfV] += Size[parentOfU];
//        }
//        else
//        {
//            Parent[parentOfV] = parentOfU;
//            Size[parentOfU] += Size[parentOfV];
//        }
//    }
//    public int FindParent(int node)
//    {
//        if (node == Parent[node])
//        {
//            return node;
//        }

//        return Parent[node] = FindParent(Parent[node]);
//    }
//}
//public class Solution
//{
//    public int MakeConnected(int n, int[][] connections)
//    {
//        DisjointSet dj = new DisjointSet(n);

//        int extraEdges = 0;

//        // Perform union and find
//        for (int i = 0; i < connections.Length; i++)
//        {
//            dj.UnionBySize(connections[i][0], connections[i][1], ref extraEdges);
//        }

//        // Get number of components
//        int parents = 0;

//        for (int i = 0; i < dj.V; i++)
//        {
//            if (dj.Parent[i] == i)
//            {
//                parents++;
//            }
//        }

//        return (extraEdges >= parents - 1) ? parents - 1 : -1;
//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        int[][] connections = new int[][] {
//            new int[] {0,1 },
//            new int[]{ 0,2},
//            new int[]{ 1, 2 }
//        };

//        Solution s = new Solution();

//        Console.WriteLine(s.MakeConnected(4, connections));
//    }
//}


//// Time : O(m+n) and aplha(n), inverse ackerman function grows very slow.
//// Union Operations : O(m * alpha(n)), as we are calling union operation on m edges
//// Counting Operation O(n)

//// Space : O(n)
