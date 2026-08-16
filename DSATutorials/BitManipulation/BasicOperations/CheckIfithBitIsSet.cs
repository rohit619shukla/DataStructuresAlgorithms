
// class Solution
// {
//     public bool IsSet(int num, int i)
//     {
//         return (num & (1 << i)) != 0;
//     }
// }
// class Program
// {
//     public static void Main()
//     {
//         int n = 13, i = 2;

//         Solution s = new Solution();

//         Console.WriteLine(s.IsSet(n, i));
//     }
// }

// // Notes : The reason we used 1 , 1 if & with 1 always gives 1 otherwise rest all as 0
// // Left shifting is used as we are only interested in that node only