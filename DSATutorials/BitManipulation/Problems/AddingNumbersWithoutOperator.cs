//using System;

//class Test
//{

//    public void ComputeAdditionOfTwoNumbers(int n1, int n2)
//    {
//        while (n2 != 0)
//        {
//            int carry = n1 & n2;                      /* gives us where the carry actually happened */
//            n1 = n1 ^ n2;                             /* performs actuall addition */
//            n2 = carry << 1;                          /* applies the carry to left side from where it was discovered */
//        }
//        Console.WriteLine($"{n1}");
//    }

//}
//class Program
//{
//    public static void Main(string[] args)
//    {
//        Test t = new Test();
//        t.ComputeAdditionOfTwoNumbers(-2, 3);
//        t.ComputeAdditionOfTwoNumbers(1, 2);
//    }
//}

////Complexity: O(logy), Space: O(1 