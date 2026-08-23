// class Solution
// {
//     public bool IsEven(int num)
//     {
//         // In binary every bit represents a power of 2, so all bits except the
//         // last one (the 1s place) are even; only the last bit adds an odd amount.
//         // Check if the last bit is 1 or not: 0 means even, 1 means odd
//         return (num & 1) == 0;
//     }
// }

// class Program
// {
//     public static void Main()
//     {
//         int num = 10;

//         Solution s = new Solution();

//         Console.WriteLine(s.IsEven(num));
//     }
// }