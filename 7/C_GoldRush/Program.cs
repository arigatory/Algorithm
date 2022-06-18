using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace C_GoldRush
{
    public class Solution
    {
        private static TextReader _reader;
        private static TextWriter _writer;

        public static void Main(string[] args)
        {
            InitialiseStreams();

            var m = long.Parse(_reader.ReadLine());
            var n = ReadInt();

            var weightPricePairs = new List<(long weight, int price)>();

            for (var i = 0; i < n; i++)
            {
                var items = _reader.ReadLine().Split();
                weightPricePairs.Add((weight: long.Parse(items[1]), int.Parse(items[0])));
            }
            weightPricePairs = weightPricePairs.OrderByDescending(p=> p.price).ToList();
            
            long sum = 0;
            long currentWeight = 0;

            for (int i = 0; i < weightPricePairs.Count; i++)
            {
                var possibleWeight = currentWeight + weightPricePairs[i].weight;
                if (possibleWeight < m)
                {
                    currentWeight = possibleWeight;
                    sum += weightPricePairs[i].price * weightPricePairs[i].weight;
                }
                else
                {
                    possibleWeight = m - currentWeight;
                    sum += weightPricePairs[i].price * possibleWeight;
                    break;
                }
            }

            _writer.WriteLine(sum);
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
