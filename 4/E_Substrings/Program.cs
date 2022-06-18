using System;
using System.Collections.Generic;
using System.IO;


namespace E_Substrings
{

    public class Solution
    {
        private static TextReader _reader;
        private static TextWriter _writer;

        public static void Main(string[] args)
        {
            InitialiseStreams();

            var s = _reader.ReadLine();

            int max = 0;

            int right = 0;
            int left = 0;

            var charIndexDict = new Dictionary<char, int>();

            var current = 0;

            while (right < s.Length && left <= right)
            {

                if (!charIndexDict.ContainsKey(s[right]))
                {
                    charIndexDict[s[right]] = right;
                    current++;
                    if (current > max)
                    {
                        max = current;
                    }
                }
                else
                {
                    var newLeftIndex = charIndexDict[s[right]] + 1;
                    current = right - newLeftIndex + 1;
                    for (int i = left; i < newLeftIndex; i++)
                    {
                        charIndexDict.Remove(s[i]);
                    }
                    charIndexDict[s[right]] = right;
                    left = newLeftIndex;
                }
                right++;
            }


            _writer.WriteLine(max);


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
