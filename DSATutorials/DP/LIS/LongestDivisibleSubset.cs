
//class Solution
//{

//    public IList<int> LargestDivisibleSubset(int[] nums)
//    {
//        int[] dp = new int[nums.Length];
//        int[] old = new int[nums.Length];

//        Array.Fill(dp, 1);
//        Array.Fill(old, -1);

//        Array.Sort(nums);


//        int maxIndex = 0;

//        for (int curr = 1; curr < nums.Length; curr++)
//        {
//            for (int prev = 0; prev < curr; prev++)
//            {
//                if (nums[curr] % nums[prev] == 0 && dp[prev] + 1 > dp[curr])
//                {
//                    dp[curr] = dp[prev] + 1;
//                    old[curr] = prev;
//                }
//            }

//            // to keep track of the maxsize of the set at every index
//            if (dp[curr] > dp[maxIndex])
//            {
//                maxIndex = curr;
//            }
//        }

//        List<int> result = new List<int>();

//        int index = maxIndex;


//        // we use old array for restructuring the array 
//        while (index >= 0)
//        {
//            result.Add(nums[index]);
//            index = old[index];
//        }

//        result.Reverse();

//        return result;
//    }
//}


//class Program
//{
//    public static void Main()
//    {
//        int[] arr = { 2, 3, 4, 9, 8 };

//        Solution s = new Solution();

//        var result = s.LargestDivisibleSubset(arr);

//        foreach (var item in result)
//        {
//            Console.Write($"{item}" + " ");
//        }
//    }

//}


//// Time : O(N^2)  and space : O(N)