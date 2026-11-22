// public class Solution
// {
//     // Time: O(n) to scan the intervals and copy the result; each input interval is visited once.
//     // Auxiliary space: O(n) for the temporary result list; merging uses O(1) extra space.
//     // Output space: O(n) for the outer array created by ToArray(); inner interval arrays are not copied.
//     // Total space: O(n) auxiliary + O(n) output = O(n), where n is the number of input intervals.
//     // Merging mutates newInterval; the output shares it and any unchanged input interval arrays.
//     public int[][] Insert(int[][] intervals, int[] newInterval)
//     {
//         // Input intervals are sorted by start and non-overlapping, so no sorting is needed.
//         List<int[]> result = new List<int[]>();

//         int i = 0;

//         while (i < intervals.Length)
//         {
//             // This interval ends strictly before newInterval starts, so keep it unchanged.
//             if (intervals[i][1] < newInterval[0])
//             {
//                 result.Add(intervals[i]);
//             }
//             else if (intervals[i][0] > newInterval[1])
//             {
//                 // This and all remaining intervals start after the merged newInterval ends.
//                 // Stop here so newInterval can be inserted before them.
//                 break;
//             }
//             else
//             {
//                 // Overlapping or touching endpoints: expand newInterval in place to cover both intervals.
//                 newInterval[0] = Math.Min(intervals[i][0], newInterval[0]);
//                 newInterval[1] = Math.Max(intervals[i][1], newInterval[1]);
//             }
//             i++;
//         }

//         // Add newInterval once, after absorbing all overlaps (also handles an empty input).
//         result.Add(newInterval);

//         // Append the remaining non-overlapping intervals in their existing sorted order.
//         while (i < intervals.Length)
//         {
//             result.Add(intervals[i]);
//             i++;
//         }

//         // Copy references into a new outer array; the inner interval arrays remain shared.
//         return result.ToArray();
//     }
// }


// class Program
// {
//     public static void Main()
//     {
//         int[][] intervals =
//         {
//             new int[] {1,2},
//             new int[] {3,5},
//             new int[] {6,7},
//             new int[] {8,10},
//             new int[] {12,16},
//         };

//         int[] newInterval = { 4, 8 };

//         Solution s = new Solution();

//         var result = s.Insert(intervals, newInterval);

//         foreach (int[] nums in result)
//         {
//             Console.WriteLine($"[{nums[0]},{nums[1]}]");
//         }
//     }
// }