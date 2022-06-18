//public class Solution
//{
//    public static Node<string> Solve(Node<string> head)
//    {
//        if (head == null)
//        {
//            return null;
//        }

//        var prev = head;
//        head = head.Next;
//        prev.Next = null;

//        while (head != null)
//        {
//            var tmp = head.Next;
//            prev.Prev = head;
//            head.Next = prev;
//            prev = head;
//            head = tmp;
//        }

//        return prev;
//    }
//}
