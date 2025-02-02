//using System;

//class StringHelper
//{
//    public string ReverseWords(string str)
//    {
//        string[] ch = str.Split(' ');

//        int start = 0, end = 0;

//        int j = 0;
//        for (int i = 0; i < ch.Length; i++)
//        {
//            if (ch[i] != "")
//            {
//                ch[j] = ch[i];
//                j++;
//            }
//        }

//        Array.Resize(ref ch, j);
//        end = j - 1;
//        while (start < end)
//        {
//            Swap(ch, start, end);
//            start++;
//            end--;
//        }

//        str = "";
//        for (int i = 0; i < ch.Length; i++)
//        {
//            str += ch[i];
//            str += " ";
//        }
//        return str.Trim();
//    }


//    private void Swap(string[] ch, int lb, int ub)
//    {
//        string temp = ch[lb];
//        ch[lb] = ch[ub];
//        ch[ub] = temp;
//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        string str = "  hello world  ";

//        StringHelper s = new StringHelper();
//        Console.WriteLine($"{s.ReverseWords(str)}");
//    }
//}

//// Space :O(1), Time : O(N)