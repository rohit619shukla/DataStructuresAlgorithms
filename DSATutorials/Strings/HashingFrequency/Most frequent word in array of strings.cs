//using System;
//using System.Collections.Generic;
//class StringHelper
//{
//    public void MostFrequentWord(string[] arr)
//    {
//        if (arr == null || arr.Length == 0)
//        {
//            return;
//        }

//        Dictionary<string, int> map = new Dictionary<string, int>();

//        for (int i = 0; i < arr.Length; i++)
//        {
//            if (map.ContainsKey(arr[i]))
//            {
//                map[arr[i]]++;
//            }
//            else
//            {
//                map.Add(arr[i], 1);
//            }
//        }

//        string mostFrequentWord = "";
//        int freq = int.MinValue;

//        foreach (var item in map)
//        {
//            if (item.Value > freq)
//            {
//                mostFrequentWord = item.Key;
//                freq = item.Value;
//            }
//        }

//        Console.WriteLine(mostFrequentWord);
//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        string[] arr = { "geeks","for","zoom","a",
//        "s","to","learn","can",
//        "be","zoom","geeks",
//        "zoom","yup","fire","in",
//            "be","zoom","geeks"};


//        StringHelper s = new StringHelper();
//        s.MostFrequentWord(arr);
//    }
//}

//// Complexity : O(N), space : O(N)