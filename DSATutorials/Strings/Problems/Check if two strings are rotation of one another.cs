//public class Solution
//{
//    // Time : O(m+n) , space :O(n)
//    public bool RotateString(string str, string goal)
//    {
//        // base cases
//        if (string.IsNullOrWhiteSpace(str) || string.IsNullOrWhiteSpace(goal))
//        {
//            return false;
//        }

//        if (str.Length != goal.Length) return false;
//        return Solve(str += str, goal);
//    }

//    private bool Solve(string str, string pattern)
//    {
//        // Step 1: create LPS array
//        int[] lps = new int[pattern.Length];
//        LPSCreation(lps, pattern);

//        // Step 2: perform actual string mathcing with help of LPS array
//        int i = 0; // to tack the actual string
//        int j = 0; // to track the pattern

//        while (i < str.Length - 1)
//        {
//            // if a match is found between both
//            if (str[i] == pattern[j])
//            {
//                i++;
//                j++;
//            }

//            // Maybe we reached end
//            if (j == pattern.Length)
//            {
//                // we found a match
//                return true;
//            }
//            else if (str[i] != pattern[j])
//            {
//                // no match found so 2 cases
//                if (j == 0)
//                {
//                    i++;
//                }
//                else
//                {
//                    // move to better lps
//                    j = lps[j - 1];
//                }
//            }
//        }

//        return false;
//    }

//    private void LPSCreation(int[] lps, string pattern)
//    {
//        int i = 0; // to track the length of longest string which is also a prefix
//        int j = 1; // to traverse the pattern

//        while (j < pattern.Length)
//        {
//            // If a match is found
//            if (pattern[i] == pattern[j])
//            {
//                lps[j] = i + 1;
//                i++;
//                j++;
//            }
//            else
//            {
//                // In case of no match, we can have 2 cases

//                // case 1:No prefix found till the  given moment
//                if (i == 0)
//                {
//                    lps[j] = 0;
//                    j++;
//                }
//                else
//                {
//                    // rollback to last found longest prefix which is also a suffix to save time
//                    i = lps[i - 1];
//                }
//            }
//        }
//    }
//}

//class Program
//{
//    public static void Main()
//    {
//        string str = "abcde";
//        string goal = "abced";

//        Solution s = new Solution();

//        Console.WriteLine(s.RotateString(str, goal));
//    }
//}