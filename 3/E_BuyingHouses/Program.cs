using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace E_BuyingHouses
{
    public class Solution
    {
        private static TextReader _reader;
        private static TextWriter _writer;

        public static void Main(string[] args)
        {
            InitialiseStreams();

            var items = ReadList();
            var n = items[0];
            var k = items[1];
            var prices = ReadList();

            int currentSum = 0;
            prices.Sort();

            int i = 0;
            for (i = 0; i < n; i++)
            {
                if (currentSum + prices[i] <= k)
                {
                    currentSum += prices[i];
                }
                else
                {
                    break;
                }
            }

            _writer.WriteLine(i);

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
