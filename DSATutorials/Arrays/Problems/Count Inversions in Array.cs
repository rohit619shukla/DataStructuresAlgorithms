
//using System.Security.Cryptography;

//class Solution
//{
//    // Time: O(N^2) , space : O(1)
//    //public int CountInversion(int[] arr)
//    //{
//    //    int count = 0;

//    //    for (int i = 0; i < arr.Length - 1; i++)
//    //    {
//    //        for (int j = i + 1; j < arr.Length; j++)
//    //        {
//    //            if (arr[i] > arr[j])
//    //            {
//    //                count++;
//    //            }
//    //        }
//    //    }
//    //    return count;
//    //}


//    // Time :O(nlogn) , space :O(n)
//    public int CountInversion(int[] arr)
//    {
//        int[] temp = new int[arr.Length];

//        return MergeSort(0, arr.Length - 1, arr, temp);

//    }

//    private int MergeSort(int lb, int ub, int[] arr, int[] temp)
//    {
//        int count = 0;
//        if (lb < ub)
//        {
//            int mid = lb + (ub - lb) / 2;
//            count += MergeSort(lb, mid, arr, temp);
//            count += MergeSort(mid + 1, ub, arr, temp);
//            count += Merge(lb, mid, ub, arr, temp);
//        }

//        return count;
//    }

//    private int Merge(int lb, int mid, int ub, int[] arr, int[] temp)
//    {
//        int count = 0;
//        int i = lb;
//        int j = mid + 1;
//        int k = lb;

//        while (i <= mid && j <= ub)
//        {
//            if (arr[i] < arr[j])
//            {
//                temp[k] = arr[i];
//                i++;
//            }
//            else
//            {
//                temp[k] = arr[j];
//                count += mid - i + 1;
//                j++;

//            }
//            k++;
//        }

//        if (i > mid)
//        {
//            while (j <= ub)
//            {
//                temp[k] = arr[j];
//                j++;
//                k++;
//            }
//        }

//        if (j > ub)
//        {
//            while (i <= mid)
//            {
//                temp[k] = arr[i];
//                i++;
//                k++;
//            }
//        }

//        for (int x = lb; x <= ub; x++)
//        {
//            arr[x] = temp[x];
//        }

//        return count;
//    }
//}

//class Program
//{
//    public static void Main()
//    {
//        int[] arr = { 4, 3, 2, 1 };

//        Solution s = new Solution();
//        Console.WriteLine(s.CountInversion(arr));
//    }
//}

// The idea here is : if a number on first array is greater then number on second array then all the numbers to right of the element in first array will also 
// be greater then number on second array itslef.