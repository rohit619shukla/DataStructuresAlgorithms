


//class Solution
//{
//    //The complexity of such a function is typically O(2^n), where n is the length of the array.
//    //This is because the function explores two possibilities at each step: either include the current element in the subset or exclude it,
//    public void Solve(int[] arr, int index, IList<int> currentList, IList<IList<int>> resultList)
//    {
//        // base case, we reached last index
//        if (index == arr.Length)
//        {
//            resultList.Add(new List<int>(currentList));
//            return;
//        }

//        // Take condition
//        currentList.Add(arr[index]);

//        // Move to next position
//        Solve(arr, index + 1, currentList, resultList);

//        // Backtrack, nottake
//        currentList.RemoveAt(currentList.Count - 1);

//        // Move to next position
//        Solve(arr, index + 1, currentList, resultList);
//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        int[] arr = { 3, 1, 2 };

//        Solution h = new Solution();

//        IList<IList<int>> resultList = new List<IList<int>>();

//        List<int> currentList = new List<int>();

//        h.Solve(arr, 0, currentList, resultList);

//        foreach (var item in resultList)
//        {
//            for (int i = 0; i < item.Count; i++)
//            {
//                Console.Write($"{item[i]}" + " ");
//            }
//            Console.WriteLine();
//        }
//    }
//}