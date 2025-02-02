//using System;
//using System.Security.Cryptography;

//class Helper
//{
//    public void MinDifference(int[] arr, int key)
//    {
//        if (arr.Length == 0)
//        {
//            return;
//        }

//        if (key < arr[0])
//        {
//            Console.WriteLine($"{arr[0]}");
//            return;
//        }

//        // In case array is already sorted
//        if (key > arr[arr.Length - 1])
//        {
//            Console.WriteLine($"{arr[arr.Length - 1]}");
//            return;
//        }

//        int lb = 0;
//        int ub = arr.Length - 1;

//        while (lb <= ub)
//        {
//            int mid = (lb + ub) / 2;

//            if (arr[mid] == key)
//            {
//                Console.WriteLine($"min difference found : {arr[mid] - key}");
//                return;
//            }
//            else if (arr[mid] > key)
//            {
//                ub = mid - 1;
//            }
//            else
//            {
//                lb = mid + 1;
//            }
//        }

//        // Now both uper and lower bound has crossed each other and these numbers can be nearer to the target
//        if (Math.Abs(arr[ub] - key) < Math.Abs(arr[lb] - key))
//        {
//            Console.WriteLine($"{Math.Abs(arr[ub] - key)}");
//        }
//        else
//        {
//            Console.WriteLine($"{Math.Abs(arr[lb] - key)}");
//        }
//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        //int[] arr = { 2, 5, 10, 12, 15 };
//        int[] arr = { 1, 3, 8, 10, 15 };

//        Helper h = new Helper();
//        h.MinDifference(arr, 12);
//    }
//}

//// Complexity : O(Log N), space : O(1)