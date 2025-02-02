
//public class Solution
//{
//    // Time :O(nlogn) + O(n^2) , space :O(n) for result and o(logn) for stack space for Quick sort
//    public IList<IList<int>> ThreeSum(int[] nums)
//    {
//        var result = new List<IList<int>>();

//        // Step 1: Since wer are asked to retun actual numbers we will sort the array
//        Array.Sort(nums);

//        // n-2 so that we have triplets
//        for (int i = 0; i < nums.Length - 2; i++)
//        {
//            if (i > 0 && nums[i] == nums[i - 1])
//            {
//                continue;
//            }
//            // Step 2: n1+n2+n3 = 0, can be written as : n2+n3 = -(n1).
//            // We are basically converting to 2 sum problem
//            int n1 = nums[i];
//            int target = -n1;

//            // step 3: Calualte 2 sum now

//            TwoSum(result, nums, i + 1, nums.Length - 1, target);

//        }

//        return result;
//    }

//    private void TwoSum(List<IList<int>> result, int[] nums, int i, int j, int target)
//    {
//        while (i < j)
//        {
//            int sum = nums[i] + nums[j];

//            if (sum == target)
//            {
//                result.Add(new List<int> { -target, nums[i], nums[j] });

//                while (i < j && nums[i] == nums[i + 1])
//                {
//                    i++;
//                }

//                while (i < j && nums[j] == nums[j - 1])
//                {
//                    j--;
//                }

//                i++;
//                j--;
//            }
//            else if (sum > target)
//            {
//                j--;
//            }
//            else
//            {
//                i++;
//            }
//        }
//    }
//}


//class Program
//{
//    public static void Main()
//    {
//        int[] nums = { -2, 0, 0, 1, 2 };

//        //int[] nums = { -1, 0, 1, 2, -1, -4 };

//        Solution s = new Solution();

//        var result = s.ThreeSum(nums);

//        foreach (var list in result)
//        {
//            foreach (var item in list)
//            {
//                Console.Write($"{item}" + " ");
//            }
//            Console.WriteLine();
//        }
//    }
//}