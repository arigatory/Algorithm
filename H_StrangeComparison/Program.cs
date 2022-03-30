using System;
using System.Collections.Generic;
using System.IO;

namespace H_StrangeComparison
{
    public class Solution
    {
        private static TextReader _reader;
        private static TextWriter _writer;

        public static void Main(string[] args)
        {
            InitialiseStreams();

            string s1 = _reader.ReadLine();
            string s2 = _reader.ReadLine();

            var dict1 = new Dictionary<char, char>();
            var dict2 = new Dictionary<char, char>();

            int n1 = s1.Length;
            int n2 = s2.Length;

            if (n1 != n2)
            {
                _writer.WriteLine("NO");
                CloseStreams();
                return;
            }

            for (int i = 0; i < n1; i++)
            {
                if (dict1.ContainsKey(s1[i]))
                {
                    if (dict1[s1[i]] != s2[i])
                    {
                        _writer.WriteLine("NO");
                        CloseStreams();
                        return;
                    }
                }
                else
                {
                    if (dict1.ContainsValue(s2[i]))
                    {
                        _writer.WriteLine("NO");
                        CloseStreams();
                        return;
                    }
                    dict1[s1[i]] = s2[i];
                }
            }
            _writer.WriteLine("YES");
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
