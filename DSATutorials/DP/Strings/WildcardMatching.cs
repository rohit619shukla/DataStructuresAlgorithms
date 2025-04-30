//public class Solution
//{
//    public bool IsMatch(string source, string pattern)
//    {
//        //for (int i = 0; i < dp.GetLength(0); i++)
//        //{
//        //    for (int j = 0; j < dp.GetLength(1); j++)
//        //    {
//        //        dp[i, j] = null;
//        //    }
//        //}

//        //return Solve(source, pattern, source.Length - 1, pattern.Length - 1, dp);
//        return Solve(source, pattern);
//    }

//    // Time : O(2^n) , space : O(n+m)
//    //private bool Solve(string source, string pattern, int idx1, int idx2)
//    //{
//    //    // base case
//    //    // 1. Both the strings are exhausted while comparing, which means we are good
//    //    if (idx1 < 0 && idx2 < 0)
//    //    {
//    //        return true;
//    //    }

//    //    // 2. Pattern got exhausted but we still have few chars left in Source. Ideally nothing in pattern is left to compare
//    //    if (idx1 >= 0 && idx2 < 0)
//    //    {
//    //        return false;
//    //    }

//    //    // 3. source is exhausted but there are still few char in pattern
//    //    if (idx1 < 0 && idx2 >= 0)
//    //    {
//    //        // Make sure all the char in source are '*'
//    //        for (int i = 0; i <= idx2; i++)
//    //        {
//    //            if (pattern[idx2] != '*')
//    //            {
//    //                return false;
//    //            }
//    //        }
//    //        return true;
//    //    }

//    //    // Normal cases
//    //    // We found a match or the current char is a '?', as ? can match with a single word only
//    //    if (source[idx1] == pattern[idx2] || pattern[idx2] == '?')
//    //    {
//    //        // Since both matched we can keep on shrinking both the strings for further comparisons
//    //        return Solve(source, pattern, idx1 - 1, idx2 - 1);
//    //    }

//    //    // We found a *, which could match with  0 or more number of characters
//    //    if (pattern[idx2] == '*')
//    //    {
//    //        // Here we could have 2 cases in general:
//    //        // 1. Either the * matches with some char and stays at its location
//    //        // 2. Or the * does not matches with any char moves
//    //        return Solve(source, pattern, idx1, idx2 - 1) || Solve(source, pattern, idx1 - 1, idx2);
//    //    }

//    //    // Nothing matches
//    //    return false;
//    //}

//    // Time : O(n*m) , space : O(n*m) + O(n+m)
//    //private bool Solve(string source, string pattern, int idx1, int idx2, bool?[,] dp)
//    //{
//    //    // base case
//    //    // 1. Both the strings are exhausted while comparing, which means we are good
//    //    if (idx1 < 0 && idx2 < 0)
//    //    {
//    //        return true;
//    //    }

//    //    // 2. Pattern got exhausted but we still have few chars left in Source. Ideally nothing in pattern is left to compare
//    //    if (idx1 >= 0 && idx2 < 0)
//    //    {
//    //        return false;
//    //    }

//    //    // 3. source is exhausted but there are still few char in pattern
//    //    if (idx1 < 0 && idx2 >= 0)
//    //    {
//    //        // Make sure all the char in source are '*'
//    //        for (int i = 0; i <= idx2; i++)
//    //        {
//    //            if (pattern[i] != '*')
//    //            {
//    //                return false;
//    //            }
//    //        }
//    //        return true;
//    //    }

//    //    if (dp[idx1, idx2].HasValue)
//    //    {
//    //        return dp[idx1, idx2].Value;
//    //    }

//    //    // Normal cases
//    //    // We found a match or the current char is a '?', as ? can match with a single word only
//    //    if (source[idx1] == pattern[idx2] || pattern[idx2] == '?')
//    //    {
//    //        // Since both matched we can keep on shrinking both the strings for further comparisons
//    //        return (dp[idx1, idx2] = Solve(source, pattern, idx1 - 1, idx2 - 1, dp)).Value;
//    //    }

