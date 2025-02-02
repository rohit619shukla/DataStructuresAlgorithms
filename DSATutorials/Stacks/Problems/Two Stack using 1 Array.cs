//using System;
//using System.Collections.Generic;

//class Helper
//{
//    private int[] N;
//    private int top1;
//    private int top2;

//    public Helper(int size)
//    {
//        N = new int[size];
//        top1 = -1;
//        top2 = size;
//    }

//    public void Push1(int num)
//    {
//        if (top1 + 1 == top2)
//        {
//            Console.WriteLine($"Stack Overflow By element{num}");
//        }
//        else
//        {
//            top1++;
//            N[top1] = num;
//            Console.WriteLine($"Node inserted is : {num}");
//        }
//    }

//    public void Push2(int num)
//    {
//        if (top1 + 1 == top2)
//        {
//            Console.WriteLine($"Stack Overflow By element{num}");
//        }
//        else
//        {
//            top2--;
//            N[top2] = num;
//            Console.WriteLine($"Node inserted is : {num}");
//        }
//    }

//    public void Pop1()
//    {
//        if (top1 == -1)
//        {
//            Console.WriteLine($"Stack empty");
//        }
//        else
//        {
//            int num = N[top1];
//            top1--;
//            Console.WriteLine($"Popped element from stack1 is : {num}");
//        }
//    }

//    public void Pop2()
//    {
//        if (top2 == -1)
//        {
//            Console.WriteLine($"Stack empty");
//        }
//        else
//        {
//            int num = N[top2];
//            top2++;
//            Console.WriteLine($"Popped element from stack2 is :{num}");
//        }
//    }
//}

//class Program
//{
//    public static void Main()
//    {
//        Helper h = new Helper(5);
//        h.Push1(5);
//        h.Push2(10);
//        h.Push2(15);
//        h.Push1(11);
//        h.Push2(7);
//        h.Pop1();
//        h.Push2(40);
//        h.Pop2();
//    }
//}

///* Complexity : O(1), Space : O(N) due to use of Array Auxillary */