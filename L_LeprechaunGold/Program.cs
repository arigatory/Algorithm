using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace L_LeprechaunGold
{
    public class Solution
    {
        private static TextReader _reader;
        private static TextWriter _writer;

        public static void Main(string[] args)
        {
            InitialiseStreams();

            var items = ReadList();
            int n = items[0];
            int M = items[1];

            var numbers = ReadList();

            int[,] dp = new int[n + 1, M + 1];



            for (var i = 1; i <= n; i++)
            {
                for (int j = 1; j <= M; j++)
                {
                    int v1 = dp[i - 1, j];
                    int v2 = 0;

                    int jj = j - numbers[i - 1];
                    if (jj >= 0)
                    {
                        v2 = dp[i - 1, jj] + numbers[i - 1];
                    }

                    dp[i, j] = Math.Max(v1, v2);
                }
            }
            _writer.WriteLine(dp[n, M]);
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
