

//public class Solution
//{
//    public int RemoveStones(int[][] stones)
//    {

//        // The objective is to use a row and column itself as number of nodes in DSU
//        // we will not directly consider stones as no:of nodes as number of stones can be 5  but the co-ordinate can have a row or column greatr value.
//        // Hence we will use maxrow and maxcol from both
//        int rows = int.MinValue;
//        int cols = int.MinValue;

//        foreach (var st in stones)
//        {
//            rows = Math.Max(rows, st[0]);
//            cols = Math.Max(cols, st[1]);
//        }

//        int[] size = new int[rows + 1 + cols + 1];
//        int[] parent = new int[rows + 1 + cols + 1];

//        for (int i = 0; i < parent.Length; i++)
//        {
//            parent[i] = i;
//            size[i] = 1;
//        }

//        // The idea of rows+1 is that since cols are also staring from 0th index but we need nodes, hence whatever is the last node in rows+1 will get added to current col
//        foreach (var st in stones)
//        {
//            int u = st[0];
//            int v = st[1] + rows + 1;

//            UnionBySize(u, v, size, parent);
//        }

//        int components = 0;

//        for (int i = 0; i < parent.Length; i++)
//        {
//            if (parent[i] == i && size[i] > 1)
//            {
//                components++;
//            }
//        }

//        // Formula : (x1+x2+x3) - (1+1+1)
//        return stones.Length - components;
//    }

//    private int FindParent(int[] parent, int i)
//    {
//        if (parent[i] == i)
//        {
//            return i;
//        }
//        return parent[i] = FindParent(parent, parent[i]);
//    }

//    private void UnionBySize(int u, int v, int[] size, int[] parent)
//    {
//        int parentU = FindParent(parent, u);
//        int parentV = FindParent(parent, v);


//        if (parentU == parentV)
//        {
//            return;
//        }

//        if (parentU > parentV)
//        {
//            parent[parentV] = parentU;
//            size[parentU] += size[parentV];
//        }
//        else
//        {
//            parent[parentU] = parentV;
//            size[parentV] += size[parentU];
//        }
//    }
//}

//class Program
//{
//    public static void Main()
//    {
//        int[][] stones = new int[][]{
//                                                     new int[] {0,1},
//                                                     new int[] {1,1},
//                     };


//        Solution s = new Solution();

//        Console.WriteLine(s.RemoveStones(stones));
//    }
//}

//// Time : O(n(alpha(n)) + O(n) and space : O(n)