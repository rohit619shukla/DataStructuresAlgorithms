//using System;
//using System.Collections.Generic;

//class TestArray
//{
//    public void RemoveDuplicates(int[] arr)
//    {
//        HashSet<int> set = new HashSet<int>();

//        for (int i = 0; i < arr.Length; i++)
//        {
//            if (!set.Contains(arr[i]))
//            {
//                set.Add(arr[i]);
//            }
//        }

//        Array.Resize(ref arr, set.Count);

//        int x = 0;

//        foreach (var item in set)
//        {
//            arr[x] = item;
//            Console.Write($"{arr[x]}" + " ");
//            x++;
//        }

//    }
//}

//class Program
//{
//    public static void Main()
//    {
//        int[] arr = { 1, 2, 2, 8, 7, 45, 10, 3, 3, 3, 29, 11, 10, 18, 11 };
//        TestArray tst = new TestArray();

//        tst.RemoveDuplicates(arr);
//    }
//}