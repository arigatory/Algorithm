using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace D_Cookies
{
    public class Solution
    {
        private static TextReader _reader;
        private static TextWriter _writer;

        public static void Main(string[] args)
        {
            InitialiseStreams();

            var n = ReadInt();
            var children = ReadList();
            var m = ReadInt();
            var cookies = ReadList();

            children.Sort();
            cookies.Sort();

            int count = 0;

            int i = 0;
            int j = 0;
            while (i < n)
            {
                while (j < m)
                {
                    if (children[i] <= cookies[j])
                    {
                        j++;
                        count++;
                        break;
                    }
                    j++;
                    if (j >= m)
                    {
                        break;
                    }
                }
                i++;
                if (j >= m)
                {
                    break;
                }
            }

            _writer.WriteLine(count);

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
