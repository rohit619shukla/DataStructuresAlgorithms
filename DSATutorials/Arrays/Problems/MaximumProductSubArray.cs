
//public class Solution
//{
//    // TIme : O(n) . space :O(1)
//    public int MaxProduct(int[] nums)
//    {
//        int leftProduct = 1, rightProduct = 1, maxProduct = nums[0], n = nums.Length;
//        for (int i = 0; i < n; i++)
//        {
//            leftProduct = leftProduct == 0 ? 1 : leftProduct;
//            rightProduct = rightProduct == 0 ? 1 : rightProduct;
//            leftProduct *= nums[i];
//            rightProduct *= nums[n - 1 - i];
//            maxProduct = Math.Max(maxProduct, Math.Max(leftProduct, rightProduct));
//        }
//        return maxProduct;
//    }


//    //public int MaxProduct(int[] nums)
//    //{
//    //    int n = nums.Length;
//    //    int maxProduct = 0; // Initialize with the smallest integer

//    //    // Iterate through all subarray start points
//    //    for (int i = 0; i < n; i++)
//    //    {
//    //        int currentProduct = 1; // Initialize product for the current subarray

//    //        // Calculate product for all subarrays starting at index 'i'
//    //        for (int j = i; j < n; j++)
//    //        {
//    //            currentProduct *= nums[j]; // Multiply by the current element
//    //            maxProduct = Math.Max(maxProduct, currentProduct); // Update maximum product
//    //        }
//    //    }

//    //    return maxProduct; // Return the maximum product found
//    //}
//}

//class Program
//{
//    public static void Main()
//    {


//        int[] arr = { 2, 3, -2, 4 };

//        Solution s = new Solution();

//        Console.WriteLine(s.MaxProduct(arr));
//    }
//}