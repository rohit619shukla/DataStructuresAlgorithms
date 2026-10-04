public class Solution
{
    // Time: O(n log n), space: O(n) for the merge buffer plus O(log n) recursion.
    public int ReversePairs(int[] nums)
    {
        int[] result = new int[nums.Length];

        return MergeSort(nums, 0, nums.Length - 1, result);
    }

    private int MergeSort(int[] nums, int lb, int ub, int[] result)
    {
        int count = 0;

        if (lb < ub)
        {
            int mid = lb + (ub - lb) / 2;

            count += MergeSort(nums, lb, mid, result);
            count += MergeSort(nums, mid + 1, ub, result);

            // Both halves are sorted now. Count cross-half reverse pairs before
            // merging because reverse-pair comparison differs from merge ordering.
            count += CountReversePairs(nums, lb, mid, ub);
            Merge(nums, lb, mid, ub, result);
        }

        return count;
    }

    private void Merge(int[] nums, int lb, int mid, int ub, int[] result)
    {
        int k = lb;
        int i = lb;
        int j = mid + 1;

        while (i <= mid && j <= ub)
        {
            if (nums[i] <= nums[j])
            {
                result[k] = nums[i];
                i++;
                k++;
            }
            else
            {
                result[k] = nums[j];
                j++;
                k++;
            }
        }

        if (i > mid)
        {
            while (j <= ub)
            {
                result[k] = nums[j];
                j++;
                k++;
            }
        }

        if (j > ub)
        {
            while (i <= mid)
            {
                result[k] = nums[i];
                i++;
                k++;
            }
        }

        for (int x = lb; x <= ub; x++)
        {
            nums[x] = result[x];
        }
    }

    private int CountReversePairs(int[] nums, int lb, int mid, int ub)
    {
        int count = 0;
        int j = mid + 1;

        // For each value in the sorted left half, find how many values at the
        // beginning of the sorted right half satisfy nums[i] > 2 * nums[j].
        for (int i = lb; i <= mid; i++)
        {
            // j never moves backward: as nums[i] increases, every previously
            // qualifying right-side value continues to qualify.
            while (j <= ub && (long)nums[i] > 2L * nums[j])
            {
                j++;
            }

            // The qualifying right-side indices are [mid + 1, j - 1].
            count += j - (mid + 1);
        }

        return count;
    }
}


class Program
{
    public static void Main()
    {
        int[] nums = { 2147483647, 2147483647, 2147483647, 2147483647, 2147483647, 2147483647 };

        Solution s = new Solution();

        Console.WriteLine($"{s.ReversePairs(nums)}");
    }
}