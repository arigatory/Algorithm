public class Solution
{
    public static int Solve(Node root)
    {
        if (root.Left == null && root.Right == null)
        {
            var l = root.Value;
            var r = root.Value;
            if (l > r)
                return l;
            return r;
        }
        else if (root.Right == null)
        {
            var left = Solve(root.Left);
            if (left > root.Value)
            {
                return left;
            }
            return root.Value;
        }
        else if (root.Left == null)
        {
            var right = Solve(root.Right);
            if (right > root.Value)
            {
                return right;
            }
            return root.Value;
        }
        var a = Solve(root.Left);
        var b = Solve(root.Right);
        if (a > b)
            return a;
        return b;
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
