using System;
using System.IO;

namespace I_DifferentSearchTrees
{

    public class Solution
    {
        private static TextReader _reader;
        private static TextWriter _writer;

        public static void Main(string[] args)
        {
            InitialiseStreams();

            var n = ReadInt();

            var res = CalculateTrees(n);

            _writer.WriteLine(res);

            CloseStreams();
        }

        private static int CalculateTrees(int n)
        {
            if (n == 0 || n == 1)
                return 1;
            if (n == 2)
                return 2;
            if (n == 3)
                return 5;

            int s = 0;
            for (int i = 0; i < n; i++)
            {
                s += CalculateTrees(i) * CalculateTrees(n - i - 1);
            }
            return s;
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
    }


}
