//public class Solution
//{
//    public IList<int> FindAnagrams(string str, string pat)
//    {
//        // to store the indices of the start of anagram
//        List<int> result = new List<int>();


//        // Step 1: create a freuency array of size 26 for all lower char
//        int[] freq = new int[26];

//        // Step 2: fill the frequency array for pattern
//        for (int k = 0; k < pat.Length; k++)
//        {
//            freq[pat[k] - 'a']++;
//        }

//        // Step 3: Sliding window solution begins
//        int i = 0, j = 0, windowSize = pat.Length;


//        while (j < str.Length)
//        {
//            // Step 4: decrement the frequency of char
//            freq[str[j] - 'a']--;

//            // check for window size
//            if (j - i + 1 == windowSize)
//            {
//                // check if all zero in the given window
//                if (IsAllZero(freq))
//                {
//                    result.Add(i);
//                }

//                // Move the window, but first make sure to restore the frequency of the char being removed from window
//                freq[str[i] - 'a']++;

//                i++;
//            }

//            j++;
//        }
//        return result;
//    }

//    private bool IsAllZero(int[] freq)
//    {
//        for (int i = 0; i < freq.Length; i++)
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
//        string str = "cbaebabacd";
//        string ptrn = "abc";

//        Solution s = new Solution();
//        var result = s.FindAnagrams(str, ptrn);

//        Console.WriteLine("Start index for every anagram is : ");
//        for (int i = 0; i < result.Count; i++)
//        {
//            Console.WriteLine($"{result[i]}");
//        }
//    }
//}

//// Complexity : O(N), space : O(N)