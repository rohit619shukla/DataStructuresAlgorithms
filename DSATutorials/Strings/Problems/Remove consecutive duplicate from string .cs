//using System;

//class StringHelper
//{
//    public void RemoveConsecutiveDuplicates(string str)
//    {
//        if (string.IsNullOrWhiteSpace(str))
//        {
//            return;
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

//        Array.Resize(ref ch, i + 1);
//        Console.WriteLine(new String(ch));
//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        string str = "aabccba";

//        StringHelper s = new StringHelper();
//        s.RemoveConsecutiveDuplicates(str);
//    }
//}

//// Complexity : O(N), Space :O(1)