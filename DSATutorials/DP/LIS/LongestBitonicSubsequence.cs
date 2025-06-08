
//class Solution
//{
//    public int Solve(int[] arr)
//    {
//        int[] dp1 = new int[arr.Length];
//        int[] dp2 = new int[arr.Length];

//        Array.Fill(dp1, 1);
//        Array.Fill(dp2, 1);

//        // perform forward LIS
//        for (int curr_idx = 1; curr_idx < arr.Length; curr_idx++)
//        {
//            for (int prev_idx = 0; prev_idx <= curr_idx; prev_idx++)
//            {
//                if (arr[curr_idx] > arr[prev_idx])
//                {
//                    dp1[curr_idx] = Math.Max(dp1[curr_idx], dp1[prev_idx] + 1);
//                }
//            }
//        }

//        // perform backward LIS
//        for (int curr_idx = arr.Length - 2; curr_idx >= 0; curr_idx--)
//        {
//            for (int prev_idx = arr.Length - 1; prev_idx >= curr_idx; prev_idx--)
//            {
//                if (arr[curr_idx] > arr[prev_idx])
//                {
//                    dp2[curr_idx] = Math.Max(dp2[curr_idx], dp2[prev_idx] + 1);
//                }
//            }
//        }

//        int maxlen = 1;

//        for (int i = 0; i < dp1.Length; i++)
//        {
//            maxlen = Math.Max(maxlen, (dp1[i] + dp2[i]) - 1);
//        }

//        return maxlen;
//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        int[] arr = { 1, 11, 2, 10, 4, 5, 2, 1 };

//        Solution s = new Solution();

//        Console.WriteLine(s.Solve(arr));
//    }
//}


////Forward LIS gives me the height of the peak I can climb to from the left.

////Backward LIS tells me how far I can descend from that peak to the right.

////The combination gives me the full bitonic length at each index, and I take the maximum of those.