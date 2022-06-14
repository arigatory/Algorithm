using System;
using System.Collections.Generic;
using System.Linq;

namespace K_Horoscopes
{
    internal class Program
    {
        static List<(int, int)>[,] cache;
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<int> a = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToList();
            int m = int.Parse(Console.ReadLine());
            List<int> b = Console.ReadLine().Split(" ").Select(i => int.Parse(i)).ToList();

            cache = new List<(int, int)>[n, m];
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
            int[,] dp = new int[n+1,m+1];

            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= m; j++)
                {
                    if (b[j-1] == a[i-1])
                    {
                        dp[i,j] = dp[i-1,j-1] + 1;
                    }
                    else
                    {
                        dp[i, j] = Math.Max(dp[i,j-1], dp[i-1,j]);
                    }
                }
            }

            var answer = new List<(int, int)>();

            int startI = n;
            int startJ = m;

            while (dp[startI,startJ] != 0)
            {
                if (a[startI-1] == b[startJ-1])
                {
                    answer.Add((startI,startJ));
                    startI--;
                    startJ--;
                }
                else
                {
                    if (dp[startI,startJ] == dp[startI-1,startJ])
                    {
                        startI--;
                    }
                    else
                    {
                        startJ--;
                    }
                }
            }



            answer.Reverse();

            return answer;
        }
    }
}
