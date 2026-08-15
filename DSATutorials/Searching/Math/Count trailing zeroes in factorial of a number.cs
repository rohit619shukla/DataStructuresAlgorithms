
//using System;

//class Solution
//{
//    public int Solve(int num)
//    {
//        int count = 0;

//        while (num / 5 > 0)
//        {
//            num = num / 5;
//            count += num;
//        }
//        return count;
//    }
//}

//class Program
//{
//    public static void Main()
//    {
//        int n = 100;

//        Solution s = new Solution();

//        Console.WriteLine(s.Solve(n));
//    }
//}

//// Time : O(log5N) as as we divide n by 5 in each iteration. , space : O(1)

//// Explanation for ex : between 1 and n we have 8 2s and 2 5s                                                                                            