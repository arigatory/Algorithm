using System;
using System.IO;

namespace L_PrefixFunction
{
    public class Solution
    {
        private static TextReader _reader;
        private static TextWriter _writer;

        public static void Main(string[] args)
        {
            InitialiseStreams();

            var s = _reader.ReadLine();

            int[] pi = new int[s.Length];
            pi[0] = 0;

            int k;
            for (int i = 1; i < s.Length; i++)
            {
                k = pi[i - 1];
                while (k > 0 && s[k] != s[i])
                {
                    k = pi[k - 1];
                }
                if (s[k] == s[i])
                {
                    k++;
                }
                pi[i] = k;
            }


            _writer.WriteLine(String.Join(" ", pi));
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
