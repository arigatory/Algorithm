using System;
using System.IO;

namespace K_CompareTwoStrings
{
    public class Solution
    {
        private static TextReader _reader;
        private static TextWriter _writer;

        public static void Main(string[] args)
        {
            InitialiseStreams();

            var s1 = _reader.ReadLine();
            var s2 = _reader.ReadLine();

            _writer.WriteLine(IsDistanceLessOne(s1, s2));

            CloseStreams();

        }

        public static int IsDistanceLessOne(string s1, string s2)
        {
            int i = 0;
            int j = 0;

            while (i < s1.Length && j < s2.Length)
            {
                if (s1[i] % 2 != 0)
                {
                    i++;
                    continue;
                }

                if (s2[j] % 2 != 0)
                {
                    j++;
                    continue;
                }

                if (s1[i] == s2[j])
                {
                    i++;
                    j++;
                }
                else
                {
                    return s1[i] > s2[j] ? 1 : -1;
                }
            }

            while (i<s1.Length && s1[i] % 2 != 0)
            {
                i++;
            }

            while (j<s2.Length && s2[j] % 2 !=0)
            {
                j++;
            }
            if (i == s1.Length && j == s2.Length)
            {
                return 0;
            }
            else if (i < s1.Length)
            {
                return 1;
            }
            else
            {
                return -1;
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
    }
}
