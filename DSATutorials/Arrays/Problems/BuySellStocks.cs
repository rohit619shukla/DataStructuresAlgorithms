//public class Solution
//{

//    //Time :(N^2) , space :O(1)
//    //public int MaxProfit(int[] prices)
//    //{
//    //    if (prices == null || prices.Length == 0)
//    //    {
//    //        return 0;
//    //    }

//    //    int maxProfit = 0;

//    //    for (int i = 0; i < prices.Length; i++)
//    //    {
//    //        for (int j = i + 1; j < prices.Length; j++)
//    //        {
//    //            // We have got a selling price greater than buying price
//    //            if (prices[i] < prices[j])
//    //            {
//    //                int profit = prices[j] - prices[i];
//    //                maxProfit = Math.Max(maxProfit, profit);
//    //            }
//    //        }
//    //    }

//    //    return maxProfit;
//    //}


//    // Time :O(n), space :O(1)
//    public int MaxProfit(int[] prices)
//    {
//        if (prices == null || prices.Length == 0)
//        {
//            return 0;
//        }

//        int maxProfit = 0, currProfit = 0, buyPrice = prices[0];

//        for (int i = 1; i < prices.Length; i++)
//        {
//            if (buyPrice > prices[i])
//            {
//                buyPrice = prices[i];
//            }
//            else
//            {
//                currProfit = prices[i] - buyPrice;
//                maxProfit = Math.Max(maxProfit, currProfit);
//            }
//        }
//        return maxProfit;
//    }
//}

//class Program
//{
//    public static void Main()
//    {
//        int[] prices = { 7, 1, 5, 3, 6, 4 };

//        Solution s = new Solution();

//        Console.WriteLine(s.MaxProfit(prices));
//    }
//}