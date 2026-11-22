// public class Solution
// {
//     public int SecondLargestElement(int[] nums)
//     {

//         int firstLargest = int.MinValue;
//         int secondLargest = int.MinValue;

//         for (int i = 0; i < nums.Length; i++)
//         {
//             if (nums[i] > firstLargest)
//             {
//                 secondLargest = firstLargest;
//                 firstLargest = nums[i];
//             }
//             else if (nums[i] > secondLargest && nums[i] != firstLargest)
//             {
//                 secondLargest = nums[i];
//             }
//         }

//         return secondLargest == int.MinValue ? -1 : secondLargest;
//     }
// }

// class Program
// {
//     public static void Main()
//     {
//         int[] nums = { -1, -3, -4, -2, -5 };
//         //int[] nums = { 8, 8, 7, 6, 5 };

//         Solution s = new Solution();

//         Console.WriteLine(s.SecondLargestElement(nums));
//     }
// }