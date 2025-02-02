//using System;

//class Heap
//{
//    /// <summary>
//    /// Complexity : O(n) , space : O(1)
//    /// </summary>
//    /// <param name="arr"></param>
//    public int FindMaxInMinHeap(int[] heap)
//    {
//        int n = heap.Length;

//        // Start from the first leaf node
//        int start = n / 2;
//        int maxElement = heap[start];

//        // Loop through all leaf nodes to find the maximum
//        for (int i = start; i < n; i++)
//        {
//            if (heap[i] > maxElement)
//            {
//                maxElement = heap[i];
//            }
//        }

//        return maxElement;
//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        Heap h = new Heap();
//        int[] arr = { 1, 3, 5, 7, 9, 11, 13, 15, 17, 19 };
//        Console.WriteLine(h.FindMaxInMinHeap(arr));
//    }
//}