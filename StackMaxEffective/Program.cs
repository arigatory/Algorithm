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
            }
            else if (command == "pop")
            {
                if (stack.Pop() == null)
                    _writer.WriteLine("error");
            }
            else
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
    Stack<int> track = new Stack<int>();

    int max = int.MinValue;

    public string Pop()
    {
        if (items.Count == 0)
        {
            return null;
        }
        else
        {   
            track.Pop();
            if (track.Count == 0)
            {
                max = int.MinValue;
            }
            else
            {
                max = track.Peek();
            }
            return items.Pop().ToString();
        }
    }

    public void Push(int num)
    {
        items.Push(num);
        if (num > max)
        {
            max = num;
            track.Push(num);
        }
        else
        {
            track.Push(max);
        }
    }

    public string GetMax()
    {
        if (items.Count == 0)
        {
            return "None";
        }
        else
        {
            return track.Peek().ToString();
        }

    }
}
