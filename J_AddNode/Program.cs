﻿using System;

namespace J_AddNode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }


    // закомментируйте перед отправкой
    public class Node
    {
        public int Value { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }

        public Node(int value)
        {
            Value = value;
            Left = null;
            Right = null;
        }
    }

    public class Solution
    {
        public static Node Insert(Node root, int key)
        {
            if (key < root.Value)
            {
                if (root.Left == null)
                {
                    root.Left = new Node(key);
                }
                else
                {
                    Insert(root.Left, key);
                }
            }
            if (key >= root.Value)
            {
                if (root.Right == null)
                {
                    root.Right = new Node(key);
                }
                else
                {
                    root.Right = new Node(key);
                }
            }
            return root;
        }

        private static void Test()
        {
            var node1 = new Node(7);
            var node2 = new Node(8)
            {
                Left = node1
            };

            var node3 = new Node(7)
            {
                Right = node2
            };
            var newHead = Insert(node3, 6);
            Console.WriteLine(newHead == node3);
            Console.WriteLine(newHead.Left.Value == 6);
        }
    }


}
