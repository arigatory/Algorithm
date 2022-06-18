using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class Solution
{
    private static TextReader _reader;
    private static TextWriter _writer;

    public static void Main(string[] args)
    {
        InitialiseStreams();

        var n = ReadInt();
        
        var stack = new StackMax();

        for (int i = 0; i < n; i++)
        {
            var command = _reader.ReadLine();
            if (command == "get_max")
            {
                _writer.WriteLine(stack.GetMax());
            } else if (command == "pop")
            {
                if (stack.Pop() == null)
                    _writer.WriteLine("error");
            } else
            {
                var commandOp = command.Split(' ');
                stack.Push(int.Parse(commandOp[1]));
            }
        }

        CloseStreams();
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

    private static int ReadInt()
    {
        return int.Parse(_reader.ReadLine());
    }
}




    public class StackMax
{
    Stack<int> items = new Stack<int>();

    public string Pop()
    {
        if (items.Count == 0)
        {
            return null;
        }
        else
        {
            return items.Pop().ToString();
        }
    }

    public void Push(int num)
    {
        items.Push(num);
    }

    public string GetMax()
    {
        if (items.Count == 0)
        {
            return "None";
        }
        else
        {
            return items.Max().ToString();
        }

    }
}
