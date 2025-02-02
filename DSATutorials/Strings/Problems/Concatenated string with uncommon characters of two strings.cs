//using System;
//using System.Collections.Generic;
//class StringHelper
//{
//    public string ConcatenateStringByRemovingDuplicates(string s1, string s2)
//    {
//        if (string.IsNullOrWhiteSpace(s1) && string.IsNullOrWhiteSpace(s2))
//        {
//            return null;
//        }
//        else if (string.IsNullOrWhiteSpace(s2))
//        {
//            return s1;
//        }
//        else if (string.IsNullOrWhiteSpace(s1))
//        {
//            return s2;
//        }
//        else
//        {
//            string result = "";
//            string str = s1 + s2;

//            Dictionary<char, int> map = new Dictionary<char, int>();

//            for (int i = 0; i < str.Length; i++)
//            {
//                if (map.ContainsKey(str[i]))
//                {
//                    map[str[i]]++;
//                }
//                else
//                {
//                    map.Add(str[i], 1);
//                }
//            }

//            foreach (var item in map)
//            {
//                if (item.Value == 1)
//                {
//                    result += item.Key;
//                }
//            }

//            return result;
//        }
//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        string s1 = "abcs";
//        string s2 = "cxzca";

//        StringHelper s = new StringHelper();
//        Console.WriteLine($"{s.ConcatenateStringByRemovingDuplicates(s1, s2)}");
//    }
//}

//// Complxeity : O(N), space : O(N)