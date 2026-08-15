
//using System.Text;

//public class Solution
//{
//    // Time :O(n) , space :O(n)
//    public bool IsPalindrome(string str)
//    {
//        StringBuilder sb = new StringBuilder();
//        // step 1: Remove all spaces and convert to lower case
//        for (int i = 0; i < str.Length; i++)
//        {
//            if (str[i] == ' ')
//            {
//                continue;
//            }
//            else if (str[i] >= 'A' && str[i] <= 'Z')
//            {
//                // Convert to lower case
//                int index = str[i] - 'A';
//                char newChar = (char)(index + 'a');
//                sb.Append(newChar);
//            }
//            else if ((str[i] >= 'a' && str[i] <= 'z') || (str[i] >= 48 && str[i] <= 57))

//            {
//                sb.Append(str[i]);
//            }

//        }
//        return PalindromeCheck(sb.ToString());
//    }


//    private bool PalindromeCheck(string str)
//    {
//        int lb = 0, ub = str.Length - 1;

//        while (lb < ub)
//        {
//            if (str[lb++] != str[ub--])
//            {
//                return false;
//            }
//        }
//        return true;
//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        string str = "0P";

//        Solution sol = new Solution();
//        Console.WriteLine(sol.IsPalindrome(str));
//    }
//}