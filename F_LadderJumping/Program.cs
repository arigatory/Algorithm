using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace F_LadderJumping
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
            var k = numbers[1];

            uint[] dp = new uint[n + 1];
            dp[1] = 1;
            dp[2] = 1;

            for (var i = 3; i <= k; i++)
            {
                dp[i] = (dp[i - 1] * 2) % 1_000_000_007;
            }

            for (int i = k + 1; i <= n; i++)
            {
                dp[i] = 0;
                for (int j = 1; j <= k; j++)
                {
                    dp[i] += dp[i - j];
                    dp[i] = dp[i] % 1_000_000_007;
                }
            }

            _writer.WriteLine(dp[n]);

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
