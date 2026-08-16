

// class Solution
// {
//     // Sets (turns ON) the bit at position i, regardless of its current value.
//     public int SetBit(int num, int i)
//     {
//         // (1 << i) creates a mask with only the i-th bit set, e.g. i=1 -> 0010.
//         // OR-ing with num forces that bit to 1 while leaving all other bits unchanged.
//         return num | (1 << i);
//     }
// }
// class Program
// {
//     public static void Main()
//     {
//         Solution s = new Solution();
//         // 13 = 1101, set bit 1 -> 1111 = 15
//         Console.WriteLine(s.SetBit(13,1));
//     }
// }