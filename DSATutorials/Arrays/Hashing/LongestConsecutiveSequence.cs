
//public class Solution
//{
//    // Time :O(nlogn) and space :O(N)
//    //public int LongestConsecutive(int[] nums)
//    //{
//    //    HashSet<int> map = new HashSet<int>(nums);
//    //    Array.Sort(nums);
//    //    int finalCount = int.MinValue;

//    //    for (int i = 0; i < nums.Length; i++)
//    //    {
//    //        int count = 1;
//    //        int sum = nums[i] + 1;

//    //        if (!map.Contains(sum))
//    //        {
//    //            continue;
//    //        }
//    //        else
//    //        {
//    //            count++;
//    //            while (map.Contains(sum + 1))
//    //            {
//    //                count++;
//    //                sum += 1;
//    //            }
//    //            finalCount = Math.Max(count, finalCount);
//    //        }
//    //    }

//    //    return finalCount;
//    //}


//    // Time : O(n) + O(n) + O(n) The inner while loop will process elements exactly once due to outer check condition, otherwise it will do double work , space :(n)
//    public int LongestConsecutive(int[] nums)
//    {
//        // base case
//        if (nums == null || nums.Length == 0)
//        {
//            return 0;
//        }

//        // Create a hashset to store all unique occurences
//        HashSet<int> set = new HashSet<int>(nums);

//        int currentCount = 0, maxCount = int.MinValue;
//        // Now iterate over all the elements in set 1 by 1

//        foreach (int item in set)
//        {
//            // Check if the given number is starting point the set to avoid any sort of repetion further
//            if (!set.Contains(item - 1))
//            {
//                // Now the given item is starting point as it does not have any direct predecssor in the set
//                currentCount = 1;
//                int nextNum = item + 1;
//                // Start processing subsequent element
//                while (set.Contains(nextNum))
//                {
//                    currentCount++;
//                    nextNum++;
//                }
//                maxCount = Math.Max(maxCount, currentCount);
//            }

//        }
//        return maxCount;
//    }

//}

//class Program
//{
//    public static void Main()
//    {
//        int[] arr = { 0, 3, 7, 2, 5, 8, 4, 6, 0, 1 };

//        Solution s = new Solution();

//        Console.WriteLine($"{s.LongestConsecutive(arr)}");
//    }
//}