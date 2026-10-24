// public class Solution
// {
//     // Time: O(n log n) for sorting + O(n) for scanning = O(n log n).
//     // Auxiliary space: O(log n) for the sorting stack; the greedy scan uses O(1) extra space.
//     // Output space: O(1) for the removal count.
//     // Total space: O(log n), where n is the number of input intervals.
//     // Sorting reorders the input array in place; interval endpoints are not modified.
//     public int EraseOverlapIntervals(int[][] intervals)
//     {
//         // Sort by start so intervals can be checked for overlap from left to right.
//         Array.Sort(intervals, (n1, n2) => n1[0].CompareTo(n2[0]));

//         // Count conceptual removals; no intervals need to be physically deleted.
//         int count = 0;

//         // i tracks the last kept interval; j scans the next candidate.
//         int i = 0, j = 1;

//         while (j < intervals.Length)
//         {
//             int[] currentInterval = intervals[i];
//             int[] nextInterval = intervals[j];

//             // No overlap: keep the next interval. Touching endpoints are allowed in this problem.
//             if (currentInterval[1] <= nextInterval[0])
//             {
//                 i = j;
//                 j++;
//             }
//             else
//             {
//                 // Overlap: remove one interval and keep the one ending earlier,
//                 // leaving the most room for future intervals.
//                 if (currentInterval[1] <= nextInterval[1])
//                 {
//                     // Keep currentInterval and skip nextInterval; either is safe if their ends match.
//                     j++;
//                     count++;
//                 }
//                 else
//                 {
//                     // Replace currentInterval with the earlier-ending nextInterval.
//                     i = j;
//                     j++;
//                     count++;
//                 }
//             }

//         }

//         return count;
//     }
// }


// class Program
// {
//     public static void Main()
//     {
//         int[][] intervals =
//         {
//             new int[] {1,2},
//             new int[] {2,3},
//              new int[] {3,4},
//             new int[] {1,3}
//         };

//         Solution s = new Solution();

//         Console.WriteLine($"{s.EraseOverlapIntervals(intervals)}");
//     }
// }