//using System;
//using System.Collections.Generic;

//class Isomorphic
//{
//    public bool AreIsmorphic(string s1, string s2)
//    {
//        Dictionary<char, char> map;

//        if (s1.Length != s2.Length)
//        {
//            return false;
//        }

//        map = new Dictionary<char, char>();

//        for (int i = 0; i < s1.Length; i++)
//        {
//            if (!map.ContainsKey(s1[i]))
//            {
//                map.Add(s1[i], s2[i]);
//            }
//            else if (map[s1[i]] != s2[i])
//            {
//                return false;
//            }
//        }

//        // Other way round
//        map.Clear();

//        for (int i = 0; i < s2.Length; i++)
//        {
//            if (!map.ContainsKey(s2[i]))
//            {
//                map.Add(s2[i], s1[i]);
//            }
//            else if (map[s2[i]] != s1[i])
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
//        string str1 = "aab";
//        string str2 = "xyz";

//        Isomorphic iso = new Isomorphic();
//        Console.WriteLine($"{iso.AreIsmorphic(str1, str2)}");
//    }
//}

// Complexity : O(N), spcae : O(N)