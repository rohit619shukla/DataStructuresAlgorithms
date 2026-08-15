
//class Solution
//{
//    // Time :O(n) , space :O(1) due to the fact that dictionary will have only 7 elements
//    public int RomanToInt(string str)
//    {
//        Dictionary<char, int> map = new Dictionary<char, int>
//        {
//            {'I', 1 },
//            {'V', 5 },
//            {'X', 10 },
//            {'L', 50 },
//            {'C', 100 },
//            {'D', 500 },
//            {'M', 1000 }
//        };

//        int result = 0;
//        int prev = 0;

//        // For roman numerals better to start with last character
//        for (int i = str.Length - 1; i >= 0; i--)
//        {
//            int curr = map[str[i]];

//            if (prev < curr)
//            {
//                result += curr;
//            }
//            else
//            {
//                result -= curr;
//            }
//            prev = curr;
//        }

//        return result;
//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        string str = "MCMXCIV";

//        Solution s = new Solution();
//        Console.WriteLine(s.RomanToInt(str));
//    }
//}