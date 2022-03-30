using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace G_Competition
{
    public class Solution
    {
        private static TextReader _reader;
        private static TextWriter _writer;

        public static void Main(string[] args)
        {
            InitialiseStreams();
            var n = ReadInt();

            int maxLength = 0;

            if (n != 0)
            {
                var numbers = ReadList();

                var indexSumDict = new Dictionary<int, int>();

                int counter = 0;

                for (int i = 1; i <= n; i++)
                {
                    counter += numbers[i - 1] == 0 ? -1 : 1;
                    if (counter == 0)
                    {
                        maxLength = i;
                    }
                    else if (indexSumDict.ContainsKey(counter))
                    {
                        int probableMax = i - indexSumDict[counter];
                        if (probableMax > maxLength)
                        {
                            maxLength = probableMax;
                        }
                    }
                    else
                    {
                        indexSumDict.Add(counter, i);
                    }
                }
            }

            _writer.WriteLine(maxLength);
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
