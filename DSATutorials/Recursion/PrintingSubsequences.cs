
//class Solution
//{
//    public IList<IList<int>> PrintSubsequence(int[] arr)
//    {
//        IList<IList<int>> result = new List<IList<int>>();
//        IList<int> tempList = new List<int>();

//        Recursion(result, tempList, 0, arr);

//        return result;
//    }

//    private void Recursion(IList<IList<int>> result, IList<int> tempList, int index, int[] arr)
//    {
//        // base case
//        if (index == arr.Length)
//        {
//            result.Add(new List<int>(tempList));
//            return;
//        }

//        // Add the element in list
//        tempList.Add(arr[index]);

//        // Recursion
//        Recursion(result, tempList, index + 1, arr);

//        // Backtracking
//        tempList.RemoveAt(tempList.Count - 1);

//        // Move to next in index
//        Recursion(result, tempList, index + 1, arr);
//    }
//}

//class Program
//{
//    public static void Main()
//    {
//        int[] arr = { 3, 1, 2 };

//        Solution s = new Solution();

//        var result = s.PrintSubsequence(arr);

//        foreach (var item in result)
//        {
//            for (int i = 0; i < item.Count; i++)
//            {
//                Console.Write($"{item[i]}" + " ");
//            }
//            Console.WriteLine();
//        }
//    }
//}

////The complexity of such a function is typically O(2^n), where n is the length of the array.
////This is because the function explores two possibilities at each step: either include the current element in the subset or exclude it,	