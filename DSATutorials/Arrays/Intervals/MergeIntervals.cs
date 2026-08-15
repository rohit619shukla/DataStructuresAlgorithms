
//class Solution
//{
//    // Time : O(nlogn) +O(n) , space :O(n)
//    public int[][] Merge(int[][] intervals)
//    {
//        // Step 1 : sort the Array so that we can start the merging
//        Array.Sort(intervals, new CompareArray());

//        // Step 2: start merging the intervals
//        List<int[]> mergedIntervals = new List<int[]>();

//        foreach (int[] inter in intervals)
//        {
//            // If the merged interval is already empty or current interval is higher than the last know exisiting interval range
//            if (mergedIntervals.Count == 0 || mergedIntervals[mergedIntervals.Count - 1][1] < inter[0])
//            {
//                mergedIntervals.Add(inter);
//            }
//            else
//            {
//                // Do the merging
//                mergedIntervals[mergedIntervals.Count - 1][1] = Math.Max(mergedIntervals[mergedIntervals.Count - 1][1], inter[1]);
//            }
//        }

//        return mergedIntervals.ToArray();
//    }
//}

//internal class CompareArray : IComparer<int[]>
//{
//    public int Compare(int[] n1, int[] n2)
//    {
//        return n1[0].CompareTo(n2[0]);
//    }
//}

//class Program
//{
//    public static void Main()
//    {
//        int[][] intervals = new int[][] {
//        new int[] {1, 3},
//        new int[] {2, 6},
//        new int[] {8, 10},
//        new int[] {15, 18}
//    };

//        Solution solution = new Solution();
//        var result = solution.Merge(intervals);

//        foreach (var interval in result)
//        {
//            Console.WriteLine($"[{interval[0]}, {interval[1]}]");
//        }
//    }
//}

