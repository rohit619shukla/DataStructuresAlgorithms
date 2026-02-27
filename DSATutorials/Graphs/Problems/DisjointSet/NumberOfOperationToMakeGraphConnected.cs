//public class Solution
//{
//    public int MakeConnected(int n, int[][] connections)
//    {
//        // We must have more edges in hand to connect n-1 components
//        if (n - 1 > connections.Length)
//        {
//            return -1;
//        }

//        // Create parent and size array
//        int[] parent = new int[n];
//        int[] size = new int[n];

//        Array.Fill(size, 1);

//        for (int i = 0; i < n; i++)
//        {
//            // every node is parent of himself
//            parent[i] = i;
//        }

//        int components = n;

//        // Apply Union for all the edges
//        foreach (int[] edge in connections)
//        {
//            UnionBySize(edge[0], edge[1], size, parent, ref components);
//        }

//        // We need exactly n-1 times extraction to connect all the computer
//        return components - 1;
//    }

//    private int FindParent(int[] parent, int i)
//    {
//        if (i == parent[i])
//        {
//            return i;
//        }

//        return parent[i] = FindParent(parent, parent[i]);
//    }

//    private void UnionBySize(int u, int v, int[] size, int[] parent, ref int components)
//    {
//        int parentOfU = FindParent(parent, u);
//        int parentOfV = FindParent(parent, v);

//        if (parentOfU == parentOfV)
//        {
//            return;
//        }

//        if (size[parentOfU] > size[parentOfV])
//        {
//            parent[parentOfV] = parentOfU;
//            size[parentOfU] += size[parentOfV];
//        }
//        else
//        {
//            parent[parentOfU] = parentOfV;
//            size[parentOfV] += size[parentOfU];
//        }

//        // We will shrink the component size as connections becomes more prevelant
//        components--;
//    }
//}

//class Program
//{
//    public static void Main()
//    {
//        int[][] connections = new int[][] {
//                    new int[] {0,1 },
//                    new int[]{ 0,2},
//                    new int[]{ 0, 3 },
//                    new int[]{ 1, 2 },
//                    new int[]{ 1, 3 }
//                };

//        Solution s = new Solution();

//        Console.WriteLine(s.MakeConnected(6, connections));

//    }
//}

//// Time : O(E * alpha(n)), for E edges we perform the union find