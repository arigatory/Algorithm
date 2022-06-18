using System;
using System.Collections;
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
        var result = new List<int>();
        int m = n;
        int i = 2;
        while (m % i == 0)
        {
            result.Add(i);
            m /= i;
        }
        i++;
        while (i <= m)
        {
            while (m % i == 0)
            {
                result.Add(i);
                m /= i;
            }
            i += 2;
        }

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