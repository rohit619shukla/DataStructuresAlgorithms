// public class Solution
// {
//     public int MinBitFlips(int start, int goal)
//     {
//         // The core idea is that the XOR operator helps to differentiate between 2 bits
//         // If we do a XOR of the numbers the resultant number we get will contains all set bit needed flip for our answer

//         int ans = start ^ goal;
//         int count = 0;

//         while (ans > 0)
//         {
//             // Just removing 1 from the given number till it is zero
//             ans &= ans - 1;
//             count++;
//         }

//         return count;
//     }

//     // Time Complexity: O(1) - the input is a fixed-width integer (32 bits), so the loop
//     //                  runs at most 32 times regardless of input value.
//     //                  Brian Kernighan's trick (ans &= ans - 1) clears one set bit per iteration.
//     // Space Complexity: O(1) - only a fixed number of integer variables are used.
// }

// class Program
// {
//     public static void Main()
//     {
//         Solution s = new Solution();

//         Console.WriteLine(s.MinBitFlips(10, 7));
//     }
// }