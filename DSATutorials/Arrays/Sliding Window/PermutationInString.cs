//public class Solution
//{
//    public bool CheckInclusion(string s1, string s2)
//    {
//        if (s1.Length >s2.Length)
//        {
//            return false;
//        }
//        string pattern = s1;

//        // Create a frequecny array to store the frequency of each character in the pattern
//        int[] freq = new int[26];

//        for (int k = 0; k < pattern.Length; k++)
//        {
//            freq[pattern[k] - 'a']++;
//        }

//        // start sliding window
//        int i = 0, j = 0, windowSize = pattern.Length;

//        int count = 0;
//        while (j < s2.Length)
//        {
//            // Decerement the frequency of the character at the start of the window
//            freq[s2[j] - 'a']--;

//            if (j - i + 1 == windowSize)
//            {
//                // Check if we have observed all the elements in frequcy array
//                if (AllZero(freq))
//                {
//                    count++;
//                }

//                // before sliding the window make sure to restore
//                freq[s2[i] - 'a']++;
//                i++;
//            }

//            j++;
//        }
//        return count > 0 ? true : false;
//    }

//    private bool AllZero(int[] freq)
//    {
//        for (int i = 0; i < 26; i++)
//        {
//            if (freq[i] != 0)
//            {
//                return false;
//            }
//        }
//        return true;
//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        Solution solution = new Solution();
//        string s1 = "ab";
//        string s2 = "eidbaooo";
//        bool result = solution.CheckInclusion(s1, s2);
//        Console.WriteLine(result);
//    }
//}