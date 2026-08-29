class Solution
{
    // Returns all "leader" elements: an element is a leader if it is greater
    // than or equal to every element to its right. The result preserves the
    // original left-to-right order.
    // Time Complexity:  O(n) - one right-to-left scan plus one reversal pass.
    // Space Complexity: O(n) - the output list stores up to n leaders.
    public List<int> leaders(int[] arr)
    {
        List<int> temp = new List<int>();

        int n = arr.Length;

        // The last element has nothing to its right, so it is always a leader.
        temp.Add(arr[n - 1]);

        int leader = arr[n - 1];

        // Scan from right to left, tracking the max seen so far.
        for (int i = n - 2; i >= 0; i--)
        {
            if (arr[i] >= leader)
            {
                // Current element beats everything to its right -> it's a leader.
                leader = arr[i];
                // Append (O(1)); leaders are collected in reverse order for now.
                temp.Add(arr[i]);
            }
        }

        // Reverse in place with two pointers to restore original left-to-right order.
        int lb = 0, ub = temp.Count - 1;

        while (lb < ub)
        {
            int placeholder = temp[lb];
            temp[lb] = temp[ub];
            temp[ub] = placeholder;

            lb++;
            ub--;
        }
        return temp;
    }
}


class Program
{
    public static void Main()
    {
        int[] arr = { 10, 4, 2, 4, 1 };

        Solution s = new Solution();

        var result = s.leaders(arr);

        foreach (int num in result)
        {
            Console.Write($"{num}" + " ");
        }
    }
}