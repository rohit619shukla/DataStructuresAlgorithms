//public class Solution
//{
//    // Time : O(N^2) , space :O(1)
//    public int BeautySum(string str)
//    {
//        int beauty = 0;

//        // Start with 2 pointers to compute the substring at every interval
//        for (int i = 0; i < str.Length; i++)
//        {
//            // create a frequency map for each substring
//            int[] freq = new int[26];


//            // As you move compute the beauty
//            for (int j = i; j < str.Length; j++)
//            {
//                freq[str[j] - 'a']++;

//                // Compute beauty
//                int max = int.MinValue;
//                int min = int.MaxValue;

//                for (int k = 0; k < 26; k++)
//                {
//                    if (freq[k] > 0)
//                    {
//                        max = Math.Max(freq[k], max);
//                        min = Math.Min(freq[k], min);
//                    }
//                }

//                beauty += max - min;
//            }
           
//        }

//        return beauty;
//    }
//}

//class Program
//{
//    public static void Main()
//    {
//        string str = "aabcb";

//        Solution s = new Solution();

//        Console.WriteLine(s.BeautySum(str));
//    }
//}