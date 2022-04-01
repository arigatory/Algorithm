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

            var q = (uint)ReadUint();
            var R = (uint)ReadUint();
            var s = _reader.ReadLine();

            uint hash = Hash(q, R, s);

            _writer.WriteLine(hash);

            CloseStreams();
        }

        private static uint Hash(uint q, uint R, string s)
        {
            var n = s.Length;
            uint hash = 0;

            for (var i = 0; i < n; i++)
            {
                hash *= q;
                hash %= R;
                hash += s[i];
                hash %= R;
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

        private static uint ReadUint()
        {
            return uint.Parse(_reader.ReadLine());
        }
    }

}
