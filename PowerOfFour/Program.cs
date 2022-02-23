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
        int l = (int)Math.Log2(n);
        writer.WriteLine(n == 1 << l && l % 2 == 0);

        reader.Close();
        writer.Close();
    }

    private static int ReadInt()
    {
        return int.Parse(reader.ReadLine());
    }

}