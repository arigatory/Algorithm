using System;
using System.IO;
namespace A_PolynomialHash
{

    public class PolynomialHash
    {
        private static TextReader _reader;
        private static TextWriter _writer;

        public static void Main(string[] args)
        {
            InitialiseStreams();

            var a = int.Parse(_reader.ReadLine());
            var m = int.Parse(_reader.ReadLine());
            var s = _reader.ReadLine();

            var hash = Hash(a, m, s);

            _writer.WriteLine(hash);

            CloseStreams();
        }

        public static long Hash(int q, int R, string s)
        {
            var n = s.Length;
            long hash = 0;

            for (var i = 0; i < n; i++)
            {
                hash *= q;
                hash += s[i];
                if (hash >= R)
                {
                    hash %= R;
                }
            }

            return hash;
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
    }

}
