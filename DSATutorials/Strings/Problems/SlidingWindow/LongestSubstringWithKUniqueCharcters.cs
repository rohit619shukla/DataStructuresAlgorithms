//public class Solution
//{
//    // Time : O(26N) = O(N) , space :O(1)
//    public int LongestSubstring(string str, int k)
//    {
//        // We will iterate over all the unique alphabets in English language, to restrict chances of encountering an invalid substring

//        int maxLen = 0;
//        for (int uniqueCharTarget = 1; uniqueCharTarget <= 26; uniqueCharTarget++)
//        {
//            int length = str.Length;
//            int start = 0, end = 0;   // two pointers to slide the window
//            int uniqueCount = 0, countAtleastK = 0;

//            // We will store the frequency of each character in the string as all the characters are lowercase alphabets
//            int[] freq = new int[26];
//            // We will try to find the longest substring with k unique characters in the range of 1 to 26
//            // Iterate till will reach the end of the string
//            while (end < length)
//            {
//                // Increase the window till we are within the range
//                if (uniqueCount <= uniqueCharTarget)
//                {
//                    // get the index of the charcater
//                    int idx = str[end] - 'a';

//                    // if its the first time we are encountring this character, increase the unique count
//                    if (freq[idx] == 0)
//                    {
//                        uniqueCount++;
//                    }

//                    // Increase the frequency of the character 
//                    freq[idx]++;

//                    // If the frequency of the character is equal to k(satisfies the condition), increase the countAtleastK
//                    if (freq[idx] == k)
//                    {
//                        countAtleastK++;
//                    }

//                    // keep moving the window
//                    end++;
//                }
//                else
//                {
//                    // Decrease the window  if we are out of range as we got another qunique character which was not supposed to be part of the given range
//                    // get the index of the charcater
//                    int idx = str[start] - 'a';

//                    // The charcater at start will now become invalid and needs to be removed from window
//                    if (freq[idx] == k)
//                    {
//                        countAtleastK--;
//                    }

//                    // Reduce the frequency of the character
//                    freq[idx]--;

//                    // If the frequency of the character is 0, decrease the unique count
//                    if (freq[idx] == 0)
//                    {
//                        uniqueCount--;
//                    }

//                    start++; // shrink the window
//                }

//                // Decide on maxlen
//                if (uniqueCount == uniqueCharTarget && uniqueCount == countAtleastK)
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
//        string str = "aaabb";
//        int k = 3;

//        Solution s = new Solution();

//        Console.WriteLine(s.LongestSubstring(str, k));
//    }
//}