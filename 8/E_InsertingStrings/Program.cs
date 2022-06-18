using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace E_InsertingStrings
{
    public class Solution
    {
        private static TextReader _reader;
        private static TextWriter _writer;

        public static void Main(string[] args)
        {
            InitialiseStreams();

            var s = _reader.ReadLine();
            var n = ReadInt();

            var dict = new Dictionary<int, string>();

            for (int i = 0; i < n; i++)
            {
                var items = _reader.ReadLine().Split();
                dict.Add(int.Parse(items[1]), items[0]);
            }

            var result = new StringBuilder();
            for (int i = 0; i < s.Length; i++)
            {
                if (dict.ContainsKey(i))
                {
                    result.Append(dict[i]);
                }
                result.Append(s[i]);
            }
            if (dict.ContainsKey(s.Length))
            {
                result.Append(dict[s.Length]);
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
    }


}
