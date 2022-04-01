using A_PolynomialHash;
using System;
using System.Collections.Generic;

namespace B_BreakMe
{
    internal class BreakMe
    {
        static int maxlength = 24;
        static string ValidChars = "01";
        static List<string> strings = new List<string>();
        static int a = 1000;
        static int m = 123_987_123;
        static Dictionary<long, string> map = new Dictionary<long, string>();

        static void Main(string[] args)
        {


            //Console.WriteLine(PolynomialHash.Hash(a,m, "ezhgeljkablzwnvuwqvp"));
            //Console.WriteLine(PolynomialHash.Hash(a,m, "gbpdcvkumyfxillgnqrv"));


            Dive("", 0);
            
            Console.WriteLine("No collisions");
        }

        public static void Dive(string prefix, int level)
        {
            level += 1;
            foreach (char c in ValidChars)
            {
                var s = prefix + c;
                var hash = PolynomialHash.Hash(a, m, s);
                if (map.ContainsKey(hash))
                {
                    Console.WriteLine("Cracked:");
                    Console.WriteLine(map[hash]);
                    Console.WriteLine(s);
                    return;
                }
                else
                {
                    map[hash] = s;
                    if (level < maxlength)
                    {
                        Dive(prefix + c, level);
                    }
                }

            }
        }
    }

}
