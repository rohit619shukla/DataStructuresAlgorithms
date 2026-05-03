
//class Solution
//{
//    private Stack<TNode> st;
//    private bool _flag;
//    public Solution(TNode root, bool flag)
//    {
//        st = new Stack<TNode>();
//        _flag = flag;
//        PushData(root);
//    }

//    private void PushData(TNode root)
//    {
//        while (root != null)
//        {
//            st.Push(root);

//            if (_flag)
//            {
//                root = root.left;
//            }
//            else
//            {
//                root = root.right;
//            }
//        }

//    }

//    public TNode Next()
//    {
//        TNode temp = st.Pop();

//        if (_flag)
//        {
//            PushData(temp.right);
//        }
//        else
//        {
//            PushData(temp.left);
//        }
//        return temp;
//    }


//}

//class Sample
//{
//    public bool FindTarget(TNode root, int k)
//    {
//        // Now we create 2 objects, quiet similar to 2 pointers
//        Solution s1 = new Solution(root, true);
//        Solution s2 = new Solution(root, false);

//        int leftPointerData = s1.Next().data;
//        int rightPointerData = s2.Next().data;

//        // We will iterate till both of these crosses each other
//        while (leftPointerData < rightPointerData)
//        {
//            int sum = leftPointerData + rightPointerData;

//            if (sum == k)
//            {
//                return true;
//            }

//            if (sum < k)
//            {
//                leftPointerData = s1.Next().data;
//            }
//            else
//            {
//                rightPointerData = s2.Next().data;
//            }
//        }

//        return false;
//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        TNode root = new TNode(5);
//        root.left = new TNode(3);
//        root.right = new TNode(6);
//        root.left.left = new TNode(2);
//        root.left.right = new TNode(4);
//        root.right.right = new TNode(7);

//        Sample s = new Sample();
//        Console.WriteLine(s.FindTarget(root, 8));

//    }
//}


//// Time :
//// 1. Constructor : O(H) for balanced tree and O(N) for skewed
//// 2. HasNext : O(1)
//// 3. Next : O(1) amortized. As there will ne N push and N Pop operations for nodes in tree which will result in O(1) 


//// Space : O(n) for worst case and O(H) for best