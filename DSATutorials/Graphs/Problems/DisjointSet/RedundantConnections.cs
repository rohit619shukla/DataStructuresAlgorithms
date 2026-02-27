//public class Solution
//{
//    public int[] FindRedundantConnection(int[][] edges)
//    {
//        int n = edges.Length;

//        int[] parent = new int[n + 1];
//        int[] size = new int[n + 1];

//        for (int i = 0; i < n; i++)
//        {
//            parent[i] = i;
//            size[i] = 1;
//        }

//        int[] result = { };

//        foreach (int[] edge in edges)
//        {
//            int[] temp = UnionBySize(edge[0], edge[1], parent, size);

//            if (temp.Length != 0)
//            {
//                result = temp;
//            }
//        }

//        return result;
//    }

//    private int FindParent(int[] parent, int i)
//    {
//        if (parent[i] == i)
//        {
//            return i;
//        }

//        return parent[i] = FindParent(parent, parent[i]);
//    }

//    private int[] UnionBySize(int u, int v, int[] parent, int[] size)
//    {
//        int parentU = FindParent(parent, u);
//        int parentV = FindParent(parent, v);

//        if (parentU == parentV)
//        {
//            return new int[] { u, v };
//        }

//        if (size[parentU] > size[parentV])
//        {
//            parent[parentV] = parentU;
//            size[parentU] += size[parentV];
//        }
//        else
//        {
//            parent[parentU] = parentV;
//            size[parentV] += size[parentU];
//        }

//        return [];
//    }
//}

//class Program
//{
//    public static void Main()
//    {
//        int[][] edges = {
//            new int[] { 1,2},
//            new int[] { 2,3},
//            new int[] { 3,4},
//            new int[]{ 1,4},
//            new int[] { 1,5}
//        };

//        Solution s = new Solution();

//        var result = s.FindRedundantConnection(edges);

//        foreach (var item in result)
//        {
//            Console.Write($"{item}" + " ");
//        }

//    }


//}

//// Time : O(E * alpha(n))