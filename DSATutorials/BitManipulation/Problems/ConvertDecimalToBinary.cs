//using System;

//class TestClass
//{
//    public void ConvertDecimalToBinary(int num)
//    {

//        string result = "";

//        while (num >= 1)                                                                                          
//        {
//            int remainder = num % 2;
//            result += remainder.ToString();
//            num = num / 2;
//        }

//        ReverseString(result);
//    }

//    private void ReverseString(string result)
//    {
//        int lb = 0;
//        int ub = result.Length - 1;
//        char[] finalResult = result.ToCharArray();

//        while (lb <= ub)
//        {
//            char temp = finalResult[lb];
//            finalResult[lb] = finalResult[ub];
//            finalResult[ub] = temp;

//            lb++;
//            ub--;
//        }

//        for (int i = 0; i < finalResult.Length; i++)
//        {
//            Console.Write($"{finalResult[i]}" + " ");
//        }
//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        TestClass t = new TestClass();
//        t.ConvertDecimalToBinary(29);
//    }
//}

//// Complexity : O(Logn), space : O(1)