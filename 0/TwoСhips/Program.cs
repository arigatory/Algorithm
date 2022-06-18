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
        var numbers = ReadList();
        var k = ReadInt();

        for (var i = 0; i < n; i++)
        {
            for (int j = i+1; j < n; j++)
            {
                if (numbers[i] + numbers[j] == k)
                {
                    writer.Write($"{numbers[i]} {numbers[j]}");
                    reader.Close();
                    writer.Close();
                    return;
                }
            }
        }
        writer.Write("None");
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