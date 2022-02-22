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

        var n = ReadList();
        if ((n[0] & 1) == (n[1] & 1) && (n[1] & 1) == (n[2] & 1))
        {
            writer.Write("WIN");
        }
        else
        {
            writer.Write("FAIL");
        }

        reader.Close();
        writer.Close();
    }

    private static List<int> ReadList()
    {
        return reader.ReadLine()
            .Split(new[] { ' ', '\t', }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToList();
    }
}