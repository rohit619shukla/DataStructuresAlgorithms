
//class Solution
//{
//    public void findSymPairs(int[,] arr)
//    {
//        int rows = arr.GetLength(0);

//        Dictionary<int, int> map = new Dictionary<int, int>();

//        for (int i = 0; i < rows; i++)
//        {
//            int key = arr[i, 0];
//            int value = arr[i, 1];

//            if (!map.ContainsKey(value))
//            {
//                map[key] = value;
//            }
//            else if (map[value] == key)
//            {
//                Console.WriteLine("{" + value + ", " + key + "}");
//            }
//        }

//    }
//}

//class Program
//{
//    public static void Main()
//    {
//        int[,] arr = {
//                       {1, 2}, {2, 1}, {3, 4}, {5, 6}, {6, 5}
//        };

//        Solution s = new Solution();

//        s.findSymPairs(arr);
//    }
//}