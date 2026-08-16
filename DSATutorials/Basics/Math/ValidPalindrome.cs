
//using System.Numerics;
//using System.Text;

//public class Solution
//{
//    // Time  : O(n) - each pointer traverses the string at most once
//    // Space : O(1) - only two integer pointers are used, no extra buffer
//    public bool IsPalindrome(string s)
//    {
//        // Guard against null / empty / whitespace-only input
//        if (string.IsNullOrWhiteSpace(s))
//        {
//            return false;
//        }

//        // Two pointer technique to avoid using extra space
//        int lb = 0;                 // left pointer, moves forward
//        int ub = s.Length - 1;      // right pointer, moves backward

//        while (lb < ub)
//        {
//            // Skip any non-alphanumeric chars on the left side
//            while (lb < ub && !IsAlphaNumeric(s[lb]))
//            {
//                lb++;
//            }

//            // Skip any non-alphanumeric chars on the right side
//            while (lb < ub && !IsAlphaNumeric(s[ub]))
//            {
//                ub--;
//            }

//            // Compare the two valid chars case-insensitively; mismatch => not a palindrome
//            if (ToLower(s[lb]) != ToLower(s[ub]))
//            {
//                return false;
//            }

//            // Move both pointers inward for the next comparison
//            lb++;
//            ub--;
//        }

//        // All comparisons matched => it is a palindrome
//        return true;
//    }

//    // Returns true if the char is A-Z, a-z, or 0-9
//    private bool IsAlphaNumeric(char ch)
//    {
//        return ((ch >= 'A' && ch <= 'Z') || (ch >= 'a' && ch <= 'z') || (ch >= '0' && ch <= '9'));
//    }

//    // Converts an uppercase letter to lowercase; other chars are returned unchanged
//    private char ToLower(char ch)
//    {
//        if (ch >= 'A' && ch <= 'Z')
//        {
//            // offset within the alphabet, then map into the lowercase range
//            int index = ch - 'A';
//            return (char)(index + 'a');
//        }

//        return ch;
//    }

//}

//class Program
//{
//    public static void Main()
//    {
//        Solution s = new Solution();

//        string str = "A man, a plan, a canal: Panama";
//        Console.WriteLine(s.IsPalindrome(str));
//    }
//}