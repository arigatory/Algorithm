using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace K_Attractions
{
    class Info
    {
        public Info(int n)
        {
            Visited = Enumerable.Repeat(false, n + 1).ToArray();
            Distance = Enumerable.Repeat(-1, n + 1).ToArray();
            Previous = Enumerable.Repeat(0, n + 1).ToArray();
        }

        public bool[] Visited { get; set; }
        public int[] Distance { get; set; }
        public int[] Previous { get; set; }
    }

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

            var verteces = ReadGraphToAdjacencyList(n, m);

            Info[] infos = new Info[n + 1];
            for (int i = 1; i <= n; i++)
            {
                infos[i] = new Info(n);
                var info = infos[i];
                info.Distance[i] = 0;
                int v = GetMinDistNotVisitedVertex(info);
                while (v != 0)
                {
                    info.Visited[v] = true;
                    List<(int, int)> neighbours = verteces[v];
                    foreach (var neighbour in neighbours)
                    {
                        Relax(v, neighbour, info);
                    }
                    v = GetMinDistNotVisitedVertex(info);
                }
            }




            // print result
            for (int i = 1; i <= n; i++)
            {
                _writer.WriteLine(string.Join(" ", infos[i].Distance.Skip(1)));
            }

            CloseStreams();
        }

        private static void Relax(int v, (int, int) neighbour, Info info)
        {
            if (info.Distance[neighbour.Item1] == -1 || info.Distance[neighbour.Item1] > info.Distance[v] + neighbour.Item2)
            {
                info.Distance[neighbour.Item1] = info.Distance[v] + neighbour.Item2;
                info.Previous[neighbour.Item1] = v;
            }
        }

        private static int GetMinDistNotVisitedVertex(Info info)
        {
            int n = info.Distance.Length - 1;
            int currentMin = int.MaxValue;
            int currentMinVertex = 0;

            for (int i = 1; i <= n; i++)
            {
                if (!info.Visited[i] && info.Distance[i] < currentMin && info.Distance[i] != -1)
                {
                    currentMin = info.Distance[i];
                    currentMinVertex = i;
                }
            }
            return currentMinVertex;
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

        private static List<(int,int)>[] ReadGraphToAdjacencyList(int n, int m)
        {
            List<(int, int)>[] vertex = new List<(int,int)>[n + 1];
            for (int i = 1; i <= n; i++)
                vertex[i] = new List<(int, int)>();

            for (var i = 0; i < m; i++)
            {
                var items = ReadList();
                vertex[items[0]].Add((items[1], items[2]));
                vertex[items[1]].Add((items[0], items[2]));
            }

            return vertex;
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
