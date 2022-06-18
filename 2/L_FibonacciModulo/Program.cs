using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace L_FibonacciModulo
{
    public class Solution
    {
        private static int getFibNumModulo(int i)
        {
            if (_indexFibPairs.ContainsKey(i))
            {
                return _indexFibPairs[i];
            }
            else
            {
                _indexFibPairs[i] = _indexFibPairs[i-1] + _indexFibPairs[i-2];
                if (_indexFibPairs[i] >= _modulo)
                {
                    _indexFibPairs[i] -= _modulo;
                }
                return _indexFibPairs[i];
            }
        }

        private static Dictionary<int, int> _indexFibPairs = new Dictionary<int, int>();
        private static TextReader _reader;
        private static TextWriter _writer;
        private static int n;
        private static int _modulo;

        public static void Main(string[] args)
        {
            InitialiseStreams();

            var numbers = ReadList();
            n = numbers[0];
            var k = numbers[1];
            _modulo = (int)Math.Pow(10, k);

            _indexFibPairs[0] = 1;
            _indexFibPairs[1] = 1;
            for (int i = 2; i <= n; i++)
            {
                _indexFibPairs[i] = _indexFibPairs[i - 1] + _indexFibPairs[i - 2];
                if (_indexFibPairs[i] >= _modulo)
                {
                    _indexFibPairs[i] -= _modulo;
                }
            }

            _writer.WriteLine(_indexFibPairs[n]);

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
