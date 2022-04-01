using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace G_Competition
{
    public class Solution
    {
        public static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            int maxLength = 0;

            if (n != 0)
            {
                var numbers = ReadList();

                var indexSumDict = new Dictionary<int, int>();

                int counter = 0;

                for (int i = 1; i <= n; i++)
                {
                    counter += numbers[i - 1] == 0 ? -1 : 1;
                    if (counter == 0)
                    {
                        maxLength = i;
                    }
                    else if (indexSumDict.ContainsKey(counter))
                    {
                        int probableMax = i - indexSumDict[counter];
                        if (probableMax > maxLength)
                        {
                            maxLength = probableMax;
                        }
                    }
                    else
                    {
                        indexSumDict.Add(counter, i);
                    }
                }
            }

            Console.WriteLine(maxLength);
        }

        private static List<int> ReadList()
        {
            return Console.ReadLine()
                .Split(new[] { ' ', '\t', }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
        }
    }

}
