using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace D_Mugs
{
    public class Solution
    {
        private static TextReader _reader;
        private static TextWriter _writer;

        public static void Main(string[] args)
        {
            InitialiseStreams();
            Console.WriteLine("привет");
            _writer.WriteLine("привет");
            _writer.Flush();
            var n = ReadInt();

            SortedSet<string> set = new SortedSet<string>();

            for (int i = 0; i < n; i++)
            {
                var s = _reader.ReadLine();
                if (!set.Contains(s))
                {
                    _writer.WriteLine(s);
                    set.Add(s);
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

        private static List<int> ReadList()
        {
            return _reader.ReadLine()
                .Split(new[] { ' ', '\t', }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
        }
    }

}