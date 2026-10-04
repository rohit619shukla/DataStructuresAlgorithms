// class Solution
// {
//     public int inversionCount(int[] arr)
//     {
//         // Count inversions while sorting the array with merge sort.
//         // Time: O(n log n). Space: O(n) for the reusable merge buffer
//         // and O(log n) for the recursion stack.
//         int[] result = new int[arr.Length];
//         int count = MergeSort(arr, result, 0, arr.Length - 1);

//         return count;

//     }

//     private int MergeSort(int[] arr, int[] result, int lb, int ub)
//     {
//         int count = 0;

//         if (lb < ub)
//         {
//             int mid = lb + (ub - lb) / 2;

//             count += MergeSort(arr, result, lb, mid);
//             count += MergeSort(arr, result, mid + 1, ub);
//             count += Merge(arr, result, lb, mid, ub);
//         }

//         return count;
//     }

//     private int Merge(int[] arr, int[] result, int lb, int mid, int ub)
//     {
//         int count = 0;

//         int k = lb;
//         int i = lb;
//         int j = mid + 1;

//         while (i <= mid && j <= ub)
//         {
//             if (arr[i] <= arr[j])
//             {
//                 result[k] = arr[i];
//                 i++;
//                 k++;
//             }
//             else
//             {
//                 result[k] = arr[j];
//                 // arr[j] is smaller than every remaining element in the left half,
//                 // so each element from i through mid forms an inversion with arr[j].
//                 count += (mid - i + 1);
//                 j++;
//                 k++;
//             }
//         }

//         if (i > mid)
//         {
//             while (j <= ub)
//             {
//                 result[k] = arr[j];
//                 j++;
//                 k++;
//             }
//         }

//         if (j > ub)
//         {
//             while (i <= mid)
//             {
//                 result[k] = arr[i];
//                 i++;
//                 k++;
//             }
//         }

//         for (int x = lb; x <= ub; x++)
//         {
//             arr[x] = result[x];
//         }

//         return count;

//     }
// }


// class Program
// {
//     public static void Main()
//     {
//         int[] arr = { 10, 10, 10 };

//         Solution s = new Solution();

//         Console.WriteLine($"{s.inversionCount(arr)}");
//     }
// }