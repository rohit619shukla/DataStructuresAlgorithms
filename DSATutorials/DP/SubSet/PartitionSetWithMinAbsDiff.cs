

//class Solution
//{
//    public void Solve(int[] arr, int index, int target, bool[,] dp)
//    {

//        for (int i = 0; i < arr.Length; i++)
//        {
//            dp[i, 0] = true;
//        }

//        dp[0, arr[0]] = true;

//        for (int i = 1; i < arr.Length; i++)
//        {
//            for (int j = 1; j <= target; j++)
//            {
//                bool notPickup = dp[i - 1, j];

//                bool pickUp = false;

//                if (j >= arr[i])
//                {
//                    pickUp = dp[i - 1, j - arr[i]];
//                }

//                dp[i, j] = pickUp || notPickup;
//            }
//        }
//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        int[] arr = { 3, 2, 7 };

//        int target = 0;

//        for (int i = 0; i < arr.Length; i++)
//        {
//            target += arr[i];
//        }

//        Solution s = new Solution();

//        bool[,] dp = new bool[arr.Length, target + 1];


        
//        s.Solve(arr, arr.Length - 1, target, dp);

//        int minNum = int.MaxValue;


//        // bascially the idea is to get all possible combinations of valid s1
//        // so if we subtract valid s1's from target we can get valid s2 automatically
//        for (int i = 0; i <= target; i++)
//        {
//            if (dp[arr.Length - 1, i] == true)
//            {
//                int s1Num = i;

//                int s2Num = target - s1Num;

//                minNum = Math.Min(minNum, Math.Abs(s1Num - s2Num));
//            }

//        }

//        Console.WriteLine(minNum);
//    }
//}