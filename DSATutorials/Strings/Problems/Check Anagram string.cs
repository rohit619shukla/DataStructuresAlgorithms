//using System;
//using System.Collections.Generic;
//using System.ComponentModel;

//class AnagramHelper
//{
//    public bool AreAnagramOfEachOther(string s1, string s2)
//    {
//        if (string.IsNullOrEmpty(s1) || string.IsNullOrEmpty(s2))
//        {
//            return false;
//        }

//        if (s1.Length != s2.Length)
//        {
//            return false;
//        }

//        Dictionary<char, int> m1 = new Dictionary<char, int>();
//        Dictionary<char, int> m2 = new Dictionary<char, int>();

//        for (int i = 0; i < s1.Length; i++)
//        {
//            if (!m1.ContainsKey(s1[i]))
//            {
//                m1.Add(s1[i], 1);
//            }
//            else
//            {
//                m1[s1[i]]++;
//            }
//        }

//        for (int i = 0; i < s2.Length; i++)
//        {
//            if (!m2.ContainsKey(s2[i]))
//            {
//                m2.Add(s2[i], 1);
//            }
//            else
//            {
//                m2[s2[i]]++;
//            }
//        }

//        foreach (var item in m1)
//        {
//            char c = item.Key;
//            int freq = item.Value;

//            if (!m2.ContainsKey(c) || m2[c] != freq)
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
//        string s1 = "LLSTEN";
//        string s2 = "SILENT";

//        AnagramHelper a = new AnagramHelper();

//        /* Complexity : O(N) , Space : O(N) */
//        Console.WriteLine(a.AreAnagramOfEachOther(s1, s2));

//    }
//}

/* An anagram of a string is another string that contains the same
 * characters, only the order of characters can be different*/