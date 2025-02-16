//using System;

//class StringHelper
//{
//    public string RemoveConsecutiveDuplicates(string str)
//    {
//        if (string.IsNullOrWhiteSpace(str))
//        {
//            return null;
//        }

//        int i = 0;

//        char[] ch = str.ToCharArray();

//        for (int j = 0; j < ch.Length; j++)
//        {
//            if (ch[i] != ch[j])
//            {
//                ch[i + 1] = ch[j];
//                i++;
//            }
//        }

//        str = new string(ch);

//        return str.Substring(0, i + 1);
//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        string str = "aabccba";

//        StringHelper s = new StringHelper();
//        Console.WriteLine(s.RemoveConsecutiveDuplicates(str));
//    }
//}

//// Complexity : O(N), Space :O(n)