using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace G_ShiftSearch
{
    public class Solution
    {
        private static TextReader _reader;
        private static TextWriter _writer;

        public static void Main(string[] args)
        {
            InitialiseStreams();

            var n = ReadInt();
            var numbers = ReadList();
            var m = ReadInt();
            var pattern = ReadList();


            for (var i = n - 1; i > 0; i--)
            {
                numbers[i] -= numbers[i - 1];
            }

            var goodPattern = new List<int>(pattern.Count - 1);
            for (int i = 1; i < m; i++)
            {
                goodPattern.Add(pattern[i] - pattern[i - 1]);
            }

            for (int i = 1; i <= n - goodPattern.Count; i++)
            {
                bool match = true;
                int j = 0;
                while (j < goodPattern.Count)
                {
                    if (goodPattern[j] != numbers[i+j])
                    {
                        match = false;
                        break;
                    }
                    j++;
                }
                if (match)
                {
                    _writer.Write(i + " ");
                }
            }

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
