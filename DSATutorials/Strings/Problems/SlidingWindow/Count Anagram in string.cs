//using System;
//using System.Collections.Generic;

//class StringHelper
//{
//    public IList<int> CountAnagram(string str, string ptrn, int k)
//    {
//        var temp = new List<int>();

//        // base conditions
//        if (string.IsNullOrWhiteSpace(str) ||
//            string.IsNullOrWhiteSpace(ptrn)
//            || str.Length < ptrn.Length)
//        {
//            return null;
//        }

//        /* Add frequency of all pattern char in Map */
//        Dictionary<char, int> map = new Dictionary<char, int>();

//        for (int i = 0; i < ptrn.Length; i++)
//        {
//            if (map.ContainsKey(ptrn[i]))
//            {
//                map[ptrn[i]]++;
//            }
//            else
//            {
//                map.Add(ptrn[i], 1);
//            }
//        }

//        int j = 0, start = 0, result = 0;

//        int count = map.Count;                /* Get the current frequency of the map*/

//        while (j < str.Length)
//        {
//            if (map.ContainsKey(str[j]))
//            {
//                map[str[j]]--;                     /* reduce the frequency of the number in map*/

//                if (map[str[j]] == 0)                /* If the frequency is 0 then the number is not available for use ,hence reduce count*/
//                {
//                    count--;
//                }
//            }

//            if (j - start + 1 < k)
//            {
//                j++;                                        /* till we get the window keep on pushing further*/
//            }
//            else if (j - start + 1 == k)
//            {
//                if (count == 0)                         /* we got all char covered between string and pattern*/
//                {
//                    result++;                           /* we found 1 match anagram*/
//                    temp.Add(start);
//                }

//                if (map.ContainsKey(str[start]))           /* before sliding window we see if we can use the start in further iteration*/
//                {
//                    map[str[start]]++;                    /* if yes then increment back the frequency of the number in map */

//                    if (map[str[start]] == 1)            /* if the frequeny is there atleast once then increase the count*/
//                    {
//                        count++;
//                    }
//                }
//                start++;
//                j++;
//            }
//        }

//        Console.WriteLine($"{result}");
//        return temp;
//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        string str = "cbaebabacd";
//        string ptrn = "abc";

//        StringHelper s = new StringHelper();
//        var result = s.CountAnagram(str, ptrn, ptrn.Length);

//        Console.WriteLine("Start index for every anagram is : ");
//        for (int i = 0; i < result.Count; i++)
//        {
//            Console.WriteLine($"{result[i]}");
//        }
//    }
//}

//// Complexity : O(N), space : O(N)