
//public class Node
//{
//    public int RowCord;
//    public int ColCord;
//    public int Diff;

//    public Node(int row, int col, int dist)
//    {
//        RowCord = row; ColCord = col; Diff = dist;
//    }
//}
//public class Solution
//{
//    public int MinimumEffortPath(int[][] heights)
//    {
//        int rows = heights.Length;
//        int cols = heights[0].Length;

//        // Create a Priority Queue
//        SortedSet<Node> pq = new SortedSet<Node>(new DistanceComparer());

//        // Add the start node to pq
//        pq.Add(new Node(0, 0, 0));

//        // prepare distance array
//        int[,] distance = new int[rows, cols];

//        // Assign the value to distance array
//        for (int i = 0; i < rows; i++)
//        {
//            for (int j = 0; j < cols; j++)
//            {
//                distance[i, j] = int.MaxValue;
//            }
//        }

//        distance[0, 0] = 0;

//        // For 4 directions
//        int[] deltaRows = { -1, 0, 1, 0 };
//        int[] deltaCols = { 0, 1, 0, -1 };

//        // Start Dijikstra

//        while (pq.Count > 0)
//        {
//            Node currentNode = pq.Min;

//            pq.Remove(currentNode);

//            // Explore 4 directions
//            for (int i = 0; i < 4; i++)
//            {
//                int newRow = currentNode.RowCord + deltaRows[i];
//                int newCol = currentNode.ColCord + deltaCols[i];

//                if (newRow >= 0 && newRow < rows && newCol >= 0 && newCol < cols)
//                {
//                    // Get the max diff path
//                    int maxEffort = Math.Max(currentNode.Diff, Math.Abs(heights[currentNode.RowCord][currentNode.ColCord] - heights[newRow][newCol]));


//                    // Same like Dijisktra with adj matrix.
//                    // Distance matrix will store min effort 
//                    if (distance[newRow, newCol] > maxEffort)
//                    {
//                        distance[newRow, newCol] = maxEffort;
//                        pq.Add(new Node(newRow, newCol, distance[newRow, newCol]));
//                    }
//                }
//            }
//        }

//        return distance[rows - 1, cols - 1];
//    }

//}

//internal class DistanceComparer : IComparer<Node>
//{
//    public int Compare(Node n1, Node n2)
//    {
//        if (n1.Diff != n2.Diff)
//        {
//            return n1.Diff.CompareTo(n2.Diff);
//        }

//        if (n1.RowCord != n2.RowCord)
//        {
//            return n1.RowCord.CompareTo(n2.RowCord);
//        }

//        return n1.ColCord.CompareTo(n2.ColCord);
//    }

//}
//class Program
//{
//    public static void Main()
//    {
//        int[][] heights = new int[][] {
//                                    new int[]  {3}
//        };

//        Solution s = new Solution();

//        Console.WriteLine($"{s.MinimumEffortPath(heights)}");
//    }
//}

////Time Complexity: O(4 * N * M * log(N * M)) { N* M are the total cells, for each of which we also check 4 adjacent nodes for the minimum effort and additional
////log(N * M) for insertion - deletion operations in a priority queue }

////Where, N = No.of rows of the binary maze and M = No. of columns of the binary maze.

////Space Complexity: O(N * M) {
////    Distance matrix containing N*M cells + priority queue in the worst case containing all the nodes(N* M) }.

////Where, N = No.of rows of the binary maze and M = No.of columns of the binary maze.