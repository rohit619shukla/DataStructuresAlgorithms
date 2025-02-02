//using System;
//using System.Collections.Generic;

//class Helper
//{
//    public void PrintSymmetricPairs(int[,] arr, int row)
//    {
//        if (arr.Length == 0)
//        {
//            return;
//        }

//        Dictionary<int, int> map = new Dictionary<int, int>();


//        for (int i = 0; i < row; i++)
//        {
//            int key = arr[i, 0];
//            int value = arr[i, 1];

//            if (map.ContainsKey(value))
//            {
//                if (map[value] == key)
//                {
//                    Console.WriteLine($"{value}  : {key}");
//                }
//            }
//            else
//            {
//                map.Add(key, value);
//            }
//        }
//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        Helper h = new Helper();

//        int[,] arr = {
//        {3, 4}, {1, 2}, {5, 2}, {7, 10}, {4, 3}, {2, 5}
//        };

//        h.PrintSymmetricPairs(arr, 6);
//    }
//}

///* Complexity : O(N), space : O(N) */