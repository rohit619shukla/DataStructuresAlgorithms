
// class Solution
// {
//     // Time  : O(log10(x)) -> we process one digit per iteration (~number of digits)
//     // Space : O(1)        -> only a few scalar variables, no extra data structures
//     public int Reverse(int num)
//     {
//         // Use long to safely detect 32-bit overflow before casting back to int
//         int temp = 0;

//         while (num != 0)
//         {
//             // Extract the last digit (works for negatives too: -123 % 10 == -3)
//             int lastNum = num % 10;

//             // If the reversed value overflows int range, LeetCode expects 0
//             if (temp > int.MaxValue / 10 || temp < int.MinValue / 10)
//             {
//                 return 0;
//             }

//             // Shift accumulated result left by one decimal place and append the digit
//             temp = temp * 10 + lastNum;


//             // Drop the last digit we just consumed
//             num /= 10;
//         }


//         return temp;
//     }

// }


// class Program
// {
//     public static void Main()
//     {
//         int x = 43261596;

//         Solution s = new Solution();

//         Console.WriteLine(s.Reverse(x));
//     }
// }