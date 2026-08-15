//public class Solution
//{
//    // Complexity: O(nlogn) space : O(n)
//    public string LargestNumber(int[] arr)
//    {
//        List<string> lst = new List<string>();
//        string result = "";

//        // Step 1: Convert all elements to string
//        foreach (var item in arr)
//        {
//            lst.Add(item.ToString());
//        }

//        // Step 2: Sort the list
//        lst.Sort(Compare);


//        // Step 3: add to the list
//        foreach (var item in lst)
//        {
//            result += item;
//        }

//        return result;
//    }

//    private int Compare(string s1, string s2)
//    {
//        string n1 = s1 + s2;
//        string n2 = s2 + s1;

//        return n2.CompareTo(n1);
//    }
//}

//class Program
//{
//    public static void Main()
//    {
//        int[] arr = { 3, 30, 34, 5, 9 };

//        Solution s = new Solution();

//        Console.WriteLine(s.LargestNumber(arr));
//    }
//}