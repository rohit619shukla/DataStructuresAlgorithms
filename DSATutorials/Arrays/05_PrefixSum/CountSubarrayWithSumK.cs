//public class Solution
//{
//    public int SubarraySum(int[] nums, int k)
//    {
//        int count = 0;

//        for (int s = 0; s < nums.Length; s++)
//        {
//            for (int e = s; e < nums.Length; e++)
//            {
//                int sum = 0;

//                sum += nums[e];

//                if (sum == k)
//                {
//                    count++;
//                }
//            }
//        }

//        return count;
//    }

//    //public int SubarraySum(int[] nums, int k)
//    //{
//    //    var map = new Dictionary<int, int> { { 0, 1 } };
//    //    int currSum = 0, count = 0;

//    //    foreach (var num in nums)
//    //    {
//    //        currSum += num;

//    //        // Check if there exists a prefix sum that satisfies the condition
//    //        if (map.ContainsKey(currSum - k))
//    //        {
//    //            count += map[currSum - k];
//    //        }

//    //        // Update the frequency of the current prefix sum
//    //        if (map.ContainsKey(currSum))
//    //        {
//    //            map[currSum]++;
//    //        }
//    //        else
//    //        {
//    //            map[currSum] = 1;
//    //        }
//    //    }

//    //    return count;
//    //}

//}


//class Program
//{
//    public static void Main()
//    {
//        int[] arr = { 1, -1 };

//        Solution s = new Solution();

//        Console.WriteLine(s.SubarraySum(arr, 0));
//    }

//}