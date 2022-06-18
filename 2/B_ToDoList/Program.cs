using System;
using System.IO;

//public class Node<TValue>
//{
//    public TValue Value { get; private set; }
//    public Node<TValue> Next { get; set; }

//    public Node(TValue value, Node<TValue> next)
//    {
//        Value = value;
//        Next = next;
//    }
//}

public class Solution
{
    private static TextReader _reader;
    private static TextWriter _writer;

    public static void Main(string[] args)
    {
        InitialiseStreams();

        //var n = ReadInt();
        //var numbers = ReadList();

        //for (var i = 0; i < n; i++)
        //{
        //    _writer.Write("{0} ", numbers[i]);
        //}

        Test();

        CloseStreams();
    }


    private static void Test()
    {
        var node3 = new Node<string>("node3", null);
        var node2 = new Node<string>("node2", node3);
        var node1 = new Node<string>("node1", node2);
        var node0 = new Node<string>("node0", node1);
        //Solve(node0);
        /*
        Output is:
        node0
        node1
        node2
        node3
        */
    }


    public static void Solve(Node<string> head)
    {
        var start = head;
        while (head != null)
        {
            Console.WriteLine(head.Value);
            head = head.Next;
        }
    }


    private static void CloseStreams()
    {
        _reader.Close();
        _writer.Close();
    }

    private static void InitialiseStreams()
    {
        _reader = new StreamReader(Console.OpenStandardInput());
        _writer = new StreamWriter(Console.OpenStandardOutput());
    }
}

