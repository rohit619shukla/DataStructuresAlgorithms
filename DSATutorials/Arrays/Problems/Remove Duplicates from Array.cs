

//class Solution
//{
//    public int RemoveDuplicates(int[] nums)
//    {
//        if (nums == null || nums.Length == 0)
//        {
//            return -1;
//        }

//        int i = 0;

//        for (int j = 0; j < nums.Length; j++)
//        {
//            if (nums[i] != nums[j])
//            {
//                nums[i + 1] = nums[j];
//                i++;
//            }
//        }

//        return i+1;
//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        int[] arr = { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 };

//        Solution s = new Solution();

//        Console.WriteLine(s.RemoveDuplicates(arr));
//    }
//}