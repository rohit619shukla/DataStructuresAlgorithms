// public class Solution
// {
//     public int GetSum(int a, int b)
//     {
//         while (b != 0)
//         {
//             // 1. We will first figure out what all places needs carry
//             int carry = a & b;

//             // 2. Perform the addition using ^, This is becoz : 1+1 = 2, but is written as 1 0 in binary
//             a = a ^ b;

//             // 3. Now take the carry and make it available to be added in next itration
//             b = carry << 1;
//         }

//         return a;
//     }
// }


// class Program
// {
//     public static void Main()
//     {
//         Solution s = new Solution();

//         Console.WriteLine(s.GetSum(1, 2));
//     }
// }