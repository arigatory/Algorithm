using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace A_ParenthesesGenerator
{
    public class Solution
    {
        private static TextReader _reader;
        private static TextWriter _writer;

        public static void Main(string[] args)
        {
            InitialiseStreams();

            var n = ReadInt();

            var result = GenerateParentheses(n);
            result.Sort();
            for (int i = 0; i < result.Count; i++)
            {
                _writer.WriteLine(result[i]);
            }

            CloseStreams();
        }

        private static List<string> GenerateParentheses(int n)
        {
            if (n == 0)
            {
                return new List<string> { "" };
            }
            var result = new List<string>();
            for (int i = 0; i < n; i++)
            {
                foreach (var left in GenerateParentheses(n - 1 - i))
                {
                    foreach (var right in GenerateParentheses(i))
                    {
                        result.Add($"({left}){right}");
                    }
                }
            }
            return result;
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
    }
}
