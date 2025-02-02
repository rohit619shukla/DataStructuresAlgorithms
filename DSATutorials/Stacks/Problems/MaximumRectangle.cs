

//public class Solution
//{
//    public int MaximalRectangle(char[][] matrix)
//    {
//        int rows = matrix.Length;
//        int cols = matrix[0].Length;

//        // to store histogram values
//        int[] heights = new int[cols];

//        int maxArea = 0;
//        // Now fill the height array at every level
//        for (int i = 0; i < rows; i++)
//        {
//            int len = cols;
//            for (int j = 0; j < cols; j++)
//            {
//                if (matrix[i][j] == '0')
//                {
//                    heights[j] = 0;
//                }
//                else
//                {
//                    heights[j] += 1;
//                }
//            }

//            //apply histogram code for largest rectangle
//            Stack<int> st = new Stack<int>();

//            for (int j = 0; j <= len; j++)
//            {
//                int currentHeight = (j == len ? 0 : heights[j]);
//                while (st.Count > 0 && heights[st.Peek()] > currentHeight)
//                {
//                    int height = heights[st.Pop()];
//                    int width = (st.Count == 0 ? j : j - st.Peek() - 1);
//                    maxArea = Math.Max(maxArea, height * width);
//                }
//                st.Push(j);
//            }
//        }

//        return maxArea;
//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        char[][] matrix = new char[][] {
//            new char[]{'1','0','1','0','0' },
//            new char[]{ '1','0','1','1','1'},
//            new char[]{ '1','1','1','1','1'},
//            new char[]{ '1','0','0','1','0'}
//        };

//        Solution s = new Solution();

//        Console.WriteLine(s.MaximalRectangle(matrix));
//    }
//}

//// Time :O(rows*cols), space :O(cols)