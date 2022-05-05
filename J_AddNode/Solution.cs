
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

}
