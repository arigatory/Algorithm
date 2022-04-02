using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace C_PrefixHashes
{
    public class Solution
    {
        private static TextReader _reader;
        private static TextWriter _writer;
        private static long[] _powers;
        private static long[] _hashes;

        public static void Main(string[] args)
        {
            InitialiseStreams();

            var a = ReadInt();
            var m = ReadInt();
            var s = _reader.ReadLine();
            var t = ReadInt();
            int n = s.Length;

            CalculateHashes(a, m, s, n);
            CalculatePowers(a, m, n);

            for (var i = 0; i < t; i++)
            {
                var items = ReadList();
                var l = items[0];
                var r = items[1];

                _writer.WriteLine(Hash(a, m, s, n, l, r));
            }

            CloseStreams();
        }

        private static void CalculatePowers(int a, int m, int n)
        {
            _powers = new long[n + 1];
            _powers[0] = 1;
            for (int i = 1; i < n; i++)
            {
                _powers[i] = Mod(_powers[i - 1] * a, m);
            }
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

        public static long Hash(int a, int m, string s, int n, int i, int j)
        {
            long hash = Mod(_hashes[j] - _hashes[i - 1] * _powers[j - i + 1], m);

            return hash;
        }

        public static void CalculateHashes(int a, int m, string s, int n)
        {
            _hashes = new long[n + 1];
            long hash = 0;

            _hashes[0] = 0;

            for (var i = 0; i < n; i++)
            {
                hash = Mod(hash * a, m);
                hash = Mod(hash + s[i], m);

                _hashes[i + 1] = hash;
            }
        }

        static long Mod(long k, int n) { return ((k %= n) < 0) ? k + n : k; }
    }
}

