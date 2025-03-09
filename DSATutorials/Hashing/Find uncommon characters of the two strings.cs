//using System.Text;

//class Solution
//{
//    // Function to find and return the uncommon characters from the two strings.
//    public string uncommonChars(string s1, string s2)
//    {
//        int[] freq = new int[26];

//        StringBuilder sb = new StringBuilder();

//        for (int i = 0; i < s1.Length; i++)
//        {
//            freq[s1[i] - 'a']++;
//        }

//        for (int j = 0; j < s2.Length; j++)
//        {
//            freq[s2[j] - 'a']++;
//        }

//        for (int k = 0; k < 26; k++)
//        {
//            if (freq[k] == 1)
//            {
//                int index = k + 'a';
//                sb.Append((char)index);
//            }
//        }
//        return sb.ToString();
//    }
//}

//class Program
//{
//    public static void Main()
//    {
//        Solution s = new Solution();

//        string s1 = "rome";
//        string s2 = "more";

//        Console.WriteLine(s.uncommonChars(s1, s2));
//    }
//}