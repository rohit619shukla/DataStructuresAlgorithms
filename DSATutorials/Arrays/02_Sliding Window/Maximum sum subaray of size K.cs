// class Solution
// {
//     // Time : O(n) , space :O(1)

//     public int maxSubarraySum(int[] arr, int k)
//     {
//         // Code here

//         // 1. Get the size of the array
//         int size = arr.Length;

//         // 2. Set start and end pointers
//         int start = 0, end = 0;

//         // 3. Keep track of what is max
//         int max = int.MinValue;

//         // 4. Current sum so far
//         int sumSoFar = 0;

//         // we will iterate over the array till have something to iterate
//         while (end < size)
//         {
//             //Console.Write($" Accumulated : {arr[end]}" + " ");
//             // Keep accumulating the sum
//             sumSoFar += arr[end];

//             // If we have hit a window then make sure to capture data
//             if (end - start + 1 == k)
//             {
//                 max = Math.Max(sumSoFar, max);

//                 // make sure to remove the element from start as now the window will move
//                 sumSoFar -= arr[start];

//                 //Console.Write($" , Removed : {arr[start]}" + " ");
//                 // move the start
//                 start++;
//             }

//             end++;

//             //Console.WriteLine();
//         }

//         return max;

//     }
// }


// class Program
// {
//     public static void Main()
//     {
//         int[] arr = { 1, 4, 2, 10, 23, 3, 1, 0, 20 };
//         int k = 4;

//         Solution s = new Solution();

//         Console.WriteLine($"{s.maxSubarraySum(arr, k)}");
//     }
// }