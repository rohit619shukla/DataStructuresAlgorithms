// class Solution
// {
//     public bool IsPowerOfTwo(int num)
//     {
//         // If a number is power of 2, then there will only be 1 set bit
//         // If we do N-1, that 1 bit will be set to 0 and all bits next to right will be set to 1
//         // Doing logical and will give either 0 or 1

//         if (num <= 0) return false;

//         return (num & num - 1) == 0 ? true : false;
//     }
// }

// class Program
// {
//     public static void Main()
//     {
//         Solution s = new Solution();

//         Console.WriteLine(s.IsPowerOfTwo(32));
//     }
// }