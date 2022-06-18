using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace B_ConvertListOfEdgesToAdjacencyMatrix
{
    public class Solution
    {
        private static TextReader _reader;
        private static TextWriter _writer;

        public static void Main(string[] args)
        {
            InitialiseStreams();

            var numbers = ReadList();
            var n = numbers[0];
            var m = numbers[1];

            var result = new List<List<int>>();
            for (int i = 0; i < n; i++)
                result.Add(new List<int>(new int[n]));

            for (var i = 0; i < m; i++)
            {
                var items = ReadList();
                result[items[0] - 1][items[1] - 1] = 1;
            }

            for (int i = 0; i < n; i++)
            {
                _writer.WriteLine(String.Join(" ", result[i]));
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

        private static List<int> ReadList()
        {
            return _reader.ReadLine()
                .Split(new[] { ' ', '\t', }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
        }
    }
}