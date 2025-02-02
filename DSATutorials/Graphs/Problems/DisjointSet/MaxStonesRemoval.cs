

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

//        for (int i = 0; i < vertices; i++)
//        {
//            Parent[i] = i;
//            Size[i] = 1;
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

//    public void UnionBySize(int u, int v)
//    {
//        int parentOfU = FindParent(u);
//        int parentOfV = FindParent(v);

//        if (parentOfU == parentOfV)
//        {
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
//}
//public class Solution
//{
//    public int RemoveStones(int[][] stones)
//    {
//        // Get number of rows and columns with cordinate shift
//        int maxRow = int.MinValue;
//        int maxCol = int.MinValue;

//        for (int i = 0; i < stones.Length; i++)
//        {
//            maxRow = Math.Max(maxRow, stones[i][0]);
//            maxCol = Math.Max(maxCol, stones[i][1]);
//        }

//        // Initialize Disjoint set
//        DisjointSet dj = new DisjointSet((maxRow + 1) + (maxCol + 1));

//        // Perform union
//        for (int i = 0; i < stones.Length; i++)
//        {
//            int u = stones[i][0];
//            int v = maxRow + stones[i][1] + 1;

//            dj.UnionBySize(u, v);
//        }

//        // Count parent nodes
//        int components = 0;

//        for (int i = 0; i < dj.Parent.Length; i++)
//        {
//            //We are making sure that on self components and then ones with only size greater then 1 are taking into consideration as each node has size of 1 by default
//            if (dj.Parent[i] == i && dj.Size[i] > 1)
//            {
//                components++;
//            }
//        }

//        return stones.Length - components;
//    }
//}

//class Program
//{
//    public static void Main()
//    {
//        int[][] stones = new int[][]{
//                                                     new int[] {0,0},
//                                                     new int[] {0,1},
//                                                     new int[] {1,0},
//                                                     new int[] {1,2},
//                                                     new int[] {2,1},
//                                                     new int[] {2,2},
//                     };


//        Solution s = new Solution();

//        Console.WriteLine(s.RemoveStones(stones));
//    }
//}

//// Time : O(n(alpha(n)) + O(n) and space : O(n)