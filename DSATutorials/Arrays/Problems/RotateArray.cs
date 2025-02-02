//public class Solution
//{
//    // Time : O(k * n) , space :O(1)
//    public void Rotate(int[] nums, int k)
//    {

//        for (int i = 0; i < k; i++)
//        {
//            int temp = nums[nums.Length - 1];

//            for (int j = nums.Length - 2; j >= 0; j--)
//            {
//                nums[j + 1] = nums[j];
//            }
//            nums[0] = temp;
//        }

//        foreach (int item in nums)
//        {
//            Console.Write($"{item}" + " ");
//        }
//    }


//    // Time :O(n) , space :O(1) 
//    //public void Rotate(int[] nums, int k)
//    //{
//    //    int n = nums.Length;
//    //    k %= n;
//    //    Reverse(nums, 0, n - 1);
//    //    Reverse(nums, 0, k - 1);
//    //    Reverse(nums, k, n - 1);

//    //    foreach (int item in nums)
//    //    {
//    //        Console.Write($"{item}" + " ");
//    //    }
//    //}

//    //private void Reverse(int[] nums, int start, int end)
//    //{
//    //    while (start < end)
//    //    {
//    //        int temp = nums[start];
//    //        nums[start] = nums[end];
//    //        nums[end] = temp;
//    //        start++;
//    //        end--;
//    //    }
//    //}
//}

//class Program
//{
//    public static void Main()
//    {
//        int[] arr = { 1, 2, 3, 4, 5, 6, 7 };

//        Solution s = new Solution();

//        s.Rotate(arr, 3);
//    }
//}