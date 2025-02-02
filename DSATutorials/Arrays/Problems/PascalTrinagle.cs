//public class Solution
//{

//    // Time : O(N^2)  , space :O(N^2) due to result list , Aux : O(1)
//    public IList<IList<int>> Generate(int numRows)
//    {
//        var result = new List<IList<int>>();

//        for (int i = 0; i < numRows; i++)
//        {
//            var row = new List<int>();

//            // cols will be row + 1
//            for (int j = 0; j <= i; j++)
//            {
//                if (j == 0 || j == i)
//                    row.Add(1);
//                else
//                    row.Add(result[i - 1][j - 1] + result[i - 1][j]);
//            }
//            result.Add(row);
//        }

//        return result;
//    }
//}

//class Program
//{
//    public static void Main()
//    {
//        int num = 5;

//        Solution s = new Solution();

//        var result = s.Generate(num);

//        foreach (List<int> row in result)
//        {
//            foreach (int col in row)
//            {
//                Console.Write($"{col}" + " ");
//            }

//            Console.WriteLine();
//        }
//    }
//}