using System.IO;



namespace K_BringOutTheRange
{

    public class Solution
    {
        public static void PrintRange(Node root, int left, int right, StreamWriter writer)
        {
            if (root == null)
            {
                return;
            }
            if (left <= root.Value)
            {
                PrintRange(root.Left, left, right, writer);
            }
            if (left <= root.Value && right >= root.Value)
            {
                writer.WriteLine(root.Value);
            }
            PrintRange(root.Right, left, right, writer);
        }
    }
}