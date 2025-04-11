//public class Solution
//{
//    public bool CanCross(int[] stones)
//    {
//        int n = stones.Length;
//        bool?[,] dp = new bool?[n + 1, n + 1]; // dp[stone index, last jump]

//        Dictionary<int, int> map = new Dictionary<int, int>();
//        for (int i = 0; i < n; i++)
//        {
//            map[stones[i]] = i;
//        }
//        return Solve(stones, 0, 0, map, dp);
//    }
//    private bool Solve(int[] stones, int cur_stone_idx, int prevJump, Dictionary<int, int> map, bool?[,] dp)
//    {
//        // base case
//        // Means we have reached last stone without falling in water
//        if (cur_stone_idx == stones.Length - 1)
//        {
//            return true;
//        }

//        if (dp[cur_stone_idx, prevJump].HasValue)
//        {
//            return dp[cur_stone_idx, prevJump].Value;
//        }
//        bool result = false;

//        // Explore all three jumps for the frog
//        for (int nextJump = prevJump - 1; nextJump <= prevJump + 1; nextJump++)
//        {
//            // Need to make sure we dont have -ve nor 0 jump as they are of no use
//            if (nextJump > 0)
//            {
//                int next_stone = stones[cur_stone_idx] + nextJump;

//                // The stone should be part of the map
//                if (map.ContainsKey(next_stone))
//                {
//                    result = result || Solve(stones, map[next_stone], nextJump, map, dp);
//                }
//            }
//        }
//        dp[cur_stone_idx, prevJump] = result;

//        return dp[cur_stone_idx, prevJump].Value;
//    }

//}

//class Program
//{
//    public static void Main()
//    {
//        int[] stones = { 0, 1, 3, 5, 6, 8, 12, 17 };

//        Solution s = new Solution();

//        Console.WriteLine(s.CanCross(stones));
//    }
//}

//// Time : O(N^2) and space :O(N^2)