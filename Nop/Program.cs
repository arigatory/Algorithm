using System;
using System.Collections.Generic;
using System.Linq;

namespace Nop
{
    internal class Program
    {
        static List<(int,int)>[,] cache;
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<int> a = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToList();
            int m = int.Parse(Console.ReadLine());
            List<int> b = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToList();

            cache = new List<(int,int)>[n,m];
            var result = GetNop(a, a.Count, b, b.Count);

            if (result.Count == 0)
            {
                Console.WriteLine(0);
            }
            else
            {
                Console.WriteLine(result.Count);
                Console.WriteLine(String.Join(" ", result.Select(i => i.Item1).OrderBy(v => v)));
                Console.WriteLine(String.Join(" ", result.Select(i => i.Item2).OrderBy(v => v)));
            }

        }

        public static List<(int, int)> GetNop(List<int> a, int n, List<int> b, int m)
        {
            if (n <= 0 || m <= 0)
            {
                return new List<(int, int)>();
            }
            if (cache[n - 1, m - 1] != null)
            {
                return cache[n - 1, m - 1];
            }
            cache[n - 1, m - 1] = new List<(int, int)>();
            if (a[n - 1] == b[m - 1])
            {
                cache[n - 1, m - 1].Add((n, m));
                cache[n - 1, m - 1].AddRange(GetNop(a, n - 1, b, m - 1));
            }
            else
            {
                var v1 = GetNop(a, n, b, m - 1);
                var v2 = GetNop(a, n - 1, b, m);
                if (v1.Count > v2.Count)
                {
                    cache[n - 1, m - 1].AddRange(v1);
                }
                else
                {
                    cache[n - 1, m - 1].AddRange(v2);
                }
            }

            return cache[n - 1, m - 1];
        }
    }
}
