// public class Solution
// {
//     public int MaxPower(string s)
//     {
//         int count = 0, max = 0;

//         for (int i = 0; i < s.Length; i++)
//         {
//             // this is the first char
//             if (i == 0)
//             {
//                 count = 1;
//             }
//             else if (s[i] != s[i - 1])
//             {
//                 // continuity broke, reset back to 1
//                 count = 1;
//             }
//             else if (s[i] == s[i - 1])
//             {
//                 count++;
//             }

//             max = Math.Max(max, count);
//         }

//         return max;
//     }
// }


// class Program
// {
//     public static void Main()
//     {
//         string str = "abbcccddddeeeeedcba";

//         Solution s = new Solution();
//         Console.WriteLine(s.MaxPower(str));
//     }
// }