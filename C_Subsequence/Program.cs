using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;


namespace C_Subsequence
{
    public class Solution
    {
        private static TextReader _reader;
        private static TextWriter _writer;

        public static void Main(string[] args)
        {
            InitialiseStreams();

            var s = _reader.ReadLine();
            var t = _reader.ReadLine();

            var result = true;
            var n = s.Length;
            var m = t.Length;
            int s_i = 0;
            int t_i = 0;
            while (s_i < n)
            {
                var ch = s[s_i];
                while (t_i < m)
                {
                    if (t[t_i] == ch)
                    {
                        t_i++;
                        break;
                    }
                    t_i++;
                }

                if (t_i == m)
                {
                    if (s_i!=n-1)
                    {
                        result = false;
                    }
                    else
                    {
                        if (ch != t[t_i-1])
                        {
                            result = false;
                        }
                    }
                    break;
                }

                s_i++;
            }
            
            _writer.WriteLine(result);
            
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