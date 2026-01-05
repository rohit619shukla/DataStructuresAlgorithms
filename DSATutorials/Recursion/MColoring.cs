
//class Solution
//{
//    public bool IsPossible(int[][] mat, int n, int m)
//    {
//        // create a color array
//        int[] color = new int[n];

//        // Convert matrix to adjacenecy List
//        List<int>[] adjList = new List<int>[n];

//        // Initialize the list
//        for (int i = 0; i < n; i++)
//        {
//            adjList[i] = new List<int>();
//        }

//        // Add element to list now
//        int rows = mat.Length;
//        int cols = mat[0].Length;

//        for (int i = 0; i < rows; i++)
//        {
//            int source = mat[i][0];
//            int dest = mat[i][1];

//            adjList[source].Add(dest);
//            adjList[dest].Add(source);
//        }

//        return Recursion(adjList, n, m, 0, color);
//    }

//    private bool Recursion(List<int>[] adjList, int n, int m, int currentNode, int[] color)
//    {
//        // If we have reached a node greater than existing set ones, means we are good and have colored all nodes and can return
//        if (currentNode == n)
//        {
//            return true;
//        }

//        // start applying colors
//        for (int i = 1; i <= m; i++)
//        {
//            // Check if the current node is good to be colored 
//            if (IsGoodToColor(currentNode, i, color, adjList))
//            {
//                // color the node
//                color[currentNode] = i;

//                // Move to next node
//                if (Recursion(adjList, n, m, currentNode + 1, color))
//                {
//                    return true;
//                }

//                // backtrack
//                color[currentNode] = 0;
//            }
//        }

//        return false;
//    }

//    private bool IsGoodToColor(int currentNode, int proposedColor, int[] color, List<int>[] adjList)
//    {
//        foreach (var item in adjList[currentNode])
//        {
//            if (color[item] != 0 && color[item] == proposedColor)
//            {
//                return false;
//            }
//        }
//        return true;
//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        int[][] mat = new int[][] {
//            new int[] { 0,1},
//                new int[] { 0,2},
//              new int[] { 1,2},
//                new int[] { 1,3},
//                new int[]{0,3}
//        };

//        int n = 4, m = 3;

//        Solution s = new Solution();

//        Console.WriteLine(s.IsPossible(mat, n, m));
//    }
//}


//// Time : O(M^V *V) , for each verstx v we can have m possibilities And additional V for checking if good to color
//// Space : O(V+E) dues to adjacency List + Recursive stck space :O(n)