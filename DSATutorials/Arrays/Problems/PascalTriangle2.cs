//public class Solution
//{
//    // Same as 1
//    public IList<int> GetRow(int rowIndex)
//    {
//        var result = new List<IList<int>>();

//        for (int i = 0; i <= rowIndex; i++)
//        {
//            var newRow = new List<int>();

//            for (int j = 0; j <= i; j++)
//            {
//                if (j == 0 || j == i)
//                {
//                    newRow.Add(1);
//                }
//                else
//                {
//                    newRow.Add(result[i - 1][j] + result[i - 1][j - 1]);
//                }
//            }
//            result.Add(newRow);
//        }

//        return result[rowIndex];
//    }
//}

//class Program
//{
//    public static void Main()
//    {
//        int rowIndex = 6;

//        Solution s = new Solution();

//        var result = s.GetRow(rowIndex);

//        foreach (var item in result)
//        {
//            Console.Write($"{item}" + " ");
//        }
//    }
//}