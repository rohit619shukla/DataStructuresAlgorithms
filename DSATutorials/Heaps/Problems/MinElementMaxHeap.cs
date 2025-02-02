//using System;

//class Heap
//{
//    //    /// <summary>
//    //    /// Complexity : O(n)
//    //    /// </summary>
//    //    /// <param name="arr"></param>
//    public void MinElement(int[] arr)
//    {
//        int min = int.MaxValue;

//        int heapSize = arr.Length;

//        for (int i = heapSize / 2; i < heapSize; i++)
//        {
//            if (arr[i] < min)
//            {
//                min = arr[i];
//            }
//        }

//        Console.WriteLine(min);
//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        int[] arr = { 20, 18, 10, 12, 9, 9, 3, 5, 6, 8 };
//        Heap h = new Heap();
//        h.MinElement(arr);
//    }
//}