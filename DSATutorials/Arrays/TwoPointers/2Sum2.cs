// LeetCode 167: Two Sum II - Input Array Is Sorted
// https://leetcode.com/problems/two-sum-ii-input-array-is-sorted/
//
// Key Idea:
//   - The array is already sorted, so use the classic two-pointer approach:
//     i starts at the left (smallest), j starts at the right (largest).
//   - Compare the sum of both pointers with target:
//     sum == target -> found the pair, record 1-based indices
//     sum > target  -> the largest value is too big, move j inward (j--)
//     sum < target  -> the smallest value is too small, move i inward (i++)
//   - Terminate when the pointers cross (i >= j).
//
// Time:  O(n) — each pointer moves inward at most n steps in a single pass.
// Space: O(1) — only two pointers are used, no extra data structures.

public class Solution
{
    public int[] TwoSum(int[] numbers, int target)
    {
        // Classic template, as the array is already sorted
        int i = 0, j = numbers.Length - 1;
        int[] result = { };

        while (i < j)
        {
            // Sum of the current left and right candidates
            int sum = numbers[i] + numbers[j];

            if (sum == target)
            {
                // Found the pair -> store 1-based indices as required by the problem
                result = new int[] { i + 1, j + 1 };
            }
            if (sum > target)
            {
                // Sum too large -> shrink from the right to reduce it
                j--;
            }
            else
            {
                // Sum too small -> grow from the left to increase it
                i++;
            }
        }

        return result;
    }
}

class Program
{
    public static void Main()
    {
        int[] nums = { 2, 7, 11, 15 };
        int target = 9;

        Solution s = new Solution();

        var result = s.TwoSum(nums, target);

        foreach (var num in result)
        {
            Console.WriteLine($"{num}" + " ");
        }
    }
}

//Time: O(N), space: O(1)