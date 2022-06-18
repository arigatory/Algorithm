using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace B_Schedule
{

    public class Solution
    {
        private static TextReader _reader;
        private static TextWriter _writer;
        const float epsilon = 0.0001f;
        public static void Main(string[] args)
        {
            InitialiseStreams();

            var n = ReadInt();
            var pairs = new List<(float, float)>();
            for (var i = 0; i < n; i++)
            {
                var numbers = ReadFloat();
                pairs.Add((numbers[0], numbers[1]));
            }

            pairs = pairs.OrderBy(x => (x.Item2, x.Item1)).ToList();
            int count = 0;
            float currentTime = 0;
            StringBuilder sb = new StringBuilder(n << 2);
            for (int i = 0; i < pairs.Count; i++)
            {
                if (pairs[i].Item1 >= currentTime - epsilon)
                {
                    count++;
                    currentTime = pairs[i].Item2;
                    sb.AppendLine($"{pairs[i].Item1} {pairs[i].Item2}");
                }
            }
            _writer.WriteLine(count);
            _writer.WriteLine(sb);


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

        private static List<float> ReadFloat()
        {
            return _reader.ReadLine()
                .Split(new[] { ' ', '\t', }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => float.Parse(x, CultureInfo.InvariantCulture.NumberFormat))
                .ToList();
        }
    }

}
