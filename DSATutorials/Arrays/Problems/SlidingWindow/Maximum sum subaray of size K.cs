
//class Solution
//{
//    // Time : O(n) , space :O(1)
//    public void MaxiMumSum(int[] arr, int k)
//    {
//        int currSum = 0, maxSum = 0, i = 0;

//        for (int j = 0; j < arr.Length; j++)
//        {
//            currSum += arr[j];

//            // If we have hit the window then do following
//            if (j - i + 1 == k)
//            {
//                // Check if we have got new max
//                maxSum = Math.Max(maxSum, currSum);

//                // remove what was accumulated in the given subarray to make space for new
//                currSum -= arr[i];
//                i++;
//            }
//        }

//        Console.WriteLine(maxSum);
//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        int[] arr = { 1, 4, 2, 10, 23, 3, 1, 0, 20 };

//        Solution s = new Solution();

//        s.MaxiMumSum(arr, 4);
//    }
//}