//    //    // We found a *, which could match with  0 or more number of characters
//    //    if (pattern[idx2] == '*')
//    //    {
//    //        // Here we could have 2 cases in general:
//    //        // 1. Either the * matches with some char and stays at its location
//    //        // 2. Or the * does not matches with any char moves
//    //        return (dp[idx1, idx2] = Solve(source, pattern, idx1, idx2 - 1, dp) || Solve(source, pattern, idx1 - 1, idx2, dp)).Value;
//    //    }

//    //    // Nothing matches
//    //    return (dp[idx1, idx2] = false).Value;
//    //}

//    // Time : O(n*m) , spae :O(n*m)
//    //private bool Solve(string source, string pattern)
//    //{
//    //    bool[,] dp = new bool[source.Length + 1, pattern.Length + 1];

//    //    // both strings got exhausted
//    //    dp[0, 0] = true;

//    //    // you're using i - 1 because pattern is a 0-based array, and your loop starts from i = 1 to align with the dp table,
//    //    // which has 1-based indexing semantics. This is a very common pattern in tabulation.
//    //    for (int i = 1; i <= pattern.Length; i++)
//    //    {
//    //        if (pattern[i - 1] != '*')
//    //        {
//    //            dp[0, i] = false;
//    //            break;
//    //        }
//    //        else
//    //        {
//    //            dp[0, i] = true;
//    //        }
//    //    }

//    //    for (int i = 1; i <= source.Length; i++)
//    //    {
//    //        for (int j = 1; j <= pattern.Length; j++)
//    //        {
//    //            if (source[i - 1] == pattern[j - 1] || pattern[j - 1] == '?')
//    //            {
//    //                // Since both matched we can keep on shrinking both the strings for further comparisons
//    //                dp[i, j] = dp[i - 1, j - 1];
//    //            }

//    //            // We found a *, which could match with  0 or more number of characters
//    //            else if (pattern[j - 1] == '*')
//    //            {
//    //                // Here we could have 2 cases in general:
//    //                // 1. Either the * matches with some char and stays at its location
//    //                // 2. Or the * does not matches with any char moves
//    //                dp[i, j] = dp[i, j - 1] || dp[i - 1, j];
//    //            }
//    //        }
//    //    }

//    //    return dp[source.Length, pattern.Length];
//    //}

//    //Time : O(n*m) , space : O(n*m)
//    private bool Solve(string source, string pattern)
//    {
//        //bool[,] dp = new bool[source.Length + 1, pattern.Length + 1];
//        bool[] prev = new bool[pattern.Length + 1];

//        // both strings got exhausted
//        prev[0] = true;

//        // you're using i - 1 because pattern is a 0-based array, and your loop starts from i = 1 to align with the dp table,
//        // which has 1-based indexing semantics. This is a very common pattern in tabulation.
//        for (int i = 1; i <= pattern.Length; i++)
//        {
//            if (pattern[i - 1] != '*')
//            {
//                prev[i] = false;
//                break;
//            }
//            else
//            {
//                prev[i] = true;
//            }
//        }

//        for (int i = 1; i <= source.Length; i++)
//        {
//            bool[] curr = new bool[pattern.Length + 1];
//            for (int j = 1; j <= pattern.Length; j++)
//            {
//                if (source[i - 1] == pattern[j - 1] || pattern[j - 1] == '?')
//                {
//                    // Since both matched we can keep on shrinking both the strings for further comparisons
//                    curr[j] = prev[j - 1];
//                }

//                // We found a *, which could match with  0 or more number of characters
//                else if (pattern[j - 1] == '*')
//                {
//                    // Here we could have 2 cases in general:
//                    // 1. Either the * matches with some char and stays at its location
//                    // 2. Or the * does not matches with any char moves
//                    curr[j] = curr[j - 1] || prev[j];
//                }
//            }
//            prev = curr;
//        }

//        return prev[pattern.Length];
//    }
//}

//class Program
//{
//    public static void Main()
//    {
//        string source = "aa";
//        string pattern = "*";

//        Solution s = new Solution();
//        Console.WriteLine(s.IsMatch(source, pattern));
//    }
//}