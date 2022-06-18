using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace H_FlowerField
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

            int[,] field = new int[n, m];

            for (var i = 0; i < n; i++)
            {
                var s = _reader.ReadLine();
                for (int j = 0; j < m; j++)
                {
                    field[n-1-i, j] = s[j] - '0';
                }
            }

            int[,] dp = new int[n + 1, m + 1];

            dp[1, 1] = field[0, 0];

            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= m; j++)
                {
                    dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]) + field[i - 1, j - 1];
                }
            }
            _writer.WriteLine(dp[n,m]);
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
