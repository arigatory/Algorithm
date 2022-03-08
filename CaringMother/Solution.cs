public class Solution
{
    public static int Solve(Node<string> head, string item)
    {
        for (var idx = 0; head != null; idx++)
        {
            if (head.Value == item)
            {
                return idx;
            }

            head = head.Next;
        }

        return -1;
    }
}
