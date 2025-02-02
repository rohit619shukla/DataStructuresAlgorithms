//using System;
//using System.Collections.Generic;
//class StringHelper
//{
//    public void LongestSubstringWithoutRepeatingCharcaters(string str)
//    {
//        if (string.IsNullOrWhiteSpace(str))
//        {
//            return;
//        }

//        Dictionary<char, int> map = new Dictionary<char, int>();

//        /* start of current substring */
//        int st = 0;

//        /* current length of the substring */
//        int currLen = 0;

//        /* max length of current substring */
//        int maxLen = 0;

//        /* start of the largest substring */
//        int start = 0;

//        map.Add(str[0], 0);
//        for (int i = 1; i < str.Length; i++)
//        {
//            if (!map.ContainsKey(str[i]))
//            {
//                map.Add(str[i], i);
//            }
//            else
//            {
//                if (map[str[i]] >= st)
//                {
//                    currLen = i - st;

//                    if (maxLen < currLen)
//                    {
//                        maxLen = currLen;
//                        start = st;
//                    }
//                    st = map[str[i]] + 1;
//                }

//                map[str[i]] = i;
//            }
//        }

//        while (maxLen > 0)
//        {
//            Console.Write($"{str[start]}" + " ");
//            start++;
//            maxLen--;
//        }
//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        string str = "GEEKSFORGEEKS";
//        StringHelper s = new StringHelper();

//        s.LongestSubstringWithoutRepeatingCharcaters(str);
//    }
//}

///* Complexity : O(N), space : O(N)*/