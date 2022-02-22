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
        var m = ReadInt();
        var array = new List<List<int>>();

        for (int k = 0; k < n; k++)
        {
            array.Add(ReadList());
        }
        var i = ReadInt();
        var j = ReadInt();

        var result = new List<int>();
        
        if (j > 0)
        {
            result.Add(array[i][j - 1]);
        }

        if (j < m - 1)
        {
            result.Add(array[i][j + 1]);
        }

        if (i > 0)
        {
            result.Add(array[i - 1][j]);
        }

        if (i < n - 1)
        {
            result.Add(array[i + 1][j]);
        }
        result.Sort();
        foreach (var r in result)
        {
            writer.Write(r + " ");
        }
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