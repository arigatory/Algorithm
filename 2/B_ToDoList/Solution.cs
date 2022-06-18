using System;


public class Solution<TValue>
{
    public static void Solve(Node<TValue> head)
    {
        var start = head;
        while (start != null)
        {
            Console.WriteLine(start.Value);
            start = start.Next;
        }
    }
}