using System;
using System.IO;
using System.Text;

namespace H_GlobalReplace
{
    public class Solution
    {
        private static TextReader _reader;
        private static TextWriter _writer;

        public static void Main(string[] args)
        {
            InitialiseStreams();

            StringBuilder s = new StringBuilder(_reader.ReadLine());
            string pattern = _reader.ReadLine();
            string res = _reader.ReadLine();

            s.Replace(pattern, res);

            _writer.WriteLine(s);

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
    }
}
