//using System;
//using System.Collections.Generic;

//class Helper
//{
//    public bool AreSame(int[] arr1, int[] arr2)
//    {
//        if (arr1.Length != arr2.Length)
//        {
//            return false;
//        }

//        Dictionary<int, int> map1 = new Dictionary<int, int>();
//        Dictionary<int, int> map2 = new Dictionary<int, int>();

//        foreach (var item in arr1)
//        {
//            if (map1.ContainsKey(item))
//            {
//                map1[item]++;
//            }
//            else
//            {
//                map1.Add(item, 1);
//            }
//        }

//        foreach (var item in arr2)
//        {
//            if (map2.ContainsKey(item))
//            {
//                map2[item]++;
//            }
//            else
//            {
//                map2.Add(item, 1);
//            }
//        }

//        foreach (var item in map2)
//        {
//            if (map1.ContainsKey(item.Key) && map1[item.Key] == map2[item.Key])
//            {
//                map1.Remove(item.Key);
//                map2.Remove(item.Key);
//            }
//            else
//            {
//                return false;
//            }
//        }

//        if (map1.Count != 0 || map2.Count != 0)
//        {
//            return false;
//        }
//        return true;
//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        int[] arr1 = { 1, 7, 1 };
//        int[] arr2 = { 7, 7, 1 };

//        Helper h = new Helper();

//        if (h.AreSame(arr1, arr2))
//        {
//            Console.WriteLine("Are same");
//        }
//        else
//        {
//            Console.WriteLine("Are not same");
//        }
//    }
//}

///* Complexity : O(N),space : O(N) */

///* If the elemnts in the array wont be repeated then we can simply XOR all elem in arr1 and arr2 and finally xor both
// .If the resutl is 0 the return true else false*/