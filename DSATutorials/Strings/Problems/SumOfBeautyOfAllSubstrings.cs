//public class Solution
//{
//    // Time : O(N^2) , space :O(1)
//    public int BeautySum(string s)
//    {
//        int finalBeauty = 0;

//        // Iterate through all the substrings and check for beauty for every substring
//        for (int i = 0; i < s.Length; i++)
//        {
//            // To store the frequency of each character in the substring
//            int[] freq = new int[26];

//            // Start generating substring
//            for (int j = i; j < s.Length; j++)
//            {
//                // keep updating the frequency
//                freq[s[j] - 'a']++;

//                int maxFreq = int.MinValue;
//                int minFreq = int.MaxValue;

//                // no compute the min and max frequency of the characters in the current substring
//                for (int k = 0; k < 26; k++)
//                {
//                    if (freq[k] > 0)
//                    {
//                        maxFreq = Math.Max(maxFreq, freq[k]);
//                        minFreq = Math.Min(minFreq, freq[k]);
//                    }
//                }

//                // Now get the cumulative beauty of the substring
//                finalBeauty += maxFreq - minFreq;
//            }
//        }

//        return finalBeauty;
//    }
//}

//class Program
//{
//    public static void Main()
//    {
//        Solution sol = new Solution();
//        Console.WriteLine(sol.BeautySum("aabcb"));
//    }
//}