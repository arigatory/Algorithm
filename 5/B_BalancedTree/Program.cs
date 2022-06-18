// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

Solution.Test();

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
    public static bool Solve(Node root)
    {
        if (root == null)
        {
            return true;
        }
         else if ( Math.Abs(Depth(root.Right) - Depth(root.Left)) <= 1 && Solve(root.Left) && Solve(root.Right) )
        {
            return true;
        }
        return false;
    }

    private static int Depth(Node root)
    {
        if (root == null)
        {
            return 0;
        }
        else
        {
            return 1 + Math.Max(Depth(root.Left), Depth(root.Right));
        }
    }

    public static void Test()
    {
        var node1 = new Node(1);
        var node2 = new Node(-5);
        var node3 = new Node(3)
        {
            Left = node1,
            Right = node2
        };
        var node4 = new Node(10);
        var node5 = new Node(2)
        {
            Left = node3,
            Right = node4
        };
        Console.WriteLine(Solve(node5));
    }
}
