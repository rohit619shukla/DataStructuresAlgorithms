// public class Solution
// {
//     public string LargestNumber(int[] nums)
//     {
//         // Time: O(n log n * k), where k is the maximum number of digits.
//         // Auxiliary space: O(log n), excluding the output string.
//         // Arrange numbers by whichever concatenation produces the larger value.
//         Array.Sort(nums, (n1, n2) => (n2.ToString() + n1).CompareTo(n1.ToString() + n2));

//         // If the largest number is 0, every number is 0.
//         if(nums[0] ==0) return "0";
        
//         string result = "";
//         foreach (int num in nums)
//         {
//             result += num;
//         }

//         return result;
//     }
// }



// class Program
// {
//     public static void Main()
//     {
//         int[] nums = { 3, 30, 34, 5, 9 };

//         Solution s = new Solution();

//         Console.WriteLine($"{s.LargestNumber(nums)}");
//     }
// }