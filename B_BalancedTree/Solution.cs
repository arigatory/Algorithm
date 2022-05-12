using System;

//public class Solution
//{
//    public static bool Solve(Node root)
//    {
//        if (root == null)
//        {
//            return true;
//        }
//        else if (Math.Abs(Depth(root.Right) - Depth(root.Left)) <= 1 && Solve(root.Left) && Solve(root.Right))
//        {
//            return true;
//        }
//        return false;
//    }

//    private static int Depth(Node root)
//    {
//        if (root == null)
//        {
//            return 0;
//        }
//        else
//        {
//            return 1 + Math.Max(Depth(root.Left), Depth(root.Right));
//        }
//    }
//}
