
// class Solution
// {
//     // Toggles (flips) the bit at position i: 1 becomes 0, and 0 becomes 1.
//     public int ToggleBit(int num, int i)
//     {
//         // (1 << i) sets only the i-th bit. XOR flips a bit wherever the mask is 1,
//         // and leaves a bit unchanged wherever the mask is 0.
//         return num ^ (1 << i);
//     }
// }
// class Program
// {
//     public static void Main()
//     {
//         Solution s = new Solution();
//         // 13 = 1101, toggle bit 2 -> 1001 = 9
//         Console.WriteLine(s.ToggleBit(13, 2));
//     }
// }