//using System;

//class Helper
//{
//    public void Conversion(int num)
//    {
//        string result = "";

//        while (num > 0)
//        {
//            result += num % 10;
//            num = num / 10;
//        }

//        Console.WriteLine($"{ReverString(result, 0, result.Length - 1)}");
//    }

//    private string ReverString(string str, int lb, int ub)
//    {
//        char[] ch = str.ToCharArray();

//        while (lb < ub)
//        {
//            char temp = ch[lb];
//            ch[lb] = ch[ub];
//            ch[ub] = temp;

//            lb++;
//            ub--;
//        }

//        return new string(ch);
//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        int num = 12345;

//        Helper h = new Helper();
//        h.Conversion(num);
//    }
//}