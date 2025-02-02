//using System;
//using System.Collections.Generic;

//class Helper
//{
//    public bool IsSubset(int[] arr1, int[] arr2)
//    {
//        if (arr1.Length == 0 || arr2.Length == 0)
//        {
//            return false;
//        }

//        if (arr1.Length < arr2.Length)
//        {
//            return false;
//        }

//        Dictionary<int, int> map1 = new Dictionary<int, int>();
//        Dictionary<int, int> map2 = new Dictionary<int, int>();

//        for (int i = 0; i < arr1.Length; i++)
//        {
//            if (map1.ContainsKey(arr1[i]))
//            {
//                map1[arr1[i]]++;
//            }
//            else
//            {
//                map1.Add(arr1[i], 1);
//            }
//        }

//        for (int i = 0; i < arr2.Length; i++)
//        {
//            if (map2.ContainsKey(arr2[i]))
//            {
//                map2[arr2[i]]++;
//            }
//            else
//            {
//                map2.Add(arr2[i], 1);
//            }
//        }

//        foreach (var item in map2)
//        {
//            if (map1.ContainsKey(item.Key))
//            {
//                if (map1[item.Key] != item.Value)
//                {
//                    return false;
//                }
//            }
//            else
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

//        Helper h = new Helper();

//        int[] arr1 = { 10, 5, 2, 2, 19 };
//        int[] arr2 = { 19, 2,5, 2 };

//        if (h.IsSubset(arr1, arr2))
//        {
//            Console.WriteLine("Is subset");
//        }
//        else
//        {
//            Console.WriteLine("Is not subset");
//        }
//    }
//}

///* Complexity : O(N), space : O(N) */