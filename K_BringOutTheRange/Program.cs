using System;

namespace K_BringOutTheRange
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //var tree = new Node<int>(1);
            //tree.Left = new Node<int>(3);
            //tree.Left.Left = new Node<int>(8);
            //tree.Left.Left.Left = new Node<int>(14);
            //tree.Left.Left.Right = new Node<int>(15);
            //tree.Left.Right = new Node<int>(10);
            //tree.Left.Right.Right = new Node<int>(3);
            //tree.Right = new Node<int>(5);
            //tree.Right.Left = new Node<int>(2);
            //tree.Right.Right = new Node<int>(6);
            //tree.Right.Right.Left = new Node<int>(0);
            //tree.Right.Right.Right = new Node<int>(1);


            var tree = new Node<string>("F");
            var b = new Node<string>("B");
            var a = new Node<string>("A");
            var d = new Node<string>("D");
            var c = new Node<string>("C");
            var e = new Node<string>("E");
            var g = new Node<string>("G");
            var i = new Node<string>("I");
            var h = new Node<string>("H");
            tree.Left = b;
            tree.Right = g;
            b.Left = a;
            b.Right = d;
            d.Left = c;
            d.Right = e;

            g.Right = i;
            i.Left = h;


            var intTree = new Node<int>(1600);

            var v1400 = new Node<int>(1400);
            var v900 = new Node<int>(900);
            var v1600 = new Node<int>(1600);
            var v1550 = new Node<int>(1550);
            var v2000 = new Node<int>(2000);
            var v1800 = new Node<int>(1800);
            var v2200 = new Node<int>(2200);

            intTree.Left = v1400;
            intTree.Right = v2000;
            v1400.Left = v900;
            v1400.Right = v1600;
            v1600.Left = v1550;

            v2000.Left = v1800;
            v2000.Right = v2200;

            PrintTreeLMR<int>(intTree);
            Console.WriteLine();
            PrintRange(intTree, 1500, 1900);
        }

        static void PrintTreeReverse<T>(Node<T> t)
        {
            if (t.Left != null)
            {
                PrintTreeReverse(t.Left);
            }
            if (t.Right != null)
            {
                PrintTreeReverse(t.Right);
            }
            Console.Write(t.Value);
        }

        static void PrintTreeLMR<T>(Node<T> t)
        {
            if (t.Left != null)
            {
                PrintTreeLMR(t.Left);
            }
            Console.Write($"{t.Value} ");
            if (t.Right != null)
            {
                PrintTreeLMR(t.Right);
            }
        }


        static void PrintTreeRML<T>(Node<T> t)
        {
            if (t.Right != null)
            {
                PrintTreeRML(t.Right);
            }
            Console.Write(t.Value);
            if (t.Left != null)
            {
                PrintTreeRML(t.Left);
            }
        }


        static void PrintRange(Node<int> root,int left, int right)
        {
            if (root == null)
            {
                return;
            }
            if (left < root.Value)
            {
                PrintRange(root.Left, left, right);
            }
            if (left <= root.Value && right >= root.Value)
            {
                Console.Write($"{root.Value} ");
            }
            PrintRange(root.Right, left, right);
        }

    }




    // закомментируйте перед отправкой
    public class Node<T>
    {
        public T Value { get; set; }
        public Node<T> Left { get; set; }
        public Node<T> Right { get; set; }

        public Node(T value)
        {
            Value = value;
            Left = null;
            Right = null;
        }
    }

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
}
