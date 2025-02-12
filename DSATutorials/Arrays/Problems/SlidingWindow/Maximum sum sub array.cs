//using System;

//class Tutorial
//{
//    // Kadane algorithm
//    public int LargestSumSubArray(int[] nums)
//    {
//        if (nums == null || nums.Length == 0)
//        {
//            return 0;
//        }

//        int currentSum = 0, maxSum = int.MinValue, start = 0, end = 0, s = 0;

//        for (int i = 0; i < nums.Length; i++)
//        {
//            currentSum += nums[i];

//            // We got new max
//            if (currentSum > maxSum)
//            {
//                maxSum = currentSum;
//                start = s;
//                end = i;
//            }

//            // reset to zero
//            if (currentSum < 0)
//            {
//                currentSum = 0;
//                s = i + 1;
//            }
//        }

//        for (int i = start; i <= end; i++)
//        {
//            Console.Write($"{nums[i]}" + " ");
//        }

//        return maxSum;
//    }
//}

//class Program
//{
//    public static void Main()
//    {
//        Tutorial t = new Tutorial();
//        int[] a = { -2, 1, -3, 4, -1, 2, 1, -5, 4 };

//        Console.WriteLine(t.LargestSumSubArray(a));
//    }
//}

////Complexity: O(N), space: O(1)