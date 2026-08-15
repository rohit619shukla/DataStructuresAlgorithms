//public class Solution
//{

//    //Time : O(n) , space :O(1)
//    //public bool IsAnagram(string str, string target)
//    //{
//    //    // base case
//    //    if (str.Length != target.Length)
//    //    {
//    //        return false;
//    //    }
//    //    // create an array of 26 characters in english
//    //    int[] ch = new int[26];

//    //    // Iterate over every character and update the char array with 1
//    //    for (int i = 0; i < str.Length; i++)
//    //    {
//    //        ch[str[i] - 'a']++;
//    //        ch[target[i] - 'a']--;
//    //    }

//    //    for (int i = 0; i < 26; i++)
//    //    {
//    //        if (ch[i] != 0)
//    //        {
//    //            return false;
//    //        }
//    //    }
//    //    return true;
//    //}

//    //Note : for unicode solution
//    public bool IsAnagram(string str, string target)
//    {
//        // base case
//        if (str.Length != target.Length)
//        {
//            return false;
//        }

//        int[] ch = new int[128];

//        for (int i = 0; i < str.Length; i++)
//        {
//            // Since the size of array is 128 so we dont need to subtract 'a' from the given charcater, plus there could be random chars in between
//            ch[str[i]]++;
//            ch[target[i]]--;
//        }

//        for (int i = 0; i < ch.Length; i++)
//        {
//            if (ch[i] != 0)
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
//        string str = "anagram";
//        string target = "nagaram";

//        Solution s = new Solution();

//        Console.WriteLine(s.IsAnagram(str, target));
//    }
//}