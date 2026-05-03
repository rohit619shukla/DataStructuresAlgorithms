 // // Note : Floor is greater value in BST which is smaller than the key. val <= key

// class Solution
// {
//     public int Solve(TNode root, int val)
//     {
//         if (root == null)
//         {
//             return -1;
//         }

//         int floor = -1;

//         TNode head = root;

//         while (head != null)
//         {
//             if (head.data == val)
//             {
//                 return val;
//             }

//             if (head.data > val)
//             {
//                 head = head.left;
//             }
//             else
//             {
//                 floor = head.data;
//                 head = head.right;
//             }
//         }

//         return floor;
//     }
// }
// class Program
// {
//     public static void Main()
//     {
//         Solution s = new Solution();

//         TNode root = new TNode(8);
//         root.left = new TNode(5);
//         root.right = new TNode(12);
//         root.left.left = new TNode(4);
//         root.left.right = new TNode(7);
//         root.left.right.left = new TNode(6);
//         root.right.left = new TNode(10);
//         root.right.right = new TNode(14);
//         root.right.right.left = new TNode(13);


//         Console.WriteLine(s.Solve(root, 9));
//     }
// }

// // Time : O(Log2n) average case and O(n) for unbalanced , space : O(1)