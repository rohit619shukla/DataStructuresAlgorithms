//using System;
//using System.Collections.Generic;
//using System.Linq;

//class Tutorial
//{
//    public void PrintDuplicates(int[] arr)
//    {
//        if (arr.Length == 0 || arr == null)
//        {
//            return;
//        }

//        //Dictionary<int, int> d = new Dictionary<int, int>();

//        //for (int i = 0; i < arr.Length; i++)
//        //{
//        //    if (!d.ContainsKey(arr[i]))
//        //    {
//        //        d.Add(arr[i], 1);
//        //    }
//        //    else
//        //    {
//        //        d[arr[i]] = d[arr[i]] + 1;
//        //    }
//        //}

//        //for (int i = 0; i < d.Count; i++)
//        //{
//        //    if (d[arr[i]] > 1)
//        //    {
//        //        Console.Write($"{d.ElementAt(i).Key}" + " ");
//        //    }
//        //}

//        // subtract 1 from exisitng array element
//        for (int i = 0; i < arr.Length; i++)
//        {
//            arr[i] = arr[i] - 1;
//        }

//        for (int i = 0; i < arr.Length; i++)
//        {
//            arr[arr[i] % arr.Length] = arr[arr[i] % arr.Length] + arr.Length;
//        }

//        for (int i = 0; i < arr.Length; i++)
//        {
//            if (arr[i] / arr.Length > 1)
//            {
//                Console.WriteLine($"{i+1}: {arr[i] / arr.Length}");
//            }

//        }
//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        int[] arr = { 1, 2, 3, 4, 3, 2, 5, 6, 5, 8, 5 };

//        Tutorial t = new Tutorial();
//        t.PrintDuplicates(arr);
//    }
//}