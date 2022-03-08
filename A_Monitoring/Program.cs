using System;

namespace A_Monitoring
{
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
            var n = ReadInt();
            var m = ReadInt();
            var matrix = new List<List<int>>();

            for (int i = 0; i < n; i++)
            {
                matrix.Add(ReadList());
            }

            var matrixTranspose = new List<List<int>>();

            for (int j = 0; j < m; j++)
            {
                var line = new List<int>();
                for (int i = 0; i < n; i++)
                {
                    line.Add(matrix[i][j]);
                }
                matrixTranspose.Add(line);
            }

            PrintMatrix(m, n, matrixTranspose);
            CloseStreams();
        }

        private static void PrintMatrix(int n, int m, List<List<int>> matrix)
        {
            for (int i = 0; i < n; i++)
            {
                _writer.Write(string.Join(" ", matrix[i]));
                _writer.WriteLine();
            }
            _writer.WriteLine();
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
