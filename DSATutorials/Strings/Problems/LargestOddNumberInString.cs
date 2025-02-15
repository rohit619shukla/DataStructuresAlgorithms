//public class Solution
//{

//    // Time :O(N) , space :O(n)
//    // Note  : Substring is called only once inside the loop. although substring takes O(N), hence total is : O(N) + O(N)
//    public string LargestOddNumber(string num)
//    {
//        if (string.IsNullOrWhiteSpace(num))
//        {
//            return num;
//        }


//        for (int i = num.Length - 1; i >= 0; i--)
//        {
//            if ((num[i] - '0') % 2 != 0)
//            {
//                return num.Substring(0, i + 1);
//            }
//        }
//        return string.Empty;
//    }

//}
//class Program
//{
//    public static void Main()
//    {
//        string num = "35427";

//        Solution s = new Solution();

//        Console.WriteLine(s.LargestOddNumber(num));
//    }
//}