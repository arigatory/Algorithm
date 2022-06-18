using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace C_DFS
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

            List<int>[] vertex = new List<int>[n];
            for (int i = 0; i < n; i++)
                vertex[i] = new List<int>();

            for (var i = 0; i < m; i++)
            {
                var items = ReadList();
                vertex[items[0] - 1].Add(items[1] - 1);
                vertex[items[1] - 1].Add(items[0] - 1);
            }

            var s = ReadInt();
            var colors = new List<Color>(Enumerable.Repeat(Color.White, n));


            DFS(vertex, s - 1, colors);


            CloseStreams();
        }

        private static void DFS(List<int>[] vertex, int i, List<Color> colors)
        {
            _writer.Write(i + 1 + " ");
            colors[i] = Color.Gray;

            foreach (var v in vertex[i].OrderBy(x => x))
            {
                if (colors[v] == Color.White)
                {
                    DFS(vertex, v, colors);
                }
            }
            colors[i] = Color.Black;
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

        private static int ReadInt()
        {
            return int.Parse(_reader.ReadLine());
        }

        enum Color
        {
            White,
            Gray,
            Black
        };
    }
}
