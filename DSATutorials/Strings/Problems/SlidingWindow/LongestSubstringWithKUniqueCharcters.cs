
//public class Solution
//{
//    // Time : O(26N) = O(N) , space :O(1)
//    public int LongestSubstring(string str, int k)
//    {

//        // Step 2 : we will try to start withe lowest number of characters to highest number of characters to avoid unnecessary iterations
//        // Thing to note is larger the number of charcaters in string means larger the chance of checking bad characters

//        int maxLen = int.MinValue;

//        for (int uniqueTarget = 1; uniqueTarget <= 26; uniqueTarget++)
//        {
//            int start = 0, end = 0, uniqueCount = 0, countAtLeastK = 0;

//            // Step 1: Have a frequency array
//            int[] freq = new int[26];
//            // Step 3 : start sliding window
//            while (end < str.Length)
//            {
//                // We are still within the target range
//                if (uniqueCount <= uniqueTarget)
//                {
//                    // It might be that we are encountering this char for the first time
//                    if (freq[str[end] - 'a'] == 0)
//                    {
//                        uniqueCount++;
//                    }

//                    // Increment the frequency of the character
//                    freq[str[end] - 'a']++;

//                    // wem might have found our least k character
//                    if (freq[str[end] - 'a'] == k)
//                    {
//                        countAtLeastK++;
//                    }

//                    // move the window
//                    end++;
//                }
//                else
//                {
//                    // We went over the target range and hence we need to shrink the window
//                    if (freq[str[start] - 'a'] == k)
//                    {
//                        // this number is no linger valid to be considered as a valid number
//                        countAtLeastK--;
//                    }

//                    // Reduce the frequency of the char
//                    freq[str[start] - 'a']--;

//                    // While reducing the freuqency we might have lost a unique character
//                    if (freq[str[start] - 'a'] == 0)
//                    {
//                        uniqueCount--;
//                    }

//                    start++;
//                }

//                if (uniqueCount == uniqueTarget && uniqueTarget == countAtLeastK)
//                {
//                    maxLen = Math.Max(maxLen, end - start);
//                }
//            }
//        }

//        return maxLen;
//    }
//}


//class Program
//{
//    public static void Main()
//    {
//        string str = "ababbc";

//        int k = 2;

//        Solution s = new Solution();

//        Console.WriteLine(s.LongestSubstring(str, k));
//    }
//}