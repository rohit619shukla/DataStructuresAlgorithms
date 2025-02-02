//public class Solution
//{
//    // Time : O(n) , space :O(1)
//    public int[] TwoSum(int[] numbers, int target)
//    {
//        int start = 0, end = numbers.Length - 1;

//        while (start <= end)
//        {
//            int sum = numbers[start] + numbers[end];

//            if (sum == target)
//            {
//                return new int[] { start + 1, end + 1 };
//            }

//            if (sum > target)
//            {
//                end--;
//            }
//            else
//            {
//                start++;
//            }
//        }

//        return new int[] { -1, -1 };
//    }
//}

//class Program
//{
//    public static void Main()
//    {
//        int[] arr = { 2, 7, 11, 15 };

//        Solution s = new Solution();

//        var result = s.TwoSum(arr, 9);

//        foreach (int item in result)
//        {
//            Console.Write($"{item}" + " ");
//        }
//    }
//}