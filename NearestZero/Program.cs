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


        int i = 0;
        var result = new List<List<int>>();
        bool foundZero = false;
        int distance = 0;
        int count = 0;
        int previousIndex = 0;
        while (i < n)
        {
            if (numbers[i] == 0)
            {
                var part = new List<int>();
                part.Add(numbers[i]);
                i++;
                while (i < n && numbers[i]!= 0)
                {
                    part.Add(numbers[i]);
                    i++;
                }
                if (i == n)
                {
                    result.Add(part);
                    break;
                }
                part.Add(numbers[i]);
                result.Add(part);
            }
        }

        int j;
        foreach (var item in result)
        {
            i = 0;
            j = item.Count - 1;
            while (i<j)
            {
                item[i] = i;
                item[j] = i;
                i++;
                j--;
            }
            Console.WriteLine(String.Join("", item));
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