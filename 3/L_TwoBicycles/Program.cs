using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace L_TwoBicycles
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
            var price = ReadInt();

            var result1 = getDay(numbers, price, 0, n - 1);
            var result2 = getDay(numbers, price * 2, 0, n - 1);


            _writer.WriteLine($"{result1} {result2}");

            CloseStreams();
        }

        private static int getDay(List<int> numbers, int price, int left, int right)
        {
            int mid;
            while (right != left)
            {
                mid = (left + right) / 2;
                if (price > numbers[mid])
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid;
                }
            }
            if (numbers[right] >= price)
            {
                return right + 1;
            }
            return -1;

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
