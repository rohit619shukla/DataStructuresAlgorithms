// public class Solution
// {
//     public bool IsPerfectSquare(int num)
//     {
//         // Binary-search for an integer whose square equals num.
//         // Time: O(log num), Space: O(1).

//         long lb = 1, ub = num;

//         while (lb <= ub)
//         {
//             long mid = lb + (ub - lb) / 2;
//             // Use long so the square cannot overflow for any valid int input.
//             long multiply = mid * mid;

//             if (multiply == num)
//             {
//                 return true;
//             }

//             if (multiply > num)
//             {
//                 ub = mid - 1;
//             }
//             else
//             {
//                 lb = mid + 1;
//             }
//         }

//         return false;
//     }
// }


// class Program
// {
//     public static void Main()
//     {
//         int num = 808201;

//         Solution s = new Solution();

//         Console.WriteLine($"{s.IsPerfectSquare(num)}");
//     }
// }