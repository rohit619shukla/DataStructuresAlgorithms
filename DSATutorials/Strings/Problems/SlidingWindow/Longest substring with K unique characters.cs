//using System;
//using System.Collections.Generic;

//class StringHelper
//{
//    public void LongestSubstring(string str, int k)
//    {
//        if (string.IsNullOrWhiteSpace(str) ||
//            k > str.Length)
//        {
//            return;
//        }

//        Dictionary<char, int> map = new Dictionary<char, int>();

//        int maxlen = int.MinValue;
//        int start = 0;
//        int end = 0;
//        int st = 0;
//        for (int i = 0; i < str.Length; i++)
//        {
//            if (!map.ContainsKey(str[i]))
//            {
//                map.Add(str[i], 1);
//            }
//            else
//            {
//                map[str[i]]++;
//            }

//            while (map.Count > k)
//            {
//                map[str[start]]--;

//                if (map[str[start]] == 0)
//                {
//                    map.Remove(str[start]);
//                }
//                start++;
//            }

//            if (map.Count == k)
//            {
//                if (maxlen < (i - start + 1))
//                {
//                    maxlen = i - start + 1;
//                    end = i;
//                    st = start;
//                }
//            }
//        }

//        for (int i = st; i <= end; i++)
//        {
//            Console.Write($"{str[i]}" + " ");
//        }
//        Console.WriteLine();
//        Console.WriteLine(maxlen);
//    }

//}
//class Program
//{
//    public static void Main()
//    {
//        string str = "aabbcc";
//        int k = 3;

//        StringHelper s = new StringHelper();
//        s.LongestSubstring(str, k);
//    }
//}

//// Complexty : O(N), space :O(N)