

//class Helper
//{
//    //public int Height(TNode root)
//    //{
//    //    if (root == null)
//    //    {
//    //        return 0;
//    //    }

//    //    int leftHeight = Height(root.left);
//    //    int rightHeight = Height(root.right);

//    //    return 1 + Math.Max(leftHeight, rightHeight);
//    //}

//    // Time : O(N^2), space : O(N)
//    //public int Diameter(TNode root)
//    //{
//    //    if (root == null)
//    //    {
//    //        return 0;
//    //    }

//    //    int leftHeight = Height(root.left);
//    //    int rightHeight = Height(root.right);

//    //    int leftDiamater = Diameter(root.left);
//    //    int rightDiamater = Diameter(root.right);

//    //    return Math.Max(1+leftHeight + rightHeight, Math.Max(leftDiamater, rightDiamater));
//    //}



//    // Time: O(N) , space : O(N)
//    public int Diameter(TNode root, ref int max)
//    {
//        if (root == null)
//        {
//            return 0;
//        }

//        //The idea is that at every junction we will calcualte the Lh and Rh and store the maximum of Lh + Rh in var maxi
//        int leftHeight = Diameter(root.left, ref max);

//        int rightHeight = Diameter(root.right, ref max);

//        max = Math.Max(max, leftHeight + rightHeight);

//        return 1 + Math.Max(leftHeight, rightHeight);
//    }
//}

//class Program
//{
//    public static void Main()
//    {
//        Helper h = new Helper();

//        TNode root = new TNode(1);
//        root.left = new TNode(2);
//        root.left.left = new TNode(4);
//        root.left.right = new TNode(5);
//        root.right = new TNode(3);


//        int max = int.MinValue;

//        h.Diameter(root, ref max);

//        Console.WriteLine(max);
//    }
//}