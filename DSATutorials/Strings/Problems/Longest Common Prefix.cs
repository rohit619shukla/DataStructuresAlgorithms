//public class Solution
//{

//    // Time :O(N*M) since inner loop is dependent on outer loop, space :O(N)
//    public string LongestCommonPrefix(string[] strs)
//    {
//        // base case
//        if (strs == null || strs.Length == 0)
//        {
//            return string.Empty;
//        }

//        // Take the very first string as base and compare with all
//        string baseString = strs[0];

//        for (int i = 1; i < strs.Length; i++)
//        {
//            // ptr1 for base string and ptr2 for current compared string
//            int ptr = 0;

//            string compareString = strs[i];

//            while (ptr < baseString.Length && ptr < compareString.Length)
//            {
//                if (baseString[ptr] == compareString[ptr])
//                {
//                    ptr++;
//                }
//                else
//                {
//                    break;
//                }
//            }

//            baseString = baseString.Substring(0, ptr);
//        }

//        return baseString;
//    }
//}

//class Progam
//{
//    public static void Main()
//    {
//        string[] str = { "dog", "racecar", "car" };

//        Solution s = new Solution();

//        Console.WriteLine(s.LongestCommonPrefix(str));
//    }
//}