using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace J_SumOfFours
{

    public class Solution
    {
        private static TextReader _reader;
        private static TextWriter _writer;

        public static void Main(string[] args)
        {
            InitialiseStreams();

            var n = ReadInt();
            var s = ReadInt();
            var numbers = ReadList();

            var result = FourSum(numbers, s);

            _writer.WriteLine(result.Count);

            foreach (var item in result)
            {
                _writer.WriteLine(string.Join(" ", item));
            }

            CloseStreams();
        }

        static List<List<int>> FourSum(List<int> nums, int target)
        {
            nums.Sort();
            return kSum(nums, target, 0, 4);
        }

        static private List<List<int>> kSum(List<int> nums, int target, int start, int k)
        {
            List<List<int>> result = new List<List<int>>();
            if (start == nums.Count)
            {
                return result;
            }

            int averageValue = target / k;

            if (nums[start] > averageValue || averageValue > nums.Last())
            {
                return result;
            }

            if (k == 2)
            {
                return TwoSum(nums, target, start);
            }

            for (int i = start; i < nums.Count; i++)
            {
                if (i == start || nums[i - 1] != nums[i])
                {
                    foreach (var subset in kSum(nums, target - nums[i], i + 1, k - 1))
                    {
                        var list = new List<int>();
                        list.Add(nums[i]);
                        list.AddRange(subset);
                        result.Add(list);
                    }
                }
            }
            return result;
        }

        static private List<List<int>> TwoSum(List<int> nums, int target, int start)
        {
            var result = new List<List<int>>();
            int lo = start;
            int hi = nums.Count - 1;

            while (lo < hi)
            {
                int currSum = nums[lo] + nums[hi];
                if (currSum < target || (lo > start && nums[lo] == nums[lo - 1]))
                {
                    ++lo;
                }
                else if (currSum > target || (hi < nums.Count - 1 && nums[hi] == nums[hi + 1]))
                {
                    --hi;
                }
                else
                {
                    result.Add(new List<int> { nums[lo++], nums[hi--] });
                }
            }
            return result;
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
