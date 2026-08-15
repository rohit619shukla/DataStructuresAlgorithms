
//class Solution
//{
//    public int CountBits(int num)
//    {
//        int count = 0;

//        while (num > 0)
//        {
//            num &= (num - 1);
//            count++;
//        }

//        return count;
//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        int num = 13;

//        Solution s = new Solution();

//        Console.WriteLine(s.CountBits(num));
//    }
//}