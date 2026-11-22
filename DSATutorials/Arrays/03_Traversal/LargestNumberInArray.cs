// class Solution
// {
//     // Time Complexity: O(n) - we traverse the array once
//     // Space Complexity: O(1) - only a single variable is used
//     public int largestElement(int[] nums)
//     {

//         // Always assume the first element in the array as largest and we assume the array will have atleast 1 element
//         int maxi = nums[0];

//         foreach (int n in nums)
//         {
//             maxi = Math.Max(maxi, n);
//         }

//         return maxi;
//     }
// }

// class Program
// {
//     public static void Main()
//     {
//         int[] nums = { 3, 3, 0, 99, -40 };

//         Solution s = new Solution();

//         Console.WriteLine(s.largestElement(nums));
//     }
// }

