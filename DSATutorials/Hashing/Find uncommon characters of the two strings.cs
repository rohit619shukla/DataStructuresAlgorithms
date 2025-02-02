//using System;
//using System.Collections.Generic;
//using System.Linq;

//class Helper
//{
//    /* Complexity : O(m+n) , space : O(N) */
//    //public void PrintUnCommonCharcters(string s1, string s2)
//    //{
//    //    if (string.IsNullOrWhiteSpace(s1) && string.IsNullOrWhiteSpace(s2))
//    //    {
//    //        return;
//    //    }

//    //    if (string.IsNullOrWhiteSpace(s1) && !string.IsNullOrWhiteSpace(s2))
//    //    {
//    //        Console.WriteLine($"{s2}");
//    //    }

//    //    if (!string.IsNullOrWhiteSpace(s1) && string.IsNullOrWhiteSpace(s2))
//    //    {
//    //        Console.WriteLine($"{s1}");
//    //    }

//    //    HashSet<char> map1 = new HashSet<char>();
//    //    HashSet<char> map2 = new HashSet<char>();

//    //    for (int i = 0; i < s1.Length; i++)
//    //    {
//    //        if (!map1.Contains(s1[i]))
//    //        {
//    //            map1.Add(s1[i]);
//    //        }
//    //    }

//    //    for (int i = 0; i < s2.Length; i++)
//    //    {
//    //        if (!map2.Contains(s2[i]))
//    //        {
//    //            map2.Add(s2[i]);
//    //        }
//    //    }

//    //    foreach (var item in map1.ToHashSet())
//    //    {
//    //        if (map2.Contains(item))
//    //        {
//    //            map1.Remove(item);
//    //            map2.Remove(item);
//    //        }
//    //    }

//    //    foreach (var item in map1)
//    //    {
//    //        Console.Write($"{item}" + " ");
//    //    }

//    //    foreach (var item in map2)
//    //    {
//    //        Console.Write($"{item}" + " ");
//    //    }
//    //}

//    /* Complexity : O(M+N), space : O(1) */
//    public void PrintUnCommonCharcters(string s1, string s2)
//    {
//        int[] alpha = new int[26];

//        /* Mark all char in s1 as 1 in array according to char position */
//        for (int i = 0; i < s1.Length; i++)
//        {
//            alpha[s1[i] - 'a'] = 1;
//        }

//        /* Mark all char in s2 as -1 if they already have been visited in s1 or mark them as 2 */
//        for (int i = 0; i < s2.Length; i++)
//        {
//            if (alpha[s2[i] - 'a'] == 1 || alpha[s2[i] - 'a'] == -1)
//            {
//                alpha[s2[i] - 'a'] = -1;
//            }
//            else
//            {
//                alpha[s2[i] - 'a'] = 2;
//            }
//        }

//        /* Print all characters in alpha marked as 1 or 2 */
//        for (int i = 0; i < alpha.Length; i++)
//        {
//            if (alpha[i] == 1 || alpha[i] == 2)
//            {
//                Console.Write($"{(char)(97 + i)}" + " ");
//            }
//        }
//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        string s1 = "geeksforgeeks";
//        string s2 = "geeksquiz";

//        Helper h = new Helper();
//        h.PrintUnCommonCharcters(s1, s2);
//    }
//}