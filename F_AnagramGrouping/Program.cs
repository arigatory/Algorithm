using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace F_AnagramGrouping
{
    public class Solution
    {
        private static TextReader _reader;
        private static TextWriter _writer;

        public static void Main(string[] args)
        {
            InitialiseStreams();

            var n = ReadInt();
            var strings = ReadList();

            Dictionary<string, List<int>> strIndexDict = new();

            for (int i = 0; i < n; i++)
            {
                var key = String.Concat(strings[i].OrderBy(c => c));
                if (strIndexDict.ContainsKey(key))
                {
                    strIndexDict[key].Add(i);
                }
                else
                {
                    strIndexDict.Add(key, new List<int> { i });
                }
            }

            foreach (var lst in strIndexDict.Values)
            {
                _writer.WriteLine(string.Join(" ", lst));
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

        private static List<string> ReadList()
        {
            return _reader.ReadLine()
                .Split(new[] { ' ', '\t', }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();
        }
    }
}
