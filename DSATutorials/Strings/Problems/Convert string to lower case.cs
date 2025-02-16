
//public class Solution
//{
//    //Time : O(n) , space :O(n)
//    public string ToLowerCase(string str)
//    {
//        if (string.IsNullOrWhiteSpace(str))
//        {
//            return string.Empty;
//        }

//        char[] chr = str.ToCharArray();

//        // Iterate over all the characters and convert to lower case
//        for (int i = 0; i < chr.Length; i++)
//        {
//            if (chr[i] >= 'A' && chr[i] <= 'Z')
//            {
//                // do conversion
//                int index = chr[i] - 'A';
//                chr[i] = (char)('a' + index);
//            }
//            else
//            {
//                // skip as the number is already converted
//                continue;
//            }
//        }
//        return new string(chr);
//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        Solution sol = new Solution();
//        string s = "LOVELY";
//        Console.WriteLine(sol.ToLowerCase(s));
//    }
//}