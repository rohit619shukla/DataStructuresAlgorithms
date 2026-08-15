//using System;

//class Helper
//{
//    // Log(n) : as the value of ub is growing exponentially or doubling 1,2,4,8..
//    public int SearchElement(int[] arr, int num)
//    {
//        if (arr.Length == 0)
//        {
//            return -1;
//        }

//        int lb = 0;
//        int ub = 1;

//        while (arr[ub] < num)
//        {
//            lb = ub;
//            ub = 2 * ub;
//        }
//        return BinarySearch(arr, lb, ub, num);
//    }

//    public int BinarySearch(int[] arr, int lb, int ub, int key)
//    {
//        while (lb <= ub)
//        {
//            int mid = (lb + ub) / 2;

//            if (key == arr[mid])
//            {
//                return mid;
//            }

//            if (key < arr[mid])
//            {
//                ub = mid - 1;
//            }
//            else
//            {
//                lb = mid + 1;
//            }
//        }
//        return -1;
//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        Helper h = new Helper();

//        int[] arr = new int[]{3, 5, 7, 9,
//            10, 90, 100, 130, 140, 160, 170};

//        int result = h.SearchElement(arr, 10);

//        if (result == -1)
//        {
//            Console.WriteLine("Element not found");
//        }
//        else
//        {
//            Console.WriteLine($"Element found at position : {result}");
//        }
//    }
//}

///* Complexity : O(LogN) , space : O(1) */