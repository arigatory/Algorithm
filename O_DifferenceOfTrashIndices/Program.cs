using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace O_DifferenceOfTrashIndices
{

    public class Solution
    {
        private static TextReader _reader;
        private static TextWriter _writer;

        public static void Main(string[] args)
        {
            InitialiseStreams();

            var n = ReadInt();
            var nums = ReadList();
            var k = ReadInt();

            nums.Sort();
            int lo = 0;
            int hi = nums[n-1] - nums[0];

            while (lo < hi)
            {
                var mid = (lo + hi) / 2;
                if (Possible(nums, n, mid, k))
                {
                    hi = mid;
                }
                else
                {
                    lo = mid + 1;
                }
            }

            _writer.WriteLine(lo);


            CloseStreams();
        }

        private static bool Possible(List<int> nums, int n, int guess, int k)
        {
            int l = 0;
            int count = 0;
            for (int r = 0; r < n; r++)
            {
                while (nums[r] - nums[l] > guess)
                {
                    l++;
                }
                count += r - l;
            }
            return count >= k;
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
