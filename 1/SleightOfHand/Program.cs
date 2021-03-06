// 65530628
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class Solution
{
    private static TextReader reader;
    private static TextWriter writer;

    public static void Main(string[] args)
    {
        reader = new StreamReader(Console.OpenStandardInput());
        writer = new StreamWriter(Console.OpenStandardOutput());

        var k = ReadInt();
        k *= 2;

        int n = 4;
        var keys = new Dictionary<int,int>();
        
        for (int i = 0; i < n; i++)
        {
            var line = reader.ReadLine();
            foreach (var ch in line)
            {
                int num = ch - '0';
                if (ch == '.')
                {
                    continue;
                }
                if (keys.ContainsKey(num))
                {
                    keys[num]++;
                }
                else
                {
                    keys.Add(num, 1);
                }
            }
        }

        int total = 0;
        foreach (var item in keys)
        {
            if (k >= item.Value)
            {
                total++;
            }
        }

        writer.Write(total);
        reader.Close();
        writer.Close();
    }

    private static int ReadInt()
    {
        return int.Parse(reader.ReadLine());
    }

    private static List<int> ReadList()
    {
        return reader.ReadLine()
            .Split(new[] { ' ', '\t', }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToList();
    }
}