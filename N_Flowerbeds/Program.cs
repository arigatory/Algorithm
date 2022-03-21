using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace N_Flowerbeds
{
    public class Solution
    {
        private static TextReader _reader;
        private static TextWriter _writer;

        public static void Main(string[] args)
        {
            InitialiseStreams();

            var n = ReadInt();

            var pieces =  new List <Tuple<int, int>>();
            var result =  new List <Tuple<int, int>>();
                        
            for (var i = 0; i < n; i++)
            {
                var items = ReadList();
                pieces.Add(new Tuple<int, int>(items[0], -items[1]));
            }
            
            pieces.Sort();
            
            int j = 0;
            while (j < n)
            {
                int start = pieces[j].Item1;
                int end = -pieces[j].Item2; 
                while (j < n - 1 && pieces[j+1].Item1 <= end)
                {
                    j++;
                    if (-pieces[j].Item2>end)
                    {
                        end = -pieces[j].Item2;
                    }
                }
                result.Add(new Tuple<int, int>(start, end));
                j++;
            }
            
            _writer.WriteLine(string.Join("\n",result.Select(r => $"{r.Item1} {r.Item2}")));
            
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
