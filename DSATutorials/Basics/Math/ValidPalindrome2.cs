//public class Solution
//{
//    // Returns true if s can be a palindrome after removing at most one character.
//    public bool ValidPalindrome(string s)
//    {
//        int lb = 0;                 // left pointer
//        int ub = s.Length - 1;      // right pointer

//        while (lb < ub)
//        {
//            if (s[lb] == s[ub])
//            {
//                // Characters match, move both pointers inward.
//                lb++;
//                ub--;
//            }
//            else
//            {
//                // On the first mismatch, try skipping either the left
//                // or the right character and check if the rest is a palindrome.
//                return IsPalindrome(s, lb + 1, ub) ||
//                    IsPalindrome(s, lb, ub - 1);
//            }
//        }

//        return true;
//    }

//    // Checks whether the substring str[lb..ub] is a palindrome.
//    private bool IsPalindrome(string str, int lb, int ub)
//    {
//        while (lb < ub)
//        {
//            if (str[lb] != str[ub])
//            {
//                return false;
//            }
//            lb++;
//            ub--;
//        }

//        return true;
//    }
//}


//class Program
//{
//    public static void Main()
//    {
//        string str = "cbbcc";

//        Solution s = new Solution();

//        Console.WriteLine(s.ValidPalindrome(str));
//    }
//}

///*
// * Time Complexity:  O(n)
// *   - The main two-pointer scan is O(n).
// *   - On the first mismatch we do at most two additional linear scans
// *     via IsPalindrome, each O(n). Total work stays linear: O(n).
// *
// * Space Complexity: O(1)
// *   - Only a constant number of index variables are used; no extra
// *     data structures are allocated.
// */