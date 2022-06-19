using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace B_BorderControl
{
    public class Solution
    {
        private static TextReader _reader;
        private static TextWriter _writer;

        public static void Main(string[] args)
        {
            InitialiseStreams();

            var s1 = _reader.ReadLine();
            var s2 = _reader.ReadLine();

            if (GetLevenshteinDistance(s1, s2) > 1)
            {
                _writer.WriteLine("FAIL");
            }
            else
            {
                _writer.WriteLine("OK");
            }

            CloseStreams();

        }

        public static int GetLevenshteinDistance(string s1, string s2)
        {
            int n = s1.Length;
            int m = s2.Length;

            if (n > m)
            {
                var temp = s1;
                s1 = s2;
                s2 = temp;
                var x = n;
                n = m;
                m = x;
            }

            int[,] dp = new int[2, m + 1];

            for (int i = 0; i <= n; i++)
            {
                for (int j = 0; j <= m; j++)
                {
                    if (i == 0 && j == 0)
                    {
                        dp[i, j] = 0;
                    }
                    else if (j == 0)
                    {
                        dp[i & 1, j] = i;
                    }
                    else if (i == 0)
                    {
                        dp[i & 1, j] = j;
                    }
                    else
                    {
                        int temp = Math.Min(dp[i & 1, j - 1], dp[(i - 1) & 1, j]);
                        dp[i & 1, j] = Math.Min(temp + 1, dp[(i - 1) & 1, j - 1] + (s1[i - 1] == s2[j - 1] ? 0 : 1));
                    }
                }
            }

            return dp[n & 1, m];
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
    }
}
