//using System;

//class Helper
//{
//    public int SearchElement(int[] arr, int num)
//    {
//        if (arr.Length == 0)
//        {
//            return -1;
//        }

//        int lb = 0;
//        int ub = arr.Length - 1;

//        while (lb <= ub)
//        {
//            int mid = (lb + ub) / 2;

//            /* We got the element, return from here */
//            if (num == arr[mid])
//            {
//                return mid;
//            }

//            /* the element could be at i-1 location and making sure we dont underflow */
//            if (mid >= lb && num == arr[mid - 1])
//            {
//                return mid - 1;
//            }

//            /* the element could be at i+1 location and making sure we dont overflow */
//            if (mid <= ub && num == arr[mid + 1])
//            {
//                return mid + 1;
//            }

//            /* Usual binary search and since we have searched i-1 hence w got for +2 and -2  */
//            if (num > arr[mid])
//            {
//                lb = mid + 2;
//            }
//            else
//            {
//                ub = mid - 2;
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
//        int[] arr = { 10, 3, 40, 20, 50, 80, 70 };

//        Console.WriteLine($"{h.SearchElement(arr, 40)}");
//    }
//}