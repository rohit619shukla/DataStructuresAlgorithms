

//class Solution
//{
//    public void Solve(int[] arr)
//    {
//        int[] dp1 = new int[arr.Length];
//        int[] dp2 = new int[arr.Length];


//        Array.Fill(dp1, 1);
//        Array.Fill(dp2, 1);


//        for (int curr = 1; curr < arr.Length; curr++)
//        {
//            for (int prev = 0; prev < curr; prev++)
//            {
//                if (arr[curr] > arr[prev] && dp1[prev] + 1 > dp1[curr])
//                {
//                    dp1[curr] = dp1[prev] + 1;
//                }
//            }
//        }

//        for (int curr = arr.Length - 2; curr >= 0; curr--)
//        {
//            for (int prev = arr.Length - 1; prev > curr; prev--)
//            {
//                if (arr[curr] > arr[prev] && dp2[prev] + 1 > dp2[curr])
//                {
//                    dp2[curr] = dp2[prev] + 1;
//                }
//            }
//        }

//        int max = int.MinValue;

//        for (int i = 0; i < arr.Length; i++)
//        {
//            max = Math.Max(max, (dp1[i] + dp2[i] - 1));
//        }

//        Console.WriteLine(max);
//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        int[] arr = { 1, 11, 2, 10, 4, 5, 2, 1 };

//        Solution s = new Solution();

//        s.Solve(arr);
//    }
//}


//// Time : O(m*n) , space : O(n)