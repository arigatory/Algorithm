// 65530096
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

        var result = new List<int>(numbers);

        int i = 0;
        while (result[i] != 0)
        {
            result[i] = -1;
            i++;
        }
        
        int counter = 0;

        while (i < n)
        {
            if (result[i] == 0)
            {
                counter = 0;
            }
            else
            {
                counter++;
            }
            result[i] = counter;
            i++;
        }
        
        i--;
        while (i >= 0)
        {
            if (result[i] == 0)
            {
                counter = 0;
            }
            else
            {
                counter++;
            }
            if (counter < result[i])
            {
                result[i] = counter;
            }
            if (result[i] == -1)
            {
                result[i] = counter;
            }
            i--;
        }

        foreach (var item in result)
        {
            writer.Write(item + " ");
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