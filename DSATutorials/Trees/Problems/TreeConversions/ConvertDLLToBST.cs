

//using DS_Tutorials.Linked_list.Types;

//class Solution
//{
//    public Node InsertNode(Node head, int val, ref int count)
//    {
//        // If the list is empty add the node to the empty list
//        if (head == null)
//        {
//            count++;
//            return new Node(val);
//        }
//        else
//        {
//            // Add the newly created node to the end of the list

//            // Traverse the list til end to find suitable position
//            Node temp = head;

//            while (temp.next != null)
//            {
//                temp = temp.next;
//            }

//            // Create new Node
//            Node newNode = new Node(val);
//            newNode.prev = temp;
//            temp.next = newNode;

//            count++;
//            return head;
//        }
//    }

//    public Node Solve(ref Node head, int lb, int ub)
//    {
//        // Base case
//        if (lb > ub)
//        {
//            return null;
//        }

//        // Calculate the mid index
//        int mid = (lb + ub) / 2;

//        // Recursively create the left subtree
//        Node left = Solve(ref head, lb, mid - 1);

//        // Create the root node from the current head
//        Node root = head;

//        // Assign the left child to the root
//        root.prev = left;

//        // Move the head to the next node in the list
//        head = head.next;

//        // Recursively create the right subtree
//        Node right = Solve(ref head, mid + 1, ub);

//        // Assign the right child to the root
//        root.next = right;

//        // Return the created root node
//        return root;
//    }

//    public void PreOder(Node root)
//    {
//        if (root == null)
//        {
//            return;
//        }

//        Console.Write($"{root.data}" + " ");
//        PreOder(root.prev);
//        PreOder(root.next);
//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        Solution s = new Solution();

//        int count = 0;

//        Node head = null;
//        head = s.InsertNode(head, 1, ref count);
//        head = s.InsertNode(head, 2, ref count);
//        head = s.InsertNode(head, 3, ref count);
//        head = s.InsertNode(head, 4, ref count);
//        head = s.InsertNode(head, 5, ref count);
//        head = s.InsertNode(head, 6, ref count);
//        head = s.InsertNode(head, 7, ref count);

//        Node finalHead = s.Solve(ref head, 0, count - 1);

//        s.PreOder(finalHead);
//    }
//}