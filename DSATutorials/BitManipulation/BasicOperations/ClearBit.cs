
// class Solution
// {
//     // Clears (turns OFF) the bit at position i, regardless of its current value.
//     public int ClearBit(int num, int i)
//     {
//         // (1 << i) sets only the i-th bit; ~ inverts it so that bit is 0 and all others are 1.
//         // AND-ing with num forces the i-th bit to 0 while keeping every other bit unchanged.
//         return num & ~(1 << i);
//     }
// }

// class Program
// {
//     public static void Main()
//     {
//         Solution s = new Solution();
//         // 13 = 1101, clear bit 2 -> 1001 = 9
//         Console.WriteLine(s.ClearBit(13, 2));
//     }
// }