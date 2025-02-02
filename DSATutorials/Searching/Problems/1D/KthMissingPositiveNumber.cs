//public class Solution
//{
//    // Time : O(k+n), where k is missing numbers and n is size of array
//    //public int FindKthPositive(int[] arr, int k)
//    //{
//    //    int missingCount = 0; // Count of missing numbers found
//    //    int current = 1; // Start checking from 1
//    //    int index = 0; // Index for traversing the array

//    //    // Continue until we've found k missing numbers
//    //    while (true)
//    //    {
//    //        // Check if the current number matches the array element
//    //        if (index < arr.Length && arr[index] == current)
//    //        {
//    //            index++; // Move to the next element in the array
//    //        }
//    //        else
//    //        {
//    //            missingCount++; // Count this number as missing
//    //            if (missingCount == k)
//    //            {
//    //                return current; // Return the Kth missing number
//    //            }
//    //        }
//    //        current++; // Move to the next number
//    //    }
//    //}

//    public int FindKthPositive(int[] arr, int k)
//    {
//        int lb = 0, ub = arr.Length - 1;
//        int missing = 0;

//        while (lb <= ub)
//        {
//            int mid = lb + (ub - lb) / 2;
//            missing = arr[mid] - (mid + 1);

//            if (missing < k)
//                lb = mid + 1;
//            else
//                ub = mid - 1;
//        }

//        // After the binary search, calculate the k-th missing number
//        return ub + k + 1;
//    }

//}

//class Program
//{
//    public static void Main()
//    {
//        int[] arr = { 1, 2, 3, 4 };

//        Solution s = new Solution();
//        Console.WriteLine(s.FindKthPositive(arr, 2));
//    }
//}

//// Derivation for 2nd code:

//// We are basically finding : arr[ub] + k - missingnumber
//// Where missing number : arr[ub] - (ub +1) => arr[ub] - ub -1
//// hence : arr[ub] + K - (arr[ub] - ub -1)
//// hence : arr[ub] + K - arr[ub] + ub +1
//// We are left with  :  ub +1+k