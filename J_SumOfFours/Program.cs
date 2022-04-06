using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace J_SumOfFours
{

    public class Solution
    {
        private static TextReader _reader;
        private static TextWriter _writer;

        public static void Main(string[] args)
        {
            InitialiseStreams();

            var n = ReadInt();
            var s = ReadInt();
            var numbers = ReadList();
            numbers.Sort();

            var fours = new SortedSet<(int, int, int, int)>();
            var history = new HashSet<int>();

            for (var i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    for (int k = j + 1; k < n; k++)
                    {
                        var target = s - numbers[i] - numbers[j] - numbers[k];
                        if (history.Contains(target))
                        {
                            fours.Add((target, numbers[i], numbers[j], numbers[k]));
                        }
                    }
                    
                }
                history.Add(numbers[i]);
            }

            _writer.WriteLine(fours.Count);
            foreach (var item in fours)
            {
                _writer.WriteLine($"{item.Item1} {item.Item2} {item.Item3} {item.Item4}");
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
