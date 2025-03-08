//using System.Text;

//public class Solution
//{
//    // Time : O(1) , space :O(1) since everything is fixed in terms of inputs and number of operations  O(1)
//    //Roman numerals typically don't go beyond 3999
//    public string IntToRoman(int num)
//    {
//        StringBuilder sb = new StringBuilder();

//        int[] nums = { 1, 4, 5, 9, 10, 40, 50, 90, 100, 400, 500, 900, 1000 };
//        string[] romans = { "I", "IV", "V", "IX", "X", "XL", "L", "XC", "C", "CD", "D", "CM", "M" };

//        // Step 1: Traverse the nums array in reverse order
//        int i = nums.Length - 1;

//        while (num > 0)
//        {
//            // How many times to print the roman number
//            int times = num / nums[i];

//            // get the next number
//            num = num % nums[i];

//            while (times > 0)
//            {
//                sb.Append(romans[i]);
//                times--;
//            }
//            i--;
//        }

//        return sb.ToString();
//    }
//}

//class Program
//{
//    public static void Main()
//    {
//        int num = 3749;

//        Solution s = new Solution();

//        Console.WriteLine(s.IntToRoman(num));
//    }
//}