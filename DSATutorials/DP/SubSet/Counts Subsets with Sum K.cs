
//class Solution
//{
//    // Time : O(2^n) , space :O(n)
//    //public int Solve(int[] arr, int index, int target)
//    //{
//    //    // base case
//    //    if (target == 0)
//    //    {
//    //        return 1;
//    //    }

//    //    if (index == 0)
//    //    {
//    //        return (arr[index] == target) ? 1 : 0;
//    //    }

//    //    int notTake = Solve(arr, index - 1, target);
//    //    int take = 0;

//    //    if (target >= arr[index])
//    //    {
//    //        take = Solve(arr, index - 1, target - arr[index]);
//    //    }

//    //    // Since we need a total count
//    //    return take + notTake;
//    //}

//    // Time : O(n*m) , spacew :(n+m)
//    public int Solve(int[] arr, int target)
//    {
//        int[] prev = new int[target + 1];

//        prev[0] = 1;
//        prev[arr[0]] = 1;

//        for (int i = 1; i < arr.Length; i++)
//        {
//            int[] curr = new int[target + 1];
//            curr[0] = 1;

//            for (int j = 1; j <= target; j++)
//            {
//                int notTake = prev[j];
//                int take = 0;

//                if (j >= arr[i])
//                {
//                    take = prev[j - arr[i]];
//                }

//                // Since we need a total count
//                curr[j] = take + notTake;
//            }
//            prev = curr;
//        }
//        return prev[target];
//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        int[] arr = { 1, 2, 2, 3 };
//        int target = 3;

//        Solution s = new Solution();
//        int[,] dp = new int[arr.Length, target + 1];
//        Console.WriteLine(s.Solve(arr, target));
//    }
//}