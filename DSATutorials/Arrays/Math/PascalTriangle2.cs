// public class Solution
// {
//     public IList<int> GetRow(int rowIndex)
//     {
//         // Building the entire triangle and returning the requested row would use O(rowIndex^2) space.
//         // Time: O(rowIndex^2). Space: O(rowIndex), including the returned row.

//         List<int> prev = new List<int>();

//         for (int i = 0; i <= rowIndex; i++)
//         {
//             List<int> curr = new List<int>();

//             for (int j = 0; j <= i; j++)
//             {
//                 if (j == 0 || j == i)
//                 {
//                     curr.Add(1);
//                 }
//                 else
//                 {
//                     curr.Add(prev[j - 1] + prev[j]);
//                 }
//             }

//             prev = curr;
//         }

//         return prev;
//     }
// }


// class Program
// {
//     public static void Main()
//     {
//         int rowIndex = 3;

//         Solution s = new Solution();

//         var result = s.GetRow(rowIndex);

//         foreach (int item in result)
//         {
//             Console.Write($"{item}" + " ");
//         }
//     }
// }