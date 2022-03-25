using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace I_ConferenceLovers
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
            var k = ReadInt();


            Dictionary<int, int> uniTotalPairs = new Dictionary<int, int>();

            for (var i = 0; i < n; i++)
            {
                if (uniTotalPairs.ContainsKey(numbers[i]))
                {
                    uniTotalPairs[numbers[i]]++;
                }
                else
                {
                    uniTotalPairs.Add(numbers[i], 1);
                }
            }

            var sorted = uniTotalPairs.OrderByDescending(k => k.Value).Select(x => x.Key);

            _writer.WriteLine(string.Join(" ", sorted.Take(k)));

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
