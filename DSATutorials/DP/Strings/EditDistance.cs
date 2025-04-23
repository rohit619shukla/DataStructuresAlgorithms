//public class Solution
//{
//    public int MinDistance(string word1, string word2)
//    {
//        //int[,] dp = new int[word1.Length, word2.Length];
//        //for (int i = 0; i < word1.Length; i++)
//        //{
//        //    for (int j = 0; j < word2.Length; j++)
//        //    {
//        //        dp[i, j] = -1;
//        //    }
//        //}

//        //return Solve(word1, word2, word1.Length - 1, word2.Length - 1, dp);
//        return Solve(word1, word2);
//        //return Solve(word1, word2, word1.Length - 1, word2.Length - 1);
//    }


//    // Time : O(3^(m+n)) , space : O(n+m)
//    //private int Solve(string word1, string word2, int idx1, int idx2)
//    //{
//    //    // base case
//    //    // 1. If the word1 is exhauseted, we may still have some char  left in word2
//    //    if (idx1 < 0)
//    //    {
//    //        return idx2 + 1;
//    //    }

//    //    // 2. If the word2 is exhauseted, we may still have some char  left in word1
//    //    if (idx2 < 0)
//    //    {
//    //        return idx1 + 1;
//    //    }

//    //    // Match case
//    //    if (word1[idx1] == word2[idx2])
//    //    {
//    //        // No action needed
//    //        return Solve(word1, word2, idx1 - 1, idx2 - 1);
//    //    }

//    //    // Not match cases
//    //    int insertCase = 1 + Solve(word1, word2, idx1, idx2 - 1);   // Since we are hypothetically inserting the char, dont need to move idx1 but indeed idx2

//    //    int deleteCase = 1 + Solve(word1, word2, idx1 - 1, idx2);  // We have delted the idx1 hence we need to search in shrinked string

//    //    int replaceCase = 1 + Solve(word1, word2, idx1 - 1, idx2 - 1); // Replace happened and offcourse they match, hence move backward

//    //    return Math.Min(insertCase, Math.Min(deleteCase, replaceCase));
//    //}

//    // Time : O(n*m) , space :O(n*m) + O(n+m)
//    //private int Solve(string word1, string word2, int idx1, int idx2, int[,] dp)
//    //{
//    //    // base case
//    //    // 1. If the word1 is exhauseted, we may still have some char  left in word2
//    //    if (idx1 < 0)
//    //    {
//    //        return idx2 + 1;
//    //    }

//    //    // 2. If the word2 is exhauseted, we may still have some char  left in word1
//    //    if (idx2 < 0)
//    //    {
//    //        return idx1 + 1;
//    //    }

//    //    if (dp[idx1, idx2] != -1)
//    //    {
//    //        return dp[idx1, idx2];
//    //    }

//    //    // Match case
//    //    if (word1[idx1] == word2[idx2])
//    //    {
//    //        // No action needed
//    //        return Solve(word1, word2, idx1 - 1, idx2 - 1, dp);
//    //    }

//    //    // Not match cases
//    //    int insertCase = 1 + Solve(word1, word2, idx1, idx2 - 1, dp);   // Since we are hypothetically inserting the char, dont need to move idx1 but indeed idx2

//    //    int deleteCase = 1 + Solve(word1, word2, idx1 - 1, idx2, dp);  // We have delted the idx1 hence we need to search in shrinked string

//    //    int replaceCase = 1 + Solve(word1, word2, idx1 - 1, idx2 - 1, dp); // Replace happened and offcourse they match, hence move backward

//    //    return dp[idx1, idx2] = Math.Min(insertCase, Math.Min(deleteCase, replaceCase));
//    //}

//    // Time : O(n*m) , space :O(n+m)
//    //private int Solve(string word1, string word2)
//    //{
//    //    int[,] dp = new int[word1.Length + 1, word2.Length + 1];

//    //    // base case :
//    //    // 1. Word1 is exhausted
//    //    for (int i = 0; i <= word2.Length; i++)
//    //    {
//    //        dp[0, i] = i; // co-ordinate shift
//    //    }

//    //    // 2. Word2 is exhausted
//    //    for (int j = 0; j <= word1.Length; j++)
//    //    {
//    //        dp[j, 0] = j;
//    //    }

//    //    for (int i = 1; i <= word1.Length; i++)
//    //    {
//    //        for (int j = 1; j <= word2.Length; j++)
//    //        {
//    //            if (word1[i - 1] == word2[j - 1])
//    //            {
//    //                // No action needed
//    //                dp[i, j] = dp[i - 1, j - 1];
//    //            }
//    //            else
//    //            {
//    //                // Not match cases
//    //                int insertCase = 1 + dp[i, j - 1];   // Since we are hypothetically inserting the char, dont need to move idx1 but indeed idx2

//    //                int deleteCase = 1 + dp[i - 1, j];  // We have delted the idx1 hence we need to search in shrinked string

//    //                int replaceCase = 1 + dp[i - 1, j - 1]; // Replace happened and offcourse they match, hence move backward

//    //                dp[i, j] = Math.Min(insertCase, Math.Min(deleteCase, replaceCase));
//    //            }

//    //        }
//    //    }

//    //    return dp[word1.Length, word2.Length];
//    //}

//    // Space optimization
//    // Time :O(n*m) , space : O(n+m)
//    private int Solve(string word1, string word2)
//    {
//        //int[,] dp = new int[word1.Length + 1, word2.Length + 1];
//        int[] prev = new int[word2.Length + 1];

//        // base case :
//        // 1. Word1 is exhausted
//        for (int i = 0; i <= word2.Length; i++)
//        {
//            prev[i] = i; // co-ordinate shift
//        }

//        for (int i = 1; i <= word1.Length; i++)
//        {
//            int[] curr = new int[word2.Length + 1];
//            curr[0] = i;
//            for (int j = 1; j <= word2.Length; j++)
//            {
//                if (word1[i - 1] == word2[j - 1])
//                {
//                    // No action needed
//                    curr[j] = prev[j - 1];
//                }
//                else
//                {
//                    // Not match cases
//                    int insertCase = 1 + curr[j - 1];   // Since we are hypothetically inserting the char, dont need to move idx1 but indeed idx2

//                    int deleteCase = 1 + prev[j];  // We have delted the idx1 hence we need to search in shrinked string

//                    int replaceCase = 1 + prev[j - 1]; // Replace happened and offcourse they match, hence move backward

//                    curr[j] = Math.Min(insertCase, Math.Min(deleteCase, replaceCase));
//                }
//            }
//            prev = curr;
//        }

//        return prev[word2.Length];
//    }
//}

//class Program
//{
//    public static void Main()
//    {
//        string word1 = "intention";
//        string word2 = "execution";

//        Solution s = new Solution();

//        Console.WriteLine(s.MinDistance(word1, word2));
//    }
//}