using System;

namespace E_SearchTree
{
    public class Solution
    {
        public static bool Solve(Node root)
        {
            if (root.Left == null && root.Right == null)
            {
                return true;
            }
            if (root.Left == null)
            {
                return root.Value < MaxNode(root.Right) && Solve(root.Right);
            }
            if (root.Right == null)
            {
                return root.Value > MaxNode(root.Left) && Solve(root.Left);
            }
            return root.Value > MaxNode(root.Left) && root.Value < MaxNode(root.Right) && Solve(root.Left) && Solve(root.Right);
        }

        static int MaxNode(Node root)
        {
            if (root.Left == null && root.Right == null)
            {
                return root.Value;
            }

            if (root.Left == null)
            {
                return MaxNode(root.Right);
            }

            if (root.Right == null)
            {
                return MaxNode(root.Left);
            }
            var a = MaxNode(root.Left);
            var b = MaxNode(root.Right);
            return a > b ? a : b;
        }

        public static void Test()
        {
            var node1 = new Node(1);
            var node2 = new Node(4);
            var node3 = new Node(3)
            {
                Left = node1,
                Right = node2
            };
            var node4 = new Node(8);
            var node5 = new Node(5)
            {
                Left = node3,
                Right = node4
            };
            Console.WriteLine(Solve(node5));
            node2.Value = 5;
            Console.WriteLine(Solve(node5));
        }
    }







}
