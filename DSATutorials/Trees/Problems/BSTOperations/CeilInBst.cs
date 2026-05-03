// // Note : Ceil of a value is the smallest value in BST which is >= to the key

// class Solution
// {
//     public int Solve(TNode root, int val)
//     {
//         if (root == null)
//         {
//             return -1;
//         }

//         int ceil = -1;

//         TNode curr = root;

//         while (curr != null)
//         {
//             if (curr.data == val)
//             {
//                 return curr.data;
//             }

//             // usual binary search
//             if (curr.data > val)
//             {
//                 ceil = curr.data;
//                 curr = curr.left;
//             }
//             else
//             {
//                 curr = curr.right;
//             }
//         }

//         return ceil;
//     }
// }
// class Graph
// {

//     public static void Main()
//     {
//         Solution s = new Solution();
//         TNode root = new TNode(10);
//         root.left = new TNode(5);
//         root.right = new TNode(13);
//         root.left.left = new TNode(3);
//         root.left.left.left = new TNode(2);
//         root.left.left.right = new TNode(4);
//         root.left.right = new TNode(6);
//         root.left.right.right = new TNode(9);
//         root.right.left = new TNode(11);
//         root.right.right = new TNode(14);

//         Console.WriteLine(s.Solve(root, 8));
//     }
// }