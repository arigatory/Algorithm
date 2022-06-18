using System;
using System.IO;

public class Solution
{
    private static int getFibNum(int i)
    {
        if (i == 0 || i == 1)
        {
            return 1;
        }
        else
        {
            return getFibNum(i - 1) + getFibNum(i - 2);
        }
    }


    private static TextReader _reader;
    private static TextWriter _writer;

    public static void Main(string[] args)
    {
        InitialiseStreams();

        var n = ReadInt();

        var result = getFibNum(n);

        _writer.WriteLine(result);

        CloseStreams();
    }

    private static void CloseStreams()
    {
        _reader.Close();
        _writer.Close();
    }

    private static void InitialiseStreams()
    {
        _reader = new StreamReader(Console.OpenStandardInput());
        _writer = new StreamWriter(Console.OpenStandardOutput());
    }

    private static int ReadInt()
    {
        return int.Parse(_reader.ReadLine());
    }
}