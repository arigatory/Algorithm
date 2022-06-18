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
        var text = reader.ReadLine();

        int maxLength = 0;
        int resultIndex = 0;
        int currentCounter = 0;
        int indexStart = 0;

        bool insideWord = false;
        for (int i = 0; i < n; i++)
        {

            if (insideWord)
            {
                if (text[i] == ' ')
                {
                    insideWord = false;
                    if (currentCounter > maxLength)
                    {
                        maxLength = currentCounter;
                        resultIndex = indexStart;
                    }
                    currentCounter = 0;
                }
                else
                {
                    currentCounter++;
                }
            }
            else
            {
                if (text[i] == ' ')
                {

                }
                else
                {
                    insideWord = true;
                    currentCounter = 1;
                    indexStart = i;
                }
            }
        }
        if (currentCounter > maxLength)
        {
            maxLength = currentCounter;
            resultIndex = indexStart;
        }

        writer.WriteLine(text.Substring(resultIndex,maxLength));
        writer.Write(maxLength);
        reader.Close();
        writer.Close();
    }

    private static int ReadInt()
    {
        return int.Parse(reader.ReadLine());
    }
}