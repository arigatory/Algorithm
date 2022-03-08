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

        var total_commands = ReadInt();
        var max_size = ReadInt();

        MyQueueSized myQueueSized = new MyQueueSized(max_size);
        for (int i = 0; i < total_commands; i++)
        {
            var command = ReadList();
            if (command[0] == "peek")
            {
                _writer.WriteLine(myQueueSized.Peek());
            } else if (command[0] == "push")
            {
                if (!myQueueSized.Push(command[1]))
                {
                    _writer.WriteLine("error");
                } 
            } else if (command[0] == "pop")
            {
                _writer.WriteLine(myQueueSized.Pop());
            } else if (command[0] == "size")
            {
                _writer.WriteLine(myQueueSized.Size());
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

    private static List<string> ReadList()
    {
        return _reader.ReadLine()
            .Split(new[] { ' ', '\t', }, StringSplitOptions.RemoveEmptyEntries).ToList();
    }
}

public class MyQueueSized
{
    private int _size;
    private int _maxSize;
    private string[] _items;
    private int _head;
    private int _tail;

    private bool _empty
    {
        get
        {
            return _size == 0;
        }
    }

    public MyQueueSized(int maxSize)
    {
        _maxSize = maxSize;
        _items = new string[maxSize];
        _head = 0;
        _tail = 0;
        _size = 0;  
    }

    public string Peek()
    {
        if (_empty)
        {
            return "None";
        }
        return _items[_head];
    }

    public bool Push(string item)
    {
        if (_size != _maxSize)
        {
            _items[_tail] = item;
            _tail = (_tail + 1) % _maxSize;
            _size++;
            return true;
        }
        else
        {
            return false;
        }
    }

    public string Pop()
    {
        if (_empty)
        {
            return "None";
        }
        var result = _items[_head];
        _items[_head] = null;
        _head = (_head + 1) % _maxSize;
        _size--;
        return result;
    }

    public int Size()
    {
        return _size;
    }
}