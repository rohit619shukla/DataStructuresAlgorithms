// public class Solution
// {
//     // Time: O(n log n) for sorting + O(n) for merging and copying the result = O(n log n).
//     // Auxiliary space: O(n) for the temporary result list + O(log n) sorting stack = O(n).
//     // Output space: O(n) for the outer array created by ToArray(); inner interval arrays are not copied.
//     // Total space: O(n) auxiliary + O(n) output = O(n), where n is the number of input intervals.
//     // The input is sorted in place; merged endpoints mutate input rows because result stores their references.
//     public int[][] Merge(int[][] intervals)
//     {
//         // Sort by start so each interval only needs to be compared with the last merged interval.
//         Array.Sort(intervals, (n1, n2) => n1[0].CompareTo(n2[0]));

//         List<int[]> result = new List<int[]>();

//         foreach (int[] interval in intervals)
//         {
//             // Start a new interval if the result is empty or there is a strict gap after the last merged end.
//             // Equal endpoints overlap (e.g., [1, 4] and [4, 5]), so they must be merged.
//             if (result.Count == 0 || result[result.Count - 1][1] < interval[0])
//             {
//                 result.Add(interval);
//             }
//             else
//             {
//                 // Extend the last merged end; Max also handles an interval contained within it.
//                 result[result.Count - 1][0] = Math.Min(result[result.Count - 1][0], interval[0]);
//                 result[result.Count - 1][1] = Math.Max(result[result.Count - 1][1], interval[1]);
//             }
//         }

//         // Copy the list into an outer array; the inner interval arrays are still shared with the input.
//         return result.ToArray();
//     }
// }


// class Program
// {
//     public static void Main()
//     {
//         Solution s = new Solution();

//         int[][] intervals =
//         {
//             new int[] {1,3},
//             new int[]{2,6},
//             new int[]{8,10},
//             new int[]{15,18}
//         };

//         var result = s.Merge(intervals);

//         foreach (int[] interval in result)
//         {
//             Console.WriteLine($"{interval[0]}, {interval[1]}");
//         }
//     }
// }