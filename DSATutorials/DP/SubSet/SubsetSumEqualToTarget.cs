
//using System.Runtime.Intrinsics.Arm;

//class Solution
//{
//    // Time  : O(2^n)  , space :O(n)
//    //public bool Solve(int[] arr, int index, int target)
//    //{
//    //    // Base case: target achieved
//    //    if (target == 0)
//    //        return true;

//    //    // Base case: only one element left, check if it matches target
//    //    if (index == 0)
//    //        return arr[index] == target;

//    //    // Option 1: Do not take current element
//    //    bool notTake = Solve(arr, index - 1, target);

//    //    // Option 2: Take current element (if possible)
//    //    bool take = false;
//    //    if (target >= arr[index])
//    //        take = Solve(arr, index - 1, target - arr[index]);

//    //    // Result is either of the choices
//    //    return take || notTake;
//    //}


//    // Time : O(n*m) , space :O(n*m) + O(n)
//    //public bool Solve(int[] arr, int index, int target, bool?[,] dp)
//    //{
//    //    // Base case: target achieved
//    //    if (target == 0)
//    //        return true;

//    //    // Base case: only one element left, check if it matches target
//    //    if (index == 0)
//    //        return arr[index] == target;

//    //    if (dp[index, target].HasValue)
//    //        return dp[index, target].Value;

//    //    // Option 1: Do not take current element
//    //    bool notTake = Solve(arr, index - 1, target, dp);

//    //    // Option 2: Take current element (if possible)
//    //    bool take = false;
//    //    if (target >= arr[index])
//    //        take = Solve(arr, index - 1, target - arr[index], dp);

//    //    // Result is either of the choices
//    //    //dp[index, target] = take || notTake;

//    //    return (dp[index, target] = take || notTake).Value;
//    //}

//    // Time : O(n*m)  , space :O(n*m)
//    //public bool Solve(int[] arr, int target, bool[,] dp)
//    //{
//    // Target can be zero for any index
//    //    for (int i = 0; i < arr.Length; i++)
//    //    {
//    //        dp[i, 0] = true;
//    //    }

//    //    dp[0, arr[0]] = true;

//    //    for (int i = 1; i < arr.Length; i++)
//    //    {
//    //        for (int j = 1; j <= target; j++)
//    //        {
//    //            // Option 1: Do not take current element
//    //            bool notTake = dp[i - 1, j];

//    //            // Option 2: Take current element (if possible)
//    //            bool take = false;
//    //            if (j >= arr[i])
//    //                take = dp[i - 1, j - arr[i]];

//    //            dp[i, j] = take || notTake;
//    //        }
//    //    }

//    //    return dp[arr.Length-1, target];
//    //}

//    // Time : O(n*m) , space :O(n+m)
//    public bool Solve(int[] arr, int target)
//    {
//        bool[] prev = new bool[target + 1];

//        // base case
//        prev[0] = true;

//        prev[arr[0]] = true;

//        for (int i = 1; i < arr.Length; i++)
//        {
//            bool[] curr = new bool[target + 1];
//            curr[0] = true; // target 0 always possible
//            for (int j = 1; j <= target; j++)
//            {
//                // Option 1: Do not take current element
//                bool notTake = prev[j];

//                // Option 2: Take current element (if possible)
//                bool take = false;
//                if (j >= arr[i])
//                    take = prev[j - arr[i]];

//                curr[j] = take || notTake;
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
//        int[] arr = { 1, 2, 3, 4 };
//        int target = 4;

//        Solution s = new Solution();

//        bool[,] dp = new bool[arr.Length, target + 1];

//        //Console.WriteLine(s.Solve(arr, arr.Length - 1, target));

//        Console.WriteLine(s.Solve(arr, target));
//    }
//}