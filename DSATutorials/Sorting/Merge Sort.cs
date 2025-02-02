//using System;

//class Helper
//{
//    public void MergeSort(int[] arr, int lb, int ub, int[] b)
//    {
//        if (arr.Length == 0)
//        {
//            return;
//        }

//        if (lb < ub)
//        {
//            int mid = (lb + ub) / 2;
//            MergeSort(arr, lb, mid, b);
//            MergeSort(arr, mid + 1, ub, b);
//            Merge(arr, lb, ub, mid, b);
//        }
//    }
//    public void PrintArray(int[] arr)
//    {
//        for (int i = 0; i < arr.Length; i++)
//        {
//            Console.Write($"{arr[i]}" + " ");
//        }
//    }

//    private void Merge(int[] arr, int lb, int ub, int mid, int[] b)
//    {
//        int i = lb;
//        int j = mid + 1;
//        int k = lb;

//        while (i <= mid && j <= ub)
//        {
//            if (arr[i] > arr[j])
//            {
//                b[k] = arr[j];
//                j++;
//            }
//            else
//            {
//                b[k] = arr[i];
//                i++;
//            }
//            k++;
//        }

//        if (i > mid)
//        {
//            while (j <= ub)
//            {
//                b[k] = arr[j];
//                k++;
//                j++;
//            }
//        }
//         if (j > ub)
//        {
//            while (i <= mid)
//            {
//                b[k] = arr[i];
//                k++;
//                i++;
//            }
//        }

//        for (int x = lb; x <= ub; x++)
//        {
//            arr[x] = b[x];
//        }
//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        //int[] arr = { 64, 34, 25, 12, 22, 11, 90 };
//        int[] arr = { 1, 2, 3, 4, 5, 6, };
//        int[] b = new int[arr.Length];

//        Helper h = new Helper();

//        Console.WriteLine("Array before sorting is:");
//        h.PrintArray(arr);

//        Console.WriteLine("\nArray after sorting is:");
//        h.MergeSort(arr, 0, arr.Length - 1, b);

//        h.PrintArray(arr);

//    }
//}


//// Complexity :
//// Best : O(nlogn)
//// Worst : O(nlogn)