

//class Solution
//{
//    public double FindMedianSortedArrays(int[] arr1, int[] arr2)
//    {
//        // We will perform BS only on smallest array  as BS works well when size is low
//        if (arr1.Length > arr2.Length)
//        {
//            //FindMedianSortedArrays(arr2, arr2);
//            Swap(ref arr1, ref arr2);
//        }

//        int arr1Length = arr1.Length;
//        int arr2Length = arr2.Length;

//        int lb = 0;
//        int ub = arr1Length;

//        while (lb <= ub)
//        {
//            // We will calculate mid point for both arrays.
//            // Basically we are performing BS on small array and arr2 we use special formula for get a mid point with +1 as it works well for even and odd cases both
//            int mid1 = lb + (ub - lb) / 2;
//            int mid2 = (arr1Length + arr2Length + 1) / 2 - mid1;

//            // Get max and min for both both the arrays
//            // We will always get min from right side and max from left side as both the arrays are already sorted.
//            // This is interesting case to handle edge cases
//            int maxLeftOfArr1 = (mid1 == 0) ? int.MinValue : arr1[mid1 - 1];
//            int minRightOfArr1 = (mid1 == arr1Length) ? int.MaxValue : arr1[mid1];

//            int maxLeftOfArr2 = (mid2 == 0) ? int.MinValue : arr2[mid2 - 1];
//            int minRightOfArr2 = (mid2 == arr2Length) ? int.MaxValue : arr2[mid2];

//            // Now check if we have found the median with following formula
//            if (maxLeftOfArr1 <= minRightOfArr2 && maxLeftOfArr2 <= minRightOfArr1)
//            {
//                // Check for even and odd cases of array length
//                if ((arr1Length + arr2Length) % 2 == 0)
//                {
//                    return ((double)(Math.Max(maxLeftOfArr1, maxLeftOfArr2) + Math.Min(minRightOfArr1, minRightOfArr2)) / 2);
//                }
//                else
//                {
//                    return (double)Math.Max(maxLeftOfArr1, maxLeftOfArr2);
//                }
//            }
//            else if (maxLeftOfArr1 > minRightOfArr2)
//            {
//                ub = mid1 - 1;
//            }
//            else if (maxLeftOfArr2 > minRightOfArr1)
//            {
//                lb = mid1 + 1;
//            }
//            else
//            {
//                break;
//            }
//        }
//        return 0.0;
//    }

//    private void Swap(ref int[] num1, ref int[] num2)
//    {
//        int[] temp = num1;
//        num1 = num2;
//        num2 = temp;
//    }
//}

//class Program
//{
//    public static void Main()
//    {
//        int[] arr1 = { 1, 3, 8, 9, 15 };
//        int[] arr2 = { 7, 11, 18, 19, 21, 25 };
//        //int[] arr1 = { 1, 3 };
//        //int[] arr2 = { 2 };

//        Solution s = new Solution();

//        Console.WriteLine(s.FindMedianSortedArrays(arr1, arr2));
//    }
//}

//// Time : O(log(min(x,y))) , space : O(1)
//// For odd array the median will be the middle element, for even it will be 2 elements/2