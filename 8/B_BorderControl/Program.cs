using System;
using System.IO;

namespace B_BorderControl
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

            if (IsDistanceLessOne(s1, s2))
            {
                _writer.WriteLine("OK");
            }
            else
            {
                _writer.WriteLine("FAIL");
            }

            CloseStreams();

        }

        public static bool IsDistanceLessOne(string s1, string s2)
        {
            if (s1.Length < s2.Length)
            {
                var temp = s1;
                s1 = s2;
                s2 = temp;
            }

            int n = s1.Length;
            int m = s2.Length;

            if (n - m > 1)
            {
                return false;
            }
            else if (m == n)
            {
                int i = 0;
                int errCount = 0;
                while (i < m)
                {
                    if (s1[i] != s2[i])
                    {
                        errCount++;
                        if (errCount > 1)
                        {
                            return false;
                        }
                    }
                    i++;
                }
                return true;
            }
            else
            {
                int i = 0;
                int delta = 0;
                int errCount = 0;
                while (i < m)
                {
                    if (s1[i + delta] != s2[i])
                    {
                        errCount++;
                        delta++;
                        if (errCount > 1)
                        {
                            return false;
                        }
                    }
                    i++;
                }
            }

            return true;
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
