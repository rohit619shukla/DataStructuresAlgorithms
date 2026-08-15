//public class Solution
//{
//    // Time :O(32) => O(1)
//    public int MinBitFlips(int start, int goal)
//    {
//        // Step1 : Get the xor for both numbers as xor will give the bits that are different
//        int xorNumber = start ^ goal;

//        // Step2 : Traverse the xorNumber and check if the bit is set, if yes then flip the bits
//        int count = 0;

//        while (xorNumber > 0)
//        {
//            xorNumber &= xorNumber - 1; 
//            count++;
//        }

//        return count;
//    }
//}

//class Program
//{
//    public static void Main()
//    {
//        int start = 10, goal = 7;

//        Solution s = new Solution();

//        Console.WriteLine(s.MinBitFlips(start, goal));
//    }
//}

//// This is classic use of Brian Kernighan's Algorithm to count the number of set bits in a number.