//using System;


//class Helper
//{
//    // Time : O(N^2)  : as we are moving to left and right of every cell and getting min and max
//    // Space: O(1)
//    // Creates TLE in leetcode
//    //public int Solve(int[] heights)
//    //{
//    //    // We need more than 2 buildings to store some water
//    //    if (heights == null || heights.Length <= 2)
//    //    {
//    //        return 0;
//    //    }

//    //    int totSum = 0;

//    //    // We will start from index 1 as at 0 it will flow out
//    //    // for every index we will try to figure out max left and max right
//    //    for (int i = 1; i < heights.Length; i++)
//    //    {
//    //        int maxLeft = 0;
//    //        int maxRight = 0;

//    //        for (int left = i; left >= 0; left--)
//    //        {
//    //            maxLeft = Math.Max(heights[left], maxLeft);
//    //        }

//    //        for (int right = i; right < heights.Length; right++)
//    //        {
//    //            maxRight = Math.Max(heights[right], maxRight);
//    //        }

//    //        totSum += Math.Min(maxLeft, maxRight) - heights[i];
//    //    }

//    //    return totSum;
//    //}


//    // Time : O(N) 
//    // Space: O(N)
//    // Passed  in leetcode
//    //public int Solve(int[] height)
//    //{
//    //    if (height == null || height.Length <= 0)
//    //    {
//    //        return 0;
//    //    }

//    //    int[] maxLeft = new int[height.Length];
//    //    int[] maxRight = new int[height.Length];

//    //    maxLeft[0] = height[0];
//    //    maxRight[height.Length - 1] = height[height.Length - 1];

//    //    int totSum = 0;

//    //    for (int i = 1; i < height.Length; i++)
//    //    {
//    //        maxLeft[i] = Math.Max(maxLeft[i - 1], height[i]);
//    //    }

//    //    for (int j = height.Length - 2; j >= 0; j--)
//    //    {
//    //        maxRight[j] = Math.Max(maxRight[j + 1], height[j]);
//    //    }


//    //    for (int k = 0; k < height.Length; k++)
//    //    {
//    //        totSum += Math.Min(maxLeft[k], maxRight[k]) - height[k];
//    //    }

//    //    return totSum;
//    //}


//    // Time : O(N) 
//    // Space: O(1)
//    public int Solve(int[] heights)
//    {
//        int totSum = 0;
//        int leftMax = 0;
//        int rightMax = 0;
//        int left = 0;
//        int right = heights.Length - 1;

//        // Move forward till both converge
//        while (left < right)
//        {
//            // If we come across a tall building
//            if (heights[left] < heights[right])
//            {
//                if (heights[left] > leftMax)
//                {
//                    leftMax = heights[left];
//                }
//                else
//                {
//                    totSum += leftMax - heights[left];
//                }
//                left++;
//            }
//            else
//            {
//                if (heights[right] > rightMax)
//                {
//                    rightMax = heights[right];
//                }
//                else
//                {
//                    totSum += rightMax - heights[right];
//                }
//                right--;
//            }
//        }

//        return totSum;
//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        int[] height = { 4, 2, 0, 6, 2, 3, 5 };

//        Helper h = new Helper();
//        Console.WriteLine(h.Solve(height));
//    }
//}


//// This question can be solved with Histogram approach.