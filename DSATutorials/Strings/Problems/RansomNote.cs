//public class Solution
//{
//    // Time :  O(n) , space :O(1)
//    public bool CanConstruct(string ransomNote, string magazine)
//    {
//        int[] freq = new int[26];

//        for (int i = 0; i < ransomNote.Length; i++)
//        {
//            freq[ransomNote[i] - 'a']++;
//        }

//        for (int j = 0; j < magazine.Length; j++)
//        {
//            freq[magazine[j] - 'a']--;
//        }

//        if (!CountGreaterThanZero(freq))
//        {
//            return false;
//        }

//        return true;
//    }

//    private bool CountGreaterThanZero(int[] freq)
//    {
//        for (int k = 0; k < freq.Length; k++)
//        {
//            if (freq[k] > 0)
//            {
//                return false;
//            }
//        }

//        return true;
//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        string ransom = "aa";
//        string mag = "aab";

//        Solution s = new Solution();

//        Console.WriteLine(s.CanConstruct(ransom, mag));
//    }
//}