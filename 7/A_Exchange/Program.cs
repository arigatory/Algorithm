using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace A_Exchange
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

            int sum = 0;
            bool have = false;
            for (int i = 0; i < n - 1; i++)
            {
                if (numbers[i + 1] > numbers[i])
                {
                    if (have)
                    {

                    }
                    else
                    {
                        sum -= numbers[i];
                        have = true;
                    }
                }
                else
                {
                    if (have)
                    {
                        sum += numbers[i];
                        have = false;
                    }
                    else
                    {

                    }
                }
            }
            if (have)
            {
                sum += numbers[n - 1];
            }
            _writer.Write("{0} ", sum);

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
