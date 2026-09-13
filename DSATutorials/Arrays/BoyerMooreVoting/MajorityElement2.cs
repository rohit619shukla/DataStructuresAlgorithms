// public class Solution
// {
//     // Time : O(n) , Space : O(1) (result list aside, only a constant number of counters)
//     public IList<int> MajorityElement(int[] nums)
//     {
//         // Boyer-Moore generalised: an element appearing more than n/k times
//         // can have at most k-1 such elements. Here k = 3, so there are at
//         // most two candidates that occur more than n/3 times.

//         IList<int> result = new List<int>();

//         // Two candidate slots and their running vote counts.
//         int maj1 = 0, count1 = 0, maj2 = 0, count2 = 0;
//         int n = nums.Length;

//         // Pass 1: find the two potential candidates via vote counting.
//         for (int i = 0; i < n; i++)
//         {
//             // Priority 1: current number already matches a candidate -> add a vote.
//             if (maj1 == nums[i])
//             {
//                 count1++;
//             }
//             else if (maj2 == nums[i])
//             {
//                 count2++;
//             }

//             // Priority 2: a candidate slot is free (count 0) -> take it for this number.
//             else if (count1 == 0)
//             {
//                 maj1 = nums[i];
//                 count1 = 1;
//             }
//             else if (count2 == 0)
//             {
//                 maj2 = nums[i];
//                 count2 = 1;
//             }

//             // Priority 3: number matches neither candidate and both are held ->
//             // cancel one vote from each candidate.
//             else
//             {
//                 count1--;
//                 count2--;
//             }
//         }

//         // Pass 2: candidates are only potential; recount their real frequencies.
//         int freq1 = 0, freq2 = 0;

//         for (int i = 0; i < n; i++)
//         {
//             if (maj1 == nums[i])
//             {
//                 freq1++;
//             }

//             else if (maj2 == nums[i])
//             {
//                 freq2++;
//             }
//         }

//         // Keep only candidates that truly appear more than n/3 times.
//         if (freq1 > (n / 3))
//         {
//             result.Add(maj1);
//         }

//         if (freq2 > (n / 3))
//         {
//             result.Add(maj2);
//         }

//         return result;
//     }
// }


// class Program
// {
//     public static void Main()
//     {
//         int[] nums = { 1, 2 };

//         Solution s = new Solution();

//         var result = s.MajorityElement(nums);

//         foreach (var num in result)
//         {
//             Console.Write($"{num}" + " ");
//         }
//     }
// }