using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace G_Wardrobe
{

    public class Solution
    {
        private static TextReader _reader;
        private static TextWriter _writer;

        public static void Main(string[] args)
        {
            InitialiseStreams();

            var n = ReadInt();
            var numbers = ReadList();

            Dictionary<int, int> keyValuePairs = new Dictionary<int, int>
            {
                {0, 0},
                {1, 0},
                {2, 0},
            };

            for (var i = 0; i < n; i++)
            {
                keyValuePairs[numbers[i]]++;
            }

            foreach (var item in keyValuePairs)
            {
                _writer.Write(String.Concat(Enumerable.Repeat($"{item.Key} ", item.Value)));
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
