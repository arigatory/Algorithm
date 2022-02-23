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


        var word1 = reader.ReadLine();
        var word2 = reader.ReadLine();

        Dictionary<char, int> charCount = new Dictionary<char, int>();

        char result;

        foreach (var ch in word1)
        {
            if (charCount.ContainsKey(ch))
            {
                charCount[ch]++;
            }
            else
            {
                charCount.Add(ch, 1);
            }
        }

        foreach (var ch in word2)
        {
            if (charCount.ContainsKey(ch))
            {
                charCount[ch]--;
            }
            else
            {
                writer.WriteLine(ch.ToString());
                reader.Close();
                writer.Close();
                return;
            }
        }

        result = charCount.FirstOrDefault(x=> x.Value != 0).Key;

        writer.WriteLine(result.ToString());

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