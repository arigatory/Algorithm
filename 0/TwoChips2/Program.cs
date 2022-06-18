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
        int i = 0;
        int j = n - 1;


        while (i < n && j > 0 && i < j)
        {
            var sum = numbers[i] + numbers[j];
            if ( sum == k)
            {
                writer.Write($"{numbers[i]} {numbers[j]}");
                reader.Close();
                writer.Close();
                return;
            }
            else if (sum < k)
            {
                i++;
            }
            else
            {
                j--;
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