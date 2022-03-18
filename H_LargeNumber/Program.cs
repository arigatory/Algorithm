using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace H_LargeNumber
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

            Sort(n, numbers);


            _writer.WriteLine(string.Join("", numbers));

            CloseStreams();
        }

        private static void Sort(int n, List<string> numbers)
        {
            bool needSwap = true;
            bool sorted = true;

            for (int j = n; j > 1; j--)
            {
                needSwap = false;
                for (int i = 1; i < j; i++)
                {
                    if (NeedSwap(numbers[i - 1], numbers[i]))
                    {
                        needSwap = true;
                        sorted = false;
                        var temp = numbers[i - 1];
                        numbers[i - 1] = numbers[i];
                        numbers[i] = temp;
                    }
                }
                if (sorted)
                {
                    break;
                }
                if (!needSwap)
                    break;
            }
        }

        private static bool NeedSwap(string s1, string s2)
        {
            var op1 = s1 + s2;
            var op2 = s2 + s1;
            return op1.CompareTo(op2) > 0 ? false : true;
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
