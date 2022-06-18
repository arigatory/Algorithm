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

        if (n==0)
        {
            writer.WriteLine(0);
            reader.Close();
            writer.Close();
            return;
        }
        
        var result = new List<int>();
        var d = n;
        var m = 0;
        while (d != 0)
        {
            m = d % 2;
            d = d/2;
            result.Insert(0,m);
        }

        writer.WriteLine(string.Join("", result));


        reader.Close();
        writer.Close();
    }

    private static int ReadInt()
    {
        return int.Parse(reader.ReadLine());
    }
}