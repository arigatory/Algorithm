using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace H_TimeToGoOut
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

            List<int>[] vertex = ReadGraphToAdjacencyList(n, m);

            var colors = new List<Color>(Enumerable.Repeat(Color.White, n + 1));
            int time = -1;
            var entry = new List<int>(Enumerable.Repeat(-1, n + 1));
            var leave = new List<int>(Enumerable.Repeat(-1, n + 1));

            DFS(vertex, 1, colors, entry, leave, ref time);

            for (int i = 1; i <= n; i++)
            {
                _writer.WriteLine($"{entry[i]} {leave[i]}");
            }

            CloseStreams();
        }

        private static void DFS(List<int>[] vertex, int i, List<Color> colors, List<int> entry, List<int> leave, ref int time)
        {
            time++;
            entry[i] = time;
            colors[i] = Color.Gray;

            foreach (var v in vertex[i].OrderBy(x => x))
            {
                if (colors[v] == Color.White)
                {
                    DFS(vertex, v, colors, entry, leave, ref time);
                }
            }
            time++;
            leave[i] = time;
            colors[i] = Color.Black;
        }

        /// <summary>
        /// Read graph storing it in adjacency list with indexes from 1 to n, where vertex[0] is fake
        /// </summary>
        /// <param name="n">Number of vertex</param>
        /// <param name="m">Number of edges</param>
        /// <returns></returns>
        private static List<int>[] ReadGraphToAdjacencyList(int n, int m)
        {
            List<int>[] vertex = new List<int>[n + 1];
            for (int i = 1; i <= n; i++)
                vertex[i] = new List<int>();

            for (var i = 0; i < m; i++)
            {
                var items = ReadList();
                vertex[items[0]].Add(items[1]);
            }

            return vertex;
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

        enum Color
        {
            White,
            Gray,
            Black
        };
    }
}