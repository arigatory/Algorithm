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
        private static int[] _powers;
        private static long[] _hashes;

        public static void Main(string[] args)
        {
            InitialiseStreams();

            var a = ReadInt();
            var m = ReadInt();
            var s = _reader.ReadLine().Trim();
            var t = ReadInt();
            int n = s.Length;

            CalculatePowers(a, m, n);
            if (_powers.Any(p=> p<0))
            {
                Console.WriteLine("NOOOO");
            }

            for (var i = 0; i < t; i++)
            {
                var items = ReadList();
                var l = items[0];
                var r = items[1];

                _writer.WriteLine(Hash(m, s, l, r));
            }

            CloseStreams();
        }

        private static void CalculatePowers(int a, int m, int n)
        {
            _powers = new int[n + 1];
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

        public static long Hash(string s, int i, int j)
        {
            long hash = 0;
            var n = j - i;
            int left = i;
            for (var k = i; k < j; k++)
            {
                hash += Mod(s[k] * _powers[n -], m);
            }

            return hash;
        }

        public static void CalculateHashes(int a, int m, string s)
        {
            var n = s.Length;
            _hashes = new long[n];
            long hash = 0;

            for (var i = 0; i < n; i++)
            {
                hash *= a;
                hash += s[i];
                
                _hashes[i] = Mod(hash,m);
            }
        }

        static int Mod(int k, int n)  { return ((k %= n) < 0) ? k + n : k; }
        static long Mod(long k, int n)  { return ((k %= n) < 0) ? k + n : k; }
    }
}

