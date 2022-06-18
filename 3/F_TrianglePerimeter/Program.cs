using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace F_TrianglePerimeter
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


            int result = Solve(n, numbers);

            _writer.WriteLine(result);

            CloseStreams();
        }

        private static int Solve(int n, List<int> numbers)
        {
            numbers.Sort((a, b) => b - a);

            for (var i = 0; i < n - 2; i++)
            {
                if (numbers[i + 1] + numbers[i + 2] > numbers[i])
                {
                    return numbers[i] + numbers[i + 1] + numbers[i + 2];
                }
            }

            return 0;
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
