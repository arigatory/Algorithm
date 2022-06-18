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

        var n = ReadInt();
        var days = ReadList();

        if (n == 1)
        {
            writer.Write(1);
            reader.Close();
            writer.Close();
            return;
        }

        if (n == 2)
        {
            writer.Write(days[0] == days[1] ? 0 : 1);
            reader.Close();
            writer.Close();
            return;
        }

        int count = 0;
        if (days[0] > days[1])
        {
            count++;
        }

        if (days[n - 1] > days[n - 2])
        {
            count++;
        }
        for (var i = 1; i < n - 1; i++)
        {
            if (days[i] > days[i + 1] && days[i] > days[i - 1])
            {
                count++;
            }
        }
        writer.Write(count);
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