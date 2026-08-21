// public class Solution
// {
//     public int HammingWeight(int n)
//     {
//         int count = 0;

//         while (n > 0)
//         {
//             n = n & n - 1;
//             count++;
//         }
//         return count;
//     }
// }

// class Program
// {
//     public static void Main()
//     {
//         Solution s = new Solution();

//         Console.WriteLine(s.HammingWeight(11));
//     }
// }