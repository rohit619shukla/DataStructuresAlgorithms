// class Solution
// {
//     // Time : O(1) , space :O(1)
//     public void Swap(int a, int b)
//     {
//         a = a ^ b;
//         b = a ^ b;
//         a = a ^ b;

//         Console.WriteLine($"Numbers after swapping are :  a : {a} and b : {b}");
//     }
// }

// class Program
// {
//     public static void Main()
//     {
//         int a = 29;
//         int b = 98;

//         Solution s = new Solution();

//         s.Swap(a, b);
//     }
// }