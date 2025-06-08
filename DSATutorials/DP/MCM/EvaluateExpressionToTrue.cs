
//using System.Net.Sockets;

//class Solution
//{
//    public long Ways(string exp)
//    {
//        long[,,] dp = new long[exp.Length, exp.Length, 2];

//        for (int i = 0; i < dp.GetLength(0); i++)
//        {
//            for (int j = 0; j < dp.GetLength(1); j++)
//            {
//                for (int k = 0; k < dp.GetLength(2); k++)
//                {
//                    dp[i, j, k] = -1;
//                }
//            }
//        }

//        //return Solve(exp, 0, exp.Length - 1, 1);
//        return Solve(exp, 0, exp.Length - 1, 1, dp);
//    }

//    // Time : O(4^n) , space : O(n)
//    private long Solve(string exp, int i, int j, int isTrue)
//    {
//        // base case
//        // 1. No more partitions
//        if (i > j)
//        {
//            return 0;
//        }

//        // 2. In case we are left we just 1 char
//        if (i == j)
//        {
//            // In case we are looking for a true or false.
//            // Remember we might need true or false both
//            if (isTrue == 1)
//            {
//                return exp[i] == 'T' ? 1 : 0;
//            }
//            else
//            {
//                return exp[i] == 'F' ? 1 : 0;
//            }
//        }

//        long ways = 0;

//        // Start MCM
//        for (int k = i + 1; k <= j - 1; k += 2)
//        {
//            // Get all 4 ways for expresssion to be true or false
//            long lT = Solve(exp, i, k - 1, 1);
//            long lF = Solve(exp, i, k - 1, 0);
//            long rT = Solve(exp, k + 1, j, 1);
//            long rF = Solve(exp, k + 1, j, 0);


//            // Now start check for characters at which break was applied
//            char ch = exp[k];

//            switch (ch)
//            {
//                case '&':
//                    if (isTrue == 1)
//                    {
//                        ways += (lT * rT);
//                    }
//                    else
//                    {
//                        ways += (lT * rF) + (lF * rT) + (lF * rF);
//                    }
//                    break;

//                case '|':
//                    if (isTrue == 1)
//                    {
//                        ways += (lT * rF) + (lF * rT);
//                    }
//                    else
//                    {
//                        ways += (lF * rF);
//                    }
//                    break;

//                case '^':
//                    if (isTrue == 1)
//                    {
//                        ways += (lF * rT) + (rF * lT);
//                    }
//                    else
//                    {
//                        ways += (lF * rF) + (lT * rT);
//                    }
//                    break;

//                default:
//                    ways += 0;
//                    break;
//            }
//        }

//        return ways;
//    }

//    // Time : O(N^3) , space : O(N^2)+O(N)
//    private long Solve(string exp, int i, int j, int isTrue, long[,,] dp)
//    {
//        // base case
//        // 1. No more partitions
//        if (i > j)
//        {
//            return 0;
//        }

//        // 2. In case we are left we just 1 char
//        if (i == j)
//        {
//            // In case we are looking for a true or false.
//            // Remember we might need true or false both
//            if (isTrue == 1)
//            {
//                return exp[i] == 'T' ? 1 : 0;
//            }
//            else
//            {
//                return exp[i] == 'F' ? 1 : 0;
//            }
//        }

//        if (dp[i, j, isTrue] != -1)
//        {
//            return dp[i, j, isTrue];
//        }

//        long ways = 0;

//        // Start MCM
//        for (int k = i + 1; k <= j - 1; k += 2)
//        {
//            // Get all 4 ways for expresssion to be true or false
//            long lT = Solve(exp, i, k - 1, 1, dp);
//            long lF = Solve(exp, i, k - 1, 0, dp);
//            long rT = Solve(exp, k + 1, j, 1, dp);
//            long rF = Solve(exp, k + 1, j, 0, dp);


//            // Now start check for characters at which break was applied
//            char ch = exp[k];

//            switch (ch)
//            {
//                case '&':
//                    if (isTrue == 1)
//                    {
//                        ways += (lT * rT);
//                    }
//                    else
//                    {
//                        ways += (lT * rF) + (lF * rT) + (lF * rF);
//                    }
//                    break;

//                case '|':
//                    if (isTrue == 1)
//                    {
//                        ways += (lT * rF) + (lF * rT) + (lT * rT);

//                    }
//                    else
//                    {
//                        ways += (lF * rF);
//                    }
//                    break;

//                case '^':
//                    if (isTrue == 1)
//                    {
//                        ways += (lF * rT) + (rF * lT);
//                    }
//                    else
//                    {
//                        ways += (lF * rF) + (lT * rT);
//                    }
//                    break;

//                default:
//                    ways += 0;
//                    break;
//            }
//        }

//        return dp[i, j, isTrue] = ways;
//    }
//}

//class Program
//{
//    public static void Main()
//    {

//        string exp = "F|T^F";

//        Solution s = new Solution();

//        Console.WriteLine(s.Ways(exp));
//    }
//}