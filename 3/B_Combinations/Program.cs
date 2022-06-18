using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace B_Combinations
{
    public class Solution
    {
        private static TextReader _reader;
        private static TextWriter _writer;
        private static List<string> _result = new();
        private static Dictionary<int, char[]> _keyboard = new Dictionary<int, char[]>
        {
            { 2, new char[] { 'a','b','c' } },
            { 3, new char[] { 'd','e','f' } },
            { 4, new char[] { 'g','h','i' } },
            { 5, new char[] { 'j','k','l' } },
            { 6, new char[] { 'm','n','o' } },
            { 7, new char[] { 'p','q','r', 's' } },
            { 8, new char[] { 't', 'u','v'} },
            { 9, new char[] { 'w','x','y','z' } },
        };

        public static void Main(string[] args)
        {
            InitialiseStreams();

            var numbers = ReadList();

            GenerateWords("", numbers, 0, numbers.Count);

            _writer.WriteLine(string.Join(" ", _result));

            CloseStreams();
        }

        private static void GenerateWords(string s, List<int> numbers, int i, int length)
        {
            if (length == 0)
            {
                _result.Add(s);
            }
            else
            {
                foreach (var ch in _keyboard[numbers[i]])
                {
                    GenerateWords(s + ch, numbers, i + 1, length - 1);
                }
            }
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
                .Trim().ToCharArray()
                .Select(c => c - '0')
                .ToList();
        }
    }
}
