using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace G_MaximumDistance
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

            var s = ReadInt();

            var colors = new List<Color>(Enumerable.Repeat(Color.White, n + 1));
            var previous = Enumerable.Repeat(-1, n + 1).ToArray();
            var distance = Enumerable.Repeat(-1, n + 1).ToArray();

            BFS(vertex, s, colors, distance, previous);


            CloseStreams();
        }

        private static void BFS(List<int>[] vertex, int s, List<Color> colors, int[] distance, int[] previous)
        {
            var planned = new Queue<int>();
            planned.Enqueue(s);
            colors[s] = Color.Gray;
            distance[s] = 0;
            int u=0;
            while (planned.Count > 0)
            {
                u = planned.Dequeue();
                foreach (var v in vertex[u].OrderBy(x => x))
                {
                    if (colors[v] == Color.White)
                    {
                        distance[v] = distance[u] + 1;
                        previous[v] = u;
                        colors[v] = Color.Gray;
                        planned.Enqueue(v);
                    }
                }
                colors[u] = Color.Black;

            }
            _writer.WriteLine(distance[u]);
            colors[s] = Color.Black;

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

        private static List<int>[] ReadGraphToAdjacencyList(int n, int m)
        {
            List<int>[] vertex = new List<int>[n + 1];
            for (int i = 1; i <= n; i++)
                vertex[i] = new List<int>();

            for (var i = 0; i < m; i++)
            {
                var items = ReadList();
                vertex[items[0]].Add(items[1]);
                vertex[items[1]].Add(items[0]);
            }

            return vertex;
        }
    }
}



