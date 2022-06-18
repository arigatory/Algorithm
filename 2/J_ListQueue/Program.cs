using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace J_ListQueue
{
    public class Solution
    {
        private static TextReader _reader;
        private static TextWriter _writer;

        public static void Main(string[] args)
        {
            InitialiseStreams();

            var totalCommands = ReadInt();

            MyQueue myQueue = new MyQueue();
            for (int i = 0; i < totalCommands; i++)
            {
                var command = ReadList();
                if (command[0] == "put")
                {
                    myQueue.Put(command[1]);
                }
                else if (command[0] == "get")
                {
                    _writer.WriteLine(myQueue.Get());
                }
                else if (command[0] == "size")
                {
                    _writer.WriteLine(myQueue.Size);
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
                .Split(new[] { ' ', '\t', }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();
        }
    }


    public class MyQueue
    {
        private int _size = 0;
        private Node<string> _start = null;
        private Node<string> _end = null;

        public int Size { get { return _size; } }

        public string Get()
        {
            if (_size == 0)
            {
                return "error";
            }
            else if (_size == 1)
            {
                var result = _start.Value;
                _start = null;
                _end = null;
                _size = 0;
                return result;
            } 
            else
            {
                var result = _start.Value;
                _size--;
                _start = _start.Next;
                return result;
            }
        }

        public void Put(string s)
        {
            if (_size == 0)
            {
                _size = 1;
                _start = new Node<string>(s, null, null);
                _end = _start;
            }
            else
            {
                _size++;
                _end.Next = new Node<string>(s, null, _end);
                _end = _end.Next;
            }
        }



        private class Node<TValue>
        {
            public TValue Value { get; private set; }
            public Node<TValue> Next { get; set; }
            public Node<TValue> Previous { get; set; }

            public Node(TValue value, Node<TValue> next, Node<TValue> previous)
            {
                Value = value;
                Next = next;
                Previous = previous;
            }
        }

    }
}
