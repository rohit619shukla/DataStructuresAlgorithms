
//class Solution
//{
//    public void FloydWarshall(int[,] dist)
//    {
//        int v = dist.GetLength(0);

//        int[,] result = new int[v, v];

//        // This is all pairs shortes path where we take an intermediate to see if we can reach a given dest node from source with that edge
//        for (int k = 0; k < v; k++)
//        {
//            for (int i = 0; i < v; i++)
//            {
//                for (int j = 0; j < v; j++)
//                {
//                    dist[i, j] = Math.Min(dist[i, j], dist[i, k] + dist[k, j]);
//                }
//            }
//        }
//    }
//}

//class Program
//{
//    public static void Main()
//    {
//        int[,] dist = {
//            {0, 4, (int)1e9, 5, (int)1e9},
//            {(int)1e9, 0, 1, (int)1e9, 6},
//            {2, (int)1e9, 0, 3, (int)1e9},
//            {(int)1e9, (int)1e9, 1, 0, 2},
//            {1, (int)1e9, (int)1e9, 4, 0}
//        };

//        int rows = dist.GetLength(0);
//        int cols = dist.GetLength(1);

//        Solution s = new Solution();
//        s.FloydWarshall(dist);


//        for (int i = 0; i < rows; i++)
//        {
//            for (int j = 0; j < cols; j++)
//            {
//                Console.Write($"{dist[i, j]}" + " ");
//            }
//            Console.WriteLine();
//        }
//    }
//}


////Time Complexity: O(V3)
////Auxiliary Space: O(V2)

//// This algo can also help to find cycle, since the distance of node to itself is 0 and if we have a path 
//// starting and ending a 0 less than 0 then there is a cycle