
//public class Solution
//{
//    private long MOD = (long)1e9 + 7;

//    // Time :O(Logn)
//    public int CountGoodNumbers(long n)
//    {
//        //This is basically like we can place 5 even numbers at even index and 4 prime numbers at odd indexes
//        long evenIndices = (n + 1) / 2;
//        long oddIndices = n / 2;

//        // Multiply the two results and apply modulo one last time
//        long result = (Pow(5, evenIndices) * Pow(4, oddIndices)) % MOD;
//        return (int)result;
//    }

//    private long Pow(long x, long n)
//    {
//        if (n == 0)
//        {
//            return 1;
//        }

//        if (n % 2 == 0)
//        {
//            // Instead of Pow(x * x, n / 2), calculate the square with modulo
//            return Pow((x * x) % MOD, n / 2);
//        }
//        else
//        {
//            // Apply modulo after multiplying by x
//            return (x * Pow((x * x) % MOD, (n - 1) / 2)) % MOD;
//        }
//    }

//}

//class Program
//{
//    public static void Main()
//    {
//        long n = 50;

//        Solution s = new Solution();

//        Console.WriteLine(s.CountGoodNumbers(n));
//    }
//}

////Note: In modulo arithmetic we tend to do MOD at every place where we multiply