//using System;

//class StringHelper
//{
//    public void RemoveSpaceFromString(string str)
//    {
//        if (string.IsNullOrWhiteSpace(str))
//        {
//            return;
//        }

//        char[] ch = str.ToCharArray();

//        int j = 0;
//        for (int i = 0; i < ch.Length; i++)
//        {
//            if (ch[i] != ' ')
//            {
//                ch[j] = ch[i];
//                j++;
//            }
//        }

//        Array.Resize(ref ch, j);
//        str = new string(ch);

//        Console.WriteLine(str);
//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        string str = " Bablo Bintook tu to mast hai bawa re huu haa";

//        StringHelper s = new StringHelper();
//        s.RemoveSpaceFromString(str);
//    }
//}

//// Complexity : O(N)