using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace P_PartialSorting
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

            int max = 0;
            int first = 0;
            int count = 0;
            int i = 0;
            List<int> items = new List<int>();

            while (i < n)
            {
                items.Add(numbers[i]);
                if (numbers[i] > max)
                {
                    max = numbers[i];
                }
                if (numbers[i] == first)
                {
                    first = max + 1;
                    while (numbers[i] < max || items.Count < max + 1)
                    {
                        i++;
                        if (i == n)
                        {
                            break;
                        }
                        items.Add(numbers[i]);
                        if (numbers[i] > max)
                        {
                            max = numbers[i];
                        }
                    }
                    count++;
                }
                else
                {
                    i++;
                }

            }

            _writer.WriteLine("{0} ", count);

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
