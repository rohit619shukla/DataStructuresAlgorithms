// public class Solution
// {
//     // Time : O(n), Space : O(1)
//     public void Rotate(int[] nums, int k)
//     {
//         // Usually you can rotate the array that many number of times which is euqual to size of array
//         // If the value of K is greater than size of array , we will kind of enter in a loop whichis not really needed
//         // Hence we need to normalize the array

//         int n = nums.Length;
//         k %= n;

//         // Now we will reverse the array 3 times, based on following way
//         // This works becasue if we see the output, after eversing the array all elements were
//         // already in the right zone, they just need a bit of shuffling
//         Reverse(0, n - 1, nums);
//         Reverse(0, k - 1, nums);
//         Reverse(k, n - 1, nums);
//     }

//     private void Reverse(int lb, int ub, int[] nums)
//     {
//         while (lb < ub)
//         {
//             int temp = nums[lb];
//             nums[lb] = nums[ub];
//             nums[ub] = temp;

//             lb++;
//             ub--;
//         }
//     }
// }

// class Program
// {
//     public static void Main()
//     {
//         int[] nums = { 1, 2, 3, 4, 5, 6, 7 };

//         Solution s = new Solution();

//         s.Rotate(nums, 3);
//     }
// }