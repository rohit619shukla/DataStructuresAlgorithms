//using System;

//class StringHelper
//{
//    public void RemoveSpaceFromString(string str)
//    {
//        int i = 0, j = 0;

//        char[] chr = str.ToCharArray();

//        for (j = 0; j < str.Length; j++)
//        {
//            if (chr[j] != ' ')
//            {
//                chr[i] = chr[j];
//                i++;
//            }
//        }

//        str = new string(chr);

//        Console.WriteLine(str.Substring(0, i));
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