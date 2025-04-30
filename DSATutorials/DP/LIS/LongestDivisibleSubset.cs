
//public class Solution
//{
//    public IList<int> LargestDivisibleSubset(int[] nums)
//    {
//        //IList<int> result = new List<int>();

//        //// To temporarily store the current list
//        //IList<int> tempList = new List<int>();

//        // Sort the Array
//        Array.Sort(nums);

//        //Solve(nums, result, tempList, 0, -1);
//        return Solve(nums);
//    }

//    // Time : O(2^n * n) , space :O(n)
//    //private void Solve(int[] nums, IList<int> result, IList<int> tempList, int currentIndex, int prevIndex)
//    //{
//    //    //base case
//    //    if (currentIndex == nums.Length)
//    //    {
//    //        if (tempList.Count > result.Count)
//    //        {
//    //            result.Clear();
//    //            foreach (var num in tempList)
//    //            {
//    //                result.Add(num);
//    //            }
//    //        }

//    //        // no new list found
//    //        return;
//    //    }

//    //    // Note : Recursion and backtracking funtion
//    //    // Take case
//    //    if (prevIndex == -1 || (nums[currentIndex] % nums[prevIndex]) == 0)
//    //    {
//    //        tempList.Add(nums[currentIndex]);
//    //        Solve(nums, result, tempList, currentIndex + 1, currentIndex);
//    //        // backtrack
//    //        tempList.RemoveAt(tempList.Count - 1);
//    //    }

//    //    // Not Take case
//    //    Solve(nums, result, tempList, currentIndex + 1, prevIndex);

//    //}

//    // O(N^2), space :O(n)
//    private IList<int> Solve(int[] nums)
//    {
//        Array.Sort(nums);
//        int[] dp = new int[nums.Length];
//        int[] location = new int[nums.Length];

//        Array.Fill(location, -1);
//        Array.Fill(dp, 1);

//        // Key Change here 👇
//        int maxLen = 1, maxIndex = 0;

//        for (int i = 1; i < nums.Length; i++)
//        {
//            for (int j = 0; j < i; j++)
//            {
//                if (nums[i] % nums[j] == 0)
//                {
//                    if (dp[j] + 1 > dp[i])
//                    {
//                        dp[i] = dp[j] + 1;
//                        // We will continously update the location array
//                        location[i] = j;
//                    }
//                }
//            }
//            // maxLen and maxIndex update should be outside inner loop
//            if (dp[i] > maxLen)
//            {
//                maxLen = dp[i];

//                //. Since we need to keep track of index hence we need this if statement otherwise it can be same as LIS code
//                maxIndex = i;
//            }
//        }

//        int[] result = new int[maxLen];
//        int count = maxLen - 1;

//        while (maxIndex != -1)
//        {
//            result[count] = nums[maxIndex];
//            maxIndex = location[maxIndex];
//            count--;
//        }

//        return result;

//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        int[] arr = { 3, 8, 15, 32, 64 };

//        Solution s = new Solution();

//        var result = s.LargestDivisibleSubset(arr);

//        foreach (var item in result)
//        {
//            Console.Write($"{item}" + " ");
//        }
//    }
//}