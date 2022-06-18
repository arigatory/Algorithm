public class Solution<TValue>
{
    public static Node<TValue> Solve(Node<TValue> head, int idx)
    {
        if (idx == 0)
        {
            return head.Next;
        }

        var prev = head;
        var answer = head;

        do
        {
            prev = head;
            head = head.Next;
            idx--;
        } while (head != null && idx > 0);

        if (head != null)
        {
            prev.Next = head.Next;
        }

        return answer;
    }
}
