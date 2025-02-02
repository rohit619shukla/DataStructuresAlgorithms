

//public class Solution
//{
//    // Time :O(N^3) + O(nlogn) , space :O(n)
//    public IList<IList<int>> FourSum(int[] arr, int target)
//    {
//        // base case
//        if (arr.Length < 4)
//        {
//            return null;
//        }

//        var result = new List<IList<int>>();

//        // Step 1: Sort the array
//        Array.Sort(arr);

//        // Step 2: Fix first number : we expect atleast 3 numbers to remain after selecting 1st number
//        for (int i = 0; i < arr.Length - 3; i++)
//        {
//            // duplicate check
//            if (i > 0 && arr[i] == arr[i - 1])
//            {
//                continue;
//            }

//            // Step 3:Fix the second number: we expect atleast 2  numbers to remain after selecting 2nd number
//            for (int j = i + 1; j < arr.Length - 2; j++)
//            {
//                // duplicate check
//                if (j > i + 1 && arr[j] == arr[j - 1])
//                {
//                    continue;
//                }

//                // Step 4: create a new target to determine based on what we did in 3 sum 
//                long newTarget = (long)target - arr[i] - arr[j];

//                // Step 5 : call two sum
//                TwoSum(result, arr, newTarget, j + 1, arr.Length - 1, i, j);
//            }

//        }

//        return result;
//    }

//    private void TwoSum(List<IList<int>> result, int[] arr, long newTarget, int k, int l, int i, int j)
//    {
//        // These 2 are variables
//        while (k < l)
//        {
//            long sum = (long)arr[k] + arr[l];

//            if (sum == newTarget)
//            {
//                result.Add(new List<int> { arr[i], arr[j], arr[k], arr[l] });

//                while (k < l && arr[k] == arr[k + 1])
//                {
//                    k++;
//                }

//                while (k < l && arr[l] == arr[l - 1])
//                {
//                    l--;
//                }

//                k++;
//                l--;
//            }
//            else if (sum > newTarget)
//            {
//                l--;
//            }
//            else
//            {
//                k++;
//            }
//        }
//    }
//}

//class Program
//{
//    public static void Main()
//    {
//        int[] nums = { 1, 0, -1, 0, -2, 2 };

//        Solution s = new Solution();

//        var result = s.FourSum(nums, 0);

//        foreach (var rows in result)
//        {
//            foreach (var val in rows)
//            {
//                Console.Write($"{val}" + " ");
//            }
//            Console.WriteLine();
//        }
//    }
//}