using System;
using System.Collections.Generic;
using System.IO;

public class Solution
{
    private static TextReader _reader;
    private static TextWriter _writer;

    public static void Main(string[] args)
    {
        InitialiseStreams();

        var line = _reader.ReadLine();

        Stack<char> brackets = new Stack<char>();

        bool result = true;
        int i = 0;
        while (i < line.Length)
        {
            if (line[i] == '(' || line[i] == '{' || line[i] == '[')
            {
                brackets.Push(line[i]);
            }
            else
            {
                if (brackets.Count == 0)
                {
                    result = false;
                    break;
                }
                var lastBracket = brackets.Pop();
                if (lastBracket == '\0')
                {
                    result = false;
                    break;
                }
                if (line[i] == ')' && lastBracket == '(' || line[i] == '}' && lastBracket == '{' || line[i] == ']' && lastBracket == '[')
                {
                   
                }
                else
                {
                    result = false;
                    break;
                }
            }
            i++;
        }

        if (i != line.Length)
        {
            result = false;
        }

        if (brackets.Count != 0)
        {
            result = false;
        }

        _writer.WriteLine(result);

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




public class StackMax<T>
{
    Stack<T> items = new Stack<T>();

    public T Pop()
    {
        if (items.Count == 0)
        {
            return default(T);
        }
        else
        {
            return items.Pop();
        }
    }

    public void Push(T num)
    {
        items.Push(num);
    }

    public int Count { get => items.Count; }

}
