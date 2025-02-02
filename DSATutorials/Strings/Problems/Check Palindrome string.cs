//using System;

//class Palindrome
//{
//    public bool IsPalindrome(string str, int lb, int ub)
//    {
//        if (string.IsNullOrWhiteSpace(str)) 
//        {
//            return false;
//        }
        
//        while (lb < ub)
//        {
//            if (str[lb] == str[ub])
//            {
//                lb++;
//                ub--;
//            }
//            else
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
//        string str = "GeeksforGeeks";
//        Palindrome p = new Palindrome();
//        Console.WriteLine(p.IsPalindrome(str, 0, str.Length - 1));
//    }
//}

//// Complexity : O(N), space : O(1)