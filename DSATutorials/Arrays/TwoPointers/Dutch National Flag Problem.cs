// public class Solution
// {
//     public void SortColors(int[] nums)
//     {
//         // The apporach is that we know :
//         // k should be at last, but we dont know where to keep i and j
//         // We assume : 0 => i, 1 => j and 2 => k
//         int i = 0, j = 0, k = nums.Length - 1;

//         while (j <= k)
//         {
//             // j will be used to determine who is at current index and what needs to be done with it
//             switch (nums[j])
//             {
//                 case 0:
//                     Swap(nums, i, j);
//                     i++;
//                     j++;
//                     break;
//                 case 1:
//                     j++;
//                     break;
//                 case 2:
//                     Swap(nums, j, k);
//                     k--;
//                     break;
//             }
//         }
//     }

//     private void Swap(int[] nums, int lb, int ub)
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
//         int[] nums = { 2, 0, 2, 1, 1, 0 };

//         Solution s = new Solution();

//         s.SortColors(nums);
//     }
// }