//public class Solution
//{
//    // Time :  O(V^2) , space :O(V)
//    public int FindCircleNum(int[][] isConnected)
//    {
//        int vertices = isConnected.Length;

//        // Create a visited matrix
//        bool[] visited = new bool[vertices];

//        int count = 0;

//        for (int i = 0; i < vertices; i++)
//        {
//            if (visited[i] == false)
//            {
//                DFS(i, visited, isConnected, vertices);
//                count++;
//            }
//        }

//        return count;
//    }

//    private void DFS(int startNode, bool[] visited, int[][] isConnected, int vertices)
//    {
//        visited[startNode] = true;


//        for (int i = 0; i < vertices; i++)
//        {
//            if (isConnected[startNode][i] == 1 && visited[i] == false)
//            {
//                DFS(i, visited, isConnected, vertices);
//            }
//        }
//    }
//}


//class Program
//{
//    public static void Main()
//    {
//        int[][] connected = new int[][] {
//            new int[] { 1,1,0},
//            new int[] { 1,1,0},
//            new int[]{ 0,0,1}
//        };

//        Solution s = new Solution();

//        Console.WriteLine(s.FindCircleNum(connected));
//    }
//}