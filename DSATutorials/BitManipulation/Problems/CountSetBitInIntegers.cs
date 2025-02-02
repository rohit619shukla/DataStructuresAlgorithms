//using System;

//class Test
//{
//    public void Count(int num)
//    {
//        string result = "";


//        while (num >= 1)
//        {
//            int reaminder = num % 2;
//            result += reaminder.ToString();
//            num /= 2;
//        }

//        char[] finalString = result.ToCharArray();
//        int count = 0;
//        foreach (var item in finalString)
//        {
//            if (item == '1')
//            {
//                count++;
//            }
//        }


//        //int count = 0;
//        //while (num > 0)
//        //{
//        //    num = num & (num - 1);
//        //    count++;
//        //}
//        Console.WriteLine(count);
//    }
//}

//class Program
//{
//    public static void Main()
//    {
//        Test test = new Test();
//        test.Count(29);
//    }
//}

////Complexity: O(logy), space: O(1)