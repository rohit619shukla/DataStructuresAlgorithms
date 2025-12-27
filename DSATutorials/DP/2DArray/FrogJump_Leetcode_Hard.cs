//public class Solution
//{
//    public bool CanCross(int[] stones)
//    {
//        // We will store the stones and their indices in a map for quick access
//        Dictionary<int, int> map = new Dictionary<int, int>();

//        for (int i = 0; i < stones.Length; i++)
//        {
//            map[stones[i]] = i;
//        }

//        bool?[,] dp = new bool?[stones.Length + 1, stones.Length + 1];

//        //return Solve(stones, 0, 0, map);
//        //return Solve(stones, 0, 0, map, dp);
//        return Solve(stones, map);
//    }

//    // Time : O(3^n) , space : O(n) recursive space stack + O(n) dictionary
//    //private bool Solve(int[] stones, int currentStoneIndex, int previousJump, Dictionary<int, int> map)
//    //{
//    //    // base case
//    //    // when the frog reached the last stones
//    //    if (currentStoneIndex == stones.Length - 1)
//    //    {
//    //        return true;
//    //    }

//    //    bool result = false;

//    //    // in order to simulate k jumps we will write it in loop
//    //    for (int nextJump = previousJump - 1; nextJump <= previousJump + 1; nextJump++)
//    //    {
//              // To make sure this goe always in forward direction
//    //        if (nextJump > 0)
//    //        {
//    //            // We need to get the next stone that we will jump on
//    //            int nextStone = nextJump + stones[currentStoneIndex];

//    //            // check if the stones does exist or not
//    //            if (map.ContainsKey(nextStone))
//    //            {
//    //                // need to pass the nextStone index to next iteration so that we can start the jump from that index
//    //                // We do or because we have 3 ways to do so
//    //                result = result || Solve(stones, map[nextStone], nextJump, map);
//    //            }
//    //        }
//    //    }

//    //    return result;
//    //}

//    // Time : O(n^2) as state for curr and prev is computed once, space : O(n) recursive space stack + O(n) dictionary + O(n^2) dp array
//    private bool Solve(int[] stones, int currentStoneIndex, int previousJump, Dictionary<int, int> map, bool?[,] dp)
//    {
//        // base case
//        // when the frog reached the last stones
//        if (currentStoneIndex == stones.Length - 1)
//        {
//            return true;
//        }

//        if (dp[currentStoneIndex, previousJump].HasValue)
//        {
//            return dp[currentStoneIndex, previousJump].Value;
//        }

//        bool result = false;

//        // in order to simulate k jumps we will write it in loop
//        for (int nextJump = previousJump - 1; nextJump <= previousJump + 1; nextJump++)
//        {
//            if (nextJump > 0)
//            {
//                // We need to get the next stone that we will jump on
//                int nextStone = nextJump + stones[currentStoneIndex];

//                // check if the stones does exist or not
//                if (map.ContainsKey(nextStone))
//                {
//                    // need to pass the nextStone index to next iteration so that we can start the jump from that index
//                    // We do or because we have 3 ways to do so
//                    result = result || Solve(stones, map[nextStone], nextJump, map, dp);
//                }
//            }
//        }

//        dp[currentStoneIndex, previousJump] = result;
//        return dp[currentStoneIndex, previousJump].Value;
//    }

//    // Time : O(N^3), space :O(N^2) + O(n)
//    private bool Solve(int[] stones, Dictionary<int, int> map)
//    {
//        int n = stones.Length;

//        // dp[i, j] = true means: from stone i with previousJump j, frog can reach end
//        bool[,] dp = new bool[n+1, n+1]; // second dim indices: 0 .. n-1

//        // Base case: frog is at last stone
//        // valid previousJump values are 1..n-1
//        for (int j = 0; j <= n; j++)
//        {
//            dp[n - 1, j] = true;
//        }

//        // Fill bottom-up
//        for (int i = n - 2; i >= 0; i--)
//        {
//            // previousJump valid range: 0 .. n-1
//            for (int previousJump = n-1; previousJump >=0; previousJump--)
//            {
//                bool result = false;

//                // Try next jumps: previousJump - 1, previousJump, previousJump + 1
//                for (int nextJump = previousJump - 1; nextJump <= previousJump + 1; nextJump++)
//                {
//                    // nextJump must be a valid jump (1..n-1) before using it as an index
//                    if (nextJump > 0 )
//                    {
//                        int nextStone = stones[i] + nextJump;

//                        if (map.ContainsKey(nextStone))
//                        {
//                            int nextIndex = map[nextStone];

//                            result = result || dp[nextIndex, nextJump];
//                        }
//                    }
//                }

//                dp[i, previousJump] = result;
//            }
//        }

//        // Frog starts at stone 0 with previousJump = 0, just revrsal of memoization
//        return dp[0, 0];
//    }


//}
//class Program
//{
//    public static void Main()
//    {
//        int[] stones = { 0, 1, 2, 3, 4, 8, 9, 11 };

//        Solution s = new Solution();

//        Console.WriteLine(s.CanCross(stones));
//    }
//}