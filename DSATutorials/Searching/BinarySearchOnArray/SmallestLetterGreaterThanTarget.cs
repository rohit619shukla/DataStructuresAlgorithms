
//class Solution
//{
//    public char NextGreatestLetter(char[] letters, char target)
//    {
//        int lb = 0;
//        int ub = letters.Length - 1;
//        int result = -1;

//        while (lb <= ub)
//        {
//            int mid = lb + (ub - lb) / 2;

//            // We will not return, but instead move to right for next element
//            if (letters[mid] == target)
//            {
//                lb = mid + 1;
//                continue;
//            }

//            if (letters[mid] > target)
//            {
//                result = mid;
//                ub = mid - 1;
//            }
//            else
//            {
//                lb = mid + 1;
//            }
//        }

//        return result != -1 ? letters[result] : letters[0];
//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        char[] chr = { 'c', 'f', 'j' };

//        char target = 'c';

//        Solution s = new Solution();

//        Console.WriteLine(s.NextGreatestLetter(chr, target));
//    }
//}

//// Time : O(Logn), space : O(1)