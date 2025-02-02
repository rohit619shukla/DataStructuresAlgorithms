//public class Solution
//{
//    public int[] RearrangeArray(int[] nums)
//    {
//        int[] result = new int[nums.Length];

//        int posPointer = 0, negPointer = 1;

//        for (int i = 0; i < nums.Length; i++)
//        {
//            if (nums[i] > 0)
//            {
//                result[posPointer] = nums[i];
//                posPointer += 2;
//            }
//            else
//            {
//                result[negPointer] = nums[i];
//                negPointer += 2;
//            }
//        }

//        return result;
//    }
//}

//class Program
//{
//    public static void Main()
//    {
//        int[] arr = { 3, 1, -2, -5, 2, -4 };

//        Solution s = new Solution();

//        var result = s.RearrangeArray(arr);

//        foreach (int item in result)
//        {
//            Console.Write($"{item}" + " ");
//        }
//    }
//